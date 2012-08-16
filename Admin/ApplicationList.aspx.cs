using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApplicationList : System.Web.UI.Page
{
    private lmGroup group = new lmGroup();
    private ywCode.ApplicationItem applicationItem = new ywCode.ApplicationItem();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string getType(int typeId)
    {
        string sql = "SELECT * FROM [Type] WHERE ([TypeKey] = 'ApplicationType' AND [TypeConnection] = " + typeId + ")";
        return group.GetTable(sql).Rows[0]["About"].ToString();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //GridView gv = (GridView)sender;
        //TableRow tr = gv.Rows[e.NewEditIndex];
        //TextBox tbx = (TextBox)tr.Cells[2].FindControl("TextBox1");
        //tbx.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(tbx.Text.ToString(), "MD5"); 
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}