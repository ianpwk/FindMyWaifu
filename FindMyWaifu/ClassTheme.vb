Public Class ClassTheme

    Public ToolbarColor As Color
    Public BackgroundColor As Color
    Public StatusColor As Color

    Public ToolbarText As Color
    Public MainColor As Color
    Public StatusText As Color
    Public toolbarIcon As Image

    Public Sub changetheme()
        If My.Settings.Theme = "Default" Then
            Colordefaults()
        ElseIf My.Settings.Theme = "Dark" Then
            ColorDark()
        Else

        End If
    End Sub

    Public Sub ChoiceColor()
        MainFrm.ToolStrip2.BackColor = ToolbarColor
        MainFrm.ToolStrip2.ForeColor = ToolbarText

        MainFrm.ToolStripSplitButton1.Image = toolbarIcon

        MainFrm.BackColor = BackgroundColor
        MainFrm.ForeColor = MainColor

        MainFrm.StatusStrip1.BackColor = StatusColor
        MainFrm.StatusStrip1.ForeColor = StatusText

    End Sub

    Private Sub Colordefaults()
        ToolbarColor = Color.FromArgb(224, 224, 224)
        ToolbarText = Color.Black

        toolbarIcon = My.Resources.menu

        BackgroundColor = Color.White
        MainColor = Color.Black

        StatusColor = Color.White

        Call ChoiceColor()
    End Sub
    Private Sub ColorDark()
        ToolbarColor = Color.FromArgb(66, 66, 66)
        ToolbarText = Color.White

        toolbarIcon = My.Resources.white_menu

        BackgroundColor = Color.FromArgb(117, 117, 117)
        MainColor = Color.Black

        StatusColor = Color.FromArgb(189, 189, 189)

        Call ChoiceColor()
    End Sub
End Class
