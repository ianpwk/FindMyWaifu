Public Class Form1

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams
        Get
            Dim mdiCp As Windows.Forms.CreateParams = MyBase.CreateParams
            mdiCp.ClassStyle = mdiCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return mdiCp
        End Get
    End Property
    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click

        If CheckBox1.Checked = True Then
            My.Settings.name = TextBox1.Text
            My.Settings.NameRemember = True
        End If
        If TextBox1.Text = "" Then
            MsgBox("Masukan nama anda", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Eror")
        Else
            Me.Hide()
            FormSplash.ShowDialog()
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Alt AndAlso (e.KeyCode = Keys.F10)) Then

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        If My.Settings.NameRemember = True Then
            Me.Hide()
            FormSplash.Show()

            TextBox1.Text = My.Settings.name
            CheckBox1.Checked = True

            TextBox1.Enabled = False
            BtnMasuk.Enabled = False
            Button1.Enabled = False

            CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
