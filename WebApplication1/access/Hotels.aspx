<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="Hotels.aspx.vb" Inherits="Access_Hotels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="Server">
    <asp:Repeater runat="server" ID="rptHotels">
        <ItemTemplate>
            <%#Eval("hotelname")%>
            -
            <%#Eval("hoteldistance")%>
            -
             <%#Eval("latitude")%>
             -
              <%#Eval("longitude")%>
            <br />
            <asp:Repeater runat="server" ID="rptRooms">
                <ItemTemplate>
                    <asp:Repeater runat="server" ID="rptNights">
                        <ItemTemplate>
                            <%#Eval("RoomDate") %>
                            -
                            <%#Eval("Price")%><br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
