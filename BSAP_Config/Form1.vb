Imports System.Configuration
Public Class Form1
    Const APP_PROFILER = "\BSApplicationProfiler.exe"
    Const APP_MONITOR = "\BSAP_AppMonitor.exe"
    Const APP_DATADUMP = "\BSAP_DataDump.exe"
    Const APP_SERVICE = "\BSAP_Service.exe"
    ''' <summary>
    ''' Load Values into the fields when the form starts up
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadProfilerValues()
        Call LoadAppMonitorValues()
        Call LoadDataDumperValues()
        call LoadServiceValues()
    End Sub
    ''' <summary>
    ''' Sub to Save values to the app.config file based on the sPath ( path of the config file) 
    ''' and the new value
    ''' </summary>
    ''' <param name="SPath"></param>
    ''' <param name="sKey"></param>
    ''' <param name="sValue"></param>
    Public Sub ChangeAppSettings(ByVal SPath As String, ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(SPath)
        Config.AppSettings.Settings.Remove(sKey)
        Config.AppSettings.Settings.Add(sKey, sValue)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
    End Sub
    sub LoadServiceValues()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & APP_SERVICE
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        chkOffLine.Checked = CBool(Config.AppSettings.Settings.Item("RUN_OFFLINE").Value)
    End sub
    ''' <summary>
    ''' Load the settings from the Data Dumper config file
    ''' </summary>
    Sub LoadDataDumperValues()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & APP_DATADUMP
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        chkDebugDD.Checked = CBool(Config.AppSettings.Settings.Item("DEBUG").Value)
        chkConsoleDD.Checked = CBool(Config.AppSettings.Settings.Item("CONSOLE").Value)
        chkLogFileDD.Checked = CBool(Config.AppSettings.Settings.Item("USE_LOGFILE").Value)
        chkNTEventDD.Checked = CBool(Config.AppSettings.Settings.Item("USE_EVENT_LOG").Value)
        txtLogFileDD.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtDebugDD.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        txtEventSourceDD.Text = Config.AppSettings.Settings.Item("EVENT_SOURCE").Value
        nudEventWarningDD.Value = Config.AppSettings.Settings.Item("EVENT_ID_WARN").Value
        nudEventInfoDD.Value = Config.AppSettings.Settings.Item("EVENT_ID_INFO").Value
        nudEventErrorDD.Value = Config.AppSettings.Settings.Item("EVENT_ID_ERROR").Value
        cmbBugModeDD.Text = Config.AppSettings.Settings.Item("BUGFILE_LEVEL").Value
    End Sub
    ''' <summary>
    ''' Load the settings from the Application Monitor config file
    ''' </summary>
    Sub LoadAppMonitorValues()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & APP_MONITOR
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        chkDebugAM.Checked = CBool(Config.AppSettings.Settings.Item("DEBUG").Value)
        chkConsoleAM.Checked = CBool(Config.AppSettings.Settings.Item("CONSOLE").Value)
        chkLogFileAM.Checked = CBool(Config.AppSettings.Settings.Item("USE_LOGFILE").Value)
        chkNTEventAM.Checked = CBool(Config.AppSettings.Settings.Item("USE_EVENT_LOG").Value)
        txtLogFileAM.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtDebugAM.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudTimerAM.Value = Config.AppSettings.Settings.Item("TIMER_INTERVAL").Value
        txtEventSourceAM.Text = Config.AppSettings.Settings.Item("EVENT_SOURCE").Value
        nudEventWarningAM.Value = Config.AppSettings.Settings.Item("EVENT_ID_WARN").Value
        nudEventInfoAM.Value = Config.AppSettings.Settings.Item("EVENT_ID_INFO").Value
        nudEventErrorAM.Value = Config.AppSettings.Settings.Item("EVENT_ID_ERROR").Value
        cmbBugModeAM.Text = Config.AppSettings.Settings.Item("BUGFILE_LEVEL").Value
    End Sub
    ''' <summary>
    ''' Load the values from the Application Profiler app.config file
    ''' </summary>
    Sub LoadProfilerValues()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & APP_PROFILER
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        chkDebug.Checked = CBool(Config.AppSettings.Settings.Item("DEBUG").Value)
        chkConsole.Checked = CBool(Config.AppSettings.Settings.Item("CONSOLE").Value)
        chkLogFile.Checked = CBool(Config.AppSettings.Settings.Item("USE_LOGFILE").Value)
        chkNTEvent.Checked = CBool(Config.AppSettings.Settings.Item("USE_EVENT_LOG").Value)
        txtLogFile.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtDebug.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudTimer.Value = Config.AppSettings.Settings.Item("TIMER_INTERVAL").Value
        txtEventSource.Text = Config.AppSettings.Settings.Item("EVENT_SOURCE").Value
        nudEventWarning.Value = Config.AppSettings.Settings.Item("EVENT_ID_WARN").Value
        nudEventInfo.Value = Config.AppSettings.Settings.Item("EVENT_ID_INFO").Value
        nudEventError.Value = Config.AppSettings.Settings.Item("EVENT_ID_ERROR").Value
        txtDBHost.Text = Config.AppSettings.Settings.Item("DB_HOST").Value
        txtDBNAME.Text = Config.AppSettings.Settings.Item("DB_NAME").Value
        txtPWD.Text = Config.AppSettings.Settings.Item("DB_PWD").Value
        txtUID.Text = Config.AppSettings.Settings.Item("DB_UID").Value
        nudHeartBeat.Value = Config.AppSettings.Settings.Item("HEARTBEAT_INTERVAL").Value
        nudDBResfreh.Value = Config.AppSettings.Settings.Item("DBREFRESH_INTERVAL").Value
        cmbBugMode.Text = Config.AppSettings.Settings.Item("BUGFILE_LEVEL").Value
    End Sub

    Sub SaveServiceSettings()
        Dim sPath As String = Application.StartupPath & APP_SERVICE
        Call ChangeAppSettings(sPath, "RUN_OFFLINE", chkOffline.Checked)
    End Sub
    ''' <summary>
    ''' Save the Changes to the App Monitor config file
    ''' </summary>
    Sub SaveAppMonitorSettings()
        Dim sPath As String = Application.StartupPath & APP_MONITOR
        Call ChangeAppSettings(sPath, "DEBUG", chkDebugAM.Checked)
        Call ChangeAppSettings(sPath, "CONSOLE", chkConsoleAM.Checked)
        Call ChangeAppSettings(sPath, "USE_LOGFILE", chkLogFileAM.Checked)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLogFileAM.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtDebugAM.Text)
        Call ChangeAppSettings(sPath, "TIMER_INTERVAL", nudTimerAM.Value)
        Call ChangeAppSettings(sPath, "USE_EVENT_LOG", chkNTEventAM.Checked)
        Call ChangeAppSettings(sPath, "EVENT_SOURCE", txtEventSourceAM.Text)
        Call ChangeAppSettings(sPath, "EVENT_ID_INFO", nudEventInfoAM.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_WARN", nudEventWarningAM.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_ERROR", nudEventErrorAM.Value)
        Call ChangeAppSettings(sPath, "BUGFILE_LEVEL", cmbBugModeAM.SelectedText)
    End Sub
    ''' <summary>
    ''' save changes to the application profilers config file
    ''' </summary>
    Sub SaveProfilerSettings()
        Dim sPath As String = Application.StartupPath & APP_PROFILER
        Call ChangeAppSettings(sPath, "DEBUG", chkDebug.Checked)
        Call ChangeAppSettings(sPath, "CONSOLE", chkConsole.Checked)
        Call ChangeAppSettings(sPath, "USE_LOGFILE", chkLogFile.Checked)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLogFile.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtDebug.Text)
        Call ChangeAppSettings(sPath, "TIMER_INTERVAL", nudTimer.Value)
        Call ChangeAppSettings(sPath, "USE_EVENT_LOG", chkNTEvent.Checked)
        Call ChangeAppSettings(sPath, "EVENT_SOURCE", txtEventSource.Text)
        Call ChangeAppSettings(sPath, "EVENT_ID_INFO", nudEventInfo.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_WARN", nudEventWarning.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_ERROR", nudEventError.Value)
        Call ChangeAppSettings(sPath, "DBREFRESH_INTERVAL", nudDBResfreh.Value)
        Call ChangeAppSettings(sPath, "HEARTBEAT_INTERVAL", nudHeartBeat.Value)
        Call ChangeAppSettings(sPath, "BUGFILE_LEVEL", cmbBugMode.SelectedText)
    End Sub
    ''' <summary>
    ''' save changes to the Data Dumper config file
    ''' </summary>
    Sub SaveDataDumperSettings()
        Dim sPath As String = Application.StartupPath & APP_DATADUMP
        Call ChangeAppSettings(sPath, "DEBUG", chkDebugDD.Checked)
        Call ChangeAppSettings(sPath, "CONSOLE", chkConsoleDD.Checked)
        Call ChangeAppSettings(sPath, "USE_LOGFILE", chkLogFileDD.Checked)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLogFileDD.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtDebugDD.Text)
        Call ChangeAppSettings(sPath, "USE_EVENT_LOG", chkNTEventDD.Checked)
        Call ChangeAppSettings(sPath, "EVENT_SOURCE", txtEventSourceDD.Text)
        Call ChangeAppSettings(sPath, "EVENT_ID_INFO", nudEventInfoDD.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_WARN", nudEventWarningDD.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_ERROR", nudEventErrorDD.Value)
        Call ChangeAppSettings(sPath, "BUGFILE_LEVEL", cmbBugModeDD.SelectedText)
    End Sub
    ''' <summary>
    ''' Save the database information to both known config files
    ''' </summary>
    Sub SaveDatabase()
        Call SaveDatabaseSettings(Application.StartupPath & APP_PROFILER)
        Call SaveDatabaseSettings(Application.StartupPath & APP_MONITOR)
        Call SaveDatabaseSettings(Application.StartupPath & APP_DATADUMP)
    End Sub
    ''' <summary>
    ''' Generic sub to save the database information to the config file that is passed 
    ''' to this sub
    ''' </summary>
    ''' <param name="sPath"></param>
    Sub SaveDatabaseSettings(sPath As String)
        Call ChangeAppSettings(sPath, "DB_HOST", txtDBHost.Text)
        Call ChangeAppSettings(sPath, "DB_NAME", txtDBNAME.Text)
        Call ChangeAppSettings(sPath, "DB_UID", txtUID.Text)
        Call ChangeAppSettings(sPath, "DB_PWD", txtPWD.Text)
    End Sub
    ''' <summary>
    ''' Save everything from the form back to the config file(s)
    ''' </summary>
    Sub SaveData()
        Call SaveDatabase()
        Call SaveProfilerSettings()
        Call SaveAppMonitorSettings()
        Call SaveDataDumperSettings()
    End Sub
    ''' <summary>
    ''' Properly exit the application
    ''' </summary>
    ''' <param name="ExitValue"></param>
    Sub ExitApp(Optional ByVal ExitValue As Integer = 0)
        Application.Exit()
        'Environment.Exit(ExitValue)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Call ExitApp()
    End Sub

    Private Sub SaveExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveExitToolStripMenuItem.Click
        Call SaveData()
        Call ExitApp()
    End Sub

    sub ToggleOffline()
        Dim showMe as Boolean = false
        If not chkOffLine.Checked then showMe = true
        txtDBHost.Enabled = showMe
        txtDBNAME.Enabled = showMe
        txtPWD.Enabled = showMe
        txtUID.Enabled = showMe
        Call SaveServiceSettings()
    End sub

    Private Sub chkOffLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkOffLine.CheckedChanged
        Call ToggleOffline()
    End Sub
End Class
