Imports Microsoft.VisualBasic

Public Class Authentication

    Public Shared Function UserID() As Guid
        Dim muser As MembershipUser = Membership.GetUser(HttpContext.Current.User.Identity.Name, True)
        If Not muser Is Nothing Then
            Return muser.ProviderUserKey
        End If
    End Function

End Class
