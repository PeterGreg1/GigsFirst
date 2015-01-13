<%@ Page Title="" Language="VB" MasterPageFile="~/admin/masterpages/MasterPage.master"
    AutoEventWireup="false" CodeFile="ImportEvents.aspx.vb" Inherits="admin_events_ImportEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="Server">

    <script type="text/javascript" src="/javascript/jquery-1.6.2.js"></script>

    <script type="text/javascript">
        function toggleChecked(status) {
            $(".checkbox input").each(function() {
                $(this).attr("checked", status);
            })
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="Server">
    <div>
        <asp:TextBox runat="server" ID="tbKeywords" MaxLength="250"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlVendor">
            <asp:ListItem Selected="True">SEE</asp:ListItem>
            <asp:ListItem>TM</asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSearch" Text="Search" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnImportMatchedEvents" Text="Import All Matched Events" />
         <br />
        <br />
        
        <asp:CheckBox runat="server" ID="cbDisplayMatchesOnly" Checked="false" Text="Show only events with associated venue and artist" />
        <br />
        <br />
        <asp:Literal runat="server" ID="litResults" />
        <br />
        <br />
        <input type="checkbox" onclick="toggleChecked(this.checked)" />
        Select / Deselect All
        <br />
        <br />
        <asp:GridView runat="server" ID="gvEvents" AutoGenerateColumns="false" AllowPaging="true"
            PageSize="30">
            <Columns>
                <asp:TemplateField HeaderText="Add">
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hfVendorEventID" Value='<%#Eval("ShowCode") %>' />
                        <asp:HiddenField runat="server" ID="hfVendorEventDate" Value='<%#Eval("ShowDate") %>' />
                        <asp:HiddenField runat="server" ID="hfVendorArtistName" Value='<%#Eval("ShowArtist") %>' />
                        <asp:HiddenField runat="server" ID="hfVendorVenueName" Value='<%#Eval("ShowVenue") %>' />
                        <asp:CheckBox runat="server" ID="cbAdd" CssClass="checkbox" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ShowCode" HeaderText="(Vendor) Event ID" />
                <asp:BoundField DataField="ShowVenue" HeaderText="(Vendor) Venue" />
                <asp:BoundField DataField="ShowTown" HeaderText="(Vendor) Town" />
                <asp:BoundField DataField="ShowDate" HeaderText="(Vendor) Date" />
                <asp:BoundField DataField="ShowArtist" HeaderText="(Vendor) Artist" />
                <asp:TemplateField HeaderText="Map To Venue:">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlVenue" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">NONE FOUND</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Map To Artist:">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlArtist" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">NONE FOUND</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button runat="server" ID="btnAddEvents" Text="Add Events" />
    </div>
</asp:Content>
