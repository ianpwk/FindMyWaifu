Imports System.IO, System.Net, System.Web, Newtonsoft.Json, Newtonsoft.Json.Linq

Public Class SettingsFrm

    ReadOnly create As New CreateFolder()
    Dim dirTheme As String = create.appDataFMW & "\theme"
    Dim dirChibi As String = create.appDataFMW & "\chibi"
    Dim file As String

    Dim xsiColor As JObject
    Dim CusTheme As String

    Public Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.Settings.Theme = ComboTheme.Text
        If My.Settings.Theme = "Default" Or My.Settings.Theme = "Dark" Or My.Settings.Theme = "Light" Then
            My.Settings.CustomTheme = False

        Else

            My.Settings.CustomTheme = True
        End If

        Dim theme As New ClassTheme()
        theme.changetheme()

        If CheckUpdate.Checked = True Then
            My.Settings.AutoUpdate = True
        Else
            My.Settings.AutoUpdate = False
        End If
        My.Settings.Save()

        Dim save As New SettingsSaver()
        Call save.Settings()

        BtnSave.Enabled = False
        BtnSaveExit.Enabled = False
    End Sub

    Public Sub CheckForUpdates()
        Try

        Catch ex As Exception

        End Try
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
        BtnSave.Enabled = True
        BtnSaveExit.Enabled = True
    End Sub

    Private Sub OpenFThemeBtn_Click(sender As Object, e As EventArgs) Handles OpenFThemeBtn.Click
        Process.Start(create.appDataFMW & "\theme")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start(create.appDataFMW & "\chibi")
    End Sub

    Private Sub ComboChibi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChibi.SelectedIndexChanged

    End Sub
End Class