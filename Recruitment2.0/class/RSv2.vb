Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Management
Imports System.Net.Dns
Imports System.Net

Namespace RSv2
    Public Module Declares
        'Public HashKeyCode, SaltKeyCode As String
        Public Const HashKeyCode As String = "The quick brown fox jumps over the lazy dog."
        Public Const SaltKeyCode As String = ".god yzal eht revo spmuj xof nworb kciuq ehT"

        'Public HRMSHost, HRMSPort, HRMSDb, HRMSLoginId, HRMSPassword As String
        Public RECSHost, RECSPort, RECSDb, RECSLoginId, RECSPassword As String
        Public NETDrive, NETFDir, NETFLoginId, NETFPassword As String

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
                                    Declares.RECSHost = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultDb"
                                    Declares.RECSDb = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultPort"
                                    Declares.RECSPort = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultUser"
                                    Declares.RECSLoginId = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultPwd"
                                    Declares.RECSPassword = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultNetDrive"
                                    Declares.NETFDir = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultNetFolder"
                                    Declares.NETFDir = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultNetUser"
                                    Declares.NETFLoginId = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
                                Case "DefaultNetPwd"
                                    Declares.NETFPassword = .DecryptData(chldNodes.FirstChild.InnerText.ToString)
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
                                Case "DefaultNetDrive"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(5))
                                Case "DefaultNetFolder"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(6))
                                Case "DefaultNetUser"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(7))
                                Case "DefaultNetPwd"
                                    chldNodes.FirstChild.InnerText = .EncryptData(SysSettings(8))
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

                        If IsNothing(CommandParameters) = True Then
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

                        If IsNothing(CommandParameters) = True Then
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

                        If IsNothing(CommandParameters) = True Then
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
            End Try
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

End Namespace
