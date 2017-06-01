<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paper.aspx.cs" Inherits="student_Paper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../javascript/jquery-1.10.0.min.js"></script>
<style type="text/css">
.slide{position:relative;width:800px;padding:10px;}
.slide .pic img{width:100%;  border:1px solid #e4e4e4;}
</style>
</head>
<body ondragstart="window.event.returnValue=false" oncontextmenu="window.event.returnValue=false" 
    onselectstart="event.returnValue=false">
<div class="slide"><!--试卷div开始-->
    <asp:Panel ID="PanImg" runat="server" CssClass="pic">
    </asp:Panel><!--试卷div结束-->
</div><!--center div结束-->
    <script type="text/javascript">
        //屏蔽刷新等操作
        function f15() {
            if ((event.keyCode == 8) ||                    //屏蔽退格删除键     
             (event.keyCode == 116) ||                   //屏蔽F5刷新键    
             (event.ctrlKey && event.keyCode == 82)) {   //Ctrl+R    
                event.keyCode = 0;
                event.returnValue = false;
            }
        }
        window.onkeydown = f15;
            </script>
</body>
</html>
