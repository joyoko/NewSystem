<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ApplicationShow.aspx.cs" Inherits="Admin_ApplicationShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Admin_Title" Runat="Server">
    当前位置：报名情况
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Admin_main" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id"  EnableModelValidation="True"
         ShowFooter="True" CssClass="GridViewStyle" 
            onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
            onrowcommand="GridView1_RowCommand" PageSize="3" >

        <FooterStyle CssClass="FooterStyle" Height="1px" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
</asp:Content>

