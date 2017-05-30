<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAnswer.aspx.cs" Inherits="admin_AnswerCard_EditAnswer" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="../../css/style.css" rel="stylesheet" />
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    font-size:12px;
}
.STYLE1 {font-size: 12px}
.STYLE4 {
	font-size: 12px;
	color: #1F4A65;
	font-weight: bold;
}

a:link {
	font-size: 12px;
	color: #06482a;
	text-decoration: none;

}
a:visited {
	font-size: 12px;
	color: #06482a;
	text-decoration: none;
}
a:hover {
	font-size: 12px;
	color: #FF0000;
	text-decoration: underline;
}
a:active {
	font-size: 12px;
	color: #FF0000;
	text-decoration: none;
}
.STYLE7 {font-size: 12px;}

    .auto-style1 {
        font-size: 12px;
        width: 17%;
    }
    .auto-style2 {
        width: 17%;
    }
    .auto-style3 {
        font-size: 12px;
        width: 12%;
    }
    .auto-style4 {
        width: 12%;
    }
    .auto-style7 {
        font-size: 12px;
        width: 8%;
    }
    .auto-style8 {
        width: 8%;
    }
    .auto-style9 {
        font-size: 12px;
        width: 22%;
    }
    .auto-style10 {
        width: 22%;
    }
    .auto-style11 {
        font-size: 12px;
        width: 14%;
    }
    .auto-style12 {
        width: 14%;
    }

-->
</style>
<script type="text/javascript" src="../../javascript/jquery.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $("#txtEditAnwer").val("按姓名、学号、试卷名和科目名模糊查找");
        $("#txtEditAnwer").css("color","#CCC");
        $("#txtEditAnwer").focus(function () {
            var txt = $(this).val();
            if (txt.trim() == "按姓名、学号、试卷名和科目名模糊查找") {
                $(this).val("");
                $("#txtEditAnwer").css("color", "#000");
            }
        });
        $("#txtEditAnwer").blur(function () {
            var txt = $(this).val();
            if (txt.trim() == "") {
                $("#txtEditAnwer").css("color", "#CCC");
                $(this).val("按姓名、学号、试卷名和科目名模糊查找");
            }
        });
    });
    function SelectEditAnwerName() {
       $("#btnEditAnwer").click();
    }
    function CheckStatus()
    {
        $("#checks").click(function () { $("#btnEditAnwer").click(); });
        $("#CheckBox1").click(function () { $("#btnEditAnwer").click(); });
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Button ID="btnEditAnwer" style="display:none;" runat="server" Text="隐藏刷新按钮" OnClick="btnEditAnwer_Click" />
<div style="margin-left:30px; margin-top:5px;" class="STYLE1">筛选条件：<input id="txtEditAnwer" type="text" runat="server" onpropertychange="SelectEditAnwerName()" class="text-input" style="height:15px;width:300px; line-height:15px;" /></div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
   <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
        <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" /> <span class="STYLE4">试卷列表信息</span></td>
        <td width="281" background="../../html/tab/images/tab_05.gif"><table border="0" align="right" cellpadding="0" cellspacing="0">
            <tr>
              <td width="60"><table width="87%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="STYLE1"><div align="center">
                       <asp:CheckBox ID="checks" name="checks" runat="server" Checked="false" OnCheckedChanged="Page_Load"/>
                    </div></td>
                    <td class="STYLE1"><div align="center">已批阅</div></td>
                  </tr>
              </table></td>
                <td width="60"><table width="87%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="STYLE1"><div align="center">
                       <asp:CheckBox ID="CheckBox1" name="CheckBox1" runat="server" Checked="false" OnCheckedChanged="Page_Load"/>
                    </div></td>
                    <td class="STYLE1"><div align="center">未批阅</div></td>
                  </tr>
              </table></td>
            </tr>
        </table></td>
        <td width="14"><img src="../../html/tab/images/tab_07.gif" width="14" height="30" /></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="9" background="../../html/tab/images/tab_12.gif">&nbsp;</td>
        <td bgcolor="#f3ffe3"><table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()"  onmouseout="changeback()">
          <tr>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style3"><div align="center" class="STYLE2 STYLE1">姓名</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style11"><div align="center" class="STYLE2 STYLE1">学号</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style9"><div align="center" class="STYLE2 STYLE1">试卷</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style1"><div align="center" class="STYLE2 STYLE1">科目</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style7"><div align="center" class="STYLE2">状态</div></td>
            <!--td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">修改</div></td-->
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">删除</div></td>
          </tr>
            <%foreach (DataRow item in objTopicList.Rows)
              {%>
         <tr>
            <td height="18" bgcolor="#FFFFFF" class="auto-style4"><div align="center" class="STYLE2 STYLE1"><%=item["XsName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style12"><div align="center" class="STYLE2 STYLE1"><%=item["Xh"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style10"><div align="center" style="text-align:left" class="STYLE2 STYLE1"><%=item["SjName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style2"><div align="left" style="text-align:left" class="STYLE2 STYLE1"><%=item["KmName"].ToString() %></div></td>
            <!--td height="18" bgcolor="#FFFFFF"><div align="center"><a href="#">0</a></div></td-->
            <!--td height="18" bgcolor="#FFFFFF" class="auto-style8"><div align="center"><%=item["Zt"].ToString().Equals("2")?"未批阅":"已批阅" %></div></td-->
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/037.gif" width="9" height="9" /></span><span class="STYLE1"> [</span>
                    <%if (item["Zt"].ToString().Equals("2"))
                      {%>
                        <a href="ReadPaper.aspx?KgtID=<%=item["KgtID"] %>">批阅</a>
                     <%
                     }
                      else
                      { %>
                        已阅
                    <%  }%>
                 
                <span class="STYLE1">]</span></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/010.gif" width="9" height="9" /></span><span class="STYLE2"> </span><span class="STYLE1">[</span><a href="#">删除</a><span class="STYLE1">]</span></div></td>
          </tr>
            <%
                  
              } %>
        </table></td>
        <td width="9" background="../../html/tab/images/tab_16.gif">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="29"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="15" height="29"><img src="../../html/tab/images/tab_20.gif" width="15" height="29" /></td>
        <td background="../../html/tab/images/tab_21.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=count %>条纪录，当前第<span id="spannowpage" runat="server"><%=Pages %></span>/<span id="spanpages" runat="server"><%=maxPage %></span>页，每页<span id="lenid" runat="server"><%=len %></span>条纪录</span></td>
            <td width="75%" valign="top" class="STYLE1"><div align="right">
              <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="62" height="22" valign="middle"><div align="right">
                      <asp:ImageButton id="ImageFrist" ImageUrl="../../html/tab/images/first.gif" runat="server" width="37" height="15" OnClick="ImageFrist_Click" /></div></td>
                  <td width="50" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageBack" ImageUrl="../../html/tab/images/back.gif" runat="server"  width="43" height="15"  OnClientClick="return BackPage()" OnClick="ImageBack_Click" /></div></td>
                  <td width="54" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageNext" ImageUrl="../../html/tab/images/next.gif" runat="server"    width="43" height="15" OnClientClick="return NextPage()" OnClick="ImageNext_Click" /></div></td>
                  <td width="49" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageLast" ImageUrl="../../html/tab/images/last.gif" runat="server"    width="37" height="15" OnClick="ImageLast_Click" /></div></td>
                  <td width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                  <td width="25" height="22" valign="middle"><span class="STYLE7">
                      <asp:TextBox ID="tzpage"  name="textfield" runat="server"  class="STYLE1" MaxLength="8" style="height:10px; width:25px;" size="5" ></asp:TextBox>
                  </span></td>
                  <td width="23" height="22" valign="middle">页</td>
                  <td width="30" height="22" valign="middle">
                      <asp:ImageButton ID="ImageGo" ImageUrl="../../html/tab/images/go.gif" runat="server"   width="37" height="15" OnClientClick="return JumpPage()" OnClick="ImageGo_Click" /></td>
                </tr>
              </table>
            </div></td>
          </tr>
        </table></td>
        <td width="14"><img src="../../html/tab/images/tab_22.gif" width="14" height="29" /></td>
      </tr>
    </table></td>
  </tr>
</table>  
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnEditAnwer" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</form>
</body>
</html>
