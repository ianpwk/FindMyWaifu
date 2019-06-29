Imports System.Data.OleDb
Imports System.Net
Public Class StartProgram

    Dim Conn As OleDbConnection
    Dim LokasNomorB As String
    Dim DataFile As WebClient
    Dim DataDownload As String = ""
    Dim msg As String = ""


    Sub DownloadEngine()
        DataFile = New WebClient()

        If Environment.Is64BitOperatingSystem Then
            DataDownload = "https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21814&authkey=AAJyWlZeNEowBXE"
        Else
            DataDownload = "https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21813&authkey=AMkKJyg4WDzIOZ8"
        End If

        Try
            AddHandler DataFile.DownloadProgressChanged, AddressOf ProgChanged
            DataFile.DownloadFileAsync(New Uri(DataDownload), "AccessEngine.exe")
        Catch ex2 As Exception
            MsgBox("Please check your internet", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Form1.Close()
        End Try
    End Sub

    Sub Koneksi()

        Try
            Timer1.Enabled = False
            LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
            Conn = New OleDbConnection(LokasNomorB)
            Conn.Open()
            Conn.Close()
            Timer1.Enabled = True
        Catch ex As Exception
            msg = ex.Message.ToString()
            Timer1.Enabled = False
            If msg = "Microsoft.ACE.OLEDB.12.0′ provNomorer Is Not registered on the local machine" Then
                Dim msg1 As String = MsgBox("Module yang dibutuhkan di program ini belum di install" + Chr(13) + "Silahkan install modulenya", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Error")
                If msg1 = DialogResult.OK Then
                    DownloadEngine()
                Else
                    Form1.Close()
                End If
            End If
        End Try
    End Sub

    Private Sub ProgChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Text = "Mendownload Module.. (" + e.ProgressPercentage.ToString() + "%)"
        Label2.Text = String.Format("Terdownload {0} MB dari {1} MB", (e.BytesReceived / 1024D / 1024D).ToString("0.00"), (e.TotalBytesToReceive / 1024D / 1024D).ToString("0.00"))

        If ProgressBar1.Value = 100 Then
            Process.Start("AccessEngine.exe")
            MainFrm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub StartProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label2.Text = ""
        Label1.Text = "Menyiapkan..."
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 1
        End If

        If ProgressBar1.Value = 50 Then
            Label1.Text = "Mendeteksi module..."
            Koneksi()
        ElseIf ProgressBar1.Value = 80 Then
            Label1.Text = "menyelesaikan wizard..."
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            MainFrm.Show()
            My.Settings.StartProgram = False
            Me.Hide()
        End If
    End Sub

    Private Sub StartProgram_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Close()
    End Sub
End Class