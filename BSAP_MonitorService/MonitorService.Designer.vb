﻿Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitorService
    Inherits ServiceBase

    'UserService overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'MonitorService
        '
        Me.CanShutdown = True
        Me.ServiceName = "BurnSoft Application Profiler Monitor"
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents EventLog1 As EventLog
    Friend WithEvents Timer1 As Timer
End Class
