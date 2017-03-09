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
                If ConnectDB() Then
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
    End Class
End Namespace
