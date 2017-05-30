<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamList.aspx.cs" Inherits="exam_ExamList" %>
<%@Import Namespace="System.Data" %>
<%@ Import Namespace="ExaminationBLL" %> 

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML lang="en" xmlns="http://www.w3.org/1999/xhtml"><HEAD><META content="IE=10.000" http-equiv="X-UA-Compatible">
<LINK href="css_js/theme.css.css" rel="stylesheet" type="text/css">
<LINK href="css_js/primefaces.css.css" rel="stylesheet" type="text/css">
<LINK href="css_js/clock.css.css" rel="stylesheet" type="text/css">
<SCRIPT src="css_js/jquery.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/jquery-plugins.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/primefaces.js.js" type="text/javascript"></SCRIPT>
<SCRIPT src="css_js/clock.js.js" type="text/javascript"></SCRIPT>                      
<LINK href="css_js/rerebbs.css" rel="stylesheet" type="text/css">         
<LINK href="css_js/rerebbs_a.css" rel="stylesheet" type="text/css">
<META name="GENERATOR" content="MSHTML 10.00.9200.16635">
    <style type="text/css">
        .auto-style1 {
            background: url("/exam2/javax.faces.resource/images/ui-bg_highlight-hard_15_459e00_1x100.png.jspx?ln=primefaces-south-street") repeat-x 50% 50% rgb(69, 158, 0);
            border: 1px solid rgb(50, 126, 4);
            color: rgb(255, 255, 255);
            font-weight: bold;
            width: 154px;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style3 {
            width: 279px;
        }
        .SPEN{
             font-size:12px;
             color:red;
             display:none;
             text-align:center;
        }
    </style>
    <script type="text/javascript">
        function textValues() {
            if ($("#Elspen").val() != null) {
                location.href = "ExamList.aspx?action=Elspenvlaues&sjName=" + $("#Elspen").val();
            }
        }
        $(document).ready(function () {
            $("#Elspen").focus(function () {
                $("#spen").css("display", "block");
            });
            $("#Elspen").blur(function () {
                $("#spen").css("display", "none");
            });
        })
    </script>
</HEAD>
<BODY> 
<FORM name="myForm" runat="server" id="myForm" action="" enctype="application/x-www-form-urlencoded" method="post">
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<INPUT name="myForm" type="hidden" value="myForm"> 
<DIV class="ui-dialog ui-widget ui-widget-content ui-overlay-hidden ui-corner-all ui-shadow" 
id="myForm:login1">

</DIV>
<DIV class="ui-notificationbar ui-widget ui-widget-content" id="myForm:j_idt30" 
style="padding: 0px; height: 41px;">                  
<DIV style="margin: 0px auto; width: 960px;">
<DIV style="margin: 9px 12px 0px 640px; border: 0px solid red; width: 317px; text-align: right; position: absolute; z-index: 500;">
<asp:UpdatePanel runat="server"><ContentTemplate>
    <SPAN class="ui-clock ui-widget ui-widget-header ui-corner-all" runat="server" id="spannowtime"></SPAN>
    <asp:Timer ID="timer1" runat="server" OnTick="timer1_Tick" Interval="1000" Enabled="true"></asp:Timer>
</ContentTemplate>
<Triggers >
    <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>    

</DIV>
<DIV><SPAN id="myForm:j_idt34">
<TABLE>
  <TBODY>
  <TR>
    <TD><SPAN class="topTip">欢迎您&nbsp;<%=Hello%>！</SPAN></TD> 
    <TD>
      <DIV class="ui-menu ui-menubar ui-widget ui-widget-content ui-corner-all ui-helper-clearfix" 
      id="myForm:j_idt39" role="menubar" style="border: 0px solid red; width: 800px; background-color: inherit;">
      <UL class="ui-menu-list ui-helper-reset">
        <LI class="ui-menuitem ui-widget ui-corner-all" role="menuitem"><A 
        class="ui-menuitem-link ui-corner-all topNav" id="myForm:j_idt40" href="#"><SPAN class="ui-menuitem-text">参加考试</SPAN></A></LI>
       
        <LI class="ui-widget ui-menuitem ui-corner-all ui-menu-parent topNav newMenuNav" 
        role="menuitem" aria-haspopup="true"><A class="ui-menuitem-link ui-corner-all" 
        href="javascript:location.href='MyExamList.aspx'"><SPAN 
        class="ui-menuitem-text">我的考卷</SPAN></A>
        </LI>
        <LI class="ui-menuitem ui-widget ui-corner-all" role="menuitem">
            <A class="ui-menuitem-link ui-corner-all topNav" id="myForm:j_idt120" 
        href="javascript:location.href='../Exit.aspx'"></SPAN><SPAN 
        class="ui-menuitem-text">退出</SPAN></A></LI></UL></DIV>
<SCRIPT id="myForm:j_idt39_s" type="text/javascript">PrimeFaces.cw('Menubar', 'widget_myForm_j_idt39', { id: 'myForm:j_idt39', autoDisplay: true });</SCRIPT>
    </TD></TR></TBODY></TABLE></SPAN>                     </DIV></DIV></DIV>
<SCRIPT id="myForm:j_idt30_s" type="text/javascript">$(function () { PrimeFaces.cw('NotificationBar', 'bar11', { id: 'myForm:j_idt30', position: 'top', effect: 'slide', effectSpeed: 'normal', autoDisplay: true }); });</SCRIPT>
             
<DIV style="margin: 0px auto; width: 960px;">
<DIV style="height: 38px;"></DIV>
<DIV style="border: 0px solid green; height: 140px; text-align: center; overflow: hidden; padding-bottom: 0px; margin-bottom: 0px; z-index: 1;"><IMG 
id="myForm:adv2" style="margin: 0px; border: 1px solid gray; width: 957px; height: 140px;" 
src="../images/login/horf1.png">      
           </DIV><!--
                &lt;ui:include src=&quot;PictureShow_1.xhtml&quot;/&gt;
                -->
<DIV class="ui-panel ui-widget ui-widget-content ui-corner-all mainPanel" id="myForm:mainPanel" 
style="width: 957px;">
<DIV class="ui-panel-content ui-widget-content" id="myForm:mainPanel_content">   
              
<SCRIPT language="javascript" type="text/javascript">
    function aabbcc(url) {
        var scrWidth = screen.availWidth;
        var scrHeight = screen.availHeight;
        var self = window.showModalDialog(url, '', "dialogWidth=" + scrWidth + "px;dialogHeight=" + scrHeight + "px");
    }
</SCRIPT>

<DIV class="ui-datatable ui-widget" id="myForm:examDc" style="width: 100%;">
<DIV class="ui-datatable-tablewrapper">
<TABLE role="grid">
  <THEAD id="myForm:examDc_head">
  <TR role="row">
    <TH class="ui-state-default ui-filter-column" id="myForm:examDc:j_idt48" 
    role="columnheader" 
      style="width: 279px; text-align: left;"><SPAN> 
      <DIV style="width: 100%; text-align: center;">试卷名称 </DIV></SPAN>
        <input type="text" id="Elspen" name="Elspen" onchange="textValues()" runat="server" class="ui-column-filter ui-inputfield ui-inputtext ui-widget ui-state-default ui-corner-all" />
    <span class="SPEN" id="spen"  >光标离开有效</span>
    <TH class="ui-state-default" id="myForm:examDc:j_idt55" role="columnheader" 
    style="text-align: center;"><SPAN>所属科目</SPAN></TH>
    <TH class="ui-state-default" id="myForm:examDc:j_idt59" role="columnheader" 
    style="width: 80px !important; text-align: center;"><SPAN>考试时长</SPAN></TH>
    <TH class="ui-state-default" id="myForm:examDc:j_idt63" role="columnheader" 
    style="text-align: center;"><SPAN>总分</SPAN></TH>
    <TH class="auto-style1" id="myForm:examDc:j_idt68" role="columnheader" 
    style="text-align: center;"><SPAN>题型</SPAN></TH>
    <TH class="ui-state-default" id="myForm:examDc:j_idt78" role="columnheader" 
    style="text-align: center;"><SPAN>开始考试</SPAN></TH></TR></THEAD>
  <TBODY class="ui-datatable-data ui-widget-content" id="myForm:examDc_data">
  
 <!-- 第一行-->
 <%
     if (testPaperList.Rows.Count <= 0)
     {%>
        <TR class="ui-widget-content ui-datatable-even" role="row" data-ri="0">
           <TD role="gridcell" colspan="6" 
              style="width: 80px !important; text-align: center;"><SPAN 
              class="tip">暂无试卷信息</SPAN><BR></TD>
        </TR>
     <%}
     else
     {
         foreach (DataRow row in testPaperList.Rows)
         {%>
  <TR class="ui-widget-content ui-datatable-even" role="row" data-ri="0">
    <TD role="gridcell" 
      style="text-align: left;" class="auto-style3"><%=row["SjName"].ToString()%><BR><SPAN 
      class="tip">开放时间：<%=DateTime.Parse(row["KsTime"].ToString()).ToString("yyyy-MM-dd hh:mm")%></SPAN><BR><SPAN 
      class="tip">结束时间：<%=DateTime.Parse(row["JsTime"].ToString()).ToString("yyyy-MM-dd hh:mm")%></SPAN></TD>
    <TD role="gridcell" style="text-align: center;"><SPAN 
      class="tip"><%=row["KmName"].ToString()%></SPAN><BR></TD>
    <TD role="gridcell" 
      style="width: 80px !important; text-align: center;"><SPAN 
      class="tip"><%=PublicClass.GetMinutes(DateTime.Parse(row["KsTime"].ToString()), DateTime.Parse(row["JsTime"].ToString()))%>分钟</SPAN><BR></TD>
    <TD role="gridcell" 
      style="width: 80px !important; text-align: center;"><SPAN 
      class="tip"><%=TbQuestionTypesManager.GetSumScoreBySjid(int.Parse(row["SjID"].ToString()))%>分</SPAN><BR></TD>
    <TD role="gridcell" style="text-align: center;" class="auto-style2">
      <TABLE class="threadColumn special1" style="height: 100px; text-align: left;" 
      cellspacing="0" cellpadding="0">
        <TBODY>
            <%
             DataTable quesTypes = TbQuestionTypesManager.GetAllQuestionTypesBySjid(int.Parse(row["SjID"].ToString()));
             if (quesTypes.Rows.Count >= 0)
             {%>
                <TR>
                <%
                 int count = 0;
                 foreach (DataRow quesTypeRow in quesTypes.Rows)
                 {
                     count++;%>
                        <TD><SPAN class="tip"><%=quesTypeRow["TxName"]%>：<%=quesTypeRow["TxCount"]%></SPAN></TD>
                    <%
                     if (count >= 2)
                         break;
                 }
                    %>
                    </TR>
                    <%
             }
             if (quesTypes.Rows.Count >= 3)
             {%>
                   <TR>
                      <TD><SPAN class="tip"><%=quesTypes.Rows[2]["TxName"]%>：<%=quesTypes.Rows[2]["TxCount"]%></SPAN></TD>
                       <%if (quesTypes.Rows.Count == 4)
                         {%>
                       <TD><SPAN class="tip"><%=quesTypes.Rows[3]["TxName"]%>：<%=quesTypes.Rows[3]["TxCount"]%></SPAN></TD>
                       <%}%>
                      
                   </TR> 
                <%} %>
        </TBODY></TABLE></TD>
    <TD role="gridcell" style="text-align: center;">
        <% Tobj.SjID = int.Parse(row["SjID"].ToString());
           Tobj.Zt = 2;
           DataTable dtAnswer = tbAnswerCardManager.getAnswerCard2(Tobj, Tobj.YhID);
           if (dtAnswer.Rows.Count > 0)
           {
               Tobj.KgtID = int.Parse(tbAnswerCardManager.getAnswerCard2(Tobj, Tobj.YhID).Rows[0]["KgtID"].ToString());
           }
           else
           {
               Tobj.Zt = 3;
               dtAnswer = tbAnswerCardManager.getAnswerCard2(Tobj, Tobj.YhID);
               if (dtAnswer.Rows.Count > 0)
               {
                   Tobj.KgtID = int.Parse(tbAnswerCardManager.getAnswerCard2(Tobj, Tobj.YhID).Rows[0]["KgtID"].ToString());
               }
               else
               {
                   Tobj.KgtID = 0;
               }
           }
           nowTs = new ExaminationModels.TbScore();
           nowTs.KgtID = Tobj.KgtID;
           nowTs = TbScoreManager.getScore(nowTs);
           
           
            if (row["Zt"].ToString().Equals("2")&&nowTs.Zt!=2)
          { %>
        <BUTTON name="myForm:examDc:0:j_idt80" 
      class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
      id="myForm:examDc:0:j_idt80" onClick="aabbcc('/student/Test.aspx?sjid=<%=row["SjID"]%>');" 
      type="submit">
            <%
              if (nowTs.Zt == 0)
              { %>
                 <SPAN class="ui-button-text ui-c">开始考试</SPAN>
              <%}
              else if (nowTs.Zt == 1)
              { %>
                 <span class="ui-button-text ui-J">继续考试</span>
             <% }%>
        </BUTTON>
<SCRIPT id="myForm:examDc:0:j_idt80_s" type="text/javascript">PrimeFaces.cw('CommandButton', 'widget_myForm_examDc_0_j_idt80', { id: 'myForm:examDc:0:j_idt80' });</SCRIPT>
        <%}
            else if (nowTs.Zt == 2 && row["Zt"].ToString().Equals("2"))
                {%>
                <span class="ui-button-text ui-K">考试结束</span>
              <%}
                  else
                  {
                      if (nowTs.Zt == 0) {
                          %>
                        nowTs.Zt == 0
                         <%
                      }
                      %>
            暂不可用
             <% } %>
    </TD></TR>
      <% }
     } %>
  </TBODY>

</TABLE></DIV>
<DIV class="ui-paginator ui-paginator-bottom ui-widget-header ui-corner-bottom" 
id="myForm:examDc_paginator_bottom"><SPAN class="ui-paginator-first ui-state-default ui-corner-all ui-state-disabled"><SPAN 
class="ui-icon ui-icon-seek-first">p</SPAN></SPAN><SPAN class="ui-paginator-prev ui-state-default ui-corner-all ui-state-disabled"><SPAN 
class="ui-icon ui-icon-seek-prev">p</SPAN></SPAN><SPAN class="ui-paginator-pages"><SPAN 
class="ui-paginator-page ui-state-default ui-state-active ui-corner-all">1</SPAN></SPAN><SPAN 
class="ui-paginator-next ui-state-default ui-corner-all ui-state-disabled"><SPAN 
class="ui-icon ui-icon-seek-next">p</SPAN></SPAN><SPAN class="ui-paginator-last ui-state-default ui-corner-all ui-state-disabled"><SPAN 
class="ui-icon ui-icon-seek-end">p</SPAN></SPAN></DIV></DIV>

</DIV></DIV>
</FORM></BODY></HTML>

