<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditClass.aspx.cs" Inherits="admin_Class_EditClass" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="../../css/style.css" rel="Stylesheet"/>
<style type="text/css">

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
td{
    text-align:left;
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

        .style1
        {
            font-size: 12px;
            height: 18px;
        }
        /*当班级名为空时*颜色设为红色*/
          .red {
         color:red;
         }

-->
</style>
    <script type="text/javascript" src="../../javascript/YanZheng.js"></script>
    <script type="text/javascript" src="../../javascript/tablelist.js"></script>
    <script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../../javascript/DivScript.js"></script>
<script type="text/jscript">
    //显示和隐藏（新增/修改）
    function Show(num) {
        var s = document.getElementById("edit");
        if (num == 0) {
            s.innerHTML = "新增班级信息";
            $("#textZy").val(0);
        }
        else {
            s.innerHTML = "修改班级信息";
            $.ajax({
                type: "post",
                url: "../../ajax.aspx",
                dataType: "string",
                data: "action=getClass&BjID=" + num,
                success: function (msg) {
                    var ms = msg.split("|");
                    $("#hidClassID").val(ms[0]);
                    $("#textName").val(ms[1]);
                    $("#textNj").val(ms[2]);
                    $("#textZy").val(ms[3]);
                }
            });
        }

        document.getElementById("addClass").style.display = "block";

    }
    function Close() {
        document.getElementById("addClass").style.display = "none";
    }
    /*按下取消按钮时清空数据*/
    function CloseEmpty() {
        $("#textName").val("");/*班级名*/
        $("#spanclassname").text("");
        $("#textNj").val("");/*年级*/
        $("#spannj").text("");
        $("#textZy").val("");/*专业*/
        $("#spanzy").text("");
        return false;
    }
    function bg() {
        document.getElementById("bgColor").style.backgroundColor = "#48d8fb";
    }
    $(document).ready(function () {
        var num = 0;
        var Number = 0;
        $("#textNj").change(function () {
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=EditClass&textName=" + $("#textName").val() + "&textNj=" + $("#textNj").val() + "&BjID=" + $("#hidClassID").val(),
                    success: function (ClassMessage) {
                        if (ClassMessage == "已存在") {
                            $("#spanclassname").text(ClassMessage);
                            num = 1;
                        }
                        else {
                            $("#spanclassname").text("");
                            num = 2;
                        }
                    }
                });
            });
        $("#textName").change(function () {
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=EditClass&textName=" + $("#textName").val() + "&textNj=" + $("#textNj").val() + "&BjID=" + $("#hidClassID").val(),
                    success: function (ClassMessage) {
                        if (ClassMessage == "已存在") {
                            $("#spanclassname").text(ClassMessage);
                            Number = 1;
                        }
                        else {
                            $("#spanclassname").text("");
                            Number = 2;
                        }
                    }
                });
            });
        $("#txtClassName").val("按班级名、年级或专业名模糊查找");
        $("#txtClassName").css("color", "#CCC");
        $("#txtClassName").focus(function () {
            var txt = $(this).val();
            if (txt.trim() == "按班级名、年级或专业名模糊查找") {
                $(this).val("");
                $("#txtClassName").css("color", "#000");
            }
        });
        $("#txtClassName").blur(function () {
            var txt = $(this).val();
            if (txt.trim() == "") {
                $("#txtClassName").css("color", "#CCC");
                $(this).val("按班级名、年级或专业名模糊查找");
            }
        });
        $("#ButtonOK").click(function () {
            if (num == 1 || Number == 1) { $("#spanclassname").text("已存在"); return false; }
            else return true;
        });
    });
    function SelectClassByName() {
        $.ajax({
            type: "post",
            url: "EditClass.aspx",
            dataType: "string",
            data: "",
            success: function () {
                $("#btn").click();
            }
        });
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:Button ID="btn"  runat="server" style="display:none;" Text="隐藏刷新按钮" OnClick="btn_Click" />
        <div style="margin-left:30px; margin-top:5px; " class="STYLE1">筛选条件：<input id="txtClassName" type="text" runat="server" onpropertychange="SelectClassByName()" class="text-input" style="height:15px;width:200px; line-height:15px;" /></div>
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional"><ContentTemplate>
    <div style="position:absolute">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="15" height="30"><img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
                <td width="1101" background="../../html/tab/images/tab_05.gif"><img src="../../html/tab/images/311.gif" style="width: 16px; height: 16px" /> <span class="STYLE4">班级信息列表</span></td>
                <td width="281" background="../../html/tab/images/tab_05.gif"><table border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="60"><table width="90%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td class="STYLE1"><div align="center"><img src="../../html/tab/images/001.gif" width="14" height="14" /></div></td>
                            <td class="STYLE1"><div align="center"><a href="#" id="addclassA" onclick="Show(0)">新增</a></div></td>
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
                    <td width="8%" background="../../html/tab/images/tab_14.gif" class="style1"><div align="center" class="STYLE2 STYLE1">班级名称</div></td>
                    <td width="10%" background="../../html/tab/images/tab_14.gif" class="style1"><div align="center" class="STYLE2 STYLE1">年级</div></td>
                    <td width="10%" background="../../html/tab/images/tab_14.gif" class="style1"><div align="center" class="STYLE2 STYLE1">专业</div></td>
                    <td width="7%" background="../../html/tab/images/tab_14.gif" class="style1"><div align="center" class="STYLE2">修改</div></td>
                    <td width="7%" background="../../html/tab/images/tab_14.gif" class="style1"><div align="center" class="STYLE2">删除</div></td>
                  </tr>
                  <%
                      int i = 0;
                      foreach (DataRow row in classList.Rows)
                    {
                        i++;%>
                  <tr>
                    <td height="18" bgcolor="#FFFFFF" class="STYLE2"><div align="center" class="STYLE2 STYLE1"><%=row["BjName"].ToString() %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=row["Nj"].ToString() %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center" class="STYLE2 STYLE1"><%=row["ZyName"].ToString() %></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/037.gif" width="9" height="9" /></span><span class="STYLE1"> [</span><a id="a<%=i %>" href="#" onclick="Show(<%=row["BjID"] %>)">修改</a><span class="STYLE1">]</span></div></td>
                    <td height="18" bgcolor="#FFFFFF"><div align="center"><span class="STYLE2"><img src="../../html/tab/images/010.gif" width="9" height="9" /></span><span class="STYLE2"> </span><span class="STYLE1">[</span><a href="?BjID=<%=row["BjID"].ToString() %>">删除</a><span class="STYLE1">]</span></div></td>
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
                    <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=Record%>条记录，当前第<span id="spannowpage" runat="server"><%=nowPage %></span>/<span id="spanpages" runat="server"><%=Pages %></span>页，每页<span id="lenid" runat="server"><%=len %></span>条记录</span></td>
                    <td width="75%" valign="top" class="STYLE1"><div align="right">
                      <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="62" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton1" ImageUrl="../../html/tab/images/first.gif" width="37" height="15" runat="server" OnClick="FirstPage_Click"/></div></td>
                          <td width="50" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton2" ImageUrl="../../html/tab/images/back.gif" width="43" height="15" runat="server" OnClientClick="return BackPage()" OnClick="BackPage_Click"/></div></td>
                          <td width="54" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton3" ImageUrl="../../html/tab/images/next.gif" width="43" height="15" runat="server" OnClientClick="return NextPage()" OnClick="NextPage_Click"/></div></td>
                          <td width="49" height="22" valign="middle"><div align="right"><asp:ImageButton ID="ImageButton4" ImageUrl="../../html/tab/images/last.gif" width="37" height="15" runat="server" OnClick="LastPage_Click"/></div></td>
                          <td width="59" height="22" valign="middle"><div align="right">转到第</div></td>
                          <td width="25" height="22" valign="middle"><span class="STYLE7">
                            <input name="textfield" type="text" id="tzpage" class="STYLE1" runat="server" style="height:10px; width:25px; line-height:10px" size="5" />
                          </span></td>
                          <td width="23" height="22" valign="middle">页</td>
                          <td width="30" height="22" valign="middle"><asp:ImageButton ImageUrl="../../html/tab/images/go.gif" width="37" height="15" runat="server" OnClientClick="return JumpPage()"  OnClick="JumpPage_Click" ID="btnJumpPage" /></td>
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
    </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger  ControlID="btn" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
     <div id="addClass" class="STYLE1" style="width:320px; border:1px solid gray; display:none; background-color:#d2efac;text-align:center;position:absolute">
          <h3  id="edit">修改班级信息</h3>
        <table align="center" width="320px">
            <tr>
                <td style="text-align:right;width:80px">班级名：</td>
                <td style="width:160px;text-align:left"><asp:TextBox ID="textName" name="textName" runat="server" CssClass="text-input" Width="160px" Text="" MaxLength="15"></asp:TextBox></td>
                <td style="text-align:left"><span id="spanclassname" class="red"></span></td>
            </tr>
             <tr>
                <td style="text-align:right;width:80px">年&nbsp;&nbsp;&nbsp;&nbsp;级：</td>
                <td style="width:160px;text-align:left"><asp:textBox ID="textNj"  name="textNj" CssClass="text-input" runat ="server" Width="160px" MaxLength="10" > </asp:textBox> </td>
                <td style="text-align:left"><span id="spannj" class="red"></span></td>
            </tr>
            <tr>
                <td style="text-align:right">专&nbsp;&nbsp;&nbsp;&nbsp;业：</td> 
                <td style="width:160px"><asp:DropDownList ID="textZy"  name="textZy" runat ="server" Width="175px">
                    <asp:ListItem>计算机信息管理</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="text-align:left"> <span id="spanzy" class="red"></span></td>
            </tr>
            <tr >
                <td  colspan="3" style="text-align:center;height:50px;line-height:50px">
                    <asp:Button ID="ButtonOK"  runat="server" CssClass="button" text="确  定" OnClientClick="return CheckClass()" OnClick="ButtonOK_Click" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;<input type="hidden" id="hidClassID" runat="server" /> &nbsp&nbsp
                    <asp:Button ID="btnClose" runat="server" CssClass="button" Text="取  消" OnClientClick="return CloseEmpty()" OnClick="ButtonNO_Click" /></td>
            </tr>
        </table>
    </div>
<script type="text/javascript">
  
    AlterDivAndClose("addClass", "addclassA", "btnClose");
    var count =<%=classList.Rows.Count %> +"";
     for (var i = 1; i <= count; i++)
         AlterDivAndClose("addClass", "a" + i, "btnClose");
</script>
</form> 
</body>
</html>
