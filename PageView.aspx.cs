using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class PageView : System.Web.UI.Page
{
    private ywCode.Apply apply = new ywCode.Apply();
    private ywCode.ApplyImp applyImp = new ywCode.ApplyImp();

    private ywCode.Application application = new ywCode.Application();
    private ywCode.ApplicationImp applicationImp = new ywCode.ApplicationImp();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel panel = this.Panel_Application;
        Label title = new Label();
        int applicationId = 0;
        if (Request.QueryString["ApplicationId"] == null)
        {
            Response.Redirect("http://jwc.cug.edu.cn");
        }
        else
        {
            applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());
            this.application = applicationImp.getApplication(applicationId);

            if (application == null || application.TypeId != 1)
            {
                //只有当报名表状态是“已生成表单”的时候，前端才可以浏览，否则跳转回首页
                Response.Redirect("http://jwc.cug.edu.cn");
            }
        }
        

        this.lit_info.Text = HttpUtility.HtmlDecode(application.Info).Replace("[$1]", "'");
        title.Font.Bold = true;
        title.Font.Size = 20;
        title.Text = application.ApplicationName;

        Table table = new Table();
        List<ywCode.ApplicationItem> list = applicationImp.getApplicationItems(applicationId);

        for (int i = 0; i < list.Count; i++)
        {
            ywCode.ApplicationItem item = list[i];
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            
            tc.Text = item.Name;
            tr.Controls.Add(tc);

            TableCell tc_input = this.getTableCell(item);

            tc_input.ColumnSpan = 2;

            tr.Controls.Add(tc_input);

            table.Controls.Add(tr);
        }
        TableCell tc_code_text = new TableCell();
        tc_code_text.VerticalAlign = VerticalAlign.Top;
        tc_code_text.Text = "验证码";
        TableCell tc_code = new TableCell();

        Literal lit = new Literal();
        string html = "<a href=\"#\" onclick=\"ReflashCode();\" style=\" height:22px; line-height:22px;\">";
        html += "<img src=\"securityCode.aspx\" id=\"code\" style=\"width:55px; height:22px; float:left;\" />";
        html += "<span style=\"height:22px; line-height:22px; float:left;\">看不清?</span>";
        html += "</a>";
        lit.Text = html;

        TextBox box = new TextBox();
        box.ID = "code";

        TableCell tc_input_code = new TableCell();
        tc_input_code.Controls.Add(lit);

        tc_code.Controls.Add(box);
        //tc_code.Controls.Add(lit);
        

        TableRow tr_code = new TableRow();
        tr_code.Controls.Add(tc_code_text);
        tr_code.Controls.Add(tc_code);
        tr_code.Controls.Add(tc_input_code);

        table.Controls.Add(tr_code);

        panel.Controls.AddAt(0, table);
        panel.Controls.AddAt(0, title);
    }

    #region private TableCell getTableCell(ywCode.ApplicationItem item)
    /// <summary>
    /// 根据item内容返回渲染好的TableCell对象
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private TableCell getTableCell(ywCode.ApplicationItem item)
    {
        TableCell tc = new TableCell();

        int typeId = item.TypeId;
        TextBox box = new TextBox();
        DropDownList ddl = new DropDownList();
        string value = item.Value;
        string[] value_list = value.Split(',');
        CheckBoxList cbl = new CheckBoxList();
        cbl.RepeatLayout = RepeatLayout.Table;

        switch (typeId)
        {
            case 0:         //文本
                box.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(box);
                break;
            case 1:         //数字
                box.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(box);
                break;
            case 2:         //身份证号
                box.ID = "Item_" + item.ApplicationConnectionId;
                box.Width = 300;
                tc.Controls.Add(box);
                break;
            case 3:         //单选
                for (int i = 0; i < value_list.Length; i++)
                {
                    ListItem listItem = new ListItem(value_list[i],i + "");
                    ddl.Items.Add(listItem);
                }
                ddl.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(ddl);
                break;
            case 4:         //多选
                for (int i = 0; i < value_list.Length; i++)
                {
                    ListItem listItem = new ListItem(value_list[i],i + "");
                    cbl.Items.Add(listItem);
                }
                cbl.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(cbl);
                break;
            case 5:         //文件
                FileUpload upload = new FileUpload();
                upload.Width = 240;
                upload.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(upload);
                break;
            case 6:         //备注
                box.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(box);
                break;
            case 7:
                FileUpload upload1 = new FileUpload();
                upload1.Width = 240;
                upload1.ID = "Item_" + item.ApplicationConnectionId;
                tc.Controls.Add(upload1);
                break;
            default:
                break;
        };

        return tc;
    }
    #endregion private TableCell getTableCell(ywCode.ApplicationItem item)

    protected void Submit(object sender, EventArgs e)
    {
        int applicationId = Convert.ToInt32(Request.QueryString["ApplicationId"].ToString());

        List<ywCode.ApplicationItem> list = applicationImp.getApplicationItems(applicationId);

        if (Request.Cookies["randomcode1"].Value != FormsAuthentication.HashPasswordForStoringInConfigFile(((TextBox)this.Panel_Application.FindControl("code")).Text.ToUpper(), "MD5"))
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('验证码不正确，请重新输入!')</script>");
            return;
        }
        if (Request.Cookies["logintime"] != null)
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('不可频繁提交报名表!')</script>");
            return;
        }


        //给了一个list
        //
        for (int i = 0; i < list.Count; i++)
        {
            ywCode.ApplicationItem item = list[i];
            int typeId = item.TypeId;

            string controlId = "Item_" + item.ApplicationConnectionId;
            Control control = this.Panel_Application.FindControl(controlId);

            TextBox box;

            switch (typeId)
            {
                case 0:         //文本
                    box = (TextBox)control;
                    item.Value = HttpUtility.HtmlEncode(box.Text.ToString()).Replace("'", "").Replace("\"", "");;
                    break;
                case 1:         //数字
                    box = (TextBox)control;
                    item.Value = HttpUtility.HtmlEncode(box.Text.ToString()).Replace("'", "").Replace("\"", "");;
                    break;
                case 2:         //身份证号
                    box = (TextBox)control;
                    if (this.CheckCidInfo(box.Text)[0].Equals("输入有误"))
                    {
                        ShowError("身份证信息填写不正确！");
                        return;
                    }
                    item.Value = HttpUtility.HtmlEncode(box.Text.ToString()).Replace("'", "").Replace("\"", "");;
                    break;
                case 3:         //单选
                    DropDownList ddl = (DropDownList)control;
                    item.Value = ddl.SelectedValue;
                    break;
                case 4:         //多选
                    CheckBoxList cbx = (CheckBoxList)control;
                    string value = "";
                    bool isFirst = true;
                    for (int j = 0; j < cbx.Items.Count; j++)
                    {
                        if (cbx.Items[j].Selected)
                        {
                            if (isFirst)
                            {
                                value += cbx.Items[j].Value.ToString();
                                isFirst = false;
                            }
                            else
                            {
                                value += "," + cbx.Items[j].Value.ToString();
                            }
                        }
                    }
                    item.Value = value;
                    break;
                case 5:         //文件
                    FileUpload upload = (FileUpload)control;
                    string f_name = System.IO.Path.GetFileName(upload.FileName);
                    string f_type = f_name.Substring(f_name.LastIndexOf(".") + 1);
                    int f_size = upload.PostedFile.ContentLength;//文件大小
                    if (f_size < 500000)//限制500k
                    {
                        if (f_type == "jpg" || f_type == "bmp" || f_type == "gif" || f_type == "GIF" || f_type == "JPG" || f_type == "BMP" || f_type == "jpeg" || f_type == "JPEG")
                        {
                            //返回上层目录的路径
                            //动态生成文件名称
                            f_name = OnlyFilename.GetFilename() + "." + f_type;
                            upload.PostedFile.SaveAs(Server.MapPath("UserPhoto/" + f_name));
                        }
                        else
                        {
                            ShowError("请输入正确的格式！");
                            return;
                        }
                    }
                    else
                    {
                        ShowError("文件尺寸不能超过500kb!");
                        return;
                    }
                    item.Value = f_name;
                    break;
                case 6:         //备注
                    box = (TextBox)control;
                    item.Value = HttpUtility.HtmlEncode(box.Text.ToString()).Replace("'", "").Replace("\"", "");;
                    break;
                case 7:
                    FileUpload upload1 = (FileUpload)control;
                    string f_name1 = System.IO.Path.GetFileName(upload1.FileName);
                    string f_type1 = f_name1.Substring(f_name1.LastIndexOf(".") + 1);
                    int f_size1 = upload1.PostedFile.ContentLength;//文件大小
                    if (f_size1 < 5000000)//限制5000k
                    {
                        if (f_type1 == "doc" || f_type1 == "DOC" 
                            || f_type1 == "docx" || f_type1 == "DOCX" 
                            || f_type1 == "xls" || f_type1 == "XLS" 
                            || f_type1 == "xlsx" || f_type1 == "XLSX"
                            || f_type1 == "ppt" || f_type1 == "PPT"
                            || f_type1 == "pptx" || f_type1 == "PPTX"
                            || f_type1 == "pdf" || f_type1 == "PDF"
                            || f_type1 == "rar" || f_type1 == "RAR"
                            )
                        {
                            //返回上层目录的路径
                            //动态生成文件名称
                            f_name1 = OnlyFilename.GetFilename() + "." + f_type1;
                            upload1.PostedFile.SaveAs(Server.MapPath("UserFile/" + f_name1));
                        }
                        else
                        {
                            ShowError("请输入正确的格式！");
                            return;
                        }
                    }
                    else
                    {
                        ShowError("文件尺寸不能超过5MB!");
                        return;
                    }
                    item.Value = f_name1;
                    break;
                default:
                    break;
            };
        }

        string code = OnlyFilename.GetRandomCode(3);
        string md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(code, "MD5");

        int id = applicationImp.InsertApplicationGetId(list, applicationId,md5);

        if (id == 0)
        {
            this.ShowError("服务器繁忙，将自动刷新页面，请稍后填写！");
            Response.Redirect("PageView.aspx?ApplicationId=" + applicationId);
        }

        //Response.Redirect(id + ".aspx");
        //全部通过验证之后，写入cookies，防止多次登录
        Response.Cookies["logintime"].Value = "ok";
        Response.Cookies["logintime"].Expires = DateTime.Now.AddSeconds(10);
        Response.Redirect("Print/index.aspx?id=" + id + "&m=" + code + "&ApplicationId=" + applicationId);
    }


    #region 检验身份证格式是否符合要求 private string[] CheckCidInfo(string cid)
    /// <summary>
    /// 检验身份证格式是否符合要求
    /// </summary>
    /// <param name="cid">身份证号</param>
    /// <returns>身份证查询返回值</returns>
    private string[] CheckCidInfo(string cid)
    {
        string[] returnValue = new string[] { "0", "0", "0" };
        string[] aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
        double iSum = 0;
        cid = cid.ToUpper();
        System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|X)$");
        System.Text.RegularExpressions.Match mc = rg.Match(cid);
        if (!mc.Success)
        {
            returnValue[0] = "输入有误";
            returnValue[1] = "";
            returnValue[2] = "";

            return returnValue;
        }
        cid = cid.ToLower();
        cid = cid.Replace("x", "a");
        if (aCity[int.Parse(cid.Substring(0, 2))] == null)
        {
            returnValue[0] = "输入有误";
        }
        try
        {
            DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
        }
        catch
        {
            returnValue[0] = "输入有误";
        }
        for (int i = 17; i >= 0; i--)
        {
            iSum += (System.Math.Pow(2, i) % 11) * int.Parse(cid[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);
        }
        if (iSum % 11 != 1)
            returnValue[0] = "输入有误";

        if (returnValue[0].Equals("输入有误"))
        {
            //如果输入有误
            returnValue[1] = "";
            returnValue[2] = "";
        }
        else
        {
            returnValue[0] = "checked";
            returnValue[1] = cid.Substring(6, 4) + "/" + cid.Substring(10, 2) + "/" + cid.Substring(12, 2);
            returnValue[2] = (int.Parse(cid.Substring(16, 1)) % 2 == 1 ? "1" : "2");
        }
        return returnValue;
    }
    #endregion  检验身份证格式是否符合要求 private string[] CheckCidInfo(string cid)

    #region private void ShowError(string Err)
    /// <summary>
    /// 弹出javascript显示错误信息。
    /// </summary>
    /// <param name="Err">错误信息内容</param>
    private void ShowError(string Err)
    {
        ClientScript.RegisterClientScriptBlock(typeof(string), "javascript", "<script>alert('" + Err + "')</script>");
        return;
    }
    #endregion  private void ShowError(string Err)
}