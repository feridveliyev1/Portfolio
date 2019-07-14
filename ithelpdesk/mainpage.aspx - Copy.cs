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

        Subcategory_s24.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                          LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=7";

        Subcategory_s7.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        Subcategory_s7.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                         LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=8";

        Subcategory_s30.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        Subcategory_s30.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                         LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=9";

        Subcategory_j24.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        Subcategory_j24.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                          LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=4";

        Subcategory_j7.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        Subcategory_j7.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                         LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=5";

        Subcategory_j30.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        Subcategory_j30.SelectCommand = @"SELECT S.EN_NAME AS NAME FROM PACKAGE_SUBCATEGORY AS PS
                                          LEFT JOIN SUB_CATEGORY AS S ON PS.SUBCATEGORY_ID=S.ID WHERE PS.PACKAGE_ID=6";

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

                Comm.Parameters.Clear();

                Comm.CommandText = "SELECT BIG_TEXT,SMALL_TEXT FROM ABBAS WHERE DATE=(SELECT MAX(DATE) FROM ABBAS)";

                reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    big_lbl.Text = reader["BIG_TEXT"].ToString();
                    small_lbl.Text = reader["SMALL_TEXT"].ToString();
                }
               
                reader.Close();

            }

            #endregion
        }
    }


}