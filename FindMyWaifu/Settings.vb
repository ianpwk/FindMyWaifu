Imports System.IO, System.Net, System.Web
Public Class Settings
    Dim versiDatabase As String = "0.0.0.1"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("saat ini masih dalam tahap development" + Chr(13) + "tunggu update selanjutnya", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Belum final")
    End Sub

    Public Sub CheckForUpdates()
        Try
            Dim req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21806&authkey=AAtl5T70h31ACiQ")
            Dim res As System.Net.HttpWebResponse = req.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(res.GetResponseStream())
            Dim newver As String = sr.ReadToEnd()
            Dim lastver As String = Application.ProductVersion
            Label6.Text = lastver.ToString
            If newver.ToString > lastver.ToString Then

            Else
                Label9.Text = "Versi anda sudah yang terbaru"
                Button4.Enabled = False
            End If
        Catch ex As Exception
            Label9.Text = "Pastikan internet anda terkoneksi"
            Button4.Enabled = False
        End Try
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Button5.Enabled = False
        ComboBox1.Enabled = False
        RadioButton2.Enabled = False
        Label6.Text = Application.ProductVersion
        Label8.Text = versiDatabase
        Timer1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Process.Start("https://github.com/ianpwk/FindMyWaifu/releases")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = "Cek koneksi...."
        CheckForUpdates()

        Timer1.Enabled = False
    End Sub
End Class