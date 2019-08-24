Imports System.IO, System.Net, System.Web, System.Xml
Public Class FrmUpdate

    Dim DataFile As WebClient
    Dim DataDownload As String = ""
    Dim msg As String = ""

    Public Sub DownloadEngine()
        DataFile = New WebClient()

        DataDownload = "https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21814&authkey=AAJyWlZeNEowBXE"

        Try
            AddHandler DataFile.DownloadProgressChanged, AddressOf ProgChanged
            DataFile.DownloadFileAsync(New Uri(DataDownload), "_data/FindMyWaifu.exe")
        Catch ex As Exception
            Label3.Text = "Check Your Connection"
        End Try
    End Sub

    Private Sub ProgChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
        MainFrm.ToolStripProgressBar1.Value = e.ProgressPercentage
        Label3.Text = "Downloading Update.. (" + e.ProgressPercentage.ToString() + "%)"

        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = True
        End If
    End Sub

    Public Sub CheckForUpdates()
        Try
            Dim ver As String = ""
            Dim xmlUpdate As New XmlTextReader("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21815&authkey=APPoahifAoJiGZo")
            Dim newver As String = ""
            Dim desc As String = ""

            While xmlUpdate.Read()
                Dim type = xmlUpdate.NodeType
                If xmlUpdate.Name = "version" Then
                    newver = xmlUpdate.ReadInnerXml.ToString()
                End If
                If xmlUpdate.Name = "description" Then
                    desc = xmlUpdate.ReadInnerXml.ToString()
                End If
            End While

            Label2.Text = "Update Ver.: " + newver
            Dim lastver As String = Application.ProductVersion

            If newver.ToString < lastver.ToString Then
                RichTextBox1.Text = desc
                Label3.Text = ""
            Else
                Label3.Text = "Sudah Terupdate"
                RichTextBox1.Text = "Versi anda sudah yang terbaru"
                Button1.Enabled = False
            End If
        Catch ex As Exception
            Label3.Text = ""
            RichTextBox1.Text = "Internet belum terkoneksi, kilk Retry untuk menyambung ulang"
            Button1.Text = "Retry"
        End Try
    End Sub

    Private Sub FrmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim create As New CreateFolder()
        If (Not System.IO.Directory.Exists(create.appDataFMW & "\_data")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\_data")
        End If

        IO.File.SetAttributes(create.appDataFMW & "\_data", IO.FileAttributes.Hidden Or
                                  IO.FileAttributes.System)

        RichTextBox1.ReadOnly = True
        RichTextBox1.BackColor = ColorTranslator.FromHtml("#f3f3f3")
        Label1.Text = "Curent ver.: " + Application.ProductVersion
        CheckForUpdates()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Update" Then
            DownloadEngine()
        ElseIf Button1.Text = "Retry" Then
            CheckForUpdates()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim process As New Process()
        process.StartInfo.FileName = "UpdateMyWaifu.exe"
        process.StartInfo.Verb = "runas"
        process.StartInfo.UseShellExecute = True
        process.Start()

        Form1.Close()
    End Sub
End Class