Imports System.Data.OleDb
Imports System.Xml
Imports System.Runtime.InteropServices
Imports FindMyWaifu.ClassTheme
Imports Newtonsoft.Json, Newtonsoft.Json.Linq

Public Class MainFrm
  'Mulai
  Dim Conn As OleDbConnection
  Dim R As Integer
  Dim msg As String = ""
  Dim s As Integer
  Dim rn As New Random
  Dim LokasNomorB As String
  Dim Out As Integer
  Public RestartPaksa As Boolean = False
  Dim myupdate As Integer

  Dim NumberRnd As String = ""
  Dim Hasilnya As String = ""
  Dim newver As String = ""

  Dim majorOnline, mirorOnline, bulidOnline, revisionOnline As String

  Dim Default_Chibi, Fail_Chibi, Happy_Chibi As Image
  Dim DefaultChibi, FailChibi, HappyChibi As String
  Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean

  Public Sub CheckForUpdates()
    Try
      Dim xmlUpdate As New XmlTextReader("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21815&authkey=APPoahifAoJiGZo")

      While xmlUpdate.Read()
        Dim type = xmlUpdate.NodeType
        If xmlUpdate.Name = "version" Then
          newver = xmlUpdate.ReadInnerXml.ToString()
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

      ToolStripStatusLabel2.Text = ""

      If majorOnline = My.Application.Info.Version.Major.ToString Then
        If bulidOnline = My.Application.Info.Version.Build.ToString Then
          If mirorOnline = My.Application.Info.Version.Minor.ToString Then
            If revisionOnline <= My.Application.Info.Version.Revision.ToString Then
              myupdate = 0
            Else
              Call notifUpdate()
            End If
          ElseIf mirorOnline < My.Application.Info.Version.Minor.ToString Then
            myupdate = 0
          Else
            Call notifUpdate()
          End If
        ElseIf bulidOnline < My.Application.Info.Version.Build.ToString Then
          myupdate = 0
        Else
          Call notifUpdate()
        End If
      ElseIf majorOnline < My.Application.Info.Version.Major.ToString Then
        myupdate = 0
      Else
        Call notifUpdate()
      End If

    Catch ex As Exception
      Dim osVer As Version = Environment.OSVersion.Version

      If osVer.Major >= 6 Then
        If InternetGetConnectedState(Out, 0) = True Then
          myupdate = -2
          ToolStripStatusLabel2.ForeColor = Color.Red

          ToolStripStatusLabel2.Text = "Auto Update Error"
        End If
      Else
        myupdate = -3

        ToolStripStatusLabel2.ForeColor = Color.Red

        ToolStripStatusLabel2.Text = "Your OS Not Supported"
      End If
    End Try
  End Sub

  Sub notifUpdate()
    myupdate = 1

    ToolStripStatusLabel2.Text = "Update Avaiable"
    Dim cariupdate As Integer = MsgBox("Versi terbaru (v" & newver.ToString & ") sudah hadir" + Chr(13) + "Apakah akan mengupdatenya?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Update Avaiable")
    If cariupdate = vbYes Then
      FrmUpdate.ShowDialog()
    End If
    ToolStripStatusLabel2.ForeColor = Color.Green
    ToolStripStatusLabel2.Visible = True
    ToolStripStatusLabel2.Text = "Update Avaiable"
  End Sub

  Sub Koneksi()
    'LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
    LokasNomorB = My.Settings.waifudataConnectionString
    Conn = New OleDbConnection(LokasNomorB)
  End Sub
  Public Sub Hitung()
    Try

      Koneksi()

      'hitung
      Conn.Open()
      Dim cmd As New OleDbCommand
      cmd = Conn.CreateCommand

      cmd.CommandText = "SELECT MAX([NO]) from [NameWaifu]"
      Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
      If dr.HasRows Then
        If dr.Read Then
          s = dr.Item("Expr1000").ToString
        End If
      End If
      Conn.Close()
    Catch ex As Exception
      Timer1.Enabled = False

      msg = ex.Message.ToString()
      If msg = "The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine." Then
        Dim msg1 As String = MsgBox("Module yang dibutuhkan di program ini belum di install" + Chr(13) + "Silahkan install modulenya", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Error")
        If msg1 = DialogResult.OK Then
          StartProgram.ShowDialog()
          StartProgram.DownloadEngine()
        Else
          Chibis.Image = Fail_Chibi
          Button1.Enabled = True
        End If
      End If
    End Try
  End Sub

  Sub Hasil()
    'Label4.Text = s.ToString
    Try
      R = s + 1
      NumberRnd = rn.Next(1, R)
    Catch ex As Exception

    End Try

    'conversi
    Try
      If NumberRnd <> 0 Then
        Koneksi()
        Conn.Open()

        Dim cmd1 As New OleDbCommand
        cmd1 = Conn.CreateCommand

        cmd1.Parameters.AddWithValue("@id", NumberRnd.ToString())
        cmd1.CommandText = "SELECT * from [NameWaifu] where [No] =@id"
        Dim dr1 As OleDbDataReader = cmd1.ExecuteReader(CommandBehavior.SingleResult)

        If dr1.HasRows Then
          If dr1.Read Then
            Hasilnya = dr1("NameWaifu").ToString
          End If
          Conn.Close()
          ProgressBar1.Value = "100"
          'Label5.Text = NumberRnd.ToString
        Else
          'Label5.Text = NumberRnd.ToString
          Conn.Close()
          Hasil()
        End If
      End If
    Catch ex As Exception
      Timer1.Enabled = False
      MessageBox.Show(ex.Message)
      Chibis.Image = Fail_Chibi
    End Try
  End Sub
  'Akhir

  Private Sub MainFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    If RestartPaksa = False Then
      Dim result As Integer = MsgBox("Anda yakin mau mengclose program ini?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Yakin???")
      If result = DialogResult.Yes Then
        If My.Settings.NameRemember = False Then
          My.Settings.name = ""
        End If
        My.Settings.Save()
        If My.Settings.backup = True Then
          Dim save As New SettingsSaver()
          save.Settings()
        End If
        FormSplash.Close()
      Else
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ProgressBar1.Visible = True
    ProgressBar1.Value = "0"
    Button1.Enabled = False
    Timer1.Enabled = True
  End Sub

  Public Sub ThemeInfo()
    Dim folders As New ThemePreview()
    If My.Settings.CustomTheme = True Then
      Call folders.XsiExist()

      If folders.jsnxName = "" Then
        ToolStripStatusLabel1.Text = "Theme: " & My.Settings.Theme.Replace("Custom - ", "")
      Else
        ToolStripStatusLabel1.Text = "Theme: " & folders.jsnxName
      End If

      If folders.errors = False Then
        ToolStripStatusLabel1.ForeColor = ColorTranslator.FromHtml("#41f367")
      Else
        ToolStripStatusLabel1.ForeColor = ColorTranslator.FromHtml("#f93b3b")
      End If
    Else
      ToolStripStatusLabel1.Text = "Theme: " & My.Settings.Theme
      ToolStripStatusLabel1.ForeColor = ColorTranslator.FromHtml("#2352ff")
    End If
  End Sub

  Private Sub MainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Call ThemeInfo()
    Dim Colors As New ClassTheme()
    Colors.changetheme()

    ChibiLoad()

    Dim Names As String


    Names = My.Settings.name

    Label3.Text = "Hai " + Names + ", senang berjumpa denganmu!!"
    Label1.Text = "Waifu " + Names + " adalah?"

    If InternetGetConnectedState(Out, 0) = True Then
      If My.Settings.AutoUpdate = True Then
        ToolStripStatusLabel2.ForeColor = Color.Green
        CheckForUpdates()
      End If
    Else
      myupdate = -1
    End If

    ProgressBar1.Visible = False

    If myupdate = 0 Then
      ToolStripStatusLabel2.Text = "v" + Application.ProductVersion + " (Latest)"
      ToolStripStatusLabel2.ForeColor = Color.CornflowerBlue
    ElseIf myupdate = -1 Then
      ToolStripStatusLabel2.Text = "v" + Application.ProductVersion + " (Disconnect)"
      ToolStripStatusLabel2.ForeColor = Color.Red
    ElseIf myupdate = 1 Then
      ToolStripStatusLabel2.Text = "v" + Application.ProductVersion + " (Oldest)"
      ToolStripStatusLabel2.ForeColor = Color.LawnGreen
    Else
      ToolStripStatusLabel2.Text = "v" + Application.ProductVersion + " (Error)"
      ToolStripStatusLabel2.ForeColor = Color.Red
    End If
  End Sub

  Private Sub Chibis_Click(sender As Object, e As EventArgs) Handles Chibis.Click
    If InternetGetConnectedState(Out, 0) = True Then

    Else
      MessageBox.Show("Pastikan internet terkoneksi untuk update online", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End If
  End Sub

  Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    Me.Close()
  End Sub

  Public Sub ChibiLoad()
    Dim foldata As New CreateFolder()
    Dim folChibi As String = foldata.appDataFMW & "\chibi\"

    If My.Settings.Chibi = "Default" Then
      Default_Chibi = My.Resources.Kasumi_Toyama_Power_chibi_YfxFAe
      Fail_Chibi = My.Resources.Kasumi_Toyama_Power_chibi_NFOyKG
      Happy_Chibi = My.Resources.Kasumi_Toyama_Power_chibi_rWnUUV
    Else
      Dim CusChibi = My.Settings.Chibi.Replace("Custom - ", "")

      DefaultChibi = folChibi & CusChibi & "\set-default.png"
      Default_Chibi = Image.FromFile(DefaultChibi)

      FailChibi = folChibi & CusChibi & "\set-fail.png"
      Fail_Chibi = Image.FromFile(FailChibi)

      HappyChibi = folChibi & CusChibi & "\set-happy.png"
      Happy_Chibi = Image.FromFile(HappyChibi)
    End If

    Chibis.Image = Default_Chibi
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If ProgressBar1.Value = "0" Then
      Chibis.Image = Default_Chibi
      ProgressBar1.Value = "30"
    ElseIf ProgressBar1.Value = "30" Then
      Hitung()
      ProgressBar1.Value = "60"
    ElseIf ProgressBar1.Value = "60" Then
      Hasil()
    ElseIf ProgressBar1.Value = "100" Then
      Timer1.Enabled = False
      Label2.Text = Hasilnya.ToString()
      Chibis.Image = Happy_Chibi
      Button1.Enabled = True
      ProgressBar1.Visible = False
    End If
  End Sub

  Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
    SettingsFrm.ShowDialog()
  End Sub

  Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
    FrmAbout.ShowDialog()
  End Sub

  Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
    Dim themeName As String = ""
    Dim themeCredit As String = ""
    Dim statusTheme As String = ""
    If My.Settings.CustomTheme = True Then
      Dim FileExist As New ThemePreview

      Call FileExist.XsiExist()
      'FileExist.errors = False

      If FileExist.jsnxName = "" Then
        themeName = "Theme Name: " & My.Settings.Theme.Replace("Custom - ", "")
      Else
        themeName = "Theme Name: " & FileExist.jsnxName
      End If

      If Not FileExist.jsnxCredit = "" Then
        themeCredit = Chr(13) + "Credit by: " + FileExist.jsnxCredit
      End If

      If FileExist.errors = False Then
        statusTheme = Chr(13) + "Status: Custom, Good"
      Else
        statusTheme = Chr(13) + "Status: Custom, Error (Total:" & FileExist.errors.ToString & ")"
      End If
    Else
      themeName = "Theme Name: " & My.Settings.Theme
      themeCredit = Chr(13) + "Credit by: System"
      statusTheme = Chr(13) + "Status: Default"
    End If
    MsgBox(themeName & themeCredit & statusTheme, vbInformation + vbOKOnly, "Credit Theme")
  End Sub

  Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
    ToolStripSplitButton1.ShowDropDown()
  End Sub

  Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
    FrmUpdate.ShowDialog()
  End Sub
End Class