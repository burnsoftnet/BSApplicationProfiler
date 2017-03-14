
Public Class Application_Sessions
    Inherits System.Web.UI.UserControl
    Public PageTitle As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim APNID As String = ""
        Dim SQL As String = "SELECT * FROM web_view_monitoring_session"
        If Len(Request.QueryString("ID")) > 0 Then
            APNID = Request.QueryString("ID")
            SQL &= " where apnid=" & APNID
            Dim Obj As New BurnSoft.BSAP.ProjectSessions
            PageTitle = Obj.GetProjectName(APNID)
        Else
            PageTitle = "NO Project Selected!"
        End If
        SQL &= " ORDER BY sessiondt desc"
        SqlDataSource1.SelectCommand = SQL


    End Sub

End Class