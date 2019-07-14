using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

    public partial class Npanel_Doneorders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() == ConfigurationManager.AppSettings["Vendor_user"])
        {
            Response.Redirect("Default.aspx");
            return;
        }

        ready_order_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        ready_order_sql.SelectCommand = @"SELECT O.ID,CONVERT(NVARCHAR,TIME_TO_CONNECT,104) 'DATE',TEAMVIEWER_CODE 'TEAMVIEWER',(VU.FNAME+' '+VU.LNAME ) 'USER_FIO' FROM ORDERS O 
                                        LEFT JOIN VENDOR_USERS VU ON O.CREATE_BY=VU.ID     
                                        
                                        WHERE O.STATUS_TYPE=2 
                                        ORDER BY O.ID DESC";

        order_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        order_type_sql.SelectCommand = @"SELECT ID,NAME FROM ORDER_TYPE";



    }

    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {

        try
        {
            problem_txt.Text = null;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                //services-------------------------------------
                services_sql.SelectParameters.Clear();
                services_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
                services_sql.SelectParameters.Add("ORDER_ID", ObjectID_hf.Value);
                if (Session["LANG"] == "AZ")
                    services_sql.SelectCommand = @"SELECT SC.AZ_NAME 'NAME' FROM SERVICES S
											LEFT JOIN SUB_CATEGORY SC ON S.SUBCATEGORY_ID=SC.ID WHERE S.ORDER_ID=@ORDER_ID";
                else if (Session["LANG"] == "EN")
                    services_sql.SelectCommand = @"SELECT SC.EN_NAME 'NAME' FROM SERVICES S
											LEFT JOIN SUB_CATEGORY SC ON S.SUBCATEGORY_ID=SC.ID WHERE S.ORDER_ID=@ORDER_ID";
                else services_sql.SelectCommand = @"SELECT SC.RU_NAME 'NAME' FROM SERVICES S
											LEFT JOIN SUB_CATEGORY SC ON S.SUBCATEGORY_ID=SC.ID WHERE S.ORDER_ID=@ORDER_ID";

                services_rpt.DataBind();

                //services-------------------------------------
                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = Conn;

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.CommandText = @"SELECT O.ID,O.PROBLEM_DESC,(CONVERT(NVARCHAR,TIME_TO_CONNECT,104)+' '+TIME_TO_CONNECT_CLOCK) 'DATE',TEAMVIEWER_CODE,(VU.FNAME+' '+VU.LNAME ) 'USER_FIO',O.SUBJECT,O.DESCRIPTION,O.STATUS_TYPE,O.PROBLEM_DESC FROM ORDERS O 
											LEFT JOIN VENDOR_USERS VU ON O.CREATE_BY=VU.ID     
											LEFT JOIN ORDER_TYPE OT ON O.STATUS_TYPE=OT.ID
											WHERE O.ID=@ID";

                    Conn.Open();

                    SqlDataReader reader = Comm.ExecuteReader();



                    if (reader.Read())
                    {
                        Username_edt.Text = reader["USER_FIO"].ToString();

                        Date_edt.Text = reader["DATE"].ToString();

                        Teamviewer_edt.Text = reader["TEAMVIEWER_CODE"].ToString();

                        Subject_edt.Text = reader["SUBJECT"].ToString();

                        Description_edt.Text = reader["DESCRIPTION"].ToString();

                        order_status_ddl.SelectedValue = reader["STATUS_TYPE"].ToString();

                        problem_txt.Text = reader["PROBLEM_DESC"].ToString();


                    }

                    reader.Close();
                }
            }
        }
        catch (SqlException E)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
            return;
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

                Comm.CommandText = @"UPDATE  ORDERS SET STATUS_TYPE=@STATUS_TYPE,
                                                            PROBLEM_DESC=@PROBLEM_DESC
                                                WHERE
                                                        ID=@ID";



                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                Comm.Parameters.Add("@PROBLEM_DESC", SqlDbType.NVarChar);
                Comm.Parameters["@PROBLEM_DESC"].Value = problem_txt.Text;

                Comm.Parameters.Add("@STATUS_TYPE", SqlDbType.NVarChar);
                Comm.Parameters["@STATUS_TYPE"].Value = order_status_ddl.SelectedValue;

            }

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