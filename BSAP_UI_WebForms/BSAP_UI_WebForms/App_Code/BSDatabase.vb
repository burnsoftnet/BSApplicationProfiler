Imports MySql.Data.MySqlClient
Namespace BurnSoft
    Public Class BSDatabase
        Dim conn As MySqlConnection
        Function ConnectString() As String
            Return System.Configuration.ConfigurationManager.ConnectionStrings("bsap").ToString
        End Function

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
        Public Sub CloseDB()
            Try
                conn.Close()
                conn = Nothing
            Catch ex As Exception
                conn = Nothing
            End Try
        End Sub
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
        Public Sub GetSessionTimes(SessionID As Long, ByRef SessionStart As String, SessionEnd As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
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
        Public Sub GetProcessDEtails(SessionID As Long, ByRef imagename As String, username As String, commandline As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            imagename = GetDistinctProcessDetails(SessionID, "imagename", errorID, errMsg)
            username = GetDistinctProcessDetails(SessionID, "username", errorID, errMsg)
            commandline = GetDistinctProcessDetails(SessionID, "commandline", errorID, errMsg)
        End Sub
    End Class
End Namespace
