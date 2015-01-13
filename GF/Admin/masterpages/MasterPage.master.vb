Imports Authentication

Partial Class Admin_MasterPages_MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        metaTitle.Text = System.Configuration.ConfigurationManager.AppSettings("CMSTitle")
        litCMSTitle.Text = System.Configuration.ConfigurationManager.AppSettings("CMSTitle")
        litUsername.Text = HttpContext.Current.User.Identity.Name
    End Sub

End Class

