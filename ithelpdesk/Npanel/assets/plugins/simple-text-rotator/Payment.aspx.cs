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
        client_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        client_dll_sql.SelectCommand = @"SELECT ID,NAME, (NAME + ' ' + SURNAME) as FIO from CLIENTS";

        category_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        category_dll_sql.SelectCommand = @"SELECT ID,NAME FROM DEVICE_CATEGORY";

        game_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        game_dll_sql.SelectCommand = @"SELECT ID,NAME FROM GAME_CATEGORY";

        status_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        status_dll_sql.SelectCommand=@"SELECT ID,STATUS_NAME AS 'NAME' FROM TRANZACTION_STATUS";

        reject_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        reject_dll_sql.SelectCommand = @"SELECT ID,NAME FROM REJECT_REASON";


        if (!IsPostBack)
        {
            begindate_edt.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            price_edt.Text = "0";
            Total_price.Text = "0";

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
//        SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

//        SqlDataSource1.SelectCommand = @"SELECT P.ID,C.NAME as CLIENT,CLIENT_DESCRIPTON,PRICE,P.PAYMENT_DATE,
// CASE PAYMENT_TYPE
// WHEN 1 THEN 'Kart'
// WHEN 2 THEN 'Cash'
//   END AS PAY_TYPE
//    FROM PAYMENT as P
//                                                 left JOIN CLIENTS as C on P.CLIENT_ID=C.ID WHERE PAYMENT_DELETED = 1 and Convert(varchar(10),PAYMENT_DATE,120)=Convert(varchar(10),dateadd(hour,11,sysdatetime()),120)";

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

                    Comm.CommandText = @"SELECT ID,CLIENT_ID,CLIENT_DESCRIPTON,PAYMENT_TYPE,CLIENT_CARD,PRICE FROM PAYMENT  WHERE ID = @ID";

                    Conn.Open();

                    SqlDataReader reader = Comm.ExecuteReader();


                    if (reader.Read())
                    {
                      //  client_ddl.SelectedValue = reader["CLIENT_ID"].ToString();

                      //  client_txt.Text = reader["CLIENT_DESCRIPTON"].ToString();

                        paytype_dll.SelectedValue = reader["PAYMENT_TYPE"].ToString();

                        specialpayment_dll.SelectedValue = reader["CLIENT_CARD"].ToString();

                        price_edt.Text = reader["PRICE"].ToString();

                        int n = Convert.ToInt32(reader["ID"].ToString());

                      //  listboxadd(n);     //listboxs add

                        ModalCaption_lb.Text = "Məlumat";

                    }
                    else
                    {
                     //   client_ddl.SelectedIndex = 0;

                     //   client_txt.Text = "";

                        paytype_dll.SelectedIndex = 0;

                        specialpayment_dll.SelectedIndex = 0;

                        price_edt.Text = "0";


                        game_dll.SelectedIndex = 0;

                     //   package_dll.SelectedIndex = 0;

                        device_dll.SelectedIndex = 0;

                        specialpayment_dll.SelectedIndex = 0;

                    //    kardbalance_edt.Text = "";

                        kardcode_edt.Text = "";

                    //    device_lstbx.Items.Clear();

                     //   package_lstbx.Items.Clear();

                        games_lstbx.Items.Clear();

                    }

                    reader.Close();
                }
            }
            else
            {
               // client_ddl.SelectedIndex = 0;

             //   client_txt.Text = "";

                paytype_dll.SelectedIndex = 0;

                specialpayment_dll.SelectedIndex = 0;

                price_edt.Text = "0";

                game_dll.SelectedIndex = 0;

             //   package_dll.SelectedIndex = 0;

                device_dll.SelectedIndex = 0;

                specialpayment_dll.SelectedIndex = 0;

                //kardbalance_edt.Text = "";

                kardcode_edt.Text = "";

              //  device_lstbx.Items.Clear();

               // package_lstbx.Items.Clear();

                games_lstbx.Items.Clear();

                ModalCaption_lb.Text = "Əlavə et";

                
            }


        }
        catch (SqlException E)
        {

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }

   //#region  from tranzaction

   // protected void listboxadd(int n)
   // {

   //     using (SqlConnection Connection = new SqlConnection())
   //     {
   //         Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

   //         SqlCommand Command = new SqlCommand();
   //         Command.Connection = Connection;

   //         Command.Parameters.Add("@P_ID", SqlDbType.Int);
   //         Command.Parameters["@P_ID"].Value = n;

   //         //==========DEVICE===========
   //         Command.CommandText = @"SELECT PAYMENT_ID,DEVICE_CATEGORY_ID FROM TRANCATIONS_DEVICE WHERE PAYMENT_ID=@P_ID";

   //         Connection.Open();

   //         SqlDataReader reader = Command.ExecuteReader();

   //        // device_dll.Items.Clear();

   //         device_lstbx.Items.Clear();

           
   //         device_dll.Items.Add("Aparatlar siyahısı");

   //         while (reader.Read())
   //         {
   //         //    device_dll.Items.Add(reader["DEVICE_CATEGORY_ID"].ToString());

   //             device_lstbx.Items.Add(reader["DEVICE_CATEGORY_ID"].ToString());
   //         }
   //         reader.Close();

   //         Command.CommandText = "";
   //         //==========DEVICE===========

   //         //==========PACKAGES===========
   //         Command.CommandText = @"SELECT PAYMENT_ID,PACKAGES FROM PAYMENT_TRANZACTIONS WHERE PAYMENT_ID=@P_ID";

   //         reader = Command.ExecuteReader();

   //         package_dll.Items.Clear();

   //         package_lstbx.Items.Clear();

   //         package_dll.Items.Add("Paketlər siyahısı");

   //         while (reader.Read())
   //         {
   //             package_dll.Items.Add(reader["PACKAGES"].ToString());
   //             package_lstbx.Items.Add(reader["PACKAGES"].ToString());
   //         }
   //         reader.Close();


   //         //==========PACKAGES===========



   //         //==========GAMES===========

   //         Command.CommandText = @"SELECT PAYMENT_ID,GAME_ID FROM TRANCATIONS_GAME WHERE PAYMENT_ID=@P_ID";

   //         reader = Command.ExecuteReader();

   //         games_dll.Items.Clear();

   //         games_lstbx.Items.Clear();


   //         games_dll.Items.Add("Paketlər siyahısı");

   //         while (reader.Read())
   //         {
   //             games_dll.Items.Add(reader["GAME_ID"].ToString());
   //             games_lstbx.Items.Add(reader["GAME_ID"].ToString());
   //         }
   //         reader.Close();
   //         //==========GAMES===========

   //         Connection.Close();


   //     }

   // }







   // #endregion


    //protected void Save_btn_Click(object sender, EventArgs e)
    //{

    //    //using (SqlConnection Conn = new SqlConnection())
    //    //{
    //    //    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

    //    //    SqlCommand Comm = new SqlCommand();
    //    //    Comm.Connection = Conn;


    //    //    Comm.CommandText = @"INSERT INTO PAYMENT(CLIENT_ID,CLIENT_DESCRIPTON,PRICE,PAYMENT_TYPE,CLIENT_CARD,PAYMENT_DELETED,PAYMENT_DATE) VALUES(@CLIENT_ID,@CLIENT_DESCRIPTON,@PRICE,@PAYMENT_TYPE,@CLIENT_CARD,@PAYMENT_DELETED,@PAYMENT_DATE);SELECT SCOPE_IDENTITY()";

    //    //    Comm.Parameters.Add("@CLIENT_ID", SqlDbType.Int);
    //    //    Comm.Parameters["@CLIENT_ID"].Value = client_ddl.SelectedValue;

    //    //    Comm.Parameters.Add("@CLIENT_DESCRIPTON", SqlDbType.NVarChar);
    //    //    Comm.Parameters["@CLIENT_DESCRIPTON"].Value = client_txt.Text;

    //    //    Comm.Parameters.Add("@PRICE", SqlDbType.Decimal);
    //    //    Comm.Parameters["@PRICE"].Value = price_edt.Text;

    //    //    Comm.Parameters.Add("@PAYMENT_TYPE", SqlDbType.Int);
    //    //    Comm.Parameters["@PAYMENT_TYPE"].Value = paytype_dll.SelectedValue;

    //    //    Comm.Parameters.Add("@CLIENT_CARD", SqlDbType.NVarChar);
    //    //    Comm.Parameters["@CLIENT_CARD"].Value = specialpayment_dll.SelectedValue;

    //    //    Comm.Parameters.Add("@PAYMENT_DELETED", SqlDbType.Int);
    //    //    Comm.Parameters["@PAYMENT_DELETED"].Value = 1;

    //    //    Comm.Parameters.Add("@PAYMENT_DATE", SqlDbType.DateTime);
    //    //    Comm.Parameters["@PAYMENT_DATE"].Value = DateTime.Now;

           

            

           

    //    //    Conn.Open();


    //    //    try
    //    //    { 
    //    //        ID=Convert.ToInt32(Comm.ExecuteScalar());
                
    //    //        if (specialpayment_dll.SelectedValue == "1")
    //    //    {
    //    //        decimal n = Convert.ToDecimal(kardbalance_edt.Text) - Convert.ToDecimal(price_edt.Text);
    //    //        Tranzactions_card(Convert.ToInt32(client_ddl.SelectedValue), n);
    //    //    }
    //    //     //   Comm.ExecuteNonQuery();

    //    //        Tranzaction_device(ID);

    //    //        Tranzaction_PACKAGES(ID);

    //    //        Tranzaction_games(ID);

    //    //    }
    //    //    catch (SqlException E)
    //    //    {
    //    //        price_edt.Text = E.ToString();
    //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left','Səhv aşkarlandi', ''); $(\"#close_btn\").click();} );</script>", false);
    //    //        return;
    //    //    }

    //    //    ObjectsGrid.DataBind();

    //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
    //    //}

    //}
    /*------------------------------------------------------------------------------*/

    /*------------------------------------------------------------------------------*/
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
                Comm.CommandText = @"UPDATE PAYMENT SET PAYMENT_DELETED=0 WHERE ID=@ID";

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


    protected void Packagedll_SelectedIndexChanged(object sender, EventArgs e)
    {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = packages_dll.SelectedValue;

                Comm.CommandText = @"SELECT ID,NAME,PRICE FROM PRICE_PACKAGES WHERE ID = @ID";

                Conn.Open();


                SqlDataReader reader = Comm.ExecuteReader();


                if (reader.Read())
                {
                    price_edt.Text = Convert.ToDecimal(reader["PRICE"]).ToString();
                    Total_price.Text = (Convert.ToInt32(Total_price.Text) + Convert.ToInt32(price_edt.Text)).ToString();
                }
                else
                {
                    Total_price.Text = (Convert.ToInt32(Total_price.Text) - Convert.ToInt32(price_edt.Text)).ToString();
                    price_edt.Text = "0";
                }
                reader.Close();
            }


        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }

    protected void package_dll_DataBound(object sender, EventArgs e)
    {
        packages_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void device_dll_DataBound(object sender, EventArgs e)
    {
        device_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void Clientdd_SelectedIndexChanged(object sender, EventArgs e)
    {
     
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();

                Comm.Connection = Conn;

                Comm.Parameters.Add("@ID", SqlDbType.Int);

                Comm.Parameters["@ID"].Value = client_ddl.SelectedValue;

                Comm.CommandText = @"SELECT ID,CLIENT_ID,BALANCE,CODE FROM CARD WHERE CLIENT_ID=@ID";

                Conn.Open();


                SqlDataReader reader = Comm.ExecuteReader();
                if (reader.Read())
                {
                    kardcode_edt.Text = reader["CODE"].ToString();
                   kardbalance_edt.Text = reader["BALANCE"].ToString();
                }
                else
                {
                    kardcode_edt.Text = "Tapılmadı ";
                    kardbalance_edt.Text = "Tapılmadı ";

                }

                reader.Close();

            }
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }
    protected void reject_ddl_DataBound(object sender, EventArgs e)
    {
        reject_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
    protected void client_ddl_DataBound(object sender, EventArgs e)
    {
        client_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
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
         
        package_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        package_dll_sql.SelectCommand = @"SELECT ID,NAME FROM PRICE_PACKAGES WHERE DEVICE_CATEGORY=" + category_dll.SelectedValue.ToString();

           devices_dll_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
           devices_dll_sql.SelectCommand = @"SELECT ID,D.NAME FROM DEVICES D WHERE DEVICE_CATEGORY_ID=" + category_dll.SelectedValue.ToString();

        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);


    }
    protected void category_dll_DataBound(object sender, EventArgs e)
    {
        category_dll.Items.Insert(0, new ListItem("Seçin", "0"));
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
        if (ModalCaption_lb.Text != "Məlumat")
        {
            games_lstbx.Items.Add(game_dll.SelectedItem);
            game_dll.SelectedIndex = 0;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);

    }
    protected void game_dll_DataBound(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            game_dll.Items.Insert(0, new ListItem("Seçin", "0"));
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$('#datatable').dataTable();} );</script>", false);
    }
     
    protected void status_dll_DataBound(object sender, EventArgs e)
    {
        if (ModalCaption_lb.Text != "Məlumat")
        {
            status_dll.Items.Insert(0, new ListItem("Seçin", "0"));
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
    protected void Save_status_btn_Click(object sender, EventArgs e)
    {
 
    }
    protected void Start_btn_Click(object sender, EventArgs e)
    {
        
    }
    protected void Statusdll_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}