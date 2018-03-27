Public Class Session_Details1
    Inherits System.Web.UI.UserControl
    Public SessionProjectTitle As String
    Sub LoadData(SessionID As Long)
        Dim SQL As String = "select p.*,TIME_FORMAT(p.dt,'%H:%I:%S') as dt_time from process_stats_main p where p.SessionID=" & SessionID & " order by dt_time asc"
        Chart1.Titles.Add("CPU %")
        Chart2.Titles.Add("MEMORY (BYTES)")
        Chart3.Titles.Add("Handles (TOTAL)")
        Chart4.Titles.Add("Threads (TOTAL)")
        SqlDataSource1.SelectCommand = SQL
        SqlDataSource2.SelectCommand = "select * from logs_main where sessionid=" & SessionID
        Dim Obj As New BurnSoft.BSAP.ProjectSessions
        Obj.GetProcessDEtails(SessionID, lblProcessName.Text, lblUser.Text, lblCommandLine.Text)
        Obj.GetSessionTimes(SessionID, lblStart.Text, lblEnd.Text, lblVersion.Text, lblAppCreator.Text, lblAppLastAccess.Text, lblAppLastWrite.Text, lblAppCreateDate.Text)
        If Not IsDate(lblEnd.Text) Then
            lblEnd.ForeColor = Drawing.Color.Green
            lblSessionTotal.Text = DateDiff(DateInterval.Minute, CDate(lblStart.Text), Now)
        Else
            lblSessionTotal.Text = DateDiff(DateInterval.Minute, CDate(lblStart.Text), CDate(lblEnd.Text))
        End If
        SessionProjectTitle = Obj.GetProjectName(CLng(Request.QueryString("APNID")))
        Dim ObjS As New BurnSoft.BSAP.BSSessionDetailsStats
        ObjS.getSessionAverage(SessionID, lblAvgCPU.Text, lblAvgMem.Text, lblAvgHandles.Text, lblAvgThreads.Text)
        ObjS = Nothing
        Obj = Nothing
    End Sub
    Sub LoadCPUData(SessionID As Long)
        Dim sql As String = "SELECT * FROM bsap.process_stats_main where SessionID=" & SessionID & " order by dt asc"
        sdsCPU.SelectCommand = sql
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadData(CLng(Request.QueryString("SessionID")))
        LoadCPUData(CLng(Request.QueryString("SessionID")))
    End Sub

End Class