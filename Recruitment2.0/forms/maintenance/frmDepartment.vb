Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmDepartment

    Dim DepartmentTranType As Integer = -1
    Dim DepartmentId As Integer = 0, DepartmentHeadId As Integer = 0


    Private Sub Tran_Department(ByVal TranType As Integer, ByVal DepartmentId As Integer, ByVal CurrentUserId As Integer, _
                                Optional ByVal DepartmentName As String = Nothing, Optional Description As String = Nothing, Optional DepartmentHeadId As Integer = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", DepartmentId))
        Params.Add(New MySqlParameter("@deptname", DepartmentName))
        Params.Add(New MySqlParameter("@deptdesc", Description))
        Params.Add(New MySqlParameter("@depthead", DepartmentHeadId))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_department", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_department", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        lblCode.Text = Drow("deptcode")
                        txtName.Text = Drow("deptname")
                        txtDesc.Text = Drow("description")
                        cboHeadId.SelectedValue = CInt(Drow("deptheadid"))
                    Next

                Case 4

                Case Else

            End Select
        End Using

    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        lblCode.Text = ""
        txtName.Clear()
        txtDesc.Clear()
        cboHeadId.SelectedValue = -1
        pnlInfo.Enabled = IsEnabled
        DepartmentTranType = -1
        DepartmentId = 0
    End Sub

    Private Sub frmDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' User Profile
            Qry = <Query>
                        select 0 as up_id, '- Select a department head -' as fullname
                        union all
                        select `up_id`, concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ',substr(`middlename`,1,1),'.') end) as fullname
                        from `hrs_userprofile`
                        where `recstatus` = 1;
                  </Query>.Value
            Call FillComboBox(Qry, Cn, "fullname", "up_id", cboHeadId, Nothing, CommandType.Text)
        End Using
    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        ClearNEnableFields(True)
        DepartmentTranType = 0
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If DepartmentId = 0 Then
            MsgBox("You have not selected an item to modify. Select one then try again.", MsgBoxStyle.Exclamation, "Edit Failed")
            Exit Sub
        End If

        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        pnlInfo.Enabled = True
        DepartmentTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If DepartmentId = 0 Then
            MsgBox("You have not selected an item to delete. Please select 1 then try again.", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' User Profile
            Qry = "select count(`up_id`) from `hrs_userprofile` where `dp_id` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", DepartmentId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)

            If HasDependencies > 0 Then
                MsgBox("Unable to remove department due to its dependencies in User Profile.", MsgBoxStyle.Exclamation, "Delete Failed")
                Exit Sub
            End If
        End Using

        If MsgBox("Delete department [" + txtDesc.Text + "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_Department(2, DepartmentId, CurrentUID)
            MsgBox("Department has been deleted successfully.", MsgBoxStyle.Information, "Removed")
            ClearNEnableFields(False)
        End If

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtName.Text.Trim.Length = 0 Then
            MsgBox("Department name is a required field. Enter a valid value then try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If txtDesc.Text.Trim.Length = 0 Then
            MsgBox("Department description is a required field. Enter a valid value then try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If

        If cboHeadId.Items.Count = 0 Then
            DepartmentHeadId = 0
        End If

        If MsgBox("Save department [" + txtDesc.Text + "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_Department(DepartmentTranType, DepartmentId, CurrentUID, txtName.Text, txtDesc.Text, cboHeadId.SelectedValue)
            MsgBox("Department has been saved successfully.", MsgBoxStyle.Information, "Saved")
            tsbCancel.PerformClick()
        End If
    End Sub

    Private Sub tsbCancel_Click(sender As Object, e As EventArgs) Handles tsbCancel.Click
        tsbAdd.Visible = True
        tsbEdit.Visible = True
        tsbDelete.Visible = True
        tsbSeparator.Visible = True
        tsbSearch.Visible = True
        tsbPrint.Visible = True
        tsbSave.Visible = False
        tsbCancel.Visible = False
        ClearNEnableFields()
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            DepartmentId = SelectedId
            Call Tran_Department(3, DepartmentId, CurrentUID)
            SelectedId = 0
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class