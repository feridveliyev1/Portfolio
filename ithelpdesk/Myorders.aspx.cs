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

public partial class Myorders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            orders_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            orders_sql.SelectCommand = @"SELECT O.ID 'ID',SUBJECT,CONVERT(NVARCHAR,TIME_TO_CONNECT,104) 'DATE',OT.NAME 'STATUS',O.POINT FROM ORDERS  O
                                     LEFT JOIN ORDER_TYPE OT ON O.STATUS_TYPE=OT.ID 
                                                                                            WHERE O.CREATE_BY=@USER_ID ORDER BY O.ID DESC";
            orders_sql.SelectParameters.Add("USER_ID", AuthCookieParse.UserID().ToString());
        }
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
                    Conn.Open();

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.CommandText = @"SELECT O.ID,O.PROBLEM_DESC,(CONVERT(NVARCHAR,TIME_TO_CONNECT,104)) 'DATE',TEAMVIEWER_CODE,TEAMVIEWER_LOGIN,(VU.FNAME+' '+VU.LNAME ) 'USER_FIO',O.SUBJECT,O.DESCRIPTION,OT.NAME AS STATUS FROM ORDERS O 
											LEFT JOIN VENDOR_USERS VU ON O.CREATE_BY=VU.ID     
											LEFT JOIN ORDER_TYPE OT ON O.STATUS_TYPE=OT.ID
											WHERE O.ID=@ID";

                    SqlDataReader reader = Comm.ExecuteReader();

                    if (reader.Read())
                    {
                        Username_edt.Text = reader["USER_FIO"].ToString();

                        Date_edt.Text = reader["DATE"].ToString();

                        Teamviewer_edt.Text = reader["TEAMVIEWER_CODE"].ToString();

                        Subject_edt.Text = reader["SUBJECT"].ToString();

                        Description_edt.Text = reader["DESCRIPTION"].ToString();

                        order_status_edt.Text = reader["STATUS"].ToString();

                        team_log_edt.Text = reader["TEAMVIEWER_LOGIN"].ToString();

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

    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "DELETE_category")
        //{
        //    using (SqlConnection Conn = new SqlConnection())
        //    {
        //        Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

        //        SqlCommand Comm = new SqlCommand();
        //        Comm.Connection = Conn;

        //        Comm.CommandText = @"DELETE FROM CATEGORY WHERE ID = @ID";

        //        Comm.Parameters.Add("@ID", SqlDbType.Int);
        //        Comm.Parameters["@ID"].Value = e.CommandArgument;

        //        Conn.Open();
        //        try
        //        { 
        //            Comm.ExecuteNonQuery(); 
        //        }

        //        catch (SqlException E)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
        //            return;
        //        }


        //        ObjectsGrid.DataBind();

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
        //    }
        //}
    }

    protected void ObjectsGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //LinkButton l = (LinkButton)e.Item.FindControl("Delete_btn");
        //l.Attributes.Add("onclick", "javascript:return confirm('Əminsiniz?')");

    }

    public string getStatus(object SendedPosition)
    {

        switch (SendedPosition.ToString())
        {
            case "WAITING":
                return string.Format("<span class=\"label label-info\">{0}</span>", SendedPosition);
                break;
            case "PROBLEM":
                return string.Format("<span class=\"label label-warning\">{0}</span>", SendedPosition);
                break;
            case "READY":
                return string.Format("<span class=\"label label-default\">DONE</span>");
                break;
        }
        return "error";
    }

}