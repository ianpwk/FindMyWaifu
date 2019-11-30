Imports System.Net
Public Class StartProgram

  Dim DataFile As WebClient
  Dim DataDownload As String = ""
  Dim msg As String = ""

  Dim closings As Boolean = False

  Public Sub DownloadEngine()
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
      Me.Close()
    End Try
  End Sub

  Private Sub ProgChanged(sender As Object, e As DownloadProgressChangedEventArgs)
    ProgressBar1.Value = e.ProgressPercentage
    Label1.Text = "Mendownload Plugin.. (" + e.ProgressPercentage.ToString() + "%)"
    Label2.Text = String.Format("Terdownload {0} MB dari {1} MB", (e.BytesReceived / 1024D / 1024D).ToString("0.00"), (e.TotalBytesToReceive / 1024D / 1024D).ToString("0.00"))

    If ProgressBar1.Value = 100 Then
      Timer1.Enabled = True
    End If
  End Sub

  Private Sub StartProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    DownloadEngine()
    Label1.Text = "Starting Download..."
    Label2.Text = ""
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    Process.Start("AccessEngine.exe")
    Timer1.Enabled = False
    MainFrm.Button1.Enabled = True
    closings = True
    Me.Close()
  End Sub

  Private Sub StartProgram_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    If closings = False Then
      Dim result As Integer = MsgBox("Anda yakin mau stop progges ini?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Yakin???")
      If result = DialogResult.Yes Then
        e.Cancel = False
        DataFile.CancelAsync()
        closings = True
        MainFrm.Button1.Enabled = True
        Me.Close()
      Else
        e.Cancel = True
      End If
    End If
  End Sub
End Class