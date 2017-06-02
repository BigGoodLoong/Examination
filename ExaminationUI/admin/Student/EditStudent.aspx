<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditStudent.aspx.cs" Inherits="admin_Student_EditStudent" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无标题文档</title>
    <style type="text/css">
        <!--
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }

        .STYLE1 {
            font-size: 12px;
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

        .STYLE7 {
            font-size: 12px;
        }

        .auto-style1 {
            font-size: 12px;
            width: 12%;
        }

        .auto-style2 {
            width: 12%;
        }

        .auto-style3 {
            font-size: 12px;
            width: 22%;
        }

        .auto-style4 {
            width: 22%;
        }

        .auto-style5 {
            font-size: 12px;
            width: 24%;
        }

        .auto-style6 {
            width: 24%;
        }

        .auto-style7 {
            font-size: 12px;
            width: 18%;
        }

        .auto-style8 {
            width: 18%;
        }

        .auto-style9 {
            width: 80px;
            text-align: right;
        }

        .red {
            color: red;
        }
        -->
    </style>
    <link href="../../css/style.css" rel="Stylesheet" />
    <script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../../javascript/DivScript.js"></script>
    <script type="text/javascript" src="../../javascript/tablelist.js"></script>
    <script type="text/javascript" src="../../javascript/YanZheng.js"></script>

    <script type="text/javascript">
        function Show(num) {
            var s = document.getElementById("edit");
            if (num == 0) {
                s.innerHTML = "新增学生信息";
                document.getElementById("TextYh").disabled = false;
                document.getElementById("TextMm").disabled = false;
            }
            else {
                s.innerHTML = "修改学生信息";
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=EditStudent&YhID=" + num,
                    success: function (msg) {
                        var ms = msg.split(",");
                        $("#HiddenYhID").val(ms[0]);
                        $("#TextName").val(ms[1]);
                        if (ms[2] == "男")
                            $("#RadButNan").click();
                        else
                            $("#RadButNv").click();
                        $("#BjName").val(ms[3]);
                        $("#textBz").val(ms[4]);
                        $("#TextYh").val(ms[5]);
                        $("#textStudentID").val(ms[6]);
                        $("#TextMm").val(ms[7]);
                        document.getElementById("TextYh").disabled = true;
                        document.getElementById("TextMm").disabled = true;
                    }
                });
            }
        }
        /*按下取消按钮时清空数据*/
        function CloseEmpty() {
            $("#textStudentID").val("");/*学号*/
            $("#spanxh").text("");
            $("#TextName").val("");/*姓名*/
            $("#spanname").text("");
            $("#TextYh").val("");/*用户名*/
            $("#spanuser").text("");
            $("#TextMm").val("");/*密码*/
            $("#spanpwd").text("");
            $("#BjName").val("请选择...");/*班级*/
            $("#spanclass").text("");
            $("#textBz").val("");/*备注*/
            return false;
        }
        $(document).ready(function () {
            var num = 0;
            var Num = 0;
            $("#textStudentID").change(function () {
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=editStudentID&YhID=" + $("#HiddenYhID").val() + "&StudentID=" + $("#textStudentID").val(),
                    success: function (msg) {
                        if (msg == "已存在") {
                            $("#spanxh").text(msg);
                            num = 1;
                        }
                        else {
                            $("#spanxh").text("");
                            num = 2;
                        }
                    }
                });
            });
            $("#TextYh").change(function () {
                $.ajax({
                    type: "post",
                    url: "../../ajax.aspx",
                    dataType: "string",
                    data: "action=EditStudentYhName&YhName=" + $("#TextYh").val() + "&YhID=" + $("#HiddenYhID").val(),
                    success: function (msg) {
                        if (msg == "已存在") {
                            $("#spanuser").text(msg);
                            Num = 1;
                        }
                        else {
                            $("#spanuser").text("");
                            Num = 2;
                        }
                    }
                });
            });
            $("#txtClassName").val("按姓名，学号，班级，用户名模糊查询");
            $("#txtClassName").css("color", "#CCC");
            $("#txtClassName").focus(function () {
                var txt = $(this).val();
                if (txt.trim() == "按姓名，学号，班级，用户名模糊查询") {
                    $(this).val("");
                    $("#txtClassName").css("color", "#000");
                }
            });
            $("#txtClassName").blur(function () {
                var txt = $(this).val();
                if (txt.trim() == "") {
                    $("#txtClassName").css("color", "#CCC");
                    $(this).val("按姓名，学号，班级，用户名模糊查询");
                }
            });
            $("#ButtonOK").click(function () {
                if (num == 1) {
                    $("#spanxh").text("已存在"); return false;
                }
                if (Num == 1) {
                    $("#spanuser").text("已存在"); return false;
                }
                else return true;
            });
        });
        function SelectByName() {
            $.ajax({
                type: "post",
                url: "EditStudent.aspx",
                dataType: "string",
                data: "",
                success: function (msg) {
                    $("#btnsx").click();
                }
            });
        }
    </script>
</head>

<body style="font-size: 12px;">
    <form id="Form1" name="form1" runat="server">
        <asp:HiddenField ID="HiddenYhID" runat="server" />
        <input type="hidden" id="hidIsSubmit" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Button ID="btnsx" Style="display: none;" runat="server" Text="隐藏刷新按钮" OnClick="Button2_Click" />
        <div style="margin-left: 30px; margin-top: 5px;">筛选条件：<input id="txtClassName" type="text" runat="server" onpropertychange="SelectByName()" class="text-input" style="height: 15px; width: 287px; line-height: 15px;" /></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="position: absolute;">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="30">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="15" height="30">
                                            <img src="../../html/tab/images/tab_03.gif" width="15" height="30" /></td>
                                        <td width="1101" background="../../html/tab/images/tab_05.gif">
                                            <img src="../../html/tab/images/311.gif" width="16" height="16" />
                                            <span class="STYLE4">学生信息列表</span></td>
                                        <td width="281" background="../../html/tab/images/tab_05.gif">
                                            <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="60">
                                                        <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="STYLE1">
                                                                    <div align="center">
                                                                        <img src="../../html/tab/images/001.gif" width="14" height="14" /></div>
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center"><a href="#" id="addstu" onclick="Show(0)">新增</a></div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="14">
                                            <img src="../../html/tab/images/tab_07.gif" width="14" height="30" /></td>
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
                                            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#c0de98" onmouseover="changeto()" onmouseout="changeback()">
                                                <tr>
                                                    <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style1">
                                                        <div align="center" class="STYLE2 STYLE1">姓名</div>
                                                    </td>
                                                    <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style5">
                                                        <div align="center" class="STYLE2 STYLE1">学号</div>
                                                    </td>
                                                    <td width="10%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1">
                                                        <div align="center" class="STYLE2 STYLE1">性别</div>
                                                    </td>
                                                    <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style3">
                                                        <div align="center" class="STYLE2 STYLE1">班级</div>
                                                    </td>
                                                    <td height="18" background="../../html/tab/images/tab_14.gif" class="auto-style7">
                                                        <div align="center" class="STYLE2">用户名</div>
                                                    </td>
                                                    <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1">
                                                        <div align="center" class="STYLE2">编辑</div>
                                                    </td>
                                                    <td width="7%" height="18" background="../../html/tab/images/tab_14.gif" class="STYLE1">
                                                        <div align="center" class="STYLE2">删除</div>
                                                    </td>
                                                </tr>
                                                <%
                                                    int i = 0;
                                                    foreach (DataRow row in studentList.Rows)
                                                    {
                                                        i++;%>
                                                <tr>
                                                    <td height="18" bgcolor="#FFFFFF" class="auto-style2">
                                                        <div align="center" class="STYLE2 STYLE1"><%=row["姓名"].ToString() %></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF" class="auto-style6">
                                                        <div align="center" class="STYLE2 STYLE1"><%=row["学号"].ToString() %></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF">
                                                        <div align="center" class="STYLE2 STYLE1"><%=row["性别"].ToString() %></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF" class="auto-style4">
                                                        <div align="center" class="STYLE2 STYLE1"><%=row["班级"].ToString() %></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF" class="auto-style8">
                                                        <div align="center"><%=row["用户名"].ToString() %></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF">
                                                        <div align="center"><span class="STYLE2">
                                                            <img src="../../html/tab/images/037.gif" width="9" height="9" /></span><span class="STYLE1"> [</span><a href="#" id="a<%=i %>" onclick="Show(<%=row["YhID"].ToString() %>)">修改</a><span class="STYLE1">]</span></div>
                                                    </td>
                                                    <td height="18" bgcolor="#FFFFFF">
                                                        <div align="center"><span class="STYLE2">
                                                            <img src="../../html/tab/images/010.gif" width="9" height="9" /></span><span class="STYLE2"> </span><span class="STYLE1">[</span><a href="?userid=<%=row["YhID"].ToString() %>">删除</a><span class="STYLE1">]</span></div>
                                                    </td>
                                                </tr>
                                                <%}   %>
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
                                        <td width="15" height="29">
                                            <img src="../../html/tab/images/tab_20.gif" width="15" height="29" /></td>
                                        <td background="../../html/tab/images/tab_21.gif">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="25%" height="29" nowrap="nowrap"><span class="STYLE1">共<%=Count %>条纪录，当前第<span id="spannowpage" runat="server"><%=page %></span>/<span id="spanpages" runat="server"><%=Maxapge %></span>页，每页<%=len %>条纪录</span></td>
                                                    <td width="75%" valign="top" class="STYLE1">
                                                        <div align="right">
                                                            <table width="352" height="20" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="62" height="22" valign="middle">
                                                                        <div align="right">
                                                                            <asp:ImageButton ID="ImageFirst" runat="server" ImageUrl="../../html/tab/images/first.gif" Width="37" Height="15" OnClick="ImageFirst_Click" />
                                                                        </div>
                                                                    </td>
                                                                    <td width="50" height="22" valign="middle">
                                                                        <div align="right">
                                                                            <asp:ImageButton ID="ImageBack" runat="server" ImageUrl="../../html/tab/images/back.gif" Width="43" OnClientClick="return BackPage()" Height="15" OnClick="ImageBack_Click" />
                                                                        </div>
                                                                    </td>
                                                                    <td width="54" height="22" valign="middle">
                                                                        <div align="right">
                                                                            <asp:ImageButton ID="ImageNext" runat="server" ImageUrl="../../html/tab/images/next.gif" Width="43" Height="15" OnClientClick="return NextPage()" OnClick="ImageNext_Click" />
                                                                        </div>
                                                                    </td>
                                                                    <td width="49" height="22" valign="middle">
                                                                        <div align="right">
                                                                            <asp:ImageButton ID="ImageLast" runat="server" ImageUrl="../../html/tab/images/last.gif" Width="37" Height="15" OnClick="ImageLast_Click" />
                                                                        </div>
                                                                    </td>
                                                                    <td width="59" height="22" valign="middle">
                                                                        <div align="right">转到第</div>
                                                                    </td>
                                                                    <td width="25" height="22" valign="middle"><span class="STYLE7">
                                                                        <asp:TextBox ID="tzpage" runat="server" name="textfield" class="STYLE1" Style="height: 10px; width: 25px;" size="5"> </asp:TextBox>
                                                                    </span></td>
                                                                    <td width="23" height="22" valign="middle">页</td>
                                                                    <td width="30" height="22" valign="middle">
                                                                        <asp:ImageButton ID="ImageGo" runat="server" ImageUrl="../../html/tab/images/go.gif" Width="37" Height="15" OnClientClick="return JumpPage()" OnClick="ImageGo_Click" /></td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="14">
                                            <img src="../../html/tab/images/tab_22.gif" width="14" height="29" /></td>
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

        <div id="addstudent" class="STYLE1" style="width: 320px;  border: 1px solid #c0de98; background-color: #e3f7c9; text-align: center; position: absolute;">

            <h3 style="margin-top: 20px; margin-bottom: 19px;" runat="server" id="edit">新增学员信息</h3>
            <br />
            <table style="width: 320px; margin-top: -20px; margin-left: auto; margin-right: auto; margin-bottom: 0px;">
                <tr>
                    <td class="auto-style9">学&nbsp&nbsp;&nbsp; 号：</td>
                    <td style="width: 160px">
                        <asp:TextBox ID="textStudentID" MaxLength="20" name="textStudentID" CssClass="text-input" runat="server" Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: left"><span class="red" id="spanxh"></span></td>
                </tr>
                <tr>
                    <td class="auto-style9">姓&nbsp&nbsp;&nbsp; 名：</td>
                    <td style="width: 160px">
                        <asp:TextBox ID="TextName" MaxLength="10" CssClass="text-input" name="TextName" runat="server"  Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: left"><span style="color: red" id="spanname"></span></td>
                </tr>
                <tr style="height: 25px">
                    <td class="auto-style9">性&nbsp&nbsp;&nbsp; 别：</td>
                    <td align="center">
                        <input type="radio" name="sex" runat="server" checked id="RadButNan" value="男" />男
                    <input type="radio" style="margin-left: 50px;" runat="server" name="sex" id="RadButNv" value="女" />女
                    </td>
                    <td style="text-align: left"><span style="color: red" id="spansex"></span></td>
                </tr>
                <tr>
                    <td class="auto-style9">用户名：</td>
                    <td style="width: 160px">
                        <asp:TextBox ID="TextYh" name="TextYh" MaxLength="15" CssClass="text-input" runat="server" Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: left"><span style="color: red" id="spanuser"></span></td>
                </tr>
                <tr>
                    <td class="auto-style9">密&nbsp&nbsp;&nbsp; 码：</td>
                    <td style="width: 160px">
                        <asp:TextBox ID="TextMm" name="TextMm" TextMode="Password" MaxLength="50" CssClass="text-input" runat="server" Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: left"><span style="color: red" id="spanpwd"></span></td>
                </tr>
                <tr>
                    <td class="auto-style9">班&nbsp&nbsp;&nbsp; 级：</td>
                    <td style="width: 160px">
                        <asp:DropDownList ID="BjName" name="BjName" CssClass="text-input"  runat="server" Width="175px" ></asp:DropDownList></td>
                    <td style="text-align: left"><span id="spanclass" style="color: red"></span></td>
                </tr>
                <tr>
                    <td class="auto-style9">备&nbsp&nbsp;&nbsp; 注：</td>
                    <td style="width: 160px">
                        <asp:TextBox ID="textBz" CssClass="text-input" MaxLength="50" runat="server" Style="overflow: hidden;" Width="160px" Height="60px" TextMode="MultiLine" Wrap="true"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height:50px;line-height:50px">
                        <asp:Button ID="ButtonOK" runat="server" CssClass="button" Text="确  定" OnClientClick="return CheckStudent()" OnClick="ButtonOK_Click" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="btnClose" CssClass="button" runat="server" Text="取  消" OnClientClick="return CloseEmpty()" OnClick="ButtonNO_Click" /></td>
                </tr>
            </table>
        </div>
<script type="text/javascript">
    AlterDivAndClose("addstudent", "addstu", "btnClose");
    var count =<%=studentList.Rows.Count %> +"";
    for (var i = 1; i <= count; i++)
        AlterDivAndClose("addstudent", "a" + i, "btnClose");
</script>
    </form>
</body>
</html>

