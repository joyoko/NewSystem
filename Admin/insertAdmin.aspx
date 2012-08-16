<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertAdmin.aspx.cs" Inherits="admin_insertAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Css/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

    <span class="info_title">当前所在位置：管理员设置</span>
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" DataSourceID="SqlDataSource2" EnableModelValidation="True"
         ShowFooter="True" CssClass="GridViewStyle" 
            onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
            onrowcommand="GridView1_RowCommand" >
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" ShowCancelButton="true" />
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" InsertVisible="False" />
            <asp:TemplateField HeaderText="pwd" SortExpression="pwd">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='请输入新密码' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='管理员密码不可见'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:TemplateField HeaderText="power" SortExpression="power">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" 
                        DataSourceID="SqlDataSourceX" DataTextField="name" DataValueField="typeId" 
                        SelectedValue='<%# Bind("power", "{0}") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceX" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
                        SelectCommand="SELECT * FROM [ywType] WHERE ([typetype] = @typetype)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Admin" Name="typetype" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("power") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="id" 
                DataNavigateUrlFormatString="AdminPowerSetup.aspx?id={0}" HeaderText="权限设置" 
                Text="权限设置" />
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
        DeleteCommand="DELETE FROM [Admin] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [Admin] ([pwd], [name], [power]) VALUES (@pwd, @name, @power)" 
        SelectCommand="SELECT * FROM [Admin]" 
        UpdateCommand="UPDATE [Admin] SET [pwd] = @pwd, [name] = @name, [power] = @power,[salt]=@salt WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="pwd" Type="String" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="power" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="pwd" Type="String" DefaultValue="shittt!" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="power" Type="Int32" />
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="salt" Type="String" DefaultValue="right" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <table cellSpacing="0" cellPadding="0" width="600" border="0" class="form_table">
				<tr>
					<td width="8"></td>
					<td vAlign="top">
						<!-- 主要工作区 开始-->
						<table cellSpacing="0" cellPadding="2" width="100%" border="0" align="center" class="t_all">
							<tr>
								<td colspan="2" style="height:20px;"></td>
							</tr>
							<tr>
								<td width="15%" class="tab_all" align="right">名称：</td>
								<td width="85%" class="tab_left">
									<input id="name" type="text" runat="server" style="width: 188px" />
								</td>
							</tr>
							<tr>
								<td width="15%" class="tab_all" align="right">密码：</td>
								<td width="85%" class="tab_left">
								 <input id="password" type="password" runat="server" style="width: 188px" />
								</td>
							</tr>
							<tr>
								<td colspan="2">
                                    <asp:DropDownList ID="DropDownList1" runat="server" 
                                        DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="typeId">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
                                        SelectCommand="SELECT * FROM [ywType] WHERE ([typetype] = @typetype)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="Admin" Name="typetype" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
							</tr>
							<tr>
								<td colspan="2" style="height:20px;"></td>
							</tr>
						</table>
						<!-- 主要工作区 结束-->
					</td>
					<td width="8"></td>
				</tr>
	  </table>
      <div class="clear" style="height:10px"></div>
      <asp:button id="btnSave" runat="server" Text="保 存" Width="72px" OnClick="addBtn_Click" CssClass="btn_1"></asp:button>
    </div>
    </form>
</body>
</html>
