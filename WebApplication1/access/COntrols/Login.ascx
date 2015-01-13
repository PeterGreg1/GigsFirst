<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login.ascx.vb" Inherits="Access_Controls_Login" %>
<div class="form">
    <div class="loginslider">
        <asp:UpdatePanel ID="upLogin" runat="server">
            <ContentTemplate>
                <div class="section">
                    <div class="sectiontitle">
                        Login</div>
                    <div class="question">
                        <div class="questiontitle">
                            Your Username or email:
                        </div>
                        <div class="answer">
                            <asp:TextBox runat="server" ID="tbUsername" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvUsername" ForeColor="#FFFFFF" Display="Dynamic"
                                ControlToValidate="tbUsername" ValidationGroup="memberlogin">
                                <div class="error3">
                                Required Field
                                </div>
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="break">
                        </div>
                    </div>
                    <div class="question">
                        <div class="questiontitle">
                            Password:
                        </div>
                        <div class="answer">
                            <asp:TextBox runat="server" ID="tbPassword" CssClass="textbox" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ForeColor="#FFFFFF" Display="Dynamic"
                                ControlToValidate="tbPassword" ValidationGroup="memberlogin">
                                <div class="error3">
                                Required Field
                                </div>
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="break">
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="genericbtn" ValidationGroup="memberlogin" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upForgotPassword" runat="server">
            <ContentTemplate>
                <div class="section">
                    <div class="sectiontitle">
                        Forgot Password?</div>
                    <div class="question">
                        <div class="questiontitle">
                            Your email:
                        </div>
                        <div class="answer">
                            <asp:TextBox runat="server" ID="tbReminderEmail" CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rfvReminderUsername" ForeColor="#FFFFFF"
                                Display="Dynamic" ControlToValidate="tbReminderEmail" ValidationGroup="memberpasswordreminder">
                                <div class="error3">
                                Required Field
                                </div>
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="break">
                        </div>
                    </div>
                    <div class="error2" runat="server" id="divReminderError" visible="false">
                        Invalid details.
                    </div>
                    <asp:Button runat="server" ID="btnPasswordRequest" Text="Request" CssClass="genericbtn"
                        ValidationGroup="memberpasswordreminder" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="navigation">
        <div style="float: left; cursor: pointer;" onclick="$('.loginslider').cycle(0);">
            Login</div>
        <div style="float: right; cursor: pointer;" onclick="$('.loginslider').cycle(1);">
            Forgot password?</div>
        <div class="break">
        </div>
    </div>
</div>
