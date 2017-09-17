Imports MySql.Data.MySqlClient
Namespace BurnSoft
    Public Class BSDatabase
        Public Conn As MySqlConnection
        Private Function MyConnectionString() As String
            Dim sAns As String = "Server=" & System.Configuration.ConfigurationManager.AppSettings("DB_HOST")
            sAns &= ";user id=" & System.Configuration.ConfigurationManager.AppSettings("DB_UID")
            sAns &= ";password=" & System.Configuration.ConfigurationManager.AppSettings("DB_PWD")
            sAns &= ";persist security info=true"
            sAns &= ";database=" & System.Configuration.ConfigurationManager.AppSettings("DB_NAME")
            Return sAns
        End Function
        Public Function ConnectDB() As Integer
            Dim iAns As Integer = 0
            Err.Clear()
            Try
                Dim sConnect As String = MyConnectionString()
                Conn = New MySqlConnection(sConnect)
                Conn.Open()
            Catch ex As Exception
                iAns = Err.Number
                Dim strForm As String = "BSGlobalClass.BSDatabase"
                Dim strSubFunc As String = "ConnectDB"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call LogError(sMsg, strForm & "." & strSubFunc)
            End Try
            Return iAns
        End Function
        Public Sub ConnExe(ByVal SQL As String)
            Try
                If ConnectDB() = 0 Then
                    Dim CMD As New MySqlCommand
                    CMD.CommandText = SQL
                    CMD.Connection = Conn
                    CMD.ExecuteNonQuery()
                    CMD.Connection.Close()
                    CMD = Nothing
                    Call CloseDB()
                End If
            Catch ex As Exception
                Dim strForm As String = "BSGlobalClass.BSDatabase"
                Dim strSubFunc As String = "ConnExe"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call LogError(sMsg, strForm & "." & strSubFunc)
            End Try
        End Sub
        Public Sub CloseDB()
            If Conn.State <> ConnectionState.Closed Then
                Conn.Close()
            End If
            Conn = Nothing
        End Sub
    End Class
    Public Class BSSqliteDatabase
        Public Conn As SQLite.SQLiteConnection
        Private Function MyConnectionString() As String
            Return "Data Source=bsap_client.db"
        End Function
        Public Function ConnectDB() As Integer
            Dim iAns As Integer = 0
            Err.Clear()
            Try
                Dim sConnect As String = MyConnectionString()
                Conn = New SQLite.SQLiteConnection(sConnect)
                Conn.Open()
            Catch ex As Exception
                iAns = Err.Number
                Dim strForm As String = "BSGlobalClass.BSSqliteDatabase"
                Dim strSubFunc As String = "ConnectDB"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call LogError(sMsg, strForm & "." & strSubFunc)
            End Try
            Return iAns
        End Function
        Public Sub ConnExe(SQL As String)
            Try
                If ConnectDB() = 0 Then
                    Dim CMD As New SQLite.SQLiteCommand
                    With CMD
                        .CommandText = SQL
                        .Connection = Conn
                        .ExecuteNonQuery()
                        .Connection.Close()
                    End With
                    CMD = Nothing
                    Call CloseDB()
                End If
            Catch ex As Exception
                Dim strForm As String = "BSGlobalClass.BSSQLiteDatabase"
                Dim strSubFunc As String = "ConnExe"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call LogError(sMsg, strForm & "." & strSubFunc)
            End Try
        End Sub
        Public Sub CloseDB()
            If Conn.State <> ConnectionState.Closed Then
                Conn.Close()
            End If
            Conn = Nothing
        End Sub
    End Class
End Namespace
