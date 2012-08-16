using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_login_out : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            Session["name"] = null;
        }
        if(Session["id"] != null)
        {
            Session["id"] = null;
        }
        if (Session["power"] != null)
        {
            Session["power"] = null;
        }
        Response.Redirect("admin_login.aspx");
    }
}