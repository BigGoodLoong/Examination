using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Text;


public partial class admin_Student_ImportStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        string url = PublicClass.CheckLogin(usercookie, "main");
        if (url != "")
        {
            Response.Write(url);
            return;
        }

    }
    /// <summary>
    /// 导入用户
    /// </summary>
    protected void BeginImport_Click(object sender, EventArgs e)
    {

        string path = "";
        if (FileUpload1.PostedFile != null)
            path = FileUpload1.PostedFile.FileName;
        if (path == "")
        {
            lblImportResult.Text = "请选择导入文件！";
            return;
        }
        if (!path.Contains(':') || !path.Contains('\\'))
        {
            lblImportResult.Text = "请设置您当前浏览器：工具-internet选项-安全-自定\n义级别-将文件上传到服务器是包含本地路径！";
            return;
        }
        string hzm = path.Substring(path.LastIndexOf('.') + 1);
        if (hzm != "xls" && hzm != "xlsx")
        {
            lblImportResult.Text = "本系统只支持excel文件格式导入，可以参考下面摸板！";
            return;
        }
        TbUser user = null;
        TbStudent stu = null;
        DataSet ds = ExcelToDataSet(path);
        foreach (DataTable table in ds.Tables)
        {
            foreach (DataRow row in table.Rows)
            {
                user = new TbUser();
                user.Xh = row[3].ToString();
                user.YhName = row[4].ToString();
                user.YhPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(row[5].ToString(), "MD5");
                user.Zt = 3;
                int userIdentity = TbUserManager.AddUser(user);
                if (userIdentity > 0)
                {
                    stu = new TbStudent();
                    stu.XsName = row[0].ToString();
                    stu.XsSex = row[1].ToString();
                    stu.YhID = userIdentity;
                    stu.BjName = row[2].ToString();
                    stu.Remark = "";
                    int stuIdentity = TbStudentManager.AddStudent(stu);
                }
            }
        }
        lblImportResult.Text = "导入成功！";
    }

    /// <summary>
    /// 读取当前Execl文件返回DataSet对象
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public static DataSet ExcelToDataSet(string filepath)
    {
        DataSet ds;
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + filepath +
                        ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
        OleDbConnection myConn = new OleDbConnection(strCon);
        string strCom = " SELECT * FROM [学员信息$]";
        myConn.Open();
        OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
        ds = new DataSet();
        myCommand.Fill(ds);
        myConn.Close();
        return ds;
    }
    /// <summary>
    /// 导出学生信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("file") + "\\studentinfo.xls";
        if (File.Exists(path))
            File.Delete(path);
        DataTable dt = TbStudentManager.GetAllStuInfo();
        PublicClass.SaveToFile(PublicClass.GetTable(dt, "学员信息"), Server.MapPath("file") + "\\studentinfo.xls");
        Response.Redirect("file/studentinfo.xls");
    }
    /// <summary>
    /// 清空学生信息j
    /// </summary>
    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        TbStudentManager.DeleteAllStu();
        TbUserManager.DeleteAllStuUser();
        lblClear.Text = "学员以全部清空！";
    }


}