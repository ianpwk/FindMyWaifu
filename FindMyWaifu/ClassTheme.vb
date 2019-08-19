Public Class ClassTheme

    Public ToolbarColor As Color
    Public BackgroundColor As Color
    Public StatusColor As Color

    Public ToolbarText As Color
    Public MainColor As Color
    Public StatusText As Color
    Public toolbarMenuIcon As Image
    Public toolbarConIcon As Image

    Dim toolbarMenuWhite As Image = My.Resources.white_menu
    Dim toolbarMenuBlack As Image = My.Resources.menu

    Dim toolbarConWhite As Image = My.Resources.white_connect
    Dim toolbarConBlack As Image = My.Resources.connect

    Public Sub changetheme()
        If My.Settings.Theme = "Default" Then
            Colordefaults()
        ElseIf My.Settings.Theme = "Dark" Then
            ColorDark()
        Else

        End If
        Call ChoiceColor()
    End Sub

    Public Sub previewtheme()
        If SettingsFrm.ComboTheme.SelectedItem = "Default" Then
            Colordefaults()
        ElseIf SettingsFrm.ComboTheme.SelectedItem = "Dark" Then
            ColorDark()
        Else

        End If
    End Sub

    Public Sub ChoiceColor()
        MainFrm.ToolStrip2.BackColor = ToolbarColor
        MainFrm.ToolStrip2.ForeColor = ToolbarText

        MainFrm.ToolStripSplitButton1.Image = toolbarMenuIcon

        MainFrm.BackColor = BackgroundColor
        MainFrm.ForeColor = MainColor

        MainFrm.StatusStrip1.BackColor = StatusColor
        MainFrm.StatusStrip1.ForeColor = StatusText

    End Sub

    Private Sub Colordefaults()
        ToolbarColor = Color.FromArgb(224, 224, 224)
        ToolbarText = Color.Black

        toolbarMenuIcon = toolbarMenuBlack
        toolbarConIcon = toolbarConBlack

        BackgroundColor = Color.White
        MainColor = Color.Black

        StatusColor = Color.White
    End Sub
    Private Sub ColorDark()
        ToolbarColor = Color.FromArgb(66, 66, 66)
        ToolbarText = Color.White

        toolbarMenuIcon = toolbarMenuWhite
        toolbarConIcon = toolbarConWhite

        BackgroundColor = Color.FromArgb(117, 117, 117)
        MainColor = Color.Black

        StatusColor = Color.FromArgb(189, 189, 189)
    End Sub
End Class
