Imports SKYPE4COMLib
Imports System.Windows.Forms
Imports System.Net

Module Module1

#Region "Title Cosmetics"

    Sub titlecosmetics()

        Dim a As New Threading.Thread(AddressOf titlecosmeticsthread)
        a.Start()

    End Sub

    Sub titlecosmeticsthread()
        Dim i As Integer = 0
        Do
            If i = 0 Then
                Console.Title = "Ptx console"
                i += 1
            ElseIf i = 1 Then
                Console.Title = "pTx console"
                i += 1
            ElseIf i = 2 Then
                Console.Title = "ptX console"
                i += 1
            ElseIf i = 3 Then
                Console.Title = "ptx Console"
                i += 1
            ElseIf i = 4 Then
                Console.Title = "ptx cOnsole"
                i += 1
            ElseIf i = 5 Then
                Console.Title = "ptx coNsole"
                i += 1
            ElseIf i = 6 Then
                Console.Title = "ptx conSole"
                i += 1
            ElseIf i = 7 Then
                Console.Title = "ptx consOle"
                i += 1
            ElseIf i = 8 Then
                Console.Title = "ptx consoLe"
                i += 1
            ElseIf i = 9 Then
                Console.Title = "ptx consolE"
                i += 1
            ElseIf i = 10 Then
                Console.Title = "ptx consoLe"
                i += 1
            ElseIf i = 11 Then
                Console.Title = "ptx consOle"
                i += 1
            ElseIf i = 12 Then
                Console.Title = "ptx conSole"
                i += 1
            ElseIf i = 13 Then
                Console.Title = "ptx coNsole"
                i += 1
            ElseIf i = 14 Then
                Console.Title = "ptx cOnsole"
                i += 1
            ElseIf i = 15 Then
                Console.Title = "ptx Console"
                i += 1
            ElseIf i = 16 Then
                Console.Title = "ptX console"
                i += 1
            ElseIf i = 17 Then
                Console.Title = "pTx console"
                i = 0
            End If
            Threading.Thread.Sleep(100)
        Loop
    End Sub

#End Region

    Dim li As New HttpListener

    Dim skype As New Skype
    Dim skypeAttached As Boolean = False

    Sub Main()
        titlecosmetics()
        Dim s As String = ""
        Console.CursorSize = 1
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("   ___  _______  __    ___                      _      ")
        Console.WriteLine("  / _ \/__   \ \/ /   / __\___  _ __  ___  ___ | | ___ ")
        Console.WriteLine(" / /_)/  / /\/\  /   / /  / _ \| '_ \/ __|/ _ \| |/ _ \")
        Console.WriteLine("/ ___/  / /   /  \  / /__| (_) | | | \__ \ (_) | |  __/")
        Console.WriteLine("\/      \/   /_/\_\ \____/\___/|_| |_|___/\___/|_|\___|")
        Console.WriteLine(" ")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("PTX Console 1.0 by Jonas")
        Console.ForegroundColor = ConsoleColor.Gray
        Do
            Console.Write("ptx:> ")
            Console.ForegroundColor = ConsoleColor.Yellow
            s = Console.ReadLine()
            If s = "bye" Then
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.Write("Really quit? Type '")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write("yes")
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.Write("' to confirm. ")
                Console.ForegroundColor = ConsoleColor.Yellow
                If Console.ReadLine() = "yes" Then
                    End
                End If
            ElseIf s = "clear" Then
                Console.Clear()
            ElseIf s.StartsWith("jump") Then
                If s.Replace("jump ", "") = "skypeClient" Then
                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.Write("Using ")
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("Skype")
                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.WriteLine(" Client library.")
                    Dim active As Boolean = True
                    While active
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write("ptx/skypeClient:> ")
                        Console.ForegroundColor = ConsoleColor.Yellow
                        Dim l As String = Console.ReadLine()
                        If l = "top" Then
                            active = False
                        ElseIf l = "attach" Then
                            If Not skypeAttached Then
                                Try
                                    skype.Attach()
                                    Console.ForegroundColor = ConsoleColor.Green
                                    Console.WriteLine("Skype attached.")
                                    skypeAttached = True
                                Catch ex As Exception
                                    EmitErr("Attachment did not work.")
                                End Try
                            Else
                                EmitErr("Skype is already attached.")
                            End If
                        ElseIf l = "forcecallend" Then
                            For Each c As SKYPE4COMLib.Call In skype.ActiveCalls
                                c.Finish()
                            Next
                        ElseIf l = "callinfo" Then
                            For Each c As SKYPE4COMLib.Call In skype.ActiveCalls
                                Console.WriteLine("Call ID: " + c.Id.ToString + " Call Subject: " + c.Subject.ToString)
                                Console.WriteLine("---")
                                Dim plist As String = ""
                                For Each p As Participant In c.Participants
                                    plist += p.Handle + "/" + p.DisplayName + " "
                                Next
                                Console.WriteLine("Participants: " + plist)
                                Console.WriteLine(" ")
                            Next
                        ElseIf l.StartsWith("pcall ") Then
                            Console.WriteLine("Calling " + l.Replace("pcall ", "") + "...")
                            skype.PlaceCall(l.Replace("pcall ", ""))
                        ElseIf l.StartsWith("options") Then
                            skype.Client.OpenOptionsDialog("0")
                        End If
                    End While

                ElseIf s.Replace("jump ", "") = "webServer" Then

                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.Write("Using ")
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("WebServer")
                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.WriteLine(" library.")
                    Dim active As Boolean = True
                    Dim port As String = "9090"
                    Dim wp As String = "<html><h1>The default web page</h1></html>"
                    While active
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write("ptx/webServer:> ")
                        Console.ForegroundColor = ConsoleColor.Yellow
                        Dim l As String = Console.ReadLine()
                        If l = "top" Then
                            active = False
                        ElseIf l.StartsWith("port") Then
                            Console.ForegroundColor = ConsoleColor.Gray
                            Console.Write("Variable ")
                            Console.ForegroundColor = ConsoleColor.White
                            Console.Write("PORT")
                            Console.ForegroundColor = ConsoleColor.Gray
                            Console.Write(" changed to ")
                            Console.ForegroundColor = ConsoleColor.White
                            Console.Write(l.Replace("port ", ""))
                            Console.ForegroundColor = ConsoleColor.Gray
                            Console.WriteLine(".")
                            port = l.Replace("port ", "")
                        ElseIf l = "startserver" Then
                            Console.ForegroundColor = ConsoleColor.Gray
                            Console.Write("Server running at ")
                            Console.ForegroundColor = ConsoleColor.White
                            Console.Write("http://localhost:" + port + "/")
                            Console.ForegroundColor = ConsoleColor.Gray
                            Console.WriteLine(".")
                            Dim t As New Threading.Thread(Sub()
                                                              li.Prefixes.Add("http://*:" + port + "/")
                                                              li.Start()
                                                              Do
                                                                  Dim r As New ServerRsp
                                                                  r.lis = li
                                                                  r.ctx = li.GetContext()
                                                                  r.wp = wp
                                                                  r.respond()
                                                              Loop
                                                          End Sub)
                            t.Start()
                            Console.WriteLine("Press a key to stop the server...")
                            Console.ReadKey()
                            t.Abort()
                            li.Stop()
                        ElseIf l = "setwp" Then
                            Dim ofd As New OpenFileDialog
                            AddHandler ofd.FileOk, Sub()
                                                       wp = My.Computer.FileSystem.ReadAllText(ofd.FileName)
                                                       ofd.Dispose()
                                                   End Sub
                            ofd.Title = "Open a webpage"
                            ofd.Filter = "HTML file|*.html"
                            ofd.ShowDialog()
                        End If
                    End While

                ElseIf s.Replace("jump ", "") = "skypeResolver" Then

                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.Write("Using ")
                    Console.ForegroundColor = ConsoleColor.Cyan
                    Console.Write("Skype")
                    Console.ForegroundColor = ConsoleColor.DarkGray
                    Console.WriteLine(" Resolver library.")
                    Dim active As Boolean = True
                    While active
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write("ptx/skypeResolver:> ")
                        Console.ForegroundColor = ConsoleColor.Yellow
                        Dim l As String = Console.ReadLine()
                        If l = "top" Then
                            active = False
                        ElseIf l.StartsWith("byname") Then
                            With New Net.WebClient()
                                .Headers("User-Agent") = "Skype"
                                Dim response As String = .DownloadString("http://api.predator.wtf/resolver/?arguments=" + l.Replace("byname ", ""))
                                If response.Contains("Crap") Or response.Contains("resolved") Then
                                    response = "Could not resolve person."
                                    EmitErr(response)
                                Else
                                    Console.ForegroundColor = ConsoleColor.Green
                                    Console.WriteLine(response)
                                    Console.ForegroundColor = ConsoleColor.Gray
                                End If
                            End With
                        ElseIf l.StartsWith("byip") Then
                            With New Net.WebClient()
                                .Headers("User-Agent") = "Skype"
                                Dim response As String = .DownloadString("http://api.predator.wtf/lookup/?arguments=" + l.Replace("byip ", ""))
                                If response.Contains("Athena") Or response.Contains("Crap") Or response.Contains("no") Then
                                    response = "The IP is not bound to a name."
                                    EmitErr(response)
                                Else
                                    Console.ForegroundColor = ConsoleColor.Green
                                    Console.WriteLine(response)
                                    Console.ForegroundColor = ConsoleColor.Gray
                                End If
                            End With
                        ElseIf l.StartsWith("geoname") Then
                            Dim ip As Boolean = False
                            Dim rip As String = ""
                            Console.Write("Getting IP... ")
                            With New Net.WebClient()
                                .Headers("User-Agent") = "Skype"
                                Dim response As String = .DownloadString("http://api.predator.wtf/resolver/?arguments=" + l.Replace("geoname ", ""))
                                If response.Contains("Crap") Or response.Contains("resolved") Then
                                    ip = False
                                Else
                                    ip = True
                                    rip = response
                                End If
                            End With
                            Console.WriteLine(rip)
                            Console.WriteLine("Getting GeoData:")
                            If ip Then
                                With New Net.WebClient()
                                    .Headers("User-Agent") = "Skype"
                                    Dim response As String = .DownloadString("http://api.predator.wtf/geoip/?arguments=" + rip.ToString.Trim)
                                    Console.ForegroundColor = ConsoleColor.White
                                    Console.WriteLine(response.Replace("<br>", vbNewLine))
                                    Console.ForegroundColor = ConsoleColor.Gray
                                End With
                            Else
                                EmitErr("No IP found.")
                            End If
                        End If
                    End While

                Else
                    EmitErr("JUMP: Library not present.")
                End If
            Else
                EmitErr("Unknown command.")
            End If

            Console.ForegroundColor = ConsoleColor.Gray



        Loop
    End Sub

    Sub EmitErr(Text As String)
        Console.Beep()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write("[")
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write("!")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write("] ")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(Text)
    End Sub

End Module

Class ServerRsp

    Public ctx As HttpListenerContext
    Public lis As HttpListener
    Public wp As String

    Sub respond()
        ctx.Response.StatusCode = 200
        With New IO.StreamWriter(ctx.Response.OutputStream)
            .WriteLine(wp)
            .Flush()
            .Close()
        End With
        ctx.Response.Close()
    End Sub

End Class