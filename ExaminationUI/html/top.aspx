<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="html_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>无标题文档</title>
<link href="../../css/style.css" rel="Stylesheet"/>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE1 {
	color: #43860c;
	font-size: 12px;
}
-->
</style>

</head>

<body>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
  <tr>
    <td height="9" style="line-height:9px; background-image:url(/images/admin/main_04.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="97" height="9" background="/images/admin/main_01.gif">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="47" background="/images/admin/main_09.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="38" height="47" background="/images/admin/main_06.gif">&nbsp;</td>
        <td width="59"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="29" background="/images/admin/main_07.gif">&nbsp;</td>
          </tr>
          <tr>
            <td height="18" background="/images/admin/main_14.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
              <tr>
                <td  style="width:1px;">&nbsp;</td>
                <td ><span class="STYLE1"><%=Request.Cookies["nowloginuser"].Value %></span></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td width="155" background="/images/admin/main_08.gif">&nbsp;</td>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="23" valign="bottom">
                <img src="/images/admin/main_12.gif" width="367" height="23" border="0" usemap="#Map" />
                <map name="Map">
                  <area shape="rect" alt="首页" coords="2,0,51,25" href="#首页" />
                  <area shape="rect" alt="" coords="51,1,99,24" href="javascript:history.go(-1);" />
                  <area shape="rect" alt="" coords="99,1,148,23" href="javascript:history.go(1);" />
                  <area shape="rect" alt="" coords="148,1,203,24" href="javascript:window.parent.frames[1].frames[1].location.reload();" />
                  <area shape="rect" alt="" coords="207,4,309,22" href="#个人" />
                  <area shape="rect" alt="" coords="309,4,367,22" href="javascript:location.href='../Exit.aspx'" />
                </map>
            </td>
          </tr>
        </table></td>
        <td width="200" background="/images/admin/main_11.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="11%" height="23">&nbsp;</td>
            <td width="89%" valign="bottom">
                <span class="STYLE1">
                    <script type="text/javascript" language="javascript">
                        var week;
                        if (new Date().getDay() == 0) week = "星期日"
                        if (new Date().getDay() == 1) week = "星期一"
                        if (new Date().getDay() == 2) week = "星期二"
                        if (new Date().getDay() == 3) week = "星期三"
                        if (new Date().getDay() == 4) week = "星期四"
                        if (new Date().getDay() == 5) week = "星期五"
                        if (new Date().getDay() == 6) week = "星期六"
                        document.write("日期：" + new Date().getFullYear() + "年" + (new Date().getMonth() + 1) + "月" + new Date().getDate() + "日 " + week);
                   </script>
                </span></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5" style="line-height:5px; background-image:url(/images/admin/main_18.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="180" background="/images/admin/main_16.gif"  style="line-height:5px;">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>

    <div style="width:300px; background:#d0eea9;border:1px solid gray" class="STYLE1" align="center" >
       <span style=" height:50px;line-height:50px;text-align:center;font-size:18px;font-weight:900">修改个人信息</span>
        <table style="width:300px;" cellpadding="0">
            <tr style="height:30px;line-height:30px">
                <td style="width:80px;text-align:right">用&nbsp;户&nbsp;名：</td>
                <td style="width:160px;text-align:left"><input id="TextYh" type="text" style="width:160px; height:20px;line-height:20px;padding-left:5px;" class="text-input"/></td>
                <td style="text-align:left"><span id="SpanYh"></span></td>
            </tr>
         
             <tr style="height:30px;line-height:30px">
                <td style="width:80px;text-align:right">密&nbsp&nbsp&nbsp&nbsp;码：</td>
                <td style="width:160px;text-align:left"><input id="Text1" type="text" style="width:160px; height:20px;line-height:20px;padding-left:5px;" class="text-input"/></td>
                <td style="text-align:left"><span id="SpanMM"></span></td>
            </tr>
             <tr style="height:30px;line-height:30px">
                <td style="width:80px;text-align:right">确认密码：</td>
                <td style="width:160px;text-align:left"><input id="Text2" type="text"  style="width:160px; height:20px;line-height:20px;padding-left:5px;" class="text-input" /></td>
                <td style="text-align:left"><span id="SpanQR"></span></td>
            </tr>
            <tr style="height:40px;line-height:40px">
                <td colspan="3" align="center"> <input id="ButtonOK" type="button" value=" 确 定 " />&nbsp&nbsp 
                    <input id="ButtonNO" type="button" value=" 取 消 " /></td>
            </tr>
        </table>
    </div>
<map name="Map" id="Map"><area shape="rect" coords="3, 1, 49, 22" href="#" /><area shape="rect" coords="52, 2, 95, 21" href="#" /><area shape="rect" coords="102, 2, 144, 21" href="#" /><area shape="rect" coords="150, 1, 197, 22" href="#" /><area shape="rect" coords="210, 2, 304, 20" href="#" /><area shape="rect" coords="314, 1, 361, 23" href="#" /></map>

</body>
</html>

