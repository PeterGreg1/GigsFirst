<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Access_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="Server">
    <asp:Repeater runat="server" ID="rptShows">
        <ItemTemplate>
            <div style="border: 1px solid #000000; padding: 5px; margin-bottom: 5px;">
                <%#Eval("ShowName") %>
                <%#Eval("ShowDate")%>
                <%#Eval("Postcode")%><br />
                <asp:Repeater runat="server" ID="rptArtists">
                    <ItemTemplate>
                        <div style="border: 1px dashed #000000; padding: 5px; margin-bottom: 5px;">
                            <%# Eval("ArtistName")%><br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="rptVendors">
                    <ItemTemplate>
                        <div style="border: 1px dashed #000000; padding: 5px; margin-bottom: 5px;">
                            <%# Eval("VendorCode")%>
                            -
                            <%# Eval("EventReference")%><br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
