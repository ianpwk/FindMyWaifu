Imports Newtonsoft.Json, Newtonsoft.Json.Linq
Public Class SettingsSaver
  Dim setting As New JArray
  Dim savejson As String = appDataFMW & "\_data\settings\backup.json"

  Public Sub Settings()
    If System.IO.File.Exists(savejson) Then
      System.IO.File.Delete(savejson)
    End If

    Dim videogameRatings As JObject = New JObject(New JProperty("name", My.Settings.name.ToString),
                                                  New JProperty("name_save", My.Settings.NameRemember),
                                                  New JProperty("theme", My.Settings.Theme.ToString),
                                                  New JProperty("custom_theme", My.Settings.CustomTheme),
                                                  New JProperty("chibi", My.Settings.Chibi.ToString),
                                                  New JProperty("custom_chibi", My.Settings.CustomChibi),
                                                  New JProperty("lang", My.Settings.Bahasa.ToString),
                                                  New JProperty("custom_lang", False),
                                                  New JProperty("auto_update", My.Settings.AutoUpdate)
                                                 )
    System.IO.File.WriteAllText(savejson, videogameRatings.ToString)

  End Sub
End Class
