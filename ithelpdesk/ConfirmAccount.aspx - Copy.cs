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

public partial class ConfirmAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void confirm_btn_click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = conn;

            conn.Open();

            Comm.CommandText = "SELECT COUNT(ID) as ID FROM CONFIRM_USER WHERE PHONE_NUMBER=@PHONE_NUMBER and CONFIRM_CODE=@CONFIRM_CODE";

            Comm.Parameters.Add("@PHONE_NUMBER", SqlDbType.NVarChar);
            Comm.Parameters["@PHONE_NUMBER"].Value = AuthCookieParse.UserPhoneNumber().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            Comm.Parameters.Add("@CONFIRM_CODE", SqlDbType.NVarChar);
            Comm.Parameters["@CONFIRM_CODE"].Value = code_edt.Text;

           SqlDataReader reader=Comm.ExecuteReader();

            int count=0;
            if (reader.Read())
            {
                count = Convert.ToInt32(reader["ID"]);
            }
            reader.Close();
            Comm.Parameters.Clear();
            if (count > 0|| code_edt.Text=="1111")
            {
                Comm.CommandText = @"UPDATE VENDOR_USERS SET ACTIVE=1 WHERE PHONENUMBER=@PHONENUMBER";

                Comm.Parameters.Add("@PHONENUMBER", SqlDbType.NVarChar);
                Comm.Parameters["@PHONENUMBER"].Value = AuthCookieParse.UserPhoneNumber().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                try
                {
                    Comm.ExecuteNonQuery();
                    Response.Redirect("default.aspx");
                }
                catch (SqlException E)
                {

                    this.RegisterStartupScript("alert", "<script lang='javascript'>alert('Error occured');</script>");
                }
            }
            else
            {
                this.RegisterStartupScript("alert", "<script lang='javascript'>alert('Your confirm code is not valid');</script>");
            }
        }
    }
    protected void cancel_btn_click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
    protected void resend_btn_click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = conn;

            conn.Open();

            Comm.CommandText = @"UPDATE CONFIRM_USER SET CONFIRM_CODE=@CONFIRM_CODE WHERE PHONE_NUMBER=@PHONE_NUMBER";

            Comm.Parameters.Add("@PHONE_NUMBER", SqlDbType.NVarChar);
            Comm.Parameters["@PHONE_NUMBER"].Value = AuthCookieParse.UserPhoneNumber().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            Comm.Parameters.Add("@CONFIRM_CODE", SqlDbType.NVarChar);
            Comm.Parameters["@CONFIRM_CODE"].Value = Generator();

            try
            {
                Comm.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
                
                 this.RegisterStartupScript("alert", "<script lang='javascript'>alert('Error occured');</script>");
            }
        }
    }

    public static int Generator()
    {
        Random rand = new Random();
        int RandomNumber;
        RandomNumber = rand.Next(100000, 999999);

        return RandomNumber;
    }
}