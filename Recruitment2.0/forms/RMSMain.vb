Imports RecSys.RSv2.Declares
Imports RecSys.RSv2.DataConnection
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient


Public Class RMSMain

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' For Testing purposes
        DefHost = "localhost"
        DefDb = "rmsv2"
        DefUID = "root"
        DefPWD = ""
        DefPort = 3306

        CurrentUID = 1
        CurrentUName = "Admin"
        CurrentUPosition = "Administrator"

    End Sub
    Function TestEncoding() As String
        Dim plainText As String = InputBox("Enter the plain text:")
        'Dim password As String = InputBox("Enter the password:")

        'Dim wrapper As New Simple3Des(password)
        Dim wrapper As New RecSys.RSv2.Security()
        Dim cipherText As String = wrapper.EncryptData(plainText)

        Return cipherText
        'MsgBox("The cipher text is: " & cipherText)
        'My.Computer.FileSystem.WriteAllText(
        '    My.Computer.FileSystem.SpecialDirectories.MyDocuments &
        '    "\cipherText.txt", cipherText, False)
    End Function

    Function TestDecoding() As String
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                "\cipherText.txt")
        'Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New RecSys.RSv2.Security()

        ' DecryptData throws if the wrong password is used. 
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            Return plainText
            'MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
            Return Nothing
        End Try
    End Function

    Private Sub tsFile_Click(sender As Object, e As EventArgs) Handles tsFile.Click


    End Sub

    Private Sub SystemToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SystemToolStripMenuItem1.Click

    End Sub

    Private Sub RequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestToolStripMenuItem.Click

    End Sub

    Private Sub NewFormsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim x As New frmStageCandidate
        x.TopLevel = False
        x.MdiParent = Me
        x.StartPosition = FormStartPosition.CenterParent
        x.WindowState = FormWindowState.Maximized
        x.Show()
    End Sub

    Private Sub CandidateProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CandidateProfileToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCandidateProfile).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmCandidateProfile
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .tsbAdd.PerformClick()
                .Show()
            End With

        End If
    End Sub

    Private Sub CandidateProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CandidateProfileToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmCandidateProfile).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmCandidateProfile
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ClearNEnableFields(False)
                .Show()
                .tsbSearch.PerformClick()
            End With

        End If
    End Sub

    Private Sub SkillTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkillTypeToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSkillType).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillType
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub SourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourcesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCandidateSource).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmCandidateSource
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkillGroupToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSkillGroup).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillGroup
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillTypeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SkillTypeToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmSkillType).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillType
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillGroupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SkillGroupToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmSkillGroup).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillGroup
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillLevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkillLevelToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSkillLevel).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillLevel
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SkillToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmSkill).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkill
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkillToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSkillLevel).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkillLevel
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub SkillToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SkillToolStripMenuItem3.Click
        If Application.OpenForms().OfType(Of frmSkill).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmSkill
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub ManpowerRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManpowerRequestToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmMR).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmMR
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .tsbAdd.PerformClick()
                .Show()
            End With
        End If
    End Sub

    Private Sub TypesToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles TypesToolStripMenuItem4.Click
        If Application.OpenForms().OfType(Of frmAccountTypes).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmAccountTypes
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub ClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmClientProfile).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmClientProfile
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub DepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmDepartment).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmDepartment
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub DepartmentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DepartmentToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of frmDepartment).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmDepartment
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
                .tsbAdd.PerformClick()
            End With
        End If
    End Sub

    Private Sub AccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmUserProfile).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim frmObj As New frmUserProfile
            With frmObj
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .Show()
                .tsbAdd.PerformClick()
            End With
        End If
    End Sub
End Class
