using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.Data;
//www.51aspx.com
public partial class ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request["action"];
        if (action == "login")
            CheckLogin(Request["username"], Request["pwd"]);
        else if (action == "getSpecial")
            GetSpecial(int.Parse(Request["zyid"]));
        else if (action == "editoradd")
            CheckSpecNameIsExist(Request["specName"]);
        else if (action == "EditStudent")
            GetStudent(int.Parse(Request["YhID"]));
        else if (action == "editStudentID")
            CheckXhIsExist(Request["StudentID"]);
        else if (action == "getClass")
            GetClass(int.Parse(Request["BjID"]));
        else if (action == "EditClass")
            CheckClassNameIsExist(Request["textName"], Request["textNj"]);
        else if (action == "getTeacher")
            GetTeacher(int.Parse(Request["YhID"]));
        else if (action == "getSubject")
            GetSubject(int.Parse(Request["KmID"]));
        else if (action == "editSubjectID")
            CheckSunjectNameIsExist(Request["KmName"], int.Parse(Request["ZyName"]));
        else if (action == "EditStudentYhName")
            CheckUserIsExist(Request["YhName"]);
        else if (action == "editTeacher")
            CheckUserIsExist(Request["YhName"]);
        else if (action == "getEditTestPaper")
            GetEditTestPaper(int.Parse(Request["sjid"]));
        else if (action == "EditTestPaperName")
            CheckTestPaperNameIsExist(Request["SjName"]);
        else if (action == "specChang")
            GetSubjectBySpecid(int.Parse(Request["specid"]));
    }

    /// <summary>
    /// 登录验证
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="pwd">密码</param>
    private void CheckLogin(string username, string pwd)
    {
        pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        int result = TbUserManager.Login(username, pwd);
        if (result > 0)
        {
            HttpCookie cookie = new HttpCookie("nowloginuser");
            cookie.Expires = DateTime.Now.AddHours(1);
            cookie.Value = username;
            Response.AppendCookie(cookie);
            string msg = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(result.ToString()));
            Response.Write(msg);
        }
        else
            Response.Write("用户名或密码错误！");
    }
    /// <summary>
    /// 根据专业ID查询对应详细信息
    /// </summary>
    /// <param name="zyid"></param>
    private void GetSpecial(int zyid)
    {
        TbSpeciality special = TbSpecialityManager.GetSpecialByID(zyid);
        string message = special.ZyID + "|" + special.ZyName + "|" + special.Remark;
        Response.Write(message);
    }
    /// <summary>
    /// 根据教师编号LsID查询对应的详细信息
    /// </summary>
    /// <param name="LsID"></param>
    private void GetTeacher(int YhID)
    {
        TbTeacher teacher = TbTeacherManager.GetTeacherInfoByLsID(YhID);
        TbUser user = TbUserManager.GetUserInfoByYhID(YhID);
        string role = "";
        if (user.Zt == 1)
        {
            role = "管理员";
        }
        else
        {
            role = "教师";
        }
        TbSpeciality speciality = TbSpecialityManager.GetSpecialByID(teacher.ZyID);
        string message = teacher.YhID + "|" + teacher.LsName + "|" + user.YhName + "|" + user.YhPwd + "|" + role + "|" + speciality.ZyName + "|" + teacher.Remark;
        Response.Write(message);
    }
    /// <summary>
    /// 根据用户名查找对应信息
    /// </summary>
    /// <param name="YhName"></param>
    private void CheckUserIsExist(string YhName)
    {
        string yhid = Request["YhID"];
        int selectyhid = TbUserManager.SelectUserYhName(YhName.Trim());
        if (selectyhid > 0 && yhid != selectyhid.ToString())
            Response.Write("已存在");
        else
            Response.Write("不存在");

    }
    /// <summary>
    /// 根据用户ID查询对应详细信息
    /// </summary>
    /// <param name="YhID"></param>
    public void GetStudent(int YhID)
    {
        TbStudent student = TbStudentManager.GetStudentByID(YhID);
        TbUser user = TbUserManager.GetAllUser(YhID);
        string message = student.YhID + "," + student.XsName + "," + student.XsSex + "," + student.BjName + "," + student.Remark + "," + user.YhName + "," + user.Xh + "," + user.YhPwd;
        Response.Write(message);
    }
    /// <summary>
    /// 判断专业名是否存在
    /// </summary>
    /// <param name="specname">专业名</param>
    private void CheckSpecNameIsExist(string specname)
    {
        string zyid = Request["zyid"];
        int seeNum = TbSpecialityManager.seeSpecialityID(specname);
        if (seeNum > 0 && zyid != seeNum.ToString())
            Response.Write("已存在");
        else
            Response.Write("不存在");
    }
    /// <summary>
    /// 判断学号是否存在
    /// </summary>
    /// <param name="StudentID"></param>
    public void CheckXhIsExist(string StudentID)
    {
        string YhID = Request["YhID"];
        int seeNum = TbUserManager.GetStudentID(StudentID);
        if (seeNum > 0 && YhID != seeNum.ToString())
            Response.Write("已存在");
        else
            Response.Write("不存在");
    }
    /// <summary>
    /// 根据班级ID查询对应详细详细
    /// </summary>
    /// <param name="BjID">班级ID</param>
    private void GetClass(int BjID)
    {
        TbClass Class = TbClassManager.GetClassByID(BjID);
        string ZyName = TbSpecialityManager.GetSpecialityName(Class.ZyID);//获取专业ID对应的专业名称
        string message = Class.BjID + "|" + Class.BjName + "|" + Class.Nj + "|" + ZyName;
        Response.Write(message);
    }
    /// <summary>
    /// 判断班级是否存在
    /// </summary>
    /// <param name="BjName">班级名称</param>
    /// <param name="Nj">年级</param>
    private void CheckClassNameIsExist(string BjName, string Nj)
    {
        string bjid = Request["BjID"];
        DataTable dt = TbClassManager.Sel_Bj(BjName, Nj);
        int Class = 0;
        foreach (DataRow item in dt.Rows)
            Class = int.Parse(item["BjID"].ToString());
        if (Class > 0 && Class.ToString() != bjid)
            Response.Write("已存在");
        else
            Response.Write("不存在");
    }
    public void GetSubject(int KmID)
    {
        TbSubject subject = TbSubjectManager.GetSubjectByID(KmID);
        TbSpeciality speciality = TbSpecialityManager.GetSpecialByID(subject.ZyID);
        string message = subject.KmID + "," + subject.KmName + "," + speciality.ZyName + "," + subject.Remark;
        Response.Write(message);
    }

    /// <summary>
    /// 判断科目名是否存在
    /// </summary>
    /// <param name="KmName"></param>
    public void CheckSunjectNameIsExist(string KmName, int ZyID)
    {
        string KmID = Request["KmID"];
        int KmNum = TbSubjectManager.GetSubjectByKmName(KmName, ZyID);
        if (KmNum > 0 && KmID != KmNum.ToString())
            Response.Write("已存在");
        else
            Response.Write("不存在");
    }
    /// <summary>
    /// 根据试卷ID查询对应详细信息
    /// </summary>
    /// <param name="sjid"></param>
    public void GetEditTestPaper(int sjid)
    {
        TbTestPaper testpaper = TbTestPaperManager.GetAllSjInfo(sjid);
        string message = testpaper.SjID + "|" + testpaper.SjName + "|" + testpaper.KsTime + "|" + testpaper.JsTime + "|" + testpaper.Remark;
        Response.Write(message);
    }
    /// <summary>
    /// 判断试卷是否存在
    /// </summary>
    /// <param name="SjName"></param>
    public void CheckTestPaperNameIsExist(string SjName)
    {
        string sjID = Request["SjID"];
        int testpapercount = TbTestPaperManager.GetTestPaperInfo(SjName);
        if (testpapercount > 0 && testpapercount.ToString() != sjID)
            Response.Write("已存在");
        else
            Response.Write("不存在");
    }
    /// <summary>
    /// 根据专业ID查询所有科目
    /// </summary>
    /// <param name="specid">专业ID</param>
    public void GetSubjectBySpecid(int specid)
    {
        DataTable table = TbSubjectManager.GetSubjectListByZyid(specid);
        string message = "";
        foreach (DataRow row in table.Rows)
        {
            message += row["KmName"].ToString() + "*";
        }
        Response.Write(message);
    }
}