<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSubject.aspx.cs" Inherits="admin_Subject_EditSubject" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  
    <title></title>
    <link href="../../css/style.css" rel="Stylesheet"/>

<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    font-size:12px;
}
.STYLE4 {
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
-->
</style> <script type="text/javascript">
     function Show(num)
     {
        var s = document.getElementById("edit");
        if (num == 0) {
            s.innerHTML = "新增科目信息";
            $("#ZyName").val(0);
        }
        else {
            s.innerHTML = "修改科目信息";
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=getSubject&KmID=" + num,
                success: function (msg) {
                    var ms = msg.split(",");
                    $("#HiddenKmID").val(ms[0]);
                    $("#KmName").val(ms[1]);
                    $("#ZyName").val(ms[2]);
                    $("#Remark").val(ms[3]);
                }
            });
        }
        document.getElementById("addSubject").style.display = "block";
    }
     function GuanBi() {
         document.getElementById("addSubject").style.display = "none";
     }
     /*按下取消按钮时清空数据*/
     function CloseEmpty() {
         $("#KmName").val("");/*科目名称*/
         $("#ZyName").val("");/*专业名*/
         $("#spusername").text("");
         $("#spanzy").text("");
         $("#Remark").val("");/*备注*/
         $("#ZyName").val("");
         $("#spusername").text("");
         return false;
     }
     $(document).ready(function () {
                 var num = 0;
                 $("#KmName").change(function () {
                     $.ajax({
                         type: "post",
                         url: "../../ajax.aspx",
                         dataType: "string",
                         data: { 'action': 'editSubjectID', 'KmID': $("#HiddenKmID").val(), 'KmName': $("#KmName").val(), 'ZyName': $("#ZyName").val() },
                         success: function (msg) {
                             if (msg == "已存在") {
                                 $("#spusername").text(msg);
                                 num = 1;
                             }
                             else {
                                 $("#spusername").text("");
                                 num = 2;
                             }
                         }
                     });
                 });
                 $("#ZyName").change(function () {
                     $.ajax({
                         type: "post",
                         url: "../../ajax.aspx",
                         dataType: "string",
                         data: {'action':'editSubjectID','KmID':$("#HiddenKmID").val(),'KmName':$("#KmName").val(), 'ZyName':$("#ZyName").val()},
                         success: function (msg) {
                             if (msg == "已存在") {
                                 $("#spusername").text(msg);
                                 num = 1;
                             }
                             else {
                                 $("#spusername").text("");
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
                 $("#ButtonOK").click(function () {
                     if (num == 1) { $("#spusername").text("已存在"); return false; }
                     else return true;
                 });
     });
     function SelectByName() {
         $.ajax({
             type: "post",
             url: "EditSubject.aspx",
             dataType: "string",
             data: "",
             success: function (msg) {
                 $("#btnsx").click();
             }
         });
     }
</script>
</head>
<body>
    <form  id="formspeciality" runat="server">
        <asp:HiddenField ID="HiddenKmID" runat="server" />
    <div style="position:absolute">
        <input type="hidden" id="hidIsSubmit" />
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Button ID="btnsx" style="display:none;" runat="server" Text="隐藏刷新按钮" OnClick="btnsx_Click" />
<div style="margin-left:30px; margin-top:5px;">筛选条件：<input id="txtSpecName" type="text" runat="server" onpropertychange="SelectByName()" class="text-input" style="height:15px;width:200px; line-height:15px;" /></div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
        <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" /> <span class="STYLE4">科目信息管理</span></td>
        <td width="281" background="../../html/tab/images/tab_05.gif"><table border="0" align="right" cellpadding="0" cellspacing="0">
            <tr>
              <td width="60"><table width="90%" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td class="STYLE1"><div align="center"><img src="../../html/tab/images/001.gif" width="14" height="14" /></div></td>
                    <td class="STYLE1"><div align="center"><a href="#" id="addSubjectA" onclick="Show(0)">新增</a></div></td>
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
        <td bgcolor="#f3ffe3"><table width="99%" border="0" id="tablepage" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()"  onmouseout="changeback()">
          <tr>
            <td width="8%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">科目</div></td>
               <td width="8%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">专业 </div></td>
               <td width="8%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">备注</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">修改</div></td>
            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">删除</div></td>
          </tr>
            <%
                int i = 0;
                foreach (DataRow subRow in subjectList.Rows)
                {
                    i++;%>
          <tr>
            <td height="18" bgcolor="#FFFFFF" class="auto-style2"><div align="center" class="STYLE2 STYLE1"><%=subRow["KmName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF" class="auto-style6"><div align="center" class="STYLE2 STYLE1"><%=subRow["ZyName"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=subRow["Remark"].ToString() %></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/037.gif" width="9" height="9" /></span><span class="STYLE1"> [</span><a href="#" id="a<%=i %>" onclick="Show(<%=subRow["KmID"].ToString() %>)">修改</a><span class="STYLE1">]</span></div></td>
            <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/010.gif" width="9" height="9" /></span><span class="STYLE2"> </span><span class="STYLE1">[</span><a href="?Sub_Sc=<% =subRow["KmID"].ToString()%>">删除</a><span class="STYLE1">]</span></div></td>          </tr><%} %>
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
            <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=Count %>条纪录，当前第<span id="spannowpage" runat="server"><%=apge %></span>/<span id="spanpages" runat="server"><%=Maxapge %></span>页，每页<%=len %>条纪录</span></td>
            <td width="75%" valign="top" class="STYLE1"><div align="right">
              <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="62" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageFirst" runat="server" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" OnClick="ImageFirst_Click" /></div></td>
                  <td width="50" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageBack" runat="server" ImageUrl="../../html/tab/images/back.gif" width="43" height="15" OnClientClick="return BackPage()" OnClick="ImageBack_Click" /></div></td>
                  <td width="54" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageNext" runat="server" ImageUrl="../../html/tab/images/next.gif" width="43" height="15" OnClientClick="return NextPage()" OnClick="ImageNext_Click" /></div></td>
                  <td width="49" height="22" valign="middle"><div align="right">
                      <asp:ImageButton ID="ImageLast" runat="server" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" OnClick="ImageLast_Click" /></div></td>
                  <td width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                  <td width="25" height="22" valign="middle"><span class="STYLE7">
                      <asp:TextBox ID="tzpage" name="textfield" runat="server" class="STYLE1" style="height:10px; width:25px; line-height:10px" size="5"></asp:TextBox>
                  </span></td>
                  <td width="23" height="22" valign="middle">页</td>
                  <td width="30" height="22" valign="middle">
                      <asp:ImageButton ID="ImageGo" runat="server" ImageUrl="../../html/tab/images/go.gif" width="37" height="15"  OnClientClick="return JumpPage()"  OnClick="ImageGo_Click" /></td>
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
</div>
    <div id="addSubject" class="STYLE1" style=" position:absolute; width:320px; border:1px solid gray; background-color:#d2efac;text-align:center; display:none">
        <h3 id="edit">新增科目信息</h3>
        <center><table cellpadding="0" width="320">
            <tr>
                <td style="width:90px;text-align:right">科目名称：</td>
                <td style="width:160px;text-align:left"><asp:TextBox ID="KmName" name="KmName" MaxLength="15"  CssClass="text-input" runat="server" Width="160px"></asp:TextBox></td>
                <td style="text-align:left"><span id="spusername" class="red"></span> </td>
            </tr>
             <tr>
                <td  style="width:90px;text-align:right">所属专业：</td>
                <td style="width:160px;text-align:left"><asp:DropDownList ID="ZyName" runat="server" CssClass="text-input"  Width="174px"></asp:DropDownList></td>
                <td style="text-align:left"><span id="spanzy" class="red"></span></td>
            </tr>
            <tr>
                <td  style="width:90px;text-align:right">备 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td> 
                <td  style="width:160px;text-align:left"><asp:TextBox ID="Remark" name="Remark" runat="server" MaxLength="50" TextMode="MultiLine" Wrap="true"  CssClass="text-input"  Height="60px" style="margin-left:0px; overflow:hidden"  Width="160px"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="height:50px;line-height:50px;">
                    <asp:Button ID="ButtonOK"  runat="server" text="确  定" CssClass="button" OnClientClick="return CheckSubject()" OnClick="ButtonOK_Click" />
                    <asp:HiddenField id="HiddenField1" runat="server"  />
                     &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp
                    <asp:Button ID="btnClose" runat="server" Text="取  消" CssClass="button" OnClientClick="return CloseEmpty()" /></td>
            </tr>
        </table></center>
    </div>
<script type="text/javascript">
    AlterDivAndClose("addSubject", "addSubjectA", "btnClose");
    var count =<%=subjectList.Rows.Count %> +"";
    for (var i = 1; i <= count; i++)
        AlterDivAndClose("addSubject", "a" + i, "btnClose");
</script>
</form>
</body>
</html>
