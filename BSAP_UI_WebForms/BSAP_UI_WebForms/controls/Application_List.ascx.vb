Public Class Application_List
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.Columns(5).Visible = Session("isLoggedIn")
    End Sub

End Class