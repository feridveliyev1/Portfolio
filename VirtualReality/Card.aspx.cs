using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class card : System.Web.UI.Page
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
        client_ddl_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        client_ddl_sql.SelectCommand = @"SELECT ID,NAME FROM CLIENTS";
        if (!Page.IsPostBack)
        {
            code_edt.Attributes.Add("placeholder", "Kodu");
            balance_edt.Attributes.Add("placeholder", "Balans");
        }
        SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        SqlDataSource1.SelectCommand = @"SELECT CARD.ID, CLIENTS.NAME as NAME,BALANCE,CODE from CARD
                                                            join CLIENTS on CARD.CLIENT_ID=CLIENTS.ID";

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

                    Comm.CommandText = @"SELECT ID,CLIENT_ID,CODE,BALANCE FROM CARD WHERE ID = @ID";

                    Conn.Open();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        client_ddl.SelectedValue = reader["Client_id"].ToString();
                        code_edt.Text = reader["CODE"].ToString();

                        ModalCaption_lb.Text = "DƏYIŞ ";

                        balance_edt.Text = reader["BALANCE"].ToString();
                        
                    }
                    else
                    {
                        code_edt.Text = "Tapılmadı ";
                        balance_edt.Text = "0";
                    }

                    reader.Close();
                }
            }
            else
            {
                client_ddl.SelectedIndex = 0;

                code_edt.Text = "";

                balance_edt.Text = "0";

                ModalCaption_lb.Text = "ƏLAVƏ ET";
            }
        }
        catch (SqlException E)
        {
            code_edt.Text = E.Message;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void client_ddl_DataBound(object sender, EventArgs e)
    {
        client_ddl.Items.Insert(0, new ListItem("Seçin", "-1"));
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
                Comm.CommandText = @"UPDATE CARD  SET
                                        CODE= @CODE,
                                        BALANCE=@BALANCE,
                                        CLIENT_ID=@CLIENT_ID
                                    WHERE
                                        ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
            }
            else
                Comm.CommandText = @"INSERT INTO CARD(CODE,BALANCE,CLIENT_ID) VALUES(@CODE,@BALANCE,@CLIENT_ID)";

            Comm.Parameters.Add("@CODE", SqlDbType.NVarChar);
            Comm.Parameters["@CODE"].Value = code_edt.Text;

            Comm.Parameters.Add("@BALANCE", SqlDbType.Decimal);
            Comm.Parameters["@BALANCE"].Value =Convert.ToDecimal(balance_edt.Text);

            Comm.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
            Comm.Parameters["@CLIENT_ID"].Value = client_ddl.SelectedValue;



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
        if (e.CommandName == "DELETE_CARD")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM CARD WHERE ID = @ID";

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