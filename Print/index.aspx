<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" MasterPageFile="~/MasterPagePrint.master" Inherits="Print_index" %>

<asp:Content ContentPlaceHolderID="HeadCentent" runat="server" ID="Head">


</asp:Content>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server" ID="Title">
打印
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="Main">
<span style="text-align:center; width:100%; margin:auto; font-size:25px; height:60px; line-height:60px; display:block; font-weight:bold; float:left;" id="title" runat="server"></span>

    <asp:Panel ID="Panel_Info" runat="server">
    </asp:Panel>
    <div class="clear" style=" height:10px;"></div>

    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div class="clear" style=" height:0;"></div>
                <asp:Label ID="code" runat="server" style=" float:left;">SN:A00003</asp:Label>
            </td>
            <td valign="top">
                <p style=" float:left; padding:10px;">
                    <asp:Literal ID="lit_info" runat="server"></asp:Literal>
                </p>
            </td>

        </tr>
    </table>

    <a href="javascript:window.print();" class="print_btn" style=" float:right;">点击打印</a>

</asp:Content>