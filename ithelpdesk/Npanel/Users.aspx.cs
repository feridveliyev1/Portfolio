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
    void info()
    {
        if (AuthCookieParse.UserStatus() == "2")
        {
            status_ddl.SelectedIndex = 1;
            status_ddl.Enabled = false;
        }
        else if (AuthCookieParse.UserStatus() == "3")
        {
            status_ddl.Enabled = true;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        users_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        users_sql.SelectCommand = @"SELECT ID,FNAME,LNAME,USERNAME,PASSWORD,STATUS FROM USERS";
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

                    Comm.CommandText = @"SELECT FNAME,LNAME,USERNAME,PASSWORD,STATUS FROM USERS WHERE ID=@ID";


                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        re_user_password_edt.Visible = false;
                        re_password_div.Attributes.Add("style", "display:none;");
                        user_name_edt.Text = reader["FNAME"].ToString();
                        user_surname_edt.Text = reader["LNAME"].ToString();
                        user_login_edt.Text = reader["USERNAME"].ToString();
                     //   user_password_edt.Text = reader["PASSWORD"].ToString();
                    }
                    else
                    {
                        user_name_edt.Text = null;
                        user_surname_edt.Text = null;
                        user_login_edt.Text = null;
                        user_password_edt.Text = null;
                    }

                    reader.Close();
                }
            }
            else
            {
                user_name_edt.Text = null;
                user_surname_edt.Text = null;
                user_login_edt.Text = null;
                user_password_edt.Text = null;
                re_password_div.Attributes.Add("style", "display:block;");
                re_user_password_edt.Visible = true;
                ModalCaption_lb.Text = "Add";
            }
        }
        catch (SqlException E)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Error occured', ''); $(\"#close_btn\").click();} );</script>", false);
            return;

            user_name_edt.Text = E.Message;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void Saving_btn_Click(object sender, EventArgs e)
    {
        if (re_user_password_edt.Visible == true && re_user_password_edt.Text != user_password_edt.Text)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','No match', ''); } );</script>", false);
            return;
        }


        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                string command = "";
                if(user_password_edt.Text=="")
                {
                    command = @"UPDATE USERS SET

                                                FNAME=@FNAME,
                                                LNAME=@LNAME,
                                                USERNAME=@USERNAME,
                                                STATUS=@STATUS
                                                
                                                WHERE
                                                        ID=@ID";
                }
                else
                {
                    command = @"UPDATE USERS SET

                                                FNAME=@FNAME,
                                                LNAME=@LNAME,
                                                USERNAME=@USERNAME,
                                                PASSWORD=@PASSWORD,
                                                STATUS=@STATUS
                                                
                                                WHERE
                                                        ID=@ID";
                }
            
                Comm.CommandText = command;

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

            }
            else
                Comm.CommandText = @"INSERT INTO USERS (FNAME,LNAME,USERNAME,PASSWORD,STATUS)
                                                     VALUES(@FNAME,@LNAME,@USERNAME,@PASSWORD,@STATUS)";


            Comm.Parameters.Add("@FNAME", SqlDbType.NVarChar);
            Comm.Parameters["@FNAME"].Value = user_name_edt.Text;

            Comm.Parameters.Add("@LNAME", SqlDbType.NVarChar);
            Comm.Parameters["@LNAME"].Value = user_surname_edt.Text;

            Comm.Parameters.Add("@USERNAME", SqlDbType.NVarChar);
            Comm.Parameters["@USERNAME"].Value = user_login_edt.Text;

            if (user_password_edt.Text != "")
            {
                Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
                Comm.Parameters["@PASSWORD"].Value = user_password_edt.Text;
            }

            Comm.Parameters.Add("@STATUS", SqlDbType.Int);
            Comm.Parameters["@STATUS"].Value = 1;



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
            re_password_div.Visible = false;
           
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

                Comm.CommandText = @"DELETE FROM USERS WHERE ID = @ID";

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