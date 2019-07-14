using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.Services.Protocols;

public partial class MasterPage : System.Web.UI.MasterPage
{
    void load_info()
    {
        if (AuthCookieParse.UserID().ToString() == "-1")
            Response.Redirect("default.aspx");

        else  if (AuthCookieParse.UserStatus() == "1")
        {
            category_li.Visible = true;
            subcategory_li.Visible = true;
            users_li.Visible = false;
            vendorusers_li.Visible = true;
            orderlist_li.Visible = true;
            Problem_list.Visible = true;
            card_generator.Visible = false;
            Tranzactions_list.Visible=false;
            Report_list.Visible = false;
            Doneorders_li.Visible = true;
            createorder_li.Visible = false;
            myorders_li.Visible = false;
        }
        else 
            if(AuthCookieParse.UserStatus() =="0")
        {
            category_li.Visible = false;
            subcategory_li.Visible = false;
            users_li.Visible = false;
            card_generator.Visible = false;
            Tranzactions_list.Visible = false;
            Report_list.Visible = false;
            vendorusers_li.Visible = false;
            orderlist_li.Visible = false;
            Doneorders_li.Visible = false;
            createorder_li.Visible = true;
            myorders_li.Visible = true;
            pricing_li.Visible = true;
        }
            else if (AuthCookieParse.UserStatus() == "3")
            {
                category_li.Visible = true;
                subcategory_li.Visible = true;
                users_li.Visible = true;
                vendorusers_li.Visible = true;
                orderlist_li.Visible = true;
                Problem_list.Visible = true;
                card_generator.Visible = true;
                Tranzactions_list.Visible = true;
                Report_list.Visible = true;
                Doneorders_li.Visible = true;
            }
            else if (AuthCookieParse.UserStatus() == "2")
            {
                category_li.Visible = true;
                subcategory_li.Visible = true;
                users_li.Visible = true;
                vendorusers_li.Visible = true;
                orderlist_li.Visible = true;
                Problem_list.Visible = true;
                card_generator.Visible = false;
                Tranzactions_list.Visible = true;
                Report_list.Visible = true;
                Doneorders_li.Visible = true;
            }

        string point = "";

        string package = "";

        string info = "";

        string time = "";

        using (SqlConnection Conn = new SqlConnection())
        {

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();

            Comm.Connection = Conn;

            Conn.Open();

            Comm.CommandText = @"
                                SELECT AP.POINT,PAY_DATE,P.NAME AS PACKAGE,PT.NAME AS TYPE,PACKAGE_ID FROM USER_PACKAGE AS AP
								LEFT JOIN PACKAGE AS P ON AP.PACKAGE_ID=P.ID
								LEFT JOIN PACKAGE_TYPE AS PT ON P.TYPE_ID=PT.ID WHERE AP.USER_ID=@ID AND USING_CHECK=1";

            Comm.Parameters.Add("@ID", SqlDbType.Int);
            Comm.Parameters["@ID"].Value = AuthCookieParse.UserID();

            SqlDataReader reader = Comm.ExecuteReader();

            if (reader.Read())
            {
                info = reader["TYPE"] + ": " + reader["PACKAGE"];

                point = reader["POINT"].ToString();

                package = reader["PACKAGE_ID"].ToString();

                time = reader["PAY_DATE"].ToString();
            }

            reader.Close();


        }

        package_info.InnerText = info;

        point_info.InnerText += point;

        if (package == "4" || package == "7")
        {
            time_info.InnerText += Convert.ToDateTime(time).AddHours(24).ToString();
        }
        else
            if (package == "5" || package == "8")
            {
                time_info.InnerText += Convert.ToDateTime(time).AddDays(7);
            }

            else
                if (package == "6" || package == "9")
                {
                    time_info.InnerText += Convert.ToDateTime(time).AddMonths(1);
                }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LANG"] == null)
            Session["LANG"] = "EN";
        if (!IsPostBack)
            load_info();
        if(AuthCookieParse.UserStatus()=="0")
        Loginlbl.Text = AuthCookieParse.UserFIO();
        else if (AuthCookieParse.UserStatus() == "1")
            Loginlbl.Text = AuthCookieParse.UserFIO() + " (Operator)";
        else if(AuthCookieParse.UserStatus() == "2")
             Loginlbl.Text = AuthCookieParse.UserFIO() + " (Admin)";
        else if(AuthCookieParse.UserStatus() == "3")
            Loginlbl.Text = AuthCookieParse.UserFIO() + " (SuperAdmin)";
        Loginlbl.Text = " " + Loginlbl.Text;
    }

    protected void SignOut_btn_Click(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() == "1")
        {
            Response.Redirect("defaultadmin.aspx");
        }
        else
        {
            Response.Redirect("default.aspx");
        }
        Response.Redirect("default.aspx");
    }

    public string AZ_ACTIVE = "";
    public string RU_ACTIVE = "";
    public string EN_ACTIVE = "";


    protected void AZ_btn_Click(object sender, EventArgs e)
    {
//        using (SqlConnection Conn = new SqlConnection())
//        {
//            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

//            SqlCommand Comm = new SqlCommand();
//            Comm.Connection = Conn;

//            Comm.CommandText = @"UPDATE VENDOR_USERS SET
//                                    CURRENT_LANG = @CURRENT_LANG
//                                WHERE
//                                    ID = @ID";

//            Comm.Parameters.Add("@ID", SqlDbType.Int);
//            Comm.Parameters["@ID"].Value = AuthCookieParse.UserID();

//            Comm.Parameters.Add("@CURRENT_LANG", SqlDbType.NVarChar);
//            Comm.Parameters["@CURRENT_LANG"].Value = "az";

//            Conn.Open();

//            Comm.ExecuteNonQuery();

        AZ_ACTIVE = "class=\"active\"";
        RU_ACTIVE = "";
        EN_ACTIVE = "";

      lang_lbl.Text = "Az";
        AZ_btn.Enabled = false;

            Session["LANG"] = "AZ";
            

            Response.Redirect(Request.Url.ToString());
        //}
    }

    protected void RU_btn_Click(object sender, EventArgs e)
    {
//        using (SqlConnection Conn = new SqlConnection())
//        {
//            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

//            SqlCommand Comm = new SqlCommand();
//            Comm.Connection = Conn;

//            Comm.CommandText = @"UPDATE VENDOR_USERS SET
//                                    CURRENT_LANG = @CURRENT_LANG
//                                WHERE
//                                    ID = @ID";

//            Comm.Parameters.Add("@ID", SqlDbType.Int);
//            Comm.Parameters["@ID"].Value = AuthCookieParse.UserID();

//            Comm.Parameters.Add("@CURRENT_LANG", SqlDbType.NVarChar);
//            Comm.Parameters["@CURRENT_LANG"].Value = "ru";

//            Conn.Open();

//            Comm.ExecuteNonQuery();

        RU_ACTIVE = "class=\"active\"";
        AZ_ACTIVE = "";
        EN_ACTIVE = "";
        lang_lbl.Text = "Ru";
        RU_btn.Enabled = false;

            Session["LANG"] = "RU";
            HttpContext.Current.Session["LANG"] = "RU";

      

            Response.Redirect(Request.Url.ToString());
        //}
    }

    protected void EN_btn_Click(object sender, EventArgs e)
    {
      
//           using (SqlConnection Conn = new SqlConnection())
//        {
//            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

//            SqlCommand Comm = new SqlCommand();
//            Comm.Connection = Conn;

//            Comm.CommandText = @"UPDATE VENDOR_USERS SET
//                                    CURRENT_LANG = @CURRENT_LANG
//                                WHERE
//                                    ID = @ID";

//            Comm.Parameters.Add("@ID", SqlDbType.Int);
//            Comm.Parameters["@ID"].Value = AuthCookieParse.UserID();
               

//            Comm.Parameters.Add("@CURRENT_LANG", SqlDbType.NVarChar);
//            Comm.Parameters["@CURRENT_LANG"].Value = "EN";

//            Conn.Open();

//            Comm.ExecuteNonQuery();
        EN_ACTIVE = "class=\"active\"";
        AZ_ACTIVE = "";
        RU_ACTIVE = "";
        lang_lbl.Text = "En";
       EN_btn.Enabled = false;

            Session["LANG"] = "EN";
 

            Response.Redirect(Request.Url.ToString());
    //}
       
    }
}
