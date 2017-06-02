using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationBLL;
using ExaminationModels;
using System.IO; //内存流所需
using System.Drawing;//Bitmap所需
using Aspose;
using System.Data;

public partial class admin_TestPaper_AddTestPaper : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            GetSpeciality();
        }
    }
    int sjid = 0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Load = this.txtName.Text;
        #region 将上传的word文档转换为图片并保存
        try
        {
            //上传的Word文件的保存路径
            string postpath = FileUpload1.PostedFile.FileName;
            if (!postpath.Contains(':') || !postpath.Contains('\\'))
            {
                lblFileMessage.Text = "请设置您当前浏览器：工具-internet选项-安全-自定义级别-将文件上传到服务器是包含本地路径！";
                return;
            }
            this.FileUpload1.PostedFile.SaveAs(postpath);  //保存上传的Word文档
            TbTestPaper paper = new TbTestPaper();
            paper.SjName = txtName.Text;  //试卷名称
            paper.LsName = Request.Cookies["nowloginuser"].Value;      //当前用户
            paper.KmID = int.Parse(ddlSubject.SelectedValue); //科目编号
            paper.KsTime = DateTime.Parse(startTime.Value);   //开始时间
            paper.JsTime = DateTime.Parse(endTime.Value);     //结束时间
            paper.Remark = txtRemark.Text;  //备注
            sjid = TbTestPaperManager.AddPaper(paper);  //添加后的试卷ID
            Word_Convert2Image(postpath);  //调用转换函数
        }
        catch (Exception ex)
        {
            TbTestPaperManager.DeleteTestpaperBySjid(sjid);
            lblSubMessage.Text = ex.Message;
            return;
        }
        #endregion

        if (sjid > 0)
        {
            string dxcount = txtdxcount.Text;  //单选题数
            string duocount = txtduocount.Text; //多选题数
            string pdcount = txtpdcount.Text;   //判断题数
            string jdcount = txtjdcount.Text;   //简答题数
            TbQuestionTypes qtype = new TbQuestionTypes();
            qtype.SjID = sjid;
            if (dxcount != "" && dxcount != "0")  //添加单选题
            {
                qtype.TxName = "单选题";
                qtype.TxCount = int.Parse(dxcount);
                qtype.Txzf = int.Parse(txtdxzf.Text);
                TbQuestionTypesManager.AddQuestionType(qtype);
            }
            if (duocount != "" && duocount != "0")  //添加多选题
            {
                qtype.TxName = "多选题";
                qtype.TxCount = int.Parse(duocount);
                qtype.Txzf = int.Parse(txtduozf.Text);
                TbQuestionTypesManager.AddQuestionType(qtype);
            }
            if (pdcount != "" && pdcount != "0")  //添加判断题
            {
                qtype.TxName = "判断题";
                qtype.TxCount = int.Parse(pdcount);
                qtype.Txzf = int.Parse(txtpdzf.Text);
                TbQuestionTypesManager.AddQuestionType(qtype);
            }
            if (jdcount != "" && jdcount != "0")  //添加简答题
            {
                qtype.TxName = "简答题";
                qtype.TxCount = int.Parse(jdcount);
                qtype.Txzf = int.Parse(txtjdzf.Text);
                TbQuestionTypesManager.AddQuestionType(qtype);
            }
            lblSubMessage.Text = "试卷生成成功！";
        }
    }

    #region 将Word文档转化为图片
    /// <summary>
    /// 将Word文档转化为图片
    /// </summary>
    /// <param name="wordpath">需要转换的word文档的全路径</param>
    public void Word_Convert2Image(string wordpath)
    {
        //第一步：将Word文档转化为Pdf文档（中间过程）
        Aspose.Words.Document doc = new Aspose.Words.Document(wordpath);
        //生成的pdf的路径
        string Pdfpath = Server.MapPath("images") + "Word2Pdf.pdf";
        doc.Save(Pdfpath, Aspose.Words.SaveFormat.Pdf);  //生成中间文档pdf

        //第二部：开始把第一步中转化的pdf文档转化为图片
        int i = 1;
        Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(Pdfpath);
        while (i <= pdfDocument.Pages.Count)
        {
            if (!string.IsNullOrEmpty(Pdfpath))
            {
                GetImage(Pdfpath, i);
                GC.Collect();  //回收内存
            }
            i++;
        }
        //图片转化完成之后，删除中间过程产生的pdf文档
        if (File.Exists(Pdfpath))
            File.Delete(Pdfpath);
    }
    #endregion
    #region 将pdf转化为图片
    /// <summary>
    /// 将PDF 相应的页转换为图片
    /// </summary>
    /// <param name="strPDFpath">PDF 路径</param>
    /// <param name="Page">需要转换的页页码</param>
    private void GetImage(string strPDFpath, int Page)
    {
        GC.Collect();
        string strSavePath = Server.MapPath("images");
        byte[] ImgData = GetImgData(strPDFpath, Page);
        MemoryStream ms = new MemoryStream(ImgData, 0, ImgData.Length);
        Bitmap returnImage = (Bitmap)Bitmap.FromStream(ms);
        string picName = string.Format("{0}_{1}.jpg", CreatePicName(), Page);
        string strImgPath = Path.Combine(strSavePath, picName);  //图片名称可在此修改
        returnImage.Save(strImgPath);
        returnImage.Dispose();
        ms.Dispose();
        AddImage(Page, picName);  //将图片添加到数据库
    }
    /// <summary>
    /// 从PDF中获取首页的图片
    /// </summary>
    /// <param name="PDFPath">PDF 文件路径</param>
    /// <param name="Page">需要获取的第几页</param>
    /// <returns></returns>
    private byte[] GetImgData(string PDFPath, int Page)
    {
        System.Drawing.Image img = PDFView.ConvertPDF.PDFConvert.GetPageFromPDF(PDFPath, Page, 200, "", true);
        return GetDataByImg(img);//读取img的数据并返回
    }
    /// <summary>
    /// 将单页的PDF转换为图片
    /// </summary>
    /// <param name="_image"></param>
    /// <returns></returns>
    private byte[] GetDataByImg(System.Drawing.Image _image)
    {
        System.IO.MemoryStream Ms = new MemoryStream();
        _image.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] imgdata = new byte[Ms.Length];
        Ms.Position = 0;
        Ms.Read(imgdata, 0, Convert.ToInt32(Ms.Length));
        Ms.Close();
        return imgdata;
    }
    #endregion

    /// <summary>
    /// 添加图片
    /// </summary>
    /// <param name="tpym">图片页码</param>
    /// <param name="picName">图片名</param>
    private void AddImage(int tpym, string picName)
    {
        TbImages image = new TbImages();
        image.SjID = sjid;
        image.TpYm = tpym;
        image.Tpian = picName;
        TbImagesManager.AddImage(image);
    }

    private static Random rd1 = new Random();
    private static Random rd2 = new Random();
    /// <summary>
    /// 随机生成一个字符串作为图片名
    /// </summary>
    /// <returns></returns>
    private string CreatePicName()
    {
        string pricName = DateTime.Now.ToString();
        pricName = pricName.Replace("-", "");
        pricName = pricName.Replace("/", "");
        pricName = pricName.Replace(" ", "");
        pricName = pricName.Replace(":", "");
        int num1 = rd1.Next(10000, 99999);
        int num2 = rd2.Next(10, 99);
        pricName += (num1 + num2).ToString();
        return pricName;
    }
    /// <summary>
    /// 绑定专业信息
    /// </summary>
    public void GetSpeciality()
    {
        DataTable dt = TbSpecialityManager.BangdingZy();
        SpecID.DataSource = dt;
        SpecID.DataTextField = "ZyName";
        SpecID.DataValueField = "ZyID";
        SpecID.DataBind();
        SpecID.Items.Insert(0, new ListItem("请选择..", "0"));
    }
    protected void ddlSpec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SpecID.SelectedValue.ToString() != "0")
        {
            int zyid = int.Parse(SpecID.SelectedValue.ToString());
            List<TbSubject> list = TbSubjectManager.GetSubjectListByZyId(zyid);
            ddlSubject.DataSource = list;
            ddlSubject.DataValueField = "KmID";
            ddlSubject.DataTextField = "KmName";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("请选择.."));
        }
        else
        {
            ddlSubject.Items.Clear();
            ddlSubject.Text = "请选择..";
        }
    }
}