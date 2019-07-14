using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml;

/// <summary>
/// Summary description for Translate
/// </summary>
public class HelpFunctions
{
    public static string Translate(string ControlName)
    {
        string Lang = "";

        if (HttpContext.Current.Session["LANG"] == null)
        {
            //using (SqlConnection Conn = new SqlConnection())
            //{
            //    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            //    SqlCommand Comm = new SqlCommand();
            //    Comm.Connection = Conn;

            //    Comm.CommandText = @"SELECT CURRENT_LANG FROM VENDOR_USERS WHERE ID = @ID";

            //    Comm.Parameters.Add("@ID", SqlDbType.Int);
            //    Comm.Parameters["@ID"].Value = AuthCookieParse.UserID();



            //    Conn.Open();

            //    SqlDataReader reader = Comm.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        if (reader["CURRENT_LANG"] == DBNull.Value)
            Lang = ConfigurationManager.AppSettings["DEFAULT_LANG"];
        }
            //    else
            //        Lang = reader["CURRENT_LANG"].ToString();
            //}
            //else
            //    Lang = ConfigurationManager.AppSettings["DEFAULT_LANG"];

            //        reader.Close();

            //        HttpContext.Current.Session["LANG"] = Lang;
            //    }
            //}
            //else
            Lang = HttpContext.Current.Session["LANG"].ToString();

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(HttpContext.Current.Server.MapPath("~/languages.xml"));

            XmlNode root = XmlDoc.DocumentElement;

            string result = "";

            try
            {
                result = root[Lang][ControlName].InnerText.Trim();
            }
            catch
            {
                result = "";
            }

            return result;
        
    }
}