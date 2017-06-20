<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ServiceInstaller1 = New System.ServiceProcess.ServiceInstaller()
        Me.ServiceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller()
        '
        'ServiceInstaller1
        '
        Me.ServiceInstaller1.Description = "Monitors the database for new entries and emails alerts if a new entry is found a" &
    "nd or if logs were inserted"
        Me.ServiceInstaller1.DisplayName = "BurnSoft Application Profiler Monitor"
        Me.ServiceInstaller1.ServiceName = "BSAPM"
        Me.ServiceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ServiceProcessInstaller1
        '
        Me.ServiceProcessInstaller1.Password = Nothing
        Me.ServiceProcessInstaller1.Username = Nothing
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceInstaller1, Me.ServiceProcessInstaller1})

    End Sub

    Friend WithEvents ServiceInstaller1 As ServiceProcess.ServiceInstaller
    Friend WithEvents ServiceProcessInstaller1 As ServiceProcess.ServiceProcessInstaller
End Class
