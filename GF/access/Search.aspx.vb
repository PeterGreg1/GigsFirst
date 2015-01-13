Partial Class Access_Search
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim newshow As ShowList = ShowManager.GetShows("", ShowManager.DateType.FutureDates)
        If Not newshow Is Nothing Then
            rptShows.DataSource = newshow
            rptShows.DataBind()
        End If
    End Sub

    Protected Sub rptShows_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptShows.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim rptArtists As Repeater = e.Item.FindControl("rptArtists")
            Dim rptVendors As Repeater = e.Item.FindControl("rptVendors")
            rptArtists.DataSource = DirectCast(e.Item.DataItem, Show).Artists
            rptArtists.DataBind()
            rptVendors.DataSource = DirectCast(e.Item.DataItem, Show).Vendors
            rptVendors.DataBind()
        End If
    End Sub
End Class
