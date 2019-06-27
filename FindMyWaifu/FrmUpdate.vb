Imports System.IO, System.Net, System.Web
Public Class FrmUpdate
    Public Sub CheckForUpdates()
        Try
            Dim req As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21806&authkey=AAtl5T70h31ACiQ")
            Dim res As System.Net.HttpWebResponse = req.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(res.GetResponseStream())
            Dim newver As String = sr.ReadToEnd()
            Dim lastver As String = Application.ProductVersion

            Label2.Text = "Update Ver.: " + lastver.ToString
            If newver.ToString > lastver.ToString Then

            Else
                Label3.Text = "Versi anda sudah yang terbaru"
                Button1.Enabled = False
            End If
        Catch ex As Exception
            Label3.Text = "Pastikan internet anda terkoneksi"
            Button1.Enabled = False
        End Try
    End Sub

    Private Sub FrmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Curent ver.: " + Application.ProductVersion
        CheckForUpdates()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = "Cek koneksi...."
        CheckForUpdates()

        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://github.com/ianpwk/FindMyWaifu/releases")
    End Sub
End Class