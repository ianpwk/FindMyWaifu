Imports System.ComponentModel

Public Class FormSplash
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
        Dim create As New CreateFolder()
        If (Not System.IO.Directory.Exists(create.appDataFMW & "\_data")) Then
            System.IO.Directory.CreateDirectory(create.appDataFMW & "\_data")

            IO.File.SetAttributes(create.appDataFMW & "\_data", IO.FileAttributes.Hidden Or
                                  IO.FileAttributes.System)
        End If


        Label1.ForeColor = ColorTranslator.FromHtml("#ea5959")
        Label1.Text = "v" + Application.ProductVersion
    End Sub

    Private Sub FormSplash_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not Application.OpenForms().OfType(Of MainFrm).Any Then
            'FromName.Close()
        End If
    End Sub
End Class