using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;

public partial class Clients_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void source_ddl_DataBound(object sender, EventArgs e)
    {
        source_category_ddl.Items.Insert(0, new ListItem("Seçin", "-1"));
    }
    protected void sourche_type_click(object sender, EventArgs e)
    {
        source_category_sql.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
        switch (sourche_type.SelectedIndex)
        {
            case 1:
                source_category_sql.SelectCommand = @"SELECT ID,NAME FROM COSTUMER_SOURCE";
                break;
            case 2:
                source_category_sql.SelectCommand = @"SELECT ID,NAME FROM BUSINESS_PARTNERS";
                break;

        }
      
        
    }
}