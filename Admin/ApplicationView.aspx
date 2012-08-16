<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ApplicationView.aspx.cs" Inherits="Admin_ApplicationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Admin_Title" Runat="Server">
    当前位置：查看报名表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Admin_main" Runat="Server">
    <div class="form_table" style="width:580px; padding:10px;">
    
        报名表状态：<asp:Literal ID="lit_status" runat="server"></asp:Literal>
        <br />
        <div class="clear"></div>
        相关操作：
        <br />
        <div class="clear"></div>
        <div class="btn_group">
            <asp:LinkButton ID="Button1" runat="server" Text="生成表单" onclick="Button1_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" Text="删除表单" onclick="Delete" />
            <asp:LinkButton ID="LinkButton2" runat="server" Text="暂停表单" />
            <asp:LinkButton ID="LinkButton3" runat="server" Text="完成此表单" onclick="finish" />
        </div>
        <div class="clear"></div>
    </div>

    <div class="clear"></div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ApplicationConnectionId" DataSourceID="SqlDataSource2" EnableModelValidation="True"
         ShowFooter="True" CssClass="GridViewStyle" 
            onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
            onrowcommand="GridView1_RowCommand" >
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="True" />
            <asp:BoundField DataField="ApplicationConnectionId" HeaderText="表单选项ID" ReadOnly="True" 
                SortExpression="ApplicationConnectionId" InsertVisible="False" />
            <asp:BoundField DataField="Name" HeaderText="选项名称" SortExpression="Name" />
            <asp:BoundField DataField="Index" HeaderText="排序字段" SortExpression="Index" />
            <asp:TemplateField HeaderText="选项类别" SortExpression="TypeId">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# getType(Convert.ToInt32(Eval("TypeId").ToString())) %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" 
                        DataSourceID="SqlDataSourceX" DataTextField="About" DataValueField="TypeConnection" 
                        SelectedValue='<%# Bind("TypeId", "{0}") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceX" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
                        SelectCommand="SELECT * FROM [Type] WHERE ([TypeKey] = @TypeKey)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="ApplicationItemType" Name="TypeKey" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Value" HeaderText="值" SortExpression="Value" />
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
        UpdateCommand="UPDATE [ApplicationConnection] SET [TypeId]=@TypeId,[Name]=@Name,[Index]=@Index,[Value]=@Value WHERE [ApplicationConnectionId]=@ApplicationConnectionId" 
        DeleteCommand="DELETE FROM [ApplicationConnection] WHERE [ApplicationConnectionId]= @ApplicationConnectionId" 
        SelectCommand="SELECT * FROM [ApplicationConnection] WHERE [ApplicationId] = @ApplicationId" >
        <UpdateParameters>
            <asp:Parameter Name="ApplicationConnectionId" Type="Int32" />
            <asp:Parameter Name="TypeId" DbType="Int32" />
            <asp:Parameter Name="Index" DbType="Int32" />
            <asp:Parameter Name="Name" DbType="String" />
            <asp:Parameter Name="Value" DbType="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="ApplicationId" Name="ApplicationId" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ApplicationConnectionId" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>

    
    <asp:Panel ID="form" runat="server">
        

    <table cellSpacing="0" cellPadding="0" width="600" border="0" class="form_table" >
        <tr>
            <td width="8"></td>
            <td vAlign="top">
            <!-- 主要工作区 开始-->
                <table cellSpacing="0" cellPadding="2" width="100%" border="0" align="center" class="t_all">
                    <tr>
                        <td colspan="2" style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td width="25%" class="tab_all" align="right">选项名称：</td>
                        <td width="75%" class="tab_left">
                            <input id="name" type="text" runat="server" style="width: 188px" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="tab_all" align="right">排序值(整数)：</td>
                        <td width="75%" class="tab_left">
                            <input id="txt_index" type="text" runat="server" style="width: 188px" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="tab_all" align="right">值：</td>
                        <td width="75%" class="tab_left">
                            <input id="txt_value" type="text" runat="server" style="width: 288px" value="null" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="tab_all" align="right">长度：</td>
                        <td width="75%" class="tab_left">
                            <input id="txt_length" type="text" runat="server" style="width: 288px" value="50" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="tab_all" align="right">是否必填：</td>
                        <td width="75%" class="tab_left">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True" Text="是" Value="2"></asp:ListItem>
                                <asp:ListItem Text="否" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_all" align="right">选项类型：</td>
                        <td>
                            <asp:DropDownList ID="typeId" runat="server" DataSourceID="SqlDataSource1" DataTextField="About" DataValueField="TypeConnection"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
                                SelectCommand="SELECT * FROM [Type] WHERE ([TypeKey] = @TypeKey)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="ApplicationItemType" Name="TypeKey" Type="String" />
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
    </asp:Panel>


</asp:Content>

