using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    lmGroup group = new lmGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["expired"] == null)
        {
            group.setTodayVisitCountAdd(1);
            Response.Cookies["expired"].Value = "ok";
            Response.Cookies["expired"].Expires = DateTime.Now.AddDays(1);
        }

    }

}
