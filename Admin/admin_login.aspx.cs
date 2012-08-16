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

public partial class Admin_admin_login : System.Web.UI.Page
{
    private string username = "";
    private string password = "";
    private int id = 0;
    private AdminImp adminImp = new AdminImp();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtPassword.Attributes.Add("onkeypress", "EnterTextBox('LinkButton1')");
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        //if(false)
        if (Request.Cookies["logintime"] != null)
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('60秒之内不可连续登陆!')</script>");
            return;
        }
        else if (Request.Cookies["randomcode1"].Value != FormsAuthentication.HashPasswordForStoringInConfigFile(this.code.Text.ToUpper(), "MD5"))
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('验证码不正确，请重新输入!')</script>");
            return;
        }

        Response.Cookies["logintime"].Value = "ok";
        Response.Cookies["logintime"].Expires = DateTime.Now.AddSeconds(60);

        if (txtUser.Text.Equals("") || txtPassword.Text.Equals("") )
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('输入有误!')</script>");
            return;
        }
        else
        {
            username = ywManager.IsValidName(txtUser.Text.Trim()) ? HttpUtility.HtmlEncode(txtUser.Text.Trim().ToString()) : "";
            password = txtPassword.Text;
            id = adminImp.ValidateAdmin(username, password);
            if (id > 0)
            {
                Session["name"] = username;
                Session["id"] = id;
                int power = adminImp.GetAdminPower(id);
                Session["power"] = power;
                Response.Redirect("index.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('不合法的用户名或者密码!')</script>");
                return;
            }
        }
    }
}
