Imports Authentication
Imports System.Xml.Linq
Imports System.Linq
Imports Twitterizer

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GetPageValues(Request.QueryString("pageid"))
        'Me.Master.PageID = intPageID
        'Me.Master.PageTitle = strPageTitle
        'Me.Master.MetaKeywords = strKeywords
        'Me.Master.MetaDescription = strDescription
        'If Not Page.IsPostBack Then
        '    Banner1.LoadBanner()
        '    DoNews()
        'End If
    End Sub

    'Sub DoNews()
    '    rptNews.DataSource = DBCalls.GetSubPages(1, 1, 1, 1, , , , , 2)
    '    rptNews.DataBind()
    'End Sub

    Sub DoTwitter()
        If Page.IsPostBack Then
            Try
                Dim usr As TwitterUser = TwitterUser.GetUser("PeterGregory1")
                Dim tweets As TwitterStatusCollection = usr.Timeline
                If tweets.Count > 0 Then
                    litTwitter.Text = "<a target=""_blank"" title=""view tweet"" href=""https://twitter.com/Broadgate_Comms/statuses/" & tweets(0).Id & """>" & charcount(tweets(0).Text, 55) & "</a>"
                End If
            Catch ex As Exception
                litTwitter.Text = "There has been an error receiving the Twitter feed."
            End Try
        End If
    End Sub

    'Protected Sub rptNews_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptNews.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim litDateTime As Literal = e.Item.FindControl("litDateTime")
    '        Dim hlLink As HyperLink = e.Item.FindControl("hlLink")
    '        Dim hlLink2 As HyperLink = e.Item.FindControl("hlLink2")
    '        litDateTime.Text = FormatDateTime(nullToStr(e.Item.DataItem("ReleaseDate")), DateFormat.ShortDate)
    '        hlLink.Text = nullToStr(e.Item.DataItem("MenuTitle"))
    '        hlLink.NavigateUrl = "/page/" & e.Item.DataItem("pageid") & "/" & StaticPageFormat(nullToStr(e.Item.DataItem("MenuTitle"))) & ".aspx"
    '        hlLink2.NavigateUrl = "/page/" & e.Item.DataItem("pageid") & "/" & StaticPageFormat(nullToStr(e.Item.DataItem("MenuTitle"))) & ".aspx"
    '    End If
    'End Sub

    Protected Sub upTwitter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles upTwitter.Load
        DoTwitter()
    End Sub
End Class
