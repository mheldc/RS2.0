Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class frmSearch
    Dim SourceForm As String = ""

    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function Open() As MySqlConnection
        Dim Cn As New MySqlConnection("Server=localhost;Database=rmsv2;Uid=root;Pwd='';")
        Try
            Cn.Open()
            Return Cn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function LoadSeachItems(ByVal SourceName As String, ParamList As ArrayList) As Integer
        SourceForm = SourceName
        Dim ItemId As Integer = 0
        Using Cn As MySqlConnection = Open()
            With dgvSearchItems
                .Columns.Clear()

                Dim bSearch As New DataGridViewButtonColumn()
                With bSearch
                    .HeaderText = ""
                    .Text = "Select"
                    .Name = "dgvSelect"
                    .Width = 70
                    .UseColumnTextForButtonValue = True
                    .Frozen = True
                End With
                .Columns.Add(bSearch)

            End With

            Try
                Select Case SourceName
                    Case "frmCandidateProfile"
                        Dim QryString As String = <Command>
                                                      	Select 
				                                            `ci_id`, `referenceid`,
				                                             concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ' , substr(middlename,1,1) , '.') end) as fullname,
				                                             case `recstatus` when 0 then 'Deleted / For Purging' else 'Active' end recstatus
			                                            From rms_candidateinfo;
                                                  </Command>.Value
                        Dim ds As New DataSet, da As New MySqlDataAdapter
                        Using Cm As New MySqlCommand(QryString, Cn)
                            da.SelectCommand = Cm
                            da.Fill(ds)
                        End Using

                        With dgvSearchItems
                            .DataSource = ds.Tables(0)
                            FormatGridColumn(1, "", False, False, False, 50)
                            FormatGridColumn(2, "Reference Id", True, True, True, 150)
                            FormatGridColumn(3, "Candidate Name", True, True, True, 250)
                            FormatGridColumn(4, "Status", True, True, True, 100)
                        End With


                    Case Else
                        MsgBox("Other query")
                End Select

            Catch ex As Exception

            End Try
        End Using
        Return 0
    End Function

    Private Sub FormatGridColumn(ByVal ColumnId As Integer, ByVal HeaderText As String, Optional IsFrozen As Boolean = False, _
                                 Optional ByVal IsVisible As Boolean = True, Optional ByVal IsReadOnly As Boolean = False, Optional ByVal ColumnWidth As Double = 100)
        With dgvSearchItems
            .Columns(ColumnId).Frozen = IsFrozen
            .Columns(ColumnId).Visible = IsVisible
            .Columns(ColumnId).Width = ColumnWidth
            .Columns(ColumnId).HeaderText = HeaderText
        End With
    End Sub

    Private Sub dgvSearchItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearchItems.CellClick
        If e.ColumnIndex = 0 Then

            Select Case SourceForm
                Case "frmCandidateProfile"
                    Me.Close()
                    frmCandidateProfile.SelCandidateId = dgvSearchItems.Rows(e.RowIndex).Cells(1).Value
                Case Else

            End Select
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Using Cn As MySqlConnection = Open()
                Select Case SourceForm
                    Case "frmCandidateProfile"
                        Dim QryString As String = <Command>
                                                      	Select 
				                                            `ci_id`, `referenceid`,
				                                             concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ' , substr(middlename,1,1) , '.') end) as fullname,
				                                             case `recstatus` when 0 then 'Deleted / For Purging' else 'Active' end recstatus
			                                            From rms_candidateinfo
                                                        Where (`referenceid` like concat('%',@searchparam, '%') or
	                                                           `lastname`  like concat('%',@searchparam, '%') or
	                                                           `firstname` like concat('%',@searchparam, '%'));
                                                  </Command>.Value
                        Dim ds As New DataSet, da As New MySqlDataAdapter
                        Using Cm As New MySqlCommand(QryString, Cn)
                            Cm.Parameters.AddWithValue("@searchparam", txtSearch.Text)
                            da.SelectCommand = Cm
                            da.Fill(ds)
                        End Using

                        With dgvSearchItems
                            .DataSource = ds.Tables(0)
                            FormatGridColumn(1, "", False, False, False, 50)
                            FormatGridColumn(2, "Reference Id", True, True, True, 150)
                            FormatGridColumn(3, "Candidate Name", True, True, True, 250)
                            FormatGridColumn(4, "Status", True, True, True, 100)
                        End With


                    Case Else
                        MsgBox("Other query")
                End Select
            End Using


        End If
    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class