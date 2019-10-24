Imports System.ComponentModel
Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Public Class FormSplash
    Dim DataFolder As New CreateFolder
    Dim savejson As String = DataFolder.appDataFMW & "\_data\settings\backup.json"

    Dim ReadJson As String
    Dim xsiColorString As String
    Public JsonObject As JObject
    Public xsiColor As JObject

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            Dim FileExist As New ThemePreview

            If My.Settings.CustomTheme = True Then
                Call FileExist.XsiExist()
                If FileExist.errors = False Then
                    If FileExist.jsnxName = "" Then
                        If FileExist.jsnxCredit = "" Then
                            MsgBox(System.IO.Path.GetFileName(FileExist.FindJsons), vbInformation + vbOKOnly, "Credit Theme")
                        Else
                            MsgBox(System.IO.Path.GetFileName(FileExist.FindJsons) + Chr(13) + "Credit by: " + FileExist.jsnxCredit, vbInformation + vbOKOnly, "Credit Theme")
                        End If
                    ElseIf Not FileExist.jsnxName = "" And Not FileExist.jsnxCredit = "" Then
                        MsgBox(FileExist.jsnxName + Chr(13) + "Credit by: " + FileExist.jsnxCredit, vbInformation + vbOKOnly, "Credit Theme")
                    Else
                        MsgBox(FileExist.jsnxName, vbInformation + vbOKOnly, "Credit Theme")
                    End If
                End If
            End If

            Call FileExist.DetectionError()
        End If

    End Sub

    Private Sub FormSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("Program ini sudah berjalan", MsgBoxStyle.Critical + vbOKOnly, "Error")
            Application.Exit()
        End If

        Dim create As New CreateFolder()
        Call create.CreateFolderFMW()

        If (Not System.IO.Directory.Exists(create.appDataFMW & "\_data")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\_data")

            IO.File.SetAttributes(create.appDataFMW & "\_data", IO.FileAttributes.Hidden Or
                                  IO.FileAttributes.System)
        End If

        If My.Settings.load = True Then
            Try
                If System.IO.File.Exists(savejson) Then
                    ReadJson = System.IO.File.ReadAllText(savejson)
                    JsonObject = JObject.Parse(ReadJson.ToString)

                    My.Settings.name = JsonObject.SelectToken("name").ToString
                    My.Settings.NameRemember = JsonObject.SelectToken("name_save")
                    My.Settings.Theme = JsonObject.SelectToken("theme").ToString
                    My.Settings.CustomTheme = JsonObject.SelectToken("custom_theme")
                    My.Settings.Chibi = JsonObject.SelectToken("chibi").ToString
                    My.Settings.Bahasa = JsonObject.SelectToken("lang").ToString
                    My.Settings.AutoUpdate = JsonObject.SelectToken("auto_update")
                End If
            Catch ex As Exception

            End Try
        End If

        Label1.ForeColor = ColorTranslator.FromHtml("#ea5959")
        Label1.Text = "v" + Application.ProductVersion
    End Sub

    Private Sub FormSplash_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class