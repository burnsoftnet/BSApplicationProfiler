Imports MySql.Data.MySqlClient
Namespace BurnSoft
    Public Class BSDatabase
        Dim conn As MySqlConnection
        ''' <summary>
        ''' Get the connection string from the web.config.  This method is a little outdate when i just could habe
        ''' call the connection string directly, but just incase you needed re format the string and method
        ''' </summary>
        ''' <returns></returns>
        Function ConnectString() As String
            Return System.Configuration.ConfigurationManager.ConnectionStrings("bsap").ToString
        End Function
        ''' <summary>
        ''' Connect to a MySQL Database
        ''' </summary>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns></returns>
        Public Function ConnectDB(Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As Boolean
            Dim bAns As Boolean = False
            Try
                conn = New MySqlConnection(ConnectString)
                conn.Open()
                bAns = True
            Catch ex As Exception
                errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Return bAns
        End Function
        ''' <summary>
        ''' Close the connection to the database
        ''' </summary>
        Public Sub CloseDB()
            Try
                conn.Close()
                conn = Nothing
            Catch ex As Exception
                conn = Nothing
            End Try
        End Sub
        ''' <summary>
        ''' Get the Project Name from the Application Project Name ID ( APNID )
        ''' </summary>
        ''' <param name="APNID"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        ''' <returns></returns>
        Public Function GetProjectName(APNID As Long, Optional ByRef errorID As Long = 0, Optional errMsg As String = "") As String
            Dim sAns As String = ""
            Try
                If ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select * from app_project_name where ID=" & APNID
                    Dim CMD As New MySqlCommand(SQL, conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        sAns = RS("name")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call CloseDB()
                Else
                    sAns = "Unable to Connect to Database"
                End If
            Catch ex As Exception
                errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
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
        Public Sub GetSessionTimes(SessionID As Long, ByRef SessionStart As String, ByRef SessionEnd As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            Try
                If ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select * from monitoring_session where id=" & SessionID
                    Dim CMD As New MySqlCommand(SQL, conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        If Not IsDBNull(RS("sessiondt")) Then SessionStart = RS("sessiondt")
                        If Not IsDBNull(RS("sessionend")) Then
                            SessionEnd = RS("sessionend")
                        Else
                            SessionEnd = "In Progress"
                        End If
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call CloseDB()
                Else
                    SessionStart = "N/A"
                    SessionEnd = "N/A"
                End If
            Catch ex As Exception
                errorID = Err.Number
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
                If ConnectDB(errorID, errMsg) Then
                    Dim SQL As String = "select distinct(" & sColumn & ") as myvalue from process_stats_main where sessionid=" & SessionID
                    Dim CMD As New MySqlCommand(SQL, conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        If Not IsDBNull(RS("myvalue")) Then sAns = RS("myvalue")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Call CloseDB()
                End If
            Catch ex As Exception
                errorID = Err.Number
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
End Namespace
