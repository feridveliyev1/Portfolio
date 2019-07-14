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

public partial class _Defaultadmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            //using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            //{
            //    socket.Connect("8.8.8.8", 65530);
            //    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
            //    localIP = endPoint.Address.ToString();
            //}
         
            
           
            Login_edt.Attributes.Add("placeholder","Login");  
            
            
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

            cmd.CommandText = @"SELECT ID,(FNAME + ' ' + LNAME) AS FIO,USERNAME,PASSWORD,STATUS FROM USERS WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD";

            cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar);

            cmd.Parameters["@USERNAME"].Value = Login_edt.Text;

            cmd.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);

            cmd.Parameters["@PASSWORD"].Value = Password_edt.Text;



            conn.Open();

            SqlDataReader reader;

            reader = cmd.ExecuteReader();
            string CookiesString = "";

            if (reader.Read())
            {
                CookiesString = reader["ID"].ToString() + "|" + reader["FIO"].ToString() + "|" + reader["USERNAME"].ToString() + "|" + reader["STATUS"] + "|";
                FormsAuthentication.SetAuthCookie(CookiesString, true);
             

                    reader.Close();

                    Response.Redirect("Orderlist.aspx");
               

            }

            reader.Close();

            this.RegisterStartupScript("alert", "<script lang='javascript'>alert('User not found');</script>");

        }
    }
}