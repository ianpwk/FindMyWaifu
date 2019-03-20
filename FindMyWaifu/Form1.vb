Public Class Form1
    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click
        If TextBox1.Text = "" Then
            MsgBox("Masukan nama anda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Eror")
        Else
            Me.Hide()
            FormSplash.ShowDialog()
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Alt AndAlso (e.KeyCode = Keys.F10)) Then

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
End Class
