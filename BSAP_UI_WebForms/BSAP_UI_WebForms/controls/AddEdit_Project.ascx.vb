Imports BurnSoft.Universal
Imports MySql.Data.MySqlClient
Public Class AddEdit_Project
    Inherits System.Web.UI.UserControl
    Public PageTitle As String
    Private _EDITMODE As Boolean
    ''' <summary>
    ''' Switch to enable or disable edit mode.  when in edit more
    ''' it will load the information from the database
    ''' </summary>
    ''' <returns></returns>
    Public Property EDITMODE As Boolean
        Get
            Return _EDITMODE
        End Get
        Set(value As Boolean)
            _EDITMODE = value
        End Set
    End Property
    ''' <summary>
    ''' Load information from the project name table
    ''' </summary>
    ''' <param name="RID">Project ID</param>
    Sub LoadProectDetails(RID As Long)
        Dim Obj As New BurnSoft.BSDatabase
        If Obj.ConnectDB Then
            Dim ObjOF As New BSOtherObjects
            Dim SQL As String = "SELECT * FROM app_project_name where id=" & RID
            Dim CMD As New MySqlCommand(SQL, Obj.conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                txtName.Text = RS("Name")
                txtDesc.Text = RS("appdesc")
                chkEnabled.Checked = ObjOF.ConvertIntToBool(RS("enabled"))
                chkHasSub.Checked = ObjOF.ConvertIntToBool(RS("has_subprocess"))
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
            ObjOF = Nothing
        End If
        Obj = Nothing
    End Sub
    ''' <summary>
    ''' Load details about the project into the detail screen
    ''' </summary>
    ''' <param name="RID">Project ID</param>
    ''' <param name="APMID">Application Details ID</param>
    Sub LoadMainProcess(RID As Long, Optional ByRef APMID As Long = 0)
        Dim Obj As New BurnSoft.BSDatabase
        If Obj.ConnectDB Then
            Dim ObjOF As New BSOtherObjects
            Dim SQL As String = "SELECT * FROM app_project_main_process where apnid=" & RID
            Dim CMD As New MySqlCommand(SQL, Obj.conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                APMID = RS("id")
                txtProcessName.Text = RS("process_display_name")
                txtEXEName.Text = RS("process_name")
                chkMatchParam.Checked = ObjOF.ConvertIntToBool(RS("match_parameters"))
                If Not IsDBNull(RS("parameters")) Then txtParameter.Text = RS("parameters")
                chkHasLogs.Checked = ObjOF.ConvertIntToBool(RS("haslogs"))
                chkClearLogs.Checked = ObjOF.ConvertIntToBool(RS("clear_logs_on_start"))
                chkUseEventLog.Checked = ObjOF.ConvertIntToBool(RS("useNTEvent"))
                If Not IsDBNull(RS("NTSource")) Then txtNTSource.Text = RS("NTSource")
                If Not IsDBNull(RS("NTEventID")) Then txtNTEventID.Text = RS("NTEventID")
                If Not IsDBNull(RS("interval")) Then txtInterval.Text = RS("interval")
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
            ObjOF = Nothing
        End If
        Obj = Nothing
    End Sub
    ''' <summary>
    ''' If there are logs in the project, load the log details 
    ''' </summary>
    ''' <param name="RID">Project ID</param>
    Sub LoadMainLogs(RID As Long)
        Dim Obj As New BurnSoft.BSDatabase
        If Obj.ConnectDB Then
            Dim ObjOF As New BSOtherObjects
            Dim SQL As String = "SELECT * FROM app_project_main_log where apmid=" & RID
            Dim CMD As New MySqlCommand(SQL, Obj.conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                txtLogName.Text = RS("logname")
                txtLogPath.Text = RS("logpath")
                chkClearLogs.Checked = ObjOF.ConvertIntToBool(RS("clearlog"))
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
            ObjOF = Nothing
        End If
        Obj = Nothing
    End Sub
    ''' <summary>
    ''' Start loading the details of the project
    ''' </summary>
    ''' <param name="RID"></param>
    Sub LoadData(RID As Long)
        Call LoadProectDetails(RID)
        Call LoadMainProcess(RID)
        If (chkHasLogs.Checked) Then
            Call LoadMainLogs(RID)
        End If
    End Sub
    ''' <summary>
    ''' Save the infomration
    ''' </summary>
    ''' <param name="RID"></param>
    Sub SaveData(Optional ByVal RID As Long = 0)
        Dim ObjoF As New BSOtherObjects
        Dim Obj As New BurnSoft.BSDatabase
        Dim ObjP As New BurnSoft.BSAP.ProjectSessions
        Dim sProjectName As String = ObjoF.FC(txtName.Text)
        Dim sDescription As String = ObjoF.FC(txtDesc.Text)
        Dim iEnabled As Integer = ObjoF.ConvertBoolToInt(chkEnabled.Checked)
        Dim iHasSub As Integer = ObjoF.ConvertBoolToInt(chkEnabled.Checked)
        Dim sDisplayName As String = ObjoF.FC(txtProcessName.Text)
        Dim sEXE As String = ObjoF.FC(txtEXEName.Text)
        Dim iParam As Integer = ObjoF.ConvertBoolToInt(chkMatchParam.Checked)
        Dim sParam As String = ObjoF.FC(txtParameter.Text)
        Dim iInterval As Integer = txtInterval.Text
        Dim iHasLogs As Integer = ObjoF.ConvertBoolToInt(chkHasLogs.Checked)
        Dim iNTEvent As Integer = ObjoF.ConvertBoolToInt(chkUseEventLog.Checked)
        Dim sNTSource As String = ObjoF.FC(txtNTSource.Text)
        Dim sNTEvetID As String = ObjoF.FC(txtNTEventID.Text)
        Dim sLogName As String = ObjoF.FC(txtLogName.Text)
        Dim sLogPath As String = ObjoF.FC(txtLogPath.Text)
        Dim iClearLogs As Integer = ObjoF.ConvertBoolToInt(chkClearLogs.Checked)
        Dim SQL As String = ""
        Dim ProjectID As Long = 0
        Dim QUITONERROR As Boolean = False
        If _EDITMODE Then ProjectID = RID
        'Add to Project Table
        If Not _EDITMODE Then
            SQL = "INSERT INTO app_project_name (name,appdesc,enabled,has_subprocess) VALUES('" &
                sProjectName & "','" & sDescription & "'," & iEnabled & "," & iHasSub & ")"
            Obj.ConnEXE(SQL)
            ProjectID = ObjP.GetProjectIDbyName(sProjectName)
            'if you cannot find the project ID, then skip adding everything else 
            If ProjectID = 0 Then QUITONERROR = True
        Else
            SQL = "UPDATE app_project_name set name='" & sProjectName & "',appdesc='" &
                sDescription & "',enabled=" & iEnabled & ",has_subprocess=" & iHasSub &
                " where id=" & ProjectID
            Obj.ConnEXE(SQL)
        End If

        If Not _EDITMODE Then
            If Not QUITONERROR Then
                'Insert information about the main process into the main process table
                SQL = "INSERT INTO app_project_main_process (APNID,process_display_name," &
                    "process_name,match_parameters,parameters,haslogs,clear_logs_on_start," &
                    "useNTEvent,NTSource,NTEventID,`interval`) VALUES (" & ProjectID & ",'" &
                    sDisplayName & "','" & sEXE & "'," & iParam & ",'" & sParam & "'," &
                    iHasLogs & "," & iClearLogs & "," & iNTEvent & ",'" & sNTSource & "','" &
                    sNTEvetID & "'," & iInterval & ")"
                Obj.ConnEXE(SQL)
                'Insert information about the Main Processs Log into the table
                SQL = "INSERT INTO app_project_main_log (apmid,logname,logpath,clearlog) VALUES(" &
                    ProjectID & ",'" & sLogName & "','" & sLogPath & "'," & iClearLogs & ")"
                Obj.ConnEXE(SQL)
            End If
        Else
            'UPdate information about the main process
            SQL = "UPDATE app_project_main_process set process_display_name='" & sDisplayName & "'," &
                    "process_name='" & sEXE & "',match_parameters=" & iParam & ",parameters='" &
                    sParam & "',haslogs=" & iHasLogs & ",clear_logs_on_start=" & iClearLogs & "," &
                    "useNTEvent=" & iNTEvent & ",NTSource='" & sNTSource & "',NTEventID='" & sNTEvetID &
                    "',`interval`=" & iInterval & " where APNID=" & ProjectID
            Obj.ConnEXE(SQL)
            'Update the information about the log file that is used by the main process.
            SQL = "UPDATE app_project_main_log set logname='" & sLogName & "',logpath='" & sLogPath &
                "',clearlog=" & iClearLogs & " where apmid=" & ProjectID
            Obj.ConnEXE(SQL)
        End If

        If QUITONERROR Then
            'TODO: put in error details in here to alert UI of the Issue
        Else
            Response.Redirect("Project_List.aspx")
        End If

    End Sub
    ''' <summary>
    ''' Load Page
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If _EDITMODE Then
                btnUpdate.Visible = True
                btnSave.Visible = False
                If Len(Request.QueryString("ID")) > 0 Then
                    Dim RID As Long = CLng(Request.QueryString("ID"))
                    Call LoadData(RID)
                End If
            Else
                btnUpdate.Visible = False
                btnSave.Visible = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' Save button for new project
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call SaveData()
    End Sub
    ''' <summary>
    ''' Update the information in the database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Call SaveData(CLng(Request.QueryString("ID")))
    End Sub
End Class