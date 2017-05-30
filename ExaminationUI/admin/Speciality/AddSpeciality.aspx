<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSpeciality.aspx.cs" Inherits="admin_Speciality_AddSpeciality" %>
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
      .showdiv {
     background:#d0eea9; 
     width:320px; 
     border:1px solid gray;
      }
          .showdiv td {
          text-align:center;}
      .red {
      color:red;}
      .auto-style1 {
          font-size: 12px;
          width: 18%;
      }
      .auto-style2 {
          width: 18%;
      }
-->
</style>

<script type="text/javascript" src="../../javascript/jquery.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>

<script type="text/javascript">
    function Show(num) {
        var s = document.getElementById("edit");
        if (num == 0) s.innerHTML = "新增专业信息";
        else {
            s.innerHTML = "修改专业信息";
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=getSpecial&zyid=" + num,
                success: function (msg) {
                    var ms = msg.split("|");
                    $("#hidSpecID").val(ms[0]);
                    $("#ZyName").val(ms[1]);
                    $("#Remark").val(ms[2]);
                }
            });
        }
    }
    /*按下取消按钮时清空数据*/
    function CloseEmpty() {
        $("#ZyName ").val("");/*专业名称*/
        $("#spanzy").text("");/*专业*/
        $("#Remark").val("");/*备注*/
        return false;
    }
    $(document).ready(function () {
        var num = 0;
        $("#ZyName").change(function () {
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=editoradd&specName=" + $("#ZyName").val() + "&zyid=" + $("#hidSpecID").val(),
                success: function (msg) {
                    if (msg == "已存在") {
                        $("#spanzy").text(msg);
                        num = 1;
                    }
                    else {
                        $("#spanzy").text("");
                        num = 2;
                    }
                }
            });
        });
        $("#txtSpecName").val("按专业名模糊查找");
        $("#txtSpecName").css("color", "#CCC");
        $("#txtSpecName").focus(function () {
            var txt = $(this).val();
            if (txt.trim() == "按专业名模糊查找") {
                $(this).val("");
                $("#txtSpecName").css("color", "#000"); 
            }
        });
        $("#txtSpecName").blur(function () {
            var txt = $(this).val();
            if (txt.trim() == "") {
                $("#txtSpecName").css("color", "#CCC");
                $(this).val("按专业名模糊查找");
            }
        });
        $("#btnbc").click(function () {
            if (num == 1) { $("#spanzy").text("已存在"); return false; }
            else return true;
        });
    });
    function SelectByName()
    {
        $.ajax({
            type: "post",
            url: "AddSpeciality.aspx",
            dataType: "string",
            data: "",
            success: function (msg) {
                $("#btnsx").click();
            }
        });
    }
    </script>
</head>
<body style="font-size:12px;">
<form name="myform1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Button ID="btnsx" style="display:none;" runat="server" Text="隐藏刷新按钮" OnClick="Button2_Click" />
<div style="margin-left:30px; margin-top:5px;">筛选条件：<input id="txtSpecName" type="text" runat="server" onpropertychange="SelectByName()" class="text-input" style="height:15px;width:200px; line-height:15px;" /></div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
<table width="100%" border="0"  cellpadding="0" cellspacing="0" style="position:absolute">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
        <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" /> <span class="STYLE4">专业信息列表</span></td>
        <td width="281" background="../../html/tab/images/tab_05.gif"><table border="0" align="right" cellpadding="0" cellspacing="0">
            <tr>
              <td width="60">
                  <table width="90%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="STYLE1"><div align="center"><img src="../../html/tab/images/001.gif" width="14" height="14" /></div></td>
                    <td class="STYLE1"><div align="center"><a href="#" id="addspecA" onclick="Show(0)">新增</a></div></td>
                  </tr>
              </table></td>
            </tr>
        </table>

        </td>
        <td width="14"><img src="../../html/tab/images/tab_07.gif" width="14" height="30" /></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="9" background="../../html/tab/images/tab_12.gif">&nbsp;</td>
        <td bgcolor="#f3ffe3"><table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()"  onmouseout="changeback()" id="tablepage">
          <tr>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style1"><div align="center" class="STYLE2 STYLE1">
                专业</div></td>
            <td width="24%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">备注</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">修改</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">删除</div></td>
          </tr>
        <%
            int i = 0;
            foreach (DataRow item in specialityList.Rows)
            {
                i++;%>
        <tr>
            <td height="18" bgcolor="#FFFFFF" class="auto-style2"><div align="center" class="STYLE2 STYLE1"><%=item["ZyName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=item["Remark"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><img src="../../html/tab/images/037.gif" width="9" height="9" /><span class="STYLE1"> [</span><a href="#" id="a<%=i %>" onclick="Show(<%=item["ZyID"] %>)">修改</a><span class="STYLE1">]</span></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/010.gif" width="9" height="9" /> </span><span class="STYLE1">[</span><a href="?ZyID=<%=item["ZyID"].ToString() %>">删除</a><span class="STYLE1">]</span></div></td>
        </tr>
        <% } %>
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
            <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=count %>条纪录，当前第<span id="spannowpage" runat="server"><%=Pages %></span>/<span id="spanpages" runat="server"><%=maxPage %></span>页，每页<%=len %>条纪录</span></td>
            <td width="75%" valign="top" class="STYLE1"><div align="right">
              <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="62" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageFrist" runat="server" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" OnClick="ImageFrist_Click"  />
                  </div></td>
                  <td width="50" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageBack" runat="server" ImageUrl="../../html/tab/images/back.gif"  width="43" height="15" OnClientClick="return BackPage()" OnClick="ImageBack_Click" />
                  </div></td>
                  <td width="54" height="22" valign="middle"><div align="right"> 
                     <asp:ImageButton ID="ImageNext" runat="server" ImageUrl="../../html/tab/images/next.gif"  width="43" height="15" OnClientClick="return NextPage()" OnClick="ImageNext_Click" />
                  </div></td>
                  <td width="49" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageEnd" runat="server" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" OnClick="ImageEnd_Click" />
                  </div></td>
                  <td width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                  <td width="25" height="22" valign="middle"><span class="STYLE7">
                    <asp:TextBox ID="tzpage" runat="server" CssClass="STYLE1" Width="25px" Height="10px" style=" line-height:10px;" size="5" ></asp:TextBox>
                  </span></td>
                  <td width="23" height="22" valign="middle">页</td>
                  <td width="30" height="22" valign="middle">
                      <asp:ImageButton ID="ImageGO" runat="server" ImageUrl="../../html/tab/images/go.gif"  width="37" height="15"  OnClientClick="return JumpPage()"  OnClick="ImageGO_Click" />
                  </td>
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
    <asp:AsyncPostBackTrigger ControlID="btnsx" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
    <div id="Addzy" align="center" class="showdiv"  style=" display:none; position:absolute"  >
        <table width="320px">
            <caption  style="margin-top:15px; height:40px; line-height:40px;font-weight:900;font-size:16px" id="edit">添加专业信息</caption>
            <tr>
                <td style="height:30px; line-height:30px;width:80px;text-align:right">专业名：</td>
                <td style="width:160px;text-align:left"><asp:TextBox ID="ZyName" name="ZyName" CssClass="text-input" style="width:160px;" MaxLength="25"  runat="server"></asp:TextBox></td>
                <td style="text-align:left"><span id="spanzy" class="red"></span></td>
            </tr>
              <tr>
                <td  style="width:80px;text-align:right">备&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
                <td  style="width:160px;text-align:left"><asp:TextBox ID="Remark" CssClass="text-input" TextMode="MultiLine" MaxLength="50" Wrap="true"  name="Remark" style="overflow:hidden;width:160px;height:60px"  runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
               <tr>
                <td colspan="3" valign="bottom"  style="height:50px;line-height:50px;text-align:center;"><asp:Button ID="btnbc" CssClass="button" runat="server" Text="确  定" OnClientClick="return CheckSpeciality()" OnClick="btnbc_Click" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <input type="hidden" id="hidSpecID" runat="server" /> &nbsp&nbsp&nbsp
                <asp:Button ID="btnClose" runat="server" OnClientClick="return CloseEmpty()" CssClass="button" Text="取  消" /></td>
            </tr>
        </table>
    </div>
<script type="text/javascript">
    AlterDivAndClose("Addzy", "addspecA", "btnClose");
var count =<%=specialityList.Rows.Count %> +"";
    for (var i = 1; i <= count; i++)
    AlterDivAndClose("Addzy", "a" + i, "btnClose");
</script>

</form>
</body>
</html>
