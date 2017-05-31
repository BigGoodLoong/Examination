<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyExamList.aspx.cs" Inherits="exam_MyExamList" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ExaminationBLL" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML lang="en" xmlns="http://www.w3.org/1999/xhtml"><HEAD><META content="IE=10.000" http-equiv="X-UA-Compatible">
<LINK href="css_js/theme.css.css" rel="stylesheet" type="text/css"><LINK 
href="css_js/primefaces.css.css" rel="stylesheet" type="text/css"><LINK 
href="css_js/clock.css.css" rel="stylesheet" type="text/css">
<SCRIPT src="css_js/jquery.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/jquery-plugins.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/primefaces.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/clock.js.js" type="text/javascript"></SCRIPT>        
<LINK href="css_js/rerebbs.css" rel="stylesheet" type="text/css">         
<LINK href="css_js/rerebbs_a.css" rel="stylesheet" type="text/css">
<META name="GENERATOR" content="MSHTML 10.00.9200.16635">
    <style type="text/css">
        .auto-style3 {
            background: url("/exam2/javax.faces.resource/images/ui-bg_highlight-hard_15_459e00_1x100.png.jspx?ln=primefaces-south-street") repeat-x 50% 50% rgb(69, 158, 0);
            border: 1px solid rgb(50, 126, 4);
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 196px;
        }
        .auto-style4 {
            width: 196px;
        }
        .auto-style5 {
            background: url("/exam2/javax.faces.resource/images/ui-bg_highlight-hard_15_459e00_1x100.png.jspx?ln=primefaces-south-street") repeat-x 50% 50% rgb(69, 158, 0);
            border: 1px solid rgb(50, 126, 4);
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 206px;
        }
        .auto-style6 {
            width: 206px;
        }
        a:link{
            font-size:12px;
        }
        .SPEN{
             font-size:12px;
             color:red;
             display:none;
        }
    </style>
     <script type="text/javascript">
         function DelMyTest(obj) {
             if (confirm('确认要删除此考试吗？') == true) {
                 location.href = "MyExamList.aspx?action=Del&kgtid=" + obj;
             }
         }
         function textValues() {
             if ($("#sjName").val() !=null) {
                 location.href = "MyExamList.aspx?action=vlaues&sjName=" + $("#sjName").val();
             }
         }
         $(document).ready(function () {
             $("#sjName").focus(function () {
                 $("#spen").css("display", "block");
             });
             $("#sjName").blur(function () {
                 $("#spen").css("display", "none");
             });
         })
    </script>
</HEAD>
<BODY> 
<FORM name="myForm" runat="server" id="myForm" enctype="application/x-www-form-urlencoded" method="post">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<DIV class="ui-dialog ui-widget ui-widget-content ui-overlay-hidden ui-corner-all ui-shadow" 
id="myForm:login1">

<SPAN 
id="myForm:j_idt28"></SPAN></DIV>
<SCRIPT id="myForm:login1_s" type="text/javascript">$(function () { PrimeFaces.cw('Dialog', 'login1', { id: 'myForm:login1', width: '330', showEffect: 'drop', hideEffect: 'drop' }); });</SCRIPT>

<DIV class="ui-notificationbar ui-widget ui-widget-content" id="myForm:j_idt30" 
style="padding: 0px; height: 41px;">                  
<DIV style="margin: 0px auto; width: 960px;">
<DIV style="margin: 9px 12px 0px 640px; border: 0px solid red; width: 317px; text-align: right; position: absolute; z-index: 500;">
<asp:UpdatePanel runat="server"><ContentTemplate>
<SPAN class="ui-clock ui-widget ui-widget-header ui-corner-all" runat="server" id="spannowtime"></SPAN>
<asp:Timer ID="timer1" runat="server" OnTick="timer1_Tick" Interval="1000" Enabled="true"></asp:Timer>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>
</DIV>
<DIV><SPAN id="myForm:j_idt34">
<TABLE>
  <TBODY>
  <TR>
    <TD><SPAN class="topTip">欢迎您&nbsp;<%=Hello %>！</SPAN></TD>
    <TD>
      <DIV class="ui-menu ui-menubar ui-widget ui-widget-content ui-corner-all ui-helper-clearfix" 
      id="myForm:j_idt39" role="menubar" style="border: 0px solid red; width: 800px; background-color: inherit;">
      <UL class="ui-menu-list ui-helper-reset">
        <LI class="ui-menuitem ui-widget ui-corner-all" role="menuitem"><A 
        class="ui-menuitem-link ui-corner-all topNav" id="myForm:j_idt40" href="javascript:location.href='ExamList.aspx'"><SPAN class="ui-menuitem-text">参加考试</SPAN></A></LI>
       
        <LI class="ui-widget ui-menuitem ui-corner-all ui-menu-parent topNav newMenuNav" 
        role="menuitem" aria-haspopup="true"><A class="ui-menuitem-link ui-corner-all" 
        href="javascript:void(0)"><SPAN 
        class="ui-menuitem-text">我的考卷</SPAN></A></LI>
        <LI class="ui-menuitem ui-widget ui-corner-all" role="menuitem">
        <A class="ui-menuitem-link ui-corner-all topNav" id="myForm:j_idt56" 
        href="javascript:location.href='../Exit.aspx'"><SPAN 
        class="ui-menuitem-text">退出</SPAN></A></LI></UL></DIV>
<SCRIPT id="myForm:j_idt39_s" type="text/javascript">PrimeFaces.cw('Menubar', 'widget_myForm_j_idt39', { id: 'myForm:j_idt39', autoDisplay: true });</SCRIPT>
    </TD></TR></TBODY></TABLE></SPAN>                     </DIV></DIV></DIV>
<SCRIPT id="myForm:j_idt30_s" type="text/javascript">$(function () { PrimeFaces.cw('NotificationBar', 'bar11', { id: 'myForm:j_idt30', position: 'top', effect: 'slide', effectSpeed: 'normal', autoDisplay: true }); });</SCRIPT>
             
<DIV style="margin: 0px auto; width: 960px;">
<DIV style="height: 38px;"></DIV>
<DIV style="border: 0px solid green; height: 140px; text-align: center; overflow: hidden; padding-bottom: 0px; margin-bottom: 0px; z-index: 1;"><IMG 
id="myForm:adv2" style="margin: 0px; border: 1px solid gray; width: 957px; height: 140px;" 
src="../images/login/horf1.png"></DIV>
<DIV class="ui-panel ui-widget ui-widget-content ui-corner-all mainPanel" id="myForm:mainPanel" 
style="width: 957px;">
<DIV class="ui-panel-content ui-widget-content" id="myForm:mainPanel_content">   

<DIV class="ui-datatable ui-widget" id="myForm:j_idt61" style="width: 100%;">
<DIV class="ui-datatable-tablewrapper">
<TABLE role="grid">
  <THEAD id="myForm:j_idt61_head">
  <TR role="row">
    <TH class="ui-state-default" id="myForm:j_idt61:j_idt62" role="columnheader" 
    style="width: 200px !important; text-align: center;"><SPAN>考试名称</SPAN>
        <input type="text" id="sjName" name="sjName" onchange="textValues()" runat="server" class="ui-column-filter ui-inputfield ui-inputtext ui-widget ui-state-default ui-corner-all" />
    <span class="SPEN" id="spen"  >光标离开有效</span></TH>
    <TH class="auto-style3" id="myForm:j_idt61:j_idt65" role="columnheader" 
    style="text-align: center;"><SPAN>题型分布</SPAN></TH>
    <TH class="ui-state-default" id="myForm:j_idt61:j_idt70" role="columnheader" 
    style="width: 50px; text-align: center;"><SPAN>评分类型</SPAN></TH>
    <TH class="auto-style5" id="myForm:j_idt61:j_idt74" role="columnheader" 
    style="text-align: center;"><SPAN>详细成绩</SPAN></TH>
    <TH class="ui-state-default" id="myForm:j_idt61:j_idt78" role="columnheader" 
    style="width: 80px !important; text-align: center;"><SPAN>总成绩/满分</SPAN></TH>
    </TR></THEAD>
  <TFOOT></TFOOT>
  <TBODY class="ui-datatable-data ui-widget-content" id="myForm:j_idt61_data">
  
  <!--第一行-->
  <%foreach (DataRow row in testPaperScoreList.Rows)
    {
        int sjid=int.Parse(row["SjID"].ToString());
        //获取当前试卷的所有题型
       DataTable questionTypes= TbQuestionTypesManager.GetAllQuestionTypesBySjid(sjid);
       int sumScore = TbQuestionTypesManager.GetSumScoreBySjid(sjid);  //试卷总分
       int type = 0;  //判断是否有简答题
        string scoreStr="";
        float score = 0; //考试总分
       DataTable scoreList= TbScoreManager.GetScoreListByKgtid(int.Parse(row["KgtID"].ToString()));
        foreach (DataRow scoreRow in scoreList.Rows)
	{
        if (scoreRow["DxtScore"].ToString() != "-1")
        {
            scoreStr += "单选题：" + scoreRow["DxtScore"] + "分\t";
            score += float.Parse(scoreRow["DxtScore"].ToString());
        }
        if (scoreRow["DuoxtScore"].ToString() != "-1")
        {
            scoreStr += "多选题：" + scoreRow["DuoxtScore"] + "分\t";
            score += float.Parse(scoreRow["DuoxtScore"].ToString());
        }
        if (scoreRow["PdtScore"].ToString() != "-1")
        {
            scoreStr += "判断题：" + scoreRow["PdtScore"] + "分\t";
            score += float.Parse(scoreRow["PdtScore"].ToString());
        }
        if (scoreRow["ZgtScore"].ToString() != "-1")
        {
            scoreStr += "简答题：" + scoreRow["ZgtScore"] + "分\t";
            score += float.Parse(scoreRow["ZgtScore"].ToString());
        }
	}
    %> 
  <TR class="ui-widget-content ui-datatable-even" role="row" data-ri="0">
    <TD role="gridcell" 
      style="width: 200px !important; text-align: left;"><%=row["SjName"].ToString() %></TD>
    <TD role="gridcell" 
      style="text-align: left;" class="auto-style4">
        <%foreach (DataRow qtRow in questionTypes.Rows)
       {
           if (qtRow["TxName"].ToString().Equals("简答题"))
               type = 1;
              %>
           <SPAN class="tip">题型：<%=qtRow["TxName"] %>/题数：<%=qtRow["TxCount"] %>/总分：<%=qtRow["Txzf"] %></SPAN><BR>
      <% } %>
    </TD>
    <TD role="gridcell" style="width: 50px; text-align: center;"><SPAN class="tip"><%=type==1?"综合评分":"智能评分" %></SPAN><BR></TD>
    <TD role="gridcell" 
      style="text-align: center;" class="auto-style6"><SPAN 
      class="tip"><%=scoreStr %></SPAN><BR></TD>
    <TD role="gridcell" 
      style="width: 80px !important; text-align: center;"><SPAN style="color: red; font-weight: bold;"><%=score %></SPAN>/<SPAN 
      style="color: green; font-weight: bold;"><%=sumScore %></SPAN></TD>
  </TR>
    <% } %>  
  </TBODY></TABLE></DIV>
<DIV class="ui-paginator ui-paginator-bottom ui-widget-header ui-corner-bottom" 
id="myForm:j_idt61_paginator_bottom">
<SPAN class="ui-paginator-first ui-state-default ui-corner-all ui-state-disabled"><SPAN class="ui-icon ui-icon-seek-first">p</SPAN></SPAN>
<SPAN class="ui-paginator-prev ui-state-default ui-corner-all ui-state-disabled"><SPAN class="ui-icon ui-icon-seek-prev">p</SPAN></SPAN>
<SPAN class="ui-paginator-pages">
<SPAN class="ui-paginator-page ui-state-default ui-state-active ui-corner-all">1</SPAN>
</SPAN>
<SPAN class="ui-paginator-next ui-state-default ui-corner-all"><SPAN class="ui-icon ui-icon-seek-next">p</SPAN></SPAN>
<SPAN class="ui-paginator-last ui-state-default ui-corner-all"><SPAN class="ui-icon ui-icon-seek-end">p</SPAN></SPAN></DIV></DIV>

</DIV></DIV>


</FORM></BODY></HTML>

