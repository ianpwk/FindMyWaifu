Imports System.IO, System.Net, System.Web

Public Class Settings
    Dim versiDatabase As String = "0.0.0.1"

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If ComboTheme.Text = "Dark" Then
            My.Settings.Theme = "Dark"
        ElseIf ComboTheme.Text = "Default" Then
            My.Settings.Theme = "Default"
        End If

        Dim theme As New ClassTheme()
        theme.changetheme()

        If CheckBox1.Checked = True Then
            My.Settings.AutoUpdate = True
        Else
            My.Settings.AutoUpdate = False
        End If
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
        Timer1.Enabled = True

        ComboTheme.Items.Add("Default")
        ComboTheme.Items.Add("Dark")

        ComboTheme.SelectedItem = My.Settings.Theme

        If My.Settings.AutoUpdate = True Then
            CheckBox1.Checked = True
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
        Button1_Click(sender, e)
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub

    Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ComboTheme.Items.Clear()
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
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        BtnSave.Enabled = True
        BtnSaveExit.Enabled = True
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class