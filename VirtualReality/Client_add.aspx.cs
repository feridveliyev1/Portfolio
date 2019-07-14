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

public partial class Client_add : System.Web.UI.Page
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
   
            SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            SqlDataSource1.SelectCommand = @"     SELECT C.ID,C.NAME,C.SURNAME,C.PHONE_NUMBER,GENDER,U.NAME AS 'USER_ID',
				  CASE SOURCE_TYPE
						WHEN 1 THEN (SELECT CS.NAME FROM COSTUMER_SOURCE CS WHERE CS.ID=SOURCE_TYPE_NAME)
						WHEN 2 THEN (SELECT BP.NAME FROM BUSINESS_PARTNERS BP WHERE BP.ID=SOURCE_TYPE_NAME)
				  END AS SOURCE_NAME,
				  CASE AGE_INTERVAL
				  WHEN 1 THEN '10-18'
				  WHEN 2 THEN '18-25'
				  WHEN 3 THEN '25-40'
				  END AS AGES,
				  CASE SOURCE_TYPE
				  WHEN 1 THEN 'Küçe'
				  WHEN 2 THEN 'Biznes'
				  END AS SOURCE_T
	  FROM CLIENTS C
	 left JOIN USERS U ON C.USER_ID=U.ID";

            source_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            source_type_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE  ORDER BY ID";
            if (!IsPostBack)
            {
               birthday_txt.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
               User_txt.Text = AuthCookieParse.UserFIO();
            }
          
    }
   
   
    protected void source_type_changed(object sender, EventArgs e)
    {
        source_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        switch (source_type.SelectedIndex)
        {
            case 1:
                source_type_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE";
                break;
            case 2:
                source_type_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS";
                break;
            default:
                source_type_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS WHERE ID<0";
                    break;

                   
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void TABLE(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void source_ddl_DataBound(object sender, EventArgs e)
    {
        source_type_name_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
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

                    Comm.CommandText = @"SELECT C.ID,C.NAME,C.SURNAME,PHONE_NUMBER,GENDER,AGE_INTERVAL,CONVERT(VARCHAR,BIRTHDAY,105) AS BIRTHDAY,SOURCE_TYPE,SOURCE_TYPE_NAME,USERS.NAME AS OPERATOR FROM CLIENTS C
                    left JOIN USERS ON C.USER_ID=USERS.ID WHERE C.ID = @ID";
                    Conn.Open();


                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                        client_name_edt.Text = reader["NAME"].ToString();

                        ModalCaption_lb.Text = "DƏYIŞ " + client_name_edt.Text;

                        client_surname_edt.Text = reader["SURNAME"].ToString();

                        gender_ddl.SelectedValue = reader["GENDER"].ToString();

                        if (reader["PHONE_NUMBER"].ToString().Length > 5)
                        {

                            numberddl.SelectedValue = reader["PHONE_NUMBER"].ToString().Substring(0, 6).ToString();
                            PhoneNumber_edt.Text = reader["PHONE_NUMBER"].ToString().Substring(6, 7).ToString();
                        }
                        else
                        {
                            numberddl.SelectedIndex = 0;
                            PhoneNumber_edt.Text = "";
                        }




                        age_ddl.SelectedValue = reader["AGE_INTERVAL"].ToString();

                        birthday_txt.Text=Convert.ToDateTime(reader["BIRTHDAY"]).Date.ToString("yyyy-MM-dd");

                      source_type.SelectedValue = reader["SOURCE_TYPE"].ToString();

                      //  ======================================================================================
                     
                            int type = Convert.ToInt32(reader["SOURCE_TYPE"].ToString());
                            int type_name = Convert.ToInt32(reader["SOURCE_TYPE_NAME"].ToString());
                            source_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
                            switch (type)
                            {
                                case 1:
                                    source_type_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE" ;
                                    break;
                                case 2:
                                    source_type_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS" ;
                                    break;
                            }
                        
                      //  ========================================================================================

                         User_txt.Text = reader["OPERATOR"].ToString();
                         source_type_name_ddl.SelectedValue = reader["SOURCE_TYPE_NAME"].ToString();
                    }
                    else
                    {
                        client_name_edt.Text = "Tapılmadı ";

                        client_surname_edt.Text = "Tapılmadı ";

                        PhoneNumber_edt.Text = "Tapılmadı";

                        age_ddl.SelectedIndex = 0;

                        gender_ddl.SelectedIndex = 0;

                        numberddl.SelectedIndex = 0;

                        source_type.SelectedIndex = 0;

                        source_type_name_ddl.SelectedIndex = 0;

                        User_txt.Text = "Tapilmadı";
                    }

                    reader.Close();
                }
            }
            else
            {
                client_name_edt.Text = " ";

                client_surname_edt.Text = "";

                PhoneNumber_edt.Text = "";

                age_ddl.SelectedIndex = 0;

                gender_ddl.SelectedIndex = 0;

                numberddl.SelectedIndex = 0;

                source_type.SelectedIndex = 0;

                source_type_name_ddl.SelectedIndex = 0;

                User_txt.Text = "";

                ModalCaption_lb.Text = "ƏLAVƏ ET";
            }
        }
        catch (SqlException E)
        {
            client_name_edt.Text = E.Message;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void Save_btn_Click(object sender, EventArgs e)
    {
        if (client_name_edt.Text == "" || client_surname_edt.Text=="")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Adı daxil edin', '');} );</script>", false);
        }
        
        else if (Convert.ToInt32(gender_ddl.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Cinsi daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(age_ddl.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Yaşı daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(source_type.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Mənbə tipini daxil edin', '');} );</script>", false);

        }
        else if (Convert.ToInt32(source_type_name_ddl.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Mənbəni daxil edin', '');} );</script>", false);
        
        }
        else
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
                {
                    Comm.CommandText = @"UPDATE CLIENTS  SET
                                              NAME=@NAME,
                                              SURNAME=@SURNAME,
                                              PHONE_NUMBER=@PHONE_NUMBER, 
                                              GENDER = @GENDER,
                                              AGE_INTERVAL=@AGE_INTERVAL,
                                              BIRTHDAY=@BIRTHDAY,
                                              SOURCE_TYPE=@SOURCE_TYPE,
                                              SOURCE_TYPE_NAME=@SOURCE_TYPE_NAME,
                                              USER_ID=@USER_ID
                                    WHERE
                                        ID = @ID";

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;
                }
                else
                    Comm.CommandText = @"INSERT INTO CLIENTS(NAME,SURNAME,PHONE_NUMBER,GENDER,AGE_INTERVAL,BIRTHDAY,SOURCE_TYPE,SOURCE_TYPE_NAME,USER_ID) 
                                VALUES(@NAME,@SURNAME,@PHONE_NUMBER,@GENDER,@AGE_INTERVAL,@BIRTHDAY,@SOURCE_TYPE,@SOURCE_TYPE_NAME,@USER_ID)";

                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                Comm.Parameters["@NAME"].Value = client_name_edt.Text;

                Comm.Parameters.Add("@SURNAME", SqlDbType.NVarChar);
                Comm.Parameters["@SURNAME"].Value = client_surname_edt.Text;

                Comm.Parameters.Add("@PHONE_NUMBER", SqlDbType.NVarChar);
                Comm.Parameters["@PHONE_NUMBER"].Value = numberddl.SelectedValue.ToString() + PhoneNumber_edt.Text;

                Comm.Parameters.Add("@GENDER", SqlDbType.Int);
                Comm.Parameters["@GENDER"].Value = gender_ddl.SelectedValue;

                Comm.Parameters.Add("@AGE_INTERVAL", SqlDbType.NVarChar);
                Comm.Parameters["@AGE_INTERVAL"].Value = age_ddl.Text;

                Comm.Parameters.Add("@BIRTHDAY", SqlDbType.DateTime);
                try
                {
                    Comm.Parameters["@BIRTHDAY"].Value = birthday_txt.Text;
                }
                catch
                {
                    Comm.Parameters["@BIRTHDAY"].Value = null;
                }


                Comm.Parameters.Add("@SOURCE_TYPE", SqlDbType.Int);
                Comm.Parameters["@SOURCE_TYPE"].Value = source_type.SelectedValue;

                Comm.Parameters.Add("@SOURCE_TYPE_NAME", SqlDbType.Int);
                Comm.Parameters["@SOURCE_TYPE_NAME"].Value = source_type_name_ddl.SelectedValue;

                Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                Conn.Open();

                try
                {
                    Comm.ExecuteNonQuery();
                }
                catch (SqlException E)
                {

                    client_name_edt.Text = E.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                    return;
                }

                ObjectsGrid.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
            }
        }
    }
    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_CLIENT")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM CLIENTS WHERE ID = @ID";

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
    //protected void source_ddl_DataBound(object sender, EventArgs e)
    //{
    //    source_category_ddl.Items.Insert(0, new ListItem("Seçin", "-1"));
    //}
    //protected void sourche_type_click(object sender, EventArgs e)
    //{
    //    source_category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
    //    switch (sourche_type.SelectedIndex)
    //    {
    //        case 1:
    //            source_category_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE";
    //            break;
    //        case 2:
    //            source_category_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS";
    //            break;

    //    }


    //}
}