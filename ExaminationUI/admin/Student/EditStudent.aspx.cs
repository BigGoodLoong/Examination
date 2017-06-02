using ExaminationBLL;
using ExaminationModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Student_EditStudent : System.Web.UI.Page
{
    public int len = 20;//定义页面表格显示数据的最大条数。赋值为10.
    public static int page = 1;//定义当前页数，初始化为1.
    public static int Count = 0; //定义科目表数据的总条数，初始化为0。
    public static int Maxapge = 0; //定义科目表数据能显示的最大页数，初始化为0.
    public static DataTable studentList = new DataTable(); //定义一个Table表格，初始化为null.
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
            this.BjName.Items.Clear();
            this.BjName.Items.Add("请选择...");
            List<TbClass> TbClass = TbClassManager.GetAllClassList();
            foreach (TbClass TbClassRow in TbClass)
            {
                string AddList = TbClassRow.Nj + TbClassRow.BjName;
                this.BjName.Items.Add(AddList);
            }
            string yhid = Request["userid"];
            if (yhid != null)
            {
                TbStudentManager.DeleteStuByYuID(int.Parse(yhid));
            }
            Load_Student();
        }
    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 加载科目列表信息
    /// </summary>
    /// <param name="apge">当前页面</param>
    public void Load_Student()
    {
        string Bj_Name = txtClassName.Value.Trim() == "按姓名，学号，班级，用户名模糊查询" ? "" : txtClassName.Value.Trim();
        if (Bj_Name != "按姓名，学号，班级，用户名模糊查询" && Bj_Name != "" && FirstSxNum == 0)
        {
            page = 1;
            FirstSxNum = 1;
        }
        studentList = TbStudentManager.GetAllStuInfo(len, page, Bj_Name);
        Count = TbStudentManager.GetAllStuInfo(Bj_Name).Rows.Count;
        if (Count == 0)
        {
            Maxapge = 1;
        }
        else
        {
            if (Count % len == 0) //当数据库数据能整除10，最大页面数取Count/len的商
                Maxapge = Count / len;
            else
                Maxapge = Count / len + 1;//当数据库数据不能整除10，最大页面数取Count/len的商+1.
        }
    }
    protected void ImageLast_Click(object sender, ImageClickEventArgs e)
    {
        page = Maxapge; //需要跳到最后一页，当前页面需要变为页面的最大值。
        Load_Student();
        RegisterEvent();
        RegisterDiv();
    }
    protected void ImageFirst_Click(object sender, ImageClickEventArgs e)
    {
        page = 1; //需要跳到第一页，当前页面需要变为一。
        Load_Student();
        RegisterEvent();
        RegisterDiv();
    }
    protected void ImageBack_Click(object sender, ImageClickEventArgs e)
    {
        page--; //上一页，将当前页数减一，实现页面向前跳一页。
        Load_Student();
        RegisterEvent();
        RegisterDiv();
    }
    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        page++;//下一页，将当前页数加一，实现页面向后跳一页。
        Load_Student();
        RegisterEvent();
        RegisterDiv();

    }
    protected void ImageGo_Click(object sender, ImageClickEventArgs e)
    {
        int Apge = page; // 用来保存当前页面数
        page = int.Parse(this.tzpage.Text.Trim());//将输入的文本值显示转换成int类型
        Load_Student();
        RegisterEvent();
        RegisterDiv();
        this.tzpage.Text = "";
    }
    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        TbUser User = new TbUser();
        TbStudent Student = new TbStudent();
        User.YhName = this.TextYh.Text;
        User.Xh = this.textStudentID.Text;
        User.Zt = 3;
        Student.XsName = this.TextName.Text;
        Student.BjName = this.BjName.Text;
        if (this.RadButNan.Checked)
            Student.XsSex = this.RadButNan.Value;
        else
            Student.XsSex = this.RadButNv.Value;
        Student.Remark = this.textBz.Text;
        if (this.HiddenYhID.Value == "")
        {
            this.BjName.Text = "请选择...";
            User.YhPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.TextMm.Text, "MD5");
            TbUserManager.SeeUser(User);
            Student.YhID = TbUserManager.AddUser(User);
            TbStudentManager.AddStudent(Student);
            Load_Student();
        }
        else
        {
            User.YhPwd = this.TextMm.Text.Trim();
            User.YhID = int.Parse(this.HiddenYhID.Value);
            Student.YhID = int.Parse(this.HiddenYhID.Value);
            TbUserManager.SetUser(User);
            TbStudentManager.SetStudent(Student);
            this.HiddenYhID.Value = "";
        }
        this.textStudentID.Text = "";
        this.TextYh.Text = "";
        this.TextName.Text = "";
        this.textBz.Text = "";
        this.BjName.Text = "请选择...";
        this.RadButNan.Checked = true;
        Load_Student();
    }

    protected void TextBjName_TextChanged(object sender, EventArgs e)
    {
        Load_Student();
    }
    protected void ButtonNO_Click(object sender, EventArgs e)
    {
        this.BjName.Text = "请选择...";
        this.textStudentID.Text = "";
        this.TextYh.Text = "";
        this.TextName.Text = "";
        this.textBz.Text = "";
        this.RadButNan.Checked = true;
        Load_Student();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;
        Load_Student();
        RegisterEvent();
    }
    /// <summary>
    /// 重新注册事件
    /// </summary>
    private void RegisterEvent()
    {
        RegisterDiv();
    }
    private void RegisterDiv()
    {

        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('addstudent', 'addstu', 'btnClose')", true);
        var count = studentList.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            string str1 = "div" + i;
            string str2 = "a" + i;
            ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('addstudent', '" + str2 + "', 'btnClose')", true);
        }
    }
}