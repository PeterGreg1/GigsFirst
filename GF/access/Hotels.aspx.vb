﻿
Partial Class Access_Hotels
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tmpHotels As HotelList = HotelManager.GetHotels(DateTime.Now, 53.470445, -2.215371)
        rptHotels.DataSource = tmpHotels
        rptHotels.DataBind()
    End Sub

    Protected Sub rptHotels_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptHotels.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim rptRooms As Repeater = e.Item.FindControl("rptRooms")
            Dim drv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            AddHandler rptRooms.ItemDataBound, AddressOf rptRooms_ItemDataBound
            rptRooms.DataSource = DirectCast(e.Item.DataItem, Hotel).HotelRooms
            rptRooms.DataBind()
        End If
    End Sub

    Protected Sub rptRooms_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim rptNights As Repeater = e.Item.FindControl("rptNights")
            Dim drv As DataRowView = TryCast(e.Item.DataItem, DataRowView)
            rptNights.DataSource = DirectCast(e.Item.DataItem, HotelRoom).HotelRoomRates
            rptNights.DataBind()
        End If
    End Sub
End Class
