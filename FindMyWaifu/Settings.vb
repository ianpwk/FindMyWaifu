Imports System.IO, System.Net, System.Web, Newtonsoft.Json, Newtonsoft.Json.Linq

Public Class SettingsFrm

    ReadOnly create As New CreateFolder()
    Dim dirTheme As String = create.appDataFMW & "\theme"
    Dim dirChibi As String = create.appDataFMW & "\chibi"

    Dim xsiColor As JObject
    Dim CusTheme As String

    Public Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.Theme = ComboTheme.Text
        If My.Settings.Theme = "Default" Or My.Settings.Theme = "Dark" Or My.Settings.Theme = "Light" Then
            My.Settings.CustomTheme = False

        Else

            My.Settings.CustomTheme = True
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

        BtnSave.Enabled = False
        BtnSaveExit.Enabled = False
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton2.Enabled = False

        If (Not System.IO.Directory.Exists(create.appDataFMW & "\theme")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\theme")
        End If

        If (Not System.IO.Directory.Exists(create.appDataFMW & "\chibi")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\chibi")
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
                ComboChibi.Items.Add(dirInfo.Name)
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

        If hap_chibi.Checked = True Or fai_chibi.Checked = True Then
            hap_chibi.Checked = False
            fai_chibi.Checked = False
        End If
        def_chibi.Checked = True
        chbiPreview.Image = My.Resources.Kasumi_Toyama_Power_chibi_YfxFAe

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
        FrmUpdate.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnSaveExit.Click
        BtnSave_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim resetnama As Integer = MsgBox("Jika klik Yes, anda harus memasukan nama saat muat ulang" + Chr(13) + "Jika klik No, maka akan membatalkan progess ini", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Anda Yakin?")
        If resetnama = vbYes Then
            My.Settings.NameRemember = False
            My.Settings.name = ""
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

        chbiPreview.Image = My.Resources.Kasumi_Toyama_Power_chibi_rWnUUV
    End Sub

    Private Sub def_chibi_CheckedChanged(sender As Object, e As EventArgs) Handles def_chibi.CheckedChanged
        If hap_chibi.Checked = True Or fai_chibi.Checked = True Then
            hap_chibi.Checked = False
            fai_chibi.Checked = False
            def_chibi.Checked = True
        End If

        chbiPreview.Image = My.Resources.Kasumi_Toyama_Power_chibi_YfxFAe
    End Sub

    Private Sub fai_chibi_CheckedChanged(sender As Object, e As EventArgs) Handles fai_chibi.CheckedChanged
        If def_chibi.Checked = True Or hap_chibi.Checked = True Then
            def_chibi.Checked = False
            hap_chibi.Checked = False
            fai_chibi.Checked = True
        End If

        chbiPreview.Image = My.Resources.Kasumi_Toyama_Power_chibi_NFOyKG
    End Sub

    Private Sub ComboTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTheme.SelectedIndexChanged
        BtnSave.Enabled = True
        BtnSaveExit.Enabled = True

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
        Else

            Dim ReadJson As String = System.IO.File.ReadAllText(dirTheme & "\" & CusTheme & ".jsnx")
            Dim JsonObject As JObject = JObject.Parse(ReadJson.ToString)

            xsiColor = JObject.Parse(JsonObject.SelectToken("color").ToString)

            ToolStrip1.BackColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("toolbar").ToString)
            ToolStrip1.ForeColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("toolbartext").ToString)
            ToolStripButton1.Image = Colors.toolbarConIcon

            GroupBox2.BackColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("form").ToString)
            GroupBox2.ForeColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("formtext").ToString)

            StatusStrip1.BackColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("status").ToString)
            StatusStrip1.ForeColor = ColorTranslator.FromHtml("#" + xsiColor.SelectToken("statustext").ToString)
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckUpdate.CheckedChanged
        Dim osVer As Version = Environment.OSVersion.Version

        If Not osVer.Major >= 6 Then
            MsgBox("Auto Update belum support untuk versi ini", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            CheckUpdate.Checked = False
        ElseIf osVer.Major >= 6 Then
            BtnSave.Enabled = True
            BtnSaveExit.Enabled = True
        End If
    End Sub

    Private Sub OpenFThemeBtn_Click(sender As Object, e As EventArgs) Handles OpenFThemeBtn.Click
        Process.Start(create.appDataFMW & "\theme")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start(create.appDataFMW & "\chibi")
    End Sub

    Private Sub ComboChibi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChibi.SelectedIndexChanged

    End Sub

    Private Sub BKsettings_Click(sender As Object, e As EventArgs) Handles BKsettings.Click
        SaveFileDialog1.Filter = "Settings Package|*.bkp|Json Settings Only|*.jsns"
        SaveFileDialog1.Title = "Save your settings"
        SaveFileDialog1.FileName = "Settings"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            'My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtTeks.Text, True)
            MsgBox(SaveFileDialog1.FileName.ToString)
        End If

    End Sub

    Private Sub RSsettings_Click(sender As Object, e As EventArgs) Handles RSsettings.Click
        OpenFileDialog1.Filter = "Settings Package|*.bkp|Json Settings Only|*.jsns"
        OpenFileDialog1.Title = "Open backup settings"
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            MsgBox(OpenFileDialog1.FileName.ToString)
        End If
    End Sub

    Private Sub RSsetting_Click(sender As Object, e As EventArgs) Handles RSsetting.Click
        Dim hasil As String = MessageBox.Show("Mereset setting akan mengembalikan ke setting default" & ControlChars.CrLf &
                            "Apakah ingin melanjutkan? (Reboot program diperlukan)", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If hasil = Windows.Forms.DialogResult.Yes Then
            If File.Exists(create.appDataFMW & "\_data\settings\backup.json") Then
                File.Delete(create.appDataFMW & "\_data\settings\backup.json")
            End If
            My.Settings.Reset()
            FormSplash.Close()
        End If
    End Sub
End Class