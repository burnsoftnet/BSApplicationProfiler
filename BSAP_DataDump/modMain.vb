Imports BurnSoft.Universal
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite
Imports System.IO
Module modMain
    Dim APP_PATH As String
    Dim SESSION_ID As Long
    Dim APP_PROJECT_MAIN_PROCESS_ID As Long
#Region "Other Subs and Functions"
    ''' <summary>
    ''' Set Global Vars
    ''' </summary>
    Sub Init()
        If Len(System.Configuration.ConfigurationManager.AppSettings("APP_PATH")) = 0 Then
            APP_PATH = Application.StartupPath
        Else
            APP_PATH = System.Configuration.ConfigurationManager.AppSettings("APP_PATH")
        End If
        Dim ObjOF As New BSOtherObjects
        AGENT_ID = ObjOF.GetCommand("agent", 0)

        DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DEBUG_LOGFILE = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MyLogFile = APP_PATH & "\" & System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
        DBHOST = System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
    End Sub
    ''' <summary>
    ''' Properly exit the application
    ''' </summary>
    ''' <param name="ExitValue"></param>
    Sub ExitApp(Optional ByVal ExitValue As Integer = 0)
        Application.Exit()
        Environment.Exit(ExitValue)
    End Sub
#End Region
#Region "MySQL Database Sub and Functions"
    ''' <summary>
    ''' Insert data into the MySQL Database
    ''' </summary>
    ''' <param name="SQL"></param>
    Sub ConnExec(SQL As String)
        Dim Obj As New BurnSoft.BSDatabase
        Obj.ConnExe(SQL)
        Obj = Nothing
    End Sub
    ''' <summary>
    ''' Create a new sessiont in the database
    ''' </summary>
    Sub CreateNewSession(APNID As Long, sessiondt As Date, sessionend As Date)
        Dim SQL As String = "INSERT INTO monitoring_session (APNID, AID,sessiondt,sessionend) VALUES (" &
            APNID & "," & AGENT_ID & ",'" & sessiondt.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
            sessionend.ToString("yyyy-MM-dd HH:mm:ss") & "')"
        Call ConnExec(SQL)
    End Sub
    ''' <summary>
    ''' Get the latest session that was just entered into the database
    ''' </summary>
    ''' <returns>id</returns>
    Function getSessionIDMySQL(APNID As Long, sessiondt As Date) As Long
        Dim lAns As Long = 0
        Try
            Dim SQL As String = "SELECT id from monitoring_session where APNID=" & APNID & " and AID=" & AGENT_ID &
                                " and sessiondt='" & sessiondt.ToString("yyyy-MM-dd HH:mm:ss") & "' order by id desc limit 1"
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
#Region "SQLite Database Sub and Functions"
    ''' <summary>
    ''' Checks the local database to see if there are any sessions in the table.
    ''' </summary>
    ''' <returns></returns>
    Function hasWaitingSessions() As Boolean
        Dim bAns As Boolean = False
        Try
            Dim SQL As String = "select * from monitoring_session"
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                bAns = RS.HasRows
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
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
            Dim SQL As String = "select * from monitoring_session"
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                Dim APNID As Long = 0
                Dim AID As Long = 0
                Dim sessiondt As String = ""
                Dim sessionend As String = ""
                Dim SessionID As Long = 0
                Dim OldSessionID As Long = 0
                While RS.Read
                    APNID = RS("APNID")
                    AID = RS("AID")
                    sessiondt = RS("sessiondt")
                    sessionend = RS("sessionend")
                    OldSessionID = RS("ID")
                    Call CreateNewSession(APNID, sessiondt, sessionend)
                    SESSION_ID = getSessionIDMySQL(APNID, sessiondt)
                    Call ProcessStatsMain(SESSION_ID, APNID, AID, OldSessionID)
                    Call ProcessStatsMainLogs(SESSION_ID, APNID, OldSessionID)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessSessions", ex.Message.ToString)
        End Try
    End Sub
    Sub ProcessStatsMain(SessionID As Long, APNID As Long, AID As Long, OldSessionID As Long)
        Try
            Dim iSQL As String = ""
            Dim SQL As String = "select * from process_stats_main where SessionID=" & OldSessionID
            Dim Obj As New BurnSoft.BSSqliteDatabase
            If Obj.ConnectDB() = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                Dim CollectionDT As Date
                While RS.Read
                    CollectionDT = RS("dt")
                    iSQL = "INSERT process_stats_main (SessionID, apnid, apmpid, AID, dt," &
                            " imagename, username, cpu, memoryused, handles, threads, commandline) VALUES(" &
                            SessionID & "," & APNID & "," & RS("apmpid") & "," & AID & ",'" & CollectionDT.ToString("yyyy-MM-dd HH:mm:ss") & "','" &
                            RS("imagename") & "','" & RS("username") & "'," & RS("cpu") & "," & RS("memoryused") & "," &
                            RS("handles") & "," & RS("threads") & ",'" & RS("commandline") & "')"
                    ConnExec(iSQL)
                    Call BuggerMe(iSQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                'TODO: verify that this does note close the ProcessSessions connection
                'Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessStatsMain", ex.Message.ToString)
        End Try
    End Sub
    Sub ProcessStatsMainLogs(SessionID As Long, APNID As Long, OldSessionID As Long)
        Try
            Dim iSQL As String = ""
            Dim SQL As String = "select * from logs_main where SessionID=" & OldSessionID
            Dim Obj As New BurnSoft.BSSqliteDatabase
            Dim ObjOF As New BSOtherObjects

            If Obj.ConnectDB() = 0 Then
                Dim CMD As New SQLiteCommand(SQL, Obj.Conn)
                Dim RS As SQLiteDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    iSQL = "INSERT logs_main (sessionid, APNID, filename, logdetails)" &
                    " VALUES(" & SessionID & "," & APNID & ",'" & RS("filename") & "','" & ObjOF.FC(RS("logdetails")) & "')"
                    Call BuggerMe(iSQL)
                    ConnExec(iSQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
            Obj = Nothing
        Catch ex As Exception
            LogError("modMain.ProcessStatsMainLogs", ex.Message.ToString)
        End Try
    End Sub
    Sub ClearLocalDb()
        Dim Obj As New BurnSoft.BSSqliteDatabase
        Dim SQL As String = "delete from "
        Obj.ConnExe(SQL & "logs_main")
        Obj.ConnExe(SQL & "process_stats_main")
        Obj.ConnExe(SQL & "monitoring_session")
    End Sub
#End Region
    Sub Main()
        Call Init()
        Dim ObjN As New BSNetwork
        If ObjN.DeviceIsUp(DBHOST) Then
            Call BuggerMe("Using Remote Database " & DBHOST)
            If hasWaitingSessions() Then
                Call BuggerMe("Found Sessions In local Database")
                Call ProcessSessions()
                Call ClearLocalDb()
            Else
                Call BuggerMe("No local session where found in database")
            End If
        Else
            Call BuggerMe("UNABLE TO CONNECT TO REMOTE DATABSE " & DBHOST)
            Call ExitApp(1)
        End If
    End Sub

End Module
