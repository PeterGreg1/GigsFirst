Partial Class Access_OAuth
    Inherits System.Web.UI.Page

    Private strReturnURL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strReturnURL = Request("returnurl")
        If strReturnURL = "" Then
            strReturnURL = "/access/user/myprofile.aspx"
        End If
        If User.Identity.IsAuthenticated Then
            Response.Redirect(strReturnURL)
        End If
    End Sub

    Sub HandleAuthorisation(booAuthorised As Boolean, strUsername As String) Handles Login1.LoginResult
        If booAuthorised = True Then
            Response.Redirect("/access/default.aspx")
        End If
    End Sub

End Class
