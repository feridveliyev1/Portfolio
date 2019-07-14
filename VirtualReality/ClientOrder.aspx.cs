using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

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
        if (!IsPostBack)
        {
          orderdate_edt.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
          cetegory_count.Text = "1";
        }
       
        device_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        device_dll_sql.SelectCommand = @"SELECT ID,NAME FROM DEVICE_CATEGORY";
        

        reject_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        reject_dll_sql.SelectCommand = @"SELECT ID,NAME FROM REJECT_REASON";

        client_ddl_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        client_ddl_sql.SelectCommand = @"SELECT ID,(NAME+' ' + SURNAME) as NAME  FROM CLIENTS";

       SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

       SqlDataSource1.SelectCommand = @"  SELECT CO.ID,DC.NAME AS CATEGORY,CO.DEVICE_CATEGORY_COUNT,CONVERT(VARCHAR,ORDER_DATE,102) AS ORDER_DATE, (CONVERT(nvarchar(10),CO.ORDER_DATE_HOUR)+':'+CONVERT(nvarchar(10),CO.ORDER_DATE_TIME)) AS 'TIME',PP.NAME AS PACKAGES,CO.CLIENT_PHONE,
                                    CASE CO.ORDER_TYPE
                                    WHEN 1 THEN 'Bron'
                                    END  AS OR_TYPE,
									     CASE CO.CLIENTS_ID
									     WHEN 0 THEN CO.CLIENTS_DESCRIPTON
										 ELSE  (C.NAME+ ' '+ C.SURNAME) 
									     END  CLIENT_NAME,
									                CASE CO.REJECT_REASON_ID
									                WHEN 0 THEN CO.REJECT_DESCRIPTON
													ELSE RR.NAME
									                END AS REJECT
                                            FROM CLIENTS_ORDER CO
                                                                left JOIN CLIENTS C ON CO.CLIENTS_ID=C.ID
											                    LEFT JOIN PRICE_PACKAGES PP ON CO.PACKAGES_ID=PP.ID
                                                                left JOIN DEVICE_CATEGORY DC ON CO.DEVICES_CATEGORY_ID=DC.ID
                                                                left JOIN REJECT_REASON RR ON CO.REJECT_REASON_ID=RR.ID  ORDER BY ORDER_DATE   ";

       
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

                      Comm.CommandText = @" SELECT ID,CLIENTS_ID,DEVICES_CATEGORY_ID,ORDER_TYPE,ORDER_DATE,REJECT_REASON_ID, REJECT_DESCRIPTON,CLIENTS_DESCRIPTON,ORDER_DATE_HOUR,ORDER_DATE_TIME,DEVICE_CATEGORY_COUNT,PACKAGES_ID,CLIENT_PHONE FROM CLIENTS_ORDER  WHERE ID=@ID";

                      Conn.Open();


                      SqlDataReader reader = Comm.ExecuteReader();


                      if (reader.Read())
                      {

                          client_ddl.SelectedValue = reader["CLIENTS_ID"].ToString();

                          gender_ddl.SelectedValue = reader["ORDER_TYPE"].ToString();

                          reject_dll.SelectedValue = reader["REJECT_REASON_ID"].ToString();

                          device_dll.SelectedIndex = 0;

                          //---------------------------------------------------------
                         // package_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
                         // package_dll_sql.SelectCommand = @"SELECT ID,NAME FROM PRICE_PACKAGES WHERE DEVICE_CATEGORY=" + reader["DEVICES_CATEGORY_ID"].ToString();
                          //-----------------------------------------------------------------------


                          numberddl.SelectedValue = reader["CLIENT_PHONE"].ToString().Substring(0, 6).ToString();

                          PhoneNumber_edt.Text = reader["CLIENT_PHONE"].ToString().Substring(6, 7).ToString();

                          hour_ddl.SelectedValue = reader["ORDER_DATE_HOUR"].ToString();

                          minutes_ddl.SelectedValue = reader["ORDER_DATE_TIME"].ToString();

                          client_txt.Text = reader["CLIENTS_DESCRIPTON"].ToString();

                          reject_edt.Text = reader["REJECT_DESCRIPTON"].ToString();

                          cetegory_count.Text = reader["DEVICE_CATEGORY_COUNT"].ToString();

                          orderdate_edt.Text = Convert.ToDateTime(reader["ORDER_DATE"]).Date.ToString("yyyy-MM-dd");

                          packages_dll.SelectedIndex = 0;

                      }
                      else
                      {
                          client_ddl.SelectedIndex = 0;

                          gender_ddl.SelectedIndex = 0;

                          reject_dll.SelectedIndex = 0;

                      //    packages_dll.Items.Clear();
                      //    packages_dll.Items.Insert(0, new ListItem("Seçin", "0"));

                          numberddl.SelectedIndex = 0;

                          PhoneNumber_edt.Text = "";

                          device_dll.SelectedIndex = 0;

                          hour_ddl.SelectedValue = DateTime.Now.Hour.ToString();

                          minutes_ddl.SelectedValue = DateTime.Now.Minute.ToString();

                           client_txt.Text = "";

                          reject_dll.SelectedIndex = 0;

                          cetegory_count.Text = "1";

                          orderdate_edt.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");

                          reject_edt.Text = "";
    
                      }
                  }

              }
              else
              {
                  client_ddl.SelectedIndex = 0;

                  gender_ddl.SelectedIndex = 0;

                  packages_dll.Items.Clear();
                  packages_dll.Items.Insert(0, new ListItem("Seçin", "0"));

                  numberddl.SelectedIndex = 0;

                  PhoneNumber_edt.Text = "";

                  reject_dll.SelectedIndex = 0;

                  device_dll.SelectedIndex = 0;

                  hour_ddl.SelectedValue = DateTime.Now.Hour.ToString();

                  minutes_ddl.SelectedValue = DateTime.Now.Minute.ToString();

                  client_txt.Text = "";

                  reject_dll.SelectedIndex = 0;

                  cetegory_count.Text = "1";

                  orderdate_edt.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
                  reject_edt.Text = "";
    
              }
          }
          catch 
          {
             
          }
            
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
     
    }
    protected void Save_btn_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(client_ddl.SelectedValue) == 0 && client_txt.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Ad daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(numberddl.SelectedValue) == 0 || PhoneNumber_edt.Text=="")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Nömrəni daxil edin', '');} );</script>", false);
        }
        else
        {
            {
                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                    SqlCommand Comm = new SqlCommand();

                    SqlCommand command_device = new SqlCommand();

                    SqlCommand command_game = new SqlCommand();

                    Comm.Connection = Conn;

                    //=================================================================

                    //=====================================================================

                    if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
                    {
                        Comm.CommandText = @"UPDATE CLIENTS_ORDER  SET
                                      CLIENTS_ID=@CLIENTS_ID,
                                      ORDER_DATE=@ORDER_DATE,
                                      ORDER_TYPE=@ORDER_TYPE,
                                      REJECT_REASON_ID=@REJECT_REASON_ID,
                                      REJECT_DESCRIPTON=@REJECT_DESCRIPTON,
                                      CLIENTS_DESCRIPTON=@CLIENTS_DESCRIPTON,
                                      ORDER_DATE_HOUR=@ORDER_DATE_HOUR,
                                      ORDER_DATE_TIME=@ORDER_DATE_TIME,
                                      CLIENT_PHONE=@CLIENT_PHONE,
                                      PACKAGES_ID=@PACKAGES_ID,
                                      DEVICE_CATEGORY_COUNT=@DEVICE_CATEGORY_COUNT
                                                                    WHERE
                                        ID = @ID";

                        Comm.Parameters.Add("@ID", SqlDbType.Int);
                        Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
                    }
                    else

                        Comm.CommandText = @"INSERT INTO CLIENTS_ORDER(CLIENTS_ID,ORDER_DATE,ORDER_TYPE,REJECT_REASON_ID,REJECT_DESCRIPTON,CLIENTS_DESCRIPTON,ORDER_DATE_HOUR,ORDER_DATE_TIME,DEVICE_CATEGORY_COUNT,DEVICES_CATEGORY_ID,CLIENT_PHONE,PACKAGES_ID)
                                                VALUES(@CLIENTS_ID,@ORDER_DATE,@ORDER_TYPE,@REJECT_REASON_ID,@REJECT_DESCRIPTON,@CLIENTS_DESCRIPTON,@ORDER_DATE_HOUR,@ORDER_DATE_TIME,@DEVICE_CATEGORY_COUNT,@DEVICES_CATEGORY_ID,@CLIENT_PHONE,@PACKAGES_ID)";


                    //if (client_txt.Text != "")
                    //{
                    //Comm.Parameters.Add("@CLIENTS_ID", SqlDbType.Int);
                    //  Comm.Parameters["@CLIENTS_ID"].Value = 0;
                    //}
                    //else
                    //{
                    Comm.Parameters.Add("@CLIENTS_ID", SqlDbType.Int);
                    Comm.Parameters["@CLIENTS_ID"].Value = client_ddl.SelectedValue;
                    //}

                    Comm.Parameters.Add("@DEVICES_CATEGORY_ID", SqlDbType.Int);
                    Comm.Parameters["@DEVICES_CATEGORY_ID"].Value = device_dll.SelectedValue;

                    Comm.Parameters.Add("@ORDER_TYPE", SqlDbType.Int);
                    Comm.Parameters["@ORDER_TYPE"].Value = gender_ddl.SelectedValue;

                    Comm.Parameters.Add("@REJECT_REASON_ID", SqlDbType.Int);
                    Comm.Parameters["@REJECT_REASON_ID"].Value = reject_dll.SelectedValue;

                    Comm.Parameters.Add("@REJECT_DESCRIPTON", SqlDbType.NVarChar);
                    Comm.Parameters["@REJECT_DESCRIPTON"].Value = reject_edt.Text;

                    // if (Convert.ToInt32(client_ddl.SelectedValue) != 0)
                    // {
                    //     Comm.Parameters.Add("@CLIENTS_DESCRIPTON", SqlDbType.NVarChar);
                    //     Comm.Parameters["@CLIENTS_DESCRIPTON"].Value = null;
                    // }
                    // else
                    //  {
                    Comm.Parameters.Add("@CLIENTS_DESCRIPTON", SqlDbType.NVarChar);
                    Comm.Parameters["@CLIENTS_DESCRIPTON"].Value = client_txt.Text;
                    // }

                    Comm.Parameters.Add("@ORDER_DATE", SqlDbType.DateTime);
                    Comm.Parameters["@ORDER_DATE"].Value = orderdate_edt.Text;

                    Comm.Parameters.Add("@ORDER_DATE_HOUR", SqlDbType.Int);
                    Comm.Parameters["@ORDER_DATE_HOUR"].Value = hour_ddl.Text;

                    Comm.Parameters.Add("@ORDER_DATE_TIME", SqlDbType.Int);
                    Comm.Parameters["@ORDER_DATE_TIME"].Value = minutes_ddl.Text;

                    Comm.Parameters.Add("@DEVICE_CATEGORY_COUNT", SqlDbType.Int);
                    Comm.Parameters["@DEVICE_CATEGORY_COUNT"].Value = Convert.ToInt32(cetegory_count.Text);

                    Comm.Parameters.Add("@CLIENT_PHONE", SqlDbType.NVarChar);

                    Comm.Parameters["@CLIENT_PHONE"].Value = numberddl.SelectedValue.ToString() + PhoneNumber_edt.Text;




                    Comm.Parameters.Add("@PACKAGES_ID", SqlDbType.Int);
                    Comm.Parameters["@PACKAGES_ID"].Value = packages_dll.SelectedValue;



                    //==================================================================================







                    Conn.Open();

                    try
                    {
                        Comm.ExecuteNonQuery();
                    }
                    catch (SqlException E)
                    {
                        client_txt.Text = E.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                        return;
                    }

                    ObjectsGrid.DataBind();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
                }

            }
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

                Comm.CommandText = @"DELETE FROM CLIENTS_ORDER WHERE ID = @ID";

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


    protected void category_changed(object sender, EventArgs e)
    {
         
        package_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        package_dll_sql.SelectCommand = @"SELECT ID,NAME FROM PRICE_PACKAGES WHERE DEVICE_CATEGORY=" + device_dll.SelectedValue.ToString();


        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);


    }
    protected void device_ddl_DataBound(object sender, EventArgs e)
    {
        device_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
 protected void package_dll_DataBound(object sender, EventArgs e)
    {
        packages_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void client_ddl_DataBound(object sender, EventArgs e)
    {
        client_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void reject_ddl_DataBound(object sender, EventArgs e)
    {
        reject_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void client_ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void packages_changed(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
}