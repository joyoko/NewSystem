using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApplicationShow : System.Web.UI.Page
{
    private ywCode.ApplicationItem applicationItem = new ywCode.ApplicationItem();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();
    private ywCode.Application application = new ywCode.Application();
    private int applicationId;

    protected void Page_Load(object sender, EventArgs e)
    {
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        this.application = applicationImp.getApplication(applicationId);
        int typeId = application.TypeId;

        System.Data.DataTable dt = applicationImp.getAllApplicationItemsTable(applicationId);
        List<ywCode.ApplicationItem> columnsItems = applicationImp.getApplicationItems(applicationId);

        this.GridView1.DataSource = dt;

        BoundField bfIndex = new BoundField();
        bfIndex.DataField = "Id";
        bfIndex.HeaderText = "序号";
        this.GridView1.Columns.Add(bfIndex);

        for (int i = 0; i < columnsItems.Count; i++)
        {
            ywCode.ApplicationItem item = columnsItems[i];
            BoundField bf = new BoundField();
            bf.DataField = "Item_" + item.ApplicationConnectionId;
            bf.HeaderText = item.Name;
            this.GridView1.Columns.Add(bf);
        }

        this.GridView1.DataBind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}