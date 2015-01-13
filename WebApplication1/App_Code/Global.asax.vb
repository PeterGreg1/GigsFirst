Imports System.Web
Imports System.Web.SessionState
Imports Authentication
Imports System.Xml.XPath

Public Class [Global]
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
    
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Response.Redirect("/error.aspx") '// remove comment when LIVE so user's see friendly error message
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

End Class