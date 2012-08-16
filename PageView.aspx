<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageView.aspx.cs" Inherits="PageView" MasterPageFile="~/MasterPageLeft.master" %>

<asp:Content ContentPlaceHolderID="LeftHead" runat="server" ID="NewsHead">
<script>
    $(document).ready(function (e) {
        var type = $(".TypeSelector").val();
        if ("1" == type || "2" == type) {
            $("#hidden").show();
        } else {
            $("#hidden").hide();
        }
    });
    function doSelect() {
        var type = $(".TypeSelector").val();
        if ("1" == type || "2" == type) {
            $("#hidden").show();
        } else {
            $("#hidden").hide();        
        }
    }

    function reflash() {

        $("#code").attr("src", "securityCode.aspx?t=" + Math.floor(Math.random() * 10));
    }
</script>
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="NewsMain">
    <asp:Panel ID="Panel_Info" runat="server" CssClass="product_group">
        <asp:Panel ID="Panel_Application" runat="server" CssClass="Panel_RequiredField">
            <div class="clear"></div>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/ims/btn_1.gif" OnClick="Submit" />
        </asp:Panel>
        
    </asp:Panel>
    
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentInfo" runat="server" ID="ContentInfo">
    <asp:Literal ID="lit_info" runat="server"></asp:Literal>
</asp:Content>
