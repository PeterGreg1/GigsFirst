Imports ticketmaster

Partial Class tm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        Dim tmrequest As New ticketmaster.Request
        tmrequest.apiKey = "4c869421b3db9beb86ca5650d2c2d039"

        'Dim tmresponse As New ticketmaster.Response
        'tmresponse.details = tmdetails
        'Dim sdsd As String = tmresponse.ToString
        'Response.Write(sdsd)

        Dim tmservice As New ticketmaster.ServiceService
        Dim tmresponse As ticketmaster.Response = tmservice.findEvents(tmrequest)

        For Each tmevent As ticketmaster.Event In tmresponse.results
            Response.Write(tmevent.eventId & "-" & tmevent.name & "<br />")
        Next


    End Sub
End Class
