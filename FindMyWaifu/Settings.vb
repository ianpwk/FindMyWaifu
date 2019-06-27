Imports System.IO, System.Net, System.Web
Public Class Settings
    Dim versiDatabase As String = "0.0.0.1"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub



    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = True
        Button5.Enabled = False
        ComboBox1.Enabled = False
        RadioButton2.Enabled = False
        Label8.Text = versiDatabase
        Timer1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmUpdate.ShowDialog()
    End Sub


End Class