using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null || Session["name"].ToString() != "admin")
        {
            Response.Redirect("admin_login.aspx");
        }
        else
        {
            string sessionName = Session["name"].ToString();
            Session["name"] = null;
            Session["name"] = sessionName;

            string sessionId = Session["id"].ToString();
            Session["id"] = null;
            Session["id"] = sessionId;

            string sessionPower = Session["power"].ToString();
            Session["power"] = null;
            Session["power"] = sessionPower;
        }
    }
}
