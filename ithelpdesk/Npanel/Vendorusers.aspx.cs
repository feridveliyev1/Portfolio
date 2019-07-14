using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Vendorusers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Vendor_user"])
        {
            Response.Redirect("Default.aspx");
            return;
        }

        users_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        users_sql.SelectCommand = @"SELECT ID,(FNAME+' '+LNAME) FIO,PHONENUMBER,EMAIL FROM VENDOR_USERS";
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

                    Comm.CommandText = @"SELECT ID,FNAME,LNAME,PHONENUMBER,EMAIL,PASSWORD FROM VENDOR_USERS WHERE ID=@ID";


                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        user_name_edt.Text = reader["FNAME"].ToString();

                        user_surname_edt.Text = reader["LNAME"].ToString();

                        user_login_edt.Text = reader["EMAIL"].ToString();

                        user_password_edt.Text = reader["PASSWORD"].ToString();

                        Phoenumber_edt.Text = reader["PHONENUMBER"].ToString();
                    }
                    else
                    {
                      //  user_name_edt.Text = null;
                        user_surname_edt.Text = null;
                        user_login_edt.Text = null;
                        user_password_edt.Text = null;
                        Phoenumber_edt.Text = null;
                    }

                    reader.Close();
                }
            }
            else
            {
                //user_name_edt.Text = null;
                user_surname_edt.Text = null;
                user_login_edt.Text = null;
                user_password_edt.Text = null;
                Phoenumber_edt.Text = null;

                ModalCaption_lb.Text = "Add";
            }
        }
        catch (SqlException E)
        {
            user_name_edt.Text = E.Message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Error occured', ''); $(\"#close_btn\").click();} );</script>", false);
            return;

           
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void Saving_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                Comm.CommandText = @"UPDATE VENDOR_USERS SET

                                                FNAME=@FNAME,
                                                LNAME=@LNAME,
                                                EMAIL=@EMAIL,
                                                PASSWORD=@PASSWORD,
                                                PHONENUMBER=@PHONENUMBER,
                                                STATUS=@STATUS
                                                
                                                WHERE
                                                        ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

            }
            else
                Comm.CommandText = @"INSERT INTO VENDOR_USERS (FNAME,LNAME,EMAIL,PHONENUMBER,PASSWORD,STATUS)
                                                     VALUES(@FNAME,@LNAME,@EMAIL,@PHONENUMBER,@PASSWORD,@STATUS)";

            Comm.Parameters.Add("@FNAME", SqlDbType.NVarChar);
            Comm.Parameters["@FNAME"].Value = user_name_edt.Text;

            Comm.Parameters.Add("@LNAME", SqlDbType.NVarChar);
            Comm.Parameters["@LNAME"].Value = user_surname_edt.Text;

            Comm.Parameters.Add("@EMAIL", SqlDbType.NVarChar);
            Comm.Parameters["@EMAIL"].Value = user_login_edt.Text;

            Comm.Parameters.Add("@PHONENUMBER", SqlDbType.NVarChar);
            Comm.Parameters["@PHONENUMBER"].Value = Phoenumber_edt.Text;

            Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
            Comm.Parameters["@PASSWORD"].Value = user_password_edt.Text;

            Comm.Parameters.Add("@STATUS", SqlDbType.Int);
            Comm.Parameters["@STATUS"].Value = 1;



            Conn.Open();

            try
            {
                Comm.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
                user_name_edt.Text = E.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Error occured', ''); $(\"#close_btn\").click();} );</script>", false);
                return;
            }

            ObjectsGrid.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Done', '');$(\"#close_btn\").click();});</script>", false);
        }
    }

    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_user")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM VENDOR_USERS WHERE ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = e.CommandArgument;

                Conn.Open();
                try
                {
                    Comm.ExecuteNonQuery();
                }

                catch (SqlException E)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Error occured', ''); $(\"#close_btn\").click();} );</script>", false);
                    return;
                }


                ObjectsGrid.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Done', '');$(\"#close_btn\").click();});</script>", false);
            }
        }
    }

    protected void ObjectsGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton l = (LinkButton)e.Item.FindControl("Delete_btn");
        l.Attributes.Add("onclick", "javascript:return confirm('Əminsiniz?')");

    }
}