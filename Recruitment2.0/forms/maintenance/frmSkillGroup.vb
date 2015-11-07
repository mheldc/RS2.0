Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frmSkillGroup
    Dim SGTranType As Integer

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
                            cboSkillType.SelectedIndex = CInt(Drow("st_id"))
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
    End Sub

    Private Sub frmSkillGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Call ClearNEnableFields(True)
        SGTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If MsgBox("Remove selected skill group?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_SkillGroup(2, SelectedId, CurrentUID)
            MsgBox("Skill group successfully removed.", MsgBoxStyle.Information, "Removed")
            Call ClearNEnableFields()
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click

    End Sub

    Private Sub tsbCancel_Click(sender As Object, e As EventArgs) Handles tsbCancel.Click

    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click

    End Sub

    Private Sub tsbPrint_Click(sender As Object, e As EventArgs) Handles tsbPrint.Click

    End Sub
End Class