Imports System.IO
Imports System.Xml
Imports System.Net
Imports Authentication

Partial Class Access_MyProfile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim membershipuser As MembershipUser = Membership.GetUser(User.Identity.Name)
        litContent.Text = membershipuser.UserName & "," & membershipuser.Email
        If CheckFileExists(Server.MapPath("/uploads/" & UserID().ToString & ".jpg")) Then
            imgPhoto.ImageUrl = "/uploads/" & UserID().ToString & ".jpg"
        Else
            imgPhoto.Visible = False
        End If
    End Sub
End Class
