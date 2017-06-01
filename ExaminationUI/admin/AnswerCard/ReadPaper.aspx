<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadPaper.aspx.cs" Inherits="admin_AnswerCard_ReadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>批阅试卷</title>
    <script type="text/javascript" src="../../javascript/YanZheng.js"></script>
    <style type="text/css">
        .all {
            background-color:#f3ffe3 ;
            width:90%;
            margin:0 auto;
        }
        .top {
            border-bottom:4px solid #000000;
            height:40px;
        }
        .main {
            border-bottom:1px solid #808080;
        }
        .main_text {
            font-size:14px;
            font-family:"华文正楷";
            font-weight:bold;
            text-align:center;
            padding-left:5px;
        }
        .fen {
            border:2px solid;
        }
        .Answer {
            width:80%;
            padding-left:10px;
            padding-right:10px;
            margin-top:20px;
            margin:0 auto;
            border:#000000 solid 0px;
            
        }

        .NeiRong {
            border:dotted 1px #000000;
            padding-left:4px;
            padding-right:4px;
            padding-top:5px;
            background-color:#f3ffe3 ;
            margin-top:10px;
        }

        .bottom {
            width:100px;
            font-size:14px;
            font-family:"微软雅黑";
            background-color:#206ea8;
            color:white;
            font-weight:bold;
        }

        .LAnswer {
            width:80%;
            padding:5px;
            word-break:break-all;
            font-size:14px;
            font-family:"微软雅黑";
        }
    </style>
    <script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
    <script type="text/javascript">
        function Click()
        {
            var tex = $("input:text");
            var spScore = Number($("#spanAllscore").text());
            var Zfen = 0;
            var Pan = true;
            for (var i = 0; i < tex.length; i++) {
                var num = tex.eq(i).val();
                if (!isNaN(num) && Number(num) > 0 && Zfen < spScore)
                {
                    Zfen += Number(num);
                    Pan = true;
                }
                else {
                    tex.eq(i).css("borderColor", "red");
                    Pan = false;
                    break;
                }
            }
            if (Pan)
            {
                location.href = "ReadPaper.aspx?action=zfen&score=" + Zfen;
                $(this).text = "提交成功";
                $("#ButTijiao").click();

            }
        }

    </script>
        
</head>
<body>
    <form id="form1" runat="server">
    <div class="all">
        <div class="top"></div>
        <div class="main">
            <div class="main_text">
                <table style="width:100%">
                    <tr>
                        <td  class="main_text">试卷名称：<%=StrLive[0]%></td>
                        <td  class="main_text">命题老师：<%=StrLive[1]%></td>
                        <td  class="main_text">学号：<%=StrLive[2]%></td>
                        <td  class="main_text">本题型总分：<span id="spanAllscore" runat="server"><%=StrLive[3]%></span></td>
                    </tr>
                </table>
            </div>
            <hr class="fen" />
            <div class="Answer">
                <%
                    num = 0;
                    for (int i = 0; i < stu.Length-1; i++)
                  {
                      num++;
                      str = num.ToString() + "." + stu[i];%>
                 
                <div class="Answer">
                    <asp:Panel runat="server" CssClass="NeiRong">
                        <table style="width:95%; margin:0 auto;">
                            <tr>
                                <td class="LAnswer"><%=str%></td>
                            </tr>
                             <tr>
                                <td style="text-align:right; font-weight:bold;font-size:13px;color:red;">
                                    本题得分：
                                    <input type="text" runat="server" name="textboxscore" style="background-color:#f3ffe3 ; overflow:hidden; border:1px solid; width:100px;" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                 <%} %>
                <div style="text-align:center;">
                    <input type="button" runat="server"  class="bottom" value="提交分数" onclick="Click()" />
                    <asp:Label runat="server" ID="Zdefen">0</asp:Label>
                    <div style="display:none">
                        <asp:Button runat="server" ID="ButTijiao" OnClick="ButTiJiao_Click" />
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
