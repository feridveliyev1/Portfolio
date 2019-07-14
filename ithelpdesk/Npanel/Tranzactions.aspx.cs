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

public partial class Tranzactions : System.Web.UI.Page
{


    public string Package_type_ = "";

    public string Senior_Packages = "";

    public string Junior_Packages = "";

    public string Payment_type = "";

      void Chart_fill()
{
       using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();


                //------Package type--------

                Comm.CommandText = @"SELECT NAME,USED_COUNT=(SELECT COUNT(UP.ID)FROM  USER_PACKAGE UP,PACKAGE P  WHERE UP.PACKAGE_ID=P.ID AND P.TYPE_ID=PT.ID) FROM PACKAGE_TYPE PT";

                string Package_type_Item = "['{0} ( {1} )', {1}],";

                DataTable dt = new DataTable();

                SqlDataReader Reader = Comm.ExecuteReader();

                dt.Load(Reader);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Package_type_+=string.Format(Package_type_Item,dt.Rows[i]["NAME"].ToString(),dt.Rows[i]["USED_COUNT"].ToString());
                }

                Package_type_ = Package_type_.Remove(Package_type_.Length - 1, 1);
                //-----------------------------------------------


                //------Package Senior--------

                Comm.CommandText = @"SELECT ID,NAME,USED_COUNT=(SELECT COUNT(UP.ID) FROM USER_PACKAGE UP WHERE UP.PACKAGE_ID=P.ID) FROM PACKAGE P WHERE P.TYPE_ID=@TYPE_ID";

                Comm.Parameters.Add("@TYPE_ID", SqlDbType.Int);
                Comm.Parameters["@TYPE_ID"].Value = 2;

               Package_type_Item = "['{0} ( {1} )', {1}],";

               Reader = Comm.ExecuteReader();
               dt = new DataTable();

                dt.Load(Reader);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Senior_Packages += string.Format(Package_type_Item, dt.Rows[i]["NAME"].ToString(), dt.Rows[i]["USED_COUNT"].ToString());
                }

               
                Senior_Packages = Senior_Packages.Remove(Senior_Packages.Length - 1, 1);
                //-----------------------------------------------

                //------Package Junior--------
                Comm.Parameters.Clear();
                Comm.CommandText = @"SELECT ID,NAME,USED_COUNT=(SELECT COUNT(UP.ID) FROM USER_PACKAGE UP WHERE UP.PACKAGE_ID=P.ID) FROM PACKAGE P WHERE P.TYPE_ID=@TYPE_ID";

                Comm.Parameters.Add("@TYPE_ID", SqlDbType.Int);
                Comm.Parameters["@TYPE_ID"].Value = 1;

                Package_type_Item = "['{0} ( {1} )', {1}],";

                Reader = Comm.ExecuteReader();
                dt = new DataTable();

                dt.Load(Reader);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Junior_Packages += string.Format(Package_type_Item, dt.Rows[i]["NAME"].ToString(), dt.Rows[i]["USED_COUNT"].ToString());
                }


                Junior_Packages = Junior_Packages.Remove(Junior_Packages.Length - 1, 1);
                //-----------------------------------------------

                //------Package Junior--------
                Comm.Parameters.Clear();
                Comm.CommandText = @"SELECT ID,PT.NAME,USED_COUNT=(SELECT COUNT(T.ID)  FROM TRANZACTIONS T WHERE T.PAYMENT_TYPE=PT.ID) FROM PAYMENT_TYPE PT";

                Package_type_Item = "['{0} ( {1} )', {1}],";

                Reader = Comm.ExecuteReader();
                dt = new DataTable();

                dt.Load(Reader);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Payment_type += string.Format(Package_type_Item, dt.Rows[i]["NAME"].ToString(), dt.Rows[i]["USED_COUNT"].ToString());
                }

                Payment_type = Payment_type.Remove(Payment_type.Length - 1, 1);
                //-----------------------------------------------

}
}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthCookieParse.UserStatus() != ConfigurationManager.AppSettings["SuperAdmin"])
        {
            Response.Redirect("Default.aspx");
            return;
        }


        Amount_txt.Text = "0";

        if (!IsPostBack)
        {
            //----- Load elements----------------
            username_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            username_sql.SelectCommand = @"SELECT ID,(FNAME+' '+LNAME) NAME FROM VENDOR_USERS WHERE ACTIVE=1";

            Package_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            Package_type_sql.SelectCommand = @"SELECT ID,NAME FROM PACKAGE_TYPE";

            payment_type_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            payment_type_sql.SelectCommand = @"SELECT ID,NAME FROM PAYMENT_TYPE";

            Chart_fill();
            //----------------------------------
        }
    }

   

    protected void Search_btn_Click(object sender, EventArgs e)
    {
        Amount_txt.Text = "0";
        
        report_sql.SelectParameters.Clear();

        report_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        report_sql.SelectCommand = "TRANZACTIONS_SP";
        report_sql.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;

        if (Username_ddl.SelectedIndex == 0)
            report_sql.SelectParameters.Add("USER_ID", "0");
        else
            report_sql.SelectParameters.Add("USER_ID", Username_ddl.SelectedValue);

        if (Package_type_ddl.SelectedIndex == 0)
            report_sql.SelectParameters.Add("PACKAGE_TYPE", "0");
        else
            report_sql.SelectParameters.Add("PACKAGE_TYPE", Package_type_ddl.SelectedValue);

        if (Package_ddl.SelectedIndex == 0)
            report_sql.SelectParameters.Add("PACKAGE", "0");
        else
            report_sql.SelectParameters.Add("PACKAGE", Package_ddl.SelectedValue);

        if (Start_edt.Text.Length == 0)
            report_sql.SelectParameters.Add("BEGIN_DATE", "2012-12-12");
        else
        {
            report_sql.SelectParameters.Add("BEGIN_DATE", DateTime.ParseExact(Start_edt.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString());
        }

        if (Deadline_edt.Text.Length == 0)
            report_sql.SelectParameters.Add("END_DATE", "2012-12-12");
        else
            report_sql.SelectParameters.Add("END_DATE", DateTime.ParseExact(Deadline_edt.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString());

        if (payment_ddl.SelectedIndex == 0)
            report_sql.SelectParameters.Add("PAYMENT_TYPE", "0");
        else
            report_sql.SelectParameters.Add("PAYMENT_TYPE", payment_ddl.SelectedValue);

        ObjectsGrid.DataBind();

        string Result_count = ObjectsGrid.Items.Count.ToString();

       ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();$.Notification.notify('success','top left','Result : "+Result_count+"', '');} );</script>", false);
    }

    protected void LoadInfo_btn_Click(object sender, EventArgs e)
    {
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();} );</script>", false);
    }

    //-------------------------------------------------------------
    protected void username_DataBound(object sender, EventArgs e)
    {
        Username_ddl.Items.Insert(0, new ListItem("Choose"));
    }

    protected void ObjectsGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((HiddenField)e.Item.FindControl("Amount_hf")).Value.Length > 0)
            Amount_txt.Text = (Convert.ToUInt32(Amount_txt.Text) + Convert.ToInt32(((HiddenField)e.Item.FindControl("Amount_hf")).Value)).ToString();
    }

    protected void Operator_DataBound(object sender, EventArgs e)
    {
        //Operator_ddl.Items.Insert(0, new ListItem("Choose"));
    }

    protected void Package_type_ddl_DataBound(object sender, EventArgs e)
    {
        Package_type_ddl.Items.Insert(0, new ListItem("Choose", "0"));
    }

    protected void package_type_selectedindex(object sender, EventArgs e)
    {
        Package_sql.SelectParameters.Clear();

        Package_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        Package_sql.SelectCommand = @"SELECT ID,NAME FROM PACKAGE WHERE TYPE_ID=@TYPE";

        Package_sql.SelectParameters.Add("TYPE", Package_type_ddl.SelectedValue);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type=\"text/javascript\">$(document).ready(function() {init();});</script>", false);
    }

    protected void Package_ddl_DataBound(object sender, EventArgs e)
    {
        Package_ddl.Items.Insert(0, new ListItem("Choose", "0"));
    }
    protected void Payment_type_ddl_DataBound(object sender, EventArgs e)
    {
        payment_ddl.Items.Insert(0, new ListItem("Seçin", "0"));
    }
    //-------------------------------------------------------------
}