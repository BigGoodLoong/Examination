
document.write('<script type="text/javascript" src="jquery-1.10.0.min.js"></script>')
 
/******************************************EditTeacher.aspx---------------即教师信息页面******************************/
//新增教师信息时判断姓名，账号，密码、专业是否为空
function CheckTeacher() {
    if ($.trim($("#teacheruser").val()) == "")/*教师用户名（或账号）为空*/ {
        $("#spanzh").text("*");
        return false;
    }
    else if ($.trim($("#teachername").val()) == "")/*教师姓名为空*/ {
        $("#spanxm").text("*");
        $("#spanzh").text("");
        return false;
    }
    else if ($("#teacherzy").val() == 0)/*专业名为空*/ {
        $("#spanzy").text("*");
        $("#spanzh").text("");
        $("#spanxm").text("");
        return false;
    }
    else if ($("#teacherpwd").val() == "")/*密码为空*/ {
        $("#spanmm").text("*");
        $("#spanzh").text("");
        $("#spanxm").text("");
        $("#spanzy").text("");
        return false;
    }
    else/*均不为空*/ {
        $("#spanmm").text("");
        $("#spanzh").text("");
        $("#spanxm").text("");
        $("#spanzy").text("");
        return true;
    }

}
/*******************************所有页面的跳转验证***************************************/
function JumpPage()
{
    var pages = document.getElementById("spanpages").innerHTML;/*总页面数*/
    var page = document.getElementById("tzpage").value;/*当前输入的跳转页面数*/
    if ($.trim($("#tzpage").val()) != "")/*如果当前输入的页面数不为空*/
    {
        if (isNaN(page) == false && page.indexOf(".", 0) < 0)/*当前输入的页面数是数字且不包含小数点*/
        {
            if (parseInt(page) <= pages && parseInt(page) > 0) /*当前输入的页面数的范围正确*/ {
                return true;
            }
            else {
                alert("不存在当前页面");
                document.getElementById("tzpage").value = "";
                return false;
            }
        }
        else {
            alert("只能输入正整数");
            document.getElementById("tzpage").value = "";
            return false;
        }
    }
    else {
        alert("请输入要跳转的页面数");
        document.getElementById("tzpage").value = "";
        return false;
    }
}
/*-----------------------------------------上一页-------------------------------*/
function BackPage()
{
    var nowPage = $("#spannowpage").text()/*当前页面数*/
    if (parseInt(nowPage) - 1 > 0)
        return true
    else {
        return false;
    }
}
/*-----------------------------------------下一页-------------------------------*/
function NextPage()
{
    var pages = $("#spanpages").text();/*总页面数*/
    var nowPage = $("#spannowpage").text()/*当前页面数*/
    if (parseInt(nowPage) + 1 <= parseInt(pages)) {
        return true;
    }
    else
        return false;
}
/***********************************EditClass.aspx--------------即班级信息页面**************************************/
//新增（或修改）班级信息时判断班级名、年级、专业是否为空
function CheckClass() {
    if ($.trim($("#textName").val()) == "")/*班级名为空*/ {
        $("#spanclassname").text("*");
        return false;
    }
    else if ($.trim($("#textNj").val()) == "")/*年级为空*/ {
        $("#spannj").text("*");
        $("#spanclassname").text("");
        return false;
    }
    else if ($("#textZy").val() == 0)/*专业为空*/ {
        $("#spannj").text("");
        $("#spanclassname").text("");
        $("#spanzy").text("*");
        return false;
    }
    else/*均不为空*/ {
        $("#spannj").text("");
        $("#spanclassname").text("");
        $("#spanzy").text("");
        return true;
    }
}

/*****************************TeacherSelectScore.aspx--------------即成绩信息页面*********************************/
//判断新增或修改学生成绩信息时科目名、学号、姓名、分数是否为空
function CheckScore()
{
    var arr = new Array("#spansubject", "#spanxh", "#spanname", "#spanscore");/*<span>标记的科目、学号、姓名、成绩*/
    if ($.trim($("#TextBox4").val()) == "")/*科目名为空*/
    {
        $("#spansubject").text("*");
        return false;
    }
    else if ($.trim($("#TextBox6").val()) == "") /*学号为空*/
    {
        $("#spanxh").text("*");
        for (i = 0; i < 1; i++) {
            $(arr[i]).text("");
        }
        return false;
    } else if ($.trim($("#TextBox7").val()) == "")/*姓名为空*/
    {
        $("#spanname").text("*");
        for (i = 0; i < 2; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#TextBox8").val()) == "")/*分数为空*/
    {
        $("#spanscore").text("*");
        alert("分数输入格式错误");
        for (i = 0; i < 3; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if (isNaN($.trim($("#TextBox8").val())) == true || parseFloat($.trim($("#TextBox8").val()))<0)/*输入的分数值不是数值型或分数小于0时*/
    {
        alert("分数输入格式错误");
        for (i = 0; i < 3; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
  
    else/*均不为空时*/
    {
        for (i = 0; i < 4; i++) {
            $(arr[i]).text("");
        }
        return true;
    }
}
/*********************************EditTestPaper.aspx-------------即试卷列表信息页面*****************************************************/
function CheckTestPaperInfo()
{
    var arr = new Array("#spansjname", "#spanstart", "#spanend");
    if ($.trim($("#sjnameid").val()) == "")/*试卷名称为空*/ {
        $("#spansjname").text("*");
        return false;
    }
    else if ($.trim($("#startTime").val()) == "") /*开始时间为空*/ {
        $("#spanstart").text("*");
        for (i = 0; i < 1; i++) {
            $(arr[i]).text("");
        }
        return false;
    } else if ($.trim($("#endTime").val()) == "")/*结束时间为空*/ {
        $("#spanend").text("*");
        for (i = 0; i < 2; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else {
        for (i = 0; i < 3; i++) {
            $(arr[i]).text("");
        }
        var NowTime = new Date();
        var NowTime = new Date();
        var week = "";
        switch (NowTime.getDay()) {
            case 0:
                week = "星期天";
                break;
            case 1:
                week = "星期一";
                break;
            case 2:
                week = "星期二";
                break;
            case 3:
                week = "星期三";
                break;
            case 4:
                week = "星期四";
                break;
            case 5:
                week = "星期五";
                break;
            case 6:
                week = "星期六";
                break;
        }

        var NowTime = NowTime.toLocaleString();/*系统当前时间*/
        NowTime = NowTime.replace('年', '/');
        NowTime = NowTime.replace('月', '/');
        NowTime = NowTime.replace('日', '');
        NowTime = NowTime.replace(week, '');
        NowTime = NowTime.replace(/-/g, "/");
        NowTime=new Date(NowTime);
        var str1 = $.trim($("#startTime").val()).replace(/-/g, "/");/*开始时间*/
        var DateOne = new Date(str1);
        var str2 = $.trim($("#endTime").val()).replace(/-/g, "/");/*结束时间*/
        var DateTwo = new Date(str2);
        var DateOneSecond = DateOne.getTime();/*开始时间的毫秒数*/
        DateOneSecond = DateOneSecond + 18000000;
        var DateTwoSecond = DateTwo.getTime();/*结束时间的毫秒数*/
        if (NowTime > DateOne)
        {
            alert("开始时间必须大于当前系统时间！");
            return false;
        }
        else if (DateOne >= DateTwo)
        {
            alert("结束时间必须大于开始时间！");
            return false;
        }
        else if(parseInt(DateTwoSecond) > parseInt(DateOneSecond)) {
            alert("结束时间大于开始时间需在0-300分钟之内！");
            return false;
        }
        else {
        return true;
    }
}
}

/*********************************AddTestPaper.aspx-------------即上传试卷页面*****************************************************/
function CheckTestPaper() {
    var arr = new Array("#spanname", "#spansubject", "#spanstarttime", "#spanendtime", "#spandxts", "#spandxfs", "#spanduoxts", "#spanduoxfs", "#spanpdtx", "#spanpdfs", "#spanjdtx", "#spanjdfs");
    var objFileUpload = document.getElementById("FileUpload1");//FileUpload 
    var FileName = new String(objFileUpload.value);//文件名 
    if ($.trim($("#txtName").val()) == "") {
        for (i = 0; i < 1; i++) {
            $(arr[i]).text("*");
        }
        return false;
    }
    else if ($("#ddlSubject").val() == "请选择..") /*科目*/ {
        $("#spansubject").text("*");
        for (i = 0; i < 1; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if (FileName == "")/*上传文件*/ {
        for (i = 0; i < 2; i++) {
            $(arr[i]).text("");
        }
        alert("请选择要上传的试卷");
        return false;
    }

    else if ($("#startTime").val() == "")/*开始时间*/ {
        $("#spanstarttime").text("*");
        for (i = 0; i < 2; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($("#endTime").val() == "")/*结束时间*/ {
        $("#spanendtime").text("*");
        for (i = 0; i < 3; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtdxcount").val()) == "" && $.trim($("#txtdxzf").val()) == "" && $.trim($("#txtduocount").val()) == "" && $.trim($("#txtduozf").val()) == "") {
        alert("题数不能均为空");
        for (i = 0; i < 4; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtdxcount").val()) != "" && ((isNaN($.trim($("#txtdxcount").val())) == true) || ($("#txtdxcount").val().indexOf(".", 0) > 0) || (parseInt($("#txtdxcount").val()) <= 0))) /*单选题数不为空且不是大于0的正整数时*/ {
        $("#spandxts").text("*");
        for (i = 0; i < 4; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtdxzf").val()) != "" && ((isNaN($.trim($("#txtdxzf").val())) == true) || ($("#txtdxzf").val().indexOf(".", 0) > 0) || (parseInt($("#txtdxzf").val()) <= 0)))/*单选题总分数不为空且不是大于0的正整数时*/ {
        $("#spandxfs").text("*");
        for (i = 0; i < 5; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtdxcount").val()) != "" && $.trim($("#txtdxzf").val()) == "")/*单选题题数不为空，但分数为空*/ {
        $("#spandxfs").text("*");
        for (i = 0; i < 5; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtduocount").val()) != "" && ((isNaN($("#txtduocount").val()) == true) || ($("#txtduocount").val().indexOf(".", 0) > 0) || (parseInt($("#txtduocount").val()) <= 0)))/*多选题题数不为空且不是大于0的正整数时*/ {
        $("#spanduoxts").text("*");
        for (i = 0; i < 6; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtduozf").val()) != "" && ((isNaN($("#txtduozf").val()) == true) || ($("#txtduozf").val().indexOf(".", 0) > 0) || (parseInt($("#txtduozf").val()) <= 0)))/*多选题总分不为空且不是大于0的正整数时*/ {
        $("#spanduoxfs").text("*");
        for (i = 0; i < 7; i++) {
            $(arr[i]).text("");
        }
        $("#spandxts").text("");
        return false;
    }
    else if ($.trim($("#txtduocount").val()) != "" && $.trim($("#txtduozf").val()) == "")/*多选题题数不为空，但分数为空*/ {
        $("#spanduoxfs").text("*");
        for (i = 0; i < 7; i++) {
            $(arr[i]).text("");
        }
        $("#spandxts").text("");
        return false;
    }
    else if ($.trim($("#txtpdcount").val()) != "" && ((isNaN($("#txtpdcount").val()) == true) || ($("#txtpdcount").val().indexOf(".", 0) > 0) || (parseInt($("#txtpdcount").val()) <= 0))) /*判断题题数不为空且不是大于0的正整数时*/ {
        $("#spanpdtx").text("*");
        for (i = 0; i < 8; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtpdzf").val()) != "" && ((isNaN($("#txtpdzf").val()) == true) || ($("#txtpdzf").val().indexOf(".", 0) > 0) || (parseInt($("#txtpdzf").val()) <= 0))) /*判断题总分不为空且不是大于0的正整数时*/ {
        $("#spanpdfs").text("*");
        for (i = 0; i < 9; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtpdcount").val()) != "" && $.trim($("#txtpdzf").val()) == "")/*判断题题数不为空，但分数为空*/ {
        $("#spanpdfs").text("*");
        for (i = 0; i < 9; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtjdcount").val()) != "" && ((isNaN($("#txtjdcount").val()) == true) || ($("#txtjdcount").val().indexOf(".", 0) > 0) || (parseInt($("#txtjdcount").val()) <= 0)))/*简答题题数不为空且不是大于0的正整数时*/ {
        $("#spanjdtx").text("*");
        for (i = 0; i < 10; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtjdzf").val()) != "" && ((isNaN($("#txtjdzf").val()) == true) || ($("#txtjdzf").val().indexOf(".", 0) > 0) || (parseInt($("#txtpdzf").val()) <= 0))) /*简答题总分不为空且不是大于0的正整数时*/ {
        $("#spanjdfs").text("*");
        for (i = 0; i < 11; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else if ($.trim($("#txtjdcount").val()) != "" && $.trim($("#txtjdzf").val()) == "")/*简答题题数不为空，但分数为空*/ {
        $("#spanjdfs").text("*");
        for (i = 0; i < 11; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    var extension = new String(FileName.substring(FileName.lastIndexOf(".") + 1, FileName.length));
    if (extension != "doc" && extension != "docx") {
        alert("只能上传*.doc或*.docx格式的试卷文档");
        for (i = 0; i < 12; i++) {
            $(arr[i]).text("");
        }
        return false;
    }
    else/*均不为空且上传文档正确时*/ {
        for (i = 0; i < 12; i++) {
            $(arr[i]).text("");
        } var NowTime = new Date();
        var NowTime = new Date();
        var week = "";
        switch (NowTime.getDay()) {
            case 0:
                week = "星期天";
                break;
            case 1:
                week = "星期一";
                break;
            case 2:
                week = "星期二";
                break;
            case 3:
                week = "星期三";
                break;
            case 4:
                week = "星期四";
                break;
            case 5:
                week = "星期五";
                break;
            case 6:
                week = "星期六";
                break;
        }

        var NowTime = NowTime.toLocaleString();/*系统当前时间*/
        NowTime = NowTime.replace('年', '/');
        NowTime = NowTime.replace('月', '/');
        NowTime = NowTime.replace('日', '');
        NowTime = NowTime.replace(week, '');
        NowTime = NowTime.replace(/-/g, "/");
        NowTime = new Date(NowTime);
        var str1 = $.trim($("#startTime").val()).replace(/-/g, "/");/*开始时间*/
        var DateOne = new Date(str1);
        var str2 = $.trim($("#endTime").val()).replace(/-/g, "/");/*结束时间*/
        var DateTwo = new Date(str2);
        var DateOneSecond = DateOne.getTime();/*开始时间的毫秒数*/
        DateOneSecond = DateOneSecond + 18000000;
        var DateTwoSecond = DateTwo.getTime();/*结束时间的毫秒数*/
        if (NowTime > DateOne) {
            $("#spanstarttime").text("开始时间必须大于当前系统时间！");
            return false;
        } else if (DateOne >= DateTwo) {
            $("#spanendtime").text("结束时间必须大于开始时间！");
            return false;
        }
        else if (parseInt(DateTwoSecond) > parseInt(DateOneSecond)) {
            $("#spanendtime").text("结束时间大于开始时间需在0-300分钟之内！");
            return false;
        }
        else { return true; }
    }
}
/******************************* EdutSubject.aspx------------------即科目信息页面*******************************/
//判断新增或修改科目时科目名、专业名是否为空
function CheckSubject()
{
    if ($.trim($("#KmName").val()) == "")/*科目名*/
    {
        $("#spusername").text("*");
        return false;
    }
    else if ($("#ZyName").val() == 0)/*专业名*/
    {
        $("#spanzy").text("*");
        $("#spusername").text("");
        return false;
    }
    else {
        $("#spusername").text("");
        $("#spanzy").text("");
        return true;
    }
}
/*******************************AddSpeciality.aspx-----------即专业信息页面**********************************/
//判断新增或修改专业时专业名是否为空
function CheckSpeciality()
{
    if ($.trim($("#ZyName").val()) == "") {
        $("#spanzy").text("*");
        return false;
    }
    else {
        $("#spanzy").text("");
        return true;
    }
}
/*********************************EditStudent.aspx-----------即学生信息页面***********************************************/
//判断修改学生信息时判断学号、姓名、班级、年级、专业是否为空
function CheckStudent()
{
    if ($.trim($("#textStudentID").val()) == "")/*学号为空*/
    {
        $("#spanxh").text("*");
        return false;
    }
    else if ($.trim($("#TextName").val()) == "")/*姓名为空*/
    {
        $("#spanname").text("*");
        $("#spanxh").text("");
        return false;
    }
  
    else if ($.trim($("#TextYh").val()) == "")/*用户名为空*/ {
        $("#spanuser").text("*");
        $("#spanname").text("");
        $("#spanxh").text("");
        return false;
    }
    else if ($("#TextMm").val() == "")/*密码为空*/ {
        $("#spanpwd").text("*");
        $("#spanuser").text("");
        $("#spanname").text("");
        $("#spanxh").text("");
        return false;
    }
    else if ($("#BjName").val() == "请选择...")/*班级为空*/
    {
        $("#spanclass").text("*");
        $("#spanpwd").text("");
        $("#spanuser").text("");
        $("#spanname").text("");
        $("#spanxh").text("");
        return false;
    }
    else/*均不为空*/
    {
        $("#spanclass").text("");
        $("#spanpwd").text("");
        $("#spanuser").text("");
        $("#spanname").text("");
        $("#spanxh").text("");
        return true;
    }
}
/*****************************AnswerCard.aspx页面---------------即考卷基本信息页面*****************************/
/*验证教师给学生评的每题得分是否合法（为正整数，且总成绩不能大于试卷总分）*/
function CheckAllScore()
{
    var AllScore = $("#spanAllscore").text();/*试卷总分*/
    var allscore=0;/*声明考生总得分变量，初始化为0*/
    var num = $("input:text").length;/*总题数*/
    for (i = 0; i < num; i++)
    {
        var score =$.trim( $("input:text").eq(i).val());/*对应题目分数*/
        if (score != "")
        {
            if ((isNaN(score) == true) || (score.indexOf(".", 0) > 0) || (parseInt(score) < 0)) {
                alert("每题的分数只能为正整数！");
                return false;
                break;
            }
            else {
                allscore = parseInt(allscore) + parseInt(score);
                if (parseInt(AllScore) < parseInt(allscore)&&i<=(num-1)) {
                    alert("考生的总得分不应该大于试卷总分");
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    }
}
/*-----------------------------------------验证教师在填写客观题的标准答案时是否填写完整-------------------------------*/
function CheckAnswer()
{
    if ($("#spandanxuan").text() != "")
    {
        var dxnum = $("tr[id='a0'] span").length;/*单选题个数*/
        for (i = 1; i <= dxnum; i++)
        {
            var name = "rdo" + i;
            var radioname = document.getElementsByName(name);
            for (j = 1; j < radioname.length; j++)
            {
                if (radioname[j].checked) {
                    break;
                } else if (j == radioname.length - 1 && radioname[j].checked == false)
                {
                    alert("请将单选题答案填写完整");
                    return false;
                    break;
                }
            }
        }
    }
    if ($("#spanduoxuan").text() != "")
    {
        var duoxnum = $("tr[id='a1'] span").length;/*多选题个数*/
        for (i = 1; i <= duoxnum; i++)
        {
            for (j = 1; j < 5; j++)
            {
                var duoxboxid = i + "_" + j;
                var duoxbox = document.getElementById(duoxboxid);
                if (duoxbox.checked)
                {
                    break;
                } else if (j == 4 && duoxbox.checked == false)
                {
                    alert("请将多选题答案填写完整");
                    return false;
                    break;
                }
            }
        }
    }
    if ($("#spanpanduan").text() != "")
    {
        var panduannum = $("tr[id='a2'] span").length;/*判断题个数*/
        for (i = 1; i <= panduannum; i++) {
            var pdname = "Prdo" + i;
            var pdnamegroup = document.getElementsByName(pdname);
            for (j = 1; j < pdnamegroup.length; j++) {
                if (pdnamegroup[j].checked) {
                    break;
                }
                /*有一个bug， 判断题全选了还是会进这个else if()*/
                /* else if (j == pdnamegroup.length - 1 && pdnamegroup[j].checked == false) {
                    alert("请将判断题答案填写完整");
                    alert(pdnamegroup.length);
                    return false;
                    break;
                }*/
            }
        }
    }
    return true;
}