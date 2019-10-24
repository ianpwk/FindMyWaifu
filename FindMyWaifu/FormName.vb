Imports System.Environment, System.IO
Public Class FromName

    Public appDataFMW As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FindMyWaifu"

    'Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    'Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams
    '    Get
    '        Dim mdiCp As Windows.Forms.CreateParams = MyBase.CreateParams
    '        mdiCp.ClassStyle = mdiCp.ClassStyle Or CP_NOCLOSE_BUTTON
    '        Return mdiCp
    '    End Get
    'End Property
    Private Sub BtnMasuk_Click(sender As Object, e As EventArgs) Handles BtnMasuk.Click
        If CheckBox1.Checked = True Then
            My.Settings.NameRemember = True
        End If
        My.Settings.name = TextBox1.Text
        MainFrm.Show()
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormSplash.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            BtnMasuk.Enabled = False
        Else
            BtnMasuk.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            BtnMasuk_Click(sender, e)
        Else
            If Not (Asc(e.KeyChar) = 8) Then
                If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                    e.KeyChar = ChrW(0)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub FromName_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not Application.OpenForms().OfType(Of MainFrm).Any Then
            FormSplash.Close()
        End If
    End Sub
End Class
