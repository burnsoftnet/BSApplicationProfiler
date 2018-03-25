Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        Application("ADMINMODE") = CBool(ConfigurationManager.AppSettings("ENABLE_ADMINMODE"))
    End Sub

    Sub Session_Start(sender As Object, e As EventArgs)
        Session("isAdmin") = False
        Session("isLoggedIn") = False
        Session("user_email") = ""
        Session("user_name") = ""
        Session("user_displayname") = ""
        If Not CBool(Application("ADMINMODE")) Then
            Session("isAdmin") = True
            Session("isLoggedIn") = True
        End If
    End Sub
End Class