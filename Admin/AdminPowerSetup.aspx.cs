using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_AdminPowerSetup : System.Web.UI.Page
{
    lmGroup group = new lmGroup();
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

    protected void getname(object sender, EventArgs e)
    {
        Label lb = (Label)sender;
        string sql = "SELECT * FROM Admin WHERE id=" + Request.QueryString["id"].ToString();

        DataTable dt = group.GetTable(sql);
        lb.Text = "您正在设置管理员<font style='font-weight:bold; color:red;'>" + dt.Rows[0]["name"].ToString() + "</font>的管理权限";
    }
    protected void submit(object sender, EventArgs e)
    {
        CheckBoxList box1 = (CheckBoxList)this.FormView1.FindControl("CheckBoxList3");
        CheckBoxList box2 = (CheckBoxList)this.FormView1.FindControl("CheckBoxList2");

        string sqlClear = "DELETE FROM ywAdminPowerConnection WHERE adminId=" + Request.QueryString["id"].ToString();
        group.RunSql(sqlClear);
        for (int i = 0; i < box1.Items.Count; i++)
        {
            if (box1.Items[i].Selected)
            {
                if (check(Convert.ToInt32(box1.Items[i].Value.ToString())))
                {
                    string sql = "INSERT INTO [ywAdminPowerConnection]([powerId],[adminId]) VALUES (" + box1.Items[i].Value.ToString() + "," + Request.QueryString["id"].ToString() + ")";
                    group.RunSql(sql);
                }

            }
        }
    }

    private bool check(int powerId)
    {
        bool returnValue = false;
        string sql = "SELECT * FROM [ywAdminPowerConnection] WHERE [powerId]=" + powerId + " AND [adminId]=" + Request.QueryString["id"].ToString();
        DataTable dt = group.GetTable(sql);
        if (dt.Rows.Count > 0)
        {
            //说明已经被添加过
            returnValue = false;
        }
        else
        {
            returnValue = true;
        }
        return returnValue;
    }

    protected void checking(object sender, EventArgs e)
    {
        CheckBoxList box = (CheckBoxList)sender;
        for (int i = 0; i < box.Items.Count; i++)
        {
            if (!check(Convert.ToInt32(box.Items[i].Value.ToString())))
            {
                box.Items[i].Selected = true;
            }
        }
    }
}