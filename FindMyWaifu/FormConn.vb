Imports System.Runtime.InteropServices
Public Class FormConn
    Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean

    Private Sub FormConn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Out As Integer
        Timer1.Enabled = False
        If InternetGetConnectedState(Out, 0) = True Then
            MsgBox("Internet sudah terkoneksi", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Succes")
            MainFrm.ToolStripStatusLabel1.Text = "Connected"
            MainFrm.ToolStripStatusLabel1.ForeColor = Color.Green
            MainFrm.ConnectToolStripMenuItem.Checked = True
            MainFrm.Kasumi.Visible = False
            MainFrm.KasumiFail.Visible = False
            MainFrm.KasumiGo.Visible = True
            Me.Close()
        Else
            MsgBox("Silahkan koneksikan internet anda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            MainFrm.Kasumi.Visible = False
            MainFrm.KasumiGo.Visible = False
            MainFrm.KasumiFail.Visible = True
            MainFrm.RichTextBox1.Text = "Pastikan terkoneksi internet ya!!!"
            Me.Close()
        End If
    End Sub

    Private Sub FormConn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Timer1.Enabled = False
    End Sub
End Class