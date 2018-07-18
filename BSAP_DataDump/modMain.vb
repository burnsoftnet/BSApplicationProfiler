Imports BurnSoft.Universal
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
'Imports System.IO
Module ModMain
    Dim _appPath As String
    Dim _sessionId As Long
    'Dim _appProjectMainProcessId As Long
#Region "Other Subs and Functions"
    ''' <summary>
    ''' Set Global Vars
    ''' </summary>
    Sub Init()
        If Len(Configuration.ConfigurationManager.AppSettings("APP_PATH")) = 0 Then
            _appPath = Application.StartupPath
        Else
            _appPath = Configuration.ConfigurationManager.AppSettings("APP_PATH")
        End If
        Dim objOf As New BSOtherObjects
        AgentId = objOf.GetCommand("agent", 0)

        BugfileLevel = Configuration.ConfigurationManager.AppSettings("BUGFILE_LEVEL")
        DoDebug = CBool(Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DebugLogfile = _appPath & "\" & Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MyLogFile = _appPath & "\" & Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        UseLogfile = CBool(Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
        DBHOST = Configuration.ConfigurationManager.AppSettings("DB_HOST")
    End Sub
    ''' <summary>
    ''' Properly exit the application
    ''' </summary>
    ''' <param name="exitValue"></param>
    Sub ExitApp(Optional ByVal exitValue As Integer = 0)
        Application.Exit()
        Environment.Exit(ExitValue)
    End Sub
#End Region
#Region "MySQL Database Sub and Functions"
    ''' <summary>
    ''' Insert data into the MySQL Database
    ''' </summary>
    ''' <param name="sql"></param>
    Sub ConnExec(sql As String)
        Dim obj As New BsDatabase
        obj.ConnExe(SQL)
        'obj = Nothing
    End Sub
    ''' <summary>
    ''' Create a new sessiont in the database
    ''' </summary>
    Sub CreateNewSession(apnid As Long, sessiondt As Date, sessionend As Date, appversion As String, appcomany As String, applastaccess As String, applastwrite As String, createddatetime As String)
        Dim sql As String = "INSERT INTO monitoring_session (APNID, AID,sessiondt,sessionendppversion, appcomany, applastaccess, applastwrite, createddatetime) VALUES (" &
            APNID & "," & AgentId & ",'" & sessiondt.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
            sessionend.ToString("yyyy-MM-dd HH:mm:ss") & "','" & appversion & "','" & appcomany & "','" & applastaccess & "','" & applastwrite & "','" & createddatetime & "')"
        Call ConnExec(sql)
    End Sub
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function GetSessionIdmySql(apnid As Long, sessiondt As Date) As Long
        Dim lAns As Long = 0
        Try
            Dim sql As String = "SELECT id from monitoring_session where APNID=" & APNID & " and AID=" & AgentId &
                                " and sessiondt='" & sessiondt.ToString("yyyy-MM-dd HH:mm:ss") & "' order by id desc limit 1"
            Dim obj As New BsDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New MySqlCommand(sql, obj.Conn)
                Dim rs As MySqlDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    lAns = rs("id")
                End While
                rs.Close()
                'rs = Nothing
                'cmd = Nothing
                obj.CloseDB()
                'obj = Nothing
            End If
        Catch ex As Exception
            Call LogError("modmain.getSessionIDMySQL", ex.Message.ToString)
        End Try
        Return lAns
    End Function
#End Region
#Region "SQLite Database Sub and Functions"
    ''' <summary>
    ''' Checks the local database to see if there are any sessions in the table.
    ''' </summary>
    ''' <returns></returns>
    Function HasWaitingSessions() As Boolean
        Dim bAns As Boolean = False
        Try
            Dim sql As String = "select * from monitoring_session"
            Dim obj As New BsSqliteDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                bAns = rs.HasRows
                rs.Close()
                'rs = Nothing
                'cmd = Nothing
                obj.CloseDB()
            End If
            'obj = Nothing
        Catch ex As Exception
            LogError("modMain.hasWaitingSessions", ex.Message.ToString)
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Start Processing the data from the local database and put it in the remote database
    ''' this will create the session and get the number then insert everything else as if it was
    ''' new but with the date it was created
    ''' </summary>
    Sub ProcessSessions()
        Try
            Dim sql As String = "select * from monitoring_session"
            Dim obj As New BsSqliteDatabase
            If obj.ConnectDB = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                Dim apnid As Long
                Dim aid As Long
                Dim sessiondt As String
                Dim sessionend As String
                'Dim sessionId As Long = 0
                Dim oldSessionId As Long
                Dim appversion As String
                Dim appcomany As String
                Dim applastaccess As String
                Dim applastwrite As String
                Dim createddatetime As String

                While rs.Read
                    apnid = rs("APNID")
                    aid = rs("AID")
                    sessiondt = rs("sessiondt")
                    sessionend = rs("sessionend")
                    oldSessionId = rs("ID")
                    appversion = rs("appversion")
                    appcomany = rs("appcomany")
                    applastaccess = rs("applastaccess")
                    applastwrite = rs("applastwrite")
                    createddatetime = rs("createddatetime")

                    Call CreateNewSession(apnid, sessiondt, sessionend, appversion, appcomany, applastaccess, applastwrite, createddatetime)
                    _sessionId = getSessionIDMySQL(apnid, sessiondt)
                    Call ProcessStatsMain(_sessionId, apnid, aid, oldSessionId)
                    Call ProcessStatsMainLogs(_sessionId, apnid, oldSessionId)
                End While
                rs.Close()
                'rs = Nothing
                'cmd = Nothing
                obj.CloseDB()
            End If
            'obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessSessions", ex.Message.ToString)
        End Try
    End Sub
    Sub ProcessStatsMain(sessionId As Long, apnid As Long, aid As Long, oldSessionId As Long)
        Try
            Dim iSql As String
            Dim sql As String = "select * from process_stats_main where SessionID=" & OldSessionID
            Dim obj As New BsSqliteDatabase
            If obj.ConnectDB() = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                Dim collectionDt As Date
                While rs.Read
                    collectionDt = rs("dt")
                    iSql = "INSERT process_stats_main (SessionID, apnid, apmpid, AID, dt," &
                            " imagename, username, cpu, memoryused, handles, threads, commandline) VALUES(" &
                            SessionID & "," & APNID & "," & rs("apmpid") & "," & AID & ",'" & collectionDt.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                            rs("imagename") & "','" & rs("username") & "'," & rs("cpu") & "," & rs("memoryused") & "," &
                            rs("handles") & "," & rs("threads") & ",'" & rs("commandline") & "')"
                    Call BuggerMe(iSql, "modMain.ProcessStatsMain", "high")
                    ConnExec(iSql)
                End While
                rs.Close()
                'rs = Nothing
                'cmd = Nothing
            End If
            'obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessStatsMain", ex.Message.ToString)
        End Try
    End Sub
    Sub ProcessStatsMainLogs(sessionId As Long, apnid As Long, oldSessionId As Long)
        Try
            Dim iSql As String
            Dim sql As String = "select * from logs_main where SessionID=" & OldSessionID
            Dim obj As New BsSqliteDatabase
            Dim objOf As New BSOtherObjects

            If obj.ConnectDB() = 0 Then
                Dim cmd As New SQLiteCommand(sql, obj.Conn)
                Dim rs As SQLiteDataReader
                rs = cmd.ExecuteReader
                While rs.Read
                    iSql = "INSERT logs_main (sessionid, APNID, filename, logdetails)" &
                    " VALUES(" & SessionID & "," & APNID & ",'" & rs("filename") & "','" & objOf.FC(rs("logdetails")) & "')"
                    Call BuggerMe(iSql, "modMain.ProcessStatsMainLogs", "high")
                    ConnExec(iSql)
                End While
                rs.Close()
                'rs = Nothing
                'cmd = Nothing
                obj.CloseDB()
            End If
            'obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessStatsMainLogs", ex.Message.ToString)
        End Try
    End Sub
    Sub ClearLocalDb()
        Dim obj As New BsSqliteDatabase
        Dim sql As String = "delete from "
        obj.ConnExe(sql & "logs_main")
        obj.ConnExe(sql & "process_stats_main")
        obj.ConnExe(sql & "monitoring_session")
    End Sub
#End Region
    Sub Main()
        Call Init()
        Dim objN As New BSNetwork
        If objN.DeviceIsUp(DBHOST) Then
            Call BuggerMe("Using Remote Database " & DBHOST, "modMain.Main")
            If hasWaitingSessions() Then
                Call BuggerMe("Found Sessions In local Database", "modMain.Main")
                Call ProcessSessions()
                Call ClearLocalDb()
            Else
                Call BuggerMe("No local session where found in database", "modMain.Main")
            End If
        Else
            Call BuggerMe("UNABLE TO CONNECT TO REMOTE DATABSE " & DBHOST, "modMain.Main")
            Call ExitApp(1)
        End If
    End Sub

End Module
