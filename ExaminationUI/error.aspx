<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        var s = 5;
        function error()
        {
            document.getElementById("ss").innerText = s;
            s--;
            if (s == 0)
                location.href = "Login.aspx";
            setTimeout("error()", 1000);
        }
        window.onload = error;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:18px;">
    页面参数错误<span id="ss" style="color:red;"></span>秒后自动跳转至登录页面
    </div>
    </form>
</body>
</html>
