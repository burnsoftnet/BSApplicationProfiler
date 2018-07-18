Imports System.Management
Imports BurnSoft.Universal
Imports System.Configuration
Public Class FrmMain
    Dim TIMER_INTERVAL As Long
    Dim APP_PATH As String
    Public USELOCAL As Boolean
    Dim HEARTBEAT_INTERVAL As Long
    Dim DB_REFRESH_INTERVAL As Long
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Visible = False
            tmrSched.Enabled = False
            Call Init()

            Call GetLocalApps()

            tmrSched.Enabled = True
            tmrSched.Interval = TIMER_INTERVAL
        Catch ex As Exception
            Call LogError("frmMain.Form1_Load", ex.Message.ToString)
        End Try
    End Sub
    Sub GetLocalApps()

        Dim iProcCount As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("APPLICATION_COUNT"))
        Dim appName As String = ""
        Dim appParam As String = ""
        Dim appInterval As Integer = 0
        'Dim appSetting As String = ""
        Dim ObjS As New BSProcessInfo
        Dim ObjF As New FileIO
        Dim ProcessID As String = ""
        Dim mon_interval As Long = 0
        Dim PID As String = ""
        Dim ProcessCount As Integer = 0

        For x As Integer = 1 To iProcCount
            'appSetting = "APPLICATION_" & x
            appName = ConfigurationManager.AppSettings("APPLICATION_" & x)
            appParam = ConfigurationManager.AppSettings("APPLICATION_PARAM_" & x)
            appInterval = Convert.ToInt32(ConfigurationManager.AppSettings("APPLICATION_INTERVAL_" & x))
            BuggerMe("Looking for Process:" & appName, "GetLocalApps", "medium")
            If ObjS.ProcessExists(ObjF.GetNameOfFile(appName), PID, ProcessCount) Then
                Call RunMonitor(appName, PID, mon_interval, appParam)

            End If
            x += 1
        Next
    End Sub
    ''' <summary>
    ''' Run the Main Monitor application that will collection the information for performance
    ''' monitoring on the selected process
    ''' </summary>
    ''' <param name="ProcessName"></param>
    ''' <param name="PID"></param>
    ''' <param name="mon_interval"></param>
    Sub RunMonitor(ProcessName As String, PID As String, mon_interval As Long, param As string)
        Try
            Dim arg As String = "/name=" & ProcessName & " /pid=" & PID & " /param=" & chr(34) & param & chr(34) & " /interval=" & mon_interval & "/offline=true"
            if param.Length = 0 Then
                arg = "/name=" & ProcessName & " /pid=" & PID & " /interval=" & mon_interval & " /offline=true"
            End If
            Dim ObjP As New BSProcessInfo
            Dim ProcCount As Integer
            Dim AppName As String = System.Configuration.ConfigurationManager.AppSettings("RUNPROGRAM")
            If Not ObjP.ProcessExists(AppName, arg,, ProcCount) Then
                Dim myProcess As New Process
                BuggerMe("Starting Monitor Process with with arguments " & arg & " process count: " & ProcCount, "frmmain.runmonitor")
                myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
                myProcess.StartInfo.FileName = AppName
                myProcess.StartInfo.Arguments = arg
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                myProcess.Start()
            Else
                BuggerMe("Process Already Started with arguments " & arg & " process count: " & ProcCount, "frmmain.runmonitor", "high")
            End If
        Catch ex As Exception
            LogError(Me.Name & "." & "RunMonitor", ex.Message.ToString)
        End Try
    End Sub
    Sub Init()
        HEARTBEAT_INTERVAL = 1

        If Len(System.Configuration.ConfigurationManager.AppSettings("APP_PATH")) = 0 Then
            APP_PATH = Application.StartupPath
        Else
            APP_PATH = System.Configuration.ConfigurationManager.AppSettings("APP_PATH")
        End If

        DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        BUGFILE_LEVEL = System.Configuration.ConfigurationManager.AppSettings("BUGFILE_LEVEL")
        DEBUG_LOGFILE = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MyLogFile = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))

        TIMER_INTERVAL = 30 * 1000
        BuggerMe("App Path: " & APP_PATH, "frmmain.init", "medium")
        BuggerMe("DEBUG_LOGFILE: " & DEBUG_LOGFILE, "frmmain.init", "medium")
        BuggerMe("MyLogFile: " & MyLogFile, "frmmain.init", "medium")
        BuggerMe("Initializing AppSettings to Global Vars Completed", "frmmain.init", "medium")
    End Sub

    ''' <summary>
    ''' Update the Local App.Confg File
    ''' </summary>
    ''' <param name="sKey"></param>
    ''' <param name="sValue"></param>
    Public Sub ChangeAppSettings(ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Config.AppSettings.Settings.Remove(sKey)
        Config.AppSettings.Settings.Add(sKey, sValue)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
        BuggerMe("Updated App.Config key:" & sKey & " with value=" & sValue, "frmmain.ChangeAppSettings", "medium")
    End Sub

    Private Sub tmrSched_Tick(sender As Object, e As EventArgs) Handles tmrSched.Tick
        Call GetLocalApps()
    End Sub
End Class