<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>后台管理系统</title>
    <link href="Css/blue.css" rel="stylesheet" type="text/css" />
 <style type="text/css">
html, body {
   	background-color:White;
	SCROLLBAR-FACE-COLOR:#d2e3f5;
　　/*定义两端箭头的方块及滑块的背景色*/
	SCROLLBAR-HIGHLIGHT-COLOR:#b9d2ea;
　　/*定义两端箭头方块的顶部及左边的边框色*/
	SCROLLBAR-SHADOW-COLOR:#dbe8f4;
　　/*定义两端箭头颜色及方块的底部和右边的边框色*/
	SCROLLBAR-3DLIGHT-COLOR:#f5f5f5;
　　/*定义3D凸起边框颜色*/
	SCROLLBAR-ARROW-COLOR:#7193b0;
　　/*定义箭头凹陷颜色*/
	SCROLLBAR-TRACK-COLOR:#e6ebed;
　　/*定义滚动条主体背景色*/
　　
	SCROLLBAR-DARKSHADOW-COLOR:#a1c0e2;
　　/*定义滚动条凹陷颜色*/
}
</style>
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.subMenu.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript">
    var Mysubmenu=null;
    $(function(){
	    Mysubmenu=$("#my_menu").submenu({oneSmOnly:false,speed:500,expandNum:5,savestatus:true});	
    })
    </script>
    <script type="text/javascript">
    $(document).ready(function(){
	    $("div#my_menu div a").click(function(){
		    $("div#my_menu div a").removeClass("current");
		    $(this).addClass("current");
	    });
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="sidebar">
	<div runat="server" id="my_menu">
    	<div runat="server" id="menu_1">
            <span>报名表管理</span>
            <a href="ApplicationList.aspx" target="main-frame">报名表列表</a>
            <a href="ApplicationInsert.aspx" target="main-frame">新建报名表</a>
        </div>

        <div runat="server" id="menu_2">
            <span>系统设置</span>
            <a href="ChangePwd.aspx" target="main-frame">修改密码</a>
            <a href="insertAdmin.aspx" target="main-frame">添加管理员</a>
        </div>
    </div>
</div>
    </form>
</body>
</html>
