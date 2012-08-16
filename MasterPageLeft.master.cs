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

public partial class MasterPageLeft : System.Web.UI.MasterPage
{
    lmGroup group = new lmGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        //////////////////////////////////////////////////////////////////////////////
        if (Request.Cookies["expired"] == null)
        {
            int dateId = 0;
            string sqlGetDateId = "SELECT TOP 1 id FROM ywDate WHERE day>'" + DateTime.Now.ToString() + "'";
            DataTable dtDateId = group.GetTable(sqlGetDateId);
            dateId = Convert.ToInt32(dtDateId.Rows[0][0].ToString());

            Response.Cookies["expired"].Value = "ok";
            Response.Cookies["expired"].Expires = DateTime.Now.AddDays(1);
            string sqlDateAdd = "UPDATE ywDate SET count = (count + 1) WHERE id = " + dateId;
            group.RunSql(sqlDateAdd);
        }



        //////////////////////////////////////////////////////////////////////////////////////////
    }
}
