Imports System.Data.OleDb
Public Class StartProgram

    Dim Conn As OleDbConnection
    Dim LokasNomorB As String

    Sub Koneksi()
        Try
            Timer1.Enabled = False
            LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
            Conn = New OleDbConnection(LokasNomorB)
            Conn.Open()
            Conn.Close()
            Timer1.Enabled = True
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Dim msg1 As String = MsgBox("Module yang dibutuhkan di progam ini belum di install" + Chr(13) + "Silahkan install modulenya", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Error")
            If msg1 = DialogResult.OK Then
                Dim webAddress As String = "https://www.microsoft.com/en-us/download/details.aspx?Nomor=13255"
                Process.Start(webAddress)
                Form1.Close()
            Else
                Form1.Close()
            End If
        End Try
    End Sub

    Private Sub StartProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Text = "Menyiapkan..."
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 1
        End If

        If ProgressBar1.Value = 50 Then
            Label1.Text = "Mendeteksi module..."
            Koneksi()
        ElseIf ProgressBar1.Value = 51 Then
            Label1.Text = "menyelesaikan wizard..."
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            MainFrm.Show()
            Me.Close()
        End If
    End Sub
End Class