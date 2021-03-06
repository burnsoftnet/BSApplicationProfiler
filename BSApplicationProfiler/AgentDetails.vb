﻿Imports BurnSoft
Imports System.Management
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class AgentDetails
    ''' <summary>
    ''' Checks to see if agent exists in the database
    ''' </summary>
    ''' <param name="sHost"></param>
    ''' <param name="AgentID"></param>
    ''' <returns></returns>
    Private Function AgentExists(sHost As String, Optional ByRef AgentID As Long = 0) As Boolean
        Dim bAns As Boolean = False
        Dim Obj As New BurnSoft.BSDatabase
        If Obj.ConnectDB = 0 Then
            Dim SQL As String = "SELECT * from agents where computername='" & sHost & "'"
            Dim CMD As New MySqlCommand(SQL, Obj.Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            If RS.HasRows Then
                bAns = True
                While RS.Read()
                    AgentID = RS("id")
                End While
                RS.Close()
            End If
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
        End If
        Obj = Nothing
        Return bAns
    End Function
    ''' <summary>
    ''' Get the agent id, insert into database if not exists, otherwise update database with client info
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAgentID() As Long
        Dim lAns As Long = 0
        Dim Obj As New Universal.BSSystemInfo
        Dim HostName As String = Obj.GetComputerName
        Dim pMem As String = Obj.GetPhysicalMemory
        Dim cpuInfo As String = Obj.GetCPUName
        Dim CpuSpeed As String = Obj.GetCPUSpeed
        Dim HostOS As String = My.Computer.Info.OSFullName
        Dim bAgent As Boolean = AgentExists(HostName, lAns)
        Dim SQL As String = "INSERT INTO agents (computername,maxmem,cpuspeed,cpuname,operatingsystem,dtReported) VALUES" &
                    "('" & HostName & "','" & pMem & "','" & CpuSpeed & "','" & cpuInfo & "','" & HostOS & "',CURRENT_TIMESTAMP)"
        If bAgent Then
            SQL = "UPDATE agents set computername='" & HostName & "',maxmem='" & pMem & "',cpuspeed='" & CpuSpeed & "',cpuname='" & cpuInfo & "',operatingsystem='" & HostOS & "',dtReported=CURRENT_TIMESTAMP where id=" & lAns
        End If
        Dim ObjDB As New BurnSoft.BSDatabase
        ObjDB.ConnExe(SQL)
        ObjDB = Nothing
        Obj = Nothing
        If Not bAgent Then AgentExists(HostName, lAns)
        Return lAns
    End Function
    ''' <summary>
    ''' Heartbeat to report back that agent i still running.
    ''' </summary>
    ''' <param name="AgentID"></param>
    Public Sub UpdateHeartBeat(AgentID As Long)
        Dim Obj As New BurnSoft.BSDatabase
        Dim SQL As String = "UPDATE agents set dtReported=CURRENT_TIMESTAMP where id=" & AgentID
        Obj.ConnExe(SQL)
        Obj = Nothing
    End Sub
End Class
