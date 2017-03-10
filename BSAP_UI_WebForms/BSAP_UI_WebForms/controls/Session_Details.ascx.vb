Public Class Session_Details1
    Inherits System.Web.UI.UserControl
    Public SessionProjectTitle As String
    Sub LoadData(SessionID As Long)
        Dim SQL As String = "select p.*,TIME_FORMAT(p.dt,'%H:%I') as dt_time from process_stats_main p where p.SessionID=" & SessionID
        Chart1.Titles.Add("CPU %")
        Chart2.Titles.Add("MEMORY (BYTES)")
        Chart3.Titles.Add("Handles (TOTAL)")
        Chart4.Titles.Add("Threads (TOTAL)")
        SqlDataSource1.SelectCommand = SQL
        SqlDataSource2.SelectCommand = "select * from logs_main where sessionid=" & SessionID
        Dim Obj As New BurnSoft.BSDatabase
        Obj.GetProcessDEtails(SessionID, lblProcessName.Text, lblUser.Text, lblCommandLine.Text)
        Obj.GetSessionTimes(SessionID, lblStart.Text, lblEnd.Text)
        If Not IsDate(lblEnd.Text) Then
            lblEnd.ForeColor = Drawing.Color.Green
        End If
        SessionProjectTitle = Obj.GetProjectName(CLng(Request.QueryString("APNID")))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LoadData(CLng(Request.QueryString("SessionID")))
    End Sub

End Class