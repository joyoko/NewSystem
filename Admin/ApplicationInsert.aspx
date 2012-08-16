<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ApplicationInsert.aspx.cs" Inherits="Admin_ApplicationInsert" %>
<%@ Register assembly="CuteEditor" namespace="CuteEditor" tagprefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Admin_Title" Runat="Server">
    当前位置：新建报名表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Admin_main" Runat="Server">


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
                        <td width="25%" class="tab_all" align="right">表单名：</td>
                        <td width="75%" class="tab_left">
                            <input id="applicationName" type="text" runat="server" style="width: 188px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_all" align="right">表单提示信息：</td>
                        <td>
                            <CE:Editor ID="content" runat="server" FilesPath="" 
                                 Height="300px" Width="500px" ThemeType="Office2007" AutoConfigure="None">
                            </CE:Editor>
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

</asp:Content>

