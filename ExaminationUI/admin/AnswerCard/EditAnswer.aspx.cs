using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.Data;
using System.Data.SqlClient;


public partial class admin_AnswerCard_EditAnswer : System.Web.UI.Page
{
    public static DataTable objTopicList = null;//定义一个Table对象，初始化为null
    public int len = 20;//页面显示信息的最大列数，初始化为15
    public static int Pages = 1;//定义当前页面的页数，初始化为1
    public static int count = 0;//定义试卷列表信息的总条数，初始化为0
    public static int maxPage = 0;//定义显示页面的最大页数，初始化为0
    public static int zt = 0;//定义已批阅状态，状态初始化为3
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllTestpaperInfoCount();
        }
    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 加载试卷列表信息
    /// </summary>
    public void GetAllTestpaperInfoCount()
    {
        string EditAnwer = txtEditAnwer.Value.Trim() == "按姓名、学号、试卷名和科目名模糊查找" ? "" : txtEditAnwer.Value.Trim();
        if (EditAnwer != "按姓名、学号、试卷名和科目名模糊查找" && EditAnwer != "")
            Pages = 1;
        //判断已批阅是否选中
        if ((this.checks.Checked == false && this.CheckBox1.Checked == false) || (this.checks.Checked == true && this.CheckBox1.Checked == true))
        {
            objTopicList = tbAnswerCardManager.GetObjTopicList(len, Pages, EditAnwer);
            count = tbAnswerCardManager.getAnswerCardCount(EditAnwer).Rows.Count;
        }
        else if (this.checks.Checked == true && this.CheckBox1.Checked == false)
        {
            zt = 3;//已批阅状态为3
            objTopicList = tbAnswerCardManager.GetObjTopicList(len, Pages, EditAnwer, zt);
            count = tbAnswerCardManager.getAnswerCardCount(EditAnwer, zt).Rows.Count;
        }
        else if (this.checks.Checked == false && this.CheckBox1.Checked == true)
        {
            zt = 2;//未批阅状态为2
            objTopicList = tbAnswerCardManager.GetObjTopicList(len, Pages, EditAnwer, zt);
            count = tbAnswerCardManager.getAnswerCardCount(EditAnwer, zt).Rows.Count;
        }
        if (count % len == 0)
        {
            if (count > 0)
                maxPage = count / len;
            else
                maxPage = 1;
        }
        else
            maxPage = count / len + 1;
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "CheckStatus()", true);
    }

    /// <summary>
    /// 跳转到首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageFrist_Click(object sender, ImageClickEventArgs e)
    {
        Pages = 1;
        GetAllTestpaperInfoCount();
    }
    /// <summary>
    /// 跳转到上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageBack_Click(object sender, ImageClickEventArgs e)
    {
        Pages--;
        GetAllTestpaperInfoCount();
    }
    /// <summary>
    /// 跳转到下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        Pages++;
        GetAllTestpaperInfoCount();
    }
    /// <summary>
    /// 跳转到尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageLast_Click(object sender, ImageClickEventArgs e)
    {
        Pages = maxPage;
        GetAllTestpaperInfoCount();
    }
    /// <summary>
    /// 跳转到指定页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageGo_Click(object sender, ImageClickEventArgs e)
    {
        Pages = int.Parse(this.tzpage.Text);
        GetAllTestpaperInfoCount();
        this.tzpage.Text = "";
    }
    protected void btnEditAnwer_Click(object sender, EventArgs e)
    {
        GetAllTestpaperInfoCount();
    }
}