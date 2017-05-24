using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class html_left : System.Web.UI.Page
{
    public static string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            status = Request["status"] != null ? Request["status"].ToString() : "1";
        }
    }
}