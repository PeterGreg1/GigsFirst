
Partial Class Access_Show
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim show As Show = ShowManager.GetShow(1000)
        If Not show Is Nothing Then
            litShowName.Text = show.ShowName
            rptArtists.DataSource = show.Artists
            rptArtists.DataBind()
            rptVendors.DataSource = show.Vendors
            rptVendors.DataBind()
        End If
    End Sub
End Class
