Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frmSkillGroup
    Dim SGTranType As Integer = -1
    Dim SGSelectedId As Integer = 0

    Private Sub Tran_SkillGroup(ByVal TranType As Integer, ByVal SkillGroupId As Integer, CurrentUserId As Integer, _
                                Optional ByVal SkillTypeId As Integer = Nothing, Optional ByVal GroupDescription As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SkillGroupId))
        Params.Add(New MySqlParameter("@typeid", SkillTypeId))
        Params.Add(New MySqlParameter("@sgroupdesc", GroupDescription))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_skillgroup", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = Query("tran_skillgroup", Cn, Params, CommandType.StoredProcedure)

                    If Not IsNothing(Dset) Then
                        For Each Drow As DataRow In Dset.Tables(0).Rows
                            cboSkillType.SelectedValue = CInt(Drow("st_id"))
                            txtGroupCode.Text = Drow("groupcode")
                            txtGroupDesc.Text = Drow("description")
                        Next
                    End If
                Case 4

                Case Else

            End Select
        End Using
    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        cboSkillType.SelectedIndex = -1
        txtGroupCode.Clear()
        txtGroupDesc.Clear()
        pnlInfo.Enabled = IsEnabled
        SGTranType = -1
        SGSelectedId = 0
    End Sub

    Private Sub frmSkillGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Qry = "select `st_id`, `description` from `rms_skilltypes` where `recstatus` = 1;"
            Call FillComboBox(Qry, Cn, "description", "st_id", cboSkillType, , CommandType.Text)
        End Using
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
        Call ClearNEnableFields(True)
        SGTranType = 0
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
        SGTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If SelectedId = 0 Then
            MsgBox("You have not selected any item to delete. Select an item first then try again", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Skill Dependencies
            Qry = "select count(`sk_id`) from `rms_skills` where `sg_id` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", SelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Skill group [" + txtGroupDesc.Text + "] cannot be deleted due to it's dependencies in Skills", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If

            ' Candidate Skills
            Qry = "select count(`cs_id`) from `rms_candidateskills` where `skillgroupid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", SGSelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Skill group [" + txtGroupDesc.Text + "] cannot be deleted due to it's dependencies in Candidate Skills", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If

            ' Manpower Request Skills
            Qry = "select count(`ms_id`) from `rms_mrskills` where `skillgroupid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", SelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Skill group [" + txtGroupDesc.Text + "] cannot be deleted due to it's dependencies in Manpower Request Skills", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Remove selected skill group?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_SkillGroup(2, SGSelectedId, CurrentUID)
            MsgBox("Skill group successfully removed.", MsgBoxStyle.Information, "Removed")
            Call ClearNEnableFields()
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If cboSkillType.SelectedIndex = -1 Then
            MsgBox("Please select a valid Skill Type.", MsgBoxStyle.Exclamation, "Invalid Skill Type")
            Exit Sub
        End If
        If txtGroupDesc.Text.Trim.Length = 0 Then
            MsgBox("Skill Group description cannot be empty.", MsgBoxStyle.Exclamation, "Invalid Entry")
            Exit Sub
        End If

        Call Tran_SkillGroup(SGTranType, SGSelectedId, CurrentUID, cboSkillType.SelectedValue, txtGroupDesc.Text)
        MsgBox("Skill group has been saved successfully", MsgBoxStyle.Information, "Saved")

        tsbCancel.PerformClick()
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
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            SGSelectedId = SelectedId
            Call Tran_SkillGroup(3, SelectedId, CurrentUID)
            SelectedId = 0
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class