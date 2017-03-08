Imports BurnSoft.Universal
Module modGlobal
    Public DO_DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public USE_EVENT_LOG As Boolean
    Public USE_LOGFILE As Boolean
    Public AGENT_ID As Long
    Public DBHOST As String
    Public Sub LogError(sLocation As String, sMessage As String)
        Dim sMsg As String = "::" & sLocation & "::" & sMessage
        Try
            If USE_LOGFILE Then
                Dim Obj As New FileIO
                Obj.LogFile(MyLogFile, sMsg)
                Obj = Nothing
            End If
            If CONSOLEMODE Then
                Console.WriteLine(sMsg)
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
        Try
            If USE_EVENT_LOG Then
                frmMain.EventLog1.WriteEntry(sMsg, EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
    End Sub
    Public Sub BuggerMe(sMsg As String, Optional ByVal sLocation As String = "")
        If Len(sLocation) > 0 Then sMsg = sLocation & "::" & sMsg
        Try
            If DO_DEBUG Then
                Dim obj As New FileIO
                obj.LogFile(DEBUG_LOGFILE, sMsg)
                obj = Nothing
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
        Try
            If DO_DEBUG Then
                If USE_EVENT_LOG Then
                    frmMain.EventLog1.WriteEntry(sMsg, EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
    End Sub
End Module
