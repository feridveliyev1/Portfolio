using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Security;
using System.Net.Sockets;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LANG"]==null)
        {
           Session["LANG"] = "EN";
        }
        Login_edt.Attributes.Add("placeholder", HelpFunctions.Translate("default_login_placeholder"));


        Password_edt.Attributes.Add("placeholder", HelpFunctions.Translate("default_password_placeholder"));
    }
    protected void Login_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT ID,(FNAME + ' ' + LNAME) AS FIO,PHONENUMBER,EMAIL,PASSWORD,CURRENT_LANG,STATUS FROM VENDOR_USERS WHERE EMAIL=@EMAIL AND PASSWORD=@PASSWORD";

            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar);

            cmd.Parameters["@EMAIL"].Value = Login_edt.Text;

            cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);

            cmd.Parameters["@PASSWORD"].Value = Password_edt.Text;

            conn.Open();

            SqlDataReader reader;

            reader = cmd.ExecuteReader();

            string CookiesString = "";

            if (reader.Read())
            {
                CookiesString = reader["ID"].ToString() + "|" + reader["FIO"].ToString() + "|" + reader["EMAIL"].ToString() + "|" + reader["STATUS"] + "|" + reader["PHONENUMBER"] + "|" + reader["CURRENT_LANG"] + "|";
                FormsAuthentication.SetAuthCookie(CookiesString, true);

                reader.Close();
            }
            else
            {
                this.RegisterStartupScript("alert", "<script lang='javascript'>alert('User not found');</script>");
                return;
            }

            reader.Close();

            cmd.CommandText = @"SELECT POINT FROM USER_PACKAGE WHERE  USING_CHECK=1 AND USER_ID=@USER_ID";

            cmd.Parameters.Add("@USER_ID", SqlDbType.Int);
            cmd.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

            reader = cmd.ExecuteReader();

            int point = 0;
            if (reader.Read())
            if (reader["POINT"] != DBNull.Value)
                point = Convert.ToInt32(reader["POINT"]);

            if (point > 0)
                Response.Redirect("Myorders.aspx");
            else
                Response.Redirect("Pricing.aspx");
            reader.Close();

            this.RegisterStartupScript("alert", "<script lang='javascript'>alert('User not found');</script>");

        }
        
    }

    protected void AZ_btn_Click(object sender, EventArgs e)
    {

     //   lang_lbl.Text = "Az";
        AZ_btn.Enabled = false;

        Session["LANG"] = "AZ";
        Response.Redirect(Request.Url.ToString());
    }

    protected void RU_btn_Click(object sender, EventArgs e)
    {
    //    lang_lbl.Text = "Ru";
        RU_btn.Enabled = false;

        Session["LANG"] = "RU";
        HttpContext.Current.Session["LANG"] = "RU";

        Response.Redirect(Request.Url.ToString());
    }

    protected void EN_btn_Click(object sender, EventArgs e)
    {
    //    lang_lbl.Text = "En";
        EN_btn.Enabled = false;

        Session["LANG"] = "EN";
        Response.Redirect(Request.Url.ToString());
    }
}
