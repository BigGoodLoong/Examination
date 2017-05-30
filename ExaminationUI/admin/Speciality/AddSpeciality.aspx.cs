using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Speciality_AddSpeciality : System.Web.UI.Page
{
    public static DataTable specialityList = new DataTable();//定义一个Table对象，初始化为null
    public int len = 20;//页面显示信息的最大列数，初始化为15
    public static int Pages = 1;//定义当前页面的页数，初始化为1
    public static int count = 0;//定义专业信息的总条数，初始化为0
    public static int maxPage = 0;//定义显示页面的最大页数，初始化为0
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
            string zyid = Request["ZyID"];
            if (zyid != null)
            {
                //判断是否存在科目信息,存在则提示不能删除专业信息，不存在则执行删除操作
                if (TbSubjectManager.QuerySubjectInfo(int.Parse(zyid)) <= 0)
                {
                    //根据专业ID删除班级、老师信息表以及专业信息表对应的信息
                    TbClassManager.DeleteClassByZyID(int.Parse(zyid));
                    TbTeacherManager.DeleteTeaByZyID(int.Parse(zyid));
                    TbSpecialityManager.DeleteSpecByZyID(int.Parse(zyid));
                }
                else
                    Page.RegisterStartupScript("", "<script>alert('存在专业对应的科目信息，如需继续执行删除操作，请先删除科目信息！')</script>");
            }
            GetAllSpenIntoCount();
        }
    }
    /// <summary>
    /// 新增界面确定添加按钮单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnbc_Click(object sender, EventArgs e)
    {
        TbSpeciality special = new TbSpeciality();

        special.ZyName = this.ZyName.Text;
        special.Remark = this.Remark.Text;
        if (hidSpecID.Value != "")
        {
            special.ZyID = int.Parse(this.hidSpecID.Value);
            TbSpecialityManager.EditSpecByID(special);
            this.hidSpecID.Value = "";
        }
        else
        {
            TbSpecialityManager.addSpeciality(special.ZyName, special.Remark);
        }
        this.ZyName.Text = "";
        this.Remark.Text = "";
        GetAllSpenIntoCount();//重新调用方法实现数据加载


    }
    static int FirstSxNum = 0;/*声明变量，初始化为0，用于判断筛选条件是否改变*/

    /// <summary>
    /// 获得专业信息的条数及页面信息
    /// </summary>
    /// <returns></returns>
    public void GetAllSpenIntoCount()
    {
        string specname = txtSpecName.Value.Trim() == "按专业名模糊查找" ? "" : txtSpecName.Value.Trim();
        if (specname != "按专业名模糊查找" && specname != "" && FirstSxNum == 0)
        {
            Pages = 1;
            FirstSxNum = 1;
        }
        specialityList = TbSpecialityManager.GetAllSpecialityinfo(len, Pages, specname);
        count = TbSpecialityManager.GetAllSpecialityinfo(specname).Rows.Count;
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
    /// 跳转到首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageFrist_Click(object sender, ImageClickEventArgs e)
    {
        Pages = 1;
        GetAllSpenIntoCount();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageEnd_Click(object sender, ImageClickEventArgs e)
    {
        Pages = maxPage;
        GetAllSpenIntoCount();
    }
    /// <summary>
    /// 跳转到上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageBack_Click(object sender, ImageClickEventArgs e)
    {
        Pages--; //将当前页数减一，实现页面向前跳一页。
        GetAllSpenIntoCount();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        Pages++;//将当前页数加一，实现页面向后跳一页。
        GetAllSpenIntoCount();
        RegisterEvent();
    }
    /// <summary>
    /// 跳转到指定页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageGO_Click(object sender, ImageClickEventArgs e)
    {
        int pages = Pages;
        Pages = int.Parse(this.tzpage.Text.Trim());//将输入的文本值显示转换成int类型
        GetAllSpenIntoCount();
        RegisterEvent();
        this.tzpage.Text = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        FirstSxNum = 0;
        GetAllSpenIntoCount();
        RegisterEvent();
    }

    /// <summary>
    /// 重新注册事件
    /// </summary>
    private void RegisterEvent()
    {
        ScriptManager.RegisterStartupScript(Page, typeof(string), "div", "AlterDivAndClose('Addzy', 'addspecA', 'btnClose')", true);
        var count = specialityList.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            string str1 = "div" + i;
            string str2 = "a" + i;
            ScriptManager.RegisterStartupScript(Page, typeof(string), str1, "AlterDivAndClose('Addzy', '" + str2 + "', 'btnClose')", true);
        }
    }
}