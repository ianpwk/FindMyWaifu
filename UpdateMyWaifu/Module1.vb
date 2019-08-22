Imports System.IO
Imports System.Linq

Module Module1
    Dim FileToCopy As String
    Dim NewCopy As String
    Sub Main()
        FileToCopy = "_data\FindMyWaifu.exe"
        NewCopy = "FindMyWaifu.exe"

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
        If System.IO.File.Exists(FileToCopy) = True Then
            If System.IO.File.Exists(NewCopy) Then
                System.IO.File.Delete(NewCopy)
            End If
            System.IO.File.Copy(FileToCopy, NewCopy)
            System.IO.File.Delete(FileToCopy)
        Else
            Console.WriteLine("File Update tidak Ditemukan atau versi program sudah yang terbaru.")
            Threading.Thread.Sleep(3000)
        End If
        Console.WriteLine("Opening...")

        Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process()
        myprocess.StartInfo.FileName = "FindMyWaifu.exe"
        myprocess.Start()
        Threading.Thread.Sleep(3000)
    End Sub

End Module
