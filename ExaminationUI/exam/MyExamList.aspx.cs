using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using System.Data;

public partial class exam_MyExamList : System.Web.UI.Page
{
    public static DataTable testPaperScoreList = null;
    public int yhid;
    public static string Hello = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = "";
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        string url = PublicClass.CheckLogin(usercookie, "");
        if (url != "")
            Response.Redirect(url);
        if (!IsPostBack)
        {
            string action = Request["action"];
            if (action != null && action.ToString().Equals("Del"))
            {
                int kgtid = int.Parse(Request["kgtid"].ToString());
                deleteGetTestPaperInfo(kgtid);
            }
            else if (action != null && action.ToString().Equals("vlaues"))
            {
                name = Request["sjName"].ToString();
            }
            spannowtime.InnerText = "服务器时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string user = usercookie.Value;
            yhid = TbUserManager.GetStudentID(user);
            testPaperScoreList = TbScoreManager.GetTestPaperScoreByYhid(yhid, name);
            sjName.Value = name;

            Hello = TbStudentManager.GetStudentByID(yhid).XsName;
        }
    }
    protected void timer1_Tick(object sender, EventArgs e)
    {
        spannowtime.InnerText = "服务器时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    }
    /// <summary>
    /// 根据客观题ID删除考卷信息
    /// </summary>
    /// <param name="KgtID">客观题ID</param>
    public void deleteGetTestPaperInfo(int KgtID)
    {
        TbScoreManager.deleteScoreInfo(KgtID);
        TbResultManager.deleteResultInfo(KgtID);
        TbObjectiveTopicManager.deleteReviewTestPaperInfo(KgtID);
    }
}