Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Public Class ThemePreview
    Dim DataFolder As New CreateFolder
    Dim CusTheme As String = My.Settings.Theme.Replace("Custom - ", "")
    Public FindJsons As String = DataFolder.appDataFMW & "\theme\" & CusTheme & ".jsnx"

    Dim ReadJson As String
    Dim xsiColorString As String
    Public JsonObject As JObject
    Public xsiColor As JObject

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
            FrmError.ListBox1.Items.Add("Error S5: File Not Found")
            My.Settings.Theme = "Default"
            My.Settings.CustomTheme = False
        Else
            Call Coloring()
        End If
    End Sub

    Public Sub Coloring()
        CheckthemeJson()

        Try
            BGtoolbarColor = xsiColor.SelectToken("toolbar").ToString
            TXtoolbarColor = xsiColor.SelectToken("toolbartext").ToString
            BGformColor = xsiColor.SelectToken("form").ToString
            TXformColor = xsiColor.SelectToken("formtext").ToString
            BGstatusColor = xsiColor.SelectToken("status").ToString
            TXstatusColor = xsiColor.SelectToken("statustext").ToString

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
        End Try




    End Sub

    Public Sub DetectionError()
        If Not errors = 0 Then
            FrmError.ShowDialog()
        End If
        MainFrm.Show()
        Form1.Hide()
        FormSplash.Close()
    End Sub

End Class
