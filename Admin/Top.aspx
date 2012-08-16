<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="admin_Top" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>后台管理系统</title>
    <link href="Css/header.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
    function fixPNG(myImage)
  {    
	var arVersion = navigator.appVersion.split("MSIE");    
	var version = parseFloat(arVersion[1]);    
	
	if ((version >= 5.5) && (version < 7) && (document.body.filters)) {        
		var imgID = (myImage.id) ? "id='" + myImage.id + "' " : "";        
		var imgClass = (myImage.className) ? "class='" + myImage.className + "' " : "";         
		var imgTitle = (myImage.title) ? "title='" + myImage.title   + "' " : "title='" + myImage.alt + "' ";        
		var imgStyle = "display:inline-block;" + myImage.style.cssText;        
		var strNewHTML = "<span " + imgID + imgClass + imgTitle            
						+ " style=\"" + "width:" + myImage.width            
						+ "px; height:" + myImage.height            
						+ "px;" + imgStyle + ";" + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"            
						+ "(src=\'" + myImage.src + "\', sizingMethod='scale');\"></span>";         
		myImage.outerHTML = strNewHTML;     
	}
   }
    function PrintToday()
	{                                                             
		var today = new Date();                                                                   
		var year = today.getYear();                                                                   
		var date = today.getDate();                                                                   
		var todays_date = new Date;                                                                   
		days = new Array("天","一","二","三","四","五","六");
		months = new Array("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12");
		document.getElementById("date").innerHTML = year + "年" + months[todays_date.getMonth()] + "月" + date + "日" + "&nbsp;&nbsp;&nbsp;" + "星期" + days[todays_date.getDay()];                                             
		//document.writeln( year+"年"+months[todays_date.getMonth()]+"月"+date+"日"+"&nbsp;"+"星期"+days[todays_date.getDay()] );  
	}
	function changemenu(n)
	{
		var m = document.getElementById("dashmenu").getElementsByTagName("li").length;
	    for(var i=1;i<=m;i++)
	    {
	        document.getElementById("dashmenu").getElementsByTagName("li")[i-1].className="";
	    }
	    document.getElementById("menuli"+n).className="select";
	}
</script>
</head>
<body onload="PrintToday();">
    <form id="form1" runat="server">
    <div id="header">
	<div id="banner">
        <asp:Image ID="Image1" runat="server" ImageUrl="Image/top.gif" />
    </div>
        <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
            <asp:TableRow>
                <asp:TableCell CssClass="login_info" Height="28px">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    当前时间：<span id="date"></span>
                </asp:TableCell>
                <asp:TableCell Height="28px">
                    <span id="logout">
                         <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/index.aspx">查看网页</asp:HyperLink>　|　<a href="login_out.aspx" target="_parent">退出</a>
                    </span>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</div>
    </form>
</body>
</html>
