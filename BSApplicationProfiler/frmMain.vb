Imports System.Management
Imports BurnSoft.Universal
Imports System.Data.SQLite
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class frmMain
    Dim TIMER_INTERVAL As Long
    Dim APP_PATH As String
    Public USELOCAL As Boolean
    Dim HEARTBEAT_INTERVAL As Long
    Dim DB_REFRESH_INTERVAL As Long
#Region "Local Database Execution"
    ''' <summary>
    ''' Run through the enabled application monitoring list and see if they are running
    ''' on the system, if they are execute the monitoring process
    ''' </summary>
    Sub GetLocalApps()
        Try
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB = 0 Then
                Dim SQL As String = "select * from view_all_processes_and_projects where enabled=1"
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                Dim ProcessName As String = ""
                Dim ProcessID As String = ""
                Dim mon_interval As Long = 0
                Dim PID As String = ""
                Dim ProcessCount As Integer = 0
                Dim ObjS As New BSProcessInfo
                Dim ObjF As New FileIO
                If RS.HasRows Then
                    While RS.Read
                        ProcessName = RS("process_name")
                        ProcessID = RS("processid")
                        mon_interval = RS("interval")
                        BuggerMe("Looking for Process:" & ObjF.GetNameOfFile(ProcessName), "GetLocalApps")
                        If ObjS.ProcessExists(ObjF.GetNameOfFile(ProcessName), PID, ProcessCount) Then
                            Call RunMonitor(ProcessName, ProcessID, mon_interval, AGENT_ID)
                        End If
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                Else
                    BuggerMe("No Rows Found in Local Database", "GetLocalApps")
                End If
            Else
                    BuggerMe("Unable to connection to the database!", "frmMain.GetLocalApps")
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError(Me.Name & "." & "GetLocalApps", ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Main Database to Local Database"
    ''' <summary>
    ''' Refresh the Main Application Details from the Main Database to the local
    ''' </summary>
    Sub LocalDBRefresh()
        Call RefreshLocalDB()
        Call RefreshLocalDB_APMP()
        Call RefreshLocalDB_APML()
    End Sub
    ''' <summary>
    ''' Download the app_project_name table from the main database server
    ''' to the local SQLite Database
    ''' </summary>
    Sub RefreshLocalDB()
        Try
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "select * from app_project_name"
                Dim iSQL As String = ""
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                Dim ObjL As New BurnSoft.BSSqliteDatabase
                ObjL.ConnExe("DELETE from app_project_name")
                RS = CMD.ExecuteReader
                While RS.Read
                    iSQL = "INSERT INTO app_project_name (id,name,appdesc,enabled,has_subprocess) VALUES (" &
                        RS("id") & ",'" & RS("name") & "','" & RS("appdesc") & "'," & RS("enabled") & "," & RS("has_subprocess") & ")"
                    ObjL.ConnExe(iSQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            Else
                BuggerMe("Unable to connection to the database!", "frmMain.RefreshLocalDB")
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError(Me.Name & "." & "RefreshLocalDB", ex.Message.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Download the contents from the app_project_main_process table from the main 
    ''' database to the loca database
    ''' </summary>
    Sub RefreshLocalDB_APMP()
        Try
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "select * from app_project_main_process"
                Dim iSQL As String = ""
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                Dim ObjL As New BurnSoft.BSSqliteDatabase
                ObjL.ConnExe("DELETE from app_project_main_process")
                RS = CMD.ExecuteReader
                While RS.Read
                    iSQL = "INSERT INTO app_project_main_process (id,apnid,process_display_name,process_name,match_parameters,parameters,haslogs,useNTEvent,NTSource,NTEventID,interval) VALUES (" &
                        RS("id") & "," & RS("apnid") & ",'" & RS("process_display_name") & "','" & RS("process_name") & "'," &
                        RS("match_parameters") & ",'" & RS("parameters") & "'," & RS("haslogs") & "," & RS("useNTEvent") & ",'" & RS("NTSource") & "','" & RS("NTEventID") & "'," & RS("interval") & ")"
                    ObjL.ConnExe(iSQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            Else
                BuggerMe("Unable to connection to the database!", "frmMain.RefreshLocalDB_APMP")
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError(Me.Name & "." & "RefreshLocalDB_APMP", ex.Message.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Download the contents of the app_project_main_log from the main database to the local
    ''' </summary>
    Sub RefreshLocalDB_APML()
        Try
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "select * from app_project_main_log"
                Dim iSQL As String = ""
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                Dim ObjL As New BurnSoft.BSSqliteDatabase
                ObjL.ConnExe("DELETE from app_project_main_log")
                RS = CMD.ExecuteReader
                While RS.Read
                    iSQL = "INSERT INTO app_project_main_log (id,apmid,logname,logpath,clearlog) VALUES (" &
                        RS("id") & "," & RS("apmid") & ",'" & RS("logname") & "','" & RS("logpath") & "'," & RS("clearlog") & ")"
                    ObjL.ConnExe(iSQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            Else
                BuggerMe("Unable to connection to the database!", "frmMain.RefreshLocalDB_APML")
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError(Me.Name & "." & "RefreshLocalDB_APML", ex.Message.ToString)
        End Try
    End Sub
#End Region
#Region "Other Subs and Functions"
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
                BuggerMe("Process Already Started with arguments " & arg & " process count: " & ProcCount, "frmmain.runmonitor")
            End If
        Catch ex As Exception
            LogError(Me.Name & "." & "RunMonitor", ex.Message.ToString)
        End Try
    End Sub
    Sub RunDBUpdate(agentid As Long)
        Try
            Dim arg As String = "/agent=" & agentid
            Dim ObjP As New BSProcessInfo
            Dim ProcCount As Integer
            Dim AppName As String = "BSAP_DataDump.exe"
            If Not ObjP.ProcessExists(AppName, arg,, ProcCount) Then
                Dim myProcess As New Process
                BuggerMe("Starting Database Sync with with arguments " & arg & " process count: " & ProcCount, "frmmain.runmonitor")
                myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
                myProcess.StartInfo.FileName = AppName
                myProcess.StartInfo.Arguments = arg
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                myProcess.Start()
            Else
                BuggerMe("Process Already Started with arguments " & arg & " process count: " & ProcCount, "frmmain.runmonitor")
            End If
        Catch ex As Exception
            LogError(Me.Name & "." & "RunDBUpdate", ex.Message.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' Set Global Vars
    ''' </summary>
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
        DEBUG_LOGFILE = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MyLogFile = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
        DBHOST = System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
        TIMER_INTERVAL = 30 * 1000
        USE_EVENT_LOG = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_EVENT_LOG"))
        EventLog1.Source = System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")
        EventLog1.Log = System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG")
        BuggerMe("App Path: " & APP_PATH, "frmmain.init")
        BuggerMe("DEBUG_LOGFILE: " & DEBUG_LOGFILE, "frmmain.init")
        BuggerMe("MyLogFile: " & MyLogFile, "frmmain.init")
        BuggerMe("Initializing AppSettings to Global Vars Completed", "frmmain.init")
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
        BuggerMe("Updated App.Config key:" & sKey & " with value=" & sValue, "frmmain.ChangeAppSettings")
    End Sub
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Visible = False
            tmrSched.Enabled = False
            Call Init()
            Dim ObjN As New BSNetwork
            If ObjN.DeviceIsUp(DBHOST) Then
                USELOCAL = False
            Else
                USELOCAL = True
            End If

            If Not USELOCAL Then
                'Agent Details and Update
                Dim Obj As New AgentDetails
                AGENT_ID = Obj.GetAgentID()
                Call ChangeAppSettings("AGENT_ID", AGENT_ID)
                BuggerMe("Using remote Database:" & DBHOST, "frmmain.Form1_Load")
                'Connect to the MySQL Database and download the Application Lists and details for watching
                Call DBRefresh()
                Obj = Nothing
            Else
                'Unable to Reach Main DB Server, use Local Settings
                BuggerMe("Using Local Database", "frmmain.Form1_Load")
                AGENT_ID = System.Configuration.ConfigurationManager.AppSettings("AGENT_ID")
                Call LogError("frmMain.Form1_Load", "Unabled to connnect to database host " & DBHOST)
            End If

            Call GetLocalApps()

            tmrSched.Enabled = True
            tmrSched.Interval = TIMER_INTERVAL
        Catch ex As Exception
            Call LogError("frmMain.Form1_Load", ex.Message.ToString)
        End Try
    End Sub
    Sub DBRefresh()
        Call RefreshLocalDB()
        Call RefreshLocalDB_APMP()
        Call RefreshLocalDB_APML()
    End Sub
    Private Sub tmrSched_Tick(sender As Object, e As EventArgs) Handles tmrSched.Tick
        Dim ObjN As New BSNetwork
        Dim LastLocalStatus = USELOCAL
        If ObjN.DeviceIsUp(DBHOST) Then
            USELOCAL = False
        Else
            USELOCAL = True
        End If
        If LastLocalStatus And Not USELOCAL Then
            Call RunDBUpdate(AGENT_ID)
        End If
        Call GetLocalApps()
        If HEARTBEAT_INTERVAL >= CInt(System.Configuration.ConfigurationManager.AppSettings("HEARTBEAT_INTERVAL")) Then
            Dim ObjA As New AgentDetails
            Call ObjA.UpdateHeartBeat(AGENT_ID)
            HEARTBEAT_INTERVAL = 0
        Else
            HEARTBEAT_INTERVAL += 1
        End If
        If DB_REFRESH_INTERVAL >= CLng(System.Configuration.ConfigurationManager.AppSettings("DB_REFRESH_INTERVAL")) Then
            Call DBRefresh()
            DB_REFRESH_INTERVAL = 0
        Else
            DB_REFRESH_INTERVAL += 1
        End If
    End Sub
End Class
