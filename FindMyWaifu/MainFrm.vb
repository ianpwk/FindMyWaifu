Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class MainFrm
    'Mulai
    Dim Conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim LokasiDB As String

    Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean

    Sub Koneksi()
        LokasiDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
        Conn = New OleDbConnection(LokasiDB)
    End Sub
    'Akhir

    Private Sub MainFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As Integer = MsgBox("Anda yakin mau mengclose program ini?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Yakin???")
        If result = DialogResult.Yes Then
            e.Cancel = False
            Form1.Close()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Try
            'Dim R As Integer
            'Randomize()
            'R = 1
            Koneksi()
            Dim cmd As OleDbCommand = Conn.CreateCommand
            cmd.CommandText = "SELECT top 1 * from NameWaifu ORDER BY rnd(ID)"
            If (Conn.State = ConnectionState.Closed) Then
                Conn.Open()
            End If

            Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If dr.Read Then
                TextBox1.Text = dr("NameWaifu").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Kasumi.Visible = False
            KasumiGo.Visible = False
            KasumiFail.Visible = True
            If ex.Message = "Microsoft.ACE.OLEDB.12.0′ provider Is Not registered on the local machine" Then
                RichTextBox1.Text = "Silahkan klik tombol di atas"
                ToolStripButton2.Enabled = True
            End If
        End Try
        Button1.Enabled = True
        'TextBox1.Text = (ds.Tables("NameWaifu"))
    End Sub

    Private Sub MainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = "Hai " + Form1.TextBox1.Text + ", senang berjumpa denganmu!!"
        ToolStripStatusLabel2.Text = ""
        Label1.Text = "Waifu " + Form1.TextBox1.Text + " adalah?"
        Dim Out As Integer
        If InternetGetConnectedState(Out, 0) = True Then
            ToolStripStatusLabel1.Text = "Connected"
            ToolStripStatusLabel1.ForeColor = Color.Green
            ConnectToolStripMenuItem.Checked = True
        Else
            ToolStripStatusLabel1.Text = "Disconnected"
            ToolStripStatusLabel1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToolStripMenuItem.Click
        FormConn.Label1.Text = "Connecting"
        FormConn.ShowDialog()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        MsgBox("Pastikan sesuai dengan system operasi anda (32/64Bit)", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "peringatan")
        Dim webAddress As String = "https://www.microsoft.com/en-us/download/details.aspx?id=13255"
        Process.Start(webAddress)
        Form1.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FormConn.Label1.Text = "Connecting"
        FormConn.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem.Click
        Settings.ShowDialog()
    End Sub

End Class