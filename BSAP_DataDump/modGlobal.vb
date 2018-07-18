Imports BurnSoft.Universal
Module ModGlobal
    Public DoDebug As Boolean
    Public DebugLogfile As String
    Public Consolemode As Boolean
    Public MyLogFile As String
    Public UseEventLog As Boolean
    Public UseLogfile As Boolean
    Public AgentId As Long
    Public Dbhost As String
    Public ProcessId As Long
    Public BugfileLevel As String
    Public Sub LogError(sLocation As String, sMessage As String)
        Dim sMsg As String = "::" & sLocation & "::" & sMessage
        Try
            If UseLogfile Then
                Dim obj As New FileIO
                obj.LogFile(MyLogFile, sMsg)
                'obj = Nothing
            End If
            If CONSOLEMODE Then
                Console.WriteLine(sMsg)
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
        Try
            If UseEventLog Then
                'frmMain.EventLog1.WriteEntry(sMsg, EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
    End Sub
    Function ToLogOrNotToLog(level As String) As Boolean
        Dim bAns As Boolean = False
        Select Case LCase(BugfileLevel)
            Case "low"
                If LCase(level) = "low" Then
                    bAns = True
                End If
            Case "medium"
                If LCase(level) = "low" Or LCase(level) = "medium" Then
                    bAns = True
                End If
            Case "high"
                bAns = True
        End Select
        Return bAns
    End Function
    Public Sub BuggerMe(sMsg As String, Optional ByVal sLocation As String = "", Optional ByVal level As String = "low")
        If Len(sLocation) > 0 Then sMsg = sLocation & "::" & sMsg
        Try
            If DoDebug Then
                Dim obj As New FileIO
                If ToLogOrNotToLog(level) Then
                    obj.LogFile(DebugLogfile, sMsg)
                End If
                'obj = Nothing
                End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
        Try
            If DoDebug Then
                If UseEventLog Then
                    'frmMain.EventLog1.WriteEntry(sMsg, EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(sMsg)
        End Try
    End Sub
End Module

