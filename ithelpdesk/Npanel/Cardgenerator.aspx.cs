using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Cardgenerator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (AuthCookieParse.UserStatus() != ConfigurationManager.AppSettings["SuperAdmin"])
        {
            Response.Redirect("Default.aspx");
            return;
        }

        category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        category_sql.SelectCommand = @"SELECT CC.ID,PT.NAME TYPE,P.NAME PACKAGE,CC.CODE FROM CARD_CODES CC,PACKAGE_TYPE PT,PACKAGE P
        WHERE CC.PACKAGE_TYPE=PT.ID AND CC.PACKAGE_ID=P.ID AND CC.ACTIVE=1";

        Package_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Package_type_sql.SelectCommand = @"SELECT ID,NAME FROM PACKAGE_TYPE";

    
        
    }

    protected void Package_pay(object sender, EventArgs e)
    {

        if (AuthCookieParse.UserID() != null && Convert.ToInt32(AuthCookieParse.UserID()) < 1)
            Response.Redirect("Default.aspx");

        else
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();

                Comm.Parameters.Add("@USER_ID", SqlDbType.Int);
                Comm.Parameters["@USER_ID"].Value = AuthCookieParse.UserID();

                Comm.CommandText = @"SELECT ACTIVE FROM VENDOR_USERS WHERE ID=@USER_ID";

                SqlDataReader Reader = Comm.ExecuteReader();

                Reader.Close();

                bool active = false;

                if (Reader.Read())
                    active = Convert.ToBoolean(Reader["ACTIVE"]);

                if (!active)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {$.Notification.notify('error','top left', '" + "Packages for active account" + " ', ''); $(\"#close_btn\").click();} );</script>", false);
                }
                else
                {
                    SqlCommand cmd_sp = new SqlCommand("SP_PAY_PACKAGE", Conn);


                    cmd_sp.CommandType = CommandType.StoredProcedure;


                    cmd_sp.Parameters.Add(new SqlParameter("@USER_ID", 22));

                    cmd_sp.Parameters.Add(new SqlParameter("@PACKAGE_ID", 6));

                    cmd_sp.ExecuteNonQuery();


                    Comm.CommandText = @"INSERT INTO USER_PACKAGE (USER_ID,PACKAGE_ID,USING_CHECK,PAY_DATE) VALUES(@USER_ID,@PACKAGE_ID,0,GETDATE())";



                }





            }
        }





    }

    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {
        Package_type_ddl.SelectedIndex = 0;
        Package_ddl.Items.Clear();
        count_txt.Text = "0";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();});</script>", false);
    }

    public string card_generator(string type )
    {
        byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
        byte[] key = Guid.NewGuid().ToByteArray();

        decimal code1 = 0;
        decimal code2 = 0;

        Random q = new Random();
        code1 = q.Next(1000000, 9000000);
        code2 = q.Next(1000000, 9000000);
        string Code_string = type+code1.ToString() + code2.ToString();
        return Code_string;
    }

    protected void Create_cards(object sender, EventArgs e)
    {
        if (Package_type_ddl.SelectedIndex<1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Choose Package type" + " ', '');} );</script>", false);
            return;
        }
        else if (Package_ddl.SelectedIndex < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Choose Package " + " ', '');} );</script>", false);
            return;
        }
        else if (Convert.ToInt32(count_txt.Text) < 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('error','top left', '" + "Choose Card count " + " ', '');} );</script>", false);
            return;
        }
        if (AuthCookieParse.UserID() != null && Convert.ToInt32(AuthCookieParse.UserID()) < 1)
            Response.Redirect("Default.aspx");

        else
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();

                Comm.Parameters.Add("@CODE", SqlDbType.NVarChar);
               
              int count=0;
                string random_text = "";

                string type = Package_type_ddl.SelectedItem.Text.Substring(0, 1);

                if (Package_ddl.SelectedValue == "4" || Package_ddl.SelectedValue=="7")
                {
                    type += "H";
                }
                else if (Package_ddl.SelectedValue == "5" || Package_ddl.SelectedValue == "8")
                {
                    type += "W";
                }
                else if (Package_ddl.SelectedValue == "6" || Package_ddl.SelectedValue == "9")
                {
                    type += "M";
                }


                while (Convert.ToInt32(count_txt.Text) > count)
                {
                    
                    
                    random_text = card_generator(type);

                    Comm.Parameters["@CODE"].Value = random_text;

                    Comm.CommandText = @"SELECT COUNT(*) FROM CARD_CODES WHERE CODE=@CODE";

                    SqlCommand cmd_sp = new SqlCommand("CARD_CREATE", Conn);

                    cmd_sp.CommandType = CommandType.StoredProcedure;

                    cmd_sp.Parameters.Add(new SqlParameter("@TYPE_ID", Package_type_ddl.SelectedValue));

                    cmd_sp.Parameters.Add(new SqlParameter("@PACKAGE_ID", Package_ddl.SelectedValue));

                    if(Convert.ToInt32(Comm.ExecuteScalar())<1)
                    {

                    cmd_sp.Parameters.Add(new SqlParameter("@CODE", random_text));
                       
                      try 
	                        {	        
                            cmd_sp.ExecuteNonQuery();
                            count+=1;
	                        }
	                  catch (SqlException t)
	                        {
	                        }

                    }
                }

                }
            }

            ObjectsGrid.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Təsdiq edildi', '');$(\"#close_btn\").click();});</script>", false);
    }

    protected void ObjectsGrid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DELETE_card")
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Comm.CommandText = @"DELETE FROM CARD_CODES WHERE ID = @ID";

                Comm.Parameters.Add("@ID", SqlDbType.Int);
                Comm.Parameters["@ID"].Value = e.CommandArgument;

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

    protected void ObjectsGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton l = (LinkButton)e.Item.FindControl("Delete_btn");
        l.Attributes.Add("onclick", "javascript:return confirm('Əminsiniz?')");
        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(l);
         
     
        

    }

    protected void Package_type_ddl_DataBound(object sender, EventArgs e)
    {
        Package_type_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }

    protected void package_type_selectedindex(object sender, EventArgs e)
    {
        Package_sql.SelectParameters.Clear();
  
        Package_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Package_sql.SelectCommand = @"SELECT ID,NAME FROM PACKAGE WHERE TYPE_ID=@TYPE";

        Package_sql.SelectParameters.Add("TYPE", Package_type_ddl.SelectedValue);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();} );</script>", false);

    }

    protected void Package_ddl_DataBound(object sender, EventArgs e)
    {
        Package_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }
}