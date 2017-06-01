using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationModels;
using ExaminationBLL;
using System.Data;

public partial class student_Paper : System.Web.UI.Page
{
    public static DataTable Dtb = new DataTable();
    /// <summary>
    /// 根据试卷ID获得图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sjid = Request["SjID"];  //获得传过来的试卷ID
            if (sjid != null)
            {
                int Sjid = int.Parse(sjid);
                DataTable dtable = TbImagesManager.GetImagesBySjid(Sjid);
                if (dtable != null)
                {
                    Dtb = dtable;
                    for (int i = 0; i < dtable.Rows.Count; i++)
                    {
                        string str = "../admin/TestPaper/images/";

                        Image img = new Image();
                        img.ImageUrl = str + dtable.Rows[i]["Tpian"];
                        PanImg.Controls.Add(img);
                    }
                }
            }

        }
    }
}