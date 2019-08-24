Public Class CreateFolder
    Public appDataFMW As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FindMyWaifu"
    Public Sub CreateFolderFMW()
        If (Not System.IO.Directory.Exists(appDataFMW)) Then
            System.IO.Directory.CreateDirectory(appDataFMW)
        End If
    End Sub
End Class
