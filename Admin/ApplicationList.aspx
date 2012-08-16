<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ApplicationList.aspx.cs" Inherits="Admin_ApplicationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Admin_Title" Runat="Server">
    当前位置：表单列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Admin_main" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ApplicationId" DataSourceID="SqlDataSource2" EnableModelValidation="True"
         ShowFooter="True" CssClass="GridViewStyle" 
            onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
            onrowcommand="GridView1_RowCommand" >
        <Columns>
            <asp:BoundField DataField="ApplicationId" HeaderText="表单ID" ReadOnly="True" 
                SortExpression="ApplicationId" InsertVisible="False" />
            <asp:BoundField DataField="ApplicationName" HeaderText="表单名称" SortExpression="ApplicationName" />
            <asp:TemplateField HeaderText="表单类别" SortExpression="TypeId">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# getType(Convert.ToInt32(Eval("TypeId").ToString())) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AddDate" HeaderText="添加时间" SortExpression="AddDate" />
            <asp:TemplateField HeaderText="查看表单" SortExpression="ApplicationId">
                <ItemTemplate>
                    <a href="ApplicationView.aspx?ApplicationId=<%# Eval("ApplicationId") %>" target="_self">查看表单</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预览" SortExpression="ApplicationId">
                <ItemTemplate>
                    <a href="../PageView.aspx?ApplicationId=<%# Eval("ApplicationId") %>" target="_blank">前端预览</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="导出表单" SortExpression="ApplicationId">
                <ItemTemplate>
                    <a href="Excel.aspx?ApplicationId=<%# Eval("ApplicationId") %>" target="_self">导出Excel格式</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="报名情况" SortExpression="ApplicationId">
                <ItemTemplate>
                    <a href="ApplicationShow.aspx?ApplicationId=<%# Eval("ApplicationId") %>" target="_self">报名情况</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle CssClass="FooterStyle" Height="1px" />
        <RowStyle CssClass="RowStyle" />
        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <SelectedRowStyle CssClass="SelectedRowStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
        SelectCommand="SELECT * FROM [Application]" >
    </asp:SqlDataSource>

</asp:Content>


