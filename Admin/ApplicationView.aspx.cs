using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApplicationView : System.Web.UI.Page
{
    private lmGroup group = new lmGroup();
    private ywCode.ApplicationItem applicationItem = new ywCode.ApplicationItem();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();
    private ywCode.Application application = new ywCode.Application();

    protected void Page_Load(object sender, EventArgs e)
    {
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        this.application = applicationImp.getApplication(applicationId);
        this.lit_status.Text = group.getTypeAbout("ApplicationType", application.TypeId);
        int typeId = application.TypeId;

        //List<ywCode.ApplicationItem> list = applicationImp.getApplicationItems(applicationId);

        this.txt_index.Value = applicationImp.getApplicationItemsCount(applicationId).ToString();
        //this.txt_value.Value = "none";

        switch (typeId)
        {
            case 0:         //新建表单
                this.LinkButton2.Visible = false;
                this.LinkButton3.Visible = false;
                break;
            case 1:         //已写入数据库的表单
                this.Button1.Visible = false;
                this.form.Visible = false;
                this.GridView1.Columns[0].Visible = false;
                break;
            case 2:         //暂停的表单
                this.Button1.Visible = false;
                this.form.Visible = false;
                this.GridView1.Columns[0].Visible = false;
                break;
            case 3:         //已完成的表单
                this.Button1.Visible = false;
                this.form.Visible = false;
                this.LinkButton3.Visible = false;
                this.GridView1.Columns[0].Visible = false;
                break;
            default: 
                break;
        }
    }

    protected string getType(int typeId)
    {
        string sql = "SELECT * FROM [Type] WHERE ([TypeKey] = 'ApplicationItemType' AND [TypeConnection] = " + typeId + ")";
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

    protected void addBtn_Click(object sender, EventArgs e)
    {
        string name = HttpUtility.HtmlEncode(ywManager.ClearHtml(this.name.Value));
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        int typeId = Convert.ToInt32(this.typeId.SelectedValue.ToString());
        int index = Convert.ToInt32(this.txt_index.Value.ToString());
        string value = HttpUtility.HtmlEncode(ywManager.ClearHtml(this.txt_value.Value.ToString()));

        int length = Convert.ToInt32(this.txt_length.Value.ToString());
        int isMust = Convert.ToInt32(this.DropDownList1.SelectedValue.ToString());

        this.applicationItem.ApplicationId = applicationId;
        this.applicationItem.TypeId = typeId;
        this.applicationItem.Name = name;
        this.applicationItem.Index = index;
        this.applicationItem.Value = value;
        this.applicationItem.Length = length;
        this.applicationItem.IsMust = isMust;

        int applicationItemId = this.applicationImp.AddItem(applicationItem);

        if (applicationItemId > 0)
        {
            Response.Redirect("ApplicationView.aspx?ApplicationId=" + applicationId);
        }
        else
        {
            Response.Redirect("ApplicationInsert.aspx");
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //生成表单
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        string sql = applicationImp.CombineSQL(applicationId);
        string sqlUpdate = "UPDATE [Application] SET [TypeId]=1 WHERE [ApplicationId]=" + applicationId;
        group.RunSql(sql);
        group.RunSql(sqlUpdate);

        Response.Redirect("ApplicationView.aspx?ApplicationId=" + applicationId);
    }
    protected void Delete(object sender, EventArgs e)
    {
        //删除
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        application = applicationImp.getApplication(applicationId);
        string sqlDelete = "DELETE FROM [Application] WHERE [ApplicationId]=" + applicationId;
        string sqlDrop = "DROP TABLE [" + application.ApplicationTableName + "]";
        group.RunSql(sqlDelete);
        group.RunSql(sqlDrop);

        Response.Redirect("ApplicationInsert.aspx");
    }

    protected void finish(object sender, EventArgs e)
    {
        //完成表单
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        string sqlUpdate = "UPDATE [Application] SET [TypeId]=3 WHERE [ApplicationId]=" + applicationId;
        group.RunSql(sqlUpdate);

        Response.Redirect("ApplicationView.aspx?ApplicationId=" + applicationId);
    }
}