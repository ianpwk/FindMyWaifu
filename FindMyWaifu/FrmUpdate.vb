Imports System.IO, System.Net, System.Web, System.Xml
Public Class FrmUpdate
    Public Sub CheckForUpdates()
        Try
            Dim ver As String = ""
            Dim xmlUpdate As New XmlTextReader("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21815&authkey=APPoahifAoJiGZo")
            Dim newver As String = ""
            Dim desc As String = ""

            While xmlUpdate.Read()
                Dim type = xmlUpdate.NodeType
                If xmlUpdate.Name = "version" Then
                    newver = xmlUpdate.ReadInnerXml.ToString()
                End If
                If xmlUpdate.Name = "description" Then
                    desc = xmlUpdate.ReadInnerXml.ToString()
                End If
            End While

            Label2.Text = "Update Ver.: " + newver
            Dim lastver As String = Application.ProductVersion

            If newver.ToString < lastver.ToString Then
                RichTextBox1.Text = desc
                Label3.Text = ""
            Else
                Label3.Text = "Sudah Terupdate"
                RichTextBox1.Text = "Versi anda sudah yang terbaru"
                Button1.Enabled = False
            End If
        Catch ex As Exception
            Label3.Text = ""
            RichTextBox1.Text = "Internet belum terkoneksi, kilk Retry untuk menyambung ulang"
            Button1.Text = "Retry"
        End Try
    End Sub

    Private Sub FrmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.ReadOnly = True
        RichTextBox1.BackColor = Color.Gray
        Label1.Text = "Curent ver.: " + Application.ProductVersion
        CheckForUpdates()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Update" Then
            Process.Start("https://github.com/ianpwk/FindMyWaifu/releases")
        ElseIf Button1.Text = "Retry" Then
            CheckForUpdates()
        End If

    End Sub
End Class