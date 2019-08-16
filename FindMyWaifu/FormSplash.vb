Public Class FormSplash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            MainFrm.Show()
            Form1.Hide()
            Me.Close()
        ElseIf ProgressBar1.Value = 10 Then
            Form1.Hide()
        End If

    End Sub
End Class