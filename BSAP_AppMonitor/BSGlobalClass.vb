Imports System.Management
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
    Public Class BSProcessInfo
        ''' <summary>
        ''' Simple WMI Call just pass the Object then the desciption of the object to look for
        ''' </summary>
        ''' <param name="sObject"></param>
        ''' <param name="sValue"></param>
        ''' <returns>value</returns>
        Private Function GetManagementObject(sObject As String, sValue As String) As String
            Dim Obj As ManagementObject = New ManagementObject(sObject)
            Dim sAns As String = CStr(Obj(sValue))
            Obj.Dispose()
            Obj = Nothing
            Return sAns
        End Function
        Private Function GetProcessInfoByPID(PID As String, sObject As String) As String
            Dim sAns As String = ""
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId=" & PID)

            For Each process As ManagementObject In searcher.Get()
                sAns = process(sObject)
            Next
            searcher = Nothing
            Return sAns
        End Function
        ''' <summary>
        ''' Get the owner of the selected process by name
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns></returns>
        Public Function GetProcessOwner(PID As String) As String
            Dim sAns As String = ""
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE name ='" & PID & "'")

            For Each process As ManagementObject In searcher.Get()
                Dim s(1) As String
                process.InvokeMethod("GetOwner", CType(s, Object()))
                sAns = (s(1) & "\\" & s(0))
            Next
            searcher = Nothing
            Return sAns
        End Function
        ''' <summary>
        ''' Get the handlecount for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>Count</returns>
        Public Function GetProccessHandleCount(PID As String) As String
            Return GetProcessInfoByPID(PID, "HandleCount")
        End Function
        ''' <summary>
        ''' Get the ThreadCount for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>Count</returns>
        Public Function GetProcessThreadCount(PID As String) As String
            Return GetProcessInfoByPID(PID, "ThreadCount")
        End Function
        ''' <summary>
        ''' Get the TerminationDate for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>Termination Date</returns>
        Public Function GetProcessTerminationDate(PID As String) As String
            Return GetProcessInfoByPID(PID, "TerminationDate")
        End Function
        ''' <summary>
        ''' Get the Caption for a particular Process by PID
        ''' Short description of an object—a one-line string.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>string</returns>
        Public Function GetProcessCaption(PID As String) As String
            Return GetProcessInfoByPID(PID, "Caption")
        End Function
        ''' <summary>
        ''' Get the CommandLine for a particular Process by PID
        ''' Command line used to start a specific process, if applicable.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>string</returns>
        Public Function GetProcessCommandLine(PID As String) As String
            Return GetProcessInfoByPID(PID, "CommandLine")
        End Function
        ''' <summary>
        ''' Get the CreationDate for a particular Process by PID
        ''' Date the process begins executing.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>datetime as string</returns>
        Public Function GetProcessCreationDate(PID As String) As String
            Return GetProcessInfoByPID(PID, "CreationDate")
        End Function
        ''' <summary>
        ''' Get the Description for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <returns>Description of an object.</returns>
        Public Function GetProcessDescription(PID As String) As String
            Return GetProcessInfoByPID(PID, "Description")
        End Function
        ''' <summary>
        ''' Get the ExecutablePath for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Path to the executable file of the process.</return>
        Public Function GetProcessExecutablePath(PID As String) As String
            Return GetProcessInfoByPID(PID, "ExecutablePath")
        End Function
        ''' <summary>
        ''' Get the ExecutionState for a particular Process by PID
        ''' Unknown (0)
        ''' Other (1)
        ''' Ready (2)
        ''' Running (3)
        ''' Blocked (4)
        ''' Suspended Blocked (5)
        ''' Suspended Ready (6)
        ''' Terminated (7)
        ''' Stopped (8)
        ''' Growing (9)
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Current operating condition of the process</return>
        Public Function GetProcessExecutionState(PID As String) As String
            Return GetProcessInfoByPID(PID, "ExecutionState")
        End Function
        ''' <summary>
        ''' Get the PageFaults for a particular Process by PID
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Number of page faults that a process generates.</return>
        Public Function GetProcessPageFaults(PID As String) As String
            Return GetProcessInfoByPID(PID, "PageFaults")
        End Function
        ''' <summary>
        ''' Get the PageFileUsage for a particular Process by PID
        ''' Amount of page file space that a process is using currently. 
        ''' This value is consistent with the VMSize value in TaskMgr.exe.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("kilobytes")</return>
        Public Function GetProcessPageFileUsage(PID As String) As String
            Return GetProcessInfoByPID(PID, "PageFileUsage")
        End Function
        ''' <summary>
        ''' Get the ParentProcessId for a particular Process by PID
        ''' Unique identifier of the process that creates a process. Process 
        ''' identifier numbers are reused, so they only identify a process for 
        ''' the lifetime of that process. It is possible that the process identified 
        ''' by ParentProcessId is terminated, so ParentProcessId may not refer to 
        ''' a running process. It is also possible that ParentProcessId incorrectly 
        ''' refers to a process that reuses a process identifier. You can use the 
        ''' CreationDate property to determine whether the specified parent was 
        ''' created after the process represented by this Win32_Process instance was created
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Parent Process Id</return>
        Public Function GetProcessParentProcessId(PID As String) As String
            Return GetProcessInfoByPID(PID, "ParentProcessId")
        End Function
        ''' <summary>
        ''' Get the PeakPageFileUsage for a particular Process by PID
        ''' Maximum amount of page file space used during the life of a process.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("kilobytes")</return>
        Public Function GetProcessPeakPageFileUsage(PID As String) As String
            Return GetProcessInfoByPID(PID, "PeakPageFileUsage")
        End Function
        ''' <summary>
        ''' Get the PeakVirtualSize for a particular Process by PID
        ''' Maximum virtual address space a process uses at any one time. 
        ''' Using virtual address space does not necessarily imply corresponding
        ''' use of either disk or main memory pages. However, virtual space is 
        ''' finite, and by using too much the process might not be able to load 
        ''' libraries.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("bytes")</return>
        Public Function GetProcessPeakVirtualSize(PID As String) As String
            Return GetProcessInfoByPID(PID, "PeakVirtualSize")
        End Function
        ''' <summary>
        ''' Get the PeakWorkingSetSize for a particular Process by PID
        ''' Peak working set size of a process.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("kilobytes")</return>
        Public Function GetProcessPeakWorkingSetSize(PID As String) As String
            Return GetProcessInfoByPID(PID, "PeakWorkingSetSize")
        End Function
        ''' <summary>
        ''' Get the PrivatePageCount for a particular Process by PID
        ''' Current number of pages allocated that are only accessible to the process 
        ''' represented by this Win32_Process instance.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>count</return>
        Public Function GetProcessPrivatePageCount(PID As String) As String
            Return GetProcessInfoByPID(PID, "PrivatePageCount")
        End Function
        ''' <summary>
        ''' Get the SessionId for a particular Process by PID
        ''' Unique identifier that an operating system generates when a 
        ''' session is created. A session spans a period of time from logon 
        ''' until logoff from a specific system.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>sessionID</return>
        Public Function GetProcessSessionId(PID As String) As String
            Return GetProcessInfoByPID(PID, "SessionId")
        End Function
        ''' <summary>
        ''' Get the UserModeTime for a particular Process by PID
        ''' Time in user mode, in 100 nanosecond units. If this information 
        ''' is not available, use a value of 0 (zero).
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("100 nanoseconds")</return>
        Public Function GetProcessUserModeTime(PID As String) As String
            Return GetProcessInfoByPID(PID, "UserModeTime")
        End Function
        ''' <summary>
        ''' Get the VirtualSize for a particular Process by PID
        ''' Current size of the virtual address space that a process is using, not
        ''' the physical or virtual memory actually used by the process. Using virtual 
        ''' address space does not necessarily imply corresponding use of either disk 
        ''' or main memory pages. Virtual space is finite, and by using too much, the 
        ''' process might not be able to load libraries. This value is consistent with 
        ''' what you see in Perfmon.exe.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("bytes")</return>
        Public Function GetProcessVirtualSize(PID As String) As String
            Return GetProcessInfoByPID(PID, "VirtualSize")
        End Function
        ''' <summary>
        ''' Get the WorkingSetSize for a particular Process by PID
        ''' Amount of memory in bytes that a process needs to execute efficiently—for 
        ''' an operating system that uses page-based memory management. If the system 
        ''' does not have enough memory (less than the working set size), thrashing occurs. 
        ''' If the size of the working set is not known, use NULL or 0 (zero). If working 
        ''' set data is provided, you can monitor the information to understand the changing 
        ''' memory requirements of a process.
        ''' </summary>
        ''' <param name="PID"></param>
        ''' <return>Units ("bytes")</return>
        Public Function GetProcessWorkingSetSize(PID As String) As String
            Return GetProcessInfoByPID(PID, "WorkingSetSize")
        End Function

        ''' <summary>
        ''' Check to see if a process exists by name, Optionally get the PID and Process Count for the result(s)
        ''' </summary>\
        ''' <param name="sProcessName"></param>
        ''' <param name="PID"></param>
        ''' <param name="ProcessCount"></param>
        ''' <returns>true/false</returns>
        Public Function ProcessExists(ProcessName As String, Optional ByRef PID As String = "", Optional ByRef ProcessCount As Integer = 0) As Boolean
            Dim bAns As Boolean = False
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name like '" &
                                                         ProcessName & "%'")

            For Each process As ManagementObject In searcher.Get()
                bAns = True
                ProcessCount += 1
                PID &= process("ProcessId")
            Next
            searcher = Nothing
            Return bAns
        End Function
        ''' <summary>
        ''' Check to see if a process exists by name and what might be in the commandline parameters, Optionally get the PID and Process Count for the result(s)
        ''' </summary>
        ''' <param name="sProcessName"></param>
        ''' <param name="CommandLineContains"></param>
        ''' <param name="PID"></param>
        ''' <param name="ProcessCount"></param>
        ''' <returns>true/false</returns>
        Public Function ProcessExists(ProcessName As String, CommandLineContains As String, Optional ByRef PID As String = "", Optional ByRef ProcessCount As Integer = 0) As Boolean
            Dim bAns As Boolean = False
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name like '" &
                                                         ProcessName & "%' and CommandLine Like '%" &
                                                         CommandLineContains & "%'")

            For Each process As ManagementObject In searcher.Get()
                bAns = True
                ProcessCount += 1
                PID &= process("ProcessId")
            Next
            searcher = Nothing
            Return bAns
        End Function
        ''' <summary>
        ''' Check to see if a process is running or not.
        ''' </summary>
        ''' <param name="sProcessName"></param>
        ''' <returns>true/false</returns>
        Public Function ProcessExists(sProcessName As String, Optional ByRef ProcessCount As Integer = 0) As Boolean
            Dim bAns As Boolean = False
            Dim p() As Process
            p = Process.GetProcessesByName(sProcessName)
            ProcessCount = p.Count
            If p.Count > 0 Then
                bAns = True
            End If
            p = Nothing
            Return bAns
        End Function
        ''' <summary>
        ''' Use the Performance counter Process/Working Set - Private to get the 
        ''' memory that is used for a process
        ''' </summary>
        ''' <param name="ProcessName"></param>
        ''' <returns>memory in bytes</returns>
        Public Function GetProcessMemoryUseage(ProcessName As String) As String
            Dim sAns As String = ""
            Dim o As New System.Diagnostics.PerformanceCounter("Process", "Working Set - Private", ProcessName)
            sAns = o.RawValue
            o.Close()
            Return sAns
        End Function
        Public Function GetProcessCPUTime(ProcessName As String, OldValue As Double, ByRef NewValue As Double) As String
            Dim sAns As String = ""
            Dim o As New System.Diagnostics.PerformanceCounter("Process", "% Processor Time", ProcessName)
            If OldValue = 0 Then
                sAns = "0"
                NewValue = o.RawValue
            Else
                NewValue = o.RawValue
                'Dim cpu As Double = (NewValue - OldValue) / Environment.ProcessorCount
                Dim cpu As Double = (((NewValue - OldValue) / TIMER_INTERVAL) / Environment.ProcessorCount) / 100
                sAns = FormatNumber(cpu, 2)
            End If
            o.Close()
            'sAns &= sAns & " %"
            Return sAns
        End Function
        Public Function GetCPUProcessStarting(ProcessName As String, ByRef NewValue As Double) As String
            Dim sAns As String = ""
            Call GetProcessCPUTime(ProcessName, 0, NewValue)
            sAns = GetProcessCPUTime(ProcessName, NewValue, NewValue)
            Return sAns
        End Function

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
