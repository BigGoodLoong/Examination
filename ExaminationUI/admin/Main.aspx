<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="admin_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <frameset rows="61,*,24" cols="*" framespacing="0" frameborder="no" border="0">
      <frame src="/html/top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
      <frame src="/html/center.aspx?status=<%=status %>" name="mainFrame" id="mainFrame" />
      <frame src="/html/down.html" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" />
    </frameset> 

</html>
