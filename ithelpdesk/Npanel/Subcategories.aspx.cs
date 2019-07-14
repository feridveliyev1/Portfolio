using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Subcategories : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Vendor_user"])
        {
            Response.Redirect("Default.aspx");
            return;
        }
        subcategory_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        subcategory_sql.SelectCommand = @"SELECT SUB_CATEGORY.ID,SUB_CATEGORY.EN_NAME,SUB_CATEGORY.AZ_NAME,SUB_CATEGORY.RU_NAME,CATEGORY.EN_NAME AS CATEGORY,(CONVERT(NVARCHAR,PRICE)+' ' +V.NAME) PRICE FROM SUB_CATEGORY
                                         LEFT JOIN CATEGORY ON SUB_CATEGORY.CATEGORY_ID=CATEGORY.ID
                                            LEFT JOIN VALYUTA V ON SUB_CATEGORY.VALYUTA_ID=V.ID";

        category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        category_sql.SelectCommand = @"SELECT ID,EN_NAME AS 'NAME' FROM CATEGORY";

        SqlDataSource4.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        SqlDataSource4.SelectCommand = @"SELECT ID,NAME FROM VALYUTA";

    }

    protected void Save_btn_click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBpath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                Comm.CommandText = @"UPDATE SUB_CATEGORY SET
                                                AZ_NAME=@AZ_NAME,
                                                EN_NAME=@EN_NAME,
                                                RU_NAME=@RU_NAME,
                                                PRICE=@PRICE,
                                                CATEGORY_ID=@CATEGORY_ID,
                                                VALYUTA_ID=@VALYUTA_ID
                                                WHERE
                                                        ID=@ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
            }

            else
                Comm.CommandText = @"INSERT INTO SUB_CATEGORY (AZ_NAME,EN_NAME,RU_NAME,CATEGORY_ID,PRICE,VALYUTA_ID)
                                                        VALUES(@AZ_NAME,@EN_NAME,@RU_NAME,@CATEGORY_ID,@PRICE,@VALYUTA_ID)";

            Comm.Parameters.Add("@AZ_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@AZ_NAME"].Value = sub_category_az_edt.Text;

            Comm.Parameters.Add("@EN_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@EN_NAME"].Value = sub_category_en_edt.Text;

            Comm.Parameters.Add("@RU_NAME", SqlDbType.NVarChar);
            Comm.Parameters["@RU_NAME"].Value = sub_category_ru_edt.Text;

            Comm.Parameters.Add("@CATEGORY_ID", SqlDbType.Int);
            Comm.Parameters["@CATEGORY_ID"].Value = category_ddl.SelectedValue;

            Comm.Parameters.Add("@PRICE", SqlDbType.Int);
            Comm.Parameters["@PRICE"].Value = price_edt.Text;

            Comm.Parameters.Add("@VALYUTA_ID", SqlDbType.Int);
            Comm.Parameters["@VALYUTA_ID"].Value = valyuta_ddl.SelectedValue;

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

                    Comm.CommandText = @"SELECT AZ_NAME,EN_NAME,RU_NAME,CATEGORY_ID,PRICE,VALYUTA_ID FROM SUB_CATEGORY WHERE ID=@ID";

                    Conn.Open();

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        sub_category_az_edt.Text = reader["AZ_NAME"].ToString();

                        sub_category_en_edt.Text = reader["EN_NAME"].ToString();

                        sub_category_ru_edt.Text = reader["RU_NAME"].ToString();

                        category_ddl.SelectedValue = reader["CATEGORY_ID"].ToString();

                        price_edt.Text = reader["PRICE"].ToString();

                        valyuta_ddl.SelectedValue=reader["VALYUTA_ID"].ToString();
                    }

                    else
                    {
                        sub_category_az_edt.Text = null;

                        sub_category_en_edt.Text = null;

                        sub_category_ru_edt.Text = null;

                        price_edt.Text = null;

                        category_ddl.SelectedIndex = 0;
                        valyuta_ddl.SelectedIndex = 0;

                        
                    }

                    reader.Close();
                }
            }

            else
            {
                sub_category_az_edt.Text = null;

                sub_category_en_edt.Text = null;

                sub_category_ru_edt.Text = null;

                price_edt.Text = null;

                category_ddl.SelectedIndex = 0;

                valyuta_ddl.SelectedIndex = 0;
               
            }
        }

        catch (SqlException E)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
            return;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_subcategory")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM SUB_CATEGORY WHERE ID=@ID";

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

    protected void category_DataBound(object sender, EventArgs e)
    {
        category_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }

    protected void valyuta_ddl_DataBound(object sender, EventArgs e)
    {
            valyuta_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }
}