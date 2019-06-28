Imports System.Data.OleDb
Imports System.Xml
Imports System.Runtime.InteropServices
Imports FindMyWaifu.ClassTheme
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

    Public Sub CheckForUpdates()
        Try
            Dim xmlUpdate As New XmlTextReader("https://onedrive.live.com/download?cid=9675D76E084032AB&resid=9675D76E084032AB%21815&authkey=APPoahifAoJiGZo")
            Dim newver As String = ""

            While xmlUpdate.Read()
                Dim type = xmlUpdate.NodeType
                If xmlUpdate.Name = "version" Then
                    newver = xmlUpdate.ReadInnerXml.ToString()
                End If
            End While

            Dim lastver As String = Application.ProductVersion

            If newver.ToString > lastver.ToString Then
                Dim cariupdate As Integer = MsgBox("Versi terbaru sudah hadir" + Chr(13) + "Apakah akan mengupdatenya?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Update Avaiable")
                If cariupdate = vbYes Then
                    FrmUpdate.ShowDialog()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

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
                'ToolStripButton2.Enabled = True
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
    End Sub

    Private Sub MainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Names As String
        If My.Settings.NameRemember = True Then
            Names = My.Settings.name

        Else
            Names = Form1.TextBox1.Text
        End If

        RichTextBox1.Text = "Hai " + Names + ", senang berjumpa denganmu!!"
        ToolStripStatusLabel2.Text = ""
        Label1.Text = "Waifu " + Names + " adalah?"
        Dim Out As Integer
        If InternetGetConnectedState(Out, 0) = True Then
            ToolStripStatusLabel1.Text = "Connected"
            ToolStripStatusLabel1.ForeColor = Color.Green

            CheckForUpdates()
        Else
            ToolStripStatusLabel1.Text = "Disconnected"
            ToolStripStatusLabel1.ForeColor = Color.Red
        End If


        Dim Colors As New ClassTheme()
        Colors.changetheme()
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

    Private Sub Conn_btn_Click(sender As Object, e As EventArgs) Handles Conn_btn.Click
        FormConn.Label1.Text = "Connecting"
        FormConn.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        FrmAbout.ShowDialog()
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        ToolStripSplitButton1.ShowDropDown()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)

    End Sub
End Class