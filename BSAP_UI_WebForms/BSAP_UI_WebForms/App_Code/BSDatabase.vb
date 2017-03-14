Imports MySql.Data.MySqlClient
Namespace BurnSoft
    Public Class BSDatabase
        Public conn As MySqlConnection
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

    End Class
End Namespace
