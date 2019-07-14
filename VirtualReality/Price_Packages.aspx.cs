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

        if (!Page.IsPostBack)
        {
            Name_edt.Attributes.Add("placeholder", "Ad");
            Price_edt.Attributes.Add("placeholder", "Qiymət");
            Minute_edt.Attributes.Add("placeholder", "Müddət");
            refresh1(device_dll);
        }
        SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        SqlDataSource1.SelectCommand = @"SELECT PP.ID,PP.NAME,DEVICE_CATEGORY.NAME as CATEGORY,PRICE,DURATION_IN_MINUTES FROM PRICE_PACKAGES PP JOIN DEVICE_CATEGORY ON PP.DEVICE_CATEGORY=DEVICE_CATEGORY.ID";
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



                    Comm.CommandText = @"SELECT PP.ID,PP.NAME,PP.DEVICE_CATEGORY,DEVICE_CATEGORY.NAME as CATEGORY,PP.PRICE,PP.DURATION_IN_MINUTES FROM PRICE_PACKAGES PP JOIN DEVICE_CATEGORY ON PP.DEVICE_CATEGORY=DEVICE_CATEGORY.ID WHERE PP.ID=@ID";

                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        Name_edt.Text = reader["NAME"].ToString();
                        try
                        {
                            device_dll.SelectedValue = reader["DEVICE_CATEGORY"].ToString();
                        }
                        catch 
                        {
                            
                          
                        }
                      
                           
                     
                        Price_edt.Text = reader["PRICE"].ToString();
                        Minute_edt.Text = reader["DURATION_IN_MINUTES"].ToString();

                        ModalCaption_lb.Text = "Dəyiş " + Name_edt.Text;
                        ModalCaption_lb.Text = "Dəyiş " + Price_edt.Text;
                        ModalCaption_lb.Text = "Dəyiş " + Minute_edt.Text;
                    }
                    else
                    {
                        Name_edt.Text = "Tapılmadı ";
                        Price_edt.Text = "Tapılmadı ";
                        Minute_edt.Text = "Tapılmadı ";
                    }

                    reader.Close();
                }
            }
            else
            {
                Name_edt.Text = "";
                Price_edt.Text = "";
                Minute_edt.Text = "";

                ModalCaption_lb.Text = "Əlavə et";
            }
        }
        catch (SqlException E)
        {
            Name_edt.Text = E.Message;
            Price_edt.Text = E.Message;
            Minute_edt.Text = E.Message;
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
                Comm.CommandText = @"UPDATE PRICE_PACKAGES  SET
                                        NAME = @NAME,
                                        DEVICE_CATEGORY=@DEVICE_CATEGORY,
                                        PRICE=@PRICE,
                                        DURATION_IN_MINUTES=@DURATION_IN_MINUTES
                                    WHERE
                                        ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
            }
            else
                Comm.CommandText = @"INSERT INTO PRICE_PACKAGES(NAME,DEVICE_CATEGORY,PRICE,DURATION_IN_MINUTES) VALUES(@NAME,@DEVICE_CATEGORY,@PRICE,@DURATION_IN_MINUTES)";

            Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
            Comm.Parameters.Add("@DEVICE_CATEGORY", SqlDbType.Int);
            Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
            Comm.Parameters.Add("@DURATION_IN_MINUTES", SqlDbType.NVarChar);
            Comm.Parameters["@NAME"].Value = Name_edt.Text;
            Comm.Parameters["@DEVICE_CATEGORY"].Value = device_dll.SelectedValue;
            Comm.Parameters["@PRICE"].Value = Price_edt.Text;
            Comm.Parameters["@DURATION_IN_MINUTES"].Value = Minute_edt.Text;



            Conn.Open();

            try
            {

                Comm.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
                Minute_edt.Text = e.ToString();
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

                Comm.CommandText = @"DELETE FROM PRICE_PACKAGES WHERE ID = @ID";

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
    private void refresh1(DropDownList a)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            conn.Open();
            adapter.SelectCommand = new SqlCommand("select * from DEVICE_CATEGORY", conn);
            adapter.Fill(dt);
            conn.Close();
            a.DataSource = dt;
            a.DataValueField = "ID";
            a.DataTextField = "NAME";
            a.DataBind();
        }
    }
}