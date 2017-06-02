using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
public partial class admin_Teacher_EditTeacher : System.Web.UI.Page
{
    public static DataTable TeacherList = new DataTable();
    public int len = 20;//定义当前页面的记录数，初始化为20
    public static int nowPage = 1;//定义当前页数，初始化为1
    public static int Pages = 1;//定义当前所查记录所占的总页数，初始化为1
    public static int Record = 0;//定义当前符号查询的记录总数，初始化为0
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        string url = PublicClass.CheckLogin(usercookie, "main");
        if (url != "")
        {
            Response.Write(url);
            return;
        }

        if (!IsPostBack)
        {
            string lsid = Request["LsID"];
            if (lsid != null)
            {
                int yhid = TbUserManager.GetTeacherUserYhID(int.Parse(lsid));//根据教师编号LsID得到对应的用户编号
                TbTeacherManager.DeleteTeacherInfo(int.Parse(lsid));//根据教师编号LsID删除对应教师信息
                TbUserManager.DeleteUserByYhID(yhid);//根据用户编号删除教师对应的用户信息
            }
            GetPageInfo();
            GetSpeciality();
        }

    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/
    /// <summary>
    /// 获取页面信息
    /// </summary>
    public void GetPageInfo()
    {

        string lsname = this.txtTeacherName.Value.Trim() == "按教师名、用户名、专业名模糊查找" ? "" : this.txtTeacherName.Value.Trim();
        if (lsname != "按教师名、用户名、专业名模糊查找" && lsname != "" && FirstSxNum == 0)
        {
            nowPage = 1;
            FirstSxNum = 1;
        }
        Record = TbTeacherManager.GetAllTeachersInfo(lsname).Rows.Count; ;/*记录总数*/
        TeacherList = TbTeacherManager.GetAllTeacherInfoPage(len, nowPage, lsname);
        if (Record == 0)
        {
            Pages = 1;
        }
        else
        {
            if (Record % len == 0)
                Pages = (Record / len);
            else
                Pages = (Record / len) + 1;
        }

    }
    /// <summary>
    /// 绑定专业信息
    /// </summary>
    public void GetSpeciality()
    {
        DataTable dt = TbSpecialityManager.BangdingZy();
        teacherzy.DataSource = dt;
        teacherzy.DataTextField = "ZyName";
        teacherzy.DataValueField = "ZyID";
        teacherzy.DataBind();
        teacherzy.Items.Insert(0, new ListItem("请选择..", "0"));
    }
    /// <summary>
    /// 新增和修改教师信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonOK_Click(object sender, EventArgs e)
    {

        TbTeacher teacher = new TbTeacher();
        TbUser user = new TbUser();
        user.Zt = int.Parse(userrole.SelectedValue);
        user.Xh = "";
        teacher.LsName = teachername.Text.Trim();
        user.YhName = teacheruser.Text.Trim();//用户名(账号)
        user.YhPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(teacherpwd.Text, "MD5");//密码
        teacher.ZyID = int.Parse(this.teacherzy.SelectedValue);//专业
        teacher.Remark = textRemark.Text.Trim();
        if (this.hidTeacherID.Value != "")/*用户编号不为空，即为修改时*/
        {
            teacher.YhID = int.Parse(this.hidTeacherID.Value);
            user.YhID = teacher.YhID;
            TbUserManager.UpdateUserRoleByYhID(user);
            TbTeacherManager.UpdateTeacherInfoByYhID(teacher);
            this.hidTeacherID.Value = "";
        }
        else
        {
            int yhid = TbUserManager.InsertTeacherUser(user.YhName, user.Xh, user.YhPwd, user.Zt);/*新增教师用户信息，返回其用户编号*/
            if (yhid > 0)
            {
                int Result = TbTeacherManager.InsertTeacherInfo(yhid, teacher.LsName, teacher.ZyID, teacher.Remark);
            }
        }
        teacherzy.Items.Clear();
        GetSpeciality();
        GetPageInfo();
        teachername.Text = "";
        teacherpwd.Text = "";
        teacheruser.Text = "";
    }
    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void FirstPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage = 1;
        GetPageInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage--;
        GetPageInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void NextPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage++;
        GetPageInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LastPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage = Pages;
        GetPageInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void JumpPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage = int.Parse(this.tzpage.Value.Trim());
        GetPageInfo();
        RegisterEvent();
        this.tzpage.Value = "";
    }
    protected void Select_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;/*筛选条件改变*/
        GetPageInfo();
        RegisterEvent();

    }
    public void RegisterEvent()
    {
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('addTeacher', 'addTeacherA', 'btnClose')", true);
        var count = Record;
        for (int i = 1; i <= count; i++)
        {
            string str1 = "div" + i;
            string str2 = "a" + i;
            ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('addTeacher', '" + str2 + "', 'btnClose')", true);
        }
    }
}