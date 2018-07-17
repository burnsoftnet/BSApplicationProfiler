<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDBHost = New System.Windows.Forms.TextBox()
        Me.txtDBNAME = New System.Windows.Forms.TextBox()
        Me.txtUID = New System.Windows.Forms.TextBox()
        Me.txtPWD = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbBugMode = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.nudDBResfreh = New System.Windows.Forms.NumericUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.nudHeartBeat = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.nudTimer = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.nudEventError = New System.Windows.Forms.NumericUpDown()
        Me.nudEventWarning = New System.Windows.Forms.NumericUpDown()
        Me.nudEventInfo = New System.Windows.Forms.NumericUpDown()
        Me.txtEventSource = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkNTEvent = New System.Windows.Forms.CheckBox()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
        Me.txtLogFile = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkLogFile = New System.Windows.Forms.CheckBox()
        Me.chkConsole = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cmbBugModeAM = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.nudTimerAM = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.nudEventErrorAM = New System.Windows.Forms.NumericUpDown()
        Me.nudEventWarningAM = New System.Windows.Forms.NumericUpDown()
        Me.nudEventInfoAM = New System.Windows.Forms.NumericUpDown()
        Me.txtEventSourceAM = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkNTEventAM = New System.Windows.Forms.CheckBox()
        Me.txtDebugAM = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.chkDebugAM = New System.Windows.Forms.CheckBox()
        Me.txtLogFileAM = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkLogFileAM = New System.Windows.Forms.CheckBox()
        Me.chkConsoleAM = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.cmbBugModeDD = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.chkNTEventDD = New System.Windows.Forms.CheckBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.nudEventErrorDD = New System.Windows.Forms.NumericUpDown()
        Me.nudEventWarningDD = New System.Windows.Forms.NumericUpDown()
        Me.nudEventInfoDD = New System.Windows.Forms.NumericUpDown()
        Me.txtEventSourceDD = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtDebugDD = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.chkDebugDD = New System.Windows.Forms.CheckBox()
        Me.txtLogFileDD = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chkLogFileDD = New System.Windows.Forms.CheckBox()
        Me.chkConsoleDD = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.chkOffLine = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.nudDBResfreh,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudHeartBeat,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudTimer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventError,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventWarning,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventInfo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage3.SuspendLayout
        CType(Me.nudTimerAM,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventErrorAM,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventWarningAM,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventInfoAM,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage4.SuspendLayout
        CType(Me.nudEventErrorDD,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventWarningDD,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.nudEventInfoDD,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.SaveExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(687, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(45, 24)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'SaveExitToolStripMenuItem
        '
        Me.SaveExitToolStripMenuItem.Name = "SaveExitToolStripMenuItem"
        Me.SaveExitToolStripMenuItem.Size = New System.Drawing.Size(96, 24)
        Me.SaveExitToolStripMenuItem.Text = "&Save && Exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database Host:"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(8, 87)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Database Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(343, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "User Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(343, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password:"
        '
        'txtDBHost
        '
        Me.txtDBHost.Location = New System.Drawing.Point(125, 51)
        Me.txtDBHost.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDBHost.Name = "txtDBHost"
        Me.txtDBHost.Size = New System.Drawing.Size(191, 22)
        Me.txtDBHost.TabIndex = 4
        '
        'txtDBNAME
        '
        Me.txtDBNAME.Location = New System.Drawing.Point(125, 83)
        Me.txtDBNAME.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDBNAME.Name = "txtDBNAME"
        Me.txtDBNAME.Size = New System.Drawing.Size(191, 22)
        Me.txtDBNAME.TabIndex = 5
        '
        'txtUID
        '
        Me.txtUID.Location = New System.Drawing.Point(435, 47)
        Me.txtUID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUID.Name = "txtUID"
        Me.txtUID.Size = New System.Drawing.Size(185, 22)
        Me.txtUID.TabIndex = 6
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(435, 83)
        Me.txtPWD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(185, 22)
        Me.txtPWD.TabIndex = 7
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 34)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(688, 370)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkOffLine)
        Me.TabPage1.Controls.Add(Me.Label42)
        Me.TabPage1.Controls.Add(Me.txtPWD)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtUID)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDBNAME)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtDBHost)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(680, 341)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Database"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmbBugMode)
        Me.TabPage2.Controls.Add(Me.Label39)
        Me.TabPage2.Controls.Add(Me.nudDBResfreh)
        Me.TabPage2.Controls.Add(Me.Label38)
        Me.TabPage2.Controls.Add(Me.nudHeartBeat)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.nudTimer)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.nudEventError)
        Me.TabPage2.Controls.Add(Me.nudEventWarning)
        Me.TabPage2.Controls.Add(Me.nudEventInfo)
        Me.TabPage2.Controls.Add(Me.txtEventSource)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.chkNTEvent)
        Me.TabPage2.Controls.Add(Me.txtDebug)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.chkDebug)
        Me.TabPage2.Controls.Add(Me.txtLogFile)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.chkLogFile)
        Me.TabPage2.Controls.Add(Me.chkConsole)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(680, 341)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Application Profiler"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'cmbBugMode
        '
        Me.cmbBugMode.FormattingEnabled = true
        Me.cmbBugMode.Items.AddRange(New Object() {"low", "medium", "high"})
        Me.cmbBugMode.Location = New System.Drawing.Point(149, 103)
        Me.cmbBugMode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbBugMode.Name = "cmbBugMode"
        Me.cmbBugMode.Size = New System.Drawing.Size(160, 24)
        Me.cmbBugMode.TabIndex = 29
        Me.cmbBugMode.Text = "low"
        '
        'Label39
        '
        Me.Label39.AutoSize = true
        Me.Label39.Location = New System.Drawing.Point(12, 103)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(93, 17)
        Me.Label39.TabIndex = 28
        Me.Label39.Text = "Debug Mode:"
        '
        'nudDBResfreh
        '
        Me.nudDBResfreh.Location = New System.Drawing.Point(505, 138)
        Me.nudDBResfreh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudDBResfreh.Name = "nudDBResfreh"
        Me.nudDBResfreh.Size = New System.Drawing.Size(160, 22)
        Me.nudDBResfreh.TabIndex = 27
        '
        'Label38
        '
        Me.Label38.AutoSize = true
        Me.Label38.Location = New System.Drawing.Point(319, 140)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(177, 17)
        Me.Label38.TabIndex = 26
        Me.Label38.Text = "Database Refresh Interval:"
        '
        'nudHeartBeat
        '
        Me.nudHeartBeat.Location = New System.Drawing.Point(151, 138)
        Me.nudHeartBeat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudHeartBeat.Name = "nudHeartBeat"
        Me.nudHeartBeat.Size = New System.Drawing.Size(160, 22)
        Me.nudHeartBeat.TabIndex = 25
        '
        'Label27
        '
        Me.Label27.AutoSize = true
        Me.Label27.Location = New System.Drawing.Point(12, 140)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(125, 17)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "Heartbeat Interval:"
        '
        'nudTimer
        '
        Me.nudTimer.Location = New System.Drawing.Point(397, 10)
        Me.nudTimer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudTimer.Name = "nudTimer"
        Me.nudTimer.Size = New System.Drawing.Size(211, 22)
        Me.nudTimer.TabIndex = 23
        Me.nudTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = true
        Me.Label15.Location = New System.Drawing.Point(221, 14)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 17)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Timer Interval In Minutes:"
        '
        'nudEventError
        '
        Me.nudEventError.Location = New System.Drawing.Point(151, 267)
        Me.nudEventError.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventError.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventError.Name = "nudEventError"
        Me.nudEventError.Size = New System.Drawing.Size(160, 22)
        Me.nudEventError.TabIndex = 21
        Me.nudEventError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventWarning
        '
        Me.nudEventWarning.Location = New System.Drawing.Point(489, 235)
        Me.nudEventWarning.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventWarning.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventWarning.Name = "nudEventWarning"
        Me.nudEventWarning.Size = New System.Drawing.Size(160, 22)
        Me.nudEventWarning.TabIndex = 20
        Me.nudEventWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventInfo
        '
        Me.nudEventInfo.Location = New System.Drawing.Point(151, 235)
        Me.nudEventInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventInfo.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventInfo.Name = "nudEventInfo"
        Me.nudEventInfo.Size = New System.Drawing.Size(160, 22)
        Me.nudEventInfo.TabIndex = 19
        Me.nudEventInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEventSource
        '
        Me.txtEventSource.Location = New System.Drawing.Point(151, 203)
        Me.txtEventSource.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEventSource.Name = "txtEventSource"
        Me.txtEventSource.Size = New System.Drawing.Size(251, 22)
        Me.txtEventSource.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = true
        Me.Label14.Location = New System.Drawing.Point(16, 270)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 17)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Event ID Error:"
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Location = New System.Drawing.Point(355, 238)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 17)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Event ID Warning:"
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Location = New System.Drawing.Point(15, 238)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 17)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Event ID Info:"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(16, 207)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Event Source:"
        '
        'chkNTEvent
        '
        Me.chkNTEvent.AutoSize = true
        Me.chkNTEvent.Location = New System.Drawing.Point(151, 172)
        Me.chkNTEvent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNTEvent.Name = "chkNTEvent"
        Me.chkNTEvent.Size = New System.Drawing.Size(54, 21)
        Me.chkNTEvent.TabIndex = 11
        Me.chkNTEvent.Text = "Yes"
        Me.chkNTEvent.UseVisualStyleBackColor = true
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(317, 70)
        Me.txtDebug.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.Size = New System.Drawing.Size(315, 22)
        Me.txtDebug.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(221, 74)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 17)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Debug File:"
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = true
        Me.chkDebug.Location = New System.Drawing.Point(149, 75)
        Me.chkDebug.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(54, 21)
        Me.chkDebug.TabIndex = 8
        Me.chkDebug.Text = "Yes"
        Me.chkDebug.UseVisualStyleBackColor = true
        '
        'txtLogFile
        '
        Me.txtLogFile.Location = New System.Drawing.Point(317, 38)
        Me.txtLogFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.Size = New System.Drawing.Size(315, 22)
        Me.txtLogFile.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(221, 42)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 17)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "LogFile:"
        '
        'chkLogFile
        '
        Me.chkLogFile.AutoSize = true
        Me.chkLogFile.Location = New System.Drawing.Point(149, 42)
        Me.chkLogFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLogFile.Name = "chkLogFile"
        Me.chkLogFile.Size = New System.Drawing.Size(54, 21)
        Me.chkLogFile.TabIndex = 5
        Me.chkLogFile.Text = "Yes"
        Me.chkLogFile.UseVisualStyleBackColor = true
        '
        'chkConsole
        '
        Me.chkConsole.AutoSize = true
        Me.chkConsole.Location = New System.Drawing.Point(149, 14)
        Me.chkConsole.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkConsole.Name = "chkConsole"
        Me.chkConsole.Size = New System.Drawing.Size(54, 21)
        Me.chkConsole.TabIndex = 4
        Me.chkConsole.Text = "Yes"
        Me.chkConsole.UseVisualStyleBackColor = true
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(15, 177)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Use EventLog?"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(11, 75)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Debug Mode?"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(12, 43)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Use Log File?"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(11, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Use Console?"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmbBugModeAM)
        Me.TabPage3.Controls.Add(Me.Label40)
        Me.TabPage3.Controls.Add(Me.nudTimerAM)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.nudEventErrorAM)
        Me.TabPage3.Controls.Add(Me.nudEventWarningAM)
        Me.TabPage3.Controls.Add(Me.nudEventInfoAM)
        Me.TabPage3.Controls.Add(Me.txtEventSourceAM)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.chkNTEventAM)
        Me.TabPage3.Controls.Add(Me.txtDebugAM)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.chkDebugAM)
        Me.TabPage3.Controls.Add(Me.txtLogFileAM)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.chkLogFileAM)
        Me.TabPage3.Controls.Add(Me.chkConsoleAM)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Size = New System.Drawing.Size(680, 341)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Application Monitor"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'cmbBugModeAM
        '
        Me.cmbBugModeAM.FormattingEnabled = true
        Me.cmbBugModeAM.Items.AddRange(New Object() {"low", "medium", "high"})
        Me.cmbBugModeAM.Location = New System.Drawing.Point(128, 106)
        Me.cmbBugModeAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbBugModeAM.Name = "cmbBugModeAM"
        Me.cmbBugModeAM.Size = New System.Drawing.Size(160, 24)
        Me.cmbBugModeAM.TabIndex = 47
        Me.cmbBugModeAM.Text = "low"
        '
        'Label40
        '
        Me.Label40.AutoSize = true
        Me.Label40.Location = New System.Drawing.Point(12, 106)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(93, 17)
        Me.Label40.TabIndex = 46
        Me.Label40.Text = "Debug Mode:"
        '
        'nudTimerAM
        '
        Me.nudTimerAM.Location = New System.Drawing.Point(376, 15)
        Me.nudTimerAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudTimerAM.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudTimerAM.Name = "nudTimerAM"
        Me.nudTimerAM.Size = New System.Drawing.Size(211, 22)
        Me.nudTimerAM.TabIndex = 45
        Me.nudTimerAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Location = New System.Drawing.Point(200, 18)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 17)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Timer Interval In ms:"
        '
        'nudEventErrorAM
        '
        Me.nudEventErrorAM.Location = New System.Drawing.Point(128, 230)
        Me.nudEventErrorAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventErrorAM.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventErrorAM.Name = "nudEventErrorAM"
        Me.nudEventErrorAM.Size = New System.Drawing.Size(160, 22)
        Me.nudEventErrorAM.TabIndex = 43
        Me.nudEventErrorAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventWarningAM
        '
        Me.nudEventWarningAM.Location = New System.Drawing.Point(485, 198)
        Me.nudEventWarningAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventWarningAM.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventWarningAM.Name = "nudEventWarningAM"
        Me.nudEventWarningAM.Size = New System.Drawing.Size(160, 22)
        Me.nudEventWarningAM.TabIndex = 42
        Me.nudEventWarningAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventInfoAM
        '
        Me.nudEventInfoAM.Location = New System.Drawing.Point(128, 198)
        Me.nudEventInfoAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventInfoAM.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventInfoAM.Name = "nudEventInfoAM"
        Me.nudEventInfoAM.Size = New System.Drawing.Size(160, 22)
        Me.nudEventInfoAM.TabIndex = 41
        Me.nudEventInfoAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEventSourceAM
        '
        Me.txtEventSourceAM.Location = New System.Drawing.Point(128, 166)
        Me.txtEventSourceAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEventSourceAM.Name = "txtEventSourceAM"
        Me.txtEventSourceAM.Size = New System.Drawing.Size(251, 22)
        Me.txtEventSourceAM.TabIndex = 40
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Location = New System.Drawing.Point(12, 233)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 17)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Event ID Error:"
        '
        'Label18
        '
        Me.Label18.AutoSize = true
        Me.Label18.Location = New System.Drawing.Point(351, 201)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(122, 17)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Event ID Warning:"
        '
        'Label19
        '
        Me.Label19.AutoSize = true
        Me.Label19.Location = New System.Drawing.Point(11, 201)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 17)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Event ID Info:"
        '
        'Label20
        '
        Me.Label20.AutoSize = true
        Me.Label20.Location = New System.Drawing.Point(12, 170)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 17)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Event Source:"
        '
        'chkNTEventAM
        '
        Me.chkNTEventAM.AutoSize = true
        Me.chkNTEventAM.Location = New System.Drawing.Point(128, 139)
        Me.chkNTEventAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNTEventAM.Name = "chkNTEventAM"
        Me.chkNTEventAM.Size = New System.Drawing.Size(54, 21)
        Me.chkNTEventAM.TabIndex = 35
        Me.chkNTEventAM.Text = "Yes"
        Me.chkNTEventAM.UseVisualStyleBackColor = true
        '
        'txtDebugAM
        '
        Me.txtDebugAM.Location = New System.Drawing.Point(296, 75)
        Me.txtDebugAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDebugAM.Name = "txtDebugAM"
        Me.txtDebugAM.Size = New System.Drawing.Size(315, 22)
        Me.txtDebugAM.TabIndex = 34
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Location = New System.Drawing.Point(200, 79)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 17)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Debug File:"
        '
        'chkDebugAM
        '
        Me.chkDebugAM.AutoSize = true
        Me.chkDebugAM.Location = New System.Drawing.Point(128, 80)
        Me.chkDebugAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDebugAM.Name = "chkDebugAM"
        Me.chkDebugAM.Size = New System.Drawing.Size(54, 21)
        Me.chkDebugAM.TabIndex = 32
        Me.chkDebugAM.Text = "Yes"
        Me.chkDebugAM.UseVisualStyleBackColor = true
        '
        'txtLogFileAM
        '
        Me.txtLogFileAM.Location = New System.Drawing.Point(296, 43)
        Me.txtLogFileAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLogFileAM.Name = "txtLogFileAM"
        Me.txtLogFileAM.Size = New System.Drawing.Size(315, 22)
        Me.txtLogFileAM.TabIndex = 31
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Location = New System.Drawing.Point(200, 47)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 17)
        Me.Label22.TabIndex = 30
        Me.Label22.Text = "LogFile:"
        '
        'chkLogFileAM
        '
        Me.chkLogFileAM.AutoSize = true
        Me.chkLogFileAM.Location = New System.Drawing.Point(128, 47)
        Me.chkLogFileAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLogFileAM.Name = "chkLogFileAM"
        Me.chkLogFileAM.Size = New System.Drawing.Size(54, 21)
        Me.chkLogFileAM.TabIndex = 29
        Me.chkLogFileAM.Text = "Yes"
        Me.chkLogFileAM.UseVisualStyleBackColor = true
        '
        'chkConsoleAM
        '
        Me.chkConsoleAM.AutoSize = true
        Me.chkConsoleAM.Location = New System.Drawing.Point(128, 18)
        Me.chkConsoleAM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkConsoleAM.Name = "chkConsoleAM"
        Me.chkConsoleAM.Size = New System.Drawing.Size(54, 21)
        Me.chkConsoleAM.TabIndex = 28
        Me.chkConsoleAM.Text = "Yes"
        Me.chkConsoleAM.UseVisualStyleBackColor = true
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Location = New System.Drawing.Point(12, 140)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(105, 17)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "Use EventLog?"
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Location = New System.Drawing.Point(11, 79)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(97, 17)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Debug Mode?"
        '
        'Label25
        '
        Me.Label25.AutoSize = true
        Me.Label25.Location = New System.Drawing.Point(12, 47)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 17)
        Me.Label25.TabIndex = 25
        Me.Label25.Text = "Use Log File?"
        '
        'Label26
        '
        Me.Label26.AutoSize = true
        Me.Label26.Location = New System.Drawing.Point(11, 18)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 17)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Use Console?"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.cmbBugModeDD)
        Me.TabPage4.Controls.Add(Me.Label34)
        Me.TabPage4.Controls.Add(Me.chkNTEventDD)
        Me.TabPage4.Controls.Add(Me.Label41)
        Me.TabPage4.Controls.Add(Me.nudEventErrorDD)
        Me.TabPage4.Controls.Add(Me.nudEventWarningDD)
        Me.TabPage4.Controls.Add(Me.nudEventInfoDD)
        Me.TabPage4.Controls.Add(Me.txtEventSourceDD)
        Me.TabPage4.Controls.Add(Me.Label28)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.Label31)
        Me.TabPage4.Controls.Add(Me.txtDebugDD)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.chkDebugDD)
        Me.TabPage4.Controls.Add(Me.txtLogFileDD)
        Me.TabPage4.Controls.Add(Me.Label33)
        Me.TabPage4.Controls.Add(Me.chkLogFileDD)
        Me.TabPage4.Controls.Add(Me.chkConsoleDD)
        Me.TabPage4.Controls.Add(Me.Label35)
        Me.TabPage4.Controls.Add(Me.Label36)
        Me.TabPage4.Controls.Add(Me.Label37)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Size = New System.Drawing.Size(680, 341)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Data Dump"
        Me.TabPage4.UseVisualStyleBackColor = true
        '
        'cmbBugModeDD
        '
        Me.cmbBugModeDD.FormattingEnabled = true
        Me.cmbBugModeDD.Items.AddRange(New Object() {"low", "medium", "high"})
        Me.cmbBugModeDD.Location = New System.Drawing.Point(128, 113)
        Me.cmbBugModeDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbBugModeDD.Name = "cmbBugModeDD"
        Me.cmbBugModeDD.Size = New System.Drawing.Size(160, 24)
        Me.cmbBugModeDD.TabIndex = 69
        Me.cmbBugModeDD.Text = "low"
        '
        'Label34
        '
        Me.Label34.AutoSize = true
        Me.Label34.Location = New System.Drawing.Point(12, 117)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(93, 17)
        Me.Label34.TabIndex = 68
        Me.Label34.Text = "Debug Mode:"
        '
        'chkNTEventDD
        '
        Me.chkNTEventDD.AutoSize = true
        Me.chkNTEventDD.Location = New System.Drawing.Point(128, 146)
        Me.chkNTEventDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkNTEventDD.Name = "chkNTEventDD"
        Me.chkNTEventDD.Size = New System.Drawing.Size(54, 21)
        Me.chkNTEventDD.TabIndex = 67
        Me.chkNTEventDD.Text = "Yes"
        Me.chkNTEventDD.UseVisualStyleBackColor = true
        '
        'Label41
        '
        Me.Label41.AutoSize = true
        Me.Label41.Location = New System.Drawing.Point(12, 148)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(105, 17)
        Me.Label41.TabIndex = 66
        Me.Label41.Text = "Use EventLog?"
        '
        'nudEventErrorDD
        '
        Me.nudEventErrorDD.Location = New System.Drawing.Point(128, 242)
        Me.nudEventErrorDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventErrorDD.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventErrorDD.Name = "nudEventErrorDD"
        Me.nudEventErrorDD.Size = New System.Drawing.Size(160, 22)
        Me.nudEventErrorDD.TabIndex = 65
        Me.nudEventErrorDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventWarningDD
        '
        Me.nudEventWarningDD.Location = New System.Drawing.Point(485, 210)
        Me.nudEventWarningDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventWarningDD.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventWarningDD.Name = "nudEventWarningDD"
        Me.nudEventWarningDD.Size = New System.Drawing.Size(160, 22)
        Me.nudEventWarningDD.TabIndex = 64
        Me.nudEventWarningDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudEventInfoDD
        '
        Me.nudEventInfoDD.Location = New System.Drawing.Point(128, 210)
        Me.nudEventInfoDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudEventInfoDD.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudEventInfoDD.Name = "nudEventInfoDD"
        Me.nudEventInfoDD.Size = New System.Drawing.Size(160, 22)
        Me.nudEventInfoDD.TabIndex = 63
        Me.nudEventInfoDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEventSourceDD
        '
        Me.txtEventSourceDD.Location = New System.Drawing.Point(128, 178)
        Me.txtEventSourceDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEventSourceDD.Name = "txtEventSourceDD"
        Me.txtEventSourceDD.Size = New System.Drawing.Size(251, 22)
        Me.txtEventSourceDD.TabIndex = 62
        '
        'Label28
        '
        Me.Label28.AutoSize = true
        Me.Label28.Location = New System.Drawing.Point(12, 245)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 17)
        Me.Label28.TabIndex = 61
        Me.Label28.Text = "Event ID Error:"
        '
        'Label29
        '
        Me.Label29.AutoSize = true
        Me.Label29.Location = New System.Drawing.Point(351, 213)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(122, 17)
        Me.Label29.TabIndex = 60
        Me.Label29.Text = "Event ID Warning:"
        '
        'Label30
        '
        Me.Label30.AutoSize = true
        Me.Label30.Location = New System.Drawing.Point(11, 213)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(92, 17)
        Me.Label30.TabIndex = 59
        Me.Label30.Text = "Event ID Info:"
        '
        'Label31
        '
        Me.Label31.AutoSize = true
        Me.Label31.Location = New System.Drawing.Point(12, 182)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 17)
        Me.Label31.TabIndex = 58
        Me.Label31.Text = "Event Source:"
        '
        'txtDebugDD
        '
        Me.txtDebugDD.Location = New System.Drawing.Point(296, 76)
        Me.txtDebugDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDebugDD.Name = "txtDebugDD"
        Me.txtDebugDD.Size = New System.Drawing.Size(315, 22)
        Me.txtDebugDD.TabIndex = 56
        '
        'Label32
        '
        Me.Label32.AutoSize = true
        Me.Label32.Location = New System.Drawing.Point(200, 80)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 17)
        Me.Label32.TabIndex = 55
        Me.Label32.Text = "Debug File:"
        '
        'chkDebugDD
        '
        Me.chkDebugDD.AutoSize = true
        Me.chkDebugDD.Location = New System.Drawing.Point(128, 81)
        Me.chkDebugDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDebugDD.Name = "chkDebugDD"
        Me.chkDebugDD.Size = New System.Drawing.Size(54, 21)
        Me.chkDebugDD.TabIndex = 54
        Me.chkDebugDD.Text = "Yes"
        Me.chkDebugDD.UseVisualStyleBackColor = true
        '
        'txtLogFileDD
        '
        Me.txtLogFileDD.Location = New System.Drawing.Point(296, 44)
        Me.txtLogFileDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLogFileDD.Name = "txtLogFileDD"
        Me.txtLogFileDD.Size = New System.Drawing.Size(315, 22)
        Me.txtLogFileDD.TabIndex = 53
        '
        'Label33
        '
        Me.Label33.AutoSize = true
        Me.Label33.Location = New System.Drawing.Point(200, 48)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(58, 17)
        Me.Label33.TabIndex = 52
        Me.Label33.Text = "LogFile:"
        '
        'chkLogFileDD
        '
        Me.chkLogFileDD.AutoSize = true
        Me.chkLogFileDD.Location = New System.Drawing.Point(128, 48)
        Me.chkLogFileDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLogFileDD.Name = "chkLogFileDD"
        Me.chkLogFileDD.Size = New System.Drawing.Size(54, 21)
        Me.chkLogFileDD.TabIndex = 51
        Me.chkLogFileDD.Text = "Yes"
        Me.chkLogFileDD.UseVisualStyleBackColor = true
        '
        'chkConsoleDD
        '
        Me.chkConsoleDD.AutoSize = true
        Me.chkConsoleDD.Location = New System.Drawing.Point(128, 20)
        Me.chkConsoleDD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkConsoleDD.Name = "chkConsoleDD"
        Me.chkConsoleDD.Size = New System.Drawing.Size(54, 21)
        Me.chkConsoleDD.TabIndex = 50
        Me.chkConsoleDD.Text = "Yes"
        Me.chkConsoleDD.UseVisualStyleBackColor = true
        '
        'Label35
        '
        Me.Label35.AutoSize = true
        Me.Label35.Location = New System.Drawing.Point(11, 80)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(97, 17)
        Me.Label35.TabIndex = 48
        Me.Label35.Text = "Debug Mode?"
        '
        'Label36
        '
        Me.Label36.AutoSize = true
        Me.Label36.Location = New System.Drawing.Point(12, 48)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(95, 17)
        Me.Label36.TabIndex = 47
        Me.Label36.Text = "Use Log File?"
        '
        'Label37
        '
        Me.Label37.AutoSize = true
        Me.Label37.Location = New System.Drawing.Point(11, 20)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 17)
        Me.Label37.TabIndex = 46
        Me.Label37.Text = "Use Console?"
        '
        'Label42
        '
        Me.Label42.AutoSize = true
        Me.Label42.Location = New System.Drawing.Point(8, 20)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(82, 17)
        Me.Label42.TabIndex = 8
        Me.Label42.Text = "Use Offline:"
        '
        'chkOffLine
        '
        Me.chkOffLine.AutoSize = true
        Me.chkOffLine.Location = New System.Drawing.Point(125, 19)
        Me.chkOffLine.Name = "chkOffLine"
        Me.chkOffLine.Size = New System.Drawing.Size(54, 21)
        Me.chkOffLine.TabIndex = 9
        Me.chkOffLine.Text = "Yes"
        Me.chkOffLine.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 409)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Application Profiler Configuration"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.nudDBResfreh,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudHeartBeat,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudTimer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventError,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventWarning,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        CType(Me.nudTimerAM,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventErrorAM,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventWarningAM,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventInfoAM,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage4.ResumeLayout(false)
        Me.TabPage4.PerformLayout
        CType(Me.nudEventErrorDD,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventWarningDD,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.nudEventInfoDD,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDBHost As TextBox
    Friend WithEvents txtDBNAME As TextBox
    Friend WithEvents txtUID As TextBox
    Friend WithEvents txtPWD As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents nudTimer As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents nudEventError As NumericUpDown
    Friend WithEvents nudEventWarning As NumericUpDown
    Friend WithEvents nudEventInfo As NumericUpDown
    Friend WithEvents txtEventSource As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkNTEvent As CheckBox
    Friend WithEvents txtDebug As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents chkDebug As CheckBox
    Friend WithEvents txtLogFile As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chkLogFile As CheckBox
    Friend WithEvents chkConsole As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents nudTimerAM As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents nudEventErrorAM As NumericUpDown
    Friend WithEvents nudEventWarningAM As NumericUpDown
    Friend WithEvents nudEventInfoAM As NumericUpDown
    Friend WithEvents txtEventSourceAM As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents chkNTEventAM As CheckBox
    Friend WithEvents txtDebugAM As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents chkDebugAM As CheckBox
    Friend WithEvents txtLogFileAM As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents chkLogFileAM As CheckBox
    Friend WithEvents chkConsoleAM As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents nudEventErrorDD As NumericUpDown
    Friend WithEvents nudEventWarningDD As NumericUpDown
    Friend WithEvents nudEventInfoDD As NumericUpDown
    Friend WithEvents txtEventSourceDD As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtDebugDD As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents chkDebugDD As CheckBox
    Friend WithEvents txtLogFileDD As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents chkLogFileDD As CheckBox
    Friend WithEvents chkConsoleDD As CheckBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents nudDBResfreh As NumericUpDown
    Friend WithEvents Label38 As Label
    Friend WithEvents nudHeartBeat As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents cmbBugMode As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents cmbBugModeAM As ComboBox
    Friend WithEvents Label40 As Label
    Friend WithEvents chkNTEventDD As CheckBox
    Friend WithEvents Label41 As Label
    Friend WithEvents cmbBugModeDD As ComboBox
    Friend WithEvents Label34 As Label
    Friend WithEvents chkOffLine As CheckBox
    Friend WithEvents Label42 As Label
End Class
