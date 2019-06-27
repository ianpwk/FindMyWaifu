Public Class ClassTheme
    Public Sub changetheme()
        If My.Settings.Theme = "Default" Then
            Colordefaults()
        ElseIf My.Settings.Theme = "Dark" Then
            ColorDark()
        End If

    End Sub
    Private Sub Colordefaults()
        MainFrm.ToolStrip2.BackColor = Color.FromArgb(224, 224, 224)
        MainFrm.ToolStrip2.ForeColor = Color.Black

        MainFrm.Conn_btn.Image = My.Resources.connect
        MainFrm.ToolStripSplitButton1.Image = My.Resources.menu

        MainFrm.BackColor = Color.White
        MainFrm.ForeColor = Color.Black
    End Sub
    Private Sub ColorDark()
        MainFrm.ToolStrip2.BackColor = Color.DimGray
        MainFrm.ToolStrip2.ForeColor = Color.White

        MainFrm.Conn_btn.Image = My.Resources.white_connect
        MainFrm.ToolStripSplitButton1.Image = My.Resources.white_menu

        MainFrm.BackColor = Color.Black
        MainFrm.ForeColor = Color.White
    End Sub
End Class
