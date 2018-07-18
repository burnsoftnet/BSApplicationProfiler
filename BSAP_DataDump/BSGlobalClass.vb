Imports MySql.Data.MySqlClient

Public Class BsDatabase
    Public Conn As MySqlConnection
    Private Function MyConnectionString() As String
        Dim sAns As String = "Server=" & Configuration.ConfigurationManager.AppSettings("DB_HOST")
        sAns &= ";user id=" & Configuration.ConfigurationManager.AppSettings("DB_UID")
        sAns &= ";password=" & Configuration.ConfigurationManager.AppSettings("DB_PWD")
        sAns &= ";persist security info=true"
        sAns &= ";database=" & Configuration.ConfigurationManager.AppSettings("DB_NAME")
        Return sAns
    End Function
    Public Function ConnectDb() As Integer
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
    Public Sub ConnExe(ByVal sql As String)
        Try
            If ConnectDB() = 0 Then
                Dim cmd As New MySqlCommand
                cmd.CommandText = SQL
                cmd.Connection = Conn
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
                'cmd = Nothing
                Call CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "BSGlobalClass.BSDatabase"
            Dim strSubFunc As String = "ConnExe"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call LogError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Public Sub CloseDb()
        If Conn.State <> ConnectionState.Closed Then
            Conn.Close()
        End If
        Conn = Nothing
    End Sub
End Class
Public Class BsSqliteDatabase
    Public Conn As SQLite.SQLiteConnection
    Private Function MyConnectionString() As String
        Return "Data Source=bsap_client.db"
    End Function
    Public Function ConnectDb() As Integer
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
    Public Sub ConnExe(sql As String)
        Try
            If ConnectDB() = 0 Then
                Dim cmd As New SQLite.SQLiteCommand
                With cmd
                    .CommandText = SQL
                    .Connection = Conn
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With
                'cmd = Nothing
                Call CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "BSGlobalClass.BSSQLiteDatabase"
            Dim strSubFunc As String = "ConnExe"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call LogError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Public Sub CloseDb()
        If Conn.State <> ConnectionState.Closed Then
            Conn.Close()
        End If
        Conn = Nothing
    End Sub
End Class