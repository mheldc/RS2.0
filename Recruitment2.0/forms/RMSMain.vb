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
            Dim cProfile As New frmCandidateProfile
            With cProfile
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
            Dim fCandidateProfile As New frmCandidateProfile
            With fCandidateProfile
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .Show()
                .ClearNEnableFields(False)
                .tsbSearch.PerformClick()
            End With

        End If
    End Sub

    Private Sub SkillTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkillTypeToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmSkillType).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim fSkillType As New frmSkillType
            With fSkillType
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub

    Private Sub SourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SourcesToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmCandidateSource).Any Then
            MsgBox("Cannot create another instance of this form." + vbCrLf + "Form already loaded.", MsgBoxStyle.Exclamation, "OOOPS!")
        Else
            Dim fCSource As New frmCandidateSource
            With fCSource
                .TopLevel = False
                .MdiParent = Me
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Normal
                .Show()
            End With
        End If
    End Sub
End Class
