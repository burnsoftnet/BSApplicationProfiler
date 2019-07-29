Imports MySql.Data.MySqlClient
Imports BurnSoft
Imports System

Namespace BurnSoft.BSAP
    Public Class ProjectSessions
        ''' <summary>
        ''' Get the Project ID based on the Name of the project
        ''' </summary>
        ''' <param name="ProjectName"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns></returns>
        Public Function GetProjectIDbyName(ProjectName As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As Long
            Dim lAns As Long = 0
            Dim Obj As New BSDatabase
            Try
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select * from app_project_name where name='" & ProjectName & "'"
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        lAns = RS("id")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Obj = Nothing
            Return lAns
        End Function
        ''' <summary>
        ''' Get the Project Name from the Application Project Name ID ( APNID )
        ''' </summary>
        ''' <param name="APNID"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns></returns>
        Public Function GetProjectName(APNID As Long, Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As String
            Dim sAns As String = ""
            Dim Obj As New BSDatabase
            Try
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select * from app_project_name where ID=" & APNID
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        sAns = RS("name")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call Obj.CloseDB()
                Else
                    sAns = "Unable to Connect to Database"
                End If
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Obj = Nothing
            Return sAns
        End Function
        ''' <summary>
        ''' Get the Session start and End Date based on the SessionID
        ''' </summary>
        ''' <param name="SessionID"></param>
        ''' <param name="SessionStart"></param>
        ''' <param name="SessionEnd"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        Public Sub GetSessionTimes(SessionID As Long, ByRef SessionStart As String, ByRef SessionEnd As String, ByRef appversion As String, ByRef appcomany As String, ByRef applastaccess As String, ByRef applastwrite As String, ByRef createddatetime As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            Try
                Dim Obj As New BSDatabase
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select * from monitoring_session where id=" & SessionID
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        If Not Convert.IsDBNull(RS("sessiondt")) Then SessionStart = RS("sessiondt")
                        If Not Convert.IsDBNull(RS("sessionend")) Then
                            SessionEnd = RS("sessionend")
                        Else
                            SessionEnd = "In Progress"
                        End If
                        If Not Convert.IsDBNull(RS("appversion")) Then
                            appversion = RS("appversion")
                        Else
                            appversion = "N/A"
                        End If
                        If Not Convert.IsDBNull(RS("appcomany")) Then
                            appcomany = RS("appcomany")
                        Else
                            appcomany = "N/A"
                        End If
                        If Not Convert.IsDBNull(RS("applastaccess")) Then
                            applastaccess = RS("applastaccess")
                        Else
                            applastaccess = "N/A"
                        End If
                        If Not Convert.IsDBNull(RS("applastwrite")) Then
                            applastwrite = RS("applastwrite")
                        Else
                            applastwrite = "N/A"
                        End If
                        If Not Convert.IsDBNull(RS("createddatetime")) Then
                            createddatetime = RS("createddatetime")
                        Else
                            createddatetime = "N/A"
                        End If
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call Obj.CloseDB()
                Else
                    SessionStart = "N/A"
                    SessionEnd = "N/A"
                End If
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
        End Sub
        ''' <summary>
        ''' Get the Distinct value from a column in the process stats main table
        ''' based on the session id
        ''' </summary>
        ''' <param name="SessionID"></param>
        ''' <param name="sColumn"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns></returns>
        Private Function GetDistinctProcessDetails(SessionID As Long, sColumn As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As String
            Dim sAns As String = "N/A"
            Try
                Dim Obj As New BSDatabase
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select distinct(" & sColumn & ") as myvalue from process_stats_main where sessionid=" & SessionID
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        If Not IsDBNull(RS("myvalue")) Then sAns = RS("myvalue")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call Obj.CloseDB()
                End If
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Return sAns
        End Function
        ''' <summary>
        ''' get the ProcessName (imagename) username and command path
        ''' This is mostly used for the Session details pages.
        ''' </summary>
        ''' <param name="SessionID"></param>
        ''' <param name="imagename"></param>
        ''' <param name="username"></param>
        ''' <param name="commandline"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        Public Sub GetProcessDEtails(SessionID As Long, ByRef imagename As String, ByRef username As String, ByRef commandline As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            imagename = GetDistinctProcessDetails(SessionID, "imagename", errorID, errMsg)
            username = GetDistinctProcessDetails(SessionID, "username", errorID, errMsg)
            commandline = GetDistinctProcessDetails(SessionID, "commandline", errorID, errMsg)
        End Sub
    End Class
    Public Class AgentSessions
        ''' <summary>
        ''' return the computer name based on the ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns>registered computer name</returns>
        Public Function GetAgentNameFromID(ID As Long, Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As String
            Dim sAns As String = ""
            Try
                Dim Obj As New BSDatabase
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select computername from agents where id=" & ID
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim rs As MySqlDataReader
                    rs = CMD.ExecuteReader
                    While rs.Read
                        sAns = rs("computername")
                    End While
                    rs.Close()
                    rs = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
                Obj = Nothing
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Return sAns
        End Function
    End Class
    Public Class BSSessionDetailsStats
        ''' <summary>
        ''' Returns the average cpu,memory, handles and threads for that session
        ''' </summary>
        ''' <param name="SessionID"></param>
        ''' <param name="AvgCPU"></param>
        ''' <param name="avgMem"></param>
        ''' <param name="avgHandles"></param>
        ''' <param name="avgthreads"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        Public Sub getSessionAverage(SessionID As Long, ByRef AvgCPU As String, ByRef avgMem As String, ByRef avgHandles As String, ByRef avgthreads As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            Try
                Dim SQL As String = "SELECT AVG(cpu) AS avgcpu, AVG(memoryused) AS avgmem, AVG(handles) AS avghandles, AVG(threads) AS avgthreads FROM `process_stats_main` WHERE sessionid=" & SessionID
                Dim Obj As New BSDatabase
                If Obj.ConnectDB(errorID, errMsg) Then
                    Dim CMD As New MySqlCommand(SQL, Obj.conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read()
                        AvgCPU = Format(RS("avgcpu"), "0.00") & "%"
                        avgMem = Format(((Format(RS("avgmem"), "0.00") / 1024) / 1024), "0.00") & " MB"
                        avgHandles = Format(RS("avghandles"), "0.00")
                        avgthreads = Format(RS("avgthreads"), "0.00")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
                Obj = Nothing
            Catch ex As Exception
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
        End Sub

    End Class
End Namespace
