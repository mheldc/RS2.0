Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmSkill
    Dim SkillTranType As Integer = -1
    Dim SkillId As Integer = 0

    Private Sub Tran_Skill(ByVal TranType As Integer, ByVal SkillId As Integer, ByVal CurrentUserId As Integer, _
                           Optional SkillGroupId As Integer = Nothing, Optional ByVal SkillDesc As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SkillId))
        Params.Add(New MySqlParameter("@sgroupid", SkillGroupId))
        Params.Add(New MySqlParameter("@skilldesc", SkillDesc))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_skills", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_skills", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        cboType.SelectedValue = CInt(Drow("st_id"))
                        cboGroup.SelectedValue = CInt(Drow("sg_id"))
                        txtCode.Text = Drow("skillcode")
                        txtDesc.Text = Drow("skill")
                    Next
                Case 4

                Case Else

            End Select
        End Using
    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        cboType.SelectedValue = -1
        cboGroup.DataSource = Nothing
        txtCode.Clear()
        txtDesc.Clear()
        pnlInfo.Enabled = IsEnabled
        SkillId = 0
    End Sub

    Private Sub frmSkill_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Qry = "select `st_id`, `description` from `rms_skilltypes` where `recstatus` = 1;"
            FillComboBox(Qry, Cn, "description", "st_id", cboType, , CommandType.Text)
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
        SkillTranType = 0
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        If SkillId = 0 Then
            MsgBox("You have not selected any item to update. Select an item then try again.", MsgBoxStyle.Exclamation, "Edit Failed")
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
        SkillTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If SelectedId = 0 Then
            MsgBox("You have not selected any item to delete. Select an item first then try again", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        ' Candidate Skills
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Qry = "select count(`cs_id`) from `rms_candidateskills` where `skillid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", SelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Skill [" + txtDesc.Text + "] cannot be deleted due to it's dependencies in Candidate Skills", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Remove [" + txtDesc.Text + "] skill list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_Skill(2, SkillId, CurrentUID, cboGroup.SelectedValue, txtDesc.Text)
            MsgBox("Skill successfully deleted", MsgBoxStyle.Information, "Removed")
            tsbCancel.PerformClick()
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtDesc.Text.Trim.Length = 0 Then
            MsgBox("Description field can't be empty. Key in a valid value.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        If MsgBox("Save skill information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_Skill(SkillTranType, SkillId, CurrentUID, cboGroup.SelectedValue, txtDesc.Text)
            MsgBox("Skill saved successfully.", MsgBoxStyle.Information, "Saved")
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
        tsbCancel.Visible = False
        tsbSave.Visible = False
        ClearNEnableFields()
        SkillTranType = -1
        SkillId = 0
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            SkillId = SelectedId
            Call Tran_Skill(3, SkillId, CurrentUID)
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Qry = "select `sg_id`, `description` from `rms_skillgroups` where `st_id` = @skilltypeid and `recstatus` = 1;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@skilltypeid", cboType.SelectedValue))
            FillComboBox(Qry, Cn, "description", "sg_id", cboGroup, Params, CommandType.Text)
        End Using
    End Sub

End Class