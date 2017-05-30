using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationDAL;
using ExaminationModels;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Subject_EditSubject : System.Web.UI.Page
{
    public int len = 20;//定义页面表格显示数据的最大条数。赋值为10.
    public static int apge = 1;//定义当前页数，初始化为1.
    public static int Count = 0; //定义科目表数据的总条数，初始化为0。
    public static int Maxapge = 0; //定义科目表数据能显示的最大页数，初始化为0.
    public static DataTable subjectList = new DataTable(); //定义一个Table表格，初始化为null.
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        string url = PublicClass.CheckLogin(usercookie, "main");
        if (url != "")
        {
            Response.Write(url);
            return;
        }
        string Sub_Sc = Request["Sub_Sc"];
        if (!IsPostBack)
        {
            ZyName.Items.Clear();
            List<TbSpeciality> TbSpeciality = TbSpecialityManager.GetAllSpecialityList();
            ZyName.DataSource = TbSpeciality;
            ZyName.DataTextField = "ZyName";
            ZyName.DataValueField = "ZyID";
            ZyName.DataBind();
            ZyName.Items.Insert(0, new ListItem("请选择..", "0"));
            if (Sub_Sc != null)
            {
                int count = TbTestPaperManager.GetAllTestPaperIsExist(int.Parse(Sub_Sc));
                if (count <= 0)
                {
                    TbSubjectManager.Dele_Sub(int.Parse(Sub_Sc));
                }
                else
                    Page.RegisterStartupScript("", "<script>alert('请先删除试卷信息！！')</script>");
            }
            Load_Subject(); //调用方法实现数据加载。
        }
    }
    protected void ButtonOK_Click(object sender, EventArgs e)
    {

        TbSubject subject = new TbSubject();
        subject.KmName = this.KmName.Text;
        subject.Remark = this.Remark.Text;
        subject.ZyID = int.Parse(this.ZyName.SelectedValue);
        if (this.HiddenKmID.Value == "")
        {
            subject.ZyID = int.Parse(this.ZyName.SelectedValue);
            TbSubjectManager.addSubject(subject);
            if (apge <= Maxapge)
                Load_Subject();
            else
            {
                apge--;//到达最后一页，apge已经加一，所以需要减一
            }
        }
        else
        {
            subject.KmID = int.Parse(this.HiddenKmID.Value);
            TbSubjectManager.Get_SubjectBy(subject);
            this.HiddenKmID.Value = "";
        }
        this.KmName.Text = "";
        this.Remark.Text = "";
        Load_Subject();
    }
    protected void ImageBack_Click(object sender, ImageClickEventArgs e)
    {
        apge--; //上一页，将当前页数减一，实现页面向前跳一页。
        Load_Subject();
        RegisterDiv();
    }
    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        apge++;//下一页，将当前页数加一，实现页面向后跳一页。
        Load_Subject();
        RegisterDiv();
    }
    protected void ImageFirst_Click(object sender, ImageClickEventArgs e)
    {
        apge = 1; //需要跳到第一页，当前页面需要变为一。
        Load_Subject();
        RegisterDiv();
    }
    protected void ImageLast_Click(object sender, ImageClickEventArgs e)
    {
        apge = Maxapge; //需要跳到最后一页，当前页面需要变为页面的最大值。
        Load_Subject();
        RegisterDiv();
    }
    protected void ImageGo_Click(object sender, ImageClickEventArgs e)
    {
        int Apge = apge; // 用来保存当前页面数
        apge = int.Parse(this.tzpage.Text.Trim());//将输入的文本值显示转换成int类型
        Load_Subject();
        RegisterDiv();
        this.tzpage.Text = "";
    }

    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 加载科目列表信息
    /// </summary>
    /// <param name="apge">当前页面</param>
    public void Load_Subject()
    {
        string Txt_ZyName = txtSpecName.Value.Trim() == "按专业名模糊查找" ? "" : txtSpecName.Value.Trim();
        if (Txt_ZyName != "按专业名模糊查找" && Txt_ZyName != "" && FirstSxNum == 0)
        {
            apge = 1;
            FirstSxNum = 1;
        }
        subjectList = TbSubjectManager.GetSubject(len, apge, Txt_ZyName);
        Count = TbSubjectManager.GetSubject(Txt_ZyName).Rows.Count;
        if (Count != 0)
        {
            if (Count % len == 0) //当数据库数据能整除10，最大页面数取Count/len的商
                Maxapge = Count / len;
            else
                Maxapge = Count / len + 1;//当数据库数据不能整除10，最大页面数取Count/len的商+1.
        }
        else
            Maxapge = 1;
    }
    protected void btnsx_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;
        Load_Subject();
        RegisterDiv();
    }
    private void RegisterDiv()
    {
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('addSubject', 'addSubjectA', 'btnClose')", true);
        var count = subjectList.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            string str1 = "div" + i;
            string str2 = "a" + i;
            ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('addSubject', '" + str2 + "', 'btnClose')", true);
        }
    }
}