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

  Public toolbarConWhite As Image = My.Resources.white_connect
  Public toolbarConBlack As Image = My.Resources.connect

  Public Sub changetheme()
    If My.Settings.Theme = "Default" Then
      ColorDefault()
    ElseIf My.Settings.Theme = "Light" Then
      ColorLight()
    ElseIf My.Settings.Theme = "Dark" Then
      ColorDark()
    Else
      CustomColor()
    End If
    Call ChoiceColor()
  End Sub

  Public Sub previewtheme()
    If SettingsFrm.ComboTheme.SelectedItem = "Default" Then
      ColorDefault()
    ElseIf SettingsFrm.ComboTheme.SelectedItem = "Light" Then
      ColorLight()
    ElseIf SettingsFrm.ComboTheme.SelectedItem = "Dark" Then
      ColorDark()
    Else
      'CustomColor()
    End If
  End Sub

  Public Sub ChoiceColor()
    MainFrm.ToolStrip2.BackColor = ToolbarColor
    MainFrm.ToolStrip2.ForeColor = ToolbarText
    MainFrm.ToolStripSplitButton1.ForeColor = ToolbarText

    MainFrm.ToolStripSplitButton1.Image = toolbarMenuIcon

    MainFrm.BackColor = BackgroundColor
    MainFrm.ForeColor = MainColor

    MainFrm.StatusStrip1.BackColor = StatusColor
    MainFrm.StatusStrip1.ForeColor = StatusText

  End Sub

  Private Sub ColorLight()
    ToolbarColor = Color.FromArgb(224, 224, 224)
    ToolbarText = Color.FromArgb(54, 54, 54)

    toolbarMenuIcon = toolbarMenuBlack
    toolbarConIcon = toolbarConBlack

    BackgroundColor = Color.White
    MainColor = Color.Black

    StatusColor = Color.White
    StatusText = Color.Black
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

  Private Sub ColorDefault()
    ToolbarColor = Color.FromKnownColor(KnownColor.Info)
    ToolbarText = Color.FromKnownColor(KnownColor.ControlText)

    toolbarMenuIcon = toolbarMenuBlack
    toolbarConIcon = toolbarConBlack

    BackgroundColor = Color.FromKnownColor(KnownColor.Control)
    MainColor = Color.FromKnownColor(KnownColor.ControlText)

    StatusColor = Color.FromKnownColor(KnownColor.Control)
  End Sub

  Private Sub CustomColor()
    Dim Colorings As New ThemePreview()

    Call Colorings.Coloring()
    ToolbarColor = ColorTranslator.FromHtml("#" + Colorings.BGtoolbarColor.ToString())
    ToolbarText = ColorTranslator.FromHtml("#" + Colorings.TXtoolbarColor.ToString())
    toolbarMenuIcon = Colorings.toolbarmenu

    BackgroundColor = ColorTranslator.FromHtml("#" + Colorings.BGformColor.ToString())
    MainColor = ColorTranslator.FromHtml("#" + Colorings.TXformColor.ToString())

    StatusColor = ColorTranslator.FromHtml("#" + Colorings.BGstatusColor.ToString())
    StatusText = ColorTranslator.FromHtml("#" + Colorings.TXstatusColor.ToString())
  End Sub
End Class
