Imports BurnSoft.Universal
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Imports System.IO
Module modMain
    Dim _sessionId As Long
    Dim _appProjectMainProcessId As Long
    Dim _appPath As String
    Dim _uselocal As Boolean
    Dim _offline as Boolean
    Dim _param As string
    Private _updatedsession As Boolean
#Region "SQLite Database Function and Sub"
    ''' <summary>
    ''' Get the Application Project Main Process ID and also return if the application has logs or not
    ''' </summary>
    ''' <param name="processName">process name</param>
    ''' <param name="hasLogs">Pass to check for logs or not</param>
    ''' <returns>id</returns>
    Function GetAppProjectMainProcessSqlIte(processName As String, Optional ByRef hasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        Try
            Dim sql As String = "Select id, haslogs from app_project_main_process where process_name='" & processName & "' COLLATE NOCASE"
            Dim obj As New BurnSoft.BSSqliteDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    lAns = rs("id")
                    HasLogs = Convert10ToBool(rs("haslogs"))
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
            End If
            obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.getAppProjectMainProcessSQLite", ex.Message.ToString)
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' Gets the Log file name and path from the database for this main process
    ''' </summary>
    ''' <param name="apid">Application ID</param>
    ''' <returns>The Path of the logfile for that process</returns>
    Function GetLogPathSqLite(apid As Long) As String
        Dim sAns As String = ""
        Try
            Dim obj As New BurnSoft.BSSqliteDatabase
            If obj.ConnectDB() = 0 Then
                Dim sql As String = "select * from app_project_main_log where apmid=" & APID
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    sAns = rs("logpath") & "\" & rs("logname")
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
            End If
            obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.GetLogPathSQLite", ex.Message.ToString)
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function GetSessionIdsqLite() As Long
        Dim lAns As Long = 0
        Try
            Dim sql As String = "SELECT id from monitoring_session where APNID=" & PROCESS_ID & " and AID=" & AGENT_ID &
                                " order by id desc limit 1"
            Dim obj As New BurnSoft.BSSqliteDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    lAns = rs("id")
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
                obj = Nothing
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
    ''' <param name="processName"></param>
    ''' <param name="hasLogs"></param>
    ''' <returns>id</returns>
    Function GetAppProjectMainProcessMySql(processName As String, Optional ByRef hasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        Try
            Dim sql As String = "Select id, haslogs from app_project_main_process where process_name='" & processName & "'"
            Dim obj As New BurnSoft.BSDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New MySqlCommand(sql, obj.Conn)
                Dim rs As MySqlDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    lAns = rs("id")
                    hasLogs = Convert10ToBool(rs("haslogs"))
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
            End If
            obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.getAppProjectMainProcessMySQL", ex.Message.ToString)
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' Gets the Log file name and path from the database for this main process
    ''' </summary>
    ''' <param name="apid"></param>
    ''' <returns></returns>
    Function GetLogPathMySql(apid As Long) As String
        Dim sAns As String = ""
        Try
            Dim obj As New BurnSoft.BSDatabase
            If obj.ConnectDB() = 0 Then
                Dim sql As String = "select * from app_project_main_log where apmid=" & APID
                Dim cmd As New MySqlCommand(sql, obj.Conn)
                Dim rs As MySqlDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    sAns = rs("logpath") & "\" & rs("logname")
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
            End If
            obj = Nothing
        Catch ex As Exception
            Call LogError("modMain.GetLogPathMySQL", ex.Message.ToString)
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function GetSessionIdmySql() As Long
        Dim lAns As Long = 0
        Try
            Dim sql As String = "SELECT id from monitoring_session where APNID=" & PROCESS_ID & " and AID=" & AGENT_ID &
                                " order by id desc limit 1"
            Dim obj As New BurnSoft.BSDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New MySqlCommand(sql, obj.Conn)
                Dim rs As MySqlDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    lAns = rs("id")
                End While
                rs.Close()
                rs = Nothing
                cmd = Nothing
                obj.CloseDB()
                obj = Nothing
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
        _UPDATEDSESSION = False
        _sessionId = getSessionID()
    End Sub
    ''' <summary>
    ''' Mark the database that the process has exist the system to close to capture project
    ''' </summary>
    Sub EndSession()
        Dim sql As String = "UPDATE monitoring_session set sessionend=CURRENT_TIMESTAMP where ID=" & _sessionId
        Call ConnExec(sql)
    End Sub
    ''' <summary>
    ''' Get the main application ID doem the database based on the name of the process
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <param name="hasLogs"></param>
    ''' <returns></returns>
    Function GetAppProjectMainProcess(processName As String, Optional ByRef hasLogs As Boolean = False) As Long
        Dim lAns As Long = 0
        If Not _uselocal Then
            lAns = getAppProjectMainProcessMySQL(processName, hasLogs)
        Else
            lAns = GetAppProjectMainProcessSqlIte(processName, hasLogs)
        End If
        Return lAns
    End Function
    ''' <summary>
    ''' Get the Log Path and details based on the main application ID
    ''' </summary>
    ''' <param name="apid"></param>
    ''' <returns></returns>
    Function GetLogPath(apid As Long) As String
        Dim sAns As String = ""
        If Not _uselocal Then
            sAns = GetLogPathMySQL(apid)
        Else
            sAns = GetLogPathSQLite(apid)
        End If
        Return sAns
    End Function
    ''' <summary>
    ''' Move between the main database and the local database to execute sql statements
    ''' </summary>
    ''' <param name="SQL"></param>
    Sub ConnExec(SQL As String)
        If Not _uselocal Then
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
        If Not _uselocal Then
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
    ''' Update the Current Session with Details from the app such as version, company and dates that are in the application details.
    ''' </summary>
    ''' <param name="SID"></param>
    ''' <param name="appversion"></param>
    ''' <param name="appcomany"></param>
    ''' <param name="applastaccess"></param>
    ''' <param name="applastwrite"></param>
    ''' <param name="createddatetime"></param>
    Sub UpdateSessionWithAppDetails(SID As Long, appversion As String, appcomany As String, applastaccess As String, applastwrite As String, createddatetime As String)
        Try
            If Not _UPDATEDSESSION Then
                Dim SQL As String = "UPDATE monitoring_session set appversion='" & appversion & "', appcomany='" & appcomany & "', applastaccess='" & applastaccess &
                    "', applastwrite='" & applastwrite & "', createddatetime='" & createddatetime & "'  where ID=" & SID
                Call ConnExec(SQL)
                _UPDATEDSESSION = True
            End If
        Catch ex As Exception
            _UPDATEDSESSION = True
        End Try
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
    ''' Start the BSAP_SubAppMonior to look for any sub/child processes that may result from this main application
    ''' </summary>
    Sub StartSubProcessMonitor()
        'TODO:  Need to work this into running the subapp 
        Dim subApp As String = "BSAP_SubAppMonitor.exe"
        'Need to Pass Time_interval Process_ID and Main AgentID to Process

    End Sub
    ''' <summary>
    ''' Set Global Vars
    ''' </summary>
    Sub Init()
        If Not USE_TEST_INIT Then
            Dim objO As New BSOtherObjects
            PROCESS_NAME = objO.GetCommand("name", "")
            PROCESS_ID = objO.GetCommand("pid", 0)
            AGENT_ID = objO.GetCommand("aid", 0)
            _param = objO.GetCommand("param","")
            _offline = objO.GetCommand("offline",False)

            TIMER_INTERVAL = objO.GetCommand("interval", 0) * 60000
            If TIMER_INTERVAL = 0 Then
                TIMER_INTERVAL = System.Configuration.ConfigurationManager.AppSettings("TIMER_INTERVAL")
            End If
            objO = Nothing

            If Len(System.Configuration.ConfigurationManager.AppSettings("APP_PATH")) = 0 Then
                _appPath = Application.StartupPath
            Else
                _appPath = System.Configuration.ConfigurationManager.AppSettings("APP_PATH")
            End If

            BUGFILE_LEVEL = System.Configuration.ConfigurationManager.AppSettings("BUGFILE_LEVEL")
            DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            DEBUG_LOGFILE = _appPath & "\" & System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
            MyLogFile = _appPath & "\" & System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
            CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
            USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
            DBHOST = System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
        Else
            PROCESS_NAME = "BSMyGunCollection.exe"
            PROCESS_ID = 2
            AGENT_ID = 1
            TIMER_INTERVAL = 1 * 60000
        End If
        If (Not _offline) Then
            If PROCESS_ID = 0 Or AGENT_ID = 0 Then
                LogError("modMail.Init", "Missing Agent ID or Process ID")
                Call ExitApp()
            End If
        Else 
            If PROCESS_ID = 0 Then
                LogError("modMail.Init", "Missing Process ID")
                Call ExitApp()
            End If
        End If
        
    End Sub
    ''' <summary>
    ''' Properly exit the application
    ''' </summary>
    ''' <param name="exitValue"></param>
    Sub ExitApp(Optional ByVal exitValue As Integer = 0)
        Application.Exit()
        Environment.Exit(ExitValue)
    End Sub

    Sub GetExeDetails(fullAppPath As String)
        Try
            If Not _UPDATEDSESSION Then
                Dim objFs As New FileIO
                Dim appVersion As String = objFs.GetFileVersion(FullAppPath)
                Dim appComp As String = objFs.GetFileCompany(FullAppPath)
                Dim appLastAccess As String = objFs.GetLastAccessDateTime(FullAppPath)
                Dim appGetLastWrite As String = objFs.GetLastWriteDateTime(FullAppPath)
                Dim createdDateTime As String = objFs.GetCreationDateTime(FullAppPath)

                Call UpdateSessionWithAppDetails(_sessionId, appVersion, appComp, appLastAccess, appGetLastWrite, createdDateTime)
            End If
        Catch ex As Exception
            Dim sMsg As String = ex.Message.ToString
            Dim errorNum As Long = Err.Number
            Select Case errorNum
                Case 5
                    sMsg &= " ( " & FullAppPath & " )"
            End Select
            sMsg = Err.Number & "::" & sMsg
            _UPDATEDSESSION = True
            LogError("modMain.GetExeDetails", sMsg)
        End Try
    End Sub

    ''' <summary>
    ''' Collect the information needed to monitor the process
    ''' </summary>
    ''' <param name="myProcess"></param>
    ''' <param name="processActive"></param>
    Sub CollectData(myProcess As String, ByRef processActive As Boolean)
        Try
            Dim myPid As String = ""
            Dim processCount As Integer = 0
            Dim cpu As Double = 0
            Dim objP As New BurnSoft.BSProcessInfo
            Dim username As String = objP.GetProcessOwner(MyProcess)
            BuggerMe("username=" & username)
            ProcessActive = objP.ProcessExists(MyProcess, myPid, processCount)
            If ProcessActive Then
                Dim activePath As String = Replace(objP.GetProcessCommandLine(myPid), "\", "//")
                BuggerMe("Full Active Path: " & activePath)
                Dim fullAppPath As String = ""
                If IsDBNull(activePath) Then
                    fullAppPath = activePath.Replace(Chr(34), "")
                End If
                BuggerMe("FullPath Formated: " & fullAppPath)

                If not _offline Then If Not _UPDATEDSESSION Then Call GetExeDetails(fullAppPath)


                If LAST_CPU_VALUE = 0 Then
                    cpu = objP.GetCPUProcessStarting(Replace(MyProcess, ".exe", ""), LAST_CPU_VALUE)
                Else
                    cpu = objP.GetProcessCPUTime(Replace(MyProcess, ".exe", ""), LAST_CPU_VALUE, LAST_CPU_VALUE)
                End If
                If not _offline Then
                    Call InsertIntoProcessStats(_sessionId, PROCESS_ID, _appProjectMainProcessId, AGENT_ID, MyProcess, username,
                                                cpu, objP.GetProcessMemoryUseage(Replace(MyProcess, ".exe", "")),
                                                objP.GetProccessHandleCount(myPid), objP.GetProcessThreadCount(myPid), activePath)
                Else 
                    Call InsertIntoFile( MyProcess, username,
                                         cpu, objP.GetProcessMemoryUseage(Replace(MyProcess, ".exe", "")),
                                         objP.GetProccessHandleCount(myPid), objP.GetProcessThreadCount(myPid), activePath)
                End If

            End If
        Catch ex As Exception
            LogError("modMain.CollectData", ex.Message.ToString)
        End Try
    End Sub
    Sub InsertIntoFile (imagename As String,
                        username As String, cpu As String, memoryused As String, ihandles As String, threads As String,
                        commandline As String)
        Try
            Dim logName as String = String.Format("{0}-{1}.csv",imagename,DateTime.Now.ToString("yyyMMdd"))
        
            Dim obj as New FileIO
            Dim fullPath as String = _appPath & "\logs\" & logName

            If ( Not obj.FileExists(fullPath))
                'Dim sHeader = "User Name" & vbTab & "CPU" & vbTab & "Memory Used" & vbTab & "Handles" & vbTab & "Threads" & vbTab & "Command Line"
                Dim sHeader = "," & "User Name" & "," & "CPU" & "," & "Memory Used" & "," & "Handles" & "," & "Threads" & "," & "Command Line"
                obj.LogFile(fullPath,sHeader)
            End If

            'Dim sLine as String = username & vbTab & cpu & vbTab & memoryused & vbTab & ihandles & vbTab & threads & vbTab & commandline
            Dim sLine as String = "," & username & "," & cpu & "," & memoryused & "," & ihandles & "," & threads & "," & commandline
            obj.LogFile(fullPath,sLine)
        Catch ex As Exception
            LogError("modMain.InsertIntoFile", ex.Message.ToString)
        End Try

    End Sub
#End Region
    ''' <summary>
    ''' Starting Point for application
    ''' </summary>
    Sub Main()
        Try
            Call INIT()
            if Not _offline Then
                Dim objN As New BSNetwork
                If objN.DeviceIsUp(DBHOST) Then
                    _uselocal = False
                Else
                    _uselocal = True
                End If
                objN = Nothing
                If _uselocal Then
                    Call LogError("modMain.Main", "Unabled to connnect to database host " & DBHOST)
                    Call BuggerMe("Using Local Database", "modMain.Main")
                Else
                    Call BuggerMe("Using Remote Database " & DBHOST, "modMain.Main")
                End If

                Dim hasLogs As Boolean = False
                _appProjectMainProcessId = GetAppProjectMainProcess(PROCESS_NAME, hasLogs)
                BuggerMe("_appProjectMainProcessId=" & _appProjectMainProcessId)

                'Start up a session in the database
                Call StartSessionDetails()
                'Start Watching the process for details
                LAST_CPU_VALUE = 0
                Dim processActive As Boolean = True
                Do While processActive
                    Call BuggerMe("Starting Data Collection at " & Now, "modMain.Main", "medium")
                    Call CollectData(PROCESS_NAME, processActive)
                    Call BuggerMe("Ending Data Collection at " & Now, "modMain.Main", "medium")
                    If processActive Then Threading.Thread.Sleep(TIMER_INTERVAL)
                Loop

                'Check to see if there was any log files left by the application after it exit the system
                If hasLogs Then
                    BuggerMe("Looking for Logs!", "modMain.Main", "medium")
                    Dim logLocation As String = GetLogPath(_appProjectMainProcessId)
                    BuggerMe("LogFile: " & logLocation)
                    Dim objF As New FileIO
                    If objF.FileExists(logLocation) Then
                        BuggerMe("Processing Logs!", "modMain.Main", "medium")
                        Call ProcessLogFile(logLocation, objF.GetNameOfFile(logLocation), PROCESS_ID, _sessionId)
                        BuggerMe("Deleting log file!")
                        objF.DeleteFile(logLocation)
                    Else
                        BuggerMe(logLocation & " not found!", "modMain.Main", "medium")
                    End If
                    BuggerMe("End of looking for Logs!", "modMain.Main", "medium")
                End If
                'Mark the recording secction as ended in the database
                Call EndSession()
            Else 
                Call BuggerMe("OFFLINE MODE WRITING TO FLAT FILES", "modMain.Main")
                LAST_CPU_VALUE = 0
                Dim processActive As Boolean = True
                Do While processActive
                    Call BuggerMe("Starting Data Collection at " & Now, "modMain.Main", "medium")
                    Call CollectData(PROCESS_NAME, processActive)
                    Call BuggerMe("Ending Data Collection at " & Now, "modMain.Main", "medium")
                    If processActive Then Threading.Thread.Sleep(TIMER_INTERVAL)
                Loop
            End If
        Catch ex As Exception
            LogError("modMain.Main", ex.Message.ToString)
        End Try            
    End Sub

End Module
