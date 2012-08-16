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

public partial class admin_insertAdmin : System.Web.UI.Page
{
    private Admin admin = new Admin();
    private AdminImp adminImp = new AdminImp();
    private bool bol = false;

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
    protected void addBtn_Click(object sender, EventArgs e)
    {
        admin.Name = this.name.Value;
        admin.Password = this.password.Value.ToString();
        admin.Power = Convert.ToInt32(this.DropDownList1.SelectedValue.ToString());
        bol = adminImp.InsertAdmin(admin);
        if (bol == true)
        {
            Response.Redirect("success.htm");
        }
        else
        {
            Response.Redirect("failure.htm");
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string salt = Guid.NewGuid().ToString();//盐值
        GridView gv = (GridView)sender;
        TableRow tr = gv.Rows[e.RowIndex];
        TextBox tbx = (TextBox)tr.Cells[2].FindControl("TextBox1");
        this.SqlDataSource2.UpdateParameters["salt"].DefaultValue = salt;
        this.SqlDataSource2.UpdateParameters["pwd"].DefaultValue = FormsAuthentication.HashPasswordForStoringInConfigFile(tbx.Text.ToString() + salt, "MD5");
        this.SqlDataSource2.Update();

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
