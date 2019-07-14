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

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Number"] = null;
    }
    protected void register_btn_click(object sender, EventArgs e)
    {
        int count = 0;
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Conn.Open();

            Comm.CommandText="SELECT COUNT(ID) as ID FROM VENDOR_USERS WHERE PHONENUMBER=@PHONENUMBER AND ACTIVE=1";

            Comm.Parameters.Add("@PHONENUMBER", SqlDbType.NVarChar);
            Comm.Parameters["@PHONENUMBER"].Value = phonenumber_edt.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            SqlDataReader reader = Comm.ExecuteReader();

            if (reader.Read())
            {
                count = Convert.ToInt32(reader["ID"]);
            }
                reader.Close();

                if (count > 0)
                {
                    this.RegisterStartupScript("alert", "<script lang='javascript'>alert('This number already exists');</script>");
                }
                else
                {
                    Comm.Parameters.Clear();



                    Comm.CommandText = @"INSERT INTO VENDOR_USERS (FNAME,LNAME,PHONENUMBER,EMAIL,PASSWORD,CURRENT_LANG,STATUS,ACTIVE) VALUES (@FNAME,@LNAME,@PHONENUMBER,@EMAIL,@PASSWORD,@CURRENT_LANG,@STATUS,@ACTIVE)";

                    Comm.Parameters.Add("@FNAME", SqlDbType.NVarChar);
                    Comm.Parameters["@FNAME"].Value = name_edt.Text;

                    Comm.Parameters.Add("@LNAME", SqlDbType.NVarChar);
                    Comm.Parameters["@LNAME"].Value = surname_edt.Text;

                    Comm.Parameters.Add("@PHONENUMBER", SqlDbType.NVarChar);
                    Comm.Parameters["@PHONENUMBER"].Value = phonenumber_edt.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                    Session["Number"] = phonenumber_edt.Text;

                    Comm.Parameters.Add("@EMAIL", SqlDbType.NVarChar);
                    Comm.Parameters["@EMAIL"].Value = email_edt.Text;

                    Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                    Comm.Parameters["@PASSWORD"].Value = password_edt.Text;

                    Comm.Parameters.Add("@CURRENT_LANG", SqlDbType.NVarChar);
                    Comm.Parameters["@CURRENT_LANG"].Value = "EN";

                    Comm.Parameters.Add("@STATUS", SqlDbType.Int);
                    Comm.Parameters["@STATUS"].Value = 0;

                    Comm.Parameters.Add("@ACTIVE", SqlDbType.Int);
                    Comm.Parameters["@ACTIVE"].Value = 0;

                    try
                    {
                        Comm.ExecuteNonQuery();

                    }
                    catch (SqlException E)
                    {
                        this.RegisterStartupScript("alert", "<script lang='javascript'>alert('Something goes wrong');</script>");
                    }

                    Comm.Parameters.Clear();

                    Comm.CommandText = @"INSERT INTO CONFIRM_USER (PHONE_NUMBER,CONFIRM_CODE) VALUES (@PHONE_NUMBER,@CONFIRM_CODE)";

                    Comm.Parameters.Add("@PHONE_NUMBER", SqlDbType.NVarChar);
                    Comm.Parameters["@PHONE_NUMBER"].Value = phonenumber_edt.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                    Comm.Parameters.Add("@CONFIRM_CODE", SqlDbType.NVarChar);
                    Comm.Parameters["@CONFIRM_CODE"].Value = Generator();
                    string CookiesString = "";

                    try
                    {
                        Comm.ExecuteNonQuery();
                        CookiesString = 0 + "|" + "a" + "|" + "b" + "|" + 1 + "|" + phonenumber_edt.Text + "|" + "2" + "|";
                        FormsAuthentication.SetAuthCookie(CookiesString, true);

                        Response.Redirect("Confirmaccount");
                    }
                    catch (SqlException E)
                    {

                        this.RegisterStartupScript("alert", "<script lang='javascript'>alert('Something goes wrong');</script>");
                    }
                }
        }
    }

    protected void AZ_btn_Click(object sender, EventArgs E)
    {
 
    }

    protected void RU_btn_Click(object sender, EventArgs E)
    {

    }
    protected void EN_btn_Click(object sender, EventArgs E)
    {

    }
    public static int Generator()
    {
        Random rand = new Random();
        int RandomNumber;
        RandomNumber = rand.Next(100000, 999999);

        return RandomNumber;
    }
}