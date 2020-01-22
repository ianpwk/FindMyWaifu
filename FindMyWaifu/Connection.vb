Imports System.Data.OleDb
Module Connection
  'Mulai
  Public Conn As OleDbConnection
  Public R As Integer
  Public msg As String = ""
  Public s As Integer
  Public rn As New Random
  Public LokasNomorB As String
  Public Out As Integer
  Public updateversion As Boolean
  Public statusUpdate As Integer

  Sub Koneksi()

    'LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
    LokasNomorB = My.Settings.waifudataConnectionString
    Conn = New OleDbConnection(LokasNomorB)

    If Conn.State = ConnectionState.Closed Then
      Conn.Open()
    End If
  End Sub

  Sub bukaUpdate()
    If updateversion = False Then
      If statusUpdate = 1 Then
        MessageBox.Show("Versi Sudah diperbaharui", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
      ElseIf statusUpdate = 2 Then
        MessageBox.Show("Connection is offline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Else
      FrmUpdate.ShowDialog()
    End If
  End Sub
End Module
