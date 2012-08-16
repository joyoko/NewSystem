using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Print_index : System.Web.UI.Page
{
    private int applicationId = 0;
    private ywCode.Application application = new ywCode.Application();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();
    private List<ywCode.ApplicationItem> list = new List<ywCode.ApplicationItem>();
    private List<ywCode.ApplicationItem> list_item = new List<ywCode.ApplicationItem>();

    private int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["m"] != null && Request.QueryString["ApplicationId"] != null)
        {
            string sid = Request.QueryString["id"];
            string aid = Request.QueryString["ApplicationId"];
            if (ywManager.isInt(sid) && ywManager.isInt(aid))
            {
                id = Convert.ToInt32(sid);
                applicationId = Convert.ToInt32(aid);
                application = applicationImp.getApplication(applicationId);
                string salt = Request.QueryString["m"];
                list = applicationImp.getApplicationItems(applicationId, id, salt);
                list_item = applicationImp.getApplicationItems(applicationId);

                int num = 100000 + id;

                this.code.Text = "SN:A_" + num;

                //this.Image1.ImageUrl = "../App_Module/url.aspx?s=http://jwc.cug.edu.cn/app/print?id=" + id + "%26m=" + salt + "%26ApplicationId=" + applicationId;

                //this.lit_info.Text = application.Info;

                if (list == null)
                {
                    Response.Redirect("http://jwc.cug.edu.cn");
                }
            }
            else
            {
                Response.Redirect("http://jwc.cug.edu.cn");
            }
        }
        else
        {
            Response.Redirect("http://jwc.cug.edu.cn");
        }

        this.title.InnerText = application.ApplicationName;

        Panel panel = this.Panel_Info;

        Table table = new Table();
        table.CssClass = "news_list_table";
        table.BorderWidth = 1;
        table.Width = 600;

        System.Data.DataTable dt = applicationImp.getAllApplicationItemsTable(applicationId, 0, id);
        if (dt.Rows.Count == 0)
        {
            Response.Redirect("http://jwc.cug.edu.cn");
        }
        System.Data.DataRow dr = dt.Rows[0];

        for (int i = 0; i < list.Count; i++)
        {
            ywCode.ApplicationItem item = list[i];
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();

            tc.Text = item.Name;
            tr.Controls.Add(tc);

            TableCell tcc = ywCode.Global.getTableCellView(item, list_item[i]);

            tr.Controls.Add(tcc);

            table.Controls.Add(tr);
        }
        panel.Controls.AddAt(0, table);
        panel.Controls.AddAt(0, title);


    }
    /// <summary>
    /// 根据item内容返回渲染好的TableCell对象
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private TableCell getTableCell(ywCode.ApplicationItem item)
    {
        TableCell tc = new TableCell();

        int typeId = item.TypeId;
        string value = item.Value;
        string[] value_list = value.Split(',');

        Literal lit = new Literal();


        switch (typeId)
        {
            case 0:         //文本
                lit.Text = value;
                break;
            case 1:         //数字
                lit.Text = value;
                break;
            case 2:         //身份证号
                lit.Text = value;
                break;
            case 3:         //单选
                lit.Text = value;
                break;
            case 4:         //多选
                lit.Text = value;
                break;
            case 5:         //相片
                string html = "<img src='../UserPhoto/" + value + "' width='150' height='210' />";
                lit.Text = html;
                break;
            case 6:         //备注
                lit.Text = value;
                break;
            case 7:
                string html1 = "<a href='../UserFile/" + value + "'>查看文件</a>";
                lit.Text = html1;
                break;
            default:
                break;
        };

        tc.Controls.Add(lit);

        return tc;
    }



    #region 根据性别代码返回性别字符串 private string getSexByInt(string sex)
    /// <summary>
    /// 根据性别代码返回性别字符串
    /// </summary>
    /// <param name="sex">性别代码</param>
    /// <returns>性别字符串</returns>
    private string getSexByInt(string sex)
    {
        if ("1" == sex)
        {
            return "男";
        }
        else
        {
            return "女";
        }
    }
    #endregion 根据性别代码返回性别字符串 private string getSexByInt(string sex)

    #region 返回预设的type类型 private string getType(int id)
    /// <summary>
    /// 返回预设的type类型
    /// </summary>
    /// <param name="id">类型id</param>
    /// <returns>类型（文本描述）</returns>
    private string getType(int id)
    {
        switch (id)
        {
            case 0:
                return "未选择";
            case 1:
                return "注册评估师";
            case 2:
                return "非注册评估师";
            case 3:
                return "从业人员";
            default:
                return "其他";
        }
    }
    #endregion 返回预设的type类型 private string getType(int id)

    #region 返回预设的【民族】类型 private string getNation(int id)
    /// <summary>
    /// 返回预设的【民族】类型
    /// </summary>
    /// <param name="id">类型id</param>
    /// <returns>类型（文本描述）</returns>
    private string getNation(int id)
    {
        switch (id)
        {
            case 1: return "汉族";
            case 8: return "壮族";
            case 11: return "满族";
            case 3: return "回族";
            case 6: return "苗族";
            case 5: return "维吾尔族";
            case 15: return "土家族";
            case 7: return "彝族";
            case 2: return "蒙古族";
            case 4: return "藏族";
            case 9: return "布依族";
            case 12: return "侗族";
            case 13: return "瑶族";
            case 10: return "朝鲜族";
            case 14: return "白族";
            case 16: return "哈尼族";
            case 17: return "哈萨克族";
            case 19: return "黎族";
            case 18: return "傣族";
            case 22: return "畲族";
            case 20: return "傈僳族";
            case 37: return "仡佬族";
            case 26: return "东乡族";
            case 23: return "高山族";
            case 24: return "拉祜族";
            case 25: return "水族";
            case 21: return "佤族";
            case 27: return "纳西族";
            case 33: return "羌族";
            case 30: return "土族";
            case 32: return "仫佬族";
            case 38: return "锡伯族";
            case 29: return "柯尔克孜族";
            case 31: return "达斡尔族";
            case 28: return "景颇族";
            case 36: return "毛南族";
            case 35: return "撒拉族";
            case 34: return "布朗族";
            case 41: return "塔吉克族";
            case 39: return "阿昌族";
            case 40: return "普米族";
            case 45: return "鄂温克族";
            case 42: return "怒族";
            case 49: return "京族";
            case 56: return "基诺族";
            case 46: return "德昂族";
            case 47: return "保安族";
            case 44: return "俄罗斯族";
            case 48: return "裕固族";
            case 43: return "乌兹别克族";
            case 54: return "门巴族";
            case 52: return "鄂伦春族";
            case 51: return "独龙族";
            case 50: return "塔塔尔族";
            case 53: return "赫哲族";
            case 55: return "珞巴族";
            default: return "未选择";
        }
    }
    #endregion 返回预设的【民族】类型 private string getNation(int id)

    private void set_tr(List<ywCode.ApplicationItem> items, System.Data.DataRow dr, TableRow tr, string name)
    {
        ywCode.ApplicationItem item = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Name.Equals(name))
            {
                item = items[i];
                this.set_tr(item, dr, tr);
            }
        }
    }

    private void set_tr(ywCode.ApplicationItem item, System.Data.DataRow dr, TableRow tr)
    {
        //ywCode.ApplicationItem item = columnsItems[i];
        string str_index = "Item_" + item.ApplicationConnectionId;
        ywCode.ApplicationItem _data = new ywCode.ApplicationItem();
        _data.Value = dr[str_index].ToString();
        TableCell tc = ywCode.Global.getTableCellView(_data, item);
        tr.Controls.Add(tc);
    }
}