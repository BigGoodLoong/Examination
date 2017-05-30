using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.Data;

public partial class exam_ExamList : System.Web.UI.Page
{
    public static DataTable testPaperList = null;
    public static int page = 1;  //当前页数
    int len = 15;   //每页显示条数
    public static int SjZ = 1;

    public static TbScore nowTs = new TbScore();
    public static TbObjectiveTopic Tobj = new TbObjectiveTopic();

    public static DataTable dtObj = new DataTable();

    public static string Hello;

    protected void Page_Load(object sender, EventArgs e)
    {
        string sjName = "";
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        string url = PublicClass.CheckLogin(usercookie, "");
        if (url != "")
            Response.Redirect(url);

        if (!IsPostBack)
        {
            string action = Request["action"];
            if (action != null && action.ToString().Equals("Elspenvlaues"))
            {
                sjName = Request["sjName"].ToString();
            }
            spannowtime.InnerText = "服务器时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string user = usercookie.Value;
            Tobj.YhID = TbUserManager.GetStudentID(user);
            TbStudent tStudent = TbStudentManager.GetStudentByID(Tobj.YhID);
            testPaperList = TbTestPaperManager.GetAllTestpaperByPages(len, page, sjName, 2);
            Hello = tStudent.XsName;
            Elspen.Value = sjName;
        }
    }
    protected void timer1_Tick(object sender, EventArgs e)
    {
        spannowtime.InnerText = "服务器时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    }

}