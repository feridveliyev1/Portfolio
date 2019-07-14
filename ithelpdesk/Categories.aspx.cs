using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Linq;

public partial class Categories : System.Web.UI.Page
{
    public string language = "az";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        Result();
    }
    protected void Result()
    {
        var ns = XNamespace.Get("http://www.w3.org/2003/05/soap-envelope");
        var bodyns = XNamespace.Get("http://webservice.web.pg.goldenpay.az/");
        XDocument request = new XDocument(
           new XElement(ns + "Envelope",
           new XElement("Body",
           new XElement(bodyns + "GetCategoryList",
               new XElement("lang", language)
               ))));





        string myrequest = request.ToString();

        myrequest = myrequest.Replace("Body xmlns=\"\"", "Body");





        var response = GoldenPay.API_SEND(myrequest, "https://system.goldenpay.az:44488/web/service/BankWebService");

        XmlDocument doc = new XmlDocument();

        if (response != null)
        {
            var streader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            doc.Load(streader);
        }
        else
        {
            return;
        }

        XmlNodeList xmlstatus = doc.GetElementsByTagName("status");
        XmlNodeList xmlcode = doc.GetElementsByTagName("code");

 


        XmlNodeList xmlCategory = doc.GetElementsByTagName("category");
        XmlNodeList xmlCategoryName = doc.GetElementsByTagName("categoryName");
        XmlNodeList xmltitle = doc.GetElementsByTagName("title");

        DataTable dt = new DataTable();

        dt.Columns.Add("CategoryName");
        dt.Columns.Add("title");

        DataRow row;

        if (xmlCategory.Count > 0)
        {
            for (int i = 0; i < xmlCategory.Count; i++)
            {
                row = dt.NewRow();
                row["CategoryName"] = xmlCategoryName[i].InnerXml;
                row["title"] = xmltitle[i].InnerXml;

                dt.Rows.Add(row);
            }
        }
        else
        {

        }
        Categories_dt.DataSource = dt;
        Categories_dt.DataBind();
    }
    protected void az_btn_click(object sender, EventArgs e)
    {
        language = "az";
        Result();
    }
    protected void en_btn_click(object sender, EventArgs e)
    {
        language = "en";
        Result();
    }
    protected void ru_btn_click(object sender, EventArgs e)
    {
        language = "ru";
        Result();
    }

    public string getImage(object Sender)
    {

        return string.Format("<img src=\"image/{0}.png\"  height=\"100\" width=\"100\"/>",Sender);
    }
}