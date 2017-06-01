using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationModels;
using ExaminationBLL;
using System.Data;

public partial class student_Test : System.Web.UI.Page
{
    public static string SjID = "6"; //声明将要考试的试卷Id
    public static string YhID = "2";

    public static DataRow drPaper;
    public static List<string> Ls;


    public static int ScoreZt;
    protected void Page_Load(object sender, EventArgs e)
    {



        Ls = new List<string>();
        if (!IsPostBack)
        {
            if (Request["sjid"] != null)
            {
                SjID = Request["sjid"].ToString();
            }
        }
        DataTable dtPaper = TbTestPaperManager.getOnePaperInfo(SjID);
        if (dtPaper != null)
        {
            drPaper = dtPaper.Rows[0];
            DateTime Jstime = DateTime.Parse(drPaper["JsTime"].ToString());     //结束时间
            DateTime Kstime = DateTime.Parse(drPaper["KsTime"].ToString());     //开始时间
            int Min = PublicClass.GetMinutes(Kstime, Jstime);                    //间隔时间
            Ls.Add(Min.ToString());                                                     //Ls[0] = 剩余时间 分钟数
            if (STimeMin == -1)
            {
                STimeMin = Min;
            }
            int Zfen = TbQuestionTypesManager.GetSumScoreBySjid(int.Parse(SjID));
            Ls.Add(Zfen.ToString());
            string KstrTime = drPaper["KsTime"].ToString();
            KstrTime = KstrTime.Substring(KstrTime.LastIndexOf(' '));
            Ls.Add(KstrTime);

        }

        HttpCookie ck = Request.Cookies["nowloginuser"];
        string user = ck.Value;//获得当前登录用户用户名
        int YhID = TbUserManager.GetStudentID(user);
        string XsName = TbStudentManager.GetStudentByID(YhID).XsName;
        Ls.Add(XsName);


        ScoreZt = TbScoreManager.getScore(YhID.ToString(), SjID).Zt;
        if (ScoreZt == 2)
        {
            //ScriptManager.RegisterStartupScript(Page, typeof(string), "3", "error()", true);
            Response.Write("<script>alert('本次考试已结束，请勿重复提交');</script>");
            Response.Write("<script>window.close();</script>");
            return;
        }

    }

    static int min = 4;
    static int scond = 60;
    static int STimeMin = -1;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        scond--;

        if (scond == 0)
        {
            min--;
            STimeMin--;
            scond = 60;
            if (min == 0)
            {
                min = 5;
            }
        }
        Jishi.Text = "0" + min + ":" + scond;
        STime.Text = STimeMin.ToString();
        if (min == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(string), "1", "test()", true);
        }
        if (STimeMin == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(string), "2", "test2()", true);
        }
    }
}