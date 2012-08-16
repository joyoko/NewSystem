<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="Admin_admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>后台管理登陆</title>
    <link href="Css/main.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        function EnterTextBox(button) {
            if (event.keyCode == 13 && document.all["txtPassword"].value != "") {
                event.keyCode = 9;
                event.returnValue = false;
                document.all[button].click();
            }
        }   
    </script>
</head>
<body style=" background: url(Image/bg.gif) repeat-x #fff; padding:0; border:0;"><form id="loginPanel" runat="server"><table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top" height="189" width="578"><asp:Image ID="Image2" runat="server" ImageUrl="Image/login_logo.gif" BorderStyle="None" ImageAlign="Left" /></td>
            <td></td>
        </tr>
        <tr>
            <td valign="top" height="235">
                <asp:Image ID="Image3" runat="server" ImageUrl="Image/login_logo2.gif" BorderStyle="None" ImageAlign="Left" />
                <span id="localtime" style="clear:both; padding-left:93px; height:60px; line-height:60px; font-family:宋体;"></span>
                <script type="text/javascript">
                function showLocale(objD)
                {
	                var str,colorhead,colorfoot;
	                var yy = objD.getYear();
	                if(yy<1900) yy = yy+1900;
	                var MM = objD.getMonth()+1;
	                if(MM<10) MM = '0' + MM;
	                var dd = objD.getDate();
	                if(dd<10) dd = '0' + dd;
	                var hh = objD.getHours();
	                if(hh<10) hh = '0' + hh;
	                var mm = objD.getMinutes();
	                if(mm<10) mm = '0' + mm;
	                var ss = objD.getSeconds();
	                if(ss<10) ss = '0' + ss;
	                var ww = objD.getDay();
	                if (ww == 0) colorhead = "<font color=\"#c1c3c8\">";
	                if (ww > 0 && ww < 6) colorhead = "<font color=\"#c1c3c8\">";
	                if (ww == 6) colorhead = "<font color=\"#c1c3c8\">";
	                if  (ww==0)  ww="星期日";
	                if  (ww==1)  ww="星期一";
	                if  (ww==2)  ww="星期二";
	                if  (ww==3)  ww="星期三";
	                if  (ww==4)  ww="星期四";
	                if  (ww==5)  ww="星期五";
	                if  (ww==6)  ww="星期六";
	                colorfoot="</font>"
	                str = colorhead + yy + "-" + MM + "-" + dd + "&nbsp;&nbsp;&nbsp;&nbsp;" + hh + ":" + mm + ":" + ss + "&nbsp;&nbsp;&nbsp;&nbsp;" + ww + colorfoot;
	                return(str);
                }
                function tick()
                {
	                var today;
	                today = new Date();
	                document.getElementById("localtime").innerHTML = showLocale(today);
	                window.setTimeout("tick()", 1000);
                }
                tick();
                </script>
            </td>
            <td align="left" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" align="left">
	                <tr>
	                    <td align="right" style="height: 30px; line-height:30px; width: 77px; color:#fff; font-size:14px;">用户名：</td>
	                    <td style="height: 30px; line-height:30px;" align="left" valign="bottom" colspan="2">
                            <asp:TextBox ID="txtUser" runat="server" Width="180px" AutoCompleteType="Disabled" BorderColor="#C6C6C6" BorderStyle="Solid" BorderWidth="1px" Height="16px"></asp:TextBox>
                        </td>
	                </tr>
	                <tr>
	                    <td align="right" style="height: 30px;  line-height:30px; width: 77px; color:#fff; font-size:14px;">密　码：</td>
	                    <td style="height: 30px; line-height:30px; " align="left" valign="bottom" colspan="2">
                            <asp:TextBox ID="txtPassword" runat="server" Width="180px" AutoCompleteType="disabled" TextMode="Password" BorderColor="#C6C6C6" BorderStyle="Solid" BorderWidth="1px" Height="16px"></asp:TextBox>
                        </td>
	                </tr>
	                <tr>
	                    <td align="right" style="height: 30px;  line-height:30px; width: 77px; color:#fff; font-size:14px;">验证码：</td>
	                    <td style="height: 30px; line-height:30px; " align="left" valign="middle">
                            <asp:TextBox ID="code" runat="server" Width="100px" AutoCompleteType="Disabled" BorderColor="#C6C6C6" BorderStyle="Solid" BorderWidth="1px" Height="16px"></asp:TextBox>
                        </td> 
                        <td>
                            <asp:Image ID="Image1" ImageUrl="~/securityCode.aspx" runat="server" />
                        </td>
	                </tr>
	                <tr>
	                    <td align="right" style="height: 40px;  line-height:30px; width: 77px; color:#fff; font-size:14px;"></td>
	                    <td style="height: 40px; line-height:40px; " align="left" valign="middle" id="btn_login">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btninput" OnClick="loginBtn_Click">登陆</asp:LinkButton>
                        </td>
	                </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="200" valign="top" align="left" style="padding-top:8px;">

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td colspan="2" style="color:#8f8f8f; font-size:12px; height:40px; line-height:40px; text-align:center; font-family:宋体;" align="center">@2012 中国地质大学自助报名系统. Powered by 余悠</td>
        </tr>
    </table>
    </form>
</body>
</html>
