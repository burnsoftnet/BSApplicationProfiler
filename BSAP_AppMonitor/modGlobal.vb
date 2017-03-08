Imports BurnSoft.Universal
Module modGlobal
    Public PROCESS_NAME As String
    Public PROCESS_ID As Long
    Public AGENT_ID As Long
    Public DO_DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public USE_EVENT_LOG As Boolean
    Public USE_LOGFILE As Boolean
    Public DBHOST As String
    Public TIMER_INTERVAL As Long
    Public LAST_CPU_VALUE As Long
    Public Const USE_TEST_INIT = False
    Public Sub LogError(sLocation As String, sMessage As String)
        Dim sMsg As String = "::" & sLocation & "::" & sMessage
        If USE_LOGFILE Then
            Dim Obj As New FileIO
            Obj.LogFile(MyLogFile, sMsg)
            Obj = Nothing
        End If
        If CONSOLEMODE Then
            Console.WriteLine(sMsg)
        End If
    End Sub
    Public Sub BuggerMe(sMsg As String, Optional ByVal sLocation As String = "")
        If Len(sLocation) > 0 Then sMsg = sLocation & "::" & sMsg
        If DO_DEBUG Then
            Dim obj As New FileIO
            obj.LogFile(DEBUG_LOGFILE, sMsg)
            obj = Nothing
        End If
    End Sub
End Module
