Imports System.Data.OleDb, Newtonsoft.Json, Newtonsoft.Json.Linq
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
  Public osSupport As Boolean
  Public currentEnabled As Boolean
  Public NameModule As String

  Public majorOnline, mirorOnline, bulidOnline, revisionOnline As String
  Public ver As String = Application.ProductVersion.ToString
  Public newver As String = ""
  Public desc As String = ""
  Public dates As String

  Sub Koneksi()

    'LokasNomorB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb"
    LokasNomorB = My.Settings.waifudataConnectionString
    Conn = New OleDbConnection(LokasNomorB)

    If Conn.State = ConnectionState.Closed Then
      Conn.Open()
    End If
  End Sub

  Sub bukaUpdate()
    'If updateversion = False Then
    '  If statusUpdate = 1 Then
    '    MessageBox.Show("Versi Sudah diperbaharui", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '  ElseIf statusUpdate = 2 Then
    '    MessageBox.Show("Connection is offline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  ElseIf statusUpdate = 3 Then
    '    MessageBox.Show("Your OS not Support for auto Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  End If
    'Else
    FrmUpdate.ShowDialog()
    'End If
  End Sub

  Public Sub CacheUpdate()
    Dim Chaches As String = appDataFMW & "\_data\settings\_update.json"

    If System.IO.File.Exists(Chaches) Then
      System.IO.File.Delete(Chaches)
    End If

    dates = Date.Today
    Dim updateData As JObject = New JObject(
      New JProperty("date", dates.ToString),
      New JProperty("version", newver),
      New JProperty("version_detalis", New JObject(
        New JProperty("major", majorOnline),
        New JProperty("miror", mirorOnline),
        New JProperty("bulid", bulidOnline),
        New JProperty("revision", revisionOnline)
        )),
      New JProperty("description", desc)
      )

    System.IO.File.WriteAllText(Chaches, updateData.ToString)
  End Sub
End Module
