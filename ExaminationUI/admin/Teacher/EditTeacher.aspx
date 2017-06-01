<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTeacher.aspx.cs" Inherits="admin_Teacher_EditTeacher" %>
<%@ Import Namespace="System.Data" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
    
<link href="../../css/style.css" rel="Stylesheet"/>
<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/tablelist.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
<script type="text/javascript" src="../../javascript/DivScript.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
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

         .auto-style1 {
             width:80px;     
             text-align:right;        
         }
         .red {
         color:red;
         }
    .editdiv {
    width:320px;
    display:none;
    background-color:#d0eea9;
    border:1px solid gray;
    text-align:center;
    position:absolute;
    }
        .editdiv .lefttd {
        width:80px;
        text-align:right;
        }
        .editdiv .centertd {
        width:160px;
        text-align:left;
        }
           
        .editdiv .righttd {
        text-align:left;
        }
-->
</style>
 
<script type="text/javascript">
    /*点击新增时发生--显示新增页面*/
    function Show(num) {
        var s = document.getElementById("edit");
        if (num == 0) {
            s.innerHTML = "新增教师信息";
            $("#teachername").val("");
            $("#teacheruser").val("");
            $("#teacherpwd").val("");
            $("#textRemark").val("");
            $("#teacherzy").val(0);
            document.getElementById("teacheruser").disabled =false;
            document.getElementById("teacherpwd").disabled = false;
        }
       else {
            s.innerHTML = "修改教师信息";
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=getTeacher&YhID=" + num,
                success: function (msg) {
                    var ms = msg.split("|");
                    $("#hidTeacherID").val(ms[0]);
                    $("#teachername").val(ms[1]);
                    $("#teacheruser").val(ms[2]);
                    $("#teacherpwd").val(ms[3]);
                    $("#userrole").val(ms[4]);
                    $("#teacherzy").val(ms[5]);
                    $("#textRemark").val(ms[6]);
                    document.getElementById("teacheruser").disabled = true;
                    document.getElementById("teacherpwd").disabled = true;
                }
            });
        }
    }

    /*按下取消按钮时清空数据*/
    function CloseEmpty()
    {
        $("#teacheruser").val("");/*账号*/
        $("#spanzh").text("");
        $("#teachername").val("");/*姓名*/
        $("#spanxm").text("");
        $("#teacherpwd").val("");/*密码*/
        $("#spanmm").text("");
        $("#userrole").val(1);/*角色*/
        $("#teacherzy").val("");/*专业*/
        $("#spanzy").text("");
        $("#textRemark").val("");/*备注*/
        return false;
    }
    $(document).ready(function () {
        var num = 0;
        $("#teacheruser").change(function () {
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: { 'action': 'editTeacher', 'YhName': $.trim($("#teacheruser").val()) ,'&YhID':  $("#hidTeacherID").val() },
                success: function (msg) {
                    if (msg == "已存在") {
                        $("#spanzh").text(msg);
                        num = 1;
                    }
                    else {
                        $("#spanzh").text("");
                        num = 2;
                    }
                }
            })
        });
     
            $("#ButtonOK").click(function () {
                if (num == 1) { $("#spanzh").text("已存在"); return false; }
                else return true;
            });
            $("#txtTeacherName").val("按教师名、用户名、专业名模糊查找");
            $("#txtTeacherName").css("color", "#CCC");
            $("#txtTeacherName").focus(function () {
                var txt = $(this).val();
                if (txt.trim() == "按教师名、用户名、专业名模糊查找") {
                    $(this).val("");
                    $("#txtTeacherName").css("color", "#000");
                }
            });
            $("#txtTeacherName").blur(function () {
                var txt = $(this).val();
                if (txt.trim() == "") {
                    $("#txtTeacherName").css("color", "#CCC");
                    $(this).val("按教师名、用户名、专业名模糊查找");
                }
            });
    });
   
    function SelectByName() {
        $.ajax({
            type: "post",
            url: "EditTeacher.aspx",
            dataType: "string",
            data: "",
            success: function (msg) {
                $("#btnsx").click();
            }
        });
    }
   
    </script>
</head>
<body style="font-size:12px">
<form id="Form1" name="form1" runat="server">
    <asp:HiddenField ID="HiddenYhID" runat="server" />
        <input type="hidden" id="hidIsSubmit" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Button ID="btnsx" Style="display: none;" runat="server" Text="隐藏刷新按钮" OnClick="Select_Click"  />
        <div style="margin-left: 30px; margin-top: 5px;">筛选条件：<input id="txtTeacherName" type="text" runat="server" onpropertychange="SelectByName()" class="text-input" style="height: 15px; width: 250px; line-height: 15px;" /></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
<div style="position:absolute;">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" >
     <tr>
          <td height="30">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                 <tr>
                    <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
                    <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" width="16" height="16" /> <span class="STYLE4">教师信息列表</span></td>
                    <td width="281" background="../../html/tab/images/tab_05.gif">
                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                             <tr>
                                <td width="60">
                                   <table width="90%" border="0" cellpadding="0" cellspacing="0" style="height: 14px">
                                       <tr>
                                          <td class="STYLE1"><div align="center"><img src="../../html/tab/images/001.gif" width="14" height="14" /></div></td>
                                          <td class="STYLE1"><div align="center"><a href="#" id="addTeacherA" onclick="Show(0)">新增</a> </div></td>
                                       </tr>
                                   </table></td>
                             </tr>
                       </table>
                    </td>
                    <td width="14"><img src="../../html/tab/images/tab_07.gif" width="14" height="30" /></td>
                </tr>
            </table>
          </td>
     </tr>
     <tr>
        <td>
           <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                 <td width="9" background="../../html/tab/images/tab_12.gif">&nbsp;</td>
                 <td bgcolor="#f3ffe3">
                     <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()"  onmouseout="changeback()" id="tablepage">
                        <tr>
                            <td width="8%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">姓名</div></td>
                            <td width="15%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">账号</div></td>
                            <td width="10%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">专业</div></td>
                            <td width="14%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2 STYLE1">备注</div></td>
                            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">修改</div></td>
                            <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1"><div align="center" class="STYLE2">删除</div></td>
                        </tr>
                       <% if(TeacherList!=null)
                        {
                            int i = 0;
                            foreach (DataRow row in TeacherList.Rows)
                            {
                              i++;%>
                      <tr>
                         <td height="18" bgcolor="#FFFFFF" class="STYLE2"><div align="center" class="STYLE2 STYLE1"><%=row["LsName"].ToString() %></div></td>
                         <td height="18" bgcolor="#FFFFFF"><div  align="center" class="STYLE2 STYLE1"><%=row["YhName"].ToString() %></div></td>
                         <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=row["ZyName"].ToString() %></div></td>
                         <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=row["Remark"].ToString() %></div></td>
                         <td height="18" bgcolor="#FFFFFF"><div align="center"><img src="../../html/tab/images/037.gif" width="9" height="9" /><span class="STYLE1"> [</span><a id="a<%=i %>" href="#"  onclick="Show(<%=row["YhID"].ToString() %>)">修改</a><span class="STYLE1">]</span></div></td>
                         <td height="18" bgcolor="#FFFFFF"><div align="center"><img src="../../html/tab/images/010.gif" width="9" height="9" /><span class="STYLE1">[</span><a href="?LsID=<%=row["LsID"].ToString() %>">删除</a><span class="STYLE1">]</span></div></td>
                      </tr>
                         <% }
                        } %>
                    </table>
                 </td>
                 <td width="9" background="../../html/tab/images/tab_16.gif">&nbsp;</td>
             </tr>
         </table>
        </td>
     </tr>
     <tr>
        <td height="29">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15" height="29"><img src="../../html/tab/images/tab_20.gif" width="15" height="29" /></td>
                <td background="../../html/tab/images/tab_21.gif">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                       <tr>
                          <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=Record%>条记录，当前第<span id="spannowpage" runat="server"><%=nowPage %></span>/<span id="spanpages" runat="server"><%=Pages %></span>页，每页<span id="lenid" runat="server"><%=len %></span>条记录</td>
                          <td width="75%" valign="top" class="STYLE1"><div align="right">
                              <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                    <td width="62" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton1" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" runat="server" OnClick="FirstPage_Click" /></div></td>
                                    <td width="50" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton2" ImageUrl="../../html/tab/images/back.gif" width="43" height="15" runat="server" OnClientClick="return BackPage()" OnClick="BackPage_Click"/></div></td>
                                    <td width="54" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton3" ImageUrl="../../html/tab/images/next.gif" width="43" height="15" runat="server" OnClientClick="return NextPage()" OnClick="NextPage_Click"/></div></td>
                                    <td width="49" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton4" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" runat="server" OnClick="LastPage_Click"/></div></td>
                                    <td width="59" height="22" valign="middle"><div align="right">转到第&nbsp; </div></td>
                                    <td width="25" height="22" valign="middle"><span class="STYLE7">
                                        <input name="textfield" type="text" id="tzpage" class="STYLE1" runat="server" style="height:10px;line-height:10px; width:25px;" size="5" /></span></td>
                                    <td width="23" height="22" valign="middle">页</td>
                                    <td width="30" height="22" valign="middle"><asp:ImageButton ImageUrl="../../html/tab/images/go.gif" runat="server" width="37" OnClientClick="return JumpPage()" height="15" OnClick="JumpPage_Click" ID="ButtonJump" /></td>
                                  </tr>
                               </table></div>
                          </td>
                        </tr>
                    </table>
                </td>
                <td width="14"><img src="../../html/tab/images/tab_22.gif" width="14" height="29" /></td>
             </tr>
         </table>
        </td>
    </tr>
</table>
</div>  
    </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnsx" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
 <div id="addTeacher" name="addTeacher" class="editdiv">
       <h3 style="margin-top:20px;margin-bottom:10px;" id="edit">新增教师信息</h3>
       <center> <table width="320px" cellpadding="0" class="STYLE1">
            <tr>
                <td class="lefttd">账&nbsp;&nbsp;号：</td>
                <td class="centertd"><asp:TextBox ID="teacheruser" name="user" runat="server" MaxLength="15" style="width:160px;" CssClass="text-input"></asp:TextBox></td>
                <td class="righttd"><span class="red" id="spanzh"></span></td>
            </tr>
            <tr>
                <td class="lefttd">姓&nbsp;&nbsp;名：</td>
                <td class="centertd"><asp:TextBox ID="teachername" name="name" MaxLength="10" runat="server" CssClass="text-input" style="width:160px"  ></asp:TextBox></td>
                <td class="righttd"><span class="red" id="spanxm"></span></td>
            </tr>
            <tr>
                <td class="lefttd">密&nbsp;&nbsp;码：</td>
                <td class="centertd"><asp:TextBox ID="teacherpwd" TextMode="Password" MaxLength="50" CssClass="text-input" name="textTeacher" style="width:160px" runat="server" ></asp:TextBox></td>
                <td class="righttd"><span class="red" id="spanmm"></span></td>
            </tr>
            <tr>
               <td class="lefttd">角&nbsp;&nbsp;色：</td>
               <td class="centertd"><asp:DropDownList ID="userrole" CssClass="text-input" style="width:170px" runat="server">
                   <asp:ListItem Value="2">教师</asp:ListItem>
                   <asp:ListItem Value="1">管理员</asp:ListItem>
                                    </asp:DropDownList></td>
               <td class="righttd"><span class="red" id="span2"></span></td>
           </tr>
            <tr>
                <td class="lefttd">专&nbsp;&nbsp;业：</td>
                <td class="centertd"><asp:DropDownList ID="teacherzy" name="ddlID" CssClass="text-input" style="width:170px" runat="server">
                    </asp:DropDownList></td>
               <td class="righttd"><span class="red" id="spanzy"></span></td>
            </tr>
            <tr>
                <td class="lefttd">备&nbsp;&nbsp;注：</td>
                <td style="text-align:right;"><asp:TextBox  style="height:60px;overflow:hidden;" ID="textRemark" MaxLength="50" TextMode="MultiLine" wrap="true"  runat="server"></asp:TextBox></td>
                <td class="righttd"><span class="red" id="span1"></span></td>
             </tr>
            <tr>
                <td colspan="3" align="center" style="height:50px;line-height:50px"><asp:Button ID="ButtonOK"  CssClass="button" name="ButtonOK" Text="确  定" runat="server" OnClientClick="return CheckTeacher()" OnClick="ButtonOK_Click" />
                 &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <input type="hidden" id="hidTeacherID" runat="server" />  &nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="btnClose" name="ButtonNO" Text="取  消"  CssClass="button" runat="server" OnClientClick="return CloseEmpty()" /><br /></td>
            </tr>
        </table>
        </center>
    </div>
<script type="text/javascript">
    AlterDivAndClose("addTeacher", "addTeacherA", "btnClose");
    var count =<%=TeacherList.Rows.Count %> +"";
    for (var i = 1; i <= count; i++) 
        AlterDivAndClose("addTeacher", "a" + i, "btnClose");
</script>
</form>
</body>
</html>
