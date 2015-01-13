<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="InitialiseFacebookLogin.aspx.vb" Inherits="Access_Register" %>

<%@ Register Src="~/access/controls/login.ascx" TagName="login" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <asp:HiddenField runat="server" ID="hfAccessCode" />
    <div class="maincontent">
        <asp:UpdatePanel ID="upCompleteRegistration" runat="server" Visible="false">
            <ContentTemplate>
                <div class="form">
                    <div class="section">
                        <div class="sectiontitle">
                            Complete registration</div>
                        <div class="question">
                            <div class="questiontitle">
                                Your postcode:
                            </div>
                            <div class="hint">
                                (OPTIONAL) Please enter your postcode so we can tailor results to your location.
                                This can be changed after.
                            </div>
                            <div class="answer">
                                <asp:TextBox runat="server" ID="tbPostcode" CssClass="textbox"></asp:TextBox>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <div class="question">
                            <div class="questiontitle">
                                Please enter a password to enable you to log in to your account without facebook.
                                If you leave this blank we will generate a random password which you can retrieve
                                at any time through the login page:
                            </div>
                            <div class="hint">
                                (OPTIONAL) Passwords must be a minimum of 8 characters and contain one numeric character
                                and one upper case character. <span class="alert">PLEASE DO NOT USE YOUR FACEBOOK PASSWORD!</span>
                            </div>
                            <div class="answer">
                                <asp:TextBox ID="tbPassword1" TextMode="password" CssClass="textbox" runat="server" />
                                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="tbPassword1"
                                    ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" Display="Dynamic"
                                    ValidationGroup="memberlogin"><div class="error3">Invalid password</div>
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <div class="question">
                            <div class="questiontitle">
                                Repeat Password *:
                            </div>
                            <div class="answer">
                                <asp:TextBox ID="tbPassword2" TextMode="password" CssClass="textbox" runat="server" />
                                <asp:CompareValidator ControlToCompare="tbPassword1" ID="cvPassword2" runat="server"
                                    ControlToValidate="tbPassword2" Display="Dynamic" ValidationGroup="memberlogin">
                                <div class="error3">Password does not match</div>
                                </asp:CompareValidator>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <asp:Button runat="server" ID="btnRegister" Text="Login" CssClass="genericbtn" ValidationGroup="memberlogin" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upVerifyAccount" Visible="false">
            <ContentTemplate>
                It looks like you already have an account with GigsFirst. Would you like to link
                this with your Facebook account?
                <uc:login runat="server" ID="login1" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
