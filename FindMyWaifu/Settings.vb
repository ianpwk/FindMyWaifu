Imports System.IO, System.Net, System.Web, Newtonsoft.Json, Newtonsoft.Json.Linq

Public Class SettingsFrm

  Dim dirTheme As String = appDataFMW & "\theme"
  Dim dirChibi As String = appDataFMW & "\chibi"

  Dim xsiColor As JObject
  Dim CusTheme As String
  Dim CusChibi As String

  Dim Set_happy, Set_fail, Set_Default As Image
  Dim Sets_happy, Sets_fail, Sets_Default As String
  Dim TB, TBT, FR, FRT, ST, STT As String
  Dim saveenabled As Integer
  Dim errortheme, errorchibi As Boolean


  Public Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
    My.Settings.Theme = ComboTheme.Text
    If My.Settings.Theme = "Default" Or My.Settings.Theme = "Dark" Or My.Settings.Theme = "Light" Then
      My.Settings.CustomTheme = False
    Else
      My.Settings.CustomTheme = True
    End If

    My.Settings.Chibi = ComboChibi.Text
    If My.Settings.Chibi = "Default" Then
      My.Settings.CustomChibi = False
    Else
      My.Settings.CustomChibi = True
    End If

    If backupCheck.Checked = True Then
      My.Settings.backup = True
    Else
      My.Settings.backup = False
    End If

    If loadCheck.Checked = True Then
      My.Settings.load = True
    Else
      My.Settings.load = False
    End If

    If My.Settings.backup = True Then
      Dim theme As New ClassTheme()
      theme.changetheme()
    End If

    If CheckUpdate.Checked = True Then
      My.Settings.AutoUpdate = True
    Else
      My.Settings.AutoUpdate = False
    End If
    My.Settings.Save()

    Dim save As New SettingsSaver()
    Call save.Settings()
    Call MainFrm.ThemeInfo()
    Call MainFrm.ChibiLoad()

    BtnSave.Enabled = False
    BtnSaveExit.Enabled = False
  End Sub

  Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Label6.Text = ""
    LblName.Text = NameModule
    RadioButton2.Enabled = False
    saveenabled = 0
    errortheme = False
    errorchibi = False

    If (Not System.IO.Directory.Exists(appDataFMW & "\theme")) Then
      System.IO.Directory.CreateDirectory(appDataFMW & "\theme")
    End If

    If (Not System.IO.Directory.Exists(appDataFMW & "\chibi")) Then
      System.IO.Directory.CreateDirectory(appDataFMW & "\chibi")
    End If

    ComboTheme.DisplayMember = "Text"

    ComboTheme.Items.Add("Default")
    ComboTheme.Items.Add("Light")
    ComboTheme.Items.Add("Dark")

    Try
      For Each files As String In System.IO.Directory.GetFiles(dirTheme, "*.jsnx")
        ComboTheme.Items.Add("Custom - " + System.IO.Path.GetFileNameWithoutExtension(files))
      Next
    Catch ex As Exception

    End Try

    ComboChibi.DisplayMember = "Text"

    ComboChibi.Items.Add("Default")
    Try
      For Each chibi As String In System.IO.Directory.GetDirectories(dirChibi)
        Dim dirInfo As New System.IO.DirectoryInfo(chibi)
        ComboChibi.Items.Add("Custom - " & dirInfo.Name)
      Next
    Catch ex As Exception

    End Try

    ComboTheme.SelectedItem = My.Settings.Theme

    ComboChibi.SelectedItem = My.Settings.Chibi

    If My.Settings.AutoUpdate = True Then
      CheckUpdate.Checked = True
    End If

    If My.Settings.NameRemember = False Then
      Button7.Enabled = False
    End If

    Dim osVer As Version = Environment.OSVersion.Version

    If Not osVer.Major >= 6 Then
      CheckUpdate.Checked = False
    End If

    If hap_chibi.Checked = True Or fai_chibi.Checked = True Then
      hap_chibi.Checked = False
      fai_chibi.Checked = False
    End If
    def_chibi.Checked = True
    chbiPreview.Image = Set_Default

    If My.Settings.load = True Then
      loadCheck.Checked = True
    End If

    If My.Settings.backup = True Then
      backupCheck.Checked = True
    End If

    BtnSave.Enabled = False
    BtnSaveExit.Enabled = False
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    bukaUpdate()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnSaveExit.Click
    BtnSave_Click(sender, e)
    Me.Close()
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    Dim resetnama As Integer = MsgBox("Jika klik Yes, anda harus memasukan nama saat muat ulang" + Chr(13) + "Jika klik No, maka akan membatalkan progess ini", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Anda Yakin?")
    If resetnama = vbYes Then
      My.Settings.NameRemember = False
      'My.Settings.name = ""
      Button7.Enabled = False
    End If
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs)
    MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
  End Sub

  Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    ComboTheme.Items.Clear()
    ComboChibi.Items.Clear()
  End Sub

  Private Sub hap_chibi_CheckedChanged(sender As Object, e As EventArgs) Handles hap_chibi.CheckedChanged
    If def_chibi.Checked = True Or fai_chibi.Checked = True Then
      def_chibi.Checked = False
      fai_chibi.Checked = False
      hap_chibi.Checked = True
    End If

    chbiPreview.Image = Set_happy
  End Sub

  Private Sub def_chibi_CheckedChanged(sender As Object, e As EventArgs) Handles def_chibi.CheckedChanged
    If hap_chibi.Checked = True Or fai_chibi.Checked = True Then
      hap_chibi.Checked = False
      fai_chibi.Checked = False
      def_chibi.Checked = True
    End If

    chbiPreview.Image = Set_Default
  End Sub

  Private Sub backupCheck_CheckedChanged(sender As Object, e As EventArgs) Handles backupCheck.CheckedChanged
    saved()
  End Sub

  Private Sub loadCheck_CheckedChanged(sender As Object, e As EventArgs) Handles loadCheck.CheckedChanged
    saved()
  End Sub

  Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    EditDatabase.ShowDialog()
  End Sub


  Private Sub fai_chibi_CheckedChanged(sender As Object, e As EventArgs) Handles fai_chibi.CheckedChanged
    If def_chibi.Checked = True Or hap_chibi.Checked = True Then
      def_chibi.Checked = False
      hap_chibi.Checked = False
      fai_chibi.Checked = True
    End If

    chbiPreview.Image = Set_fail
  End Sub

  Sub saved()
    If saveenabled < 0 Then
      BtnSave.Enabled = False
      BtnSaveExit.Enabled = False
      Label6.Text = "Tidak dapat disimpan karena kesalahan"
      Label6.ForeColor = Color.Red
    Else
      BtnSave.Enabled = True
      BtnSaveExit.Enabled = True
      Label6.Text = "Semua baik baik saja"
      Label6.ForeColor = Color.Green
    End If
  End Sub

  Private Sub ComboTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTheme.SelectedIndexChanged
    If errorchibi = True Then
      If saveenabled < -1 Then
        saveenabled += 1
      End If
    Else
      If saveenabled < 0 Then
        saveenabled += 1
      End If
    End If

    If Not (ComboTheme.SelectedItem = "Default" Or ComboTheme.SelectedItem = "Light" Or ComboTheme.SelectedItem = "Dark") Then
      CusTheme = ComboTheme.SelectedItem.ToString.Replace("Custom - ", "")
    End If

    Dim Colors As New ClassTheme()
    Colors.previewtheme()
    If (ComboTheme.SelectedItem = "Default" Or ComboTheme.SelectedItem = "Light" Or ComboTheme.SelectedItem = "Dark") Then
      ToolStrip1.BackColor = Colors.ToolbarColor
      ToolStrip1.ForeColor = Colors.ToolbarText
      ToolStripButton1.Image = Colors.toolbarConIcon

      GroupBox2.BackColor = Colors.BackgroundColor
      GroupBox2.ForeColor = Colors.MainColor

      StatusStrip1.BackColor = Colors.StatusColor
      StatusStrip1.ForeColor = Colors.StatusText

      errortheme = False
      saved()
    Else

      Dim ReadJson As String = System.IO.File.ReadAllText(dirTheme & "\" & CusTheme & ".jsnx")
      Dim JsonObject As JObject = JObject.Parse(ReadJson.ToString)

      xsiColor = JObject.Parse(JsonObject.SelectToken("color").ToString)
      Try
        errortheme = False
        TB = xsiColor.SelectToken("toolbar").ToString
        FR = xsiColor.SelectToken("form").ToString
        ST = xsiColor.SelectToken("status").ToString
        saved()
      Catch ex As Exception
        If errorchibi = True Then
          If saveenabled >= -2 Then
            saveenabled -= 1
          End If
        Else
          If saveenabled >= -1 Then
            saveenabled -= 1
          End If
        End If
        errortheme = True
        saved()
        TB = "FFF"
        FR = "FFF"
        ST = "FFF"
      End Try

      Try
        TBT = xsiColor.SelectToken("toolbartext").ToString
        FRT = xsiColor.SelectToken("formtext").ToString
        STT = xsiColor.SelectToken("statustext").ToString
      Catch ex As Exception

      End Try


      If FRT = "" Then
        Dim Red = Val("&H" & Mid(FR, 1, 2))
        Dim Green = Val("&H" & Mid(FR, 3, 2))
        Dim Blue = Val("&H" & Mid(FR, 5, 2))

        Dim IsDark As Boolean = (Red <= 128) Or
                            (Green <= 128) Or
                            (Blue <= 128) Or
                            (FR = "000")

        If IsDark Then
          FRT = "FFFFFF"
        Else
          FRT = "000"
        End If
      End If

      If TBT = "" Then
        Dim Red = Val("&H" & Mid(TB, 1, 2))
        Dim Green = Val("&H" & Mid(TB, 3, 2))
        Dim Blue = Val("&H" & Mid(TB, 5, 2))

        Dim IsDark As Boolean = (Red <= 128) Or
                            (Green <= 128) Or
                            (Blue <= 128) Or
                            (TB = "000")

        If IsDark Then
          TBT = "FFFFFF"
          ToolStripButton1.Image = Colors.toolbarConWhite
        Else
          TBT = "000"
          ToolStripButton1.Image = Colors.toolbarConBlack
        End If
      End If

      If STT = "" Then
        Dim Red = Val("&H" & Mid(ST, 1, 2))
        Dim Green = Val("&H" & Mid(ST, 3, 2))
        Dim Blue = Val("&H" & Mid(ST, 5, 2))

        Dim IsDark As Boolean = (Red <= 128) Or
                            (Green <= 128) Or
                            (Blue <= 128) Or
                            (ST = "000")

        If IsDark Then
          STT = "FFFFFF"
        Else
          STT = "000"
        End If
      End If

      ToolStrip1.BackColor = ColorTranslator.FromHtml("#" + TB)
      ToolStrip1.ForeColor = ColorTranslator.FromHtml("#" + TBT)

      GroupBox2.BackColor = ColorTranslator.FromHtml("#" + FR)
      GroupBox2.ForeColor = ColorTranslator.FromHtml("#" + FRT)

      StatusStrip1.BackColor = ColorTranslator.FromHtml("#" + ST)
      StatusStrip1.ForeColor = ColorTranslator.FromHtml("#" + STT)
    End If

  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckUpdate.CheckedChanged
    Dim osVer As Version = Environment.OSVersion.Version
    If CheckUpdate.Checked = True Then
      If Not osVer.Major >= 6 Then
        MsgBox("Auto Update belum support untuk OS ini", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
        CheckUpdate.Checked = False
      End If
    End If
    If osVer.Major >= 6 Then
      saved()
    End If
  End Sub

  Private Sub OpenFThemeBtn_Click(sender As Object, e As EventArgs) Handles OpenFThemeBtn.Click
    Process.Start(appDataFMW & "\theme")
  End Sub

  Private Sub ChibiSearchFol_Click(sender As Object, e As EventArgs) Handles ChibiSearchFol.Click
    Process.Start(appDataFMW & "\chibi")
  End Sub

  Private Sub ComboChibi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChibi.SelectedIndexChanged

    If Not (ComboChibi.SelectedItem = "Default") Then
      CusChibi = ComboChibi.SelectedItem.ToString.Replace("Custom - ", "")
    End If

    Dim folChibi As String = appDataFMW & "\chibi\"

    If ComboChibi.SelectedItem = "Default" Then
      Set_Default = My.Resources.Kasumi_Toyama_Power_chibi_YfxFAe
      Set_fail = My.Resources.Kasumi_Toyama_Power_chibi_NFOyKG
      Set_happy = My.Resources.Kasumi_Toyama_Power_chibi_rWnUUV

      errorchibi = False
      If errortheme = True Then
        If saveenabled < -1 Then
          saveenabled += 1
        End If
      Else
        If saveenabled < 0 Then
          saveenabled += 1
        End If
      End If
    Else
      Sets_Default = folChibi & CusChibi & "\set-default.png"
      Sets_fail = folChibi & CusChibi & "\set-fail.png"
      Sets_happy = folChibi & CusChibi & "\set-happy.png"

      If File.Exists(Sets_Default) Then
        Set_Default = Image.FromFile(Sets_Default)
      Else
        Set_Default = My.Resources.chibi_none
      End If

      If File.Exists(Sets_fail) Then
        Set_fail = Image.FromFile(Sets_fail)
      Else
        Set_fail = My.Resources.chibi_none
      End If

      If File.Exists(Sets_happy) Then
        Set_happy = Image.FromFile(Sets_happy)
      Else
        Set_happy = My.Resources.chibi_none
      End If

      If (File.Exists(Sets_Default) And File.Exists(Sets_fail) And File.Exists(Sets_happy)) Then
        errorchibi = False
        If errortheme = True Then
          If saveenabled < -1 Then
            saveenabled += 1
          End If
        Else
          If saveenabled < 0 Then
            saveenabled += 1
          End If
        End If
      Else
        errorchibi = True
        If errortheme = True Then
          If saveenabled >= -2 Then
            saveenabled -= 1
          End If
        Else
          If saveenabled >= -1 Then
            saveenabled -= 1
          End If
        End If
      End If
    End If

    saved()
    If def_chibi.Checked = True Then
      chbiPreview.Image = Set_Default
    ElseIf hap_chibi.Checked = True Then
      chbiPreview.Image = Set_happy
    ElseIf fai_chibi.Checked = True Then
      chbiPreview.Image = Set_fail
    End If
  End Sub

  Private Sub BKsettings_Click(sender As Object, e As EventArgs) Handles BKsettings.Click
    If saveenabled >= 0 Then
      SaveFileDialog1.Filter = "Settings Package|*.bkp|Json Settings Only|*.jsns"
      SaveFileDialog1.Title = "Save your settings"
      SaveFileDialog1.FileName = "Settings"
      If SaveFileDialog1.ShowDialog = DialogResult.OK Then
        Dim pathsave As String = Path.GetExtension(SaveFileDialog1.FileName.ToString)

        If pathsave = ".jsns" Then
          BtnSave_Click(sender, e)
          Dim videogameRatings As JObject = New JObject(New JProperty("name", My.Settings.name.ToString),
                                                        New JProperty("name_save", My.Settings.NameRemember),
                                                        New JProperty("theme", My.Settings.Theme.ToString),
                                                        New JProperty("custom_theme", My.Settings.CustomTheme),
                                                        New JProperty("chibi", My.Settings.Chibi.ToString),
                                                        New JProperty("custom_chibi", My.Settings.CustomChibi),
                                                        New JProperty("lang", My.Settings.Bahasa.ToString),
                                                        New JProperty("custom_lang", False),
                                                        New JProperty("auto_update", My.Settings.AutoUpdate)
                                                       )
          System.IO.File.WriteAllText(SaveFileDialog1.FileName.ToString, videogameRatings.ToString)
        End If
        'MsgBox(SaveFileDialog1.FileName.ToString)
      End If
    Else
      MessageBox.Show("Ada bagian yang Error, Coba Periksa lagi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub

  Private Sub RSsettings_Click(sender As Object, e As EventArgs) Handles RSsettings.Click
    Dim themeNotFound As Boolean = False
    Dim chibiNotFound As Boolean = False

    OpenFileDialog1.Filter = "All Backups|*.jsns;*.bkp|Settings Package|*.bkp|Json Settings Only|*.jsns"
    OpenFileDialog1.Title = "Open backup settings"
    OpenFileDialog1.FileName = ""

    If OpenFileDialog1.ShowDialog = DialogResult.OK Then
      Dim pathsave As String = Path.GetExtension(OpenFileDialog1.FileName.ToString)

      If pathsave = ".jsns" Then
        Try
          File.Copy(OpenFileDialog1.FileName.ToString, appDataFMW & "\_data\settings\backup.json", True)
        Catch ex As Exception
          File.Delete(appDataFMW & "\_data\settings\backup.json")
          File.Copy(OpenFileDialog1.FileName.ToString, appDataFMW & "\_data\settings\backup.json")
        End Try

        Dim ReadJson As String = File.ReadAllText(appDataFMW & "\_data\settings\backup.json")
        Dim JsonObject As JObject = JObject.Parse(ReadJson.ToString)

        Dim CustomThemes As String = JsonObject.SelectToken("theme")
        Dim CustomChibis As String = JsonObject.SelectToken("chibi")

        If CustomThemes = "Default" OrElse CustomThemes = "Dark" OrElse CustomThemes = "Light" Then
          themeNotFound = False
        Else
          Dim Themes = CustomThemes.Replace("Custom - ", "")

          If Not File.Exists(dirTheme & "\" & Themes & ".jsnx") Then
            themeNotFound = True
          Else
            Dim folder As JObject = JObject.Parse(File.ReadAllText(dirTheme & "\" & Themes & ".jsnx"))
            Dim xsiColors As JObject = JObject.Parse(folder.SelectToken("color"))
            Try
              TB = xsiColors.SelectToken("toolbar").ToString
              FR = xsiColors.SelectToken("form").ToString
              ST = xsiColors.SelectToken("status").ToString
            Catch ex As Exception
              themeNotFound = True
            End Try
          End If
        End If


        If Not CustomChibis = "Default" Then

          Dim Chibis = CustomChibis.Replace("Custom - ", "")
          'MsgBox(Chibis)
          If Not Directory.Exists(dirTheme & "\" & Chibis) Then
            chibiNotFound = True
          Else
            Dim folder = dirTheme & "\" & Chibis

            If (Not File.Exists(folder & "\set-default.png") OrElse
                Not File.Exists(folder & "\set-fail.png") OrElse
                Not File.Exists(folder & "\set-happy.png")) Then
              chibiNotFound = True
            End If
          End If
        End If

        Dim msgset = "Semua tidak ada masalah"

        If chibiNotFound = True And themeNotFound = False Then
          msgset = "Chibi tidak ditemukan atau ada masalah, akan dikembalikan ke default"
        ElseIf chibiNotFound = False And themeNotFound = True Then
          msgset = "Theme tidak ditemukan atau ada masalah, akan dikembalikan ke default"
        ElseIf chibiNotFound = True And themeNotFound = True Then
          msgset = "Theme dan Chibi tidak ditemukan atau ada masalah, akan dikembalikan ke default"
        End If

        Dim hasil As String = MessageBox.Show(msgset & ControlChars.CrLf &
                    "Apakah yakin mau merestore setting ini? (Reboot program diperlukan)", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If hasil = DialogResult.Yes Then
          If themeNotFound = True Then
            JsonObject("theme") = "Default"
            JsonObject("custom_theme") = False
          End If

          If chibiNotFound = True Then
            JsonObject("chibi") = "Default"
            JsonObject("custom_chibi") = False
          End If

          If chibiNotFound = True Or themeNotFound = True Then
            File.Delete(appDataFMW & "\_data\settings\backup.json")
            File.WriteAllText(appDataFMW & "\_data\settings\backup.json", JsonObject.ToString)
          End If

          My.Settings.Reset()
          MainFrm.RestartPaksa = True
          Application.Restart()
        End If
        'elseif bkp
      End If
      'MsgBox(OpenFileDialog1.FileName.ToString)
    End If
  End Sub

  Private Sub RSsetting_Click(sender As Object, e As EventArgs) Handles RSsetting.Click
    Dim hasil As String = MessageBox.Show("Mereset setting akan mengembalikan ke setting default" & ControlChars.CrLf &
                        "Apakah ingin melanjutkan? (Reboot program diperlukan)", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If hasil = Windows.Forms.DialogResult.Yes Then
      If File.Exists(appDataFMW & "\_data\settings\backup.json") Then
        File.Delete(appDataFMW & "\_data\settings\backup.json")
      End If
      My.Settings.Reset()
      MainFrm.RestartPaksa = True
      Application.Restart()
    End If
  End Sub
End Class