Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports MySql.Data.MySqlClient


Public Class frmCandidateProfile
    ' Candidate Information
    Dim CandidateTranType As Integer = -1

    ' Family Background
    Dim FMTranType As Integer = 0
    Dim selFMId, selFMCandidateId As Integer, selFMName As String

    ' Education History
    Dim EducTranType As Integer = 0
    Dim selEducId, selEducCandidateId As Integer, selCourseTaken, selSchool As String

    ' Employment History
    Dim EmpTranType As Integer = 0
    Dim selEmpId, selEmpCandidateId As Integer, selJobPost, selCompanyName As String


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
                    txtCandidateRemarks.Text = Drow("candidateremarks")
                Next
                Call Tran_FamilyBackground(4, 0, CandidateId, CurrentUserId)
                Call Tran_EducationalBackground(4, 0, CandidateId, CurrentUserId)
                Call Tran_EmploymentHistory(4, 0, CandidateId, CurrentUserId)
                Call Tran_CandidateSkills(4, 0, CandidateId, CurrentUserId)
            End If
        End If

    End Sub

    Private Sub Tran_FamilyBackground(ByVal TranType As Integer, ByVal FamilyMemberId As Integer, ByVal CandidateId As Integer, ByVal CurrentUserId As Integer, _
                                      Optional ByVal FamilyMemberName As String = Nothing, Optional ByVal BDate As Date = Nothing, _
                                      Optional ByVal CivilStat As Integer = Nothing, Optional ByVal Relationship As String = Nothing, _
                                      Optional ByVal Occupation As String = Nothing, Optional ByVal IsDeceased As Boolean = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", FamilyMemberId))
        Params.Add(New MySqlParameter("@candidateid", CandidateId))
        Params.Add(New MySqlParameter("@cfmname", FamilyMemberName))
        Params.Add(New MySqlParameter("@cbdate", BDate))
        Params.Add(New MySqlParameter("@ccivilstat", CivilStat))
        Params.Add(New MySqlParameter("@crelationship", Relationship))
        Params.Add(New MySqlParameter("@coccupation", Occupation))
        Params.Add(New MySqlParameter("@cisdeceased", IsDeceased))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            If TranType = 0 Or TranType = 1 Or TranType = 2 Then
                QueryExec("tran_candidatefamilybackground", Cn, Params, CommandType.StoredProcedure)
            ElseIf TranType = 3 Then
                Dset = New DataSet
                Dset = Query("tran_candidatefamilybackground", Cn, Params, CommandType.StoredProcedure)
                For Each Drow As DataRow In Dset.Tables(0).Rows
                    txtFMName.Text = Drow("familymembername")
                    dtpFMBDate.Value = CDate(Drow("bdate"))
                    txtFMAge.Text = Drow("age")
                    cboFMCStatus.SelectedIndex = CInt(Drow("civilstatus"))
                    txtFMRel.Text = Drow("relationship")
                    txtFMOccupation.Text = Drow("occupation")
                    chkFMIsDeceased.Checked = CBool(Drow("isdeceased"))

                Next
            ElseIf TranType = 4 Then
                Dset = New DataSet
                Dset = Query("tran_candidatefamilybackground", Cn, Params, CommandType.StoredProcedure)
                dgvFM.DataSource = Dset.Tables(0)
                FormatGridColumn(dgvFM, 2, "FMId", False, False, True, 50)
                FormatGridColumn(dgvFM, 3, "CandidateId", False, False, True, 50)
                FormatGridColumn(dgvFM, 4, "Name", True, True, True, 250)
                FormatGridColumn(dgvFM, 5, "Birth Date", True, True, True, 150)
                FormatGridColumn(dgvFM, 6, "Age", True, True, True, 70)
                FormatGridColumn(dgvFM, 7, "Civil Status Id", False, False, True, 50)
                FormatGridColumn(dgvFM, 8, "Civil Status", True, True, True, 150)
                FormatGridColumn(dgvFM, 9, "Relationship", True, True, True, 250)
                FormatGridColumn(dgvFM, 10, "Occupation", True, True, True, 250)
                dgvFM.Refresh()
            End If
        End Using
    End Sub

    Private Sub Tran_EducationalBackground(ByVal TranType As Integer, ByVal EducHistId As Integer, ByVal CandidateId As Integer, ByVal CurrentUserId As Integer, _
                                           Optional ByVal SchoolName As String = Nothing, Optional ByVal SchoolAddress As String = Nothing, Optional ByVal CourseTaken As String = Nothing, Optional ByVal StartDate As Date = Nothing, _
                                           Optional ByVal EndDate As Date = Nothing, Optional ByVal GraduationDate As Date = Nothing, Optional ByVal IsUnderGrad As Boolean = Nothing, Optional ByVal HonorsReceived As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", EducHistId))
        Params.Add(New MySqlParameter("@candidateid", CandidateId))
        Params.Add(New MySqlParameter("@ce_instname", SchoolName))
        Params.Add(New MySqlParameter("@ce_instaddr", SchoolAddress))
        Params.Add(New MySqlParameter("@ce_coursetaken", CourseTaken))
        Params.Add(New MySqlParameter("@ce_startdate", StartDate))
        Params.Add(New MySqlParameter("@ce_enddate", EndDate))
        Params.Add(New MySqlParameter("@ce_graddate", GraduationDate))
        Params.Add(New MySqlParameter("@ce_isundergrad", IsUnderGrad))
        Params.Add(New MySqlParameter("@ce_honors", HonorsReceived))
        Params.Add(New MySqlParameter("@usedid", CurrentUID))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            If TranType = 0 Or TranType = 1 Or TranType = 2 Then
                QueryExec("tran_candidateeduchist", Cn, Params, CommandType.StoredProcedure)
            ElseIf TranType = 3 Then
                Dset = New DataSet
                Dset = Query("tran_candidateeduchist", Cn, Params, CommandType.StoredProcedure)

                For Each Drow As DataRow In Dset.Tables(0).Rows
                    txtEduSchool.Text = Drow("institutionname")
                    txtEduAdd.Text = Drow("institutionadd")
                    txtEduCourse.Text = Drow("coursetaken")
                    dtpEduStart.Value = CDate(Drow("startdate"))
                    dtpEduEnd.Value = CDate(Drow("enddate"))
                    dtpEduGrad.Value = CDate(Drow("graddate"))
                    chkEduIsUG.Checked = CBool(Drow("isundergrad"))
                    txtEduHonors.Text = Drow("honorsreceived")
                Next

            ElseIf TranType = 4 Then
                Dset = New DataSet
                Dset = Query("tran_candidateeduchist", Cn, Params, CommandType.StoredProcedure)
                dgvEduHist.DataSource = Dset.Tables(0)
                FormatGridColumn(dgvEduHist, 2, "EducId", False, False, True, 50)
                FormatGridColumn(dgvEduHist, 3, "CandidateId", False, False, True, 50)
                FormatGridColumn(dgvEduHist, 4, "School Name", False, True, True, 300)
                FormatGridColumn(dgvEduHist, 5, "School Address", False, True, True, 300)
                FormatGridColumn(dgvEduHist, 6, "Course Taken", False, True, True, 300)
                FormatGridColumn(dgvEduHist, 7, "Inclusive Dates", False, True, True, 200)
                FormatGridColumn(dgvEduHist, 8, "Date Graduated", False, True, True, 120)
                FormatGridColumn(dgvEduHist, 9, "Honors Received", False, True, True, 200)

                dgvEduHist.Refresh()
            Else
                MsgBox("Unhandled condition", MsgBoxStyle.Exclamation, "OOOPS!")
            End If
        End Using

    End Sub

    Private Sub Tran_EmploymentHistory(ByVal TranType As Integer, EmploymentId As Integer, CandidateId As Integer, CurrentUserId As Integer, _
                                       Optional ByVal CompanyName As String = Nothing, Optional ByVal CompanyAddress As String = Nothing, Optional ByVal ContactNumbers As String = Nothing, _
                                       Optional ByVal StartDate As Date = Nothing, Optional ByVal EndDate As Date = Nothing, Optional ByVal IsPresentEmployment As Boolean = Nothing, _
                                       Optional ByVal PositionHeld As String = Nothing, Optional ByVal ImmediateSuperior As String = Nothing, Optional ByVal ReasonForLeaving As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", EmploymentId))
        Params.Add(New MySqlParameter("@candidateid", CandidateId))
        Params.Add(New MySqlParameter("@ccompname", CompanyName))
        Params.Add(New MySqlParameter("@caddr", CompanyAddress))
        Params.Add(New MySqlParameter("@ccontactno", ContactNumbers))
        Params.Add(New MySqlParameter("@cstartdate", StartDate))
        Params.Add(New MySqlParameter("@cenddate", EndDate))
        Params.Add(New MySqlParameter("@cispresentemp", IsPresentEmployment))
        Params.Add(New MySqlParameter("@cposheld", PositionHeld))
        Params.Add(New MySqlParameter("@cimsuperior", ImmediateSuperior))
        Params.Add(New MySqlParameter("@creasonforleaving", ReasonForLeaving))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidateemphist", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_candidateemphist", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        txtEmpCName.Text = Drow("companyname")
                        txtEmpCAdd.Text = Drow("address")
                        txtEmpCContact.Text = Drow("contactnos")
                        dtpEmpStart.Value = CDate(Drow("startdate"))
                        dtpEmpEnd.Value = CDate(Drow("enddate"))
                        chkEmpPresent.Checked = CBool(Drow("ispresentemp"))
                        txtEmpPosHeld.Text = Drow("posheld")
                        txtEmpIS.Text = Drow("immediatesup")
                        txtEmpReason.Text = Drow("reasonforleaving")
                    Next

                Case 4
                    Dset = New DataSet
                    Dset = Query("tran_candidateemphist", Cn, Params, CommandType.StoredProcedure)

                    With dgvEmp
                        .DataSource = Dset.Tables(0)
                        FormatGridColumn(dgvEmp, 3, "EmpId", False, False, True, 50)
                        FormatGridColumn(dgvEmp, 4, "CandidateId", False, False, True, 50)
                        FormatGridColumn(dgvEmp, 5, "IsPresent", False, False, True, 50)
                        FormatGridColumn(dgvEmp, 6, "Company Name", True, True, True, 300)
                        FormatGridColumn(dgvEmp, 7, "Position Held", False, True, True, 250)
                        FormatGridColumn(dgvEmp, 8, "Inclusive Dates", False, True, True, 200)
                        FormatGridColumn(dgvEmp, 9, "Reason for Leaving", False, True, True, 350)
                        .Refresh()
                    End With
                Case Else

            End Select
        End Using
    End Sub

    Private Sub Tran_CandidateSkills(ByVal TranType As Integer, ByVal SkillListId As Integer, ByVal CandidateId As Integer, ByVal CurrentUserId As Integer, _
                                     Optional ByVal SkillTypeId As Integer = Nothing, Optional ByVal SkillGroupId As Integer = Nothing, _
                                     Optional ByVal SkillId As Integer = Nothing, Optional ByVal SkillLevelId As Integer = Nothing, _
                                     Optional ByVal TotalYearsUsed As Integer = Nothing, Optional ByVal LastYearUsed As Integer = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SkillListId))
        Params.Add(New MySqlParameter("@candidateid", CandidateId))
        Params.Add(New MySqlParameter("@cskilltype", SkillTypeId))
        Params.Add(New MySqlParameter("@cskillgroup", SkillGroupId))
        Params.Add(New MySqlParameter("@cskill", SkillId))
        Params.Add(New MySqlParameter("@cskilllevel", SkillLevelId))
        Params.Add(New MySqlParameter("@cttlyearsused", TotalYearsUsed))
        Params.Add(New MySqlParameter("@cyearlastused", LastYearUsed))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidateskills", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_candidateskills", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        cboSkillType.SelectedIndex = CInt(Drow("skilltypeid"))
                        cboSkillGroup.SelectedIndex = CInt(Drow("skillgroupid"))
                        cboSkill.SelectedIndex = CInt(Drow("skillid"))
                        cboSkillLevel.SelectedIndex = CInt(Drow("skilllevelid"))
                        txtSYearUsed.Text = Drow("totalyearsused")
                        txtSLastYearUsed.Text = Drow("yearlastused")
                    Next

                Case 4
                    Dset = New DataSet
                    Dset = Query("tran_candidateskills", Cn, Params, CommandType.StoredProcedure)
                    With dgvSkill
                        .DataSource = Dset.Tables(0)
                        FormatGridColumn(dgvSkill, 2, "SkillListId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 3, "CandidateId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 4, "SkillTypeId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 5, "SkillGroupId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 6, "SkillId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 7, "SkillLevelId", False, False, True, 50)
                        FormatGridColumn(dgvSkill, 8, "Skill", True, True, True, 300)
                        FormatGridColumn(dgvSkill, 9, "Total Years Used", True, True, True, 150)
                        FormatGridColumn(dgvSkill, 10, "Year Last Used", True, True, True, 150)
                        FormatGridColumn(dgvSkill, 11, "Level", True, True, True, 150)
                        .Refresh()
                    End With
                Case Else

            End Select
        End Using


    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        CandidateTranType = 3
        Dim ParamList As New ArrayList
        ParamList.AddRange({4, "Mix", 5.1})
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me.Name, ParamList)
            .ShowDialog()
            Call TranCandidateInfo(CandidateTranType, SelCandidateId)
        End With
    End Sub

    Private Sub dtpBDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBDate.ValueChanged
        txtAge.Text = DateDiff(DateInterval.Year, dtpBDate.Value, Now)
    End Sub

    Private Sub dtpFMBDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFMBDate.ValueChanged
        txtFMAge.Text = DateDiff(DateInterval.Year, dtpFMBDate.Value, Now)
    End Sub

    Private Sub rdbAvail1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAvail1.CheckedChanged
        txtAvailInCount.Enabled = rdbAvail1.Checked
        cboAvailInType.Enabled = rdbAvail1.Checked
    End Sub

    Private Sub rdbAvail2_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAvail2.CheckedChanged
        dtpAvailableOn.Enabled = rdbAvail2.Checked
    End Sub

    Private Sub tabInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabInfo.SelectedIndexChanged
        With tabInfo
            If .SelectedIndex = 0 Or .SelectedIndex = 5 Then
                tsOps.Enabled = True
            Else
                tsOps.Enabled = False
            End If
        End With
    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        CandidateTranType = 0
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        Call ClearNEnableFields(True)
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

        If CandidateTranType = 0 Then
            Call LogActivity(1, "User " + CurrentUName + " cancels profile creation.", CurrentUID)
        ElseIf CandidateTranType = 1 Then
            Call LogActivity(1, "User " + CurrentUName + "cancels modification of profile " + txtFName.Text + " " + txtLName.Text + ".", CurrentUID)
        Else
            ' Unhandled transaction
        End If

        Call ClearNEnableFields(False)
        CandidateTranType = -1
        SelCandidateId = 0
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If SelCandidateId > 0 Then
            CandidateTranType = 1
            tsbSave.Visible = True
            tsbCancel.Visible = True
            tsbAdd.Visible = False
            tsbEdit.Visible = False
            tsbDelete.Visible = False
            tsbSeparator.Visible = False
            tsbSearch.Visible = False
            tsbPrint.Visible = False

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
                CandidateTranType = -1
                SelCandidateId = 0
                Call LogActivity(0, "System clears and disable fields. After deletion of candidate profile.", CurrentUID)
            End If
        Else
            MsgBox("You have not selected any profile to delete. Please try again.", MsgBoxStyle.Exclamation, "Remove Failed")
            LogActivity(1, "User " + CurrentUName + " attempts to remove a profile without selecting from list.", CurrentUID)
            Call ClearNEnableFields(False)
        End If

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtFName.Text.Trim.Length = 0 Then

        ElseIf txtLName.Text.Trim.Length = 0 Then

        End If
    End Sub

    Private Sub dgvFM_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFM.CellClick
        selFMId = dgvFM.Rows(e.RowIndex).Cells("cf_id").Value.ToString
        selFMCandidateId = dgvFM.Rows(e.RowIndex).Cells("ci_id").Value.ToString
        selFMName = dgvFM.Rows(e.RowIndex).Cells("familymembername").Value.ToString

        If e.ColumnIndex = 0 Then
            FMTranType = 1
            Call Tran_FamilyBackground(3, selFMId, selFMCandidateId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
            tsbFMSave.ToolTipText = "Update Information"
        ElseIf e.ColumnIndex = 1 Then
            If MsgBox("Proceed removing Family Member?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                Call Tran_FamilyBackground(2, selFMId, selFMCandidateId, CurrentUID)
                Call Tran_FamilyBackground(4, 0, selFMCandidateId, CurrentUID)
                MsgBox(selFMName + " has been removed from list.", MsgBoxStyle.Information, "Removed")
            End If
        Else
            MsgBox("Unhandled condition", MsgBoxStyle.Information, "System Notification")
        End If

    End Sub

    Private Sub tsbFMSave_Click(sender As Object, e As EventArgs) Handles tsbFMSave.Click
        If FMTranType = 0 Then
            Call Tran_FamilyBackground(0, 0, SelCandidateId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
            MsgBox(txtFMName.Text + " has been added to family members list.", MsgBoxStyle.Information, "Family Member Added")
        Else
            Call Tran_FamilyBackground(1, selFMId, selFMCandidateId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
            MsgBox(txtFMName.Text + " has been modified successfully.", MsgBoxStyle.Information, "Family Member Updated")
            FMTranType = 0
        End If

        txtFMName.Clear()
        dtpFMBDate.Value = Now
        txtFMAge.Clear()
        cboFMCStatus.SelectedIndex = 0
        txtFMRel.Clear()
        txtFMOccupation.Clear()
        chkFMIsDeceased.CheckState = CheckState.Unchecked

        Call Tran_FamilyBackground(4, selFMId, selFMCandidateId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
    End Sub

    Private Sub tsbFMCancel_Click(sender As Object, e As EventArgs) Handles tsbFMCancel.Click
        FMTranType = 0
        txtFMName.Clear()
        dtpFMBDate.Value = Now
        txtFMAge.Clear()
        cboFMCStatus.SelectedIndex = 0
        txtFMRel.Clear()
        txtFMOccupation.Clear()
        chkFMIsDeceased.CheckState = CheckState.Unchecked
        tsbFMSave.ToolTipText = "Save Information"
    End Sub

    Private Sub dgvEduHist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEduHist.CellClick
        selEducId = dgvEduHist.Rows(e.RowIndex).Cells("ce_id").Value.ToString
        selEducCandidateId = dgvEduHist.Rows(e.RowIndex).Cells("ci_id").Value.ToString
        selSchool = dgvEduHist.Rows(e.RowIndex).Cells("institutionname").Value.ToString
        selCourseTaken = dgvEduHist.Rows(e.RowIndex).Cells("coursetaken").Value.ToString

        If e.ColumnIndex = 0 Then
            EducTranType = 1
            Call Tran_EducationalBackground(3, selEducId, selEducCandidateId, CurrentUID)
            tsbEducSave.ToolTipText = "Update Information"
        ElseIf e.ColumnIndex = 1 Then
            If MsgBox("Proceed removing Education from list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                Call Tran_EducationalBackground(2, selEducId, selEducCandidateId, CurrentUID)
                Call Tran_EducationalBackground(4, 0, selEducCandidateId, CurrentUID)
                MsgBox(selCourseTaken + " from " + selSchool + " has been removed from list.", MsgBoxStyle.Information, "Removed")
            End If

        Else
            MsgBox("Unhandled condition", MsgBoxStyle.Information, "System Notification")
        End If
    End Sub

    Private Sub tsbEducSave_Click(sender As Object, e As EventArgs) Handles tsbEducSave.Click
        If EducTranType = 0 Then
            Call Tran_EducationalBackground(0, 0, SelCandidateId, CurrentUID, txtEduSchool.Text, txtEduAdd.Text, txtEduCourse.Text, dtpEduStart.Value, dtpEduEnd.Value, dtpEduGrad.Value, chkEduIsUG.Checked, txtEduHonors.Text)
            MsgBox("Education has been added to list.", MsgBoxStyle.Information, "Education Added")
        Else
            Call Tran_EducationalBackground(1, 0, SelCandidateId, CurrentUID, txtEduSchool.Text, txtEduAdd.Text, txtEduCourse.Text, dtpEduStart.Value, dtpEduEnd.Value, dtpEduGrad.Value, chkEduIsUG.Checked, txtEduHonors.Text)
            MsgBox("Education has been modified successfully.", MsgBoxStyle.Information, "Education Updated")
            EducTranType = 0
        End If

        txtEduSchool.Clear()
        txtEduAdd.Clear()
        txtEduCourse.Clear()
        dtpEduStart.Value = Now
        dtpEduEnd.Value = Now
        dtpEduGrad.Value = Now
        chkEduIsUG.CheckState = CheckState.Unchecked
        txtEduHonors.Clear()
        tsbEducSave.ToolTipText = "Save Information"

        Call Tran_EducationalBackground(4, 0, SelCandidateId, CurrentUID)

    End Sub

    Private Sub tsbEducCancel_Click(sender As Object, e As EventArgs) Handles tsbEducCancel.Click
        EducTranType = 0
        txtEduSchool.Clear()
        txtEduAdd.Clear()
        txtEduCourse.Clear()
        dtpEduStart.Value = Now
        dtpEduEnd.Value = Now
        dtpEduGrad.Value = Now
        chkEduIsUG.CheckState = CheckState.Unchecked
        txtEduHonors.Clear()
        tsbEducSave.ToolTipText = "Save Information"
    End Sub

    Private Sub dgvEmp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmp.CellClick
        selEmpId = dgvEmp.Rows(e.RowIndex).Cells("ce_id").Value.ToString
        selEmpCandidateId = dgvEmp.Rows(e.RowIndex).Cells("ci_id").Value.ToString
        selCompanyName = dgvEmp.Rows(e.RowIndex).Cells("companyname").Value.ToString
        selJobPost = dgvEmp.Rows(e.RowIndex).Cells("posheld").Value.ToString

        If e.ColumnIndex = 0 Then
            EmpTranType = 1
            Call Tran_EmploymentHistory(3, selEmpId, selEmpCandidateId, CurrentUID)
        ElseIf e.ColumnIndex = 1 Then
            If MsgBox("Proceed removing employment from list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                Call Tran_EmploymentHistory(3, selEmpId, selEmpCandidateId, CurrentUID)
                Call Tran_EmploymentHistory(4, 0, selEmpCandidateId, CurrentUID)
                MsgBox("Employment has been successfully removed from list.", MsgBoxStyle.Information, "Removed")
            End If
        Else
            MsgBox("Unhandled condition")
        End If
    End Sub

    Private Sub tsbEmpSave_Click(sender As Object, e As EventArgs) Handles tsbEmpSave.Click
        If EmpTranType = 0 Then
            Call Tran_EmploymentHistory(0, 0, SelCandidateId, CurrentUID, txtEmpCName.Text, txtEmpCAdd.Text, txtEmpCContact.Text, dtpEmpStart.Value, dtpEmpEnd.Value, chkEmpPresent.Checked, txtEmpPosHeld.Text, txtEmpIS.Text, txtEmpReason.Text)
            MsgBox("Employment information has been added successfully.", MsgBoxStyle.Information, "Employment Added")
        Else
            Call Tran_EmploymentHistory(1, selEmpId, selEmpCandidateId, CurrentUID, txtEmpCName.Text, txtEmpCAdd.Text, txtEmpCContact.Text, dtpEmpStart.Value, dtpEmpEnd.Value, chkEmpPresent.Checked, txtEmpPosHeld.Text, txtEmpIS.Text, txtEmpReason.Text)
            MsgBox("Employment information has been updated successfully.", MsgBoxStyle.Information, "Employment Added")
            EmpTranType = 0
        End If

        txtEmpCName.Clear()
        txtEmpCAdd.Clear()
        txtEmpCContact.Clear()
        dtpEmpStart.Value = Now
        dtpEmpEnd.Value = Now
        chkEmpPresent.Checked = False
        txtEmpPosHeld.Clear()
        txtEmpIS.Clear()
        txtEmpReason.Clear()
        Call Tran_EmploymentHistory(4, 0, SelCandidateId, CurrentUID)

    End Sub

    Private Sub tsbEmpCancel_Click(sender As Object, e As EventArgs) Handles tsbEmpCancel.Click
        txtEmpCName.Clear()
        txtEmpCAdd.Clear()
        txtEmpCContact.Clear()
        dtpEmpStart.Value = Now
        dtpEmpEnd.Value = Now
        chkEmpPresent.Checked = False
        txtEmpPosHeld.Clear()
        txtEmpIS.Clear()
        txtEmpReason.Clear()
    End Sub

End Class