Imports System.IO, System.Net, System.Web

Public Class Settings
    Dim versiDatabase As String = "0.0.0.1"

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "Dark" Then
            My.Settings.Theme = "Dark"
        ElseIf ComboBox1.Text = "Default" Then
            My.Settings.Theme = "Default"
        End If
        Dim theme As New ClassTheme()
        theme.changetheme()
        Button1.Enabled = False
    End Sub

    Public Sub CheckForUpdates()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton2.Enabled = False
        Label8.Text = versiDatabase
        Timer1.Enabled = True

        ComboBox1.Items.Add("Default")
        ComboBox1.Items.Add("Dark")

        ComboBox1.SelectedItem = My.Settings.Theme

        If My.Settings.NameRemember = False Then
            Button7.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmUpdate.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim resetnama As Integer = MsgBox("Jika klik Yes, anda harus memasukan nama muat ulang" + Chr(13) + "Jika klik No, maka akan membatalkan progess ini", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Anda Yakin?")
        If resetnama = vbYes Then
            My.Settings.NameRemember = False
            My.Settings.name = ""
            Button7.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub

    Private Sub Settings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ComboBox1.Items.Clear()
    End Sub
End Class