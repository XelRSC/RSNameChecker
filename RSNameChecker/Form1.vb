Imports System.IO
Imports System.Threading
Imports System.Net



Public Class Form1


    Private cURL = "http://rscript.org/lookup.php?type=namecheck&name="
    Private avString = "NAMECHECK: AVALIBLE"
    Private tWatch As New Stopwatch
    Private progressBarValue As Integer = 0
    Private killThreads As Boolean = False


    Private listBox1 As New ListBox
    Private listBox2 As New ListBox
    Private listBox3 As New ListBox
    Private listBox4 As New ListBox
    Private listBox5 As New ListBox

    Private timeThread As Thread = New Thread(AddressOf Me.timerThread)
    Private probarThread As Thread = New Thread(AddressOf Me.pbarThread)



    Private Sub loader() Handles MyBase.Load
        timeThread.IsBackground = True
        probarThread.IsBackground = True
        timeThread.Start()
        probarThread.Start()
    End Sub

#Region "Start/Stop"
    Private Sub startThreads() Handles StartToolStripMenuItem.Click
        killThreads = False
        setStates()
        splitBox(Namestocheck)
        'Set threads
        Dim t1 As Thread = New Thread(AddressOf Me.checkerThread1)
        Dim t2 As Thread = New Thread(AddressOf Me.checkerThread2)
        Dim t3 As Thread = New Thread(AddressOf Me.checkerThread3)
        Dim t4 As Thread = New Thread(AddressOf Me.checkerThread4)
        Dim t5 As Thread = New Thread(AddressOf Me.checkerThread5)
        t1.IsBackground = True
        t2.IsBackground = True
        t3.IsBackground = True
        t4.IsBackground = True
        t5.IsBackground = True
        If Namestocheck.Items.Count < 10 Then
            t1.Start()
            t2.Start()
            t3.Start()
        Else
            t1.Start()
            t2.Start()
            t3.Start()
            t4.Start()
            t5.Start()
        End If
        tWatch.Start()
    End Sub

    Private Sub stopThreads() Handles StopToolStripMenuItem.Click
        killThreads = True

    End Sub

    Private Sub setStates()
        thread1End = False
        thread2End = False
        thread3End = False
        thread4End = False
        thread5End = False
        ProgressBar1.Maximum = Namestocheck.Items.Count
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0
    End Sub

    Private Sub splitBox(ByVal lb As ListBox)
        Dim i As Integer = lb.Items.Count
        Dim x As Integer = i / 5
        Dim i0 As Integer = 0

        listBox1.Items.Clear()
        listBox2.Items.Clear()
        listBox3.Items.Clear()
        listBox4.Items.Clear()
        listBox5.Items.Clear()

        If lb.Items.Count < 10 Then
            Dim x2 As Integer = i / 3
            For i0 = 0 To x2
                listBox1.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = 0 To x2 * 2
                listBox2.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = 0 To lb.Items.Count - 1
                listBox3.Items.Add(lb.Items.Item(i0))
            Next
        Else
            For i0 = 0 To x
                listBox1.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = x To x * 2
                listBox2.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = x * 2 To x * 3
                listBox3.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = x * 3 To x * 4
                listBox4.Items.Add(lb.Items.Item(i0))
            Next

            For i0 = x * 4 To lb.Items.Count - 1
                listBox5.Items.Add(lb.Items.Item(i0))
            Next

        End If
    End Sub

#End Region

#Region "Threads"
    'Thread variables
    'bools
    Private thread1End As Boolean = False
    Private thread2End As Boolean = False
    Private thread3End As Boolean = False
    Private thread4End As Boolean = False
    Private thread5End As Boolean = False
    'ints
    Private thread1Int As Integer = 0
    Private thread2Int As Integer = 0
    Private thread3Int As Integer = 0
    Private thread4Int As Integer = 0
    Private thread5Int As Integer = 0



    Private Sub checkerThread1()
        thread1Int = 0
        Dim wr As WebRequest
        Dim ins As StreamReader
        For Each item In listBox1.Items
            If killThreads Then
                Exit For
            End If
            thread1Int = thread1Int + 1
            If thread1Int >= listBox1.Items.Count Then
                thread1End = True
                Exit For
            End If
            Try
                progressBarValue = progressBarValue + 1
                wr = WebRequest.Create(cURL & item.ToString)
                ins = New StreamReader(wr.GetResponse().GetResponseStream())
                If ins.ReadToEnd.Contains(avString) Then
                    addName(item.ToString, True)
                Else
                    addName(item.ToString, False)
                End If
                ins.Close()
                wr.Abort()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        thread1End = True
    End Sub

    Private Sub checkerThread2()
        thread2Int = 0
        Dim wr As WebRequest
        Dim ins As StreamReader
        For Each item In listBox2.Items
            If killThreads Then
                Exit For
            End If
            thread2Int = thread2Int + 1
            If thread2Int >= listBox2.Items.Count Then
                thread2End = True
                Exit For
            End If
            Try
                progressBarValue = progressBarValue + 1
                wr = WebRequest.Create(cURL & item.ToString)
                ins = New StreamReader(wr.GetResponse().GetResponseStream())
                If ins.ReadToEnd.Contains(avString) Then
                    addName(item.ToString, True)
                Else
                    addName(item.ToString, False)
                End If
                ins.Close()
                wr.Abort()
            Catch ex As Exception
            End Try
        Next
        thread2End = True
    End Sub

    Private Sub checkerThread3()
        thread3Int = 0
        Dim wr As WebRequest
        Dim ins As StreamReader
        For Each item In listBox3.Items
            If killThreads Then
                Exit For
            End If
            thread3Int = thread3Int + 1
            If thread3Int >= listBox3.Items.Count Then
                thread3End = True
                Exit For
            End If
            Try
                progressBarValue = progressBarValue + 1
                wr = WebRequest.Create(cURL & item.ToString)
                ins = New StreamReader(wr.GetResponse().GetResponseStream())
                If ins.ReadToEnd.Contains(avString) Then
                    addName(item.ToString, True)
                Else
                    addName(item.ToString, False)
                End If
                ins.Close()
                wr.Abort()
            Catch ex As Exception
            End Try
        Next
        thread3End = True
    End Sub

    Private Sub checkerThread4()
        thread4Int = 0
        Dim wr As WebRequest
        Dim ins As StreamReader
        For Each item In listBox4.Items
            If killThreads Then
                Exit For
            End If
            thread4Int = thread4Int + 1
            If thread4Int >= listBox4.Items.Count Then
                thread4End = True
                Exit For
            End If
            Try
                progressBarValue = progressBarValue + 1
                wr = WebRequest.Create(cURL & item.ToString)
                ins = New StreamReader(wr.GetResponse().GetResponseStream())
                If ins.ReadToEnd.Contains(avString) Then
                    addName(item.ToString, True)
                Else
                    addName(item.ToString, False)
                End If
                ins.Close()
                wr.Abort()
            Catch ex As Exception
            End Try
        Next
        thread4End = True
    End Sub

    Private Sub checkerThread5()
        thread5Int = 0
        Dim wr As WebRequest
        Dim ins As StreamReader
        For Each item In listBox5.Items
            If killThreads Then
                Exit For
            End If
            thread5Int = thread5Int + 1
            If thread5Int >= listBox5.Items.Count Then
                thread5End = True
                Exit For
            End If
            Try
                progressBarValue = progressBarValue + 1
                wr = WebRequest.Create(cURL & item.ToString)
                ins = New StreamReader(wr.GetResponse().GetResponseStream())
                If ins.ReadToEnd.Contains(avString) Then
                    addName(item.ToString, True)
                Else
                    addName(item.ToString, False)
                End If
                ins.Close()
                wr.Abort()
            Catch ex As Exception
            End Try
        Next
        thread5End = True
    End Sub

    Private Sub timerThread()
        While True
            If thread1End And thread2End And thread3End And thread4End And thread5End Then
                tWatch.Stop()
                Dim ts As TimeSpan = TimeSpan.FromMilliseconds(tWatch.ElapsedMilliseconds)
                Dim hours As Integer = ts.TotalHours
                Dim minutes As Integer = ts.TotalMinutes
                Dim seconds As Integer = ts.TotalSeconds

                If hours > 0 Then
                    MessageBox.Show("Finished checking " + Namestocheck.Items.Count.ToString + " names in " + hours.ToString + " Hours:" + minutes.ToString + " Minutes:" + seconds.ToString + " Seconds!")
                Else
                    If minutes > 0 Then
                        MessageBox.Show("Finished checking " + Namestocheck.Items.Count.ToString + " names in " + minutes.ToString + " Minutes:" + seconds.ToString + " Seconds!")
                    Else
                        MessageBox.Show("Finished checking " + Namestocheck.Items.Count.ToString + " names in " + seconds.ToString + " Seconds!")
                    End If
                End If
                tWatch.Reset()
                thread1End = False
            Else
                Thread.Sleep(100)
            End If
        End While
    End Sub

    Private Sub pbarThread()
        While True
            pbarDo()
            Thread.Sleep(100)
        End While
    End Sub

#Region "Progressbar stuff"

    Private Delegate Sub DelegatePbar()
    Sub pbarDo()
        If ProgressBar1.InvokeRequired Then
            Dim d As New DelegatePbar(AddressOf pbarDo)
            ProgressBar1.Invoke(d)
        Else
            If thread1End = True Then
                ProgressBar1.Value = ProgressBar1.Maximum
            Else
                If progressBarValue > ProgressBar1.Maximum Then
                    ProgressBar1.Value = ProgressBar1.Maximum
                Else
                    ProgressBar1.Value = progressBarValue
                End If
            End If
            
        End If
    End Sub

#End Region

#End Region

#Region "Save/Load"
    Private Sub loadList() Handles LoadToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        If DialogResult.OK Then
            addNames(ofd.FileName.ToString)
        End If
    End Sub

    Private Sub saveList() Handles SaveToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Text Files | *.txt"
        If DialogResult.OK = True Then
            Dim out As StreamWriter = New StreamWriter(sfd.FileName.ToString)
            For Each item In Availablenames.Items
                out.WriteLine(item.ToString)
            Next
            out.Close()
        End If
    End Sub
#End Region

#Region "Add names to listbox"
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private Sub addNames(ByVal filePath As String)
        Dim tReader As TextReader = New StreamReader(filePath)
        Dim name As String = Nothing
        While (InlineAssignHelper(name, tReader.ReadLine())) IsNot Nothing
            If Namestocheck.Items.Contains(name) Then
            Else
                Namestocheck.Items.Add(name)
            End If
        End While
    End Sub

#Region "Add to taken/available"

    Private Delegate Sub DelegateaddName(ByVal name As String, ByVal taken As Boolean)
    Sub addName(ByVal name As String, ByVal taken As Boolean)
        If taken = False Then
            If Takennames.InvokeRequired Then
                Dim d As New DelegateaddName(AddressOf addName)
                Takennames.Invoke(d, name, False)
            Else
                Takennames.Items.Add(name)
            End If
        Else
            If Availablenames.InvokeRequired Then
                Dim d As New DelegateaddName(AddressOf addName)
                Availablenames.Invoke(d, name, True)
            Else
                Availablenames.Items.Add(name)
            End If
        End If
    End Sub

#End Region
#End Region


End Class
