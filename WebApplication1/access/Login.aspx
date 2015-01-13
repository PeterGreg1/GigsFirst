<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Access_OAuth" %>

<%@ Register Src="~/access/controls/login.ascx" TagName="Login" TagPrefix="uc" %>
<%@ Register Src="~/access/controls/Facebooklogin.ascx" TagName="FacebookLogin" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="maincontent">
        <h1>
            Log in/Register with facebook:</h1>
        <uc:FacebookLogin runat="server" ID="FacebookLogin1" />
        <hr />
        <h1>
            Or log in with your username/email and password:</h1>
        <uc:Login runat="server" ID="Login1" />
        <hr />
        <h1>
            Not registered?</h1>
        <a href="Register.aspx">Click here to sign up</a></div>
</asp:Content>
