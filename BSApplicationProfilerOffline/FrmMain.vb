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
        Dim sList As String() = Split(ConfigurationManager.AppSettings("APPLICATION_LISTINGS"), ",")
        If (sList.Count > 0) Then
            Dim sProcess As String
            Dim ObjS As New BSProcessInfo
            Dim ObjF As New FileIO
            Dim ProcessID As String = ""
            Dim mon_interval As Long = 0
            Dim PID As String = ""
            Dim ProcessCount As Integer = 0

            For x As Integer = 0 To sList.Count
                sProcess = sList(x)
                BuggerMe("Looking for Process:" & sProcess, "GetLocalApps", "medium")
                If ObjS.ProcessExists(ObjF.GetNameOfFile(sProcess), PID, ProcessCount) Then
                    Call RunMonitor(sProcess, ProcessID, mon_interval, AGENT_ID)
                End If
                x += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Run the Main Monitor application that will collection the information for performance
    ''' monitoring on the selected process
    ''' </summary>
    ''' <param name="ProcessName"></param>
    ''' <param name="PID"></param>
    ''' <param name="mon_interval"></param>
    ''' <param name="agentid"></param>
    Sub RunMonitor(ProcessName As String, PID As String, mon_interval As Long, agentid As Long)
        Try
            Dim arg As String = "/name=" & ProcessName & " /pid=" & PID & " /aid=" & agentid & " /interval=" & mon_interval
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
        'APP_PATH = Application.ExecutablePath
        'APP_PATH = "C:\Program Files (x86)\BurnSoft\Application Profiler"
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
        'DBHOST = System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
        TIMER_INTERVAL = 30 * 1000
        USE_EVENT_LOG = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_EVENT_LOG"))
        'EventLog1.Source = System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")
        'EventLog1.Log = System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG")
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
        'Dim ObjN As New BSNetwork
        'Dim LastLocalStatus = USELOCAL
        'If LastLocalStatus And Not USELOCAL Then
        'Call RunDBUpdate(AGENT_ID)
        'End If
        'Call GetLocalApps()
        If HEARTBEAT_INTERVAL >= CInt(System.Configuration.ConfigurationManager.AppSettings("HEARTBEAT_INTERVAL")) Then
            '   Dim ObjA As New AgentDetails
            '  Call ObjA.UpdateHeartBeat(AGENT_ID)
            HEARTBEAT_INTERVAL = 0
        Else
            HEARTBEAT_INTERVAL += 1
        End If
        'If DB_REFRESH_INTERVAL >= CLng(System.Configuration.ConfigurationManager.AppSettings("DB_REFRESH_INTERVAL")) Then
        '' Call DBRefresh()
        'DB_REFRESH_INTERVAL = 0
        'Else
        'DB_REFRESH_INTERVAL += 1
        'End If
    End Sub
End Class