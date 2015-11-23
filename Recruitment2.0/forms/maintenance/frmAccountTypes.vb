Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmAccountTypes

    Dim AcctTypeTranType As Integer = -1
    Dim AcctTypeSelectedId As Integer = 0


    Private Sub Tran_AccountTypes(ByVal TranType As Integer, ByVal AccountTypeId As Integer, ByVal CurrentUserId As Integer, Optional ByVal AccountTypeDesc As String = Nothing)
        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", AccountTypeId))
        Params.Add(New MySqlParameter("@adesc", AccountTypeDesc))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_accounttypes", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_accounttypes", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        txtCode.Text = Drow("typecode")
                        txtDesc.Text = Drow("typedesc")
                    Next

                Case 4

                Case Else

            End Select
        End Using
    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        pnlInfo.Enabled = IsEnabled
        txtCode.Clear()
        txtDesc.Clear()
        AcctTypeTranType = -1
    End Sub

    Private Sub frmAccountTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        ClearNEnableFields(True)
        AcctTypeTranType = 0
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
        pnlInfo.Enabled = True
        AcctTypeTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If AcctTypeSelectedId = 0 Then
            MsgBox("You have not selected an item to remove. Please select one then try again.", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Qry = "select count(`ca_id`) from `rms_clientaccounts` where `accounttypeid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", AcctTypeSelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Account Type [" + txtDesc.Text + "] cannot be deleted due to it's dependencies in Manpower Request(MR) Info", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Delete account type [" + txtDesc.Text + "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_AccountTypes(2, AcctTypeSelectedId, CurrentUID)
            MsgBox("Account type [" + txtDesc.Text + "] has been removed successfully", MsgBoxStyle.Information, "Delete Success")
            Call ClearNEnableFields()
        End If

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtDesc.Text.Trim.Length = 0 Then
            MsgBox("Account type description is a required field and cannot be empty/null. Please enter a valid value then try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If

        If MsgBox("Save account type?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_AccountTypes(AcctTypeTranType, AcctTypeSelectedId, CurrentUID, txtDesc.Text)
            MsgBox("Account type has been saved successfully.", MsgBoxStyle.Information, "Saved")
            tsbCancel.PerformClick()
        End If

    End Sub

    Private Sub tsbCancel_Click(sender As Object, e As EventArgs) Handles tsbCancel.Click
        tsbSave.Visible = False
        tsbCancel.Visible = False
        tsbAdd.Visible = True
        tsbEdit.Visible = True
        tsbDelete.Visible = True
        tsbSeparator.Visible = True
        tsbSearch.Visible = True
        tsbPrint.Visible = True
        Call ClearNEnableFields()
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            AcctTypeSelectedId = SelectedId
            Call Tran_AccountTypes(3, AcctTypeSelectedId, CurrentUID)
            SelectedId = 0
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class