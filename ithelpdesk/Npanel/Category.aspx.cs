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

public partial class Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Vendor_user"])
        {
            Response.Redirect("Default.aspx");
            return;
        }

        category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        category_sql.SelectCommand = @"SELECT ID,AZ_NAME,EN_NAME,RU_NAME FROM CATEGORY";
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

            Reader.Close();

            bool active = false;

            if (Reader.Read())
                active = Convert.ToBoolean(Reader["ACTIVE"]);

            if (!active)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$.Notification.notify('error','top left', '" + "Packages for active account" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
            }
            else
            {
            SqlCommand cmd_sp = new SqlCommand("SP_PAY_PACKAGE", Conn);


            cmd_sp.CommandType = CommandType.StoredProcedure;

           
            cmd_sp.Parameters.Add(new SqlParameter("@USER_ID", 22));

            cmd_sp.Parameters.Add(new SqlParameter("@PACKAGE_ID", 6));

            cmd_sp.ExecuteNonQuery();


            Comm.CommandText = @"INSERT INTO USER_PACKAGE (USER_ID,PACKAGE_ID,USING_CHECK,PAY_DATE) VALUES(@USER_ID,@PACKAGE_ID,0,GETDATE())";



              }





              }
        }





    }
    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {
        try
        {

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {

                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = Conn;

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.CommandText = @"SELECT AZ_NAME,EN_NAME,RU_NAME FROM CATEGORY WHERE ID=@ID";


                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        category_az_edt.Text = reader["AZ_NAME"].ToString();

                        category_en_edt.Text = reader["EN_NAME"].ToString();

                        category_ru_edt.Text = reader["RU_NAME"].ToString();
                    }
                    else
                    {
                        category_az_edt.Text = null;

                        category_en_edt.Text = null;

                        category_ru_edt.Text = null;
                    }

                    reader.Close();
                }
            }
            else
            {
                category_az_edt.Text = null;

                category_en_edt.Text = null;

                category_ru_edt.Text = null;

                ModalCaption_lb.Text = "Əlavə et";
            }
        }
        catch (SqlException E)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
            return;

            category_az_edt.Text = E.Message;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void Save_btn_click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                Comm.CommandText = @"UPDATE CATEGORY SET

                                                AZ_NAME=@AZ_NAME,
                                                EN_NAME=@EN_NAME,
                                                RU_NAME=@RU_NAME
                                                
                                                WHERE
                                                        ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

            }
            else
                Comm.CommandText = @"INSERT INTO CATEGORY (AZ_NAME,EN_NAME,RU_NAME)
                                                     VALUES(@AZ_NAME,@EN_NAME,@RU_NAME)";

            Comm.Parameters.Add("@AZ_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@AZ_NAME"].Value = category_az_edt.Text;

            Comm.Parameters.Add("@EN_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@EN_NAME"].Value = category_en_edt.Text;

            Comm.Parameters.Add("@RU_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@RU_NAME"].Value = category_ru_edt.Text;



            Conn.Open();

            try
            {
                Comm.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                return;
            }

            ObjectsGrid.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
        }
    }

    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_category")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM CATEGORY WHERE ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = e.CommandArgument;

                Conn.Open();
                try
                { 
                    Comm.ExecuteNonQuery(); 
                }

                catch (SqlException E)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                    return;
                }


                ObjectsGrid.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
            }
        }
    }

    protected void ObjectsGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton l = (LinkButton)e.Item.FindControl("Delete_btn");
        l.Attributes.Add("onclick", "javascript:return confirm('Əminsiniz?')");

    }
}