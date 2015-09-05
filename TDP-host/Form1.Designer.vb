<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBaud = New System.Windows.Forms.ComboBox()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.txtIn = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.pd = New System.Drawing.Printing.PrintDocument()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.slice = New System.Windows.Forms.PictureBox()
        Me.modelLoc = New System.Windows.Forms.OpenFileDialog()
        Me.btnChooseModel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.layerHeight = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSlice = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtScale = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTargetTemp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.currentTemp = New System.Windows.Forms.Label()
        Me.btnSetTemp = New System.Windows.Forms.Button()
        Me.TimerCheckTemp = New System.Windows.Forms.Timer(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.labelPrintbedPos = New System.Windows.Forms.Label()
        Me.labelFeederPos = New System.Windows.Forms.Label()
        Me.DisplayTheSentCommands = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.slice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnDisconnect)
        Me.GroupBox1.Controls.Add(Me.btnConnect)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbBaud)
        Me.GroupBox1.Controls.Add(Me.cmbPort)
        Me.GroupBox1.Location = New System.Drawing.Point(423, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 76)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(295, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(295, 43)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.btnDisconnect.TabIndex = 5
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(295, 43)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "BAUD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "COM"
        '
        'cmbBaud
        '
        Me.cmbBaud.FormattingEnabled = True
        Me.cmbBaud.Location = New System.Drawing.Point(157, 46)
        Me.cmbBaud.Name = "cmbBaud"
        Me.cmbBaud.Size = New System.Drawing.Size(121, 20)
        Me.cmbBaud.TabIndex = 1
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(157, 20)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(121, 20)
        Me.cmbPort.TabIndex = 0
        '
        'txtIn
        '
        Me.txtIn.Location = New System.Drawing.Point(423, 117)
        Me.txtIn.Multiline = True
        Me.txtIn.Name = "txtIn"
        Me.txtIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtIn.Size = New System.Drawing.Size(395, 290)
        Me.txtIn.TabIndex = 1
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(423, 415)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(313, 21)
        Me.txtMessage.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(742, 413)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'pd
        '
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(279, 330)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'slice
        '
        Me.slice.Location = New System.Drawing.Point(28, 117)
        Me.slice.Name = "slice"
        Me.slice.Size = New System.Drawing.Size(330, 195)
        Me.slice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.slice.TabIndex = 5
        Me.slice.TabStop = False
        '
        'modelLoc
        '
        Me.modelLoc.Filter = "模型文件(*.stl)|*.stl"
        '
        'btnChooseModel
        '
        Me.btnChooseModel.Location = New System.Drawing.Point(279, 7)
        Me.btnChooseModel.Name = "btnChooseModel"
        Me.btnChooseModel.Size = New System.Drawing.Size(75, 23)
        Me.btnChooseModel.TabIndex = 6
        Me.btnChooseModel.Text = "Load Model"
        Me.btnChooseModel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "none"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Layer Height:"
        '
        'layerHeight
        '
        Me.layerHeight.Location = New System.Drawing.Point(279, 90)
        Me.layerHeight.Name = "layerHeight"
        Me.layerHeight.Size = New System.Drawing.Size(54, 21)
        Me.layerHeight.TabIndex = 11
        Me.layerHeight.Text = "0.1"
        Me.layerHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(339, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 12)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Model Size:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(244, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "null"
        Me.Label9.Visible = False
        '
        'btnSlice
        '
        Me.btnSlice.Location = New System.Drawing.Point(26, 330)
        Me.btnSlice.Name = "btnSlice"
        Me.btnSlice.Size = New System.Drawing.Size(75, 23)
        Me.btnSlice.TabIndex = 16
        Me.btnSlice.Text = "Slice"
        Me.btnSlice.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(107, 330)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(153, 45)
        Me.TrackBar1.TabIndex = 17
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(279, 330)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 18
        Me.btnStop.Text = "STOP"
        Me.btnStop.UseVisualStyleBackColor = True
        Me.btnStop.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Scale:"
        '
        'txtScale
        '
        Me.txtScale.Location = New System.Drawing.Point(281, 63)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Size = New System.Drawing.Size(52, 21)
        Me.txtScale.TabIndex = 20
        Me.txtScale.Text = "100"
        Me.txtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(343, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 315)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'txtTargetTemp
        '
        Me.txtTargetTemp.Location = New System.Drawing.Point(203, 391)
        Me.txtTargetTemp.Name = "txtTargetTemp"
        Me.txtTargetTemp.Size = New System.Drawing.Size(45, 21)
        Me.txtTargetTemp.TabIndex = 23
        Me.txtTargetTemp.Text = "60"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 395)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 12)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Target temperature"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 372)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 12)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Current temperature"
        '
        'currentTemp
        '
        Me.currentTemp.AutoSize = True
        Me.currentTemp.Location = New System.Drawing.Point(206, 372)
        Me.currentTemp.Name = "currentTemp"
        Me.currentTemp.Size = New System.Drawing.Size(0, 12)
        Me.currentTemp.TabIndex = 26
        '
        'btnSetTemp
        '
        Me.btnSetTemp.Location = New System.Drawing.Point(285, 389)
        Me.btnSetTemp.Name = "btnSetTemp"
        Me.btnSetTemp.Size = New System.Drawing.Size(73, 23)
        Me.btnSetTemp.TabIndex = 27
        Me.btnSetTemp.Text = "Set"
        Me.btnSetTemp.UseVisualStyleBackColor = True
        '
        'TimerCheckTemp
        '
        Me.TimerCheckTemp.Interval = 1000
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 415)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 12)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Height:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(105, 415)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 12)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Bottom of printing zone"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(105, 433)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 12)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Bottom of feeder"
        '
        'labelPrintbedPos
        '
        Me.labelPrintbedPos.AutoSize = True
        Me.labelPrintbedPos.Location = New System.Drawing.Point(286, 415)
        Me.labelPrintbedPos.Name = "labelPrintbedPos"
        Me.labelPrintbedPos.Size = New System.Drawing.Size(0, 12)
        Me.labelPrintbedPos.TabIndex = 31
        '
        'labelFeederPos
        '
        Me.labelFeederPos.AutoSize = True
        Me.labelFeederPos.Location = New System.Drawing.Point(286, 433)
        Me.labelFeederPos.Name = "labelFeederPos"
        Me.labelFeederPos.Size = New System.Drawing.Size(0, 12)
        Me.labelFeederPos.TabIndex = 32
        '
        'DisplayTheSentCommands
        '
        Me.DisplayTheSentCommands.AutoSize = True
        Me.DisplayTheSentCommands.Location = New System.Drawing.Point(423, 95)
        Me.DisplayTheSentCommands.Name = "DisplayTheSentCommands"
        Me.DisplayTheSentCommands.Size = New System.Drawing.Size(174, 16)
        Me.DisplayTheSentCommands.TabIndex = 34
        Me.DisplayTheSentCommands.Text = "Display the sent commands"
        Me.ToolTip1.SetToolTip(Me.DisplayTheSentCommands, "Ignore temperature checking command (m105)")
        Me.DisplayTheSentCommands.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 454)
        Me.Controls.Add(Me.DisplayTheSentCommands)
        Me.Controls.Add(Me.labelFeederPos)
        Me.Controls.Add(Me.labelPrintbedPos)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnSetTemp)
        Me.Controls.Add(Me.currentTemp)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTargetTemp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtScale)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.btnSlice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.layerHeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnChooseModel)
        Me.Controls.Add(Me.slice)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtIn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "TPD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.slice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtIn As System.Windows.Forms.TextBox
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents pd As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents slice As System.Windows.Forms.PictureBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents modelLoc As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnChooseModel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents layerHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSlice As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtScale As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTargetTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents currentTemp As System.Windows.Forms.Label
    Friend WithEvents btnSetTemp As System.Windows.Forms.Button
    Friend WithEvents TimerCheckTemp As System.Windows.Forms.Timer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents labelPrintbedPos As System.Windows.Forms.Label
    Friend WithEvents labelFeederPos As System.Windows.Forms.Label
    Friend WithEvents DisplayTheSentCommands As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
