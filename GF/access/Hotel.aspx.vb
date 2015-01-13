
Partial Class Access_Hotel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Hotel As Hotel = HotelManager.GetHotel(DateTime.Now, 500)
        If Not Hotel Is Nothing Then
            litHotel.Text = Hotel.HotelName
        End If
    End Sub
End Class
