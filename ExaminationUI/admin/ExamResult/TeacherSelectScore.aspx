<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="TeacherSelectScore.aspx.cs" Inherits="admin_ExamResult_TeacherSelectScore" %>
<%@ Register assembly="Chartlet" namespace="FanG" tagprefix="cc1" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>成绩查询</title>
<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>
<link href="../../css/style.css" rel="Stylesheet"/>

<style type="text/css">
body {
    margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    font-size:12px;
}
    td {
        text-align:left;
    }
.STYLE2 {
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
    .red {
    color:red;}
    .auto-style1 {
        font-size: 12px;
        width: 164px;
    }
</style>
     
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ddlSpec").change(function () {
                $("#txtNameTest").val("按姓名、试卷名模糊查找");
                $("#txtNameTest").css("color", "#CCC");
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=specChang&specid=" + $("#ddlSpec").val(),
                    success: function (msg) {
                        var subjects = msg.split('*');
                        $("#ddlSubject option").remove();
                        $("#ddlSubject").append("<option>全部</option>");
                        for (var i = 0; i < subjects.length-1; i++)
                            $("#ddlSubject").append("<option>" + subjects[i] + "</option>");
                        $("#btnsx").click();
                    }
                });
            });
            $("#ddlSubject").change(function () {
                $("#hidSubject").val($("#ddlSubject").val());
                $("#btnSubject").click();
            });
            $("#txtNameTest").val("按姓名、试卷名模糊查找");
            $("#txtNameTest").css("color", "#CCC");
            $("#txtNameTest").focus(function () {
                var txt = $(this).val();
                if (txt.trim() == "按姓名、试卷名模糊查找") {
                    $(this).val("");
                    $("#txtNameTest").css("color", "#000");
                }
            });
            $("#txtNameTest").blur(function () {
                var txt = $(this).val();
                if (txt.trim() == "") {
                    $("#txtNameTest").css("color", "#CCC");
                    $(this).val("按姓名、试卷名模糊查找");
                }
            });
        });
    </script>
    <script type="text/javascript">
        function Show(num) {
            var s = document.getElementById("edit");
            if (num == 0) s.innerHTML = "新增成绩信息";
            if (num == 1) s.innerHTML = "修改成绩信息";
            document.getElementById("addScoreInfo").style.display = "block";
        }
        function SelectScoreByName() {
            $("#btnsx").click();
        }
        function blockBtn()
        {
            $("#chartSpan").removeClass();
            $("#chartSpan").addClass("blockBtn");
            $("#btnOpenChart").unbind();
            $("#btnClose").unbind();
            AlterDivAndClose("divChart", "btnOpenChart", "btnClose");
        }
        function noneBtn() {
            $("#chartSpan").removeClass();
            $("#chartSpan").addClass("noneBtn");
        }
</script>
<style type="text/css">
    .blockBtn{display:block;margin-right:100px;float:right;}
    .noneBtn{display:none;margin-right:100px;}
</style>
</head>
<body>
<form id="Form1" name="Myform" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div style="margin-top:5px;">
    <asp:Button ID="btnsx" style="display:none;" runat="server" Text="隐藏刷新按钮" OnClick="btnsx_Click" />
    <asp:Button ID="btnSubject" style="display:none;" runat="server" Text="科目改变按钮" OnClick="btnSubject_Click" />
    <span style="margin-left:30px;">筛选条件：<input id="txtNameTest" type="text" runat="server" onpropertychange="SelectScoreByName()" class="text-input" style="height:15px;width:200px; line-height:15px;" /></span>
    <span style="margin-left:30px;">专业：<asp:DropDownList ID="ddlSpec" runat="server" CssClass="text-input" AutoPostBack="true" OnSelectedIndexChanged="ddlSpec_SelectedIndexChanged"></asp:DropDownList></span>
    <span style="margin-left:30px;">科目：<select id="ddlSubject" runat="server" css="text-input"></select></span>
    <span id="chartSpan"><input type="button" id="btnOpenChart" value="查看图表统计" class="button" /></span>
    <input type="hidden" runat="server" id="hidSubject" />
    
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>      
        <div style="position:absolute;">
           <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
                <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" />
                    <span class="STYLE2">成绩信息列表</span>
                    <span style="float:right;"><asp:Button ID="btnExprotScore" runat="server" Text="导出成绩" CssClass="button" OnClick="btnExprotScore_Click" /></span>
                </td>
                <td width="14"><img src="../../html/tab/images/tab_07.gif" width="14" height="30" /></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="9" background="../../html/tab/images/tab_12.gif">&nbsp;</td>
                <td bgcolor="#f3ffe3"><table width="99%" border="0" id="tablepage" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()"  onmouseout="changeback()">
                  <tr>
                    <td height="18" width="9%" background="../../html/tab/images/tab_14.gif"><div align="center">姓名</div></td>
                    <td height="18" width="21%" background="../../html/tab/images/tab_14.gif"><div align="center">试卷</div></td>
                    <td height="18" width="15%" background="../../html/tab/images/tab_14.gif"><div align="center">专业</div></td>
                    <td height="18" width="15%" background="../../html/tab/images/tab_14.gif"><div align="center">科目</div></td>
                    <td height="18" width="30%" background="../../html/tab/images/tab_14.gif"><div align="center">详细成绩</div></td>
                    <td height="18" width="10%" background="../../html/tab/images/tab_14.gif"><div align="center">总成绩</div></td>
                  </tr>
                    <%
                        if(scoreList!=null)
                        {
                        foreach (DataRow row in scoreList.Rows)
                        {
                          int score = 0;  //总成绩
                          string scoreStr = "";  //成绩详细信息
                          if (int.Parse(row["DxtScore"].ToString()) >= 0)
                          {
                              scoreStr += "单选题：" + row["DxtScore"] + " ";
                              score += int.Parse(row["DxtScore"].ToString());
                          }
                          if (int.Parse(row["DuoxtScore"].ToString()) >= 0)
                          {
                              scoreStr += "多选题：" + row["DuoxtScore"] + " ";
                              score += int.Parse(row["DuoxtScore"].ToString());
                          }
                          if (int.Parse(row["PdtScore"].ToString()) >= 0)
                          {
                              scoreStr += "判断题：" + row["PdtScore"] + " ";
                              score += int.Parse(row["PdtScore"].ToString());
                          }
                          if (int.Parse(row["ZgtScore"].ToString()) >= 0)
                          {
                              scoreStr += "简答题：" + row["ZgtScore"] + " ";
                              score += int.Parse(row["ZgtScore"].ToString());
                          }
                          %>
                    <tr>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=row["XsName"] %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=row["SjName"] %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=row["ZyName"] %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=row["KmName"] %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=scoreStr %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><%=score %>分</div></td>
                  </tr>
                    <% } 
                       }%>
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
                    <%if(maxPage>0){ %>
                  <tr>
                    <td class="STYLE1" width="25%" height="29" nowrap="nowrap">共<%=count %>条纪录
                        ，当前第<span id="spannowpage" runat="server"><%=page %></span>/<span id="spanpages" runat="server"><%=maxPage %></span>页，每页<span id="lenid" runat="server"><%=len %></span>条纪录
                    </td>
                    <td width="75%" valign="top"><div align="right">
                      <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="62" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton1" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" runat="server" OnClick="FirstPage_Click" /></div></td>
                          <td width="50" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton2" ImageUrl="../../html/tab/images/back.gif" width="43" height="15" runat="server" OnClientClick="return BackPage()" OnClick="BackPage_Click"/></div></td>
                          <td width="54" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton3" ImageUrl="../../html/tab/images/next.gif" width="43" height="15" runat="server" OnClientClick="return NextPage()" OnClick="NextPage_Click"/></div></td>
                          <td width="49" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton4" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" runat="server" OnClick="LastPage_Click"/></div></td>
                          <td class="STYLE1" width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                          <td width="25" height="22" valign="middle"><span>
                            <input name="textfield" type="text" id="tzpage" class="STYLE1" runat="server" style="height:10px; width:25px; line-height:10px" size="5" />
                          </span></td>
                          <td class="STYLE1" width="23" height="22" valign="middle">页</td>
                          <td width="30" height="22" valign="middle"><asp:ImageButton ImageUrl="../../html/tab/images/go.gif" width="37" runat="server" OnClientClick="return JumpPage()" ID="BtnJumppage" height="15" href="#" OnClick="BtnJumppage_Click" /></td>
                        </tr>
                      </table>
                    </div></td>
                  </tr>
                    <%}else{%>
                      <tr><td colspan="2">共<%=count %>条纪录</td></tr>
                      <%} %>
                </table></td>
                <td width="14"><img src="../../html/tab/images/tab_22.gif" width="14" height="29" /></td>
              </tr>
            </table></td>
          </tr>
        </table>
   </div>
<div id="divChart" style="display:none; position:absolute; z-index:10000; background-color:white; text-align:center;">
    <div id="btnClose" style="width:14px;height:14px;float:right;"><img src="../../images/close.gif" /></div>
        <cc1:Chartlet ID="Chartlet1" runat="server" Dimension="Chart3D" Height="400px" />

  <%
      if (scoreList.Rows.Count > 0)
      {
          ScriptManager.RegisterStartupScript(Page, typeof(string), "", "blockBtn()", true);
      }
      else
          ScriptManager.RegisterStartupScript(Page, typeof(string), "", "noneBtn()", true); 
      %> </div>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnsx" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="ddlSpec" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="btnSubject" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
    
</form>
</body>
</html>
