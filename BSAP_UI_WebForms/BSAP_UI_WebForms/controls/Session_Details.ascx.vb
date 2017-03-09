Public Class Session_Details1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SessionID As Long = CLng(Request.QueryString("SessionID"))
        Dim SQL As String = "select p.*,TIME_FORMAT(p.dt,'%H:%I') as dt_time from process_stats_main p where p.SessionID=" & SessionID
        Chart1.Titles.Add("CPU")
        Chart2.Titles.Add("MEMORY")
        Chart3.Titles.Add("Handles")
        Chart4.Titles.Add("Threads")
        SqlDataSource1.SelectCommand = SQL
        SqlDataSource2.SelectCommand = "select * from logs_main where sessionid=" & SessionID
        Dim Obj As New BurnSoft.BSDatabase
        Obj.GetProcessDEtails(SessionID, lblProcessName.Text, lblUser.Text, lblCommandLine.Text)
        Obj.GetSessionTimes(SessionID, lblStart.Text, lblEnd.Text)
    End Sub

End Class