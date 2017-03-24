Imports BurnSoft.Universal
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Imports System.IO
Module modMain
    Dim SESSION_ID As Long
    Dim APP_PROJECT_MAIN_PROCESS_ID As Long
    Dim APP_PATH As String
    Dim USELOCAL As Boolean
#Region "SQLite Database Function and Sub"
    ''' <summary>
    ''' Get the Application Project Main Process ID and also return if the application has logs or not
    ''' </summary>
    ''' <param name="process_name"></param>
    ''' <param name="HasLogs"></param>
    ''' <returns>id</returns>
    Function getAppProjectMainProcessSQLIte(process_name As String, Optional ByRef HasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        Try
            Dim SQL As String = "Select id, haslogs from app_project_main_process where process_name='" & process_name & "' COLLATE NOCASE"
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("id")
                    HasLogs = Convert10ToBool(RS("haslogs"))
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.getAppProjectMainProcessSQLite", ex.Message.ToString)
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' Gets the Log file name and path from the database for this main process
    ''' </summary>
    ''' <param name="APID"></param>
    ''' <returns></returns>
    Function GetLogPathSQLite(APID As Long) As String
        Dim sAns As String = ""
        Try
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "select * from app_project_main_log where apmid=" & APID
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS("logpath") & "\" & RS("logname")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.GetLogPathSQLite", ex.Message.ToString)
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function getSessionIDSQLite() As Long
        Dim lAns As Long = 0
        Try
            Dim SQL As String = "SELECT id from monitoring_session where APNID=" & PROCESS_ID & " and AID=" & AGENT_ID &
                                " order by id desc limit 1"
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("id")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
                Obj = Nothing
            End If
        Catch ex As Exception
            Call LogError("modmain.getSessionIDSQLite", ex.Message.ToString)
        End Try
        Return lAns
    End Function
#End Region
#Region "MySQL Database Functions and Subs"
    ''' <summary>
    ''' Get the Application Project Main Process ID and also return if the application has logs or not
    ''' </summary>
    ''' <param name="process_name"></param>
    ''' <param name="HasLogs"></param>
    ''' <returns>id</returns>
    Function getAppProjectMainProcessMySQL(process_name As String, Optional ByRef HasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        Try
            Dim SQL As String = "Select id, haslogs from app_project_main_process where process_name='" & process_name & "'"
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("id")
                    HasLogs = Convert10ToBool(RS("haslogs"))
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.getAppProjectMainProcessMySQL", ex.Message.ToString)
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' Gets the Log file name and path from the database for this main process
    ''' </summary>
    ''' <param name="APID"></param>
    ''' <returns></returns>
    Function GetLogPathMySQL(APID As Long) As String
        Dim sAns As String = ""
        Try
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "select * from app_project_main_log where apmid=" & APID
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS("logpath") & "\" & RS("logname")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.GetLogPathMySQL", ex.Message.ToString)
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function getSessionIDMySQL() As Long
        Dim lAns As Long = 0
        Try
            Dim SQL As String = "SELECT id from monitoring_session where APNID=" & PROCESS_ID & " and AID=" & AGENT_ID &
                                " order by id desc limit 1"
            Dim Obj As New BurnSoft.BSDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("id")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
                Obj = Nothing
            End If
        Catch ex As Exception
            Call LogError("modmain.getSessionIDMySQL", ex.Message.ToString)
        End Try
        Return lAns
    End Function
#End Region
#Region "Database Functions and Subs"
    ''' <summary>
    ''' Create a new Session Marker in the database and set the Global
    ''' variable SESSIOn_ID
    ''' </summary>
    Sub StartSessionDetails()
        Call CreateNewSession()
        SESSION_ID = getSessionID()
    End Sub
    Sub EndSession()
        Dim SQL As String = "UPDATE monitoring_session set sessionend=CURRENT_TIMESTAMP where ID=" & SESSION_ID
        Call ConnExec(SQL)
    End Sub
    ''' <summary>
    ''' Get the main application ID doem the database based on the name of the process
    ''' </summary>
    ''' <param name="process_name"></param>
    ''' <param name="HasLogs"></param>
    ''' <returns></returns>
    Function getAppProjectMainProcess(process_name As String, Optional ByRef HasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        If Not USELOCAL Then
            lAns = getAppProjectMainProcessMySQL(process_name, HasLogs)
        Else
            lAns = getAppProjectMainProcessSQLIte(process_name, HasLogs)
        End If
        Return lAns
    End Function
    ''' <summary>
    ''' Get the Log Path and details based on the main application ID
    ''' </summary>
    ''' <param name="APID"></param>
    ''' <returns></returns>
    Function GetLogPath(APID As Long) As String
        Dim sAns As String = ""
        If Not USELOCAL Then
            sAns = GetLogPathMySQL(APID)
        Else
            sAns = GetLogPathSQLite(APID)
        End If
        Return sAns
    End Function
    ''' <summary>
    ''' Move between the main database and the local database to execute sql statements
    ''' </summary>
    ''' <param name="SQL"></param>
    Sub ConnExec(SQL As String)
        If Not USELOCAL Then
            Dim Obj As New BurnSoft.BSDatabase
            Obj.ConnExe(SQL)
            Obj = Nothing
        Else
            Dim Obj As New BurnSoft.BSSqliteDatabase
            Obj.ConnExe(SQL)
            Obj = Nothing
        End If
    End Sub
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function getSessionID() As Long
        Dim lAns As Long = 0
        If Not USELOCAL Then
            lAns = getSessionIDMySQL()
        Else
            lAns = getSessionIDSQLite()
        End If
        Return lAns
    End Function
    ''' <summary>
    ''' Create a new sessiont in the database
    ''' </summary>
    Sub CreateNewSession()
        Dim SQL As String = "INSERT INTO monitoring_session (APNID, AID) VALUES (" & PROCESS_ID & "," & AGENT_ID & ")"
        Call ConnExec(SQL)
    End Sub
    ''' <summary>
    ''' Insert the information gathered about the process into the database
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <param name="apnid"></param>
    ''' <param name="apmpid"></param>
    ''' <param name="aid"></param>
    ''' <param name="imagename"></param>
    ''' <param name="username"></param>
    ''' <param name="cpu"></param>
    ''' <param name="memoryused"></param>
    ''' <param name="ihandles"></param>
    ''' <param name="threads"></param>
    ''' <param name="commandline"></param>
    Sub InsertIntoProcessStats(SessionID As String, apnid As String, apmpid As String, aid As String, imagename As String,
                               username As String, cpu As String, memoryused As String, ihandles As String, threads As String,
                               commandline As String)
        Try
            Dim SQL As String = "INSERT INTO process_stats_main (SessionID,apnid,apmpid,AID,imagename," &
                    "username,`cpu`,memoryused,handles,threads,commandline) VALUES(" & SessionID & "," &
                    apnid & "," & apmpid & "," & aid & ",'" & imagename & "','" & username & "'," &
                    cpu & "," & memoryused & "," & ihandles & "," & threads & ",'" & commandline & "')"
            Call BuggerMe(SQL, "modMain.InsertIntoProcessStats", "high")
            Call ConnExec(SQL)
        Catch ex As Exception
            Call LogError("modMain.InsertIntoProcessStats", ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region "Other Subs and Functions"
    ''' <summary>
    ''' Go through the log file and insert the lines from the log file into the database
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <param name="FileName"></param>
    ''' <param name="APID"></param>
    ''' <param name="SID"></param>
    Sub ProcessLogFile(sFile As String, FileName As String, APID As Long, SID As Long)
        Dim fr As StreamReader = New StreamReader(sFile)
        Dim ObjOF As New BSOtherObjects
        Dim SQL As String = ""

        Do Until fr.EndOfStream
            Dim sLine As String = ObjOF.FC(fr.ReadLine)
            SQL = "INSERT INTO logs_main (sessionid,APNID,filename,logdetails) VALUES (" & SID &
                  "," & APID & ",'" & FileName & "','" & sLine & "')"
            Call ConnExec(SQL)
        Loop
        fr.Close()
        fr = Nothing
        ObjOF = Nothing
    End Sub
    ''' <summary>
    ''' Quickly Convert a 1 or 0 value to true or false
    ''' </summary>
    ''' <param name="iValue"></param>
    ''' <returns></returns>
    Function Convert10ToBool(iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue = 1 Then bAns = True
        Return bAns
    End Function
    ''' <summary>
    ''' Set Global Vars
    ''' </summary>
    Sub INIT()
        If Not USE_TEST_INIT Then
            Dim ObjO As New BSOtherObjects
            PROCESS_NAME = ObjO.GetCommand("name", "")
            PROCESS_ID = ObjO.GetCommand("pid", 0)
            AGENT_ID = ObjO.GetCommand("aid", 0)
            TIMER_INTERVAL = ObjO.GetCommand("interval", 0) * 60000
            If TIMER_INTERVAL = 0 Then
                TIMER_INTERVAL = System.Configuration.ConfigurationManager.AppSettings("TIMER_INTERVAL")
            End If
            ObjO = Nothing

            If Len(System.Configuration.ConfigurationManager.AppSettings("APP_PATH")) = 0 Then
                APP_PATH = Application.StartupPath
            Else
                APP_PATH = System.Configuration.ConfigurationManager.AppSettings("APP_PATH")
            End If

            BUGFILE_LEVEL = System.Configuration.ConfigurationManager.AppSettings("BUGFILE_LEVEL")
            DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            DEBUG_LOGFILE = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
            MyLogFile = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
            CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
            USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
            DBHOST = System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
        Else
            PROCESS_NAME = "BSMyGunCollection.exe"
            PROCESS_ID = 2
            AGENT_ID = 1
            TIMER_INTERVAL = 1 * 60000
        End If
        If PROCESS_ID = 0 Or AGENT_ID = 0 Then
            LogError("modMail.Init", "Missing Agent ID or Process ID")
            Call ExitApp()
        End If
    End Sub
    ''' <summary>
    ''' Properly exit the application
    ''' </summary>
    ''' <param name="ExitValue"></param>
    Sub ExitApp(Optional ByVal ExitValue As Integer = 0)
        Application.Exit()
        Environment.Exit(ExitValue)
    End Sub
    ''' <summary>
    ''' Collect the information needed to monitor the process
    ''' </summary>
    ''' <param name="MyProcess"></param>
    ''' <param name="username"></param>
    ''' <param name="ProcessActive"></param>
    Sub CollectData(MyProcess As String, ByRef ProcessActive As Boolean)
        Dim MyPID As String = ""
        Dim ProcessCount As Integer = 0
        Dim CPU As Double = 0
        Dim ObjP As New BurnSoft.BSProcessInfo
        Dim Username As String = ObjP.GetProcessOwner(MyProcess)
        BuggerMe("username=" & Username)
        ProcessActive = ObjP.ProcessExists(MyProcess, MyPID, ProcessCount)
        If ProcessActive Then
            If LAST_CPU_VALUE = 0 Then
                CPU = ObjP.GetCPUProcessStarting(Replace(MyProcess, ".exe", ""), LAST_CPU_VALUE)
            Else
                CPU = ObjP.GetProcessCPUTime(Replace(MyProcess, ".exe", ""), LAST_CPU_VALUE, LAST_CPU_VALUE)
            End If

            Call InsertIntoProcessStats(SESSION_ID, PROCESS_ID, APP_PROJECT_MAIN_PROCESS_ID, AGENT_ID, MyProcess, username,
                                        CPU, ObjP.GetProcessMemoryUseage(Replace(MyProcess, ".exe", "")),
                                        ObjP.GetProccessHandleCount(MyPID), ObjP.GetProcessThreadCount(MyPID), ObjP.GetProcessCommandLine(MyPID))
        End If
    End Sub
#End Region
    Sub Main()
        Try
            Call INIT()

            Dim ObjN As New BSNetwork
            If ObjN.DeviceIsUp(DBHOST) Then
                USELOCAL = False
            Else
                USELOCAL = True
            End If
            ObjN = Nothing
            If USELOCAL Then
                Call LogError("modMain.Main", "Unabled to connnect to database host " & DBHOST)
                Call BuggerMe("Using Local Database", "modMain.Main")
            Else
                Call BuggerMe("Using Remote Database " & DBHOST, "modMain.Main")
            End If

            Dim HasLogs As Boolean = False
            APP_PROJECT_MAIN_PROCESS_ID = getAppProjectMainProcess(PROCESS_NAME, HasLogs)
            BuggerMe("APP_PROJECT_MAIN_PROCESS_ID=" & APP_PROJECT_MAIN_PROCESS_ID)
            Dim ObjS As New BSOtherObjects

            ObjS = Nothing
            Call StartSessionDetails()
            LAST_CPU_VALUE = 0
            Dim ProcessActive As Boolean = True
            Do While ProcessActive
                Call BuggerMe("Starting Data Collection at " & Now, "modMain.Main", "medium")
                Call CollectData(PROCESS_NAME, ProcessActive)
                Call BuggerMe("Ending Data Collection at " & Now, "modMain.Main", "medium")
                If ProcessActive Then System.Threading.Thread.Sleep(TIMER_INTERVAL)
            Loop

            If HasLogs Then
                BuggerMe("Looking for Logs!", "modMain.Main", "medium")
                Dim LogLocation As String = GetLogPath(APP_PROJECT_MAIN_PROCESS_ID)
                BuggerMe("LogFile: " & LogLocation)
                Dim ObjF As New FileIO
                If ObjF.FileExists(LogLocation) Then
                    BuggerMe("Processing Logs!", "modMain.Main", "medium")
                    Call ProcessLogFile(LogLocation, ObjF.GetNameOfFile(LogLocation), PROCESS_ID, SESSION_ID)
                    BuggerMe("Deleting log file!")
                    ObjF.DeleteFile(LogLocation)
                Else
                    BuggerMe(LogLocation & " not found!", "modMain.Main", "medium")
                End If
                BuggerMe("End of looking for Logs!", "modMain.Main", "medium")
            End If
            Call EndSession()
        Catch ex As Exception
            LogError("modMain.Main", ex.Message.ToString)
        End Try
    End Sub

End Module
