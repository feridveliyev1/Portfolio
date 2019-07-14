using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;

public partial class Createorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (HttpContext.Current.Session["LANG"] == null)
            HttpContext.Current.Session["LANG"] = "EN";
       
     
        if (!IsPostBack)
            Session["SERVICES"] = null;

     

        subject_txt.Attributes.Add("placeholder", HelpFunctions.Translate("createorder_subject_placeholder"));

        Deadline_edt.Attributes.Add("placeholder", HelpFunctions.Translate("createorder_connect_placeholder"));

     

        Subcategory();

    }

    struct pay_result_struct
    {
        public string success;
        public string orderId;
        public string forwardUrl;
    }

    protected void Subcategory()
     {
         int package_id = 0;

         using (SqlConnection Conn = new SqlConnection())
         {
             Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

             SqlCommand Comm = new SqlCommand();
             Comm.Connection = Conn;

             Comm.CommandText = @"SELECT ID,PACKAGE_ID,POINT FROM USER_PACKAGE WHERE  USING_CHECK=1 AND USER_ID=@USER_ID  ";

             Comm.Parameters.Add("@USER_ID",SqlDbType.Int);
             Comm.Parameters["@USER_ID"].Value=AuthCookieParse.UserID();

             Conn.Open();

             SqlDataReader Reader = Comm.ExecuteReader();

             

             if (Reader.Read())
                 if (Reader["PACKAGE_ID"] != DBNull.Value)
                 {
                     package_id = Convert.ToInt32(Reader["PACKAGE_ID"]);
                    
                     Max_point.Text = Reader["POINT"].ToString();

                     User_Package_id_txt.Text = Reader["ID"].ToString();
                 }

             Conn.Close();
             Reader.Close();
             

         }

         subcategory_sql.SelectParameters.Clear();
         subcategory_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;


         subcategory_sql.SelectCommand = string.Format(@"SELECT SB.ID,SB.{0}_NAME AS NAME,SB.PRICE,'VALUE'='',POINT FROM PACKAGE_SUBCATEGORY  PS
											LEFT JOIN SUB_CATEGORY SB ON PS.SUBCATEGORY_ID=SB.ID
											WHERE PS.PACKAGE_ID=@PACKAGE_ID", Session["LANG"].ToString());

         subcategory_sql.SelectParameters.Add("PACKAGE_ID","9");



     }

    protected void subcategory_databound(object sender, RepeaterItemEventArgs e)
    {
        if (Session["SERVICES"] != null)
        {
            ListBox lb = (ListBox)Session["SERVICES"];
            for (int i = 0; i < lb.Items.Count; i++)
            {
                if (((HiddenField)e.Item.FindControl("check_hf")).Value == lb.Items[i].Value)
                    ((CheckBox)e.Item.FindControl("Check_chk")).Checked = true;
            }
        }
    }

    protected void Add_items_btn_Click(object sender, EventArgs e)
    {
        if (text_hf.Value !="1") return;

        bool check = false;
        for (int i = 0; i < Selected_lbx.Items.Count; i++)
        {
            if (Selected_lbx.Items[i].Text == Value_hf.Value)
            {
                check = true;
                break;
            }
        }
        if (check)
        {
            Selected_lbx.Items.Remove(Value_hf.Value);
           total_lbl.Text = (Convert.ToInt32(total_lbl.Text) - Convert.ToInt32(price_hf.Value)).ToString();

            ListBox lb = (ListBox)Session["SERVICES"];
            lb.Items.Remove(subcategory_id.Value);
        }
        else
        {
            Selected_lbx.Items.Add(Value_hf.Value );
            total_lbl.Text = (Convert.ToInt32(total_lbl.Text) + Convert.ToInt32(price_hf.Value)).ToString();

            if (Session["SERVICES"] == null)
            {
                ListBox lb = new ListBox();
                lb.Items.Add(subcategory_id.Value);

                Session["SERVICES"] = lb;
            }
            else
            {
                ListBox lb = (ListBox)Session["SERVICES"];
                lb.Items.Add(subcategory_id.Value);

                Session["SERVICES"] = lb;
            }
        }
        text_hf.Value = "0";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();} );</script>", false);
    }

    protected void Check_check(object sender, EventArgs e)
    {
        text_hf.Value = "1";
    }

    protected void Pay_btn_click(object sender, EventArgs e)
    {
       if (Selected_lbx.Items.Count < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Choose Services" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
            return;
        }
        else if (subject_txt.Value.Length < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Enter Subject" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
            return;
        }
        else if (Deadline_edt.Text.Length < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Enter Date" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
            return;
        }

        else if(DateTime.ParseExact(Deadline_edt.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture)<DateTime.Now.Date)
        {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Choose correct Date" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
               return;

        }
       else if (Convert.ToInt32(total_lbl.Text)>Convert.ToInt32(Max_point.Text))
       {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Max Point:"+Max_point.Text + " ', ''); $(\"#close_btn\").click();} );</script>", false);
           return;
       }
       
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Conn.Open();

//            Comm.CommandText = @"INSERT INTO PAYMENT_TRANZACTION(USER_ID,CREATE_DATE) 
//                                               VALUES(@USER_ID,GETDATE());SELECT SCOPE_IDENTITY()";

//            Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
//            Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

//            int TranzactionId = 0;

//            TranzactionId = Convert.ToInt32(Comm.ExecuteScalar());

//            //---------------------------------------------------------------------------------------------------------------------------------------
//            string address = "https://www.e-pul.az/epay/pay_via_epul/register_transaction?username=frazexHP&password=aFYGL6nG&amount={amount}&description=partner%20payment&transactionId={transaction_id}&backUrl=http://ithelpdesk.albuket.az/createorder.aspx&errorUrl=http://ithelpdesk.albuket.az/createorder.aspx".Replace("{amount}", Math.Ceiling(0.12 * 100).ToString()).Replace("{transaction_id}", TranzactionId.ToString());

//            System.Net.WebRequest req = System.Net.WebRequest.Create(address);

//            System.Net.WebResponse resp = req.GetResponse();
//            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
//            string result = sr.ReadToEnd().Trim();

//            pay_result_struct pay_result = JsonConvert.DeserializeObject<pay_result_struct>(result);
//            //---------------------------------------------------------------------------------------------------------------------------------------

//            if (pay_result.success == "true")
//            {
                Comm.Parameters.Clear();

                //Запись данных о ордере в базу
                //---------------------------------------------------------------------------------------------------------------------------------------
                Comm.CommandText = @"INSERT INTO ORDERS(SUBJECT,TIME_TO_CONNECT,DESCRIPTION,POINT,VALYUTA_ID,CREATE_BY,STATUS_TYPE,TEAMVIEWER_CODE,TEAMVIEWER_LOGIN) 
                                               VALUES(@SUBJECT,convert(date, convert(varchar(30), @TIME_TO_CONNECT), 104),@DESCRIPTION,@POINT_TOTAL,1,@CREATE_BY,1,@TEAMVIEWER_CODE,@TEAMVIEWER_LOGIN);
                                                UPDATE USER_PACKAGE SET POINT=@POINT WHERE ID=@UP_ID;SELECT SCOPE_IDENTITY()";

                Comm.Parameters.Add("@SUBJECT", SqlDbType.NVarChar);
                Comm.Parameters["@SUBJECT"].Value = subject_txt.Value;

                Comm.Parameters.Add("@TIME_TO_CONNECT", SqlDbType.VarChar);
                Comm.Parameters["@TIME_TO_CONNECT"].Value = Deadline_edt.Text;
       
                Comm.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar);
                Comm.Parameters["@DESCRIPTION"].Value = Description_txt.Text;

                Comm.Parameters.Add("@POINT_TOTAL", SqlDbType.Int);
                Comm.Parameters["@POINT_TOTAL"].Value = total_lbl.Text;

                Comm.Parameters.Add("@POINT", SqlDbType.Int);
                Comm.Parameters["@POINT"].Value = Convert.ToInt32(Max_point.Text) - Convert.ToInt32(total_lbl.Text);

                Comm.Parameters.Add("@CREATE_BY", SqlDbType.Int);
                Comm.Parameters["@CREATE_BY"].Value = AuthCookieParse.UserID();

                Comm.Parameters.Add("@UP_ID", SqlDbType.Int);
                Comm.Parameters["@UP_ID"].Value = User_Package_id_txt.Text;

                Comm.Parameters.Add("@TEAMVIEWER_CODE", SqlDbType.NVarChar);
                Comm.Parameters["@TEAMVIEWER_CODE"].Value = Teamviwer_txt.Text;

                Comm.Parameters.Add("@TEAMVIEWER_LOGIN", SqlDbType.NVarChar);
                Comm.Parameters["@TEAMVIEWER_LOGIN"].Value = Login_teamviewer_txt.Text;

                int order_id = 0;

                try
                {
                    order_id = Convert.ToInt32(Comm.ExecuteScalar());
                }
                catch (SqlException E)
                {
                    subject_txt.Value = e.ToString();
                    return;
                }

                Comm.Parameters.Clear();

                Comm.CommandText = @"INSERT INTO SERVICES(ORDER_ID,SUBCATEGORY_ID) VALUES(@ORDER_ID,@SUBCATEGORY_ID)";

                Comm.Parameters.Add("@ORDER_ID", SqlDbType.Int);
                Comm.Parameters["@ORDER_ID"].Value = order_id;

                Comm.Parameters.Add("@SUBCATEGORY_ID", SqlDbType.Int);

                ListBox lb = (ListBox)Session["SERVICES"];
                for (int i = 0; i < lb.Items.Count; i++)
                {
                    Comm.Parameters["@SUBCATEGORY_ID"].Value = lb.Items[i].Value;
                    Comm.ExecuteNonQuery();

                }

                Comm.Parameters.Clear();

                //Comm.CommandText = @"UPDATE PAYMENT_TRANZACTION SET ORDER_ID=@ORDER_ID,PAY_RESULT=@PAY_RESULT WHERE ID=@ID";

                //Comm.Parameters.Add("@PAY_RESULT", SqlDbType.NVarChar);
                //Comm.Parameters["@PAY_RESULT"].Value ="Payed";

                //Comm.Parameters.Add("@ORDER_ID", SqlDbType.NVarChar);
                //Comm.Parameters["@ORDER_ID"].Value = pay_result.orderId.ToString();

                //Comm.Parameters.Add("@ID", SqlDbType.Int);
                //Comm.Parameters["@ID"].Value = TranzactionId;

                //Comm.ExecuteNonQuery();

                ////---------------------------------------------------------------------------------------------------------------------------------------

                //Response.Redirect(pay_result.forwardUrl);

           // }
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');});</script>", false);
        Response.Redirect("myorders.aspx");

    }

    protected void reset(object sender, EventArgs e)
    {
        Session["SERVICES"] = null;
        Selected_lbx.Items.Clear();
        total_lbl.Text="0";
     
        Repeater1.DataBind();
        Repeater2.DataBind();
      
    }
}