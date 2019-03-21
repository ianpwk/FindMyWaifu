Imports DotNetUpdater
Public Class Settings
    Dim upgate As New DotNetUpdater.updater
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Button5.Enabled = False
        ComboBox1.Enabled = False
        RadioButton2.Enabled = False
        Label6.Text = String.Format("{0}", My.Application.Info.Version.ToString)

        upgate.checkinternetconn()
        If upgate.internet = True Then
            upgate.checkupdate("", Label6.Text)
        End If
    End Sub
End Class