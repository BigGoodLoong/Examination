<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportStudent.aspx.cs" Inherits="admin_Student_ImportStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body {
	        margin-left: 0px;
	        margin-top: 0px;
	        margin-right: 0px;
	        margin-bottom: 0px;
            font-size:12px;
        }
        .lefttd {
            width:100px;
            text-align:right;
            vertical-align:middle;
        }
        .tableborder {
            border-collapse:collapse;
            border:0px solid;
            width:100%;
        }
        hr {
            border:#caced1 2px solid;
            width:95%;
        }
        ul li {
            list-style:none;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
   <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
           <td style="height:30px;width:13px;background-image:url(../../html/tab/images/tab_03.gif)">&nbsp;</td>
           <td style="background-image:url(../../html/tab/images/tab_05.gif)">
               <b>- 学员导入导出 -</b>
           </td>
           <td style="height:30px;width:4px;background-image:url(../../html/tab/images/tab_07.gif)">&nbsp;&nbsp;&nbsp;&nbsp;</td>
      </tr>
      <tr>
           <td style="height:100%;width:13px;background-image:url(../../html/tab/images/tab_12.gif)">&nbsp;</td>
           <td style="background-color:#f3ffe3;">
               <table class="tableborder">
                   <tr>
                       <td colspan="2"><hr /></td>
                   </tr>
                   <tr height="120">
                       <td class="lefttd">导入用户：</td>
                       <td>
                           <ul>
                               <li>
                                   <asp:FileUpload ID="FileUpload1" runat="server" Width="280" height="25"  />
                                   <asp:Button ID="BeginImport" runat="server" Text="开始导入" OnClick="BeginImport_Click" />
                                   <span style="margin-left:50px;"><asp:Label ID="lblImportResult" runat="server" style="color:red;" Text=""></asp:Label></span>
                               </li>
                               <li style="margin-top:30px; color:red;">注：导入的用户文件必须严格遵守本系统的格式要求，保险起见，导入新用户文件前先将原用户导出。</li>
                           </ul>
                       </td>
                   </tr>    
                   <tr>
                       <td colspan="2"><hr /></td>
                   </tr>
                   <tr height="80">
                       <td class="lefttd">导出用户：</td>
                       <td>
                           <ul>
                               <li><asp:Button ID="BtnExport" runat="server" Text="导出用户" OnClick="BtnExport_Click" /></li>
                           </ul>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2"><hr /></td>
                   </tr>
                   <tr height="80">
                       <td class="lefttd">清空用户：</td>
                       <td>
                           <ul>
                               <li>
                                   <asp:Button ID="ClearBtn" runat="server" Text="清空用户" OnClick="ClearBtn_Click" />
                                   <span style="margin-left:50px;"><asp:Label ID="lblClear" runat="server" Text="" style="color:red;"></asp:Label></span>
                               </li>
                           </ul>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2"><hr /></td>
                   </tr>
                   <tr height="80">
                       <td class="lefttd">用户模版：</td>
                       <td>
                           <ul>
                               <li><a href="file/StudentInfoTemplate.xls">StudentInfoTemplate.xls</a></li>
                           </ul>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2"><hr /></td>
                   </tr>
               </table>
           </td>
           <td style="height:100%;width:4px;background-image:url(../../html/tab/images/tab_16.gif);background-position-x:5px;">&nbsp;</td>
      </tr>
      <tr>
           <td style="height:30px;width:13px;background-image:url(../../html/tab/images/tab_20.gif)">&nbsp;</td>
           <td style="background-image:url(../../html/tab/images/tab_21.gif)"></td>
           <td style="height:30px;width:4px;background-image:url(../../html/tab/images/tab_22.gif)">&nbsp;</td>
      </tr>
    </table>
    </form>
</body>
</html>

