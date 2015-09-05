Imports System.IO.Ports
Imports System.Drawing.Printing
Imports System.IO
Imports System.Threading


Public Class Form1
    Dim WithEvents sp As New SerialPort
    Dim printThread As Thread
    Dim sliceDone As Boolean = False
    Dim loadDone As Boolean = False
    Dim xHeight As Double
    Dim yHeight As Double
    Dim zHeight As Double
    Dim xHeightp As Double
    Dim yHeightp As Double
    Dim zHeightp As Double
    Dim maxLayer As Integer
    Dim targetTemperature As Double
    Dim currentTemperature As Double
    Dim feederPos As Double
    Dim printbedPos As Double
    Dim pixel_per_mm_length As Integer = 11.8  'TBD
    Dim pixel_per_mm_width As Integer = 11.8    'TBD

    Dim isPosAcquired As Boolean = False

    Dim isCarriageHome As Boolean


    '=====================================================
    'Arduino communication
    'Reference:Visual Basic Serial Monitor (http://www.multiwingspan.co.uk/arduino.php?page=vb1 )

    Private Sub GetSerialPortNames()
        For Each serialport As String In My.Computer.Ports.SerialPortNames
            cmbPort.Items.Add(serialport)
        Next
    End Sub

    Sub ShowString(ByVal myString As String)
        'show the received string 
        'filter temperature checking,
        If InStr(myString, "current temperature:") + InStr(myString, "received:m105") + InStr(myString, "received:M105") = 0 Then
            If DisplayTheSentCommands.Checked = False Then
                If InStr(myString, "received:") = 0 Then
                    txtIn.AppendText(myString + Chr(10))
                End If
            Else
                txtIn.AppendText(myString + Chr(10))
            End If

        End If

        If InStr(myString, "current temperature:") <> 0 Then
            getTempVal(myString)
        End If
        If InStr(myString, "Current positions:") <> 0 Then
            getPosVal(myString)
        End If
        If InStr(myString, "x to home") <> 0 Then
            isCarriageHome = True
        End If
    End Sub

    Delegate Sub myMethodDelegate(ByVal [text] As String)
    Dim myDelegate As New myMethodDelegate(AddressOf ShowString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim BaudRates() As String = {"300", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "57600", "115200"}
        cmbBaud.Items.AddRange(BaudRates)
        cmbBaud.SelectedIndex = 4
        btnDisconnect.Visible = False
        btnSetTemp.Visible = False
        currentTemp.Visible = False

        Try
            GetSerialPortNames()
            cmbPort.SelectedIndex = 0
        Catch
        End Try
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            sp.BaudRate = cmbBaud.SelectedItem.ToString
            sp.PortName = cmbPort.SelectedItem.ToString
            sp.Open()
            If sp.IsOpen Then
                btnConnect.Visible = False
                cmbPort.Enabled = False
                cmbBaud.Enabled = False
                btnDisconnect.Visible = True

                'enable thermo control
                currentTemp.Visible = True
                btnSetTemp.Visible = True
                TimerCheckTemp.Enabled = True
            End If
        Catch
            sp.Close()
        End Try
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Try
            sp.Close()
            btnConnect.Visible = True
            btnDisconnect.Visible = False
            cmbPort.Enabled = True
            cmbBaud.Enabled = True
            btnSetTemp.Visible = False
            currentTemp.Visible = False
            TimerCheckTemp.Enabled = False
            Exit Sub
        Catch
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Try
            Dim str As String = sp.ReadLine()
            Invoke(myDelegate, str)
        Catch ex As Exception
            MessageBox.Show("Oops!Something happened when receiving messsage from Arduino:(")
        End Try
        
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If sp.IsOpen() Then
            sp.WriteLine(txtMessage.Text)
            txtMessage.Text = ""
        End If
    End Sub

    Private Sub txtMessage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMessage.KeyPress
        'so that the typed codes can be directly sent by pressing enter
        If Convert.ToInt32(e.KeyChar) = 13 Then btnSend_Click(sender, e)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            GetSerialPortNames()
            cmbPort.SelectedIndex = 0
        Catch
            MsgBox("No ports connected.")
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If sp.IsOpen() Then
            MessageBox.Show("Disconnect before closing")
            e.Cancel = True
        End If
        If printThread.IsAlive = True Then
            printThread.Abort()
        End If
    End Sub

    '=============================================
    'Printing

    Private Sub btnChooseModel_Click(sender As Object, e As EventArgs) Handles btnChooseModel.Click
        modelLoc.ShowDialog() 'show choosing dialog
        Label5.Text = modelLoc.SafeFileName 'Only the file name are shown, no path info
        Label5.Visible = True
        sliceDone = False
        GetModelProp()
    End Sub

    Private Sub GetModelProp()
        'Get the properties of the model: height, width, lehgth

        'Make sure that a model is already selected.
        If modelLoc.FileName = "" Then
            loadDone = False
            Return
        End If

        'Use Freesteel Slicer, which should be installed before running this function, to find out the properties of the model
        'More info about Fresteel Slicer: http://www.freesteel.co.uk/wpblog/slicer/
        'The output of Freesteel Slicer will be exported to a txt file named modelProp.txt, which will be analysed later
        Shell("cmd /c slice " + modelLoc.FileName + " > " + Application.StartupPath + "/modelProp.txt & exit", AppWinStyle.Hide, True)

        'Deal with modelProp.txt
        If File.Exists(Application.StartupPath + "/modelProp.txt") Then
            Dim srVar As StreamReader
            srVar = File.OpenText(Application.StartupPath + "/modelProp.txt")
            Dim tempStr As String = srVar.ReadToEnd()
            srVar.Close()
            xHeight = getValue("xhi", tempStr) - getValue("xlo", tempStr)
            yHeight = getValue("yhi", tempStr) - getValue("ylo", tempStr)
            zHeight = getValue("zhi", tempStr)
            Label9.Text = xHeight.ToString + " * " + yHeight.ToString + " * " + zHeight.ToString
            Label9.Visible = True
            txtScale.Text = "100"
            loadDone = True 'Enable the slice button
        Else
            MessageBox.Show("list.txt does not exist", "ERROR")
            loadDone = False
        End If
    End Sub

    Private Function getValue(aString As String, ByVal tempStr As String)
        'Get the value of aString？ Well, hard to explain. You will understand as soon as you check out modelProp.txt

        Dim pos As Integer = InStr(tempStr, """" + aString + """: ") 'Locate aString in tempStr
        pos += 6 'Locate the begin position of the value
        Dim srValue As String = ""
        Do Until tempStr.Chars(pos) = "."
            srValue += tempStr.Chars(pos)
            pos += 1
        Loop
        srValue += tempStr.Chars(pos) 'dot
        srValue += tempStr.Chars(pos + 1)
        srValue += tempStr.Chars(pos + 2)
        Dim value As Double
        Try
            value = CDbl(srValue)
        Catch
            MessageBox.Show("Slice error!")
            'When the tranformation of srValue to a number(double) goes wrong, Freesteel Slicer is the most possible suspect.
            MessageBox.Show("Slice command:")
            MessageBox.Show("cmd /c slice " + modelLoc.FileName + " > " + Application.StartupPath + "/modelProp.txt")
        End Try
        Return value
    End Function

    Private Sub txtScale_TextChanged(sender As Object, e As EventArgs) Handles txtScale.TextChanged
        If txtScale.Text = "" Then Return
        Dim Scale As Double
        Try
            Scale = CDbl(txtScale.Text)
        Catch
            Return
        End Try
        xHeightp = Int(xHeight * Scale) / 100.0
        yHeightp = Int(yHeight * Scale) / 100.0
        zHeightp = Int(zHeight * Scale) / 100.0
        Label9.Text = xHeightp.ToString + "*" + yHeightp.ToString + "*" + zHeightp.ToString
    End Sub

    Private Sub btnSlice_Click(sender As Object, e As EventArgs) Handles btnSlice.Click
        If loadDone = False Then
            MessageBox.Show("Model not loaded yet!")
            Return
        End If

        'Initialization of the working folder(./temp)
        Try
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "/temp") Then
                My.Computer.FileSystem.DeleteDirectory(Application.StartupPath + "/temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/temp")
            Else
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/temp")
            End If
        Catch
            MessageBox.Show("Folder initialization error!")
            loadDone = False
            Return
        End Try

        'Slice the model into pictures, the output jpg files are saved in the working folder
        Shell("cmd /c slice -o " + Application.StartupPath + "/temp/slice.jpg -z0," + zHeight.ToString + "," + (CDbl(layerHeight.Text) / CDbl(txtScale.Text) * 100.0).ToString + " --height=" + Int(pixel_per_mm_length * yHeight).ToString + " --width=" + Int(pixel_per_mm_width * xHeight).ToString + " " + modelLoc.FileName, AppWinStyle.NormalFocus, True) 'slice
        sliceDone = True 'Enable print button

        'Initialzation of slice preview
        maxLayer = Int(zHeight / (CDbl(layerHeight.Text) / CDbl(txtScale.Text) * 100.0))
        TrackBar1.Minimum = 0
        TrackBar1.Maximum = maxLayer
        TrackBar1.Enabled = True

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Dim layer As Integer = Int(TrackBar1.Value)
        Dim foundFileStr As String
        If layer < 10 Then
            foundFileStr = "*_000" + layer.ToString() + "*"
        ElseIf layer < 100 Then
            foundFileStr = "*_00" + layer.ToString() + "*"
        ElseIf layer < 1000 Then
            foundFileStr = "*_0" + layer.ToString() + "*"
        Else
            foundFileStr = "*_" + layer.ToString() + "*"
        End If
        Dim foundFile As String = ""
        For Each foundFile In My.Computer.FileSystem.GetFiles(Application.StartupPath + "/temp", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, foundFileStr)
        Next
        slice.ImageLocation = foundFile
        Label3.Text = "current layer:" + layer.ToString
        Label3.Visible = True
        Try
            slice.Load()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If sliceDone = False Then
            MessageBox.Show("Model not sliced yet!")
            Return
        End If
        If sp.IsOpen = False Then
            MessageBox.Show("Printer no connected yet!")
            Return
        End If
        btnStop.Visible = True
        btnPrint.Visible = False
        TrackBar1.Enabled = False

        If MessageBox.Show("Container already prepared?", "", MessageBoxButtons.YesNo) = 7 Then
            btnStop.Visible = False
            btnPrint.Visible = True
            TrackBar1.Enabled = True
            Return
        End If
        printThread = New Thread(AddressOf runPrint)
        printThread.Start()
    End Sub

    Private Sub runPrint()
        '+++++++++++++++++++++++++++++++++
        'Initial processes
        'Heating 
        'If the target temperature is not entered, it will be set to a default value (60).
        Try
            targetTemperature = CDbl(txtTargetTemp.Text)
            sp.WriteLine("M104 " + txtTargetTemp.Text)
        Catch ex As Exception
            MessageBox.Show("Warning! The target temperature was set to 60 by default!")
            SetText("60") 'thread-safe
            targetTemperature = 60
        End Try

        'Spreader
        sp.WriteLine("G0 R1")
        '++++++++++++++++++++++++++++++++++

        Dim layer As Integer = 0
        Do Until layer >= maxLayer
            '+++++++++++++++++++++++++++++++++++++
            'To do at every layer
            SetTrackbatVal(layer) 'thread-safe
            Try
                sp.WriteLine("G28 X")
                sp.WriteLine("m114")
                Do Until isPosAcquired = True
                    Application.DoEvents()
                Loop
                sp.WriteLine("G0 Y" + (printbedPos + CDbl(layerHeight.Text)).ToString)    'zero point at upper
                sp.WriteLine("G0 Z" + (feederPos - 2 * CDbl(layerHeight.Text)).ToString)  'zero point at upper

                'The following processes can be repeated to print more ink on one layer.
                '--------------------------------------------------
                sp.WriteLine("G28 X")  'home carriage
                Do Until isCarriageHome = True   'wait 
                    Application.DoEvents()
                Loop
                pd.Print()   'use windows printing interface to print the slice
                isCarriageHome = False
                '------------------------------------------------------

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "An error occurred while printing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            layer += 1
            '+++++++++++++++++++++++++++++++++++++++++
        Loop
        btnStop.Visible = False
        btnPrint.Visible = True
        TrackBar1.Enabled = True
    End Sub

    Delegate Sub SetTextCallback([text] As String)

    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If txtTargetTemp.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            txtTargetTemp.Text = [text]
        End If
    End Sub

    Delegate Sub SetTrackbatValCallback(layer As Integer)

    Private Sub SetTrackbatVal(ByVal layer As Integer)
        If TrackBar1.InvokeRequired Then
            Dim f As New SetTrackbatValCallback(AddressOf SetTrackbatVal)
            Me.Invoke(f, New Object() {layer})
        Else
            TrackBar1.Value = layer
        End If
    End Sub

    ' Specifies what happens when the PrintPage event is raised. 
    Private Sub pd_PrintPage(sender As Object, ev As PrintPageEventArgs) Handles pd.PrintPage
        'The detailed parameters are not determined yet!
        Dim margins As New Margins(100, 100, 100, 100)
        pd.DefaultPageSettings.Margins = margins

        ' Draw a picture.
        ev.Graphics.DrawImage(slice.Image, (100), (100))

        ' Indicate that this is the last page to print.
        ev.HasMorePages = False
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        printThread.Abort()
        btnStop.Visible = False
        btnPrint.Visible = True
        TrackBar1.Enabled = True
    End Sub

    '==================================
    'Thermo

    Private Sub btnSetTemp_Click(sender As Object, e As EventArgs) Handles btnSetTemp.Click
        Try
            targetTemperature = CDbl(txtTargetTemp.Text)
            sp.WriteLine("M104 " + txtTargetTemp.Text) 'M104
        Catch ex As Exception
            MessageBox.Show("Please enter the target Temperature!")
        End Try
    End Sub

    Private Sub TimerCheckTemp_Tick(sender As Object, e As EventArgs) Handles TimerCheckTemp.Tick
        sp.WriteLine("M105")
    End Sub

    Private Sub getTempVal(ByVal Tempstr As String)
        '（The received codes should be like: "current temperature:60.00")
        currentTemp.Text = ""
        Dim pos As Integer = 20
        Do Until pos >= Tempstr.Length
            currentTemp.Text += Tempstr.Chars(pos)
            pos += 1
        Loop
    End Sub

    '==================================
    'position（The received codes should be like:"Current positions: X:0.00 Y:0.00 Z:0.00 E:0.00"） 

    Private Sub getPosVal(myString As String)
        Dim tempStr As String = ""
        Dim readPos As Integer = InStr(myString, "Y") 'locate "Y"
        readPos += 1 'locate val
        Do Until myString.Chars(readPos) = " "
            tempStr += myString.Chars(readPos)
            readPos += 1
        Loop
        printbedPos = CDbl(tempStr)
        labelPrintbedPos.Text = tempStr

        tempStr = ""
        readPos = InStr(myString, "Z") 'Locate "Z"
        readPos += 1 'locate val
        Do Until myString.Chars(readPos) = " "
            tempStr += myString.Chars(readPos)
            readPos += 1
        Loop
        feederPos = CDbl(tempStr)
        labelFeederPos.Text = tempStr

        isPosAcquired = True
    End Sub

End Class
