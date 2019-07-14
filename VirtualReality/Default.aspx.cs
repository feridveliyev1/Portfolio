using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Login_edt.Attributes.Add("placeholder", "Login");
            Password_edt.Attributes.Add("placeholder", "Password");

        }
    }
    protected void Login_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT ID,NAME+' '+SURNAME AS FIO,LOGIN,PASSWORD,STATUS FROM USERS WHERE LOGIN=@LOGIN AND PASSWORD=@PASSWORD";
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar);

            cmd.Parameters["@LOGIN"].Value = Login_edt.Text;

            cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);

            cmd.Parameters["@PASSWORD"].Value = Password_edt.Text;

            conn.Open();

            SqlDataReader reader;

            reader = cmd.ExecuteReader();

            string CookiesString = "";

            if (reader.Read())
            {
                CookiesString = reader["ID"].ToString() + "|" + reader["FIO"].ToString() + "|" + DateTime.Now.ToString() + "|" + Request.UserHostAddress + "|" + reader["LOGIN"].ToString() + "|" + reader["STATUS"] + "|";

                reader.Close();
                
                FormsAuthentication.SetAuthCookie(CookiesString, true);

                Session["qeydiyyat12_1"] = "ok";
                
                Response.Redirect("Payment.aspx");
            }

            reader.Close();

            this.RegisterStartupScript("alert", "<script lang='javascript'>alert('User not found');</script>");

        }
    }
}