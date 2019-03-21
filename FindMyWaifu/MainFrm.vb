Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class MainFrm
    'Mulai
    Dim Conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim R As Integer

    Dim s As Integer
    Dim rn As New Random
    Dim LokasNomorB As String

    Private Declare Function InternetGetConnectedState Lib "wininet" (ByRef conn As Long, ByVal val As Long) As Boolean

    Sub Koneksi()
        LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
        Conn = New OleDbConnection(LokasNomorB)
    End Sub

    Public Sub Hitung()
        Try

            Koneksi()

            'hitung
            Conn.Open()

            Dim cmd As OleDbCommand = Conn.CreateCommand
            cmd.CommandText = "SELECT * from NameWaifu ORDER BY rnd()"

            Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If dr.Read Then
                s = dr("No").ToString

                R = rn.Next(1, S)
                rndno.Text = R
            End If
            Conn.Close()
        Catch ex As Exception
            Timer1.Enabled = False
            MessageBox.Show(ex.Message)
            Kasumi.Visible = False
            KasumiGo.Visible = False
            KasumiFail.Visible = True
            If ex.Message = "Microsoft.ACE.OLEDB.12.0′ provNomorer Is Not registered on the local machine" Then
                RichTextBox1.Text = "Silahkan klik tombol di atas"
                ToolStripButton2.Enabled = True
            End If
        End Try
    End Sub

    Sub hasil()

        'conversi
        Try
            Koneksi()
            Conn.Open()

            Dim cmd1 As New OleDbCommand
            cmd1 = Conn.CreateCommand

            cmd1.Parameters.AddWithValue("@id", rndno.Text)
            cmd1.CommandText = "SELECT * from [NameWaifu] where [No] =@id"
            Dim dr1 As OleDbDataReader = cmd1.ExecuteReader(CommandBehavior.SingleResult)

            If dr1.Read Then
                Label2.Text = dr1("NameWaifu").ToString
            End If
            Conn.Close()
        Catch ex As Exception
            Timer1.Enabled = False
            MessageBox.Show(ex.Message)
            Kasumi.Visible = False
            KasumiGo.Visible = False
            KasumiFail.Visible = True
        End Try
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
        ToolStripProgressBar1.Value = "0"
        Button1.Enabled = False
        Timer1.Enabled = True
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
        Dim webAddress As String = "https://www.microsoft.com/en-us/download/details.aspx?Nomor=13255"
        Process.Start(webAddress)
        Form1.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FormConn.Label1.Text = "Connecting"
        FormConn.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ToolStripProgressBar1.Value = "0" Then
            ToolStripProgressBar1.Value = "30"
        ElseIf ToolStripProgressBar1.Value = "30" Then
            Hitung()
            ToolStripProgressBar1.Value = "60"
        ElseIf ToolStripProgressBar1.Value = "60" Then
            hasil()
            ToolStripProgressBar1.Value = "100"
        ElseIf ToolStripProgressBar1.Value = "100" Then
            Timer1.Enabled = False
            TextBox1.Text = Label2.Text
            Button1.Enabled = True
        End If
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem.Click
        Settings.ShowDialog()
    End Sub

End Class