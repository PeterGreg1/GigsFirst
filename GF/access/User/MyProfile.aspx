<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="MyProfile.aspx.vb" Inherits="Access_MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="maincontent">
        <asp:Literal runat="server" ID="litContent"></asp:Literal>
        <br />
        <asp:Image runat="server" ID="imgPhoto" />
    </div>
</asp:Content>
