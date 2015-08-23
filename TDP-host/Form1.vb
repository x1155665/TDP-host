Imports System.IO.Ports
Imports System.Drawing.Printing
Imports System.IO


Public Class Form1
    Dim WithEvents sp As New SerialPort
    Dim sliceDone As Boolean = False
    Dim printStop As Boolean = False
    Dim loadDone As Boolean = False
    Dim xHeight As Double
    Dim yHeight As Double
    Dim zHeight As Double
    Dim xHeightp As Double
    Dim yHeightp As Double
    Dim zHeightp As Double
    Dim maxLayer As Integer
    Dim pixel_per_mm_length As Integer = 11.8  '需要进一步测试
    Dim pixel_per_mm_width As Integer = 11.8
    Private Sub GetSerialPortNames()
        For Each serialport As String In My.Computer.Ports.SerialPortNames
            cmbPort.Items.Add(serialport)
        Next
    End Sub

    Private Sub GetModelProp()
        If modelLoc.FileName = "" Then
            loadDone = False
            Return
        End If      
        Shell("cmd /c slice " + modelLoc.FileName + " > " + Application.StartupPath + "/modelProp.txt & exit", AppWinStyle.Hide, True) '获取模型信息
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
            loadDone = True
        Else
            MessageBox.Show("list.txt does not exist", "ERROR")
            loadDone = False
        End If
    End Sub

    Private Function getValue(aString As String, ByVal tempStr As String)
        Dim pos As Integer = InStr(tempStr, """" + aString + """: ")
        pos += 6 '位置移动到数字第一位
        Dim srValue As String = ""
        Do Until tempStr.Chars(pos) = "."
            srValue += tempStr.Chars(pos)
            pos += 1
        Loop
        srValue += tempStr.Chars(pos) '小数点
        srValue += tempStr.Chars(pos + 1)
        srValue += tempStr.Chars(pos + 2)
        Dim value As Double
        Try
            value = CDbl(srValue)
        Catch
            MessageBox.Show("Slice error!")
            MessageBox.Show("Slice command:")
            MessageBox.Show("cmd /c slice " + modelLoc.FileName + " > " + Application.StartupPath + "/modelProp.txt")
        End Try
        Return value
    End Function

    Sub ShowString(ByVal myString As String)
        txtIn.AppendText(myString)
    End Sub

    Delegate Sub myMethodDelegate(ByVal [text] As String)
    Dim myDelegate As New myMethodDelegate(AddressOf ShowString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim BaudRates() As String = {"300", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "57600", "115200"}
        cmbBaud.Items.AddRange(BaudRates)
        cmbBaud.SelectedIndex = 4
        btnDisconnect.Visible = False
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
            Exit Sub
        Catch
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If sp.IsOpen() Then
            MessageBox.Show("Disconnect before closing")
            e.Cancel = True
        End If
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim str As String = sp.ReadExisting()
        Invoke(myDelegate, str)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If sp.IsOpen() Then
            sp.WriteLine(txtMessage.Text)
            txtMessage.Text = ""
        End If
    End Sub

    Private Sub txtMessage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMessage.KeyPress
        If Convert.ToInt32(e.KeyChar) = 13 Then btnSend_Click(sender, e)
    End Sub

    ' Specifies what happens when the user clicks the Button. 
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If sliceDone = False Then
            MessageBox.Show("Model not sliced yet!")
            Return
        End If
        btnStop.Visible = True
        btnPrint.Visible = False
        TrackBar1.Enabled = False
        Dim foundFile As String = ""
        Dim layer As Integer = 0
        Do Until layer >= maxLayer
            If printStop = True Then
                printStop = False
                Return
            End If
            TrackBar1.Value = layer
            Try
                pd.Print()
                'MessageBox.Show(layer)
            Catch ex As Exception
                MessageBox.Show("An error occurred while printing", ex.ToString())
            End Try
            layer += 1
        Loop

        Return
    End Sub

    ' Specifies what happens when the PrintPage event is raised. 
    Private Sub pd_PrintPage(sender As Object, ev As PrintPageEventArgs) Handles pd.PrintPage

        Dim margins As New Margins(100, 100, 100, 100)
        pd.DefaultPageSettings.Margins = margins



        ' Draw a picture.
        ev.Graphics.DrawImage(slice.Image, (100), (100))

        ' Indicate that this is the last page to print.
        ev.HasMorePages = False
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            GetSerialPortNames()
            cmbPort.SelectedIndex = 0
        Catch
            MsgBox("No ports connected.")
        End Try
    End Sub

    Private Sub btnChooseModel_Click(sender As Object, e As EventArgs) Handles btnChooseModel.Click
        modelLoc.ShowDialog() '选择模型
        Label5.Text = modelLoc.SafeFileName
        Label5.Visible = True
        sliceDone = False
        GetModelProp()
    End Sub

    Private Sub btnSlice_Click(sender As Object, e As EventArgs) Handles btnSlice.Click
        If loadDone = False Then
            MessageBox.Show("Model not loaded yet!")
            Return
        End If
        Try
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "/temp") Then '初始化工作文件夹
                My.Computer.FileSystem.DeleteDirectory(Application.StartupPath + "/temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/temp")
            Else
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/temp")
            End If
        Catch
            MessageBox.Show ("Folder initialization error!")
            loadDone = False
            Return
        End Try
        Shell("cmd /c slice -o " + Application.StartupPath + "/temp/slice.jpg -z0," + zHeight.ToString + "," + (CDbl(layerHeight.Text) / CDbl(txtScale.Text) * 100.0).ToString + " --height=" + Int(pixel_per_mm_length * yHeight).ToString + " --width=" + Int(pixel_per_mm_width * xHeight).ToString + " " + modelLoc.FileName + " & pause", AppWinStyle.NormalFocus, True) 'slice
        sliceDone = True
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

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        btnStop.Visible = False
        btnPrint.Visible = True
        printStop = True
    End Sub

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
        Label9.Text = xHeightp.ToString + "*" + yHeightp.ToString(+"*" + zHeightp.ToString)
    End Sub


End Class
