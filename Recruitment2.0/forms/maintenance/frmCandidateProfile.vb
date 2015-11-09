Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmCandidateProfile
    ' Candidate Information
    Public CandidateTranType As Integer = -1

    ' Family Background
    Dim FMTranType As Integer = 0
    Dim selFMId, selFMCandidateId As Integer, selFMName As String

    ' Education History
    Dim EducTranType As Integer = 0
    Dim selEducId, selEducCandidateId As Integer, selCourseTaken, selSchool As String

    ' Employment History
    Dim EmpTranType As Integer = 0
    Dim selEmpId, selEmpCandidateId As Integer, selJobPost, selCompanyName As String

    ' Skills and Talents
    Dim SkillTranType As Integer = 0
    Dim selSkillType As Integer, selSkillGroup As Integer, selSkillId As Integer, selSkillRecId As Integer, selSkillName As String

    ' Others
    Dim selImagePath As String, imgData As IO.MemoryStream

    Private Sub frmCandidateProfile_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call ClearNEnableFields(False)
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Applicant Source
            Qry = <Query>
                        select 0 as cs_id, '- Select an Applicant Source -' as description
                        union all
                        select `cs_id`,`description` from `rms_candidatesource` where `recstatus` = 1;

                  </Query>.Value
            Call FillComboBox(Qry, Cn, "description", "cs_id", cboAppSource, , CommandType.Text)

            'Skill Type
            Qry = <Query>
                        select 0 as st_id, '- Select a Skill Type -' as description
                        union all
                        select `st_id`, `description` from `rms_skilltypes` where `recstatus` = 1;
                  </Query>.Value
            Call FillComboBox(Qry, Cn, "description", "st_id", cboSkillType, , CommandType.Text)

            ' Skill Level
            Qry = <Query>
                        select 0 as sl_id, '- Select a Skill Level -' as description
                        union all
                        select `sl_id`, `description` from `rms_skilllevels` where `recstatus` = 1;
                  </Query>.Value
            Call FillComboBox(Qry, Cn, "description", "sl_id", cboSkillLevel, , CommandType.Text)

        End Using

    End Sub

    Public Sub ClearNEnableFields(Optional ByVal EnableControls As Boolean = True)

        For Each tPages As TabPage In tabInfo.TabPages
            tPages.Enabled = EnableControls
            Try
                For Each Ctrl As Control In pnlCInfo.Controls
                    If TypeOf Ctrl Is TextBox Then
                        With DirectCast(Ctrl, TextBox)
                            If Ctrl.Name = "txtAvailInCount" Then .Text = "0" Else .Clear()
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
                dgvFM.DataSource = Nothing
                dgvFM.Refresh()
                dgvEduHist.DataSource = Nothing
                dgvEduHist.Refresh()
                dgvEmp.DataSource = Nothing
                dgvEmp.Refresh()
                dgvSkill.DataSource = Nothing
                dgvSkill.Refresh()
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
                                 Optional ByVal AvailNoticeTypeId As Integer = Nothing, Optional ByVal AvailNoticeOnDate As Date = Nothing, Optional ByVal CandidateRemarks As String = Nothing, Optional ByVal CandidateImage() As Byte = Nothing)


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
        Dim imgparam As New MySqlParameter("@cimage", MySqlDbType.VarBinary)
        imgparam.Value = CandidateImage
        Params.Add(imgparam)
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Dim Legend As String = _
            <Legend>
               0 - Add
               1 - Edit
               2 - Delete
               3 - Load Information
               4 - Load List
            </Legend>

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0
                    SelectedId = QueryExec("tran_candidateinfo", Cn, Params, CommandType.StoredProcedure)
                Case 1, 2
                    QueryExec("tran_candidateinfo", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_candidateinfo", Cn, Params, CommandType.StoredProcedure)

                    If Not IsNothing(Dset) Or Dset.Tables(0).Rows.Count > 0 Then
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

                            If Not IsNothing(Drow("candidateimg")) Then
                                Dim imgArr() As Byte = Drow("candidateimg")
                                Dim mstream As New System.IO.MemoryStream(imgArr)
                                picCandidate.Image = Image.FromStream(mstream)
                            End If


                            txtCandidateRemarks.Text = Drow("candidateremarks")
                        Next
                        Call Tran_FamilyBackground(4, 0, CandidateId, CurrentUserId)
                        Call Tran_EducationalBackground(4, 0, CandidateId, CurrentUserId)
                        Call Tran_EmploymentHistory(4, 0, CandidateId, CurrentUserId)
                        Call Tran_CandidateSkills(4, 0, CandidateId, CurrentUserId)
                    End If

                Case 4

                Case Else

            End Select
        End Using

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

        Dim Legend As String = _
            <Legend>
               0 - Add
               1 - Edit
               2 - Delete
               3 - Load Information
               4 - Load List
            </Legend>

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidatefamilybackground", Cn, Params, CommandType.StoredProcedure)

                Case 3
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

                Case 4
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

                Case Else

            End Select
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

        Dim Legend As String = _
            <Legend>
               0 - Add
               1 - Edit
               2 - Delete
               3 - Load Information
               4 - Load List
            </Legend>

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidateeduchist", Cn, Params, CommandType.StoredProcedure)

                Case 3
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

                Case 4
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

                Case Else

            End Select
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

        Dim Legend As String = _
            <Legend>
               0 - Add
               1 - Edit
               2 - Delete
               3 - Load Information
               4 - Load List
            </Legend>

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
                        FormatGridColumn(dgvEmp, 2, "EmpId", False, False, True, 50)
                        FormatGridColumn(dgvEmp, 3, "CandidateId", False, False, True, 50)
                        FormatGridColumn(dgvEmp, 4, "Present", False, True, True, 70, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter)
                        FormatGridColumn(dgvEmp, 5, "Company Name", True, True, True, 300)
                        FormatGridColumn(dgvEmp, 6, "Position Held", False, True, True, 250)
                        FormatGridColumn(dgvEmp, 7, "Inclusive Dates", False, True, True, 200)
                        FormatGridColumn(dgvEmp, 8, "Reason for Leaving", False, True, True, 350)
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

        Dim Legend As String = _
            <Legend>
               0 - Add
               1 - Edit
               2 - Delete
               3 - Load Information
               4 - Load List
            </Legend>

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_candidateskills", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_candidateskills", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        cboSkillType.SelectedValue = CInt(Drow("skilltypeid"))
                        cboSkillGroup.SelectedValue = CInt(Drow("skillgroupid"))
                        cboSkill.SelectedValue = CInt(Drow("skillid"))
                        cboSkillLevel.SelectedValue = CInt(Drow("skilllevelid"))
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
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            Call TranCandidateInfo(3, SelectedId)
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
            If .SelectedIndex = 0 Or .SelectedIndex = 1 Then
                tsOps.Enabled = True
            Else
                tsOps.Enabled = False
                Select Case .SelectedIndex
                    Case 2
                        If SelectedId > 0 Then tsFM.Enabled = True Else tsFM.Enabled = False
                    Case 3
                        If SelectedId > 0 Then tsEduc.Enabled = True Else tsEduc.Enabled = False
                    Case 4
                        If SelectedId > 0 Then tsEmp.Enabled = True Else tsEmp.Enabled = False
                    Case 5
                        If SelectedId > 0 Then tsSkills.Enabled = True Else tsSkills.Enabled = False
                    Case Else

                End Select
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
        picCandidate.Image = RecSys.My.Resources.profilephoto2

        If CandidateTranType = 0 Then
            Call LogActivity(1, "User " + CurrentUName + " cancels profile creation.", CurrentUID)
        ElseIf CandidateTranType = 1 Then
            Call LogActivity(1, "User " + CurrentUName + "cancels modification of profile " + txtFName.Text + " " + txtLName.Text + ".", CurrentUID)
        Else
            ' Unhandled transaction
        End If

        Call ClearNEnableFields(False)
        dgvFM.Rows.Clear()
        dgvEduHist.Rows.Clear()
        dgvEmp.Rows.Clear()
        dgvSkill.Rows.Clear()
        CandidateTranType = -1
        SelectedId = 0

    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If SelectedId > 0 Then
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
        If SelectedId > 0 Then
            If MsgBox("Would you like to remove candidate profile of [" + lblRefId.Text + " " + txtFName.Text + " " + txtLName.Text + "] ?") = MsgBoxResult.Yes Then
                Call TranCandidateInfo(2, SelectedId)
                Call LogActivity(1, "User " + CurrentUName + " successfully deleted the candidate profile of Mr./Ms. " + txtFName.Text + " " + txtLName.Text + ".", CurrentUID)
                Call ClearNEnableFields(False)
                CandidateTranType = -1
                SelectedId = 0
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
            MsgBox("Unable to save information. Please enter a valid value for [First Name] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply a value to [First Name] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtLName.Text.Trim.Length = 0 Then
            MsgBox("Unable to save information. Please enter a valid value for [Last Name] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply a value to [Last Name] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtApplyingFor.Text.Length = 0 Then
            MsgBox("Unable to save information. Please enter a valid value for [Position Applying for] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply a value to [Position Applying for] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If cboAppSource.SelectedIndex = -1 Then
            MsgBox("Unable to save information. Please select a value for [Application Source] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to select a valid value from [Application Source] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtSalary.Text.Trim.Length = 0 Or IsNumeric(txtSalary.Text) = False Then
            MsgBox("Unable to save information. Please enter a valid value for [Preferred Salary Rate] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply a value to [Preferred Salary Rate] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If cboGender.SelectedIndex = -1 Then
            MsgBox("Unable to save information. Please select a valid value for [Gender] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply a value to [Gender] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If CInt(txtAge.Text) < 18 Then
            If MsgBox("Under law, ages below 18 are NOT allowed to work without proper consent from a legal guardian. Proceed?", MsgBoxStyle.Question + vbYesNo, "Confirm") = MsgBoxResult.Yes Then
                LogActivity(1, "Sytem validation : User verifies and confirms adding candidate under 18 of age.", CurrentUID)
            Else
                Exit Sub
            End If
        End If
        If cboCStatus.SelectedIndex = -1 Then
            MsgBox("Unable to save information. Please enter a valid value for [Civil Status] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to select a vald value from [Civil Status] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtAdd1.Text.Trim.Length = 0 And txtAdd2.Text.Trim.Length = 0 Then
            MsgBox("Unable to save information. Please enter at least one(1) valid Address in [Address 1] or [Address 2] field.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply value to [Address 1] or [Address 2] field while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If (rdbAdd1.Checked = True And txtAdd1.Text.Trim.Length = 0) Or (rdbAdd2.Checked = True And txtAdd2.Text.Trim.Length = 0) Then
            MsgBox("Unable to save information. Selected [Primary Address] cannot be empty.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply value to [Address 1] as [Primary Address] while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtPhoneNo.Text.Trim.Length = 0 And txtMobileNo.Text.Trim.Length = 0 Then
            MsgBox("Unable to save information. Candidate should have at least one(1) valid contact number.", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply value to [Phone Number] or [Mobile Number] while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        End If
        If txtEmail.Text.Trim.Length = 0 Then
            MsgBox("Unable to save information. Candidate should have at least one(1) valid [Email Address].", MsgBoxStyle.Exclamation, "Saving Error")
            LogActivity(1, "Sytem validation : User fails to supply value to [Email Address] while attempting to save Candidate Information", CurrentUID)
            Exit Sub
        Else
            If IsValidEmail(txtEmail.Text) = False Then
                MsgBox("Unable to save information. [Email Address] value is invalid.", MsgBoxStyle.Exclamation, "Saving Error")
                LogActivity(1, "Sytem validation : User supplies and invalid [Email Address] while attempting to save Candidate Information", CurrentUID)
                Exit Sub
            End If
        End If

        If txtAvailInCount.Text = "" Then txtAvailInCount.Text = "0"

        Dim AvailType As Integer = -1
        If rdbAvail0.Checked = True Then
            AvailType = 0
        ElseIf rdbAvail1.Checked = True Then
            AvailType = 1
        ElseIf rdbAvail2.Checked = True Then
            AvailType = 2
        ElseIf rdbAvail3.Checked = True Then
            AvailType = 3
        Else
            AvailType = 0
        End If

        If selImagePath.Length > 0 Then
            Using imgObj As Image = Image.FromFile(selImagePath)
                Using imgStream As New IO.MemoryStream
                    imgObj.Save(imgStream, Imaging.ImageFormat.Jpeg)
                    imgData = imgStream
                End Using
            End Using
        End If

        If MsgBox("Save Candidate information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call TranCandidateInfo(CandidateTranType, SelectedId, CurrentUID, txtLName.Text, txtFName.Text, txtMName.Text, cboGender.SelectedIndex, dtpBDate.Value, _
                                   txtBPlace.Text, cboCStatus.SelectedIndex, txtAdd1.Text, rdbAdd1.Checked, txtAdd2.Text, rdbAdd2.Checked, _
                                   txtPhoneNo.Text, txtMobileNo.Text, txtEmail.Text, mtbSSS.Text, mtbTIN.Text, mtbHDMF.Text, mtbPH.Text, _
                                   1, txtApplyingFor.Text, cboAppSource.SelectedValue, txtAppSrcRemarks.Text, txtPrefWorkLocation.Text, txtSalary.Text, _
                                   cboSalaryRate.SelectedIndex, chkIsNegotiable.Checked, AvailType, txtAvailInCount.Text, cboAvailInType.SelectedIndex, _
                                   dtpAvailableOn.Value, txtCandidateRemarks.Text, imgData.GetBuffer())

            MsgBox("Candidate profile has been saved successfully", MsgBoxStyle.Information, "Saved")
        End If
    End Sub

    Private Sub dgvFM_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFM.CellClick
        selFMId = dgvFM.Rows(e.RowIndex).Cells("cf_id").Value.ToString
        selFMCandidateId = dgvFM.Rows(e.RowIndex).Cells("ci_id").Value.ToString
        selFMName = dgvFM.Rows(e.RowIndex).Cells("familymembername").Value.ToString

        Select Case e.ColumnIndex
            Case 0
                FMTranType = 1
                Call Tran_FamilyBackground(3, selFMId, selFMCandidateId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
                tsbFMSave.ToolTipText = "Update Information"
            Case 1
                If MsgBox("Proceed removing Family Member?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                    Call Tran_FamilyBackground(2, selFMId, selFMCandidateId, CurrentUID)
                    Call Tran_FamilyBackground(4, 0, selFMCandidateId, CurrentUID)
                    MsgBox(selFMName + " has been removed from list.", MsgBoxStyle.Information, "Removed")
                End If
            Case Else

        End Select

    End Sub

    Private Sub tsbFMSave_Click(sender As Object, e As EventArgs) Handles tsbFMSave.Click
        If FMTranType = 0 Then
            Call Tran_FamilyBackground(0, 0, SelectedId, CurrentUID, txtFMName.Text, dtpFMBDate.Value, cboFMCStatus.SelectedIndex, txtFMRel.Text, txtFMOccupation.Text, chkFMIsDeceased.Checked)
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

        Call Tran_FamilyBackground(4, 0, SelectedId, CurrentUID)

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

        Select Case e.ColumnIndex
            Case 0
                EducTranType = 1
                Call Tran_EducationalBackground(3, selEducId, selEducCandidateId, CurrentUID)
                tsbEducSave.ToolTipText = "Update Information"

            Case 1
                If MsgBox("Proceed removing Education from list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                    Call Tran_EducationalBackground(2, selEducId, selEducCandidateId, CurrentUID)
                    Call Tran_EducationalBackground(4, 0, selEducCandidateId, CurrentUID)
                    MsgBox(selCourseTaken + " from " + selSchool + " has been removed from list.", MsgBoxStyle.Information, "Removed")
                End If
            Case Else

        End Select

    End Sub

    Private Sub tsbEducSave_Click(sender As Object, e As EventArgs) Handles tsbEducSave.Click
        If EducTranType = 0 Then
            Call Tran_EducationalBackground(0, 0, SelectedId, CurrentUID, txtEduSchool.Text, txtEduAdd.Text, txtEduCourse.Text, dtpEduStart.Value, dtpEduEnd.Value, dtpEduGrad.Value, chkEduIsUG.Checked, txtEduHonors.Text)
            MsgBox("Education has been added to list.", MsgBoxStyle.Information, "Education Added")
        Else
            Call Tran_EducationalBackground(1, 0, SelectedId, CurrentUID, txtEduSchool.Text, txtEduAdd.Text, txtEduCourse.Text, dtpEduStart.Value, dtpEduEnd.Value, dtpEduGrad.Value, chkEduIsUG.Checked, txtEduHonors.Text)
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

        Call Tran_EducationalBackground(4, 0, SelectedId, CurrentUID)

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
        picCandidate.Image = picCandidate.InitialImage
    End Sub

    Private Sub dgvEmp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmp.CellClick
        selEmpId = dgvEmp.Rows(e.RowIndex).Cells("ce_id").Value.ToString
        selEmpCandidateId = dgvEmp.Rows(e.RowIndex).Cells("ci_id").Value.ToString
        selCompanyName = dgvEmp.Rows(e.RowIndex).Cells("companyname").Value.ToString
        selJobPost = dgvEmp.Rows(e.RowIndex).Cells("posheld").Value.ToString

        Select Case e.ColumnIndex
            Case 0
                EmpTranType = 1
                Call Tran_EmploymentHistory(3, selEmpId, selEmpCandidateId, CurrentUID)
            Case 1
                If MsgBox("Proceed removing employment from list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm?") = MsgBoxResult.Yes Then
                    Call Tran_EmploymentHistory(2, selEmpId, selEmpCandidateId, CurrentUID)
                    Call Tran_EmploymentHistory(4, 0, selEmpCandidateId, CurrentUID)
                    MsgBox("Employment has been successfully removed from list.", MsgBoxStyle.Information, "Removed")
                End If
            Case Else

        End Select

    End Sub

    Private Sub tsbEmpSave_Click(sender As Object, e As EventArgs) Handles tsbEmpSave.Click
        If EmpTranType = 0 Then
            Call Tran_EmploymentHistory(0, 0, SelectedId, CurrentUID, txtEmpCName.Text, txtEmpCAdd.Text, txtEmpCContact.Text, dtpEmpStart.Value, dtpEmpEnd.Value, chkEmpPresent.Checked, txtEmpPosHeld.Text, txtEmpIS.Text, txtEmpReason.Text)
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
        Call Tran_EmploymentHistory(4, 0, SelectedId, CurrentUID)

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

    Private Sub btnUseImgFile_Click(sender As Object, e As EventArgs) Handles btnUseImgFile.Click
        ofdImage.InitialDirectory = Application.StartupPath
        ofdImage.Filter = "JPG/JPEG Images (*.jpg/*jpeg) | *.jpg; *.jpeg|Bitmap Images (*.bmp)| *.bmp"
        ofdImage.FilterIndex = 0
        If ofdImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            picCandidate.Image = Image.FromFile(ofdImage.FileName)
            selImagePath = ofdImage.FileName
            MsgBox(selImagePath)
        End If
    End Sub

    Private Sub cboSkillType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSkillType.SelectedValueChanged
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            'Skill Group
            Qry = <Query>
                        select 0 as sg_id, '- Select a Skill Group -' as description
                        union all
                        select `sg_id`, `description` from `rms_skillgroups` where `st_id` = @skilltypeid and `recstatus` = 1;
                  </Query>.Value
            Params = New ArrayList
            Params.Add(New MySqlParameter("@skilltypeid", cboSkillType.SelectedValue))
            Call FillComboBox(Qry, Cn, "description", "sg_id", cboSkillGroup, Params, CommandType.Text)
        End Using
    End Sub

    Private Sub cboSkillGroup_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSkillGroup.SelectedValueChanged
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            'Skill Group
            Qry = <Query>
                        select 0 as sk_id, '- Select a Skill -' as description
                        union all
                        select `sk_id`, `description` from `rms_skills` where `sg_id` = @skillgroupid and `recstatus` = 1;
                  </Query>
            Params = New ArrayList
            Params.Add(New MySqlParameter("@skillgroupid", cboSkillGroup.SelectedValue))
            Call FillComboBox(Qry, Cn, "description", "sk_id", cboSkill, Params, CommandType.Text)
        End Using
    End Sub

    Private Sub tsbSkillSave_Click(sender As Object, e As EventArgs) Handles tsbSkillSave.Click
        If cboSkillType.SelectedValue = 0 Or cboSkillGroup.SelectedValue = 0 Or cboSkill.SelectedValue = 0 Or cboSkillLevel.SelectedValue = 0 Then
            MsgBox("Incomplete/Invalid selection. Please try again.", MsgBoxStyle.Exclamation, "Saving Failed")
            Exit Sub
        End If
        If txtSLastYearUsed.Text.Trim.Length < 4 Then
            MsgBox("You have entered an invalid year. Try again.", MsgBoxStyle.Exclamation, "Saving Failed")
            Exit Sub
        End If
        If txtSYearUsed.Text.Trim.Length = 0 Then
            MsgBox("Invalid value supplied. Try again", MsgBoxStyle.Exclamation, "Saving Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Dim SkillExists As Integer = 0
            Qry = "select count(`cs_id`) as skillexists from `rms_candidateskills` where `ci_id` = @candidateid and `skillid` = @skillid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@candidateid", SelectedId))
            Params.Add(New MySqlParameter("@skillid", cboSkill.SelectedValue))
            SkillExists = QueryExec(Qry, Cn, Params, CommandType.Text)
            If SkillExists > 0 Then
                MsgBox("Skill has already been added to list. Please select a different skill then try again.", MsgBoxStyle.Exclamation, "Saving Failed")
                Exit Sub
            End If
        End Using

        If MsgBox("Save this skill to list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_CandidateSkills(SkillTranType, selSkillRecId, SelectedId, CurrentUID, cboSkillType.SelectedValue, _
                                      cboSkillGroup.SelectedValue, cboSkill.SelectedValue, cboSkillLevel.SelectedValue, txtSYearUsed.Text, txtSLastYearUsed.Text)
            MsgBox("Skill saved successfully.", MsgBoxStyle.Information, "Saved")
            Tran_CandidateSkills(4, 0, SelectedId, CurrentUID)
            tsbSkillCancel.PerformClick()
        End If
    End Sub

    Private Sub tsbSkillCancel_Click(sender As Object, e As EventArgs) Handles tsbSkillCancel.Click
        cboSkillType.SelectedValue = 0
        cboSkillGroup.SelectedValue = 0
        cboSkill.SelectedValue = 0
        cboSkillLevel.SelectedValue = 0
        txtSLastYearUsed.Text = Year(Now).ToString
        txtSYearUsed.Text = "0"
        SkillTranType = 0
    End Sub

    Private Sub dgvSkill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSkill.CellClick
        selSkillRecId = dgvSkill.Rows(e.RowIndex).Cells("cs_id").Value.ToString
        selSkillType = dgvSkill.Rows(e.RowIndex).Cells("skilltypeid").Value.ToString
        selSkillGroup = dgvSkill.Rows(e.RowIndex).Cells("skillgroupid").Value.ToString
        selSkillId = dgvSkill.Rows(e.RowIndex).Cells("skillid").Value.ToString
        selSkillName = dgvSkill.Rows(e.RowIndex).Cells("skillname").Value.ToString

        Select Case e.ColumnIndex
            Case 0
                SkillTranType = 1
                Call Tran_CandidateSkills(1, selSkillRecId, SelectedId, CurrentUID)
            Case 1
                If MsgBox("Remove skill from list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    Call Tran_CandidateSkills(2, selSkillRecId, SelectedId, CurrentUID)
                    MsgBox("Skill has been successfully removed from list.", MsgBoxStyle.Information, "Removed")
                    Call Tran_CandidateSkills(4, selSkillRecId, SelectedId, CurrentUID)
                    SkillTranType = 0
                End If
            Case Else

        End Select
    End Sub


End Class