using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using FanG;
using System.Collections;
using System.Data;
using System.IO;


public partial class admin_ExamResult_TeacherSelectScore : System.Web.UI.Page
{
    public static DataTable scoreList = null;  //当前成绩列表
    public static int page = 1;  //当前页书
    public static int len = 20;  //每页显示条数
    public static int count = 0;//定义专业信息的总条数
    public static int maxPage = 0;//定义显示页面的最大页数
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSpec.DataSource = TbSpecialityManager.GetAllSpecialityListByScore();
            ddlSpec.DataValueField = "ZyID";
            ddlSpec.DataTextField = "ZyName";
            ddlSpec.DataBind();
            ddlSpec.Items.Insert(0, new ListItem("全部", "0"));
            GetScoreList();
            LoadData("", 1);
        }

    }
    private void GetScoreList()
    {
        scoreList = TbScoreManager.GetScoreList(len, page);
        count = TbScoreManager.GetScoreList().Rows.Count;
        if (count % len == 0) //当数据库数据能整除len，最大页面数取Count/len的商
        {
            if (count > 0)
                maxPage = count / len;
            else
                maxPage = 1;
        }
        else
            maxPage = count / len + 1;//当数据库数据不能整除len，最大页面数取Count/len的商+1.

    }
    /// <summary>
    /// 绑定图表
    /// </summary>
    /// <param name="whereStr">当前筛选条件</param>
    /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
    public void LoadData(string whereStr, int type)
    {
        if (scoreList.Rows.Count > 0)
        {
            Chartlet1.AppearanceStyle = (FanG.Chartlet.AppearanceStyles)System.Enum.Parse(typeof(FanG.Chartlet.AppearanceStyles), "Bar_3D_Aurora_NoCrystal_NoGlow_NoBorder", true);
            DataTable classListTable = TbScoreManager.GetClassList(whereStr, type);
            ArrayList classList = new ArrayList();
            foreach (DataRow classRow in classListTable.Rows)
                classList.Add(classRow["BjName"]);
            DataTable testpaperListTable = TbScoreManager.GetTestPaperList(whereStr, type);
            ArrayList testpaperList = new ArrayList();
            foreach (DataRow testRow in testpaperListTable.Rows)
                testpaperList.Add(testRow["SjName"]);

            ArrayList[] DataArray = new ArrayList[testpaperList.Count];
            for (int i = 0; i < DataArray.Length; i++)
            {
                DataArray[i] = new ArrayList();
                int sjid = int.Parse(testpaperListTable.Rows[i]["SjiD"].ToString());
                float sjZongScore = TbQuestionTypesManager.GetSumScoreBySjid(sjid);
                for (int j = 0; j < classList.Count; j++)
                {
                    string nowClassName = classList[j].ToString();
                    float sumScore = 0;
                    DataTable dtScorelist = TbScoreManager.GetScoreListBySjidAndClassname(sjid, nowClassName);
                    if (dtScorelist.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtScorelist.Rows)
                        {
                            float score = 0;
                            if (float.Parse(row["DxtScore"].ToString()) > 0)
                                score += float.Parse(row["DxtScore"].ToString());
                            if (float.Parse(row["DuoxtScore"].ToString()) > 0)
                                score += float.Parse(row["DuoxtScore"].ToString());
                            if (float.Parse(row["PdtScore"].ToString()) > 0)
                                score += float.Parse(row["PdtScore"].ToString());
                            if (float.Parse(row["ZgtScore"].ToString()) > 0)
                                score += float.Parse(row["ZgtScore"].ToString());
                            sumScore += score;
                        }
                        float avgScore = sumScore / dtScorelist.Rows.Count;
                        DataArray[i].Add(avgScore / sjZongScore * 100);
                    }
                }

            }
            string title = "";
            switch (type)
            {
                case 1:
                    if (whereStr == "")
                        title = "全部";
                    else
                        title = "筛选：" + whereStr;
                    break;
                case 2: title = "专业：" + whereStr; break;
                case 3: title = "科目：" + whereStr; break;
            }
            Chartlet1.ChartTitle.Text = title;
            Chartlet1.XLabels.UnitText = "班级/平均分";
            Chartlet1.YLabels.UnitText = "总分";
            Chartlet1.MaxValueY = 100;
            Chartlet1.InitializeData(DataArray, classList, testpaperList);
        }
    }

    protected void btnsx_Click(object sender, EventArgs e)
    {
        string specname = txtNameTest.Value.Trim();
        if (specname == "按姓名、试卷名模糊查找" || specname == "")
        {
            if (ddlSpec.SelectedItem.Text.Equals("全部"))
            {
                GetScoreList();
                LoadData("", 1);
            }
        }
        else
        {
            scoreList = TbScoreManager.GetScoreList(specname, 1);
            count = scoreList.Rows.Count;
            maxPage = 0;
            LoadData(specname, 1);
        }

    }
    protected void ddlSpec_SelectedIndexChanged(object sender, EventArgs e)
    {
        string specname = ddlSpec.SelectedItem.Text;
        if (specname.Equals("全部"))
        {
            GetScoreList();
        }
        else
        {
            scoreList = TbScoreManager.GetScoreList(specname, 2);
            LoadData(specname, 2);
            count = scoreList.Rows.Count;
            maxPage = 0;
        }
    }
    protected void btnSubject_Click(object sender, EventArgs e)
    {
        string subjectname = hidSubject.Value;
        if (subjectname.Equals("全部"))
        {
            scoreList = scoreList = TbScoreManager.GetScoreList(ddlSpec.SelectedItem.Text, 2);
            LoadData(ddlSpec.SelectedItem.Text, 2);
        }
        else
        {
            scoreList = TbScoreManager.GetScoreList(subjectname, 3);
            LoadData(subjectname, 3);
        }
        count = scoreList.Rows.Count;
        maxPage = 0;
    }
    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void FirstPage_Click(object sender, ImageClickEventArgs e)
    {
        page = 1;
        GetScoreList();

    }
    /// <summary>
    /// 上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BackPage_Click(object sender, ImageClickEventArgs e)
    {
        page--;
        GetScoreList();
    }
    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void NextPage_Click(object sender, ImageClickEventArgs e)
    {
        page++;
        GetScoreList();
    }
    /// <summary>
    /// 尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LastPage_Click(object sender, ImageClickEventArgs e)
    {
        page = maxPage;
        GetScoreList();

    }
    protected void BtnJumppage_Click(object sender, ImageClickEventArgs e)
    {
        page = int.Parse(this.tzpage.Value.Trim());//将输入的文本值显示转换成int类型
        GetScoreList();
        this.tzpage.Value = "";
    }
    /// <summary>
    /// 导出成绩
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExprotScore_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("file") + "\\studentScoreList.xls";
        if (File.Exists(path))
            File.Delete(path);
        DataTable dataSource = new DataTable();
        dataSource.Columns.Add("姓名", Type.GetType("System.String"));
        dataSource.Columns.Add("试卷", Type.GetType("System.String"));
        dataSource.Columns.Add("专业", Type.GetType("System.String"));
        dataSource.Columns.Add("科目", Type.GetType("System.String"));
        dataSource.Columns.Add("班级", Type.GetType("System.String"));
        dataSource.Columns.Add("成绩", Type.GetType("System.String"));
        DataTable nowDt;  //当前成绩列表
        if (maxPage > 0)
            nowDt = TbScoreManager.GetScoreList();
        else
            nowDt = scoreList;
        foreach (DataRow row in nowDt.Rows)
        {
            DataRow dr = dataSource.NewRow();
            dr["姓名"] = row["XsName"];
            dr["试卷"] = row["SjName"];
            dr["专业"] = row["ZyName"];
            dr["科目"] = row["KmName"];
            dr["班级"] = row["BjName"];
            int score = 0;
            if (int.Parse(row["DxtScore"].ToString()) >= 0)
                score += int.Parse(row["DxtScore"].ToString());
            if (int.Parse(row["DuoxtScore"].ToString()) >= 0)
                score += int.Parse(row["DuoxtScore"].ToString());
            if (int.Parse(row["PdtScore"].ToString()) >= 0)
                score += int.Parse(row["PdtScore"].ToString());
            if (int.Parse(row["ZgtScore"].ToString()) >= 0)
                score += int.Parse(row["ZgtScore"].ToString());
            dr["成绩"] = score + "分";
            dataSource.Rows.Add(dr);
        }
        PublicClass.SaveToFile(PublicClass.GetTable(dataSource, "学员成绩信息"), Server.MapPath("file") + "\\studentScoreList.xls");
        Response.Redirect("file/studentScoreList.xls");
    }
}