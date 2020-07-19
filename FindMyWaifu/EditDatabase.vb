Imports System.Data.OleDb
Imports System.Xml
Imports System.Runtime.InteropServices
Imports FindMyWaifu.ClassTheme
Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Imports System.IO

Public Class EditDatabase

  Dim ID As String
  Dim NameWaifu As String
  Dim imgFMW As String

  Public Sub list()
    Try
      ListBox1.SelectedValue = ""
      ListBox1.Items.Clear()

      'hitung
      Koneksi()

      Dim cmd As New OleDbCommand
      cmd = Conn.CreateCommand

      cmd.CommandText = "SELECT * from [NameWaifu]"
      Dim dr As OleDbDataReader = cmd.ExecuteReader()
      While dr.Read()
        If Not dr(1).ToString = "" Then
          ListBox1.Items.Add(dr(0).ToString() & ". " & dr(1).ToString)
        End If
      End While
    Catch ex As Exception

      msg = ex.Message.ToString()
      If msg = "The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine." Then
        Dim msg1 As String = MsgBox("Module yang dibutuhkan di program ini belum di install" + Chr(13) + "Silahkan install modulenya", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Error")
        If msg1 = DialogResult.OK Then
          StartProgram.ShowDialog()
          StartProgram.DownloadEngine()
        Else
          Me.Close()
        End If
      End If
    End Try
  End Sub

  Private Sub EditDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    list()
  End Sub

  Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
    Dim screenPoint As Point = ButtonAdd.PointToScreen(New Point(ButtonAdd.Left, ButtonAdd.Bottom))
    If (screenPoint.Y _
                + (ContextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)) Then
      ContextMenuStrip1.Show(ButtonAdd, New Point(0, (ContextMenuStrip1.Size.Height * -1)))
    Else
      ContextMenuStrip1.Show(ButtonAdd, New Point(0, ButtonAdd.Height))
    End If
  End Sub

  Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
    Try
      Dim ID As String = ListBox1.SelectedItem.ToString.Split(".")(0)

      FormWaifu.Text = "Edit Waifu"
      FormWaifu.idedit = ID
      FormWaifu.ShowDialog()
    Catch ex As Exception

    End Try
  End Sub

  Private Sub AddNormalyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNormalyToolStripMenuItem.Click
    FormWaifu.idedit = 0
    FormWaifu.Text = "Add Waifu"
    FormWaifu.ShowDialog()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim ID As String = ListBox1.SelectedItem.ToString.Split(".")(0)
    Dim edit As New FormWaifu

    FormWaifu.Text = "Edit Waifu"
    FormWaifu.idedit = ID
    FormWaifu.ShowDialog()
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    ImgView.PictureBox1.Image = Image.FromFile(imgFMW)
    ImgView.Text = NameWaifu.ToString
    ImgView.ShowDialog()
  End Sub

  Sub Delete()
    ID = ListBox1.SelectedItem.ToString.Split(".")(0)
    Koneksi()

    Dim com = "DELETE from NameWaifu WHERE ([NO] = @no)"
    Dim cmd2 As New OleDbCommand(com, Conn)

    cmd2.Parameters.AddWithValue("@id", ID)

    Try
      cmd2.ExecuteNonQuery()
    Catch ex As Exception

    End Try
    Call list()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim hasil As String = MessageBox.Show("Apakah yakin untuk menghapus database ini?" & ControlChars.CrLf &
                    "Database akan terhapus berserta image nya", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    If hasil = Windows.Forms.DialogResult.Yes Then
      Delete()
    End If
  End Sub

  Private Sub EditDatabase_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    Conn.Close()
  End Sub

  Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
    Try
      ID = ListBox1.SelectedItem.ToString.Split(".")(0)
      NameWaifu = ListBox1.SelectedItem.ToString.Split(". ")(1)

      Button1.Enabled = True
      Button2.Enabled = True

      Koneksi()

      Dim cmd1 As New OleDbCommand
      cmd1 = Conn.CreateCommand

      cmd1.Parameters.AddWithValue("@id", ID)
      cmd1.CommandText = "SELECT * from [NameWaifu] where [No] =@id"
      Dim dr1 As OleDbDataReader = cmd1.ExecuteReader(CommandBehavior.SingleResult)

      Dim imgwaifu As String = ""

      If dr1.Read Then
        imgwaifu = dr1("image").ToString
      End If

      If Not imgwaifu = "" Then
        imgFMW = appDataFMW & "\_data\waifu\" & ID & "\" & imgwaifu

        If File.Exists(imgFMW) Then
          Button3.Enabled = True
        Else
          Button3.Enabled = False
        End If
      Else
        Button3.Enabled = False
      End If
    Catch ex As Exception
      Button1.Enabled = False
      Button2.Enabled = False
      Button3.Enabled = False
    End Try
  End Sub
End Class