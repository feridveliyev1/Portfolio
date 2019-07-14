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

    public int ID = 0;
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

        client_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        client_dll_sql.SelectCommand = @"SELECT ID,NAME, (NAME + ' ' + SURNAME) as FIO from CLIENTS";

        category_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        category_dll_sql.SelectCommand = @"SELECT ID,NAME FROM DEVICE_CATEGORY";

        game_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        game_dll_sql.SelectCommand = @"SELECT ID,NAME FROM GAMES";

        status_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        status_dll_sql.SelectCommand=@"SELECT ID,STATUS_NAME AS 'NAME' FROM TRANZACTION_STATUS";

        reject_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        reject_dll_sql.SelectCommand = @"SELECT ID,NAME FROM REJECT_REASON";

        worker_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        worker_dll_sql.SelectCommand = @"SELECT ID,NAME FROM USERS WHERE STATUS=3";


        if (!IsPostBack)
        {
            begindate_edt.Text =  DateTime.Now.AddHours(-11).ToString("dd-MM-yyyy HH:mm");
            price_edt.Text = "0";
            Total_price.Text = "0";
            time_edt.Text = "0";
            payed_balane.Text = "0";
            count_edt.Text = "1";
          

        }
          
        

        /*   try
           {
               if (Session["qeydiyyat12_1"].ToString() != "ok")
                   Response.Redirect("Default.aspx");
           }
           catch (Exception)
           {ss
               Response.Redirect("Default.aspx");
           }
  */
       
            SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlDataSource1.SelectCommand = @"SELECT T.CLIENT_ID as CLIENT_ID,T.ID, T.BEGIN_DATE as BEGIN_TIME,END_DATE as END_TIME,T.PRICE,TZ.STATUS_NAME,USERS.NAME as NAME,
 ISNULL(
 CASE (select DATEDIFF(second,DATEADD(HOUR,11,GETDATE()),END_DATE) from TRANZACTIONS TR where  T.ID=TR.ID)
  WHEN  NULL   THEN 0
 ELSE (select DATEDIFF(second,DATEADD(HOUR,11,GETDATE()),END_DATE) from TRANZACTIONS TR where DATEADD(HOUR,11,GETDATE())<TR.END_DATE AND TR.ID=T.ID) 
END,0) DateDif,
                                                 CASE T.CLIENT_ID
									                WHEN 0 THEN T.CUSTOMER_CLIENT
										            ELSE  (C.NAME+ ' '+ C.SURNAME) 
									             END   as CLIENT_NAME
                                                              FROM TRANZACTIONS AS T 
                                                                      left join CLIENTS as C on T.CLIENT_ID=C.ID
                                                                       left join TRANZACTION_STATUS as TZ on T.STATUS_ID=TZ.ID 
                                                                       left join USERS on T.WORKER_ID=USERS.ID WHERE Convert(varchar(10),END_DATE,120)=Convert(varchar(10),dateadd(hour,11,sysdatetime()),120) and  PAYMENT_DELETED=1  ORDER BY T.ID DESC";


          
        
     
    }
    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {
        try
        {

            if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
            {
                //Start_btn.Visible = true;
                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = Conn;

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.CommandText = @"SELECT ID,CLIENT_ID,CUSTOMER_CLIENT,BEGIN_DATE,CATEGORY_ID,PACKAGES_ID,DEVICE_ID,REJECT_ID,REJECT_DESCRIPTON,END_DATE,STATUS_ID,PRICE,PAYMENT_TYPE,CLIENT_CARD,PAYED_BALANCE,WORKER_ID FROM TRANZACTIONS  WHERE ID = @ID";

                    Conn.Open();

                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {

                        client_ddl.SelectedValue = reader["CLIENT_ID"].ToString();

                        client_txt.Text = reader["CUSTOMER_CLIENT"].ToString();

                        begindate_edt.Text = Convert.ToDateTime(reader["BEGIN_DATE"]).ToString("dd-MM-yyyy HH:mm");

                        category_dll.SelectedValue = reader["CATEGORY_ID"].ToString();

                         Packages(Convert.ToInt32(reader["CATEGORY_ID"]));

                         Devices(Convert.ToInt32(reader["CATEGORY_ID"]));

                       // packages_dll.SelectedValue = reader["PACKAGES_ID"].ToString();

                        //device_dll.SelectedValue = reader["DEVICE_ID"].ToString();

                        reject_dll.SelectedValue = reader["REJECT_ID"].ToString();

                        reject_edt.Text = reader["REJECT_DESCRIPTON"].ToString();

                        enddate_edt.Text = Convert.ToDateTime(reader["END_DATE"]).ToString("dd-MM-yyyy HH:mm");

                        status_dll.SelectedValue = reader["STATUS_ID"].ToString();

                        Total_price.Text = reader["PRICE"].ToString();

                        paytype_dll.SelectedValue = reader["PAYMENT_TYPE"].ToString();

                        worker_dll.SelectedValue = reader["WORKER_ID"].ToString();

                        payed_balane.Text = reader["PAYED_BALANCE"].ToString();
                        
                        int n = Convert.ToInt32(reader["ID"].ToString());

                     /*   if (reader["STATUS_ID"].ToString() == "2" || reader["STATUS_ID"].ToString() == "5")
                        {
                            Start_btn.Visible = false;
                        }*/
                        if (reader["STATUS_ID"].ToString() == "3")
                        {
                            payed_balane.Enabled = true;
                        }
                        else
                        {
                            payed_balane.Enabled = false;
                            payed_balane.Text = "0";
                        }

                        ModalCaption_lb.Text = "Məlumat";

                    }
                    else
                    {
                        client_ddl.SelectedIndex = 0;

                        client_txt.Text = "";

                        paytype_dll.SelectedIndex = 0;

                        begindate_edt.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

                        price_edt.Text = "0";

                        enddate_edt.Text = "";


                        game_dll.SelectedIndex = 0;

                        packages_dll.Items.Clear();
                        packages_dll.Items.Insert(0, new ListItem("Выберите", "0"));

                        count_edt.Text = "1";

                        Total_price.Text = "0";

                        payed_balane.Enabled = false;

                        status_dll.SelectedIndex = 0;

                        device_dll.SelectedIndex = 0;

                        payed_balane.Text = "0";

                        worker_dll.SelectedIndex = 0;

                        games_lstbx.Items.Clear();

                        category_dll.SelectedIndex = 0; 

                    

                    }

                    reader.Close();
                }
            }
            else
            {
                client_ddl.SelectedIndex = 0;

                client_txt.Text = "";

                begindate_edt.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

                paytype_dll.SelectedIndex = 0;

                category_dll.SelectedIndex = 0;

                enddate_edt.Text = "";
                
                price_edt.Text = "0";

                game_dll.SelectedIndex = 0;

                packages_dll.Items.Clear();
                packages_dll.Items.Insert(0, new ListItem("Выберите", "0"));

                count_edt.Text = "1";

                status_dll.SelectedIndex = 0;
                
                Total_price.Text = "0";
                
                payed_balane.Enabled = false;

                device_dll.SelectedIndex = 0;

                payed_balane.Text = "0";

                games_lstbx.Items.Clear();

                ModalCaption_lb.Text = "Добавление";

                worker_dll.SelectedIndex = 0;

                games_lstbx.Items.Clear();

               
            }


        }
        catch (SqlException E)
        {
            reject_edt.Text = E.ToString();
        }
         ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);
        
        
      }

    #region  from tranzaction

    public void Packages(int n)
    {

        package_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        package_dll_sql.SelectCommand = @"SELECT ID,NAME FROM PRICE_PACKAGES WHERE DEVICE_CATEGORY=" + n.ToString();
 

    }

    public void Devices(int n)
    {
        devices_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        devices_dll_sql.SelectCommand = @"SELECT ID,D.NAME FROM DEVICES D WHERE DEVICE_CATEGORY_ID="+n.ToString();


    }


    protected void listboxadd(int n)
    {

        using (SqlConnection Connection = new SqlConnection())
        {
            Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Command = new SqlCommand();
            Command.Connection = Connection;

            Command.Parameters.Add("@P_ID", SqlDbType.Int);
            Command.Parameters["@P_ID"].Value = n;


            Connection.Open();

            SqlDataReader reader = Command.ExecuteReader();



            //==========GAMES===========

            Command.CommandText = @"SELECT PAYMENT_ID,GAME_ID FROM TRANCATIONS_GAME WHERE PAYMENT_ID=@P_ID";

            reader = Command.ExecuteReader();

            game_dll.Items.Clear();

            games_lstbx.Items.Clear();


            game_dll.Items.Add("Paketlər siyahısı");

            while (reader.Read())
            {
                game_dll.Items.Add(reader["GAME_ID"].ToString());
                games_lstbx.Items.Add(reader["GAME_ID"].ToString());
            }
            reader.Close();
            //==========GAMES===========

            Connection.Close();


        }

    }







    #endregion
    /*------------------------------------------------------------------------------*/

    /*------------------------------------------------------------------------------*/

    protected void Packagedll_SelectedIndexChanged(object sender, EventArgs e)
    {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = packages_dll.SelectedValue;

                Comm.CommandText = @"SELECT ID,NAME,PRICE,DURATION_IN_MINUTES FROM PRICE_PACKAGES WHERE ID = @ID";

                Conn.Open();


                SqlDataReader reader = Comm.ExecuteReader();


                if (reader.Read())
                {
                   
                    
                    price_edt.Text = reader["PRICE"].ToString();

                    time_edt.Text = reader["DURATION_IN_MINUTES"].ToString();

                    enddate_edt.Text = DateTime.Now.AddMinutes(Convert.ToInt32(reader["DURATION_IN_MINUTES"])).ToString("dd-MM-yyyy HH:mm");

                   
                }
                else
                {
                time_edt.Text = "0";

                enddate_edt.Text = null;


                price_edt.Text = "0";

                time_edt.Text = "0";
                }
                reader.Close();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);

    }

    protected void package_dll_DataBound(object sender, EventArgs e)
    {
        packages_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();$('.timer').startTimer();} );</script>", false);
    }

    protected void device_dll_DataBound(object sender, EventArgs e)
    {
        device_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();$('.timer').startTimer();} );</script>", false);
    }

    protected void device_chg(object sender,EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);
        
        }
    protected void Clientdd_SelectedIndexChanged(object sender, EventArgs e)
    {
     
            //using (SqlConnection Conn = new SqlConnection())
            //{
            //    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            //    SqlCommand Comm = new SqlCommand();

            //    Comm.Connection = Conn;

            //    Comm.Parameters.Add("@ID", SqlDbType.Int);

            //    Comm.Parameters["@ID"].Value = client_ddl.SelectedValue;

            //    Comm.CommandText = @"SELECT ID,CLIENT_ID,BALANCE,CODE FROM CARD WHERE CLIENT_ID=@ID";

            //    Conn.Open();


            //    SqlDataReader reader = Comm.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        kardcode_edt.Text = reader["CODE"].ToString();
            //       kardbalance_edt.Text = reader["BALANCE"].ToString();
            //    }
            //    else
            //    {
            //        kardcode_edt.Text = "Tapılmadı ";
            //        kardbalance_edt.Text = "Tapılmadı ";

            //    }

            //    reader.Close();

            //}

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);
    }
    protected void payed_balane_textchanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);
    }
    protected void reject_ddl_DataBound(object sender, EventArgs e)
    {
        reject_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void client_ddl_DataBound(object sender, EventArgs e)
    {
        client_ddl.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void remove_text(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();

                Comm.Connection = Conn;

                Comm.Parameters.Add("@NAME", SqlDbType.NVarChar);
                //Comm.Parameters["@NAME"].Value = package_lstbx.SelectedItem.Text.ToString();

                Comm.CommandText = @"SELECT ID,NAME,PRICE FROM PRICE_PACKAGES WHERE NAME = @NAME";

                Conn.Open();

                SqlDataReader reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    price_edt.Text = (Convert.ToDecimal(price_edt.Text) - Convert.ToDecimal(reader["PRICE"])).ToString();
                }
                reader.Close();
            }
           // package_lstbx.Items.RemoveAt(package_lstbx.SelectedIndex);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }

    protected void Category_SelectedIndexChanged(object sender, EventArgs e)
    {
    

        price_edt.Text = "0";

        time_edt.Text = "0";


        enddate_edt.Text = null;

        package_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        package_dll_sql.SelectCommand = @"SELECT ID,NAME FROM PRICE_PACKAGES WHERE DEVICE_CATEGORY=" + category_dll.SelectedValue.ToString();

        devices_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        devices_dll_sql.SelectCommand = @"SELECT ID,D.NAME FROM DEVICES D WHERE DEVICE_CATEGORY_ID=" +category_dll.SelectedValue.ToString();


           ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);

    }
    protected void category_dll_DataBound(object sender, EventArgs e)
    {
        category_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void remove1_text(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
           // device_lstbx.Items.RemoveAt(device_lstbx.SelectedIndex);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }
    protected void Gamesdll_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            games_lstbx.Items.Add(game_dll.SelectedItem);
            game_dll.SelectedIndex = 0;
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);
    }
    protected void game_dll_DataBound(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            game_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
     
    protected void status_dll_DataBound(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            status_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        }



        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void remove_game_text(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            games_lstbx.Items.RemoveAt(games_lstbx.SelectedIndex);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }
    protected void worker_ddl_DataBound(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            worker_dll.Items.Insert(0, new ListItem("Выберите", "0"));
        }
    }

    protected void Save_status_btn_Click(object sender, EventArgs e)
    {
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
                Comm.CommandText = @"UPDATE TRANZACTIONS SET PAYMENT_DELETED=@PAYMENT_DELETED,OPERATOR_ID=@OPERATOR_ID WHERE ID=@ID";

                Comm.Parameters.Add("@PAYMENT_DELETED", SqlDbType.Int);
                Comm.Parameters["@PAYMENT_DELETED"].Value = 0;

                Comm.Parameters.Add("@OPERATOR_ID", SqlDbType.Int);
                Comm.Parameters["@OPERATOR_ID"].Value = AuthCookieParse.UserID();

                Conn.Open();
                try { Comm.ExecuteNonQuery(); }
                catch (SqlException E)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();;$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
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
        l.Attributes.Add("onclick", "javascript:return confirm('Вы уверены?')");

    }

    protected void Start_btn_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(client_ddl.SelectedValue) == 0 && client_txt.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Adı daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(category_dll.SelectedValue) == 0 && status_dll.SelectedValue != "5" && status_dll.SelectedValue != "2")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Kategoriya daxil edin', '');} );</script>", false);
        }
         else if (Convert.ToInt32(packages_dll.SelectedValue) == 0 && status_dll.SelectedValue != "5" && status_dll.SelectedValue != "2")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Paketi daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(device_dll.SelectedValue) == 0 && status_dll.SelectedValue!="5" && status_dll.SelectedValue!="2")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Aparatı daxil edin', '');} );</script>", false);
        }
        else if (games_lstbx.Width == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Oyunları daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(status_dll.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Statusu daxil edin', '');} );</script>", false);
        }
        else if (Convert.ToInt32(worker_dll.SelectedValue) == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','İşçiləri daxil edin', '');} );</script>", false);
        }
        else
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();


                Comm.Connection = Conn;


                Conn.Open();
                //=====================================================================

                if (ObjectID_hf.Value.Length != 0 && ObjectID_hf.Value != "-1")
                {
                    Comm.CommandText = @"UPDATE TRANZACTIONS  SET
                                                 CLIENT_ID=@CLIENT_ID,
                                                CUSTOMER_CLIENT=@CUSTOMER_CLIENT,
                                                CATEGORY_ID=@CATEGORY_ID,
                                                PACKAGES_ID=@PACKAGES_ID,
                                                DEVICE_ID=@DEVICE_ID,
                                                STATUS_ID=@STATUS_ID,
                                                PRICE=@PRICE,
                                                PAYMENT_TYPE=@PAYMENT_TYPE,
                                                CLIENT_CARD=@CLIENT_CARD,
                                                BEGIN_DATE=DATEADD(HOUR,11,GETDATE()),
                                                END_DATE=DATEADD(HOUR,11,DATEADD(MINUTE,@END_DATE,GETDATE())),
                                                WORKER_ID=@WORKER_ID,
                                                PACKAGES_COUNT=@PACKAGES_COUNT,
                                                REJECT_ID=@REJECT_ID,
                                                REJECT_DESCRIPTON=@REJECT_DESCRIPTON,
                                                PAYED_BALANCE=@PAYED_BALANCE,
                                                OPERATOR_ID=@OPERATOR_ID
                                                                    WHERE
                                        ID = @ID";

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Tranzaction_device(Convert.ToInt32(ObjectID_hf.Value));

                    Tranzaction_packages(Convert.ToInt32(ObjectID_hf.Value));

                    Tranzaction_category(Convert.ToInt32(ObjectID_hf.Value));

                    Tranzaction_games(Convert.ToInt32(ObjectID_hf.Value));

                    Comm.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
                    Comm.Parameters["@CLIENT_ID"].Value = client_ddl.SelectedValue;

                    Comm.Parameters.Add("@PACKAGES_COUNT", SqlDbType.Int);
                    Comm.Parameters["@PACKAGES_COUNT"].Value = count_edt.Text;

                    Comm.Parameters.Add("@CUSTOMER_CLIENT", SqlDbType.NVarChar);
                    Comm.Parameters["@CUSTOMER_CLIENT"].Value = client_txt.Text;

                    Comm.Parameters.Add("@CATEGORY_ID", SqlDbType.Int);
                    Comm.Parameters["@CATEGORY_ID"].Value = category_dll.SelectedValue;

                    Comm.Parameters.Add("@PACKAGES_ID", SqlDbType.Int);
                    Comm.Parameters["@PACKAGES_ID"].Value = packages_dll.SelectedValue;

                    Comm.Parameters.Add("@DEVICE_ID", SqlDbType.Int);
                    Comm.Parameters["@DEVICE_ID"].Value = device_dll.SelectedValue;

                    Comm.Parameters.Add("@STATUS_ID", SqlDbType.Int);
                    Comm.Parameters["@STATUS_ID"].Value = status_dll.SelectedValue;

                    Comm.Parameters.Add("@PAYMENT_TYPE", SqlDbType.Int);
                    Comm.Parameters["@PAYMENT_TYPE"].Value = paytype_dll.SelectedValue;

                    Comm.Parameters.Add("@CLIENT_CARD", SqlDbType.Int);
                    Comm.Parameters["@CLIENT_CARD"].Value = 2;

                    if (status_dll.SelectedValue == "2" || status_dll.SelectedValue == "5")
                    {
                        Comm.Parameters.Add("@END_DATE", SqlDbType.Int);
                        Comm.Parameters["@END_DATE"].Value = 0;
                    }
                    else
                    {
                        Comm.Parameters.Add("@END_DATE", SqlDbType.Int);
                        Comm.Parameters["@END_DATE"].Value = time_edt.Text;
                    }
                   

                    Comm.Parameters.Add("@WORKER_ID", SqlDbType.Int);
                    Comm.Parameters["@WORKER_ID"].Value = worker_dll.SelectedValue;

                    Comm.Parameters.Add("@REJECT_ID", SqlDbType.Int);
                    Comm.Parameters["@REJECT_ID"].Value = reject_dll.SelectedValue;

                    Comm.Parameters.Add("@REJECT_DESCRIPTON", SqlDbType.NVarChar);
                    Comm.Parameters["@REJECT_DESCRIPTON"].Value = reject_edt.Text;

                    Comm.Parameters.Add("@OPERATOR_ID", SqlDbType.Int);
                    Comm.Parameters["@OPERATOR_ID"].Value = AuthCookieParse.UserID();


                    if (status_dll.SelectedValue == "2")
                    {

                        Comm.Parameters.Add("@PAYED_BALANCE", SqlDbType.Decimal);
                        Comm.Parameters["@PAYED_BALANCE"].Value = 0;

                        Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
                        Comm.Parameters["@PRICE"].Value = Total_price.Text;

                    }
                    else if (status_dll.SelectedValue == "5")
                    {
                        Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
                        Comm.Parameters["@PRICE"].Value = Total_price.Text;

                        Comm.Parameters.Add("@PAYED_BALANCE", SqlDbType.Decimal);
                        Comm.Parameters["@PAYED_BALANCE"].Value = payed_balane.Text;
                    }
                    else
                    {
                        Comm.Parameters.Add("@PAYED_BALANCE", SqlDbType.Decimal);
                        Comm.Parameters["@PAYED_BALANCE"].Value = payed_balane.Text;

                        Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
                        Comm.Parameters["@PRICE"].Value = Convert.ToDecimal(Convert.ToDecimal(Total_price.Text) + Convert.ToDecimal(price_edt.Text) * Convert.ToDecimal(count_edt.Text)).ToString();
                    }

                    try
                    {
                        Comm.ExecuteNonQuery();
                    }
                    catch (SqlException E)
                    {
                        client_txt.Text = E.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                        return;
                    }
                }

                else
                {
                    Comm.CommandText = @"INSERT INTO TRANZACTIONS(CLIENT_ID,CUSTOMER_CLIENT,CATEGORY_ID,PACKAGES_ID,DEVICE_ID,STATUS_ID,PRICE,PAYMENT_TYPE,CLIENT_CARD,BEGIN_DATE,END_DATE,WORKER_ID,REJECT_ID,REJECT_DESCRIPTON,PAYMENT_DELETED,PAYED_BALANCE,PACKAGES_COUNT,OPERATOR_ID)
                                                VALUES(@CLIENT_ID,@CUSTOMER_CLIENT,@CATEGORY_ID,@PACKAGES_ID,@DEVICE_ID,@STATUS_ID,@PRICE,@PAYMENT_TYPE,@CLIENT_CARD,DATEADD(HOUR,11,GETDATE()),DATEADD(HOUR,11,DATEADD(MINUTE,@END_DATE,GETDATE())),@WORKER_ID,@REJECT_ID,@REJECT_DESCRIPTON,@PAYMENT_DELETED,@PAYED_BALANCE,@PACKAGES_COUNT,@OPERATOR_ID);SELECT SCOPE_IDENTITY()";




                    Comm.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
                    Comm.Parameters["@CLIENT_ID"].Value = client_ddl.SelectedValue;

                    Comm.Parameters.Add("@PACKAGES_COUNT", SqlDbType.Int);
                    Comm.Parameters["@PACKAGES_COUNT"].Value = count_edt.Text;

                    Comm.Parameters.Add("@CUSTOMER_CLIENT", SqlDbType.NVarChar);
                    Comm.Parameters["@CUSTOMER_CLIENT"].Value = client_txt.Text;

                    Comm.Parameters.Add("@CATEGORY_ID", SqlDbType.Int);
                    Comm.Parameters["@CATEGORY_ID"].Value = category_dll.SelectedValue;

                    Comm.Parameters.Add("@PACKAGES_ID", SqlDbType.Int);
                    Comm.Parameters["@PACKAGES_ID"].Value = packages_dll.SelectedValue;

                    Comm.Parameters.Add("@DEVICE_ID", SqlDbType.Int);
                    Comm.Parameters["@DEVICE_ID"].Value = device_dll.SelectedValue;

                    Comm.Parameters.Add("@STATUS_ID", SqlDbType.Int);
                    Comm.Parameters["@STATUS_ID"].Value = status_dll.SelectedValue;

                    Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
                    Comm.Parameters["@PRICE"].Value = (Convert.ToDecimal(price_edt.Text) * Convert.ToDecimal(count_edt.Text)).ToString();

                    Comm.Parameters.Add("@PAYMENT_TYPE", SqlDbType.Int);
                    Comm.Parameters["@PAYMENT_TYPE"].Value = paytype_dll.SelectedValue;

                    Comm.Parameters.Add("@CLIENT_CARD", SqlDbType.Int);
                    Comm.Parameters["@CLIENT_CARD"].Value = 1;



                    Comm.Parameters.Add("@END_DATE", SqlDbType.Int);
                    Comm.Parameters["@END_DATE"].Value = time_edt.Text;

                    Comm.Parameters.Add("@WORKER_ID", SqlDbType.Int);
                    Comm.Parameters["@WORKER_ID"].Value = worker_dll.SelectedValue;

                    Comm.Parameters.Add("@REJECT_ID", SqlDbType.Int);
                    Comm.Parameters["@REJECT_ID"].Value = reject_dll.SelectedValue;

                    Comm.Parameters.Add("@REJECT_DESCRIPTON", SqlDbType.NVarChar);
                    Comm.Parameters["@REJECT_DESCRIPTON"].Value = reject_edt.Text;

                    Comm.Parameters.Add("@PAYMENT_DELETED", SqlDbType.Int);
                    Comm.Parameters["@PAYMENT_DELETED"].Value = 1;

                    Comm.Parameters.Add("@PAYED_BALANCE", SqlDbType.Decimal);
                    Comm.Parameters["@PAYED_BALANCE"].Value = payed_balane.Text;

                    Comm.Parameters.Add("@OPERATOR_ID", SqlDbType.Int);
                    Comm.Parameters["@OPERATOR_ID"].Value = AuthCookieParse.UserID();

                    try
                    {

                        ID = Convert.ToInt32(Comm.ExecuteScalar());

                        Tranzaction_device(ID);

                        Tranzaction_packages(ID);

                        Tranzaction_category(ID);

                        Tranzaction_games(ID);



                    }
                    catch (SqlException E)
                    {
                        client_txt.Text = E.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                        return;
                    }
                }

                ObjectsGrid.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);


            }


        }
    }




    protected void Tranzactions_card(int cl_id, decimal price)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Comm.CommandText = @"UPDATE CARD SET BALANCE=@PRICE WHERE CLIENT_ID=@CL_ID";

            Comm.Parameters.Add("@CL_ID", SqlDbType.Int);
            Comm.Parameters["@CL_ID"].Value = cl_id;

            Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
            Comm.Parameters["@PRICE"].Value = price;

            Conn.Open();

            try
            {
                Comm.ExecuteNonQuery();
            }
            catch
            {


            }
            Conn.Close();
        }
    }


    protected void Tranzaction_device(int id)
    {

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Comm.CommandText = @"INSERT INTO TRANZACTIONS_DEVICE(PAYMENT_ID,DEVICE_ID) VALUES(@P_ID,@DC_ID)";
            Conn.Open();

                Comm.Parameters.Add("@P_ID", SqlDbType.Int);
                Comm.Parameters["@P_ID"].Value = id;

                Comm.Parameters.Add("@DC_ID", SqlDbType.Int);
                Comm.Parameters["@DC_ID"].Value = device_dll.SelectedValue;

                Comm.ExecuteNonQuery();

                Comm.Parameters.Clear();

            Conn.Close();
        }
    }//READY


    protected void Tranzaction_packages(int id)
    {

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Comm.CommandText = @"INSERT INTO TRANZACTIONS_PACKAGES(PAYMENT_ID,PACKAGES_ID) VALUES(@P_ID,@P)";
            Conn.Open();

                Comm.Parameters.Add("@P_ID", SqlDbType.Int);
                Comm.Parameters["@P_ID"].Value = id;

                Comm.Parameters.Add("@P", SqlDbType.Int);
                Comm.Parameters["@P"].Value = packages_dll.SelectedValue;

                Comm.ExecuteNonQuery();

                Comm.Parameters.Clear();

            Conn.Close();

        }
    }
    protected void Tranzaction_category(int id)
    {

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Comm.CommandText = @"INSERT INTO TRANZACTIONS_CATEGORY(PAYMENT_ID,DAVICE_CATEGORY) VALUES(@P_ID,@C_ID)";
            Conn.Open();

            Comm.Parameters.Add("@P_ID", SqlDbType.Int);
            Comm.Parameters["@P_ID"].Value = id;

            Comm.Parameters.Add("@C_ID", SqlDbType.Int);
            Comm.Parameters["@C_ID"].Value = category_dll.SelectedValue;

            Comm.ExecuteNonQuery();

            Comm.Parameters.Clear();

            Conn.Close();

        }
    }

    protected void Tranzaction_games(int id)
    {

        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Comm.CommandText = @"INSERT INTO TRANZACTIONS_GAME(PAYMENT_ID,GAME_ID) VALUES(@P_ID,@G_ID)";
            Conn.Open();
            for (int i = 0; i < games_lstbx.Items.Count; i++)
            {
                Comm.Parameters.Add("@P_ID", SqlDbType.Int);
                Comm.Parameters["@P_ID"].Value = id;

                Comm.Parameters.Add("@G_ID", SqlDbType.NVarChar);
                Comm.Parameters["@G_ID"].Value = games_lstbx.Items[i].Text;

                Comm.ExecuteNonQuery();

                Comm.Parameters.Clear();

            }
            Conn.Close();

        }
    }

    protected void Statusdll_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (status_dll.SelectedValue == "3")
        {
            payed_balane.Enabled = true;
        }
        else
        {
            payed_balane.Enabled = false;

        }

        if (status_dll.SelectedValue == "5")
        {
            reject_dll.Enabled = true;
            reject_edt.Enabled = true;


            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                Comm.CommandText = @"SELECT P.PRICE PPRICE,PACKAGES_COUNT,T.PRICE TPRICE FROM TRANZACTIONS T LEFT JOIN   PRICE_PACKAGES p on t.PACKAGES_ID=p.ID  WHERE T.ID=@ID";

                Conn.Open();

                SqlDataReader reader = Comm.ExecuteReader();

                reader.Read();
                Total_price.Text = (Convert.ToDecimal(reader["TPRICE"].ToString()) - Convert.ToDecimal(reader["PPRICE"].ToString()) * Convert.ToDecimal(reader["PACKAGES_COUNT"].ToString())).ToString();

            }
        }
        else
        {
            reject_dll.Enabled = false;
            reject_edt.Enabled = false;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);

    }
    protected void reject_chg(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('.timer').startTimer();$('#datatable').dataTable();});</script>", false);

    }
    protected void Count_edt_text_changed(object sender, EventArgs e)
    {

    }
    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        
    }
    protected string GetTimeLeft(DateTime EndsDate)
    {

        //string FormatDate = "MM/dd/yyyy HH:mm:ss";

        //string newenddate = EndsDate.ToString(FormatDate);

        //string t=EndsDate.Date.ToShortTimeString().ToString("HH:mm:ss");

        DateTime myDate1 = DateTime.Now;

        DateTime myDate2 = EndsDate;

        return (myDate2 - myDate1).ToString();
    }


    protected void LoadClientInfo_btn_Click(object sender, EventArgs e)
    {
        try
        {
            source_type_name_ddl.DataBind();
            source_type.DataBind();

            if (ClientID_hf.Value.Length != 0 && ClientID_hf.Value != "-1")
            {
                using (SqlConnection Conn = new SqlConnection())
                {
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                    SqlCommand Comm = new SqlCommand();
                    Comm.Connection = Conn;

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ClientID_hf.Value;

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

                        birthday_txt.Text = Convert.ToDateTime(reader["BIRTHDAY"]).Date.ToString("yyyy-MM-dd");

                        source_type.SelectedValue = reader["SOURCE_TYPE"].ToString();

                        //  ======================================================================================

                        int type = Convert.ToInt32(reader["SOURCE_TYPE"].ToString());
                        int type_name = Convert.ToInt32(reader["SOURCE_TYPE_NAME"].ToString());
                        source_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
                        switch (type)
                        {
                            case 1:
                                source_type_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE";
                                break;
                            case 2:
                                source_type_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS";
                                break;
                        }

                        source_type_name_ddl.DataBind();
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

                //ModalCaption_lb.Text = "ƏLAVƏ ET";
            }
        }
        catch (SqlException E)
        {
            client_name_edt.Text = E.Message;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }

    protected void SaveClient_btn_Click(object sender, EventArgs e)
    {
        if (client_name_edt.Text == "" || client_surname_edt.Text == "")
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

                if (ClientID_hf.Value.Length != 0 && ClientID_hf.Value != "-1")
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
                    Comm.Parameters["@ID"].Value = ClientID_hf.Value;
                }
                else
                    Comm.CommandText = @"INSERT INTO CLIENTS(NAME,SURNAME,PHONE_NUMBER,GENDER,AGE_INTERVAL,BIRTHDAY,SOURCE_TYPE,SOURCE_TYPE_NAME,USER_ID) 
                                VALUES(@NAME,@SURNAME,@PHONE_NUMBER,@GENDER,@AGE_INTERVAL,@BIRTHDAY,@SOURCE_TYPE,@SOURCE_TYPE_NAME,@USER_ID);SELECT SCOPE_IDENTITY()";

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
                    Comm.Parameters["@BIRTHDAY"].Value = DBNull.Value;
                }


                Comm.Parameters.Add("@SOURCE_TYPE", SqlDbType.Int);
                Comm.Parameters["@SOURCE_TYPE"].Value = source_type.SelectedValue;

                Comm.Parameters.Add("@SOURCE_TYPE_NAME", SqlDbType.Int);
                Comm.Parameters["@SOURCE_TYPE_NAME"].Value = source_type_name_ddl.SelectedValue;

                Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                Conn.Open();

                int NewClientID = -1;

                try
                {
                    if (ClientID_hf.Value.Length == 0 || ClientID_hf.Value == "-1")
                        NewClientID = Convert.ToInt32(Comm.ExecuteScalar());
                    else
                        Comm.ExecuteNonQuery();
                }
                catch (SqlException E)
                {
                    client_name_edt.Text = E.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
                    return;
                }

                if (NewClientID != -1)
                {
                    Comm.CommandText = @"UPDATE TRANZACTIONS SET
                                            CLIENT_ID = @CLIENT_ID
                                         WHERE
                                            ID = @ID";

                    Comm.Parameters.Clear();

                    Comm.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
                    Comm.Parameters["@CLIENT_ID"].Value = NewClientID;

                    Comm.Parameters.Add("@ID", SqlDbType.Int);
                    Comm.Parameters["@ID"].Value = ObjectID_hf.Value;

                    Comm.ExecuteNonQuery();
                }

                ObjectsGrid.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
            }
        }
    }

    protected void source_ddl_DataBound(object sender, EventArgs e)
    {
        source_type_name_ddl.Items.Insert(0, new ListItem("Выберите", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
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
}