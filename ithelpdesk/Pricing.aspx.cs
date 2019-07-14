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

public partial class mainpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Subcategory_s24.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_s24.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=7";

        Subcategory_s7.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_s7.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=8";

        Subcategory_s30.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_s30.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=9";

        Subcategory_j24.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_j24.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=4";

        Subcategory_j7.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_j7.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=5";

        Subcategory_j30.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Subcategory_j30.SelectCommand = @"SELECT EN_NAME AS NAME,PACKAGE_ID FROM SUB_CATEGORY WHERE PACKAGE_ID=6";

        if (!IsPostBack)
        {
            #region prices
            string price = "";


            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();


                Comm.CommandText = @"select (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 7;



                SqlDataReader reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();



                s24_lbl.InnerText = price;

                Comm.Parameters.Clear();

                Comm.CommandText = @"SELECT (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 8;

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();

                s7_lbl.InnerText = price;

                Comm.Parameters.Clear();

                Comm.CommandText = @"SELECT (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 9;

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();

                s30_lbl.InnerText = price;

                Comm.Parameters.Clear();

                Comm.CommandText = @"SELECT (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 4;

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();

                j24_lbl.InnerText = price;

                Comm.Parameters.Clear();

                Comm.CommandText = @"SELECT (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 5;

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();

                j7_lbl.InnerText = price;

                Comm.Parameters.Clear();

                Comm.CommandText = @"SELECT (CONVERT(nvarchar,PRICE) + ' ' + V.NAME + ' ' +'(' + Convert(nvarchar,POINT) + ')') as PRICE FROM PACKAGE AS P
        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID WHERE P.ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = 6;

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price = reader["PRICE"].ToString();
                }

                reader.Close();

                j30_lbl.InnerText = price;

            }

            #endregion
        }
    }

    protected void Package_pay(object sender, EventArgs e)
    {

        if (AuthCookieParse.UserID() != null && Convert.ToInt32(AuthCookieParse.UserID()) < 1)
            Response.Redirect("Default.aspx");

        else
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();

                Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                Comm.CommandText = @"SELECT ACTIVE FROM VENDOR_USERS WHERE ID=@USER_ID";

                SqlDataReader Reader = Comm.ExecuteReader();

                bool active = false;

                if (Reader.Read())
                    active = Convert.ToBoolean(Reader["ACTIVE"]);

                if (!active)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$.Notification.notify('error','top left', '" + "Packages for active account" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
                }
                else
                {
                    Reader.Close();

                    SqlCommand cmd_sp = new SqlCommand("CARD_CODE_PAY", Conn);

                    cmd_sp.CommandType = CommandType.StoredProcedure;

                    cmd_sp.Parameters.Add(new SqlParameter("@USER_ID", AuthCookieParse.UserID()));

                    cmd_sp.Parameters.Add(new SqlParameter("@CODE", Card_code_edt.Text));

                    cmd_sp.Parameters.Add(new SqlParameter("@PACKAGE_IDD", ObjectID_hf.Value));

                   int res=cmd_sp.ExecuteNonQuery();



                   if (res < 1)
                   {
                       error_lbl.Visible = true;
                   }
                   else
                   {
                       error_lbl.Visible = false;
                       Response.Redirect("Myorders.aspx");

                   }
       

                }
            }

        }
    }
}


