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

public partial class Admin_ChangePwd : System.Web.UI.Page
{
    private lmGroup group = new lmGroup();
    private AdminImp adminImp = new AdminImp();
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

            string sessionId = Session["id"].ToString();
            Session["id"] = null;
            Session["id"] = sessionId;

            string sessionPower = Session["power"].ToString();
            Session["power"] = null;
            Session["power"] = sessionPower;
        }
    }

    protected void add(object sender, EventArgs e)
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

            string sessionId = Session["id"].ToString();
            Session["id"] = null;
            Session["id"] = sessionId;

            string sessionPower = Session["power"].ToString();
            Session["power"] = null;
            Session["power"] = sessionPower;
        }


        //修改密码
        if (adminImp.ValidateAdmin(Session["name"].ToString(), oldPwd.Text) == 0)
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('原密码不正确!')</script>");
            return;
        }
        else if (!this.newPwd1.Text.Equals(this.newPwd2.Text))
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('两次输入的新密码不一致，请重新输入!')</script>");
            return;
        }
        else if (this.newPwd2.Text.Length < 8)
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('密码长度不可小于8!')</script>");
            return;
        }
        else
        {
            adminImp.UpdatePassword(Convert.ToInt16(Session["id"].ToString()), newPwd2.Text);
        }
    }
}