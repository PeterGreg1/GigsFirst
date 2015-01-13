<%@ Page Title="" Language="VB" MasterPageFile="~/access/masterpages/BasePage.master"
    AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/access/controls/banner.ascx" TagName="Banner1" TagPrefix="uc" %>
<%@ MasterType VirtualPath="~/access/masterpages/BasePage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link rel="Stylesheet" type="text/css" href="/access/styles/homepage.css" />
    <script type="text/javascript">
        (function () {
            doBannerSlideShow();
        })(jQuery)
        function doBannerSlideShow() {
            $('.bannerslideshow').cycle({
                fx: 'fade',
                speed: 'slow',
                timeout: 6000,
                slideExpr: '.bannerslideshowitem',
                prev: '.bannerleftnav',
                next: '.bannerrightnav'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="Server">
    <uc:Banner1 ID="Banner1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="homepagebox box1">
        <h1>
            Welcome</h1>
        <p>
            We are a Marketing Agency based in Amersham, Buckinghamshire. We can help you to
            build and evolve your brand by delivering bespoke design solutions that engage your
            audience and promote your product, service or business to maximum effect.</p>
        <a class="moreinfo3" href="" title="read more"><span>Read More</span><img src="/access/images/moreinfoicon2.png"
            alt="more info" title="more info" /></a>
        <img src="/access/images/shareicon.png" title="share" alt="share" class="shareicon st_sharethis_custom" />
    </div>
    <div class="homepagebox box2">
        <img src="/uploads/images/main/hppic1.jpg" class="photo" />
        <div class="description">
            <h1>
                MARKETING COMMUNICATIONS</h1>
            <p>
                Whatever service you provide what ever service you provide what is the product you...</p>
        </div>
        <a class="moreinfo" href="" title="more info">
            <img src="/access/images/moreinfoicon.png" /></a>
    </div>
    <div class="homepagebox box3">
        <img src="/uploads/images/main/hppic2.jpg" class="photo" />
        <div class="description">
            <h1>
                CONSULTANCY</h1>
            <p>
                Whatever service you provide what ever service you provide what is the product you...</p>
        </div>
        <a class="moreinfo" href="" title="more info">
            <img src="/access/images/moreinfoicon.png" /></a>
    </div>
    <div class="homepagebox box4">
        <img src="/uploads/images/main/hppic3.jpg" class="photo" />
        <div class="description">
            <h1>
                TRAINING</h1>
            <p>
                Whatever service you provide what ever service you provide what is the product you...</p>
        </div>
        <a class="moreinfo" href="" title="more info">
            <img src="/access/images/moreinfoicon.png" /></a>
    </div>
    <div class="break">
    </div>
    <div class="homepagebox box5">
        <h1>
            Latest news...</h1>
        <div class="newsitems">
            <div class="item">
                <div class="date">
                    24/02/1982</div>
                <div class="title">
                    <a href="">Latest news to go here</a></div>
                <a href="" class="moreinfo2"><span>Read More</span><img src="/access/images/moreinfoicon2.png"
                    alt="more info" title="more info" /></a>
            </div>
             <div class="item">
                <div class="date">
                    24/02/1982</div>
                <div class="title">
                    <a href="">Latest news to go here</a></div>
                <a href="" class="moreinfo2"><span>Read More</span><img src="/access/images/moreinfoicon2.png"
                    alt="more info" title="more info" /></a>
            </div>
            <asp:UpdatePanel runat="server" ID="upTwitter">
                <ContentTemplate>
                    <div class="tweet">
                        <strong>Latest tweet...</strong>
                        <asp:Literal runat="server" ID="litTwitter"></asp:Literal>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="homepagebox box6">
        <img src="/uploads/images/main/hppic4.jpg" class="photo" />
        <div class="description">
            <h1>
                CASE STUDY</h1>
            <h2>
                Broxbourne Housing Association</h2>
            <p>
                E-commerce website</p>
        </div>
        <a class="moreinfo" href="" title="more info">
            <img src="/access/images/moreinfoicon.png" alt="more info" title="more info" /></a>
    </div>
    <div class="homepagebox box7">
        <img src="/uploads/images/main/hppic4.jpg" class="photo" />
        <div class="description">
            <h1>
                CASE STUDY</h1>
            <h2>
                Broxbourne Housing Association</h2>
            <p>
                E-commerce website</p>
        </div>
        <a class="moreinfo" href="" title="more info">
            <img src="/access/images/moreinfoicon.png" alt="more info" title="more info" /></a>
    </div>
    <div class="break">
    </div>
    <script type="text/javascript">
        __doPostBack('<%= upTwitter.UniqueID %>', '');
    </script>
</asp:Content>
