Imports System.IO
Imports System.Linq
Imports System.Security.Principal

Module Module1
  Dim FileToCopy As String
  Dim FileToCopy1 As String
  Dim FileToCopy2 As String
  Dim FileToCopy3 As String
  Dim NewCopy As String
  Dim NewCopy1 As String
  Dim NewCopy2 As String
  Dim NewCopy3 As String
  Dim appDataFMW As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FindMyWaifu\_data"
  Dim unziper As String = appDataFMW & "\updates\data"
  Dim reg As Object = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\ardIANsyah", True)
  Dim regChange = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\ardIANsyah\FindMyWaifu", True)

  Private Function GetFileVersionInfo(ByVal filename As String) As Version
    Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
  End Function

  Sub Main()
    Dim identity = WindowsIdentity.GetCurrent()
    Dim principal = New WindowsPrincipal(identity)
    Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
    If isElevated Then

      Dim myAssemblyPath As String
      Dim a As Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
      myAssemblyPath = a.Location.Substring(0, InStrRev(a.Location, "\"))

      FileToCopy = unziper & "\FindMyWaifu.exe"
      FileToCopy1 = unziper & "\UpdateMyWaifu.exe"
      FileToCopy2 = unziper & "\FindMyWaifu.exe.config"
      'FileToCopy3 = unziper & "\waifudata.mdb"

      NewCopy = "FindMyWaifu.exe"
      NewCopy1 = "UpdateMyWaifu.exe"
      NewCopy2 = "FindMyWaifu.exe.config"
      'NewCopy3 = "waifudata.mdb"

      Console.WriteLine("Closing Program....")
      Threading.Thread.Sleep(3000)

      If Process.GetProcessesByName("FindMyWaifu").Length <> 0 Then
        Process.GetProcessesByName("FindMyWaifu")(0).Kill()
        Console.WriteLine("Program Closed")
      Else
        Console.WriteLine("program sudah berhenti")
      End If

      Console.WriteLine("Upgading file...")
      Threading.Thread.Sleep(3000)

      If Not reg Is Nothing Then
        Dim ver = GetFileVersionInfo(FileToCopy).ToString
        regChange.SetValue("Version", ver)
      End If

      If (Not Directory.Exists(appDataFMW)) Then
        Directory.CreateDirectory(appDataFMW)
      End If


      Unzip()

      If File.Exists(FileToCopy) = True Then
        File.Copy(FileToCopy, NewCopy, True)
        File.Copy(FileToCopy1, NewCopy1, True)
        File.Copy(FileToCopy2, NewCopy2, True)
        'File.Copy(FileToCopy3, NewCopy3, True)

        delete()
        File.Delete(appDataFMW + "\updates\update.zip")
      Else
        Console.WriteLine("File Update tidak Ditemukan atau versi program sudah yang terbaru.")
        Threading.Thread.Sleep(3000)
      End If

      Console.WriteLine("Opening...")

      Using myprocess As System.Diagnostics.Process = New System.Diagnostics.Process()
        myprocess.StartInfo.FileName = "FindMyWaifu.exe"
        myprocess.Start()
      End Using
      Threading.Thread.Sleep(1000)
    Else
      Console.WriteLine("Anda bukan admin")
      Threading.Thread.Sleep(3000)
    End If
  End Sub

  Private Sub Unzip()
    If File.Exists(appDataFMW + "\updates\update.zip") Then
      If Directory.Exists(appDataFMW & "\updates\data") Then
        delete()
      End If

      Directory.CreateDirectory(appDataFMW & "\updates\data")

      Dim sc As New Shell32.Shell()
      Dim output As Shell32.Folder = sc.NameSpace(appDataFMW + "\updates\data")
      Dim input As Shell32.Folder = sc.NameSpace(appDataFMW + "\updates\update.zip")

      output.CopyHere(input.Items, 4)
    Else
      Console.WriteLine("File tidak ada")
      Threading.Thread.Sleep(3000)
      Environment.Exit(0)
    End If
  End Sub

  Private Sub delete()
    For Each Deletes In Directory.GetFiles(unziper)
      Try
        File.Delete(Deletes)
      Catch ex As Exception

      End Try
    Next

    Directory.Delete(appDataFMW & "\updates\data")

  End Sub

End Module
