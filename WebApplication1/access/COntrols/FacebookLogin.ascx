<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FacebookLogin.ascx.vb"
    Inherits="Access_Controls_FacebookLogin" %>
<div id="fb-root">
</div>
<script type="text/javascript" src="/access/javascript/facebookconnect.js"></script>
<img src="/access/images/facebook-connect.png" alt="connect with facebook" title="connect with facebook"
    onclick="FB.login(function(response) {}, {scope: 'email'});" />