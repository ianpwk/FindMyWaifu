Imports System.IO
Imports System.Linq
Imports System.Security.Principal

Module Module1
    Dim FileToCopy As String
    Dim FileToCopy2 As String
    Dim FileToCopy3 As String
    Dim NewCopy As String
    Dim NewCopy2 As String
    Dim NewCopy3 As String
    Dim appDataFMW As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FindMyWaifu\_data"
    Sub Main()
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If isElevated Then


            FileToCopy = appDataFMW & "\FindMyWaifu.exe"
            FileToCopy2 = appDataFMW & "\FindMyWaifu.exe.config"
            FileToCopy3 = appDataFMW & "\waifudata.mdb"
            NewCopy = "FindMyWaifu.exe"
            NewCopy2 = "FindMyWaifu.exe.config"
            NewCopy2 = "waifudata.mdb"

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

            If (Not System.IO.Directory.Exists(appDataFMW)) Then
                System.IO.Directory.CreateDirectory(appDataFMW)
            End If


            Unzip()

            If System.IO.File.Exists(FileToCopy) = True Then
                If System.IO.File.Exists(NewCopy) Then
                    System.IO.File.Delete(NewCopy)
                    System.IO.File.Delete(NewCopy2)
                    System.IO.File.Delete(NewCopy3)
                End If
                System.IO.File.Copy(FileToCopy, NewCopy)
                System.IO.File.Copy(FileToCopy2, NewCopy2)
                System.IO.File.Copy(FileToCopy3, NewCopy3)
                For Each Deletes In Directory.GetFiles(appDataFMW)
                    Try
                        System.IO.File.Delete(Deletes)
                    Catch ex As Exception

                    End Try

                Next
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
        System.IO.Directory.CreateDirectory(appDataFMW)

        Dim sc As New Shell32.Shell()
        Dim output As Shell32.Folder = sc.NameSpace(appDataFMW)
        Dim input As Shell32.Folder = sc.NameSpace(appDataFMW + "\updates\update.zip")

        output.CopyHere(input.Items, 4)
    End Sub

End Module
