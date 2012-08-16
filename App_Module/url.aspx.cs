using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;

public partial class App_Module_url : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string codeStr;
        if (null != Request.QueryString["s"] && ywManager.IsValidUrl(Request.QueryString["s"].ToString()))
        {
            string url = Request.QueryString["s"].ToString();
            codeStr = url;
            this.CreateCheckCodeImage(codeStr,3,4,3);
        }
        else if (null != Request.QueryString["t"] && ywManager.IsValidUrl(Request.QueryString["t"].ToString()))
        {
            //传递t的，给予高分辨率图
            string url = Request.QueryString["t"].ToString();
            codeStr = url;
            this.CreateCheckCodeImage(codeStr,2,2,3);
        }
        else
        {
            this.CreateCheckCodeImage("http://www.floatclouds.com");
        }
    }

    private void CreateCheckCodeImage(string checkCode,int scale,int version,int _width)
    {
        //制定二维码的尺寸和分辨率
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder(88, 151, 165,_width);
        if (scale == 3)
        {
            qrCodeEncoder = new QRCodeEncoder(0, 0, 0, _width);
        }
        else
        {
            qrCodeEncoder = new QRCodeEncoder(88, 151, 165, _width);
        }
        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        qrCodeEncoder.QRCodeScale = scale;
        qrCodeEncoder.QRCodeVersion = version;
        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

        System.Drawing.Image image2;
        String data = checkCode;
        image2 = qrCodeEncoder.Encode(data);

        Graphics g = Graphics.FromImage(image2);
        try
        {
            //画图片的边框线
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image2.Dispose();
        }

    }

    private void CreateCheckCodeImage(string checkCode)
    {
        this.CreateCheckCodeImage(checkCode, 2, 3,3);
    }
}