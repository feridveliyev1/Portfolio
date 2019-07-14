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

public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() != ConfigurationManager.AppSettings["SuperAdmin"])
        {
            Response.Redirect("Default.aspx");
            return;
        }

        if (!IsPostBack)
        {
            //----- Load elements----------------
            username_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            username_sql.SelectCommand = @"SELECT ID,(FNAME+' '+LNAME) NAME FROM VENDOR_USERS WHERE ACTIVE=1";

            operator_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            operator_sql.SelectCommand = @"SELECT ID,(FNAME+' '+LNAME) NAME  FROM USERS WHERE STATUS=1";

            order_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            order_type_sql.SelectCommand = @"SELECT ID,NAME FROM ORDER_TYPE";
            //----------------------------------
        }
    }

    protected void Search_btn_Click(object sender, EventArgs e)
    {
        report_sql.SelectParameters.Clear();

        report_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        report_sql.SelectCommand = "REPORT_SP";
        report_sql.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;

        if(Username_ddl.SelectedIndex==0)
           report_sql.SelectParameters.Add("USER_ID","0");
        else
          report_sql.SelectParameters.Add("USER_ID", Username_ddl.SelectedValue);

        if(Subject_txt.Text.Length==0)
            report_sql.SelectParameters.Add("SUBJECT", "#~#");
        else
            report_sql.SelectParameters.Add("SUBJECT", Subject_txt.Text);

        if(Description_txt.Text.Length==0)
            report_sql.SelectParameters.Add("DESCRIPTION", "#~#");
        else
            report_sql.SelectParameters.Add("DESCRIPTION", Description_txt.Text);

        if (Start_edt.Text.Length == 0)
            report_sql.SelectParameters.Add("BEGIN_DATE", "2012-12-12");
        else
            report_sql.SelectParameters.Add("BEGIN_DATE", DateTime.ParseExact(Start_edt.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString());

        if (Deadline_edt.Text.Length == 0)
            report_sql.SelectParameters.Add("END_DATE", "2012-12-12");
        else
            report_sql.SelectParameters.Add("END_DATE", DateTime.ParseExact(Deadline_edt.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString());

        if(Operator_ddl.SelectedIndex==0)
            report_sql.SelectParameters.Add("OPERATOR_ID", "0");
        else
            report_sql.SelectParameters.Add("OPERATOR_ID", Operator_ddl.SelectedValue);
       
        ObjectsGrid.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();} );</script>", false);
    }

    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {
        try
        {
            problem_txt.Text = null;

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                name_lbl.Text = "";
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


                    SqlCommand Comm2 = new SqlCommand();
                    Comm2.Connection = Conn;

                    Conn.Open();
                    Comm.CommandText = @"SELECT COUNT(*) FROM ORDER_EDITING WHERE USER_ID=@USER_ID AND ORDER_ID=@ORDER_ID";

                    Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                    Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                    Comm.Parameters.Add("@ORDER_ID", SqlDbType.Int);
                    Comm.Parameters["@ORDER_ID"].Value = ObjectID_hf.Value;

                    int count = Convert.ToInt32(Comm.ExecuteScalar());

                    Comm.Parameters.Clear();

                    if (count < 1)
                    {
                        Comm.CommandText = @"INSERT INTO ORDER_EDITING (USER_ID,ORDER_ID,EDIT_DATE,TEXT) VALUES (@USER_ID,@ORDER_ID,
											 CONVERT(NVARCHAR, DATEADD(HOUR,11,GETDATE()),20),'SEEN')";

                        Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                        Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                        Comm.Parameters.Add("@ORDER_ID", SqlDbType.Int);
                        Comm.Parameters["@ORDER_ID"].Value = ObjectID_hf.Value;


                        Comm.ExecuteNonQuery();

                        Comm.Parameters.Clear();
                    }
                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm2.Parameters.Add("@ID", SqlDbType.Int);
                    Comm2.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.CommandText = @"SELECT O.ID,O.PROBLEM_DESC,(CONVERT(NVARCHAR,TIME_TO_CONNECT,104)) 'DATE',TEAMVIEWER_CODE,TEAMVIEWER_LOGIN,(VU.FNAME+' '+VU.LNAME ) 'USER_FIO',O.SUBJECT,O.DESCRIPTION,O.STATUS_TYPE FROM ORDERS O 
											LEFT JOIN VENDOR_USERS VU ON O.CREATE_BY=VU.ID     
											LEFT JOIN ORDER_TYPE OT ON O.STATUS_TYPE=OT.ID
											WHERE O.ID=@ID";

                    Comm2.CommandText = @"SELECT USER_ID,ORDER_ID,EDIT_DATE,TEXT,(U.FNAME + ' ' + U.LNAME) AS FIO,US.STATUS AS STATUS FROM ORDER_EDITING OE
                                            LEFT JOIN ORDERS O ON OE.ORDER_ID=O.ID
                                            LEFT JOIN USERS U ON OE.USER_ID=U.ID
                                            LEFT JOIN USER_STATUS US ON U.STATUS =US.ID
                                            WHERE OE.ORDER_ID=@ID";


                    SqlDataReader reader = Comm.ExecuteReader();



                    if (reader.Read())
                    {
                        Username_edt.Text = reader["USER_FIO"].ToString();

                        Date_edt.Text = reader["DATE"].ToString();

                        Teamviewer_edt.Text = reader["TEAMVIEWER_CODE"].ToString();

                        Subject_edt.Text = reader["SUBJECT"].ToString();

                        Description_edt.Text = reader["DESCRIPTION"].ToString();

                        order_status_ddl.SelectedValue = reader["STATUS_TYPE"].ToString();

                        team_log_edt.Text = reader["TEAMVIEWER_LOGIN"].ToString();




                    }
                    reader.Close();

                    DataTable Table = new DataTable();
                    Table.Load(Comm2.ExecuteReader());

                    for (int i = 0; i < Table.Rows.Count; i++)
                    {
                        name_lbl.Text = name_lbl.Text + Table.Rows[i]["FIO"].ToString() + " " + Table.Rows[i]["EDIT_DATE"].ToString() + " " + Table.Rows[i]["Text"].ToString() + "</br>";
                    }



                }
            }
        }
        catch (SqlException E)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
            //return;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();} );</script>", false);
    }

    //-------------------------------------------------------------
    protected void username_DataBound(object sender, EventArgs e)
    {
        Username_ddl.Items.Insert(0,new ListItem("Choose"));
    }

    protected void Operator_DataBound(object sender, EventArgs e)
    {
        Operator_ddl.Items.Insert(0, new ListItem("Choose"));
    }
    //-------------------------------------------------------------
}