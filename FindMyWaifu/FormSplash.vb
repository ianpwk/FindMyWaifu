Imports System.ComponentModel
Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Imports System.IO
Public Class FormSplash
    Dim DataFolder As New CreateFolder
    Dim savejson As String = DataFolder.appDataFMW & "\_data\settings\backup.json"

    Dim ReadJson As String
    Dim xsiColorString As String
    Public JsonObject As JObject
    Public xsiColor As JObject
    Dim openfile As String

    Private Sub FormSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (My.Application.CommandLineArgs.Count > 0) Then
            openfile = My.Application.CommandLineArgs(0).ToString
        End If

        Dim create As New CreateFolder()
        Call create.CreateFolderFMW()

        If (Not System.IO.Directory.Exists(create.appDataFMW & "\_data")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\_data")

            IO.File.SetAttributes(create.appDataFMW & "\_data", IO.FileAttributes.Hidden Or
                                  IO.FileAttributes.System)
        End If

        If Not Directory.Exists(create.appDataFMW & "\theme") Then
            Directory.CreateDirectory(create.appDataFMW & "\theme")
        End If

        If Not Directory.Exists(create.appDataFMW & "\chibi") Then
            Directory.CreateDirectory(create.appDataFMW & "\chibi")
        End If

        Dim osVer As Version = Environment.OSVersion.Version

        If osVer.Major < 6 Then
            My.Settings.AutoUpdate = False
        End If

        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            If My.Application.CommandLineArgs.Count > 0 Then
                Timer1.Enabled = False
                Dim settheme As Boolean = False

                If Not openfile = "" Then
                    Dim theme As New CreateFolder()
                    Dim checks As String = Path.GetExtension(openfile.ToString)
                    Dim checkfile As String = Path.GetFileName(openfile.ToString)
                    Dim checksource As String = theme.appDataFMW & "\theme\" & checkfile
                    If checks = ".jsnx" Then
                        If File.Exists(checksource) Then
                            Dim duplikat As String = MessageBox.Show("Theme yang ditambahkan sudah ditambahkan sebelumnya" & ControlChars.CrLf &
                                "Klik yes untuk menimpa, no untuk menutup aplikasi ini, cencel untuk membatalkan", "Theme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If duplikat = Windows.Forms.DialogResult.Yes Then
                                File.Copy(openfile, checksource, True)
                                settheme = True
                            End If
                        Else
                            File.Copy(openfile, checksource)
                            settheme = True
                        End If

                        If settheme = True Then
                            Dim hasil As String = MessageBox.Show("Theme telah ditambahkan", "Theme", MessageBoxButtons.OK, MessageBoxIcon.Question)
                            Application.Exit()
                        End If
                        'elseifchibi
                    End If
                    openfile = ""
                End If
            Else
                MsgBox("Program ini sudah berjalan", MsgBoxStyle.Critical + vbOKOnly, "Error")
                Application.Exit()
            End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim settheme As Boolean = False

        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            Dim FileExist As New ThemePreview

            If Not openfile = "" Then
                Dim theme As New CreateFolder()
                Dim checks As String = Path.GetExtension(openfile.ToString)
                Dim checkfile As String = Path.GetFileName(openfile.ToString)
                Dim checksource As String = theme.appDataFMW & "\theme\" & checkfile
                If checks = ".jsnx" Then
                    If File.Exists(checksource) Then
                        Dim duplikat As String = MessageBox.Show("Theme yang ditambahkan sudah ditambahkan sebelumnya" & ControlChars.CrLf &
                            "Klik yes untuk menimpa, no untuk menutup aplikasi ini, cencel untuk membatalkan", "Theme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If duplikat = Windows.Forms.DialogResult.Yes Then
                            Try
                                File.Copy(openfile, checksource, True)
                            Catch ex As Exception
                                File.Delete(checksource)
                                File.Copy(openfile, checksource)
                            End Try
                            settheme = True
                        End If
                    Else
                        File.Copy(openfile, checksource)
                        settheme = True
                    End If

                    If settheme = True Then
                        Dim hasil As String = MessageBox.Show("Theme telah ditambahkan" & ControlChars.CrLf &
                            "Apakah ingin menggunakannya?", "Theme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If hasil = Windows.Forms.DialogResult.Yes Then
                            My.Settings.CustomTheme = True
                            My.Settings.Theme = "Custom - " & Path.GetFileNameWithoutExtension(openfile).ToString
                        End If
                    End If
                    'elseifchibi
                End If
                openfile = ""
            End If
            If FileExist.errors = False Then
                'nothing
            End If
            Call FileExist.DetectionError()
        End If

    End Sub

    Private Sub FormSplash_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class