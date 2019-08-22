Imports System.IO
Imports System.Linq
Imports System.Security.Principal

Module Module1
    Dim FileToCopy As String
    Dim NewCopy As String
    Sub Main()
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If isElevated Then


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

            Using myprocess As System.Diagnostics.Process = New System.Diagnostics.Process()
                myprocess.StartInfo.FileName = "FindMyWaifu.exe"
                myprocess.Start()
            End Using
            Threading.Thread.Sleep(3000)
        Else
            Console.WriteLine("Anda bukan admin")
            Threading.Thread.Sleep(3000)
        End If
    End Sub

End Module
