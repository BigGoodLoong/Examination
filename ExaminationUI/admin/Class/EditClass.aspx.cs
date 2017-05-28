using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using System.Data;
using System.Data.SqlClient;
using ExaminationDAL;
using ExaminationModels;
public partial class admin_Class_EditClass : System.Web.UI.Page
{
    public static DataTable classList = new DataTable();
    public int len = 20;//定义当前页面的记录数，初始化为15
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
            string bjid = Request["BjID"];
            if (bjid != null)
            {
                TbClassManager.DeleteClassInfo(int.Parse(bjid));
            }
            GetPageInfo();
            //绑定专业名称
            DataTable dt = TbSpecialityManager.BangdingZy();
            textZy.DataSource = dt;
            textZy.DataTextField = "ZyName";
            textZy.DataValueField = "ZyID";
            textZy.DataBind();
            textZy.Items.Insert(0, new ListItem("请选择..", "0"));
        }
    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 获取页面信息
    /// </summary>
    public void GetPageInfo()
    {
        if (classList != null)
        {
            string ClassNameOrNj = txtClassName.Value.Trim() == "按班级名、年级或专业名模糊查找" ? "" : txtClassName.Value.Trim();
            if (ClassNameOrNj != "按班级名、年级或专业名模糊查找" && ClassNameOrNj != "" && FirstSxNum == 0)
            {
                nowPage = 1;
                FirstSxNum = 1;
            }
            Record = TbClassManager.GetAllClassInfo(ClassNameOrNj).Rows.Count;/*记录总数*/
            classList = TbClassManager.GetAllClassInfoPage(len, nowPage, ClassNameOrNj);
            if (Record % len == 0)
            {
                if (Record > 0)
                    Pages = (Record / len);
                else
                    Pages = 1;
            }
            else
                Pages = (Record / len) + 1;
        }

    }
    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        TbClass Class = new TbClass();
        Class.BjName = this.textName.Text;
        Class.Nj = this.textNj.Text;
        Class.ZyID = int.Parse(this.textZy.SelectedValue);//专业
        DataTable table = TbClassManager.Sel_Bj(Class.BjName, Class.Nj);
        int Count = table.Rows.Count;
        if (hidClassID.Value != "")
        {
            Class.BjID = int.Parse(this.hidClassID.Value);
            TbClassManager.EditClassByID(Class);
            this.hidClassID.Value = "";
            this.textName.Text = "";
            this.textNj.Text = "";
        }
        else
        {
            TbClassManager.AddClass(Class.BjName, Class.Nj, Class.ZyID);
            textName.Text = "";
            textNj.Text = "";
        }
        GetPageInfo();
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
    protected void JumpPage_Click(object sender, ImageClickEventArgs e)
    {
        nowPage = int.Parse(this.tzpage.Value.Trim());
        GetPageInfo();
        RegisterEvent();
        this.tzpage.Value = "";
    }
    protected void ButtonNO_Click(object sender, EventArgs e)
    {
        this.textName.Text = "";
        this.textNj.Text = "";
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;/*筛选条件改变*/
        GetPageInfo();
        RegisterEvent();
    }

    private void RegisterEvent()
    {
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('addClass', 'addclassA', 'btnClose')", true); ;
        if (classList != null)
        {
            var count = classList.Rows.Count;
            for (int i = 1; i <= count; i++)
            {
                string str1 = "div" + i;
                string str2 = "a" + i;
                ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('addClass', '" + str2 + "', 'btnClose')", true);
            }
        }
    }
}