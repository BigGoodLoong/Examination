using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie usercookie = Request.Cookies["nowloginuser"];
        if (usercookie != null)
        {
            usercookie.Expires = DateTime.Now.AddHours(-1);
            Response.AppendCookie(usercookie);
            Response.Write("<script>window.parent.location.href='../../Login.aspx'</script>");
        }
    }
}