<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="FindFriends.aspx.vb" Inherits="Access_FindFriends" %>

<%@ Register Src="~/access/controls/Facebooklogin.ascx" TagName="FacebookLogin" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="maincontent">
        <uc:FacebookLogin runat="server" ID="FacebookLogin1" Visible="false" />
        <asp:Repeater runat="server" ID="rptFriends">
            <ItemTemplate>
                <asp:Image runat="server" ID="imgPhoto" />
                <%# Eval("firstname")%>
                <%# Eval("lastname")%><br />
                
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
