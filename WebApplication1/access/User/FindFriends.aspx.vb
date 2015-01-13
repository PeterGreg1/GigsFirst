Partial Class Access_FindFriends
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim facebookfriends As UserList = FacebookManager.GetFacebookUserFriends(Session("accessToken"))
        If Not (facebookfriends Is Nothing) Then
            Dim userList As UserList = UserManager.GetRegisteredOAuthFriends(facebookfriends, "facebook")
            rptFriends.DataSource = userList
            rptFriends.DataBind()
            'For Each blah As FacebookUser In facebookfriends
            '    Response.Write(blah.FacebookID)
            'Next
        Else
            FacebookLogin1.Visible = True
        End If
    End Sub

    Protected Sub rptFriends_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptFriends.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim imgPhoto As System.Web.UI.WebControls.Image = e.Item.FindControl("imgPhoto")
            If CheckFileExists(Server.MapPath("/uploads/" & DirectCast(e.Item.DataItem, User).UserID.ToString & ".jpg")) Then
                imgPhoto.ImageUrl = "/uploads/" & DirectCast(e.Item.DataItem, User).UserID.ToString & ".jpg"
            Else
                imgPhoto.Visible = False
            End If
        End If
    End Sub
End Class
