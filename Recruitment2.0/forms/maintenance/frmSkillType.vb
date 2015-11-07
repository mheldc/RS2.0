Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frmSkillType

    Dim SkillTranType As Integer = -1

    Private Sub Tran_SkillTypes(ByVal TranType As Integer, ByVal SkillTypeId As Integer, ByVal CurrentUserId As Integer, _
                                Optional ByVal SkillTypeDesc As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", SkillTypeId))
        Params.Add(New MySqlParameter("@typedesc", SkillTypeDesc))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0, 1, 2
                    QueryExec("tran_skilltypes", Cn, Params, CommandType.StoredProcedure)
                    Call ClearNEnableFields()
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_skilltypes", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        txtSTCode.Text = Drow("typecode")
                        txtSTDesc.Text = Drow("description")
                    Next

                Case 4
                Case Else

            End Select
        End Using
    End Sub

    Public Sub ClearNEnableFields(Optional ByVal IsEnabled As Boolean = False)
        txtSTCode.Clear()
        txtSTDesc.Clear()
        pnlInfo.Enabled = IsEnabled
    End Sub

    Private Sub frmSkillType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        ClearNEnableFields(True)
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        SkillTranType = 0
        Call LogActivity(1, "User " + CurrentUName + " clicks Add Skill Type button", CurrentUID)
    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click
        pnlInfo.Enabled = True
        tsbSave.Visible = True
        tsbCancel.Visible = True
        tsbAdd.Visible = False
        tsbEdit.Visible = False
        tsbDelete.Visible = False
        tsbSeparator.Visible = False
        tsbSearch.Visible = False
        tsbPrint.Visible = False
        SkillTranType = 1
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        If MsgBox("Proceed in removing Skill Type [" + txtSTCode.Text + " : " + txtSTDesc.Text + "]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Call Tran_SkillTypes(2, SelectedId, CurrentUID)
            Call ClearNEnableFields()
            MsgBox("Skill type has been removed sucessfully", MsgBoxStyle.Information, "Removed")
            SelectedId = 0
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        If txtSTDesc.Text.Trim.Length = 0 Then
            MsgBox("Description field can't be empty. Key in a valid value.", MsgBoxStyle.Exclamation, "Save Failed")
            Exit Sub
        End If

        Select Case SkillTranType
            Case 0
                If MsgBox("Add skill type " + txtSTDesc.Text + "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Create?") = MsgBoxResult.Yes Then
                    Call Tran_SkillTypes(0, 0, CurrentUID, txtSTDesc.Text)
                    MsgBox("New skill type has been created successfully.", MsgBoxStyle.Information, "Success")
                End If
            Case 1
                If MsgBox("Update skill type " + txtSTDesc.Text + "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Update?") = MsgBoxResult.Yes Then
                    Call Tran_SkillTypes(1, SelectedId, CurrentUID, txtSTDesc.Text)
                    MsgBox("Selected skill type has been modified successfully.", MsgBoxStyle.Information, "Success")
                End If
            Case Else

        End Select

        tsbAdd.Visible = True
        tsbEdit.Visible = True
        tsbDelete.Visible = True
        tsbSeparator.Visible = True
        tsbSearch.Visible = True
        tsbPrint.Visible = True
        tsbSave.Visible = False
        tsbCancel.Visible = False
        Call ClearNEnableFields()
        SelectedId = 0
    End Sub

    Private Sub tsbSearch_Click(sender As Object, e As EventArgs) Handles tsbSearch.Click
        With frmSearch
            .StartPosition = FormStartPosition.CenterScreen
            .WindowState = FormWindowState.Normal
            .LoadSeachItems(Me)
            .ShowDialog()
            Call Tran_SkillTypes(3, SelectedId, CurrentUID)
        End With
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
        SelectedId = 0
    End Sub
End Class