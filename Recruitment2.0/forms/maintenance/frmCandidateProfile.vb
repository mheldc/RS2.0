Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports MySql.Data.MySqlClient


Public Class frmCandidateProfile

    Dim TranType As Integer = -1
    Public Shared SelCandidateId As Integer

    Private Sub frmCandidateProfile_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' For Testing purposes
        DefHost = "localhost"
        DefDb = "rmsv2"
        DefUID = "root"
        DefPWD = ""
        DefPort = 3306

        CurrentUID = 1
        CurrentUName = "Admin"
        CurrentUPosition = "Administrator"
        ' 
        Call ClearNEnableFields(False)
    End Sub

    Private Sub ClearNEnableFields(Optional ByVal EnableControls As Boolean = True)

        For Each tPages As TabPage In tabInfo.TabPages
            tPages.Enabled = EnableControls
            Try
                For Each Ctrl As Control In pnlCInfo.Controls
                    If TypeOf Ctrl Is TextBox Then
                        With DirectCast(Ctrl, TextBox)
                            .Clear()
                        End With
                    ElseIf TypeOf Ctrl Is Label Then
                        If DirectCast(Ctrl, Label).Name = "lblRefId" Or DirectCast(Ctrl, Label).Name = "lblStatus" Then
                            DirectCast(Ctrl, Label).Text = "[]"
                        End If
                    End If
                Next

                For Each Ctrl As Control In tPages.Controls
                    If TypeOf Ctrl Is TextBox Then
                        With DirectCast(Ctrl, TextBox)
                            .Clear()
                        End With
                    ElseIf TypeOf Ctrl Is MaskedTextBox Then
                        With DirectCast(Ctrl, MaskedTextBox)
                            .Clear()
                        End With
                    ElseIf TypeOf Ctrl Is ComboBox Then
                        With DirectCast(Ctrl, ComboBox)
                            If .Items.Count > 0 Then
                                .SelectedIndex = 0
                            End If
                        End With
                    ElseIf TypeOf Ctrl Is DateTimePicker Then
                        With DirectCast(Ctrl, DateTimePicker)
                            .Value = Now
                        End With
                    ElseIf TypeOf Ctrl Is DataGridView Then
                        With DirectCast(Ctrl, DataGridView)
                            .DataSource = Nothing
                            .AllowUserToAddRows = False
                        End With
                    ElseIf TypeOf Ctrl Is CheckBox Then
                        With DirectCast(Ctrl, CheckBox)

                        End With
                    Else
                        Console.WriteLine("the control is something else.")
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Occured")
            End Try
        Next
    End Sub

    Public Sub TranCandidateInfo(TranType As Integer, ByVal CandidateId As Integer, Optional ByVal CurrentUserId As Integer = 0, _
                                 Optional ByVal LastName As String = Nothing, Optional ByVal FirstName As String = Nothing, Optional ByVal MiddleName As String = Nothing, _
                                 Optional ByVal Gender As Integer = Nothing, Optional ByVal BDate As Date = Nothing, Optional ByVal BPlace As String = Nothing, Optional ByVal CivilStatus As Integer = Nothing, _
                                 Optional ByVal Address1 As String = Nothing, Optional ByVal Addr1Current As Boolean = Nothing, Optional ByVal Address2 As String = Nothing, Optional ByVal Addr2Current As Boolean = Nothing, _
                                 Optional ByVal PhoneNo As String = Nothing, Optional ByVal MobileNo As String = Nothing, Optional ByVal Email As String = Nothing, Optional ByVal SSSId As String = Nothing, Optional ByVal TINId As String = Nothing, _
                                 Optional ByVal HDMFId As String = Nothing, Optional ByVal PHId As String = Nothing, Optional ByVal CandidateStatusId As Integer = Nothing, Optional ByVal AppliedPosition As String = Nothing, _
                                 Optional ByVal AppSourceId As Integer = Nothing, Optional ByVal AppSourceRemarks As String = Nothing, Optional ByVal PrefWorkLocation As String = Nothing, Optional ByVal PrefSalary As String = Nothing, _
                                 Optional ByVal PrefSalaryTypeId As Integer = Nothing, Optional ByVal IsSalaryNegotiable As Boolean = Nothing, Optional ByVal AvailabilityTypeId As Integer = Nothing, Optional ByVal AvailNoticeCount As Integer = Nothing, _
                                 Optional ByVal AvailNoticeTypeId As Integer = Nothing, Optional ByVal AvailNoticeOnDate As Date = Nothing, Optional ByVal CandidateRemarks As Integer = Nothing, Optional ByVal CandidateImage As Byte = Nothing)


        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", CandidateId))
        Params.Add(New MySqlParameter("@clname", LastName))
        Params.Add(New MySqlParameter("@cfname", FirstName))
        Params.Add(New MySqlParameter("@cmname", MiddleName))
        Params.Add(New MySqlParameter("@cgender", Gender))
        Params.Add(New MySqlParameter("@cbdate", BDate))
        Params.Add(New MySqlParameter("@cbplace", BPlace))
        Params.Add(New MySqlParameter("@ccstat", CivilStatus))
        Params.Add(New MySqlParameter("@cadd1", Address1))
        Params.Add(New MySqlParameter("@cadd1current", Addr1Current))
        Params.Add(New MySqlParameter("@cadd2", Address2))
        Params.Add(New MySqlParameter("@cadd2current", Addr2Current))
        Params.Add(New MySqlParameter("@cphoneno", PhoneNo))
        Params.Add(New MySqlParameter("@cmobileno", MobileNo))
        Params.Add(New MySqlParameter("@cemail", Email))
        Params.Add(New MySqlParameter("@csssid", SSSId))
        Params.Add(New MySqlParameter("@ctinid", TINId))
        Params.Add(New MySqlParameter("@chdmfid", HDMFId))
        Params.Add(New MySqlParameter("@cphid", PHId))
        Params.Add(New MySqlParameter("@cstatusid", CandidateStatusId))
        Params.Add(New MySqlParameter("@cappliedpost", AppliedPosition))
        Params.Add(New MySqlParameter("@cappsourceid", AppSourceId))
        Params.Add(New MySqlParameter("@cappsourceremarks", AppSourceRemarks))
        Params.Add(New MySqlParameter("@cprefloc", PrefWorkLocation))
        Params.Add(New MySqlParameter("@cprefsalary", PrefSalary))
        Params.Add(New MySqlParameter("@cprefsalarytype", PrefSalaryTypeId))
        Params.Add(New MySqlParameter("@cprefsalarynegotiable", IsSalaryNegotiable))
        Params.Add(New MySqlParameter("@cavailtype", AvailabilityTypeId))
        Params.Add(New MySqlParameter("@cavailnotice", AvailNoticeCount))
        Params.Add(New MySqlParameter("@cavailnoticetype", AvailabilityTypeId))
        Params.Add(New MySqlParameter("@cavaildate", AvailNoticeOnDate))
        Params.Add(New MySqlParameter("@cremarks", CandidateRemarks))
        Params.Add(New MySqlParameter("@cimage", CandidateImage))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            If TranType = 3 Then
                Dset = Query("tran_candidateinfo", Cn, Params, CommandType.StoredProcedure)
            Else
                QueryExec("tran_candidateinfo", Cn, Params, CommandType.StoredProcedure)
            End If

        End Using
        If TranType = 3 Then
            If Dset.Tables.Count > 0 Or Not IsNothing(Dset) Then
                For Each Drow As DataRow In Dset.Tables(0).Rows
                    lblRefId.Text = Drow("referenceid")
                    txtLName.Text = Drow("lastname")
                    txtFName.Text = Drow("firstname")
                    txtMName.Text = Drow("middlename")
                    lblStatus.Text = Drow("statusdesc")
                    cboGender.SelectedIndex = CInt(Drow("gender"))
                    dtpBDate.Value = CDate(Drow("bdate"))
                    txtBPlace.Text = Drow("bplace")
                    txtAge.Text = Drow("age")
                    txtAdd1.Text = Drow("address1")
                    rdbAdd1.Checked = CBool(Drow("add1iscurrent"))
                    txtAdd2.Text = Drow("address2")
                    rdbAdd2.Checked = CBool(Drow("add2iscurrent"))
                    txtPhoneNo.Text = Drow("phoneno")
                    txtMobileNo.Text = Drow("mobileno")
                    txtEmail.Text = Drow("email")
                    mtbSSS.Text = Drow("sssid")
                    mtbTIN.Text = Drow("tinid")
                    mtbHDMF.Text = Drow("hdmfid")
                    mtbPH.Text = Drow("phid")

                    txtApplyingFor.Text = Drow("appliedposition")
                    'cboAppSource.SelectedIndex = Drow("appsourceid")
                    txtAppSrcRemarks.Text = Drow("appsourceremarks")
                    txtPrefWorkLocation.Text = Drow("prefworklocation")
                    txtSalary.Text = Format(Drow("prefsalary"), "###,###,##0.00")
                    cboSalaryRate.SelectedIndex = Drow("prefsalarytype")
                    chkIsNegotiable.Checked = CBool(Drow("issalarynegotiable"))

                    Select Case Drow("availabilitytype")
                        Case 0
                            rdbAvail0.Checked = True
                        Case 1
                            rdbAvail1.Checked = True
                            txtAvailInCount.Text = Drow("availinnotice")
                            'cboAvailInType.SelectedIndex = Drow("availnoticetype")
                        Case 2
                            rdbAvail2.Checked = True
                            dtpAvailableOn.Value = CDate(Drow("availondate"))
                        Case 3
                            rdbAvail3.Checked = True
                        Case Else

                    End Select

                Next
            End If
        End If

    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        TranType = 3
        Dim ParamList As New ArrayList
        ParamList.AddRange({4, "Mix", 5.1})
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me.Name, ParamList)
            .ShowDialog()
            Call TranCandidateInfo(TranType, SelCandidateId)
        End With
    End Sub

    Private Sub rdbAvail1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAvail1.CheckedChanged
        txtAvailInCount.Enabled = rdbAvail1.Checked
        cboAvailInType.Enabled = rdbAvail1.Checked
    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        TranType = 0
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        tsbSave.Visible = True
        tsbCancel.Visible = True
        Call ClearNEnableFields(True)
    End Sub

    Private Sub rdbAvail2_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAvail2.CheckedChanged
        dtpAvailableOn.Enabled = rdbAvail2.Checked
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

        If TranType = 0 Then
            Call LogActivity(1, "User " + CurrentUName + " cancels profile creation.", CurrentUID)
        ElseIf TranType = 1 Then
            Call LogActivity(1, "User " + CurrentUName + "cancels modification of profile " + txtFName.Text + " " + txtLName.Text + ".", CurrentUID)
        Else
            ' Unhandled transaction
        End If

        Call ClearNEnableFields(False)
        TranType = -1
        SelCandidateId = 0
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If SelCandidateId > 0 Then
            TranType = 1
            tsbAdd.Visible = False
            tsbEdit.Visible = False
            tsbDelete.Visible = False
            tsbSeparator.Visible = False
            tsbSearch.Visible = False
            tsbPrint.Visible = False
            tsbSave.Visible = True
            tsbCancel.Visible = True
            For Each tPages In tabInfo.TabPages
                tPages.enabled = True
            Next
            Call LogActivity(1, "User " + CurrentUName + "clicks Edit button.", CurrentUID)
        Else
            MsgBox("There are no items to edit. Please select a profile to modify.", MsgBoxStyle.Exclamation, "Error Occurred")
        End If
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If SelCandidateId > 0 Then
            If MsgBox("Would you like to remove candidate profile of [" + lblRefId.Text + " " + txtFName.Text + " " + txtLName.Text + "] ?") = MsgBoxResult.Yes Then
                Call TranCandidateInfo(2, SelCandidateId)
                Call LogActivity(1, "User " + CurrentUName + " successfully deleted the candidate profile of Mr./Ms. " + txtFName.Text + " " + txtLName.Text + ".", CurrentUID)
                Call ClearNEnableFields(False)
                TranType = -1
                SelCandidateId = 0
                Call LogActivity(0, "System clears and disable fields. After deletion of candidate profile.", CurrentUID)
            End If
        Else
            MsgBox("You have not selected any profile to delete. Please try again.", MsgBoxStyle.Exclamation, "Remove Failed")
            LogActivity(1, "User " + CurrentUName + " attempts to remove a profile without selecting from list.", CurrentUID)
            Call ClearNEnableFields(False)
        End If

    End Sub
End Class