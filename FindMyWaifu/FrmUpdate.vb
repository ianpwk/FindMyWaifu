Imports System.IO, System.Net, System.Web, System.Xml, System.Runtime.InteropServices
Public Class FrmUpdate

  Delegate Sub DownloadComplateSafe(ByVal cancelled As Boolean)
  Delegate Sub UpdatesLog(ByVal cancelled As Boolean)
  Delegate Sub ChangeTextSafe(ByVal lenght As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

  Dim DataDownload As String = "https://github.com/yansaan/FindMyWaifu/releases/latest/download/FindMyWaifuPortable.zip" 'Files Update
  Dim Out As Integer
  Dim updates As Integer = 0
  Dim filedownload As String = appDataFMW & "\_data\updates\update.zip" 'Location
  Dim readXml As String = "https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21815&authkey=APPoahifAoJiGZo" 'Update Checker
  Dim Curent As String

  Dim check As Boolean = False

  Dim security As Boolean = False

  Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean

  Sub checking()
    Label3.Text = "Plase Wait..."
    ProgressBar1.Style = ProgressBarStyle.Marquee
    Button1.Enabled = False

    BackgroundWorker2.RunWorkerAsync()
  End Sub

  Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
    Dim osVer As Version = Environment.OSVersion.Version
    Try
      Dim xmlUpdate As New XmlTextReader(readXml)

      While xmlUpdate.Read()
        Dim type = xmlUpdate.NodeType
        If xmlUpdate.Name = "version" Then
          newver = xmlUpdate.ReadInnerXml.ToString()
        End If
        If xmlUpdate.Name = "description" Then
          desc = xmlUpdate.ReadInnerXml.ToString()
        End If

        If xmlUpdate.Name = "major" Then
          majorOnline = xmlUpdate.ReadInnerXml.ToString()
        ElseIf xmlUpdate.Name = "miror" Then
          mirorOnline = xmlUpdate.ReadInnerXml.ToString()
        ElseIf xmlUpdate.Name = "bulid" Then
          bulidOnline = xmlUpdate.ReadInnerXml.ToString()
        ElseIf xmlUpdate.Name = "revision" Then
          revisionOnline = xmlUpdate.ReadInnerXml.ToString()
        End If
      End While

      Dim updateComplate As New UpdatesLog(AddressOf CheckForUpdates)
      Me.Invoke(updateComplate, False)
    Catch ex As Exception
      Dim updateCancelled As New UpdatesLog(AddressOf CheckForUpdates)
      Me.Invoke(updateCancelled, True)
    End Try
  End Sub

  Public Sub CheckForUpdates(ByVal cancelled As Boolean)
    If cancelled Then
      ProgressBar1.Style = ProgressBarStyle.Blocks
      updates = 0
      Label3.Text = "Internet sedang gangguan, kilk Check Updates untuk menyambung ulang"
      Button1.Text = "Check Updates"
    Else
      ProgressBar1.Style = ProgressBarStyle.Blocks
      CheckThisUpdate()
      'Label2.Text = "Update Ver.: " + newver
    End If
  End Sub

  Sub CheckThisUpdate()
    Label2.Text = "Update Ver.: " & If(newver = "", "0", newver)
    daysUpdate()

    If majorOnline = My.Application.Info.Version.Major.ToString Then
      If bulidOnline = My.Application.Info.Version.Build.ToString Then
        If mirorOnline = My.Application.Info.Version.Minor.ToString Then
          If revisionOnline <= My.Application.Info.Version.Revision.ToString Then
            CurrentUpdate()
          Else
            thisUpdate()
          End If
        ElseIf mirorOnline < My.Application.Info.Version.Minor.ToString Then
          CurrentUpdate()
        Else
          thisUpdate()
        End If
      ElseIf bulidOnline < My.Application.Info.Version.Build.ToString Then
        CurrentUpdate()
      Else
        thisUpdate()
      End If
    ElseIf majorOnline < My.Application.Info.Version.Major.ToString Then
      CurrentUpdate()
    Else
      thisUpdate()
    End If
  End Sub

  Sub thisUpdate()
    updates = 1
    RichTextBox1.Text = desc
    Label3.Text = "Update Avaiable"
    Button1.Text = "Update now"
  End Sub

  Private Sub FrmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Label2.Text = "Update Ver.: " & If(newver = "", "0", newver)
    Label1.Text = "Curent ver.: " + ver

    If My.Settings.AutoUpdate = True Then
      daysUpdate()

      Select Case osSupport
        Case False 'When OS not Supported
          UpdateNotSupported()
        Case True
          Select Case statusUpdate
            Case 1 'When Update is Current
              CurrentUpdate()
            Case 2 'When Internet not Connect
              Label3.Text = "Internet not Connect"
              CheckThisUpdate()
            Case 3 'When Update Avaiable
              thisUpdate()
          End Select
      End Select
    Else
      checking()
    End If

    '    If InternetGetConnectedState(Out, 0) = True Then
    '  Try
    '    ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
    '  Catch ex As Exception
    '    security = True
    '  End Try
    '  Dim create As New CreateFolder()

    '  If (Not System.IO.Directory.Exists(create.appDataFMW & "\_data\updates")) Then
    '    System.IO.Directory.CreateDirectory(create.appDataFMW & "\_data\updates")
    '  End If

    '  RichTextBox1.ReadOnly = True

    '  If majorOnline = "" And bulidOnline = "" And bulidOnline = "" And revisionOnline = "" Then
    '    Label2.Text = "Update Ver.: 0"
    '    Label3.Text = "Plase Wait..."
    '    ProgressBar1.Style = ProgressBarStyle.Marquee
    '    Button1.Enabled = False

    '    BackgroundWorker2.RunWorkerAsync()
    '  Else
    '    UpdatefromUtama()
    '  End If
    'Else

    'End If
  End Sub

  Private Sub daysUpdate()
    Button1.Enabled = True
    Try
      Dim dateToday As Date = Today
      Dim dateLatest As Date = Date.Parse(dates)

      Dim dayTotal As Integer = (dateToday - dateLatest).TotalDays
      Dim titleDay As String = " Days Ago"

      Select Case dayTotal
        Case >= 7
          dayTotal = Math.Floor(dayTotal / 7)
          titleDay = " Week Ago"
          Select Case dayTotal
            Case >= 4
              dayTotal = Math.Floor(dayTotal / 4)
              titleDay = " Mouth Ago"

              Select Case dayTotal
                Case >= 12
                  Math.Floor(dayTotal / 12)
                  titleDay = " Year Ago"
              End Select
          End Select

        Case 0
          titleDay = "Today"
      End Select
      DateLbl.Text = "Latest Check:" & If(dayTotal = 0, titleDay, dayTotal.ToString & titleDay)
    Catch ex As Exception
      DateLbl.Text = ""
    End Try
  End Sub

  Private Sub CurrentUpdate()
    RichTextBox1.Text = "This is latest Version"
    Button1.Text = "Check Updates"

    updates = 0
  End Sub

  Private Sub UpdateNotSupported()
    Label3.Text = "Your OS not support for Automatic updates"
    RichTextBox1.Text = "This is latest Version"
    Button1.Text = "Check Updates"
    Button1.Enabled = False

    updates = -1
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim fileDetail = My.Computer.FileSystem.GetFileInfo(filedownload)
    If updates = 0 Then
      If InternetGetConnectedState(Out, 0) = True Then
        checking()
      Else
        MessageBox.Show("Pastikan internet anda terkoneksi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If
    ElseIf updates = 1 Then
      Try
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
      Catch ex As Exception
        If osSupport = True Then
          MsgBox("Update disabled because not install .NET 4.5", vbExclamation, "Error")
          security = True
        End If
      End Try

      If security = False Then
        If Not File.Exists(filedownload) Then
          BackgroundWorker1.RunWorkerAsync()
        Else
          If fileDetail.Length = 0 Then
            BackgroundWorker1.RunWorkerAsync()
            Button1.Text = "Cencel"
          Else
            Dim hasil As String = MessageBox.Show("File Telah terdownload. Klik yes untuk install," & ControlChars.CrLf &
                " No untuk download ulang, dan cencel untuk menutup pesan ini", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If hasil = Windows.Forms.DialogResult.Yes Then
              Installing()
            ElseIf hasil = Windows.Forms.DialogResult.No Then
              BackgroundWorker1.RunWorkerAsync()
              Button1.Text = "Cencel"
            End If
          End If
        End If
      Else
        Dim hasil As String = MessageBox.Show("Untuk bisa update langsung dari program ini, dibutuhkan Net framework 4.5" & ControlChars.CrLf &
                    "Atau anda bisa download manual via browser jika klik MO", "Info", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If hasil = Windows.Forms.DialogResult.Yes Then
          Process.Start("https://download.microsoft.com/download/E/2/1/E21644B5-2DF2-47C2-91BD-63C560427900/NDP452-KB2901907-x86-x64-AllOS-ENU.exe")
        ElseIf hasil = Windows.Forms.DialogResult.No Then
          Process.Start("https://github.com/yansaan/FindMyWaifu/releases/latest/")
        End If
      End If
    ElseIf updates = 2 Then
      BackgroundWorker1.CancelAsync()
    End If
  End Sub

  Private Sub Installing()
    Dim process As New Process()
    Try
      Button1.Enabled = False
      process.StartInfo.FileName = "UpdateMyWaifu.exe"
      process.StartInfo.Verb = "runas"
      process.StartInfo.UseShellExecute = True
      process.Start()

      FormSplash.Close()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    ' creating the request and getting the response

    Dim theResponse As HttpWebResponse
    Dim theRequest As HttpWebRequest
    If File.Exists(filedownload) Then
      File.Delete(filedownload)
    End If

    Try 'check if the file is exist

      theRequest = WebRequest.Create(DataDownload)
      theResponse = theRequest.GetResponse
      check = True
      updates = 2



    Catch ex As Exception

      MessageBox.Show("Update is error" & ControlChars.CrLf &
                      "Check your connection", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      'we will create the delegate here
      ' just wait fo a moment

      Dim cancelDelegate As New DownloadComplateSafe(AddressOf DownloadComplate)
      Me.Invoke(cancelDelegate, True)
      Exit Sub
    End Try

    Dim lenght As Long = theResponse.ContentLength 'Size of the response (in bytes)
    ' we will create the functions for update the informations
    ' just wait for a moment



    Dim safedelegate As New ChangeTextSafe(AddressOf ChangeText)
    Me.Invoke(safedelegate, lenght, 0, 0, 0)

    Dim writestream As New IO.FileStream(Me.filedownload, IO.FileMode.Create)

    'Replacement for Stream.Position (webResponse stream doesn't support seek)
    Dim nRead As Integer

    'To calculate the download speed
    Dim speedTimer As New Stopwatch
    Dim currentspeed As Double = -1
    Dim readings As Integer = 0

    Do
      If BackgroundWorker1.CancellationPending Then 'If user abort download
        Exit Do
      End If
      speedTimer.Start()
      Dim readBytes(4095) As Byte
      Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
      nRead += bytesread

      Dim percent As Short = (nRead * 100) / lenght
      Me.Invoke(safedelegate, lenght, nRead, percent, currentspeed)

      ' sorry for it, just replace the variable speed to double
      ' lets try it again

      If bytesread = 0 Then Exit Do

      writestream.Write(readBytes, 0, bytesread)
      speedTimer.Stop()

      readings += 1
      If readings >= 5 Then 'For increase precision, the speed it's calculated only every five cicles

        currentspeed = 20480 / (speedTimer.ElapsedMilliseconds / 1000)
        speedTimer.Reset()
        readings = 0
      End If

    Loop

    'Close the streams
    theResponse.GetResponseStream.Close()
    writestream.Close()

    If Me.BackgroundWorker1.CancellationPending Then
      If check = True Then
        IO.File.Delete(Me.filedownload)
        Dim canceldelegate As New DownloadComplateSafe(AddressOf DownloadComplate)
        Me.Invoke(canceldelegate, True)
        Exit Sub
      End If
    End If

    Dim complatedelegate As New DownloadComplateSafe(AddressOf DownloadComplate)
    Me.Invoke(complatedelegate, False)
  End Sub

  Public Sub DownloadComplate(ByVal cancelled As Boolean)

    If cancelled Then
      If File.Exists(filedownload) Then
        File.Delete(filedownload)
      End If
      If check = False Then
        Label3.Text = "Check Your Connection"
      Else
        Label3.Text = "Update Cancelled by user"
      End If
    Else
      check = False
      Dim hasil As String = MsgBox("Update telah terdownload" + Chr(13) + "apakah yakin mau menginstall sekarang", vbInformation + vbYesNo, "Updating")
      If hasil = vbYes Then
        Installing()
      ElseIf hasil = vbNo Then
        Label3.Text = "File update telah terdownload"
      End If
    End If

    Me.Button1.Text = "Update"
  End Sub

  Public Sub ChangeText(ByVal lenght As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

    Label3.Text = "Downloading Update " & ProgressBar1.Value & "% (" & Math.Round((position / 1024), 2) & " KB / " & Math.Round((lenght / 1024), 2) & " KB..."
    'Me.Label4.Text = "File Size: " & Math.Round((lenght / 1024), 2) & " KB"
    'Me.Label2.Text = "Downloading: " & Me.TextBox1.Text
    'Me.Label6.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB OF " & Math.Round((lenght / 1024), 2) & " KB (" & ProgressBar1.Value & " %) "

    'If speed = -1 Then

    '    Me.Label5.Text = "Speed : Calculating ..."
    'Else
    '    Me.Label5.Text = "Speed : " & Math.Round((speed / 1024), 2) & " KB/s"
    'End If

    Me.ProgressBar1.Value = percent

  End Sub

  Private Sub FrmUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    If check = True Then
      Dim result As Integer = MsgBox("Update sedang berjalan" + Chr(13) + "Yakin mau distop updatenya?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Yakin???")
      If result = DialogResult.Yes Then
        BackgroundWorker1.CancelAsync()
        e.Cancel = False
      Else
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Process.Start("https://github.com/yansaan/FindMyWaifu/releases/latest/")
  End Sub
End Class