Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Public Class ThemePreview
    Dim DataFolder As New CreateFolder
    Dim CusTheme As String = My.Settings.Theme.Replace("Custom - ", "")
    Public FindJsons As String = DataFolder.appDataFMW & "\theme\" & CusTheme & ".jsnx"

    Dim ReadJson As String
    Dim xsiColorString As String
    Public JsonObject As JObject
    Public xsiColor As JObject
    Public toolbarmenu As Image

    Private Sub CheckthemeJson()
        Try
            If System.IO.File.Exists(FindJsons) Then
                ReadJson = System.IO.File.ReadAllText(FindJsons)
                JsonObject = JObject.Parse(ReadJson.ToString)

                xsiColorString = JsonObject.SelectToken("color").ToString
                xsiColor = JObject.Parse(xsiColorString.ToString)
            End If
        Catch ex As Exception

        End Try

        Try
            jsnxName = JsonObject.SelectToken("name").ToString
        Catch ex As Exception
            jsnxName = ""
            End Try
        Try
            jsnxCredit = JsonObject.SelectToken("credit").ToString
        Catch ex As Exception
            jsnxCredit = ""
        End Try
    End Sub

    Public jsnxName, jsnxCredit, iconmenu As String
    Public BGtoolbarColor, TXtoolbarColor, BGformColor, TXformColor, BGstatusColor, TXstatusColor As String
    Public imgIcon As Image

    Public errors As Integer = 0

    Public Sub XsiExist()
        If Not System.IO.File.Exists(FindJsons) Then
            errors += 1
            FrmError.ListBox1.Items.Add("Error S5: Theme Not Found")
            My.Settings.Theme = "Default"
            My.Settings.CustomTheme = False
        Else
            Call Coloring()
        End If
    End Sub

    Sub CheckChibi()
        If My.Settings.CustomChibi = True Then
            Dim ChibiFolder = My.Settings.Chibi.Replace("Custom - ", "")
            Dim folder = DataFolder.appDataFMW & "\chibi\" & ChibiFolder

            If System.IO.Directory.Exists(folder) Then
                If System.IO.File.Exists(folder & "set-default.png") And
                   System.IO.File.Exists(folder & "set-fail.png") And
                   System.IO.File.Exists(folder & "set-happy.png") Then

                Else
                    errors += 1
                    FrmError.ListBox1.Items.Add("Error S4: Theme Not Found")
                    My.Settings.Chibi = "Default"
                    My.Settings.CustomChibi = False
                End If
            Else
                errors += 1
                FrmError.ListBox1.Items.Add("Error S5: Chibi Not Found")
                My.Settings.Chibi = "Default"
                My.Settings.CustomChibi = False
            End If
        End If
    End Sub

    Public Sub Coloring()
        CheckthemeJson()

        Try
            BGtoolbarColor = xsiColor.SelectToken("toolbar").ToString
            BGformColor = xsiColor.SelectToken("form").ToString
            BGstatusColor = xsiColor.SelectToken("status").ToString
        Catch ex2 As Exception
            Dim validColorBGT As String = "#" + xsiColor.SelectToken("toolbar").ToString + " is not a valid value for Int32."
            Dim invalidname As String = "Object reference not set to an instance of an object."
            If ex2.Message.ToString = validColorBGT Then
                errors += 1
                FrmError.ListBox1.Items.Add("Error code S1: Code Color not valid or null")
            ElseIf ex2.Message.ToString = invalidname Then
                errors += 1
                FrmError.ListBox1.Items.Add("Error A2: Valiable not found (Color)")
            End If
            My.Settings.Theme = "Default"
            My.Settings.CustomTheme = False
        End Try

        Try
            TXtoolbarColor = xsiColor.SelectToken("toolbartext").ToString
            TXformColor = xsiColor.SelectToken("formtext").ToString
            TXstatusColor = xsiColor.SelectToken("statustext").ToString
        Catch ex As Exception

        End Try

        If TXformColor = "" Then
            Dim Red = Val("&H" & Mid(BGformColor, 1, 2))
            Dim Green = Val("&H" & Mid(BGformColor, 3, 2))
            Dim Blue = Val("&H" & Mid(BGformColor, 5, 2))

            Dim IsDark As Boolean = (Red <= 128) Or
                                    (Green <= 128) Or
                                    (Blue <= 128) Or
                                    (BGformColor = "000")

            If IsDark Then
                TXformColor = "FFFFFF"
            Else
                TXformColor = "000"
            End If
        End If

        If TXtoolbarColor = "" Then
            Dim Red = Val("&H" & Mid(BGtoolbarColor, 1, 2))
            Dim Green = Val("&H" & Mid(BGtoolbarColor, 3, 2))
            Dim Blue = Val("&H" & Mid(BGtoolbarColor, 5, 2))

            Dim IsDark As Boolean = (Red <= 128) Or
                                    (Green <= 128) Or
                                    (Blue <= 128) Or
                                    (BGtoolbarColor = "000")

            If IsDark Then
                TXtoolbarColor = "FFFFFF"
            Else
                TXtoolbarColor = "000"
            End If
        End If

        If TXstatusColor = "" Then
            Dim Red = Val("&H" & Mid(BGstatusColor, 1, 2))
            Dim Green = Val("&H" & Mid(BGstatusColor, 3, 2))
            Dim Blue = Val("&H" & Mid(BGstatusColor, 5, 2))

            Dim IsDark As Boolean = (Red <= 128) Or
                                    (Green <= 128) Or
                                    (Blue <= 128) Or
                                    (BGstatusColor = "000")

            If IsDark Then
                TXstatusColor = "FFFFFF"
            Else
                TXstatusColor = "000"
            End If
        End If

        Dim TBred = Val("&H" & Mid(BGtoolbarColor, 1, 2))
        Dim TBgreen = Val("&H" & Mid(BGtoolbarColor, 3, 2))
        Dim TBblue = Val("&H" & Mid(BGtoolbarColor, 5, 2))

        Dim TBIsDark As Boolean = (TBred <= 128) Or
                                (TBgreen <= 128) Or
                                (TBblue <= 128) Or
                                (BGtoolbarColor = "000")

        If TBIsDark Then
            toolbarmenu = My.Resources.white_menu
        Else
            toolbarmenu = My.Resources.menu
        End If
    End Sub

    Public Sub DetectionError()
        If Not errors = 0 Then
            FrmError.ShowDialog()
        End If
        If My.Settings.NameRemember = False Then
            FromName.Show()
            FormSplash.Hide()
        Else
            MainFrm.Show()
            FormSplash.Hide()
        End If
    End Sub

End Class
