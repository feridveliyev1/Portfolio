using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Games : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            game_name_edt.Attributes.Add("placeholder", "Ad");
        }

        SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        SqlDataSource1.SelectCommand = @"SELECT G.ID,GC.NAME AS CATEGORY,G.NAME FROM GAMES G
                                            JOIN GAME_CATEGORY GC ON G.GAME_CATEGORY_ID=GC.ID";

        game_category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        game_category_sql.SelectCommand = @"SELECT ID,NAME FROM GAME_CATEGORY";
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

                    Comm.CommandText = @"SELECT ID,NAME,GAME_CATEGORY_ID FROM GAMES WHERE ID = @ID";

                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        game_name_edt.Text = reader["NAME"].ToString();

                        ModalCaption_lb.Text = "DƏYIŞ " + game_name_edt.Text;

                        game_category_ddl.SelectedValue = reader["GAME_CATEGORY_ID"].ToString();
                    }
                    else
                    {
                        game_name_edt.Text = "Tapılmadı ";
                        game_category_ddl.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }
            else
            {
                game_name_edt.Text = "";
                game_category_ddl.SelectedIndex = 0;

                ModalCaption_lb.Text = "ƏLAVƏ ET";
            }
        }
        catch (SqlException E)
        {
            game_name_edt.Text = E.Message;
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
                Comm.CommandText = @"UPDATE GAMES  SET
                                        NAME= @NAME,
                                        GAME_CATEGORY_ID=@GAME_CATEGORY_ID
                                    WHERE
                                        ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
            }
            else
                Comm.CommandText = @"INSERT INTO GAMES(NAME,GAME_CATEGORY_ID) VALUES(@NAME,@GAME_CATEGORY_ID)";

            Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
            Comm.Parameters["@NAME"].Value = game_name_edt.Text;

            Comm.Parameters.Add("@GAME_CATEGORY_ID", SqlDbType.Int);
            Comm.Parameters["@GAME_CATEGORY_ID"].Value = game_category_ddl.SelectedValue;



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
        if (e.CommandName == "DELETE_GAME")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM GAMES WHERE ID = @ID";

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