Public Class FrmError
    Dim CheckError As New ThemePreview()
    Private Sub FrmError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Error Total: " + ListBox1.Items.Count.ToString()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class