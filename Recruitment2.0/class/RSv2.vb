Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.Dns
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Xml

Namespace RSv2
    Public Module Declares
        'Public HashKeyCode, SaltKeyCode As String
        Public Const HashKeyCode As String = "The quick brown fox jumps over the lazy dog."
        Public Const SaltKeyCode As String = ".god yzal eht revo spmuj xof nworb kciuq ehT"

        ' DB and SMTP Server Variables
        Public DefHost, DefPort, DefDb, DefUID, DefPWD As String, DbType As DbTypes
        Public DefSMTPHost, DefSMTPPort, CredEmail, CredEmailPwd As String, useSSL As Boolean, useCredential As Boolean

        ' Data variables
        Public Qry As String, Dset As DataSet, Dtbl As DataTable, Drow As DataRow
        Public Params As ArrayList

        ' Login variables
        Public CurrentUID As Integer, CurrentUName As String, CurrentUPosition As String

        ' General Variables
        Public SelectedId As Integer = 0

        Public Enum DbTypes As Integer
            MySQL = 0
            MSSQL = 1
            ORACLE = 2 ' To support soon
        End Enum

        Public Enum RecModules As Integer
            Candidate = 0
            ManpowerRequest = 1
            LineUpRequest = 2
            ContractRequest = 3
            MRStatus = 4
            MRTypes = 5
            LRStatus = 6
            CRStatus = 7
            ClientAccounts = 8
            UserProfile = 9
        End Enum

    End Module

    Public Class Setup
        Public Shared Sub GetSystemSettings()

            Dim xmlDoc As New Xml.XmlDocument
            Dim xNode As Xml.XmlNode

            If Not IO.File.Exists(Application.StartupPath + "\Recruitment2.0.exe.config") = True Then
                Exit Sub
            End If

            Try
                xmlDoc.Load(Application.StartupPath + "\Recruitment2.0.exe.config")
                xNode = xmlDoc.SelectSingleNode("/configuration/applicationSettings/RecSys.My.MySettings")

                If xNode.HasChildNodes Then
                    Dim Crypto As New Security()
                    With Crypto
                        For Each chldNodes As Xml.XmlNode In xNode.ChildNodes

                            Select Case chldNodes.Attributes("name").Value
                                Case "DefaultHost"
                                    Declares.DefHost = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultDb"
                                    Declares.DefDb = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultPort"
                                    Declares.DefPort = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultUser"
                                    Declares.DefUID = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultPwd"
                                    Declares.DefPWD = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "SMTPHost"
                                    Declares.DefSMTPHost = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "SMTPPort"
                                    Declares.DefSMTPPort = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "SMTPSSL"
                                    Declares.useSSL = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "UseCredential"
                                    Declares.useCredential = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "CredentialEmail"
                                    Declares.CredEmail = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "CredentialPwd"
                                    Declares.CredEmailPwd = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DbType"
                                    Declares.DbType = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case Else

                            End Select
                        Next
                    End With
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try

        End Sub

        Public Shared Sub SetSystemSettings(ByVal ParamArray SysSettings() As String)
            Dim xmlDoc As New Xml.XmlDocument
            Dim xNode As Xml.XmlNode

            If Not IO.File.Exists(Application.StartupPath + "\Recruitment.exe.config") = True Then
                Exit Sub
            End If

            Try
                xmlDoc.Load(Application.StartupPath + "\Recruitment2.0.exe.config")

                xNode = xmlDoc.SelectSingleNode("/configuration/applicationSettings/RecSys.My.MySettings")

                If xNode.HasChildNodes Then
                    Dim Crypto As New Security()
                    With Crypto
                        For Each chldNodes As Xml.XmlNode In xNode.ChildNodes
                            Select Case chldNodes.Attributes("name").Value
                                Case "DefaultHost"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(0))
                                Case "DefaultDb"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(1))
                                Case "DefaultPort"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(2))
                                Case "DefaultUser"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(3))
                                Case "DefaultPwd"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(4))
                                Case "DefSMTPHost"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(5))
                                Case "SMTPPort"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(6))
                                Case "SMTPSSL"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(7))
                                Case "UseCredential"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(8))
                                Case "CredentialEmail"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(9))
                                Case "CredentialPwd"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(10))
                                Case "DbType"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(11))
                                Case Else
                                    ' Unhandled condition
                            End Select
                        Next
                    End With

                End If
                xmlDoc.Save(Application.StartupPath + "\Recruitment.exe.config")
                MsgBox("Settings has been saved.", MsgBoxStyle.Information, "Success")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try

        End Sub

        Public Shared Sub RegisterMachine()
            Dim HD_Serial As String = ""
            Dim MB_Serial As String = ""
            Dim MacName As String = GetHostName().ToString
            Dim MacIps As IPHostEntry = GetHostEntry(MacName)
            Dim MacIp As String = ""

            For Each Ips As IPAddress In MacIps.AddressList
                If Ips.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                    MacIp = Ips.ToString
                    Exit For
                End If
            Next

            Using HDScan As New ManagementObjectSearcher("Select * From Win32_DiskDrive Where DeviceId='\\\\.\\PHYSICALDRIVE0'")
                For Each HD In HDScan.Get
                    HD_Serial = HD("SerialNumber").ToString.Trim
                Next
            End Using

            Using MBScan As New ManagementObjectSearcher("Select * From Win32_BaseBoard")
                For Each MB In MBScan.Get
                    MB_Serial = MB("SerialNumber").ToString.Trim
                Next
            End Using

            Dim Crypto As New Security()
            MsgBox("Hash Key 1: " + MacIp + " " + Crypto.EncryptData(MacIp) + vbCrLf + _
                   "Hash Key 2: " + MacName + " " + Crypto.EncryptData(MacName) + vbCrLf + _
                   "Hash Key 3: " + HD_Serial + " " + Crypto.EncryptData(HD_Serial) + vbCrLf + _
                   "Hash Key 4: " + MB_Serial + " " + Crypto.EncryptData(MB_Serial), MsgBoxStyle.Information, "Hash Keys")
        End Sub

    End Class

    Public Class DataConnection
        Public Shared Function Open(ByVal ConnectionString As String) As MySqlConnection
            Dim tmpCn As New MySqlConnection(ConnectionString)
            Try
                tmpCn.Open()
                Return tmpCn
            Catch ex As Exception
                Return Nothing
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
            End Try
        End Function

        Public Shared Function Open(ByVal ServerHost As String, ByVal DefaultDatabase As String, ByVal UserId As String, ByVal Password As String, Optional ByVal DefaultPort As String = "3306") As MySqlConnection
            Dim CnString As String = "Server=[1];Port=[2];Database=[3];Uid=[4];Pwd=[5];"
            Dim tmpCn As MySqlConnection
            Try
                CnString = CnString.Replace("[1]", ServerHost).Replace("[2]", DefaultPort).Replace("[3]", DefaultDatabase).Replace("[4]", UserId).Replace("[5]", Password)
                tmpCn = New MySqlConnection(CnString)
                tmpCn.Open()
                Return tmpCn
            Catch ex As Exception
                Return Nothing
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
            End Try
        End Function

        Public Shared Function Query(ByVal CommandString As String, DefaultConnection As MySqlConnection, Optional ByVal CommandParameters As ArrayList = Nothing, Optional ByVal SQLCommandType As CommandType = CommandType.Text) As DataSet
            Dim tmpDS As New DataSet
            Try
                Using DefaultCm As New MySqlCommand()
                    With DefaultCm
                        .CommandType = SQLCommandType
                        .CommandText = CommandString
                        .Connection = DefaultConnection

                        If Not IsNothing(CommandParameters) Then
                            For Each SqlParam As MySqlParameter In CommandParameters
                                .Parameters.Add(SqlParam)
                            Next
                        End If
                    End With
                    Using myDa As New MySqlDataAdapter(DefaultCm)
                        myDa.Fill(tmpDS)
                    End Using
                End Using
                Return tmpDS
            Catch ex As Exception

                MsgBox("Please contact application vendor and report this error." + vbCrLf + _
                        ex.HResult.ToString + ":" + ex.Message, MsgBoxStyle.Critical, "System Error!")
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
                Return Nothing
            End Try
        End Function

        Public Shared Function QueryExec(ByVal CommandString As String, DefaultConnection As MySqlConnection, Optional ByVal CommandParameters As ArrayList = Nothing, Optional ByVal SQLCommandType As CommandType = CommandType.Text) As Object
            Try
                Using DefaultCm As New MySqlCommand()
                    With DefaultCm
                        .CommandType = SQLCommandType
                        .CommandText = CommandString
                        .Connection = DefaultConnection

                        If CommandParameters.Count > 0 Or Not IsNothing(CommandParameters) Then
                            For Each SqlParam As MySqlParameter In CommandParameters
                                .Parameters.Add(SqlParam)
                            Next
                        End If
                        Return .ExecuteScalar()
                    End With
                End Using
            Catch ex As Exception
                MsgBox("Please contact application vendor and report this error." + vbCrLf + _
                        ex.HResult.ToString + ":" + ex.Message, MsgBoxStyle.Critical, "System Error!")
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
                Return Nothing
            End Try
        End Function

        Public Shared Sub FillComboBox(ByVal CommandString As String, DefaultConnection As MySqlConnection, _
                                       ByVal DefaultDisplayMember As String, ByVal DefaultValueMember As String, ByRef DefaultComboBox As ComboBox, _
                                       Optional ByVal CommandParameters As ArrayList = Nothing, Optional ByVal SQLCommandType As CommandType = CommandType.Text)
            Try
                Using DefaultCm As New MySqlCommand()
                    With DefaultCm
                        .CommandType = SQLCommandType
                        .CommandText = CommandString
                        .Connection = DefaultConnection

                        If IsNothing(CommandParameters) = False Then
                            For Each SqlParam As MySqlParameter In CommandParameters
                                .Parameters.Add(SqlParam)
                            Next
                        End If
                        Using MyDa As New MySqlDataAdapter(DefaultCm)
                            Dim MyDt As New DataTable
                            MyDa.Fill(MyDt)
                            With DefaultComboBox
                                .ValueMember = DefaultValueMember
                                .DisplayMember = DefaultDisplayMember
                                .DataSource = MyDt
                            End With
                        End Using
                    End With
                End Using
            Catch ex As Exception
                MsgBox("Please contact application vendor and report this error." + vbCrLf + _
                        ex.HResult.ToString + ":" + ex.Message, MsgBoxStyle.Critical, "System Error!")
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
            End Try
        End Sub

        Public Shared Sub FillListBox(ByVal CommandString As String, DefaultConnection As MySqlConnection, _
                               ByVal DefaultDisplayMember As String, ByVal DefaultValueMember As String, ByRef DefaultListBox As ListBox, _
                               Optional ByVal CommandParameters As ArrayList = Nothing, Optional ByVal SQLCommandType As CommandType = CommandType.Text)
            Try
                Using DefaultCm As New MySqlCommand()
                    With DefaultCm
                        .CommandType = SQLCommandType
                        .CommandText = CommandString
                        .Connection = DefaultConnection

                        If IsNothing(CommandParameters) = True Then
                            For Each SqlParam As MySqlParameter In CommandParameters
                                .Parameters.Add(SqlParam)
                            Next
                        End If
                        Using MyDa As New MySqlDataAdapter(DefaultCm)
                            Dim MyDt As New DataTable
                            MyDa.Fill(MyDt)
                            With DefaultListBox
                                .ValueMember = DefaultValueMember
                                .DisplayMember = DefaultDisplayMember
                                .DataSource = MyDt
                            End With
                        End Using
                    End With
                End Using
            Catch ex As Exception
                MsgBox("Please contact application vendor and report this error." + vbCrLf + _
                        ex.HResult.ToString + ":" + ex.Message, MsgBoxStyle.Critical, "System Error!")
                Call LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
            End Try
        End Sub

        Public Shared Sub LogActivity(ByVal LogType As Integer, LogActivity As String, CurrentUID As Integer)
            Using Cn As MySqlConnection = Open(DefHost, DefDb, DefUID, DefPWD, DefPort)
                Params = New ArrayList
                Params.Add(New MySqlParameter("@ltype", LogType))
                Params.Add(New MySqlParameter("@lactivity", LogActivity))
                Params.Add(New MySqlParameter("@usedid", CurrentUID))

                QueryExec("log_activity", Cn, Params, CommandType.StoredProcedure)
            End Using
        End Sub
    End Class

    Public NotInheritable Class Security

        '  1. Create the Simple3Des class to encapsulate the encryption and decryption methods.
        '  2. Add an import of the cryptography namespace to the start of the file that contains the Simple3Des class.
        '  3. In the Simple3Des class, add a private field to store the 3DES cryptographic service provider. 
        '  4. Add a private method that creates a byte array of a specified length from the hash of the specified key.
        '  5. Add a constructor to initialize the 3DES cryptographic service provider.
        '       The key parameter controls the EncryptData and DecryptData methods.
        '  6. Add a public method that encrypts a string.
        '  7. Add a public method that decrypts a string. 

        Private TripleDES As New TripleDESCryptoServiceProvider

        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()

            Dim SHA1 As New SHA1CryptoServiceProvider

            ' Hash the key. 
            Dim KeyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
            Dim Hash() As Byte = SHA1.ComputeHash(KeyBytes)

            ' Truncate or pad the hash. 
            ReDim Preserve Hash(length - 1)
            Return Hash

        End Function

        Sub New()
            ' Initialize the crypto provider.
            TripleDES.Key = TruncateHash(Declares.HashKeyCode, TripleDES.KeySize \ 8)
            TripleDES.IV = TruncateHash(Declares.SaltKeyCode, TripleDES.BlockSize \ 8)
        End Sub

        Public Function EncryptData(ByVal plaintext As String) As String

            ' Convert the plaintext string to a byte array. 
            Dim plaintextBytes() As Byte =
                System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream. 
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream. 
            Dim encStream As New CryptoStream(ms,
                TripleDES.CreateEncryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string. 
            Return Convert.ToBase64String(ms.ToArray)
        End Function

        Public Function DecryptData(ByVal encryptedtext As String) As String

            ' Convert the encrypted text string to a byte array. 
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

            ' Create the stream. 
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream. 
            Dim decStream As New CryptoStream(ms,
                TripleDES.CreateDecryptor(),
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()

            ' Convert the plaintext stream to a string. 
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function

    End Class

    Public Class Mailer
        Public Shared Function SendEmail(ByVal MailSender As String, ByVal MailReceipients As String, ByVal MailSubject As String, _
                                  ByVal MailMessage As String, Optional ByVal IsBodyHtml As Boolean = False, Optional ByVal MailAttachments As ArrayList = Nothing) As Boolean

            Try
                Using SMTPMail As New SmtpClient
                    Using NewMail As New MailMessage
                        With SMTPMail
                            .EnableSsl = Declares.useSSL
                            .UseDefaultCredentials = Declares.useCredential
                            .Credentials = New Net.NetworkCredential(Declares.CredEmail, Declares.CredEmailPwd)
                            .Port = Declares.DefSMTPPort
                            .Host = Declares.DefSMTPHost

                            With NewMail
                                .From = New MailAddress(MailSender)
                                .To.Add(MailReceipients)
                                .Subject = MailSubject
                                .IsBodyHtml = IsBodyHtml
                                .Body = MailMessage
                            End With

                            .Send(NewMail)
                            Console.Write("Mail Sent")
                            Return True
                        End With
                    End Using
                End Using

            Catch ex As Exception
                MsgBox("Please contact application vendor and report this error." + vbCrLf + _
                        ex.HResult.ToString + ":" + ex.Message, MsgBoxStyle.Critical, "System Error!")
                Call DataConnection.LogActivity(0, "Error occurred : " + ex.Message, CurrentUID)
                Return False
            End Try
        End Function

    End Class

    Public Class AppForm
        Public Shared Sub FormatGridColumn(ByVal DGObject As DataGridView, ByVal ColumnId As Integer, ByVal HeaderText As String, Optional IsFrozen As Boolean = False, _
                             Optional ByVal IsVisible As Boolean = True, Optional ByVal IsReadOnly As Boolean = False, Optional ByVal ColumnWidth As Double = 100, _
                             Optional ByVal ContentAlignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft, _
                             Optional ByVal HeaderAlignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft)
            With DGObject
                .Columns(ColumnId).Frozen = IsFrozen
                .Columns(ColumnId).Visible = IsVisible
                .Columns(ColumnId).Width = ColumnWidth
                .Columns(ColumnId).HeaderText = HeaderText
                .Columns(ColumnId).DefaultCellStyle.Alignment = ContentAlignment
                .Columns(ColumnId).HeaderCell.Style.Alignment = HeaderAlignment
            End With
        End Sub
    End Class

    Public Class RegExUtilities
        Shared IsValid As Boolean = False

        Public Shared Function IsValidEmail(strIn As String) As Boolean
            IsValid = False
            If String.IsNullOrEmpty(strIn) Then Return False

            ' Use IdnMapping class to convert Unicode domain names.
            Try
                strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200))
            Catch e As RegexMatchTimeoutException
                Return False
            End Try

            If IsValid Then Return False

            ' Return true if strIn is in valid e-mail format.
            Try
                Return Regex.IsMatch(strIn,
                       "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                       "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                       RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
            Catch e As RegexMatchTimeoutException
                Return False
            End Try
        End Function

        Public Shared Function DomainMapper(match As Match) As String
            ' IdnMapping class with default property values.
            Dim idn As New IdnMapping()

            Dim domainName As String = match.Groups(2).Value
            Try
                domainName = idn.GetAscii(domainName)
            Catch e As ArgumentException
                IsValid = True
            End Try
            Return match.Groups(1).Value + domainName
        End Function

    End Class
End Namespace
