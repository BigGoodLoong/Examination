<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTestPaper.aspx.cs" Inherits="admin_TestPaper_EditTestPaper" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看试卷</title>
<link href="../../css/style.css" rel="Stylesheet"/>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE1 {font-size: 12px}
    .STYLES {
        text-align:right;
        color:red;
    }
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
  .editdiv {
     background:#d0eea9; 
     border:1px solid gray;
     width:430px;
     text-align:center;
     height:300px;
      }
   
    .auto-style4 {
        font-size: 12px;
        width: 18%;
    }
    .auto-style5 {
        width: 18%;
    }
    .auto-style6 {
        font-size: 12px;
        width: 14%;
    }
    .auto-style7 {
        width: 14%;
    }
    .auto-style12 {
        font-size: 12px;
        width: 10%;
    }
    .auto-style13 {
        width: 10%;
    }
    .auto-style14 {
        font-size: 12px;
        width: 23%;
    }
    .auto-style15 {
        width: 23%;
    }
    .auto-style16 {
        font-size: 12px;
        width: 7%;
    }
    .auto-style17 {
        width: 7%;
    }
-->
</style>
<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
      <script type="text/javascript">
          $(document).ready(function () {
          });
          function ShowEditDiv() {
              document.getElementById("editid").style.display = "block";
          }
    </script>
<script type="text/javascript" >
    $(document).ready(function () {
        $("#sjnameid").change(function () {
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=EditTestPaperName&SjName=" + $("#sjnameid").val() + "&SjID=" + $("#hidSjID").val(),
                success: function (msg) {
                    if (msg == "已存在") {
                        $("#spansjname").text(msg);
                        num = 1;
                    }
                    else {
                        $("#spansjname").text("");
                        num = 2;
                    }
                }
            });
        });
        $("#txtTestPaperName").val("按试卷名、科目名模糊查找");
        $("#txtTestPaperName").css("color", "#CCC");
        $("#txtTestPaperName").focus(function () {
            var txt = $(this).val();
            if (txt.trim() == "按试卷名、科目名模糊查找") {
                $(this).val("");
                $("#txtTestPaperName").css("color", "#000");
            }
        });

        $("#txtTestPaperName").blur(function () {
            var txt = $(this).val();
            if (txt.trim() == "") {
                $("#txtTestPaperName").css("color", "#CCC");
                $(this).val("按试卷名、科目名模糊查找");
            }
        });
    });

    $("#ButtonOK").click(function () {
        if (num == 1) { $("#spansjname").text("已存在"); return false; }
        else { return true; }
    });
    function testPaperName() {
        $.ajax({
            type: "post",
            url: "EditTestPaper.aspx",
            dataType: "string",
            data: "",
            success: function () {
                $("#btntp").click();
            }
        });
    }

    function ShowEditDiv(num)/*显示修改div*/
    {
        document.getElementById("editid").style.display = "block";
        $.ajax({
            type: "post",
            url: "../../ajax.aspx",
            dataType: "string",
            data: "action=getEditTestPaper&sjid=" + num,
            success: function (msg) {
                var ms = msg.split("|");
                $("#hidSjID").val(ms[0]);
                $("#sjnameid").val(ms[1]);
                $("#startTime").val(ms[2]);
                $("#endTime").val(ms[3]);
                $("#textRemark").val(ms[4]);
            }
        });
    }
    /*按下取消按钮时清空数据*/
    function CloseEmpty() {
        $("#sjnameid").val("");/*考试名称*/
        $("#startTime").val("");/*开始时间*/
        $("#endTime").val("");/*结束时间*/
        $("#textRemark").val("");/*备注*/
        return false;
    }
  
</script>
</head>
<body size="12"> 
    <form id="sjform" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Button ID="btntp" style="display:none;" runat="server" Text="隐藏刷新按钮" OnClick="btntp_Click" />
<div style="margin-left:30px; margin-top:5px;" class="STYLE1">筛选条件：<input id="txtTestPaperName" type="text" runat="server" onpropertychange="testPaperName()" class="text-input" style="height:15px;width:200px; line-height:15px;" /></div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="position:absolute">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
        <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" /> <span class="STYLE4">试卷列表信息</span></td>
        <td width="281" background="../../html/tab/images/tab_05.gif"></td>
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
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style14"><div align="center" class="STYLE2 STYLE1">试卷名称</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style4"><div align="center" class="STYLE2 STYLE1">所属科目</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style12"><div align="center" class="STYLE2 STYLE1">出题人</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style6"><div align="center" class="STYLE2">开始时间</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style6"><div align="center" class="STYLE2">结束时间</div></td>
            <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style16"><div align="center" class="STYLE2 STYLE1">标准答案</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">修改</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">删除</div></td>
          </tr>
            <%
                int i=0;
                foreach (DataRow row in testPaperList.Rows)
              {
                    i++;%>
             <tr>
            <td height="18" bgcolor="#FFFFFF" class="auto-style15"><div align="center" class="STYLE2 STYLE1"><%=row["SjName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style5"><div align="center" class="STYLE2 STYLE1"><%=row["KmName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style13"><div align="center" class="STYLE2 STYLE1"><%=row["LsName"].ToString() %> </div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style7"><div align="center" class="STYLE2 STYLE1"><%=row["KsTime"].ToString() %></div></td>
                 <td height="18" bgcolor="#FFFFFF" class="auto-style7"><div align="center" class="STYLE2 STYLE1" ><%=row["JsTime"].ToString() %></div></td>
                 <%
                  string zt = row["Zt"].ToString();
                  if(zt=="1"){ %>
                 <td height="18" bgcolor="#FFFFFF" class="auto-style17"><div align="center" class="STYLE2 STYLE1" ><a href="../AnswerCard/AnswerCard.aspx?sjid=<%=row["SjID"].ToString() %>&User=1">添加</a></div></td>
                 <%}else{ %>
                  <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1" ><a href="../AnswerCard/AnswerCard.aspx?sjid=<%=row["SjID"].ToString() %>&User=1" title="修改答案">修改</div></td>
                 <%} %>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><img src="../../html/tab/images/037.gif" width="9" height="9" /><span class="STYLE1"> [</span><a href="#" id="a<%=i %>" title="修改试卷信息" onclick="ShowEditDiv(<%=row["SjID"] %>)">修改</a><span class="STYLE1">]</span></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/010.gif" width="9" height="9" /> </span><span class="STYLE1">[</span><a href="?action=delete&sjid=<%=row["SjID"] %>">删除</a><span class="STYLE1">]</span></div></td>
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
             <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=Count %>条纪录，当前第<span id="spannowpage" runat="server"><%=page %></span>/<span id="spanpages" runat="server"><%=Maxpage %></span>页，每页<%=len %>条纪录</span></td>
            <td width="75%" valign="top" class="STYLE1"><div align="right">
              <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="62" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageFrist" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" runat="server" OnClick="ImageFrist_Click" />
                      </div></td>
                  <td width="50" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageBack" ImageUrl="../../html/tab/images/back.gif" width="43" height="15" runat="server" OnClientClick="return BackPage()" OnClick="ImageBack_Click" />
                      </div></td>
                  <td width="54" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageNext" ImageUrl="../../html/tab/images/next.gif" width="43" height="15" runat="server" OnClientClick="return NextPage()"  OnClick="ImageNext_Click" />
                      </div></td>
                  <td width="49" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageLast" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" runat="server" OnClick="ImageLast_Click" />
                      </div></td>
                  <td width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                  <td width="25" height="22" valign="middle"><span class="STYLE7">



                    <asp:TextBox ID="tzpage" name="textfield"  class="STYLE1" style="height:10px; width:25px;" size="5" MaxLength="8" runat="server"></asp:TextBox>

                  </span></td>
                  <td width="23" height="22" valign="middle">页</td>
                  <td width="30" height="22" valign="middle">
                      <asp:ImageButton ID="ImageGo" ImageUrl="../../html/tab/images/go.gif" width="37" height="15"  runat="server" OnClientClick="return JumpPage()" OnClick="ImageGo_Click" />
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
    <asp:AsyncPostBackTrigger ControlID="btntp" EventName="Click" />
</Triggers>
</asp:UpdatePanel> 
   
<div id="editid" class="editdiv" style="border:1px solid gray;width:320px; height:320px;text-align:center;position:absolute;background-color:#d2efac;font-size:12px">
        <h3 style="text-align:center">修改考试信息</h3>
       <table id="edittb" width="310px" cellpadding="0">
           <tr>
               <td style="text-align:right;width:90px">试卷名称：</td>
               <td style="width:160px;text-align:left"><asp:TextBox id="sjnameid" runat="server" CssClass="text-input" style="width:160px; " ></asp:TextBox></td>
               <td style="text-align:left"><span id="spansjname" style="color:red"></span></td>
               </tr>
           <tr>
               <td style="text-align:right;width:90px">开放时间：</td>
               <td style="width:180px;text-align:left">
                   <asp:TextBox  runat="server" class="sang_Calender" style="width:160px; border-radius: 16px; -moz-border-radius: 16px; -webkit-border-radius: 16px;padding: 6px; font-size: 13px; border: 1px solid #d5d5d5;color: #333;" id="startTime" name="startTime"></asp:TextBox></td>
               <td style="text-align:left"><span id="spanstart" style="color:red"></span><asp:Label ID="stime" runat="server" style="color:red"></asp:Label></td>
           </tr>
             <tr>
               <td style="text-align:right;width:90px">结束时间：</td>
               <td style="width:180px;text-align:left">
                   <asp:TextBox  runat="server" class="sang_Calender" style=" width:160px; border-radius: 16px; -moz-border-radius: 16px; -webkit-border-radius: 16px;padding: 6px; font-size: 13px; border: 1px solid #d5d5d5;color: #333;" id="endTime" name="endTime" ></asp:TextBox></td>
               <td style="text-align:left"><span id="spanend" style="color:red"></span></td>
           </tr>
           <tr>
               <td></td>
               <td colspan="3"><asp:Label ID="Lbltime" name="Lbltime" runat="server"  CssClass="STYLES"></asp:Label></td>
           </tr>
           <tr>
               <td style="text-align:right;width:90px">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
               <td style="width:130px;text-align:left" ><asp:TextBox ID="textRemark" name="textRemark" CssClass="text-input" style="overflow:hidden; width:160px;" TextMode="MultiLine" Wrap="true" runat="server" Height="80px"></asp:TextBox></td>
               <td></td>
           </tr>
            <tr>
               <td colspan="3" align="center" ><br /><asp:Button ID="ButtonOK"  runat="server" class="button" Text="确  定" OnClientClick="return CheckTestPaperInfo()" OnClick="ButtonOK_Click" />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input type="hidden" id="hidSjID"  runat="server"/>
                   <asp:Button ID="btnClose"  class="button" runat="server" Text="关  闭" OnClientClick="return CloseEmpty()"/></td>
           </tr>
       </table>
   </div>

<script type="text/javascript" src="../../javascript/calendar.js"></script>
<script type="text/javascript">
    AlterDivAndClose("editid", "editidA", "btnClose");
    var count =<%=testPaperList.Rows.Count %> +"";
    for (var i = 1; i <= count; i++)
        AlterDivAndClose("editid", "a" + i, "btnClose");
</script>     
</form>
</body>
</html>
