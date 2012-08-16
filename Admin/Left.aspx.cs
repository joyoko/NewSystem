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

public partial class admin_Left : System.Web.UI.Page
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

            string sessionId = Session["id"].ToString();
            Session["id"] = null;
            Session["id"] = sessionId;

            string sessionPower = Session["power"].ToString();
            Session["power"] = null;
            Session["power"] = sessionPower;
        }

        int power = Convert.ToInt32(Session["power"]);                   //获取管理员权限代码

        if (46 != power)
        {
            //如果不是超级管理员，4-14菜单全部隐藏
            for (int i = 1; i <= 14; i++)
            {
                //先将4-14号菜单设置为不显示
                this.hideMenu(i);
            }

            if (37 == power)
            {
                this.showMenu(6);
            }
            if (38 == power)
            {
                this.showMenu(7);
            }
            if (39 == power)
            {
                this.showMenu(8);
            }
            if (40 == power)
            {
                this.showMenu(9);
            }
            if (41 == power)
            {
                this.showMenu(10);
            }
            if (42 == power)
            {
                this.showMenu(11);
            }
            if (43 == power)
            {
                this.showMenu(12);
            }
            if (44 == power)
            {
                this.showMenu(13);
            }
            if (45 == power)
            {
                this.showMenu(14);
            }
        }

    }

    private void showMenu(int menuId)
    {
        string menuStr = "menu_" + menuId;
        this.FindControl(menuStr).Visible = true;
    }

    private void hideMenu(int menuId)
    {
        string menuStr = "menu_" + menuId;
        this.FindControl(menuStr).Visible = false;
    }
}
