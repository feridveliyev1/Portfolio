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


        if(!IsPostBack)
        {
 
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.SelectCommand = new SqlCommand(@"SELECT T.ID, T.BEGIN_DATE as BEGIN_TIME,END_DATE as END_TIME,T.PRICE,TZ.STATUS_NAME,USERS.NAME as NAME,(SELECT U.NAME FROM USERS U WHERE T.OPERATOR_ID=U.ID) as OPNAME,
                                                 CASE T.CLIENT_ID
									             WHEN 0 THEN T.CUSTOMER_CLIENT
										         ELSE  (C.NAME+ ' '+ C.SURNAME) 
									             END   as CLIENT_NAME,
									             CASE T.PAYMENT_DELETED
									             WHEN 1 THEN 'ACTIVE'
									             WHEN 0 THEN 'SILINIB'
									             END AS DELETED
                                                              FROM TRANZACTIONS AS T 
                                                                      left join CLIENTS as C on T.CLIENT_ID=C.ID
                                                                       left join TRANZACTION_STATUS as TZ on T.STATUS_ID=TZ.ID 
                                                                       left join USERS on T.WORKER_ID=USERS.ID WHERE Convert(varchar(10),END_DATE,120)=Convert(varchar(10),dateadd(hour,11,sysdatetime()),120)", conn);

                adapter.Fill(dt);
                conn.Close();
                ObjectsGrid.DataSource = dt;
                ObjectsGrid.DataBind();
                decimal sum_qazanc = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    decimal qazanc = 0;

                    try
                    {

                        qazanc = decimal.Parse(dt.Rows[i]["PRICE"].ToString());

                    }
                    catch { }




                    sum_qazanc += qazanc;

                }
                txtqazanc.Text = sum_qazanc.ToString();

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


                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = e.CommandArgument;

                Comm.CommandText = @"DELETE FROM PAYMENT WHERE ID = @ID";

                

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
    protected void GetReport_btn_Click(object sender, EventArgs e)
    {


        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter1.SelectCommand = new SqlCommand(@"SELECT T.ID, T.BEGIN_DATE as BEGIN_TIME,END_DATE as END_TIME,T.PRICE,TZ.STATUS_NAME,USERS.NAME as NAME,(SELECT U.NAME FROM USERS U WHERE T.OPERATOR_ID=U.ID) as OPNAME,
                                                 CASE T.CLIENT_ID
									             WHEN 0 THEN T.CUSTOMER_CLIENT
										         ELSE  (C.NAME+ ' '+ C.SURNAME) 
									             END   as CLIENT_NAME,
									             CASE T.PAYMENT_DELETED
									             WHEN 1 THEN 'ACTIVE'
									             WHEN 0 THEN 'SILINIB'
									             END AS DELETED
                                                              FROM TRANZACTIONS AS T 
                                                                      left join CLIENTS as C on T.CLIENT_ID=C.ID
                                                                       left join TRANZACTION_STATUS as TZ on T.STATUS_ID=TZ.ID 
                                                                       left join USERS on T.WORKER_ID=USERS.ID WHERE Convert(varchar(10),END_DATE,120)>=Convert(varchar(10),@time_begin,120) and Convert(varchar(10),END_DATE,120)<=Convert(varchar(10),@time_last,120)", conn);

            adapter1.SelectCommand.Parameters.Add("@time_begin", SqlDbType.DateTime).Value = FromDAte.Text;
            adapter1.SelectCommand.Parameters.Add("@time_last", SqlDbType.DateTime).Value = ToDate.Text;
            adapter1.Fill(dt);
           
            conn.Close();
            ObjectsGrid.DataSource = dt;
            ObjectsGrid.DataBind();
            decimal sum_qazanc = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                decimal qazanc = 0;

                try
                {

                    qazanc = decimal.Parse(dt.Rows[i]["PRICE"].ToString());

                }
                catch { }




                sum_qazanc += qazanc;

            }
            txtqazanc.Text = sum_qazanc.ToString();


        }
         
    }

    public string getStatus(object DeletedPosition)
    {
        //  return "style=background-color:red";
        switch (DeletedPosition.ToString())
        {
            case "SILINIB":
                return string.Format("<span class=\"label label-danger\">{0}</span>", DeletedPosition);
                break;
            case "ACTIVE":
                return string.Format("<span class=\"label label-success\">{0}</span>", DeletedPosition);
                break;
            


        }
        return "error";
    }
}