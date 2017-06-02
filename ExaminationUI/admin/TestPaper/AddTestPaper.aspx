<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTestPaper.aspx.cs" Inherits="admin_TestPaper_AddTestPaper" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../../css/style.css" rel="stylesheet" />
<script type="text/javascript" src="../../javascript/datatimer.js"></script>
<script type="text/javascript" src="../../javascript/jquery.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.10.0.min.js"></script>
<script type="text/javascript" src="../../javascript/YanZheng.js"></script>
<title></title>
          
<script type="text/javascript">
    $(document).ready(function () {
        $("#Button2").click(function () {
            $("#txtName").val("");
            $("#SpecID").val(0);
            $("#startTime").val("");
            $("#endTime").val("");
            $("#txtdxcount").val("");
            $("#txtdxzf").val("");
            $("#txtduocount").val("");
            $("#txtduozf").val("");
            $("#txtpdcount").val("");
            $("#txtpdzf").val("");
            $("#txtjdcount").val("");
            $("#txtjdzf").val("");
            $("#txtRemark").val("");
        });
    });
</script>
    <style type="text/css">
    body {
    margin-left:5px;
    margin-top:5px;
    margin-right:0px;
    margin-bottom:0px;
    }
    tr {
        height:35px;
        line-height:35px;
    }
    .td1 {
        width:30%;
        text-align:left;
        width:90px;
        padding-left:130px
        }
    .style1 {
    border:1px solid #9ad452;
    }
    #tbimg td{
    padding-right:20px; 
    padding-bottom:10px;
    text-align:right;
}
    .auto-style1 {width: 550px;}
    .red {
    color:red;}
        .auto-style2 {width: 150px; }
        .auto-style3 {width: 40px; }
        .auto-style5 {width:45px;}
        #endTime {width: 150px; }
        #startTime {width: 150px;}
        .file {
            background-color: #ffffff;
            border: #d5d5d5 0px solid;
        }
</style>

</head>
<body style="font-size:12px;">
     <form id="form1" runat="server">
        <table style="background-color:#f3ffe3 ;" class="style1"  >
            <tr>
                <td class="td1">试卷名称：</td>
                <td  style="text-align:left" class="auto-style1">
                    <asp:TextBox ID="txtName" CssClass="text-input" runat="server" MaxLength="25" Width="370px"></asp:TextBox>
                    <span id="spanname" class="red"></span></td>
            </tr>
             <tr>
                <td class="td1">所属专业：</td>
                <td  style="text-align:left" class="auto-style1">
                        <asp:DropDownList ID="SpecID" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddlSpec_SelectedIndexChanged" ></asp:DropDownList>
                    <span id="spanzy" class="red" width="50px" align="left"></span> </td>
                </tr>
            <tr>
                <td class="td1">所属科目：</td>
                <td  style="text-align:left" class="auto-style1">
                        <asp:DropDownList ID="ddlSubject" runat="server" Width="160px"></asp:DropDownList><span id="spansubject" class="red" width="50px" align="left"></span> </td>
                </tr>
                <tr>
                    <td class="td1">上传试卷：</td>
                    <td class="auto-style1"><asp:FileUpload ID="FileUpload1" CssClass="file" runat="server" Height="27px" Width="383px" />
                       <br /><asp:Label ID="lblFileMessage" runat="server" style="color:red;"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td  class="td1">开始考试时间：</td>
                    <td style="text-align:left" class="auto-style1"><span style="width:160px">
                        <input runat="server" class="sang_Calender" style="border-radius: 16px; -moz-border-radius: 16px; -webkit-border-radius: 16px;padding: 6px; font-size: 13px; border: 1px solid #d5d5d5;color: #333;" id="startTime" name="startTime"/>
                        <span id="spanstarttime" class="red"></span></span></td>
                </tr>
                <tr>
                    <td class="td1">考试结束时间：</td>
                    <td  style="text-align:left" class="auto-style1"><span style="width:30%">
                        <input runat="server" class="sang_Calender" style="border-radius: 16px; -moz-border-radius: 16px; -webkit-border-radius: 16px;padding: 6px; font-size: 13px; border: 1px solid #d5d5d5;color: #333;" id="endTime" name="endTime"/>
                        <span id="spanendtime" class="red"></span></span></td>
                </tr>
                <tr >
                    <td  class="td1"><span>单选题&nbsp;&nbsp;</span><span >题数：</span></td>
                    <td  style="text-align:left" class="auto-style1">
                        <table class="auto-style1" cellpadding="0" cellspacing="0"s>
                            <tr>
                                <td class="auto-style2"><asp:TextBox ID="txtdxcount" runat="server" CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td style="text-align:left" class="auto-style3"><span id="spandxts" class="red"></span></td>
                                <td class="auto-style5">总分:</td>
                                <td class="auto-style2"><asp:TextBox ID="txtdxzf" runat="server"  CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td  style="text-align:left" class="auto-style3"><span class="red"  id="spandxfs"></span></td>
                                <td style="width:125px"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td  class="td1"><span>多选题&nbsp;&nbsp;</span><span >题数：</span></td>
                    <td  style="text-align:left" class="auto-style1">
                     <table  class="auto-style1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="auto-style2"><asp:TextBox ID="txtduocount" runat="server" Width="150px" CssClass="text-input"></asp:TextBox></td>
                            <td style="text-align:left" class="auto-style3"><span class="red" style="width:50px" id="spanduoxts"></span></td>
                            <td class="auto-style5">总分:</td>
                            <td class="auto-style2"><asp:TextBox ID="txtduozf" Width="150px" runat="server"  CssClass="text-input"></asp:TextBox></td>
                            <td style="text-align:left" class="auto-style3"><span class="red" style="width:50px" id="spanduoxfs"></span></td>
                             <td style="width:125px"></td>
                        </tr>
                    </table>
                 </td>
                </tr>
                <tr>
                    <td  class="td1"><span>判断题&nbsp;&nbsp;</span><span >题数：</span></td>
                    <td  style="text-align:left" class="auto-style1">
                        <table  class="auto-style1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="auto-style2"><asp:TextBox ID="txtpdcount" runat="server"  CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td style="text-align:left" class="auto-style3"><span class="red" id="spanpdtx"></span></td>
                                <td class="auto-style5">总分:</td>
                                <td class="auto-style2"><asp:TextBox ID="txtpdzf" runat="server"  CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td style="text-align:left" class="auto-style3"><span id="spanpdfs" class="red"></span></td>
                                <td style="width:125px"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr >
                    <td  class="td1"><span>简答题&nbsp;&nbsp;</span><span >题数：</span></td>
                    <td  style="text-align:left" class="auto-style1">
                        <table  class="auto-style1" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="auto-style2"><asp:TextBox ID="txtjdcount" runat="server"  CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td style="text-align:left" class="auto-style3"><span id="spanjdtx" class="red"></span></td>
                                <td class="auto-style5">总分:</td>
                                <td class="auto-style2"><asp:TextBox ID="txtjdzf" runat="server"  CssClass="text-input" Width="150px"></asp:TextBox></td>
                                <td style="text-align:left" class="auto-style3"><span class="red" id="spanjdfs"></span></td>
                                  <td style="width:125px"></td>
                            </tr>
                        </table>
                      </td> 
                </tr>
                <tr>
                     <td  class="td1"><span>备  注：</span></td>
                     <td style="text-align:left" class="auto-style1"><asp:TextBox ID="txtRemark" runat="server" MaxLength="50" style="overflow:hidden;" TextMode="MultiLine" Wrap="true" Width="380px" Height="75px"></asp:TextBox></td>
                 </tr>
            <tr>
                <td colspan="2" style="text-align:center;vertical-align:middle;">
                    <asp:button ID="Button1" runat="server" text=" 提  交 " CssClass="button" OnClientClick="return CheckTestPaper()"  OnClick="Button1_Click" />
                    <asp:button style="margin-left:30px;" ID="Button2" CssClass="button" runat="server" text=" 重  置 " />
                    <asp:Label style="margin-left:30px; color:red;" runat="server" ID="lblSubMessage"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
<script language="javascript" src="../../javascript/calendar.js"></script>
</body>
</html>

