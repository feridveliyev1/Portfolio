using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.Services.Protocols;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (AuthCookieParse.UserStatus() == "1")
        {
            users_lb.Visible = true;
            report_lb.Visible = true;
        }
        else
        {
            users_lb.Visible = false;
            report_lb.Visible = false;
        }
    }

    protected void SignOut_btn_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("default.aspx");
    }
}
