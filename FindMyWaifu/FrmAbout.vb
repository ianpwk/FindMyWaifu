Public Class FrmAbout
  Private Sub FrmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Label2.Text = "v" + Application.ProductVersion
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    bukaUpdate()
  End Sub

  Private Sub GithubLink_Click(sender As Object, e As EventArgs) Handles GithubLink.Click
    Process.Start("https://github.com/ianpwk/FindMyWaifu")
  End Sub

  Private Sub YoutubeLink_Click(sender As Object, e As EventArgs) Handles YoutubeLink.Click
    Process.Start("https://youtube.com/ianardian1com")
  End Sub

  Private Sub InstagramLink_Click(sender As Object, e As EventArgs) Handles InstagramLink.Click
    Process.Start("https://instagram.com/yansaan_")
  End Sub

  Private Sub TwitterLink_Click(sender As Object, e As EventArgs) Handles TwitterLink.Click
    Process.Start("https://twitter.com/yansaan_")
  End Sub

  Private Sub FacebookLink_Click(sender As Object, e As EventArgs) Handles FacebookLink.Click
    Process.Start("https://fb.me/yansaanxyz")
  End Sub

  Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

  End Sub
End Class