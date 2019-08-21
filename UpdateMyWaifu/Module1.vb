Imports System.IO
Imports System.Linq

Module Module1
    Dim FileToCopy As String
    Dim NewCopy As String
    Sub Main()
        FileToCopy = "C:\Users\Owner\Documents\test.txt"
        NewCopy = "C:\Users\Owner\Documents\NewTest.txt"

        Console.WriteLine("Closing Porgram...")
        Process.

        If System.IO.File.Exists(FileToCopy) = True Then

            System.IO.File.Copy(FileToCopy, NewCopy)
        End If
    End Sub

End Module
