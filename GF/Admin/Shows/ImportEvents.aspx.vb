Partial Class admin_events_ImportEvents
    Inherits System.Web.UI.Page
    Private Venues As VenueList
    Private Artists As ArtistList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub

    Sub BindData(ByVal MatchesOnly As Boolean)
        Dim VendorShows As VendorShowList = VendorShowManager.GetNewShows(ddlVendor.SelectedValue, MatchesOnly, "")
        Venues = VenueManager.GetVenues()
        Artists = ArtistManager.GetArtists()
        If Not VendorShows Is Nothing Then
            litResults.Text = VendorShows.Count
            gvEvents.DataSource = VendorShows
            gvEvents.DataBind()
        End If
    End Sub

    Protected Sub gvEvents_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEvents.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
            Dim ddlArtist As DropDownList = e.Row.FindControl("ddlArtist")
            Dim ddlVenue As DropDownList = e.Row.FindControl("ddlVenue")
            ddlVenue.DataSource = Venues
            ddlVenue.DataValueField = "VenueID"
            ddlVenue.DataTextField = "VenueAndTown"
            ddlVenue.DataBind()
            ddlArtist.DataSource = Artists
            ddlArtist.DataValueField = "ArtistID"
            ddlArtist.DataTextField = "ArtistName"
            ddlArtist.DataBind()
            ddlArtist.SelectedValue = DirectCast(e.Row.DataItem, VendorShow).ArtistID
            ddlVenue.SelectedValue = DirectCast(e.Row.DataItem, VendorShow).VenueID
        End If
    End Sub

    Protected Sub btnAddEvents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEvents.Click
        Dim shows As New showlist
        For Each gvRow As GridViewRow In gvEvents.Rows
            Dim cbAdd As CheckBox = gvRow.FindControl("cbAdd")
            Dim hfEventDate As HiddenField = gvRow.FindControl("hfVendorEventDate")
            Dim hfArtistName As HiddenField = gvRow.FindControl("hfVendorArtistName")
            Dim hfVenueName As HiddenField = gvRow.FindControl("hfVendorVenueName")
            Dim hfVendorEventID As HiddenField = gvRow.FindControl("hfVendorEventID")
            Dim ddlArtist As DropDownList = gvRow.FindControl("ddlArtist")
            Dim ddlVenue As DropDownList = gvRow.FindControl("ddlVenue")
            If cbAdd.Checked Then
                If IsDate(hfEventDate.Value) Then
                    If ddlArtist.SelectedValue > 0 And ddlVenue.SelectedValue > 0 Then
                        Dim show As New Show
                        show.ShowDate = hfEventDate.Value
                        show.VenueID = ddlVenue.SelectedValue
                        Dim artist As Artist = New Artist
                        artist.ArtistID = ddlArtist.SelectedValue
                        artist.ArtistName = hfArtistName.Value
                        show.Artists.Add(artist)
                        Dim vendor As New ShowVendor
                        vendor.VendorCode = hfVendorEventID.Value
                        vendor.VendorID = ddlVendor.SelectedValue
                        show.Vendors.Add(vendor)
                        shows.Add(show)
                    End If
                End If
            End If
        Next
        ShowManager.AddShows(shows)
        BindData(IsDisplayMatchesOnlyChecked)
    End Sub

    Protected Sub gvEvents_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvEvents.PageIndexChanging
        gvEvents.PageIndex = e.NewPageIndex
        BindData(IsDisplayMatchesOnlyChecked)
    End Sub

    Function IsDisplayMatchesOnlyChecked() As Boolean
        If cbDisplayMatchesOnly.Checked Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindData(IsDisplayMatchesOnlyChecked)
    End Sub

    Protected Sub btnImportMatchedEvents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImportMatchedEvents.Click
        'Dim dtEvents As DataTable = New DataTable
        'Select Case ddlVendor.SelectedValue
        '    Case "SEE"
        '        '                dtEvents = DBCallsEventsAdmin.GetNewMatchedEventsSeeTickets(tbKeywords.Text)
        '    Case "TM"

        '    Case Else

        'End Select
        'Dim table As New DataTable()
        'table.Columns.Add("EventDate")
        'table.Columns.Add("Venue")
        'table.Columns.Add("Artist")
        'table.Columns.Add("Vendor")
        'table.Columns.Add("VendorEventID")
        'table.Columns.Add("ArtistName")
        'For Each dtRow As DataRow In dtEvents.Rows
        '    Dim dtRow2 As DataRow = table.NewRow
        '    dtRow2("EventDate") = dtRow("show_date")
        '    dtRow2("Venue") = dtRow("venueid")
        '    dtRow2("Artist") = dtRow("artistid")
        '    dtRow2("Vendor") = ddlVendor.SelectedValue
        '    dtRow2("VendorEventID") = dtRow("show_code")
        '    dtRow2("ArtistName") = dtRow("artistname")
        '    table.Rows.Add(dtRow2)
        'Next
        ''        DBCallsEventsAdmin.AddEventBatch(table)
    End Sub
End Class
