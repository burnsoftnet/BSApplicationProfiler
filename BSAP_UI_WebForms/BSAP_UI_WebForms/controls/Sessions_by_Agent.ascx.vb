Public Class Sessions_by_Agent
    Inherits System.Web.UI.UserControl
    Public PageTitle As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim AGENTID As String = ""
        Dim SQL As String = "SELECT * FROM web_view_monitoring_session"
        If Len(Request.QueryString("AID")) > 0 Then
            AGENTID = Request.QueryString("AID")
            SQL &= " where aid=" & AGENTID
            Dim Obj As New BurnSoft.BSAP.AgentSessions
            PageTitle = "Sessions from " & Obj.GetAgentNameFromID(AGENTID)
        Else
            PageTitle = "No Agent Selected!"
        End If
        SQL &= " ORDER BY sessiondt desc"
        SqlDataSource1.SelectCommand = SQL
    End Sub

End Class