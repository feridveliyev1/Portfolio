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

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void reset_btn_click(object sender, EventArgs e)
    {
        string code = "";
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = conn;

            conn.Open();

            Comm.CommandText = "SELECT PASSWORD FROM VENDOR_USERS WHERE PHONENUMBER=@PHONENUMBER";

            Comm.Parameters.Add("@PHONENUMBER", SqlDbType.NVarChar);
            Comm.Parameters["@PHONENUMBER"].Value = phonenumber_edt.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            SqlDataReader reader = Comm.ExecuteReader();

            if (reader.Read())
            {
                code = reader["PASSWORD"].ToString();
            }
            reader.Close();

        }
    }
}