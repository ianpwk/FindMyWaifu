Public Class FrmAbout
    Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "v" + Application.ProductVersion
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/ianpwk/FindMyWaifu")
    End Sub
End Class