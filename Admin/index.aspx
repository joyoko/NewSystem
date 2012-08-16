<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>@2012 中国地质大学自助报名系统, powered by 余悠</title>
    <link type="text/css" rel="stylesheet" href="CSS/main.css" />
</head>
<frameset rows="110,*" cols="*" frameborder="no" border="0"> 
  <frame src="Top.aspx" name="topFrame" id="topFrame" scrolling="no" noresize /> 
  <frameset rows="*" cols="180,*" id="bodyFrame"> 
    <frame src="Left.aspx" id="menu-frame" name="menu-frame" scrolling="yes" /> 
    <frame src="Right.htm" id="main-frame" name="main-frame" style=" padding:0;"/> 
  </frameset> 
</frameset> 
<noframes><body> 
</body> 
</noframes>
</html>
