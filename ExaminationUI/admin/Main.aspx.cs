using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//|5|1|a|s|p|x
public partial class admin_Main : System.Web.UI.Page
{
    public static string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        if (usercookie == null)
            Response.Redirect("../Login.aspx");
        if (!IsPostBack)
        {
            string nowstatus = Request["status"];
            if (nowstatus != null)
            {
                try
                {
                    status = System.Text.Encoding.Default.GetString(Convert.FromBase64String(nowstatus));
                    if (status != "1" && status != "2")
                        Response.Redirect("../error.aspx");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Base-64"))
                        Response.Redirect("../error.aspx");
                }
            }
            else
                Response.Redirect("../error.aspx");

        }
    }
}