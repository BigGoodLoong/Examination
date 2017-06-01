<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="student_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../javascript/jquery-1.10.0.min.js"></script>
<style type="text/css">
	#all{position:fixed; left:0px;width:100%;height:100%;
        top: 0px;
        font-family:"微软雅黑";
    }
	#top{
		width:100%;
		height:5%;
		position:fixed;
		left:0px;
		top:0px;
		background-color:#e3f8ca;}
	.toptable{
		font-size:12px;
		font-weight:bold;
		width:100%;
		height:40px;
		padding-left:20px;}
	#bottom{
		width:100%;
		height:5%;
		position:fixed;
		left:0px;
		bottom:0px;
		background-color:#e3f8ca;}
	.bottomtable{
		font-size:12px;
		font-weight:bold;}
	.button{
		width:82px;
		height:23px;
		border:0px solid;
		background-image:url(../images/shijuan/button.jpg);}
    #center {
    height:95%;
    }
	
.slide{position:relative;width:46%;height:89%;padding:10px;border:#ccc 1px solid; margin-top:40px; float:left;}
    .ifre {
        height:100%;width:100%;
        overflow:hidden;
    }

.right{position:relative;float:right; width:46%;height:89%;padding:10px;border:#ccc 1px solid; margin-top:40px; right:20px;}
.right .rdiodiv{ background-color:#CCC; width:600px; height:auto; position:fixed;right:30px;}
.right .ckbdiv{ background-color:#0FF; width:600px; height:auto; position:fixed; top:220px;}
.right .panduan{ background-color:#CCC; width:600px; height:auto; position:fixed; top:315px;
        left: 352px;
    }
ul{ padding-left:0px;}
ul li{ list-style-type:none; float:left; margin-right:20px; width:180px; text-align:right;}
.panduan ul li{width:113px; margin-right:7px;}
    #Jishi {
        font-size:11px;
        color:red;
    }
</style>

    <script type="text/javascript">
        function test()
        {
                document.getElementById('frm1').contentWindow.document.getElementById("Baocun").click();
                return false;
        }

        function test2()
        {
            document.getElementById('frm1').contentWindow.document.getElementById("Button1").click();
            this.close();
        }

        function error()
        {
            alert("本次考试已结束，请勿重复提交");
            this.close();
            location.href = "../error.aspx";
        }
    </script>

</head>
<body style="background-image:url(../images/shijuan/snowhua.png)" ondragstart="window.event.returnValue=false" oncontextmenu="window.event.returnValue=false" onselectstart="event.returnValue=false" >
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000" Enabled="true" ></asp:Timer>
        <div id="all"> <!--整个页面div开始-->
          <div id="top">
	        <table class="toptable">
    	        <tr>
        	        <td>考试名称：<span style="color:#06F;"><%=drPaper["SjName"].ToString()%></span></td>
                    <td>考生姓名：<span style="color:#06F;"><%=Ls[3] %></span></td>
                    <td>考试时长：<span style="color:#06F;"><%=Ls[0]%>分钟</span></td>
                    <td>开考时间：<span style="color:#06F;"><%=Ls[2]%></span></td>
                    <td>试卷总分：<span style="color:#06F;"><%=Ls[1]%>分</span></td>
                </tr>
            </table>
        </div>
          <div id="center"><!--center div开始-->
            <div class="slide"><!--试卷div开始-->
                 <iframe src="Paper.aspx?SjID=<%=SjID %>" lass="ifre" height="100%" width="100%"></iframe>
                </div><!--试卷div结束-->
    
              <div class="right">
                  <iframe id="frm1" src="../admin/AnswerCard/AnswerCard.aspx?SjID=<%=SjID%>&User=2" width="100%" height="100%"></iframe>
                </div><!--答题卡div结束-->
        </div><!--center div结束-->
          <div id="bottom">
	        <table class="bottomtable" align="center" width="1005">
    	        <tr>
        	        <td width="371"><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                            剩余时间：<span style="color:#F00;"> <asp:Label ID="STime" runat="server" Text="0" />分钟</span>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel></td>
                    <td width="338"><input class="button" type="button" value="提交试卷" onclick="test2()" /></td>
                        
                     <td style="text-align:left;">
                        <span style="width:100px; font-size:13px;">
                            <asp:UpdatePanel runat="server"><ContentTemplate>
                            <asp:Label ID="Jishi" runat="server" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel></span>
                    </td>
                    <td width="280"><input class="button" type="button" value="保存试题" onclick="test()" /></td>
                </tr>
            </table>
        </div>

        </div><!--整个页面div结束-->


        <script type="text/javascript">   
            var defaultOpts = { interval: 4000, fadeInTime: 300, fadeOutTime: 200 };
            var _titles = $(".slide .thumb a");
            var _bodies = $(".slide .pic a");
            var _count = _titles.length;
            var _current = 0;
            var _intervalID = null;
            var stop = function() { window.clearInterval(_intervalID); };
            var slide = function(opts) {
                if (opts) {
                    _current = opts.current || 0;
                } else {
                    _current = (_current >= (_count - 1)) ? 0 : (++_current);
                };
                _bodies.filter(":visible").fadeOut(defaultOpts.fadeOutTime, function() {
                    _bodies.eq(_current).fadeIn(defaultOpts.fadeInTime);
                    _bodies.removeClass("cur").eq(_current).addClass("cur");
                });
                _titles.removeClass("cur").eq(_current).addClass("cur");
            };

            var itemMouseOver = function(target, items) {
                stop();
                var i = $.inArray(target, items);
                slide({ current: i });
            }; 
            _titles.hover(function() { if($(this).attr('class')!='cur'){itemMouseOver(this, _titles); }else{stop();}});
            _bodies.hover(stop);

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
    </form> 
</body>
</html>
