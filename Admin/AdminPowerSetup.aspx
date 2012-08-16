<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPowerSetup.aspx.cs" Inherits="Admin_AdminPowerSetup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    

</head>
<body>
    <form id="form1" runat="server">
    
    <span class="info_title">当前所在位置：设置管理员权限</span>
    <div id="shit"></div>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="id" 
        DataSourceID="SqlDataSource" DefaultMode="Insert">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate>
            <table width="800" class="form_table">
                <thead>
                    <tr>
                        <th style="height:10px; width:80px;">
                        </th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text='loading' OnLoad="getname" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="400px" Width="400px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CC3300" BackColor="White">
                            <asp:Panel ID="Panel3" runat="server" CssClass="panel_checkbox">
                                <asp:Label ID="Label3" runat="server" Text="该管理员的权限："></asp:Label>
                                <asp:CheckBoxList ID="CheckBoxList3" runat="server" DataSourceID="SqlDataSource2" 
                                    DataTextField="name" DataValueField="id" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="5" OnDataBound="checking">
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
                                    SelectCommand="SELECT * FROM [ywAdminPower]"></asp:SqlDataSource>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="400px" Width="400px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CC3300" BackColor="White">
                            
                        </asp:Panel>
                    </td>
                </tr>
                <tfoot>
                    <tr>
                        <td colspan="4" style="height:10px;">
                        </td>
                    </tr>
                </tfoot>
            </table>
            <div class="clear" style="height:10px;"></div>
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" OnClick="submit" Text="提交" CssClass="btn_1" />
            <asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="取消" CssClass="btn_2" />
        </InsertItemTemplate>
        <ItemTemplate></ItemTemplate>
    </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ywSystemConnectionString %>" 
        SelectCommand="SELECT * FROM [ywAdminPowerConnection] WHERE [id]=@id" >
        <InsertParameters>
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
    <script type="text/javascript" src="js/success.js"></script>
</body>
</html>
