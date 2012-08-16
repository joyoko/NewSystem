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

public partial class Admin_ApplicationInsert : System.Web.UI.Page
{
    private Admin admin = new Admin();
    private AdminImp adminImp = new AdminImp();
    private bool bol = false;
    private lmGroup group = new lmGroup();

    private ywCode.UserPlus _user = new ywCode.UserPlus();
    private ywCode.UserPlusImp userImp = new ywCode.UserPlusImp();

    private ywCode.Application application = new ywCode.Application();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();

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

    protected string getType(int typeId)
    {
        string sql = "SELECT * FROM [Type] WHERE ([TypeKey] = 'ApplicationType' AND [TypeConnection] = " + typeId + ")";
        return group.GetTable(sql).Rows[0]["About"].ToString();

        //return group.getTypeNameById(typeId);
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        string applicationName = HttpUtility.HtmlEncode(ywManager.ClearHtml(this.applicationName.Value));
        string applicationTableName = "";       //插入成功之后赋值，此处无意义
        int typeId = 0;

        string info = HttpUtility.HtmlEncode(this.content.Text.ToString()).Replace("'", "[$1]");

        this.application.ApplicationName = applicationName;
        this.application.ApplicationTableName = applicationTableName;
        this.application.TypeId = typeId;
        this.application.Info = info;

        int applicationId = this.applicationImp.InsertApplicationGetId(application);

        if (applicationId > 0)
        {
            Response.Redirect("ApplicationView.aspx?ApplicationId=" + applicationId);
        }
        else
        {
            Response.Redirect("ApplicationInsert.aspx");
        }
    }
}