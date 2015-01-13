<%@ Page Title="" Language="VB" MasterPageFile="~/Access/Masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Access_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div id="fb-root">
    </div>
    <script type="text/javascript" src="/access/javascript/facebookconnect.js"></script>
    <div class="maincontent">
        <h1>
            Register using facebook:</h1>
        <img src="/access/images/facebook-connect.png" alt="connect with facebook" title="connect with facebook"
            onclick="FB.login();" />
        <hr />
        <h1>
            Register by creating a gigsfirst account:</h1>
        <div class="form">
            <asp:UpdatePanel ID="upLogin" runat="server">
                <ContentTemplate>
                    <asp:Literal runat="server" ID="litErrors"></asp:Literal>
                    <div class="section">
                        <div class="sectiontitle">
                            Register</div>
                        <div class="question">
                            <div class="questiontitle">
                                Your Email *:
                            </div>
                            <div class="answer">
                                <asp:TextBox runat="server" ID="tbEmail" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail"
                                    Display="Dynamic" ValidationGroup="memberlogin">
                            <div class="error3">Please enter your email</div>
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="tbEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="memberlogin"
                                    Display="Dynamic">
                              <div class="error3">Invalid Email</div>
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <div class="question">
                            <div class="questiontitle">
                                Choose a username *:
                            </div>
                            <div class="answer">
                                <asp:TextBox runat="server" ID="tbUsername" CssClass="textbox"></asp:TextBox>
                                <asp:Button runat="server" ID="btnCheckUsername" Text="Check Availability" CssClass="genericbtn"
                                    CausesValidation="false" />
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="tbUsername"
                                    ValidationGroup="memberlogin">
                            <div class="error3">Please enter a username</div>
                                </asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvUsername" runat="server" ControlToValidate="tbUsername"
                                    Display="Dynamic" ValidationGroup="memberlogin">
                             <div class="error3">This username has already been taken</div>
                                </asp:CustomValidator>
                            </div>
                            <div class="answer">
                                <asp:Literal runat="server" ID="litUsernameStatus"></asp:Literal>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <div class="question">
                            <div class="questiontitle">
                                Your postcode:
                            </div>
                            <div class="hint">
                                (optional) Please enter your postcode so we can tailor results to your location.
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
                                Password *:
                            </div>
                            <div class="hint">
                                Passwords must be a minimum of 8 characters and contain one numeric character and
                                one upper case character.
                            </div>
                            <div class="answer">
                                <asp:TextBox ID="tbPassword1" TextMode="password" CssClass="textbox" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword1"
                                    Display="Dynamic" ValidationGroup="memberlogin">
                            <div class="error3">Please enter a password</div>
                                </asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="rfvPassword2" runat="server" ControlToValidate="tbPassword2"
                                    Display="Dynamic" ValidationGroup="memberlogin">
                                <div class="error3">Please enter a password</div>
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="break">
                            </div>
                        </div>
                        <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="genericbtn"
                            ValidationGroup="memberlogin" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
