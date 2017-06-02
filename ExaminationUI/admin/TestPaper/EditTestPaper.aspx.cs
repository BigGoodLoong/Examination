using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationDAL;
using ExaminationModels;
using System.IO;

public partial class admin_TestPaper_EditTestPaper : System.Web.UI.Page
{
    public static DataTable testPaperList = new DataTable();
    public int len = 20;   //定义每个页面显示的条数，初始化为20
    public static int page = 1;  //定义当前页面的页数，初始化为1
    public static int Count = 0; //定义试卷信息的总条数，初始化为0
    public static int Maxpage = 0; //定义页面的最大页面数，初始化为0
    public static string YhID = "1";
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
            string action = Request["action"];
            string sjid = Request["sjid"];
            if (action != null && sjid != null)
            {
                int id = int.Parse(sjid);
                if (action.Equals("delete"))
                {
                    //删除服务器上面对应试卷的所有图片
                    foreach (DataRow row in TbImagesManager.GetImagesBySjid(id).Rows)
                    {
                        string path = Server.MapPath("images/" + row["Tpian"].ToString());
                        if (File.Exists(path))
                            File.Delete(path);
                    }
                    TbImagesManager.DeleteImageBySjid(id);
                    TbQuestionTypesManager.DeleteQuestionTypesBySjid(id);
                    TbTestPaperManager.DeleteTestpaperBySjid(id);
                }
            }
            GetAllTestPaperInfo();
        }
    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 加载科目列表信息
    /// </summary>
    public void GetAllTestPaperInfo()
    {
        string testpaper = txtTestPaperName.Value.Trim() == "按试卷名、科目名模糊查找" ? "" : txtTestPaperName.Value.Trim();
        if (testpaper != "按试卷名、科目名模糊查找" && testpaper != "" && FirstSxNum == 0)
        {
            page = 1;
            FirstSxNum = 1;
        }
        testPaperList = TbTestPaperManager.GetAllTestpaperByPage(len, page, testpaper);
        Count = TbTestPaperManager.GetAllTestpaperCount(testpaper).Rows.Count;
        if (Count % len == 0)//获得数据库数据整除len值，最大页面数为（Count/len）的商
        {
            if (Count > 0)
                Maxpage = Count / len;
            else
                Maxpage = 1;
        }
        else
        {
            Maxpage = Count / len + 1;//获得数据库数据整除len值，最大页面数为（Count/len+1）的商
        }
    }
    /// <summary>
    /// 跳转到首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageFrist_Click(object sender, ImageClickEventArgs e)
    {
        page = 1;
        GetAllTestPaperInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageBack_Click(object sender, ImageClickEventArgs e)
    {
        page--;
        GetAllTestPaperInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        page++;
        GetAllTestPaperInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageLast_Click(object sender, ImageClickEventArgs e)
    {
        page = Maxpage;
        GetAllTestPaperInfo();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到指定页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageGo_Click(object sender, ImageClickEventArgs e)
    {
        page = int.Parse(this.tzpage.Text.Trim());
        GetAllTestPaperInfo();
        this.tzpage.Text = "";
    }
    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        //if ((PublicClass.GetMinutes(Convert.ToDateTime(this.startTime.Text), Convert.ToDateTime(this.endTime.Text))) <= 0)
        //{
        //    this.Lbltime.Text = "开始时间必须大于结束时间";
        //    return;
        //}
        TbTestPaper testpaper = new TbTestPaper();
        testpaper.SjName = this.sjnameid.Text;
        testpaper.KsTime = Convert.ToDateTime(this.startTime.Text);
        testpaper.JsTime = Convert.ToDateTime(this.endTime.Text);
        testpaper.Remark = this.textRemark.Text;
        DateTime CurrentDate = new DateTime();
        CurrentDate = DateTime.Now;
        int time = DateTime.Compare(testpaper.KsTime, testpaper.JsTime);
        if (hidSjID.Value != "")
        {
            testpaper.SjID = int.Parse(this.hidSjID.Value);
            TbTestPaperManager.updateTestPaper(testpaper.SjName, testpaper.KsTime, testpaper.JsTime, testpaper.Remark, testpaper.SjID);
            this.hidSjID.Value = "";
        }
        this.sjnameid.Text = "";
        this.startTime.Text = "";
        this.endTime.Text = "";
        this.textRemark.Text = "";
        GetAllTestPaperInfo();
    }
    /// <summary>
    /// 重新注册事件
    /// </summary>
    public void RegisterEvent()
    {
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('editid', 'editidA', 'btnClose')", true);
        var count = testPaperList.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            string str1 = "div" + i;
            string str2 = "a" + i;
            ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('editid', '" + str2 + "', 'btnClose')", true);
        }
    }
    protected void btntp_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;
        GetAllTestPaperInfo();
        RegisterEvent();
    }
}