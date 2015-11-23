Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports RecSys.RSv2.Mailer
Imports RecSys.RSv2.AppForm
Imports RecSys.RSv2.RegExUtilities
Imports MySql.Data.MySqlClient

Public Class frmUserProfile

    Dim UserProfileId As Integer

    Private Sub Tran_UserProfile(ByVal TranType As Integer, ByVal UserProfileId As Integer, ByVal CurrentUserId As Integer, _
                                  Optional ByVal UserGroupId As Integer = Nothing, Optional ByVal DepartmentId As Integer = Nothing, Optional ByVal Username As String = Nothing, _
                                  Optional ByVal UserPassword As String = Nothing, Optional ByVal FirstName As String = Nothing, Optional ByVal MiddleName As String = Nothing, _
                                  Optional ByVal LastName As String = Nothing, Optional ByVal EmailAddress As String = Nothing, Optional ByVal MustChangePassword As Boolean = Nothing, _
                                  Optional ByVal DoesPasswordExpires As String = Nothing)

        Params = New ArrayList
        Params.Add(New MySqlParameter("@trantype", TranType))
        Params.Add(New MySqlParameter("@recid", UserProfileId))
        Params.Add(New MySqlParameter("@usergroupid", UserGroupId))
        Params.Add(New MySqlParameter("@departmentid", DepartmentId))
        Params.Add(New MySqlParameter("@username", Username))
        Params.Add(New MySqlParameter("@userpwd", UserPassword))
        Params.Add(New MySqlParameter("@fname", FirstName))
        Params.Add(New MySqlParameter("@mname", MiddleName))
        Params.Add(New MySqlParameter("@lname", LastName))
        Params.Add(New MySqlParameter("@emailadd", EmailAddress))
        Params.Add(New MySqlParameter("@mustchangepwd", MustChangePassword))
        Params.Add(New MySqlParameter("@doespwdexpires", DoesPasswordExpires))
        Params.Add(New MySqlParameter("@usedid", CurrentUserId))

        Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
            Select Case TranType
                Case 0
                    UserProfileId = QueryExec("tran_userprofile", Cn, Params, CommandType.StoredProcedure)
                Case 1, 2
                    QueryExec("tran_userprofile", Cn, Params, CommandType.StoredProcedure)
                Case 3
                    Dset = New DataSet
                    Dset = Query("tran_userprofile", Cn, Params, CommandType.StoredProcedure)

                    For Each Drow As DataRow In Dset.Tables(0).Rows
                        cboUserGroup.SelectedValue = CInt(Drow("ug_id"))
                        cboDept.SelectedValue = CInt(Drow("dp_id"))
                        txtFName.Text = Drow("firstname")
                        txtMName.Text = Drow("middlename")
                        txtLName.Text = Drow("lastname")
                        txtEmail.Text = Drow("email")
                        chkChangePwd.Checked = CBool(Drow("ispwdchanged"))
                        chkPwdExpires.Checked = CBool(Drow("passwordexpires"))

                    Next
                Case 4

                Case Else

            End Select
        End Using

    End Sub

    Private Sub frmUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        trvModules.ExpandAll()
    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click

    End Sub

    Private Sub tsbEdit_Click(sender As Object, e As EventArgs) Handles tsbEdit.Click

    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click

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