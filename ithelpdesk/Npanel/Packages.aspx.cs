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

public partial class Packages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Vendor_user"] || AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Operator"])
        {
            Response.Redirect("Default.aspx");
            return;
        }


        packages_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        packages_sql.SelectCommand = @"SELECT P.ID,P.NAME,(CONVERT(nvarchar,P.PRICE) + ' ' + V.NAME) as PRICE,POINT FROM PACKAGE as P
                                                                        LEFT JOIN VALYUTA AS V ON P.VALYUTA_ID=V.ID";

        valyuta_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        valyuta_sql.SelectCommand = @"SELECT ID,NAME FROM VALYUTA";
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

                    Comm.CommandText = @"SELECT ID,NAME,PRICE,VALYUTA_ID,POINT FROM PACKAGE WHERE ID = @ID";

                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        package_edt.Text = reader["NAME"].ToString();

                        price_edt.Text = reader["PRICE"].ToString();

                        valyuta_ddl.SelectedValue = reader["VALYUTA_ID"].ToString();

                        point_edt.Text = reader["POINT"].ToString();

                        ModalCaption_lb.Text = "Dəyiş " + package_edt.Text;
                    }
                    else
                    {
                        package_edt.Text = "Tapılmadı ";

                        price_edt.Text = "";

                        valyuta_ddl.SelectedIndex = 0;

                        point_edt.Text = "";

                        ModalCaption_lb.Text = "Dəyiş " + package_edt.Text;
                    }

                    reader.Close();
                }
            }
            else
            {
                package_edt.Text = "";

                price_edt.Text = "";

                valyuta_ddl.SelectedIndex = 0;

                point_edt.Text = "";

                ModalCaption_lb.Text = "Əlavə et";
            }
        }
        catch (SqlException E)
        {
            package_edt.Text = E.Message;
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
              Comm.CommandText = @"UPDATE PACKAGE  SET
                                        NAME = @NAME,
                                        PRICE=@PRICE,
                                        VALYUTA_ID=@VALYUTA_ID,
                                        POINT=@POINT
                                    WHERE
                                        ID = @ID";

              Comm.Parameters.Add("@ID", SqlDbType.Int);
              Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
          }
          else
              Comm.CommandText = @"INSERT INTO PACKAGE(NAME,PRICE,VALYUTA_ID,POINT) VALUES(@NAME,@PRICE,@VALYUTA_ID,@POINT)";

          Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
          Comm.Parameters["@NAME"].Value = package_edt.Text;

          Comm.Parameters.Add("@PRICE", SqlDbType.Int);
          Comm.Parameters["@PRICE"].Value = price_edt.Text;

          Comm.Parameters.Add("@VALYUTA_ID", SqlDbType.Int);
          Comm.Parameters["@VALYUTA_ID"].Value = valyuta_ddl.SelectedValue;

          Comm.Parameters.Add("@POINT", SqlDbType.Int);
          Comm.Parameters["@POINT"].Value = point_edt.Text;



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
        if (e.CommandName == "DELETE_package")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM PACKAGE WHERE ID = @ID";

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

    protected void valyuta_ddl_DataBound(object sender, EventArgs e)
    {
        valyuta_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }
}