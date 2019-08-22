Imports System.IO
Imports System.Linq

Module Module1
    Dim FileToCopy As String
    Dim NewCopy As String
    Sub Main()
        FileToCopy = "C:\Users\Owner\Documents\test.txt"
        NewCopy = "C:\Users\Owner\Documents\NewTest.txt"

        Console.WriteLine("Closing Program....")
        Threading.Thread.Sleep(3000)

        If Process.GetProcessesByName("FindMyWaifu").Length <> 0 Then
            Process.GetProcessesByName("FindMyWaifu")(0).Kill()
            Console.WriteLine("Program Closed")
        Else
            Console.WriteLine("program sudah berhenti")
        End If

        Console.WriteLine("Upgating file...")
        If System.IO.File.Exists(FileToCopy) = True Then
            Threading.Thread.Sleep(3000)
            System.IO.File.Copy(FileToCopy, NewCopy)
        Else
            Console.WriteLine("File Update tidak Ditemukan atau versi program sudah yang terbaru.")
            Threading.Thread.Sleep(3000)
        End If
        Console.WriteLine("Apakah ingin menjalankannya lagi?")
        Dim myprocess As System.Diagnostics.Process = New System.Diagnostics.Process()
        myprocess.StartInfo.FileName = "FindMyWaifu.exe"
        myprocess.Start()
    End Sub

End Module
