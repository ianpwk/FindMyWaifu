Imports System.Data.OleDb, System.IO
Public Class FormWaifu
  Public idedit As Integer = 0

  Dim img As New CreateFolder()
  Dim imgFMW As String
  Private Sub FormWaifu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Try
      If idedit > 0 Then
        Koneksi()

        Dim cmd1 As New OleDbCommand
        cmd1 = Conn.CreateCommand

        cmd1.Parameters.AddWithValue("@id", idedit.ToString)
        cmd1.CommandText = "SELECT * from [NameWaifu] where [No] =@id"
        Dim dr1 As OleDbDataReader = cmd1.ExecuteReader(CommandBehavior.SingleResult)

        If dr1.HasRows Then
          If dr1.Read Then
            TextBox1.Text = dr1("NameWaifu").ToString
            TextBox2.Text = dr1("image").ToString
          End If
        End If
      Else
        TextBox1.Text = ""
        TextBox2.Text = ""
        imgFMW = ""
        Button2.Enabled = False
      End If
    Catch ex As Exception

    End Try

    If Not TextBox2.Text = "" Then
      imgFMW = img.appDataFMW & "\_data\waifu\" & idedit & "\" & TextBox2.Text
      If File.Exists(imgFMW) Then
        Button2.Enabled = True
      Else
        Button2.Enabled = False
      End If
    End If
  End Sub

  Private Sub ubah()
    Koneksi()

    Dim com = "UPDATE NameWaifu SET NameWaifu = @nw, [image] = @img WHERE ([NO] = @no)"
    Dim cmd2 As New OleDbCommand(com, Conn)

    cmd2.Parameters.AddWithValue("@nw", TextBox1.Text)
    cmd2.Parameters.AddWithValue("@img", TextBox2.Text)
    cmd2.Parameters.AddWithValue("@id", idedit.ToString)

    Try
      cmd2.ExecuteNonQuery()

      If Not TextBox2.Text = "" Then
        If Not Directory.Exists(img.appDataFMW & "\_data\waifu\" & idedit) Then
          Directory.CreateDirectory(img.appDataFMW & "\_data\waifu\" & idedit)
        End If

        If Not File.Exists(img.appDataFMW & "\_data\waifu\" & idedit & "\" & TextBox2.Text) Then
          File.Copy(imgFMW, img.appDataFMW & "\_data\waifu\" & idedit & "\" & TextBox2.Text)
        End If
      End If

      MsgBox("Data Berhasil Diubah", MsgBoxStyle.Information, "Info")
    Catch ex As Exception

    End Try
  End Sub

  Private Sub tambah()
    Koneksi()

    Dim com = "INSERT INTO NameWaifu (NameWaifu, [image]) VALUES (@nw, @img)"
    Dim cmd2 As New OleDbCommand(com, Conn)

    cmd2.Parameters.AddWithValue("@nw", TextBox1.Text)
    cmd2.Parameters.AddWithValue("@img", TextBox2.Text)

    Try
      cmd2.ExecuteNonQuery()

      If Not TextBox2.Text = "" Then
        If Not Directory.Exists(img.appDataFMW & "\_data\waifu\" & idedit) Then
          Directory.CreateDirectory(img.appDataFMW & "\_data\waifu\" & idedit)
        End If

        If Not File.Exists(img.appDataFMW & "\_data\waifu\" & idedit & "\" & TextBox2.Text) Then
          File.Copy(imgFMW, img.appDataFMW & "\_data\waifu\" & idedit & "\" & TextBox2.Text)
        End If
      End If

      MsgBox("Data Berhasil Ditambah", MsgBoxStyle.Information, "Info")
    Catch ex As Exception

    End Try
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If Not String.IsNullOrEmpty(TextBox1.Text) Then
      If idedit > 0 Then
        ubah()
      Else
        tambah()
      End If

      Me.Close()
    Else
      MsgBox("Data tidak boleh kosong", MsgBoxStyle.Critical, "Error")
    End If
  End Sub

  Private Sub FormWaifu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    EditDatabase.Button1.Enabled = False
    EditDatabase.Button2.Enabled = False
    Call EditDatabase.list()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ImgView.PictureBox1.Image = Image.FromFile(imgFMW)
    ImgView.Text = TextBox1.Text
    ImgView.ShowDialog()
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    OpenFileDialog1.Filter = "All Images|*.jpg;*.jpeg;*.png;*.gif"
    OpenFileDialog1.Title = "Open Image"
    OpenFileDialog1.FileName = ""

    If OpenFileDialog1.ShowDialog = DialogResult.OK Then
      imgFMW = OpenFileDialog1.FileName.ToString
      TextBox2.Text = Path.GetFileName(imgFMW)
      Button2.Enabled = True
    End If
  End Sub
End Class