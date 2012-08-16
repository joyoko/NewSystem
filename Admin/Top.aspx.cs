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

public partial class admin_Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            Response.Redirect("admin_login.aspx");
        }
        else
        {
            string sessionName = Session["name"].ToString();
            Session["name"] = null;
            Session["name"] = sessionName;
            this.Label1.Text = "用户：" + Session["name"].ToString() + "　　";
        }
    }
}
