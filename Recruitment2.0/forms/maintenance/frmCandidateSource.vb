Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmCandidateSource

    Dim CSourceTranType As Integer = -1
    Dim CSourceSelectedId As Integer = 0

    Private Sub Tran_CandidateSource(ByVal TranType As Integer, ByVal SourceId As Integer, ByVal CurrentUserId As Integer, _
                                     Optional ByVal SourceDesc As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SourceId))
        Params.Add(New MySqlParameter("@sourcedesc", SourceDesc))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidatesource", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_candidatesource", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        SelectedId = CInt(Drow("cs_id"))
                        txtSource.Text = Drow("sourcecode")
                        txtSourceDesc.Text = Drow("description")
                    Next
                Case 4

                Case Else

            End Select
        End Using

    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        txtSource.Clear()
        txtSourceDesc.Clear()
        pnlInfo.Enabled = IsEnabled
        CSourceSelectedId = 0
        CSourceTranType = -1
    End Sub

    Private Sub frmCandidateSource_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        CSourceTranType = 0
        ClearNEnableFields(True)
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        CSourceTranType = 1
        pnlInfo.Enabled = True
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If SelectedId = 0 Then
            MsgBox("You have not selected any item to delete. Select an item first then try again", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Manpower Request Information
            Qry = "select count(`ci_id`) from `rms_candidateinfo` where `appsourceid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", CSourceSelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Cannot remove applicant source [" + txtSourceDesc.Text + "] due to it's dependencies in Candidate Information", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Remove [" + txtSourceDesc.Text + "] as candidate source?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
                Qry = "select count(`ci_id`) as datainuse from rms_candidateinfo where `appsourceid` = @sourceid;"
                Params = New ArrayList
                Params.Add(New MySqlParameter("@sourceid", CSourceSelectedId))
                Dim DataInUse As Integer = QueryExec(Qry, Cn, Params, CommandType.Text)
                If DataInUse > 0 Then
                    MsgBox("Unable to remove selected source, it's currently being used." + vbCrLf + _
                           "Select another one and try again.", MsgBoxStyle.Exclamation, "Remove Failed")
                Else
                    Call Tran_CandidateSource(2, CSourceSelectedId, CurrentUID)
                    MsgBox("Candidate source has been removed successfully", MsgBoxStyle.Information, "Removed")
                    Call ClearNEnableFields()
                End If
            End Using
        End If

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If MsgBox("Save candidate source?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_CandidateSource(CSourceTranType, CSourceSelectedId, CurrentUID, txtSourceDesc.Text)
            MsgBox("Candidate source has been saved successfully", MsgBoxStyle.Information, "Saved")
            ClearNEnableFields()
            tsbAdd.Visible = True
            tsbEdit.Visible = True
            tsbDelete.Visible = True
            tsbSeparator.Visible = True
            tsbSearch.Visible = True
            tsbPrint.Visible = True
            tsbCancel.Visible = False
            tsbSave.Visible = False
            Call ClearNEnableFields()
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As Object, e As EventArgs) Handles tsbCancel.Click
        tsbAdd.Visible = True
        tsbEdit.Visible = True
        tsbDelete.Visible = True
        tsbSeparator.Visible = True
        tsbSearch.Visible = True
        tsbPrint.Visible = True
        tsbCancel.Visible = False
        tsbSave.Visible = False
        Call ClearNEnableFields()
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            CSourceSelectedId = SelectedId
            Call Tran_CandidateSource(3, CSourceSelectedId, CurrentUID)
            SelectedId = 0
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class