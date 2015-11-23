Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmClientProfile

    Dim ClientAcctTranType As Integer = -1, CAContactTranType As Integer = -1
    Dim CASelectedId As Integer = 0
    Dim CAContactId As Integer = 0, CAContactName As String = ""

    Private Sub Tran_ClientAccounts(ByVal TranType As Integer, ByVal ClientAccountId As Integer, CurrentUserId As Integer, _
                                    Optional ByVal AccountTypeId As Integer = Nothing, Optional ByVal AccountName As String = Nothing, _
                                    Optional ByVal Address As String = Nothing, Optional ByVal PhoneNo As String = Nothing, _
                                    Optional ByVal FaxNo As String = Nothing, Optional ByVal WebsiteURL As String = Nothing, _
                                    Optional ByVal HandledByEmployeeId As Integer = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", ClientAccountId))
        Params.Add(New MySqlParameter("@accttypeid", AccountTypeId))
        Params.Add(New MySqlParameter("@acctname", AccountName))
        Params.Add(New MySqlParameter("@addr", Address))
        Params.Add(New MySqlParameter("@acctphone", PhoneNo))
        Params.Add(New MySqlParameter("@acctfax", FaxNo))
        Params.Add(New MySqlParameter("@acctwebsite", WebsiteURL))
        Params.Add(New MySqlParameter("@handlerid", HandledByEmployeeId))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0
                    ClientAccountId = QueryExec("tran_clientaccounts", Cn, Params, CommandType.StoredProcedure)
                Case 1, 2
                    QueryExec("tran_clientaccounts", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_clientaccounts", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        lblRefNo.Text = Drow("accountcode")
                        cboAcctType.SelectedValue = CInt(Drow("accounttypeid"))
                        txtAcctName.Text = Drow("accountname")
                        txtAddr.Text = Drow("address")
                        txtPhoneNo.Text = Drow("phoneno")
                        txtFaxNo.Text = Drow("faxno")
                        txtWebURL.Text = Drow("website")
                        cboHandledBy.SelectedValue = CInt(Drow("handledbyid"))
                    Next

                Case 4

                Case Else

            End Select
        End Using



    End Sub

    Private Sub Tran_ClientContacts(ByVal TranType As Integer, ByVal ContactId As Integer, ByVal ClientId As Integer, ByVal CurrentUserId As Integer, _
                                    Optional ByVal ContactName As String = Nothing, Optional ByVal Designation As String = Nothing, Optional ByVal EmailAddress As String = Nothing, _
                                    Optional ByVal PhoneNo As String = Nothing, Optional ByVal MobileNo As String = Nothing, Optional ByVal Others As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", ContactId))
        Params.Add(New MySqlParameter("@acctid", ClientId))
        Params.Add(New MySqlParameter("@acname", ContactName))
        Params.Add(New MySqlParameter("@acdesignation", Designation))
        Params.Add(New MySqlParameter("@acemail", EmailAddress))
        Params.Add(New MySqlParameter("@acphoneno", PhoneNo))
        Params.Add(New MySqlParameter("@acmobileno", MobileNo))
        Params.Add(New MySqlParameter("@acothers", Others))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_clientcontacts", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_clientcontacts", Cn, Params, CommandType.StoredProcedure)
                Case 4
                    Dset = New DataSet
                    Dset = Query("tran_clientcontacts", Cn, Params, CommandType.StoredProcedure)
                    dgvContact.DataSource = Dset.Tables(0)
                    FormatGridColumn(dgvContact, 2, "Contact Id", False, False, False, 50)
                    FormatGridColumn(dgvContact, 3, "Client Id", False, False, False, 50)
                    FormatGridColumn(dgvContact, 4, "Contact Name", False, True, True, 250)
                    FormatGridColumn(dgvContact, 5, "Designation", False, True, True, 250)
                    dgvContact.Refresh()
                Case Else

            End Select
        End Using

    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        txtAcctName.Clear()
        txtAddr.Clear()
        txtPhoneNo.Clear()
        txtFaxNo.Clear()
        txtWebURL.Clear()
        cboAcctType.SelectedValue = -1
        cboHandledBy.SelectedValue = -1
        pnlInfo.Enabled = IsEnabled
        ClientAcctTranType = 0
        CASelectedId = 0
        CAContactId = 0
        pnlInfo.Enabled = IsEnabled
    End Sub

    Private Sub ClearNEnableContactFields(Optional ByVal IsEnabled As Boolean = False)
        txtCName.Clear()
        txtCDesignation.Clear()
        txtCPhone.Clear()
        txtCMobile.Clear()
        txtCEmail.Clear()
        txtCPhone.Clear()
        dgvContact.DataSource = Nothing
        dgvContact.Refresh()
        CAContactId = 0
        CAContactTranType = 0
    End Sub

    Private Sub frmClientProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Account Types
            Qry = "select `at_id`, `description` from `rms_accounttypes` where `recstatus` = 1;"
            Qry = <Query>
                      select 0 as at_id, '- Select an Account Type -' as description
                      union all
                      select `at_id`, `description` from `rms_accounttypes` where `recstatus` = 1;
                  </Query>.Value

            Call FillComboBox(Qry, Cn, "description", "at_id", cboAcctType, Nothing, CommandType.Text)

            ' User Profile
            Qry = <Query>
                        select 0 as up_id, '- Select an Account Owner -' as fullname
                        union all
                        select `up_id`, concat(`lastname`, ', ', `firstname`, case length(`middlename`) when 0 then '' else concat(' ', substr(`middlename`,1, 1)) end) as fullname
                        from `hrs_userprofile`
                        where `recstatus` = 1;  
                  </Query>.Value
            Call FillComboBox(Qry, Cn, "fullname", "up_id", cboHandledBy, Nothing, CommandType.Text)

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
        ClientAcctTranType = 0
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        pnlInfo.Enabled = True
        ClientAcctTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If CASelectedId = 0 Then
            MsgBox("You have not selected an item to delete. Search and select an item then try again.", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Manpower Request
            Qry = "select count(`mr_id`) from `rms_mrinfo` where `accountid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", CASelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Account [" + txtAcctName.Text + "] cannot be deleted due to it's dependencies in Manpower Request", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Remove account [" + txtAcctName.Text + "] and its contact information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_ClientAccounts(2, CASelectedId, CurrentUID)
            MsgBox("Account successfully removed.", MsgBoxStyle.Information, "Removed")
            Call ClearNEnableFields()
            Call ClearNEnableContactFields()
        End If

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If cboAcctType.SelectedIndex = -1 Or cboAcctType.SelectedValue = -1 Then
            MsgBox("Please select a valid account type associated with the account.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If txtAcctName.Text.Trim.Length = 0 Then
            MsgBox("Account name cannot be empty. Enter a valid value and try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If txtAddr.Text.Trim.Length = 0 Then
            MsgBox("Account should have an address. Enter a valid value and try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If txtPhoneNo.Text.Trim.Length = 0 Then
            MsgBox("Account should have at least 1 contact number. Enter a valid value and try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If cboHandledBy.SelectedIndex = -1 Or cboHandledBy.SelectedValue = -1 Then
            MsgBox("Account owner has not been selected. Please select 1 from the drop down and try again.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If

        If MsgBox("Save client information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_ClientAccounts(ClientAcctTranType, CASelectedId, CurrentUID, cboAcctType.SelectedValue, txtAcctName.Text, txtAddr.Text, txtPhoneNo.Text, _
                                     txtFaxNo.Text, txtWebURL.Text, cboHandledBy.SelectedValue)
            MsgBox("Client [" + txtAcctName.Text + "] has been saved successfully.", MsgBoxStyle.Information, "Saved")
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
        Call ClearNEnableFields()
        Call ClearNEnableContactFields()
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            CASelectedId = SelectedId
            Call Tran_ClientAccounts(3, CASelectedId, CurrentUID)
            Call Tran_ClientContacts(4, 0, CASelectedId, CurrentUID)
            SelectedId = 0
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub

    Private Sub tabInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabInfo.SelectedIndexChanged
        If CASelectedId > 0 Then
            tsContactOps.Enabled = True
        End If

        If tabInfo.SelectedIndex = 1 Then
            tsOps.Enabled = False
        Else
            tsOps.Enabled = True
        End If
    End Sub

End Class