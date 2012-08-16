using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data;

public partial class Admin_Excel : System.Web.UI.Page
{

    private ywCode.Application application = new ywCode.Application();
    private int applicationId = 0;
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

        applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
        this.application = applicationImp.getApplication(applicationId);
        List<List<ywCode.ApplicationItem>> list = applicationImp.getAllApplicationItems(applicationId);

        List<ywCode.ApplicationRecord> recordList = applicationImp.getAllApplicationRecord(applicationId);

        if (recordList.Count > 0)
        {
            ToExcel(recordList);
        }
        
    }

    public void ToExcel(List<ywCode.ApplicationRecord> recordList)
    {
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=Excel.xls");
        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
        HttpContext.Current.Response.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
        System.IO.StringWriter tw = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        List<ywCode.ApplicationItem> title_list = recordList[0].Items;

        res("编号" + "\t");
        for (int i = 0; i < title_list.Count; i++)
        {
            
            ywCode.ApplicationItem item = title_list[i];
            if (i < title_list.Count - 1)
            {
                res(item.Name + "\t");
            }
            else
            {
                res(item.Name + "\n");
            }
        }

        for (int i = 0; i < recordList.Count; i++)
        {
            ywCode.ApplicationRecord record = recordList[i];
            res(record.Id + "\t");
            List<ywCode.ApplicationItem> one_list = record.Data;        //一条记录

            for (int t = 0; t < one_list.Count; t++)
            {
                
                ywCode.ApplicationItem item = one_list[t];
                if (t < one_list.Count - 1)
                {
                    if (item.TypeId == 2)
                    {
                        res("=\"" + item.Value + "\"\t");
                    }
                    else
                    {
                        res(item.Value + "\t");
                    }
                }
                else
                {
                    if (item.TypeId == 2)
                    {
                        res("=\"" + item.Value + "\"\n");
                    }
                    else
                    {
                        res(item.Value + "\n");
                    }
                }
            }
        }

        HttpContext.Current.Response.End();
    }



    private void res(string content)
    {
        HttpContext.Current.Response.Write(content);
    }
}