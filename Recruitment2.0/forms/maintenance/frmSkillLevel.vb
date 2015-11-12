Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmSkillLevel

    Dim SkillLevelTranType As Integer = -1

    Private Sub Tran_SkillLevel(ByVal TranType As Integer, ByVal SkillLevelId As Integer, ByVal CurrentUserId As Integer, _
                                Optional ByVal LevelDescription As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SkillLevelId))
        Params.Add(New MySqlParameter("@leveldesc", LevelDescription))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_skilllevel", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_skilllevel", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        txtLevelCode.Text = Drow("levelcode")
                        txtLevelDesc.Text = Drow("description")
                    Next
                Case 4

                Case Else

            End Select
        End Using
    End Sub

    Private Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        txtLevelCode.Clear()
        txtLevelDesc.Clear()
        pnlInfo.Enabled = IsEnabled
    End Sub

    Private Sub frmSkillLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        SkillLevelTranType = 0
        Call ClearNEnableFields(True)
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
        SkillLevelTranType = 1
        pnlInfo.Enabled = True
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If SelectedId = 0 Then
            MsgBox("You have not selected any item to delete. Select an item first then try again", MsgBoxStyle.Exclamation, "Delete Failed")
            Exit Sub
        End If

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            ' Candidate Skills
            Qry = "select count(`cs_id`) from `rms_candidateskills` where `skilllevelid` = @selectedid;"
            Params = New ArrayList
            Params.Add(New MySqlParameter("@selectedid", SelectedId))
            HasDependencies = QueryExec(Qry, Cn, Params, CommandType.Text)
            If HasDependencies > 0 Then
                MsgBox("Skill level [" + txtLevelDesc.Text + "] cannot be deleted due to it's dependencies in Candidate Skills", MsgBoxStyle.Exclamation, "Delete Error")
                Exit Sub
            End If
        End Using

        If MsgBox("Remove selected skill level?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_SkillLevel(2, SelectedId, CurrentUID)
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtLevelDesc.Text.Trim.Length = 0 Then
            MsgBox("Description field can't be empty. Key in a valid value.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If
        Call Tran_SkillLevel(SkillLevelTranType, SelectedId, CurrentUID, txtLevelDesc.Text)
        MsgBox("Skill level saved successfully.", MsgBoxStyle.Information, "Saved")
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
        SkillLevelTranType = -1
        SelectedId = 0
        Call ClearNEnableFields()
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            Call Tran_SkillLevel(3, SelectedId, CurrentUID)
        End With
    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class