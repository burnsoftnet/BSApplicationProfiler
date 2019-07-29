Imports MySql.Data.MySqlClient
Imports System
Namespace BurnSoft
    Public Class BSDatabase
        Public conn As MySqlConnection
        ''' <summary>
        ''' Get the connection string from the web.config.  This method is a little outdate when i just could habe
        ''' call the connection string directly, but just incase you needed re format the string and method
        ''' </summary>
        ''' <returns></returns>
        Function ConnectString() As String
            Return Configuration.ConfigurationManager.ConnectionStrings("bsap").ToString
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
                ''errorID = Err.Number
                errMsg = ex.Message.ToString
            End Try
            Return bAns
        End Function
        ''' <summary>
        ''' Close the connection to the database
        ''' </summary>
        Public Sub CloseDB()
            Try
                'If IsDBNull(conn) Then
                conn.Close()
                ' ElseIf conn.State = ConnectionState.Open And conn.State <> ConnectionState.Executing Then
                '    conn.Close()
                'End If
                conn = Nothing
            Catch ex As Exception
                conn = Nothing
            End Try
        End Sub
        ''' <summary>
        ''' A quick and Easy Execution on a T-SQL query, greate for everything except SELECT Statements
        ''' </summary>
        ''' <param name="SQL"></param>
        ''' <param name="errorID"></param>
        ''' <param name="errMsg"></param>
        Public Sub ConnEXE(SQL As String, Optional ByRef errorID As Long = 0, Optional errMsg As String = "")
            Try
                If ConnectDB() Then
                    Dim CMD As New MySqlCommand
                    CMD.CommandText = SQL
                    CMD.Connection = conn
                    CMD.ExecuteNonQuery()
                    CMD.Connection.Close()
                    CMD = Nothing
                    Call CloseDB()
                Else
                    conn = Nothing
                End If

            Catch ex As Exception
                ''errorID = 'Err.Number
                errMsg = ex.Message.ToString
            End Try
        End Sub
    End Class
End Namespace
