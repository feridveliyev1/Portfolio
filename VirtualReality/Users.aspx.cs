using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class defaultinner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["qeydiyyat12_1"].ToString() != "ok")
                Response.Redirect("Default.aspx");
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }
        try
        {
            if (Session["adminsession"].ToString() != "okay")
                Response.Redirect("Default.aspx");
        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }

        if (!Page.IsPostBack)
        {
            Name_edt.Attributes.Add("placeholder", "Ad");
            Surname_edt.Attributes.Add("placeholder", "Soyad");
            Login_edt.Attributes.Add("placeholder", "Login");
            Password_edt.Attributes.Add("placeholder", "Parol");
        }
        SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        SqlDataSource1.SelectCommand = @"SELECT ID, NAME, SURNAME,LOGIN,PASSWORD,
                                                        CASE STATUS 
                                                        WHEN 1 THEN 'Admin'
                                                        WHEN 2 THEN 'Kassir'
                                                        WHEN 3 THEN 'Worker' 
                                                        END AS STATUS_NAME
                                                        FROM USERS";
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

                    Comm.CommandText = @"SELECT ID,NAME,SURNAME,LOGIN,PASSWORD,STATUS FROM USERS WHERE ID=@ID";

                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {

                        Name_edt.Text = reader["NAME"].ToString();
                        Surname_edt.Text = reader["SURNAME"].ToString();
                        Login_edt.Text = reader["LOGIN"].ToString();
                        Password_edt.Text = reader["PASSWORD"].ToString();
                        status_dll.SelectedValue = reader["STATUS"].ToString();

                        ModalCaption_lb.Text = "Dəyiş " + Name_edt.Text;
                        ModalCaption_lb.Text = "Dəyiş " + Surname_edt.Text;
                        ModalCaption_lb.Text = "Dəyiş " + Login_edt.Text;
                        ModalCaption_lb.Text = "Dəyiş " + Password_edt.Text;
                    }
                    else
                    {
                        Name_edt.Text = "Tapılmadı ";
                        Surname_edt.Text = "Tapılmadı ";
                        Login_edt.Text = "Tapılmadı ";
                        Password_edt.Text = "Tapılmadı ";
                        status_dll.SelectedValue = "0";
                    }

                    reader.Close();
                }
            }
            else
            {
                Name_edt.Text = "";
                Surname_edt.Text = "";
                Login_edt.Text = "";
                Password_edt.Text = "";
                status_dll.SelectedValue = "0";
                ModalCaption_lb.Text = "Əlavə et";
            }
        }
        catch (SqlException E)
        {
            Name_edt.Text = E.Message;
            Surname_edt.Text = E.Message;
            Login_edt.Text = E.Message;
            Password_edt.Text = E.Message;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void Save_btn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                Comm.CommandText = @"UPDATE USERS  SET
                                        NAME = @NAME,
                                        SURNAME=@SURNAME,
                                        LOGIN=@LOGIN,
                                        PASSWORD=@PASSWORD,
                                        STATUS=@STATUS
                                    WHERE
                                        ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
            }
            else
                Comm.CommandText = @"INSERT INTO USERS(NAME,SURNAME,LOGIN,PASSWORD,STATUS) VALUES(@NAME,@SURNAME,@LOGIN,@PASSWORD,@STATUS)";

            Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
            Comm.Parameters.Add("@SURNAME", SqlDbType.NVarChar);
            Comm.Parameters.Add("@LOGIN", SqlDbType.NVarChar);
            Comm.Parameters.Add("@PASSWORD", SqlDbType.NVarChar);
            Comm.Parameters.Add("@STATUS", SqlDbType.Int);
            Comm.Parameters["@NAME"].Value = Name_edt.Text;
            Comm.Parameters["@SURNAME"].Value = Surname_edt.Text;
            Comm.Parameters["@LOGIN"].Value = Login_edt.Text;
            Comm.Parameters["@PASSWORD"].Value = Password_edt.Text;
            Comm.Parameters["@STATUS"].Value = status_dll.SelectedValue;



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
        if (e.CommandName == "DELETE_Name")
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
                try { Comm.ExecuteNonQuery(); }
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