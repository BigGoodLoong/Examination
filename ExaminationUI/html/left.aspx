<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="html_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>����ҳ��</title>

<script src="/javascript/prototype.lite.js" type="text/javascript"></script>
<script src="/javascript/moo.fx.js" type="text/javascript"></script>
<script src="/javascript/moo.fx.pack.js" type="text/javascript"></script>
<style>
body {
	font:12px Arial, Helvetica, sans-serif;
	color: #000;
	background-color: #EEF2FB;
	margin: 0px;
}
#container {
	width: 182px;
}
H1 {
	font-size: 12px;
	margin: 0px;
	width: 182px;
	cursor: pointer;
	height: 30px;
	line-height: 20px;
	background-color:#d4f0b1;
}

H1 a {
	display: block;
	width: 182px;
	color: #000;
	height: 30px;
	text-decoration: none;
	moz-outline-style: none;
	background-image: url(images/menu_bgS.gif);
	background-repeat: no-repeat;
	line-height: 30px;
	text-align: center;
	margin: 0px;
	padding: 0px;
}
.content{
	width: 182px;
	height: 26px;
	
}
.MM ul {
	list-style-type: none;
	margin: 0px;
	padding: 0px;
	display: block;
}
.MM li {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	list-style-type: none;
	display: block;
	text-decoration: none;
	height: 26px;
	width: 182px;
	padding-left: 0px;
}
.MM {
	width: 182px;
	margin: 0px;
	padding: 0px;
	left: 0px;
	top: 0px;
	right: 0px;
	bottom: 0px;
	clip: rect(0px,0px,0px,0px);
}
.MM a:link {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.MM a:visited {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}
.MM a:active {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.MM a:hover {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	font-weight: bold;
	color: #006600;
	background-image: url(images/menu_bg2.gif);
	background-repeat: no-repeat;
	text-align: center;
	display: block;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}
</style>
</head>

<body>
<table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
  <tr>
    <td width="182" valign="top">
   <div id="container">
    <h1 class="type"><a href="javascript:void(0)">�Ծ���Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
		  <li><a href="../admin/TestPaper/EditTestPaper.aspx" target="I1">�Ծ��б���Ϣ</a></li>
          <li><a href="../admin/TestPaper/AddTestPaper.aspx" target="I1">�ϴ��Ծ�</a></li>
        </ul>
      </div>

        <h1 class="type"><a href="javascript:void(0)">������Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
		  <li><a href="../admin/AnswerCard/EditAnswer.aspx" target="I1">���������Ϣ</a></li>
        </ul>
      </div>

      <h1 class="type"><a href="javascript:void(0)">�ɼ���Ϣ����</a></h1>
      <div class="content">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
            </tr>
          </table>
        <ul class="MM">
          <li><a href="../admin/ExamResult/TeacherSelectScore.aspx" target="I1">�ɼ��б���Ϣ</a></li>
        </ul>
      </div>
       <%if (status.Equals("1"))
         {%>
     <h1 class="type"><a href="javascript:void(0)">������Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
          <li><a href="../admin/Student/EditStudent.aspx" target="I1">���ѧ����Ϣ</a></li>
          <li><a href="../admin/Student/ImportStudent.aspx" target="I1">����ѧ����Ϣ</a></li>
        </ul>
      </div>

      <h1 class="type"><a href="javascript:void(0)">��ʦ��Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
          <li><a href="../admin/Teacher/EditTeacher.aspx" target="I1">��ʦ������Ϣ</a></li>
        </ul>
      </div>

      <h1 class="type"><a href="javascript:void(0)">רҵ��Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
		  <li><a href="../admin/Speciality/AddSpeciality.aspx" target="I1">רҵ������Ϣ</a></li>
        </ul>
      </div>

      <h1 class="type"><a href="javascript:void(0)">��Ŀ��Ϣ����</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
          <li><a href="../admin/Subject/EditSubject.aspx" target="I1">��ѯ��Ŀ��Ϣ</a></li>
        </ul>
      </div>

       <h1 class="type"><a href="javascript:void(0)">�༶��Ϣ����</a></h1>
      <div class="content">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                  <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
              </tr>
          </table>
          <ul class="MM">
              <li><a href="../admin/Class/EditClass.aspx" target="I1">�༶������Ϣ</a></li>
          </ul>
      </div>
       <% } %>
    </div>

        <script type="text/javascript">
            var contents = document.getElementsByClassName('content');
            var toggles = document.getElementsByClassName('type');

            var myAccordion = new fx.Accordion(
                toggles, contents, { opacity: true, duration: 400 }
            );
            myAccordion.showThisHideOpen(contents[0]);
	</script>
        </td>
  </tr>
</table>
</body>
</html>

