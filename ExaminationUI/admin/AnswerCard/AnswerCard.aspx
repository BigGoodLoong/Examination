<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnswerCard.aspx.cs" Inherits="admin_AnswerCard_AnswerCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    .all {
        width:98%;
        height:40%; 
        border:1px solid #000;
    }
        
    .text {
        font-size:13px;
        font-family:"微软雅黑";
        font-weight:bold;
        border:1px solid #000;
        background-color:#71ad25;
        display:block;
        width:500px;
        text-align:center;
        width:100%;
    }
        .textOn {
        display:block;
        }
        .textOff {
        display:none;
        }
    tr {
        height:auto;
    }
        .texbefor {
            height:50px;
            width:450px;
            border-bottom:1px solid #000;
            border-left:0;
            border-top:0;
            border-right:0;
            overflow:hidden;
            background-color:#e3f8ca;
        }

        .tab {
        width:98%;
        }

        .head {
            font-size:17px;
            font-weight:bold;
            font-family:"微软雅黑";
        text-align:center;
        padding-top:20px;
        }

        .BunDiv {
        border:1px solid #e3f8ca;
        background-color:#808080;
        text-decoration:none;
        margin-top:6px;
        padding:2px;
        }
        .rdiobtnList{
        font-size:12px;
        font-weight:bold;
        }
        .nowrdoBtnList {
        background-color:#f0f0f0;
        font-size:12px;
        }
</style>
<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<script type="text/javascript">
 
</script>
<script type="text/javascript">
    function Cick(num)
    {
        $(".textOff").css("display", "none");
        $("#a" + num).css("display", "block");
        
    }
    function load()
    {
        $("table:eq(0) tr:eq(3)").css("display", "block");
        
    }
    
    $(document).ready(function () {
        $(".rdiobtnList").click(function () {
            var rad = $(this).children()[0].firstElementChild.children;
            if (rad.length>0)
            {
                for (var rd = 0; rd < rad.length; rd++) {
                    if ($(rad).children()[rd * 2].checked) {
                        $(this).addClass("nowrdoBtnList");
                        break;
                    }
                }
            }
            else {
                rad = $(this).children();
                for (var ck = 1; ck < rad.length; ck++) {
                    if (rad[ck].firstElementChild.checked) {
                        $(this).addClass("nowrdoBtnList");
                        break;
                    }
                }
            }
        });
       
    });
</script>
</head>
<body style="font-size:12px;background-color:#f3ffe3;" onload="load()" 
    ondragstart="window.event.returnValue=false" oncontextmenu="window.event.returnValue=false" onselectstart="event.returnValue=false">   
    <form runat="server" class="tab">
    <center>
            <table style="width:500px;">
                <tr><td class="head" style="font-family:LiSu;font-size:22px"><%=drPaper["SjName"].ToString() %></td></tr>
                <tr><td class="head">答题卡</td></tr>
                <%if (max[0] > 0)
                  { %>
                <tr onclick="Cick(0)">
                    <td class="text"><span id="spandanxuan"><%=strText[0]%></span></td>
                </tr>
                 <tr class="textOff" id="a0">
                    <td>
                        <asp:Panel ID="PanDan"  runat="server">
                           
                        </asp:Panel>
                    </td>
                </tr> 
                <% } 
                if (max[1] > 0)
                  { 
                  %>
                <tr onclick="Cick(1)"><td class="text" ><span id="spanduoxuan"><%=strText[1]%></span></td></tr>
                <tr class="textOff" id="a1">
                    <td>
                        <asp:Panel ID="PanDuo" runat="server">
                           
                        </asp:Panel>
                    </td>
                </tr>
                 <% } 
                  if (max[2] > 0)
                  { 
                  %>
                    <tr onclick="Cick(2)"><td class="text"><span id="spanpanduan"><%=strText[2]%></span></td></tr>
                    <tr class="textOff" id="a2">
                    <td>
                        <asp:Panel ID="PanPan" runat="server">
                           
                        </asp:Panel>
                    </td>
                </tr>
                 <% }
                if (max[3] > 0)
                  { 
                  %>
                <tr onclick="Cick(3)"><td class="text"><span id="spanjianda"><%=strText[3]%></span></td></tr>
                <tr class="textOff" id="a3">
                    <td>
                        <asp:Panel ID="PanJay" runat="server">
                           
                        </asp:Panel>
                    </td>
                </tr>
                 <% } %>
            </table>
         <div style="display:none" >
        <asp:Button ID="Baocun" Text="保存" runat="server" OnClick="Baocun_Click1" Height="20px" Width="50px" />
        <asp:Button ID="Button1" Text="提交" runat="server" OnClick="Button1_Click" Height="20px" Width="50px" />
        </div>
        <%if (Top.Zt == 1)
          { %>
         <asp:Button ID="Tijiao" Text="提交答案" runat="server" OnClientClick="return CheckAnswer()" OnClick="Tijiao_Click" />
        <asp:Button ID="back" Text="返回<<" runat="server" OnClick="back_Click" />
         <% } %>
    </center>
   </form>
    <script type="text/javascript">
     //屏蔽刷新等操作
            function f15(){
                if((event.keyCode==8)||                    //屏蔽退格删除键     
                 (event.keyCode==116)||                   //屏蔽F5刷新键    
                 (event.ctrlKey && event.keyCode==82)){   //Ctrl+R    
                    event.keyCode=0;    
                    event.returnValue=false;    
                }    
            }
            window.onkeydown=f15;
            </script>
</body>
</html>
