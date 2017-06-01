using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ExaminationModels;
using ExaminationBLL;

public partial class admin_AnswerCard_ReadPaper : System.Web.UI.Page
{
    public static TbObjectiveTopic Tbt;
    public static string[] stu;
    public static int num = 0;
    public static string str = "";
    public static List<string> StrLive;
    public static int ZDfen = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string action = Request["action"];
            if (action != null && action.ToString().Equals("zfen"))
                ZDfen = int.Parse(Request["score"].ToString());
        }
        //Tbt = new TbObjectiveTopic(); //声明答案类
        //stu = new string[] { }; //保存主观题答案
        //num = 0;    //题号
        //StrLive = new List<string>(); //保存标题所有内容
        if (Request["KgtID"] != null)
        {
            Tbt = new TbObjectiveTopic(); //声明答案类
            stu = new string[] { }; //保存主观题答案
            num = 0;    //题号
            StrLive = new List<string>(); //保存标题所有内容
            Tbt.KgtID = int.Parse(Request["KgtID"].ToString());
            HttpCookie cookie = new HttpCookie("kgtid");
            cookie.Value = Tbt.KgtID.ToString();
            Request.Cookies.Add(cookie);
        }
        else
        {
            string kgtid = Request.Cookies["kgtid"].Value;
            Tbt.KgtID = int.Parse(kgtid);
        }
        Tbt.Zt = 2;



        DataTable dt = tbAnswerCardManager.getAnswerCardZgt(Tbt);
        if (dt.Rows.Count > 0)
        {
            stu = dt.Rows[0]["ZgtAnswer"].ToString().Split('︵'); //获得所有主观题答案
            DataRow dtKgt = tbAnswerCardManager.getAnswerCard2(Tbt.KgtID).Rows[0];  //获得答题卡
            string Sj = dtKgt["SjID"].ToString();
            DataTable dtTx = TbQuestionTypesManager.GetAllQuestionTypesBySjid(int.Parse(Sj));
            DataRow drTx = dtTx.Rows[dtTx.Rows.Count - 1];
            if (drTx["TxName"].ToString() == "简答题")
            {
                int Zfen = int.Parse(dtTx.Rows[dtTx.Rows.Count - 1]["Txzf"].ToString());       //本试卷简答题总分
                int TCount = int.Parse(dtTx.Rows[dtTx.Rows.Count - 1]["TxCount"].ToString());    //本试卷简答题个数
                DataRow dtPaper = TbTestPaperManager.getOnePaperInfo(Sj).Rows[0];

                Sj = dtPaper["SjName"].ToString();
                StrLive.Add(Sj);     //1 试卷名称
                Sj = dtPaper["LsName"].ToString();
                StrLive.Add(Sj); //2 老师名字
                Sj = dtKgt["YhID"].ToString();
                Sj = TbUserManager.GetAllUser(int.Parse(Sj)).Xh;  //获得用户学号
                StrLive.Add(Sj); //3 学生学号
                StrLive.Add(Zfen.ToString()); //4简答题总分
            }
        }
    }
    protected void ButTiJiao_Click(object sender, EventArgs e)
    {
        TbScore Ts = new TbScore();
        Ts.KgtID = Tbt.KgtID;
        Ts.ZgtScore = ZDfen;
        Ts.Zt = 3;
        int i = TbScoreManager.UpdScroe(Ts, Ts.KgtID);
        i = tbAnswerCardManager.UpdateObjZt(Ts);
        Response.Redirect("EditAnswer.aspx");
    }
}