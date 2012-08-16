<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Admin_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="../css/form.css" />
    <link href="../Admin/Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <span class="info_title">当前所在位置：修改密码</span>
            <table width="800" class="form_table">
                <thead>
                    <th style="height:10px;"></th>
                    <th></th>
                </thead>
                <tr>
                    <td>原密码:</td>
                    <td><asp:TextBox TextMode="Password" ID="oldPwd" runat="server" /></td>
                </tr>
                <tr>
                    <td>新密码:</td>
                    <td><asp:TextBox TextMode="Password" ID="newPwd1" runat="server" /></td>
                </tr>
                <tr>
                    <td>确认新密码:</td>
                    <td><asp:TextBox TextMode="Password" ID="newPwd2" runat="server" /></td>
                </tr>
                <tfoot>
                    <td colspan="2" style="height:10px;"></td>
                </tfoot>
            <table>
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" Text="提交" CssClass="btn_1" OnClick="add" />
    </form>
</body>
</html>
