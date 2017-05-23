<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        <!--
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow: hidden;
        }

        .STYLE3 {
            color: #528311;
            font-size: 12px;
        }

        .STYLE4 {
            color: #42870a;
            font-size: 12px;
        }

        .styleprompt {
            color: red;
            font-size: 12px;
        }

        .denglu {
            margin-left: -5px;
        }

        .auto-style1 {
            width: 421px;
        }
        -->
    </style>
    <script type="text/javascript" src="javascript/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#prompt").addClass("styleprompt");
            $("#imgBtnLogin").click(function () {
                if ($("#textfield").val() == "") {
                    $("#spusername").text("*");
                } else if ($("#textfield2").val() == "") {
                    $("#sppwd").text("*");
                    $("#spusername").text("");
                } else {
                    var $user = $("#textfield").val();
                    var $pwd = $("#textfield2").val();
                    $.ajax({
                        type: "post",
                        url: "ajax.aspx",
                        dataType: "string",
                        data: "action=login&username=" + $user + "&pwd=" + $pwd,
                        success: function (msg) {
                            if (msg == "MQ==" || msg == "Mg==")
                                location.href = "admin/Main.aspx?status=" + msg;
                            else if (msg == "Mw==")
                                location.href = "exam/ExamList.aspx";
                            else
                                $("#tdmsg").text(msg);
                        }
                    });
                }
                return false;
            });
            $("#imgBtnReset").click(function () {
                $("#textfield").val("");
                $("#textfield2").val("");
                return false;
            });
        });
    </script>
</head>
<script type="text/javascript">
    document.onkeydown = function mykeydown() { //网页内按下回车触发,设置[登录]图片按钮响应回车
        if (event.keyCode == 13) {
            document.getElementById("imgBtnLogin").click();
            return false;
        }
    }
</script>
<body onload="document.onkeydown()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td bgcolor="#e5f6cf">&nbsp;</td>
            </tr>
            <tr>
                <td height="608" background="images/login/login_03.gif">
                    <table width="862" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="266" background="images/login/login_04.gif">
                                <table height="266" width="100%">
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                        <td id="tdmsg" style="color: red; vertical-align: bottom; font-size: 12px;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="95">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="424" height="95" background="images/login/login_06.gif">&nbsp;</td>
                                        <td width="183" background="images/login/login_07.gif">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" height="30">
                                                        <div align="center"><span class="STYLE3">用户</span></div>
                                                    </td>
                                                    <td width="79%" height="30">

                                                        <asp:TextBox ID="textfield" name="textfield" Style="height: 18px; width: 130px; border: solid 1px #cadcb2; font-size: 12px; color: #81b432;" runat="server"></asp:TextBox><span style="vertical-align: bottom; color: red; font-size: 12px;" id="spusername"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <div align="center"><span class="STYLE3">密码</span></div>
                                                    </td>
                                                    <td height="30">
                                                        <asp:TextBox ID="textfield2" name="textfield2" TextMode="Password" Style="height: 18px; width: 130px; border: solid 1px #cadcb2; font-size: 12px; color: #81b432;" runat="server"></asp:TextBox><span id="sppwd" style="vertical-align: bottom; color: red; font-size: 12px;"></span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">&nbsp;</td>
                                                    <td height="30">
                                                        <asp:ImageButton ID="imgBtnLogin" ImageUrl="~/images/login/dl_01.png" runat="server" />
                                                        <asp:ImageButton ID="imgBtnReset" ImageUrl="~/images/login/dl_02.png" CssClass="denglu" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="255" background="images/login/login_08.gif">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="247" valign="top" background="images/login/login_09.gif">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="22%" height="30">&nbsp;</td>
                                        <td width="56%">&nbsp;</td>
                                        <td width="22%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td height="30">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="44%" height="20">&nbsp;</td>
                                                    <td width="56%" class="STYLE4">版本 2017V1.0 </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="#a2d962">&nbsp;</td>
            </tr>
        </table>

        <map name="Map">
            <area shape="rect" coords="3,3,36,19" href="#">
            <area shape="rect" coords="40,3,78,18" href="#">
        </map>
    </form>
</body>
</html>
