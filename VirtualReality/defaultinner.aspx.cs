using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public partial class defaultinner : System.Web.UI.Page
{
    public decimal Man = 0;
    public decimal Woman = 0;

    public decimal Costumer = 0;
    public decimal Business = 0;

    public decimal from10to18=0;
    public decimal from18to25 = 0;
    public decimal from25to40 = 0;
    public decimal from10to18Count = 0;
    public decimal from18to25Count = 0;
    public decimal from25to40Count = 0;

    public string Gender = "";

    public string Source = "";

    public string Packages = "";

    public string Category = "";

    public string Device = "";

    public string Games = "";

    public int[] massiv;


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
       if(AuthCookieParse.UserStatus()=="1")
        {
            Session["adminsession"] = "okay";
        }

        if (!IsPostBack)
        {
            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;

                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;

                Conn.Open();
                //------Gender--------
                Comm.CommandText = @" SELECT COUNT(ID) FROM CLIENTS WHERE GENDER=@G_ID";//if G_ID=1 then man and G_ID=2 then woman

                Comm.Parameters.Add("@G_ID",SqlDbType.Int);
                Comm.Parameters["@G_ID"].Value = 1;//MAN Count

                Man = Convert.ToInt32(Comm.ExecuteScalar());

                Comm.Parameters["@G_ID"].Value = 2;//WOMAN Count

                Woman=Convert.ToInt32(Comm.ExecuteScalar());

                string GenderTestItem = "['{0} ( {1} )', {1}],";

                Gender += string.Format(GenderTestItem, "Kishi", Man.ToString());

                Gender += string.Format(GenderTestItem, "Qadin", Woman.ToString());

                Gender = Gender.Remove(Gender.Length - 1, 1);
                //-----------------------------------------------

                //---------Source
                Comm.CommandText = @"SELECT COUNT(ID) FROM CLIENTS WHERE SOURCE_TYPE=@S_ID";//if S_ID=1 then Costumer and S_ID=2 then Business

                Comm.Parameters.Add("@S_ID", SqlDbType.Int);
                Comm.Parameters["@S_ID"].Value = 1;

                Costumer = Convert.ToInt32(Comm.ExecuteScalar());

                Comm.Parameters["@S_ID"].Value = 2;

                Business = Convert.ToInt32(Comm.ExecuteScalar());

                string SourceItem = "['{0} ( {1} )', {1}],";

                Source += string.Format(SourceItem, "Küçə", Costumer.ToString());

                Source += string.Format(SourceItem, "Biznes", Business.ToString());

                Source = Source.Remove(Source.Length - 1, 1);
                //-----------------------------------------------

                //----------------AGE interval-----------------

                Comm.CommandText=@" SELECT COUNT(ID) FROM CLIENTS WHERE AGE_INTERVAL=@AGE_id"; //if age_id=1 --> 10-18 & age_id=2--> 18-25 & age_id=3 25-40  

                Comm.Parameters.Add("@AGE_ID", SqlDbType.Int);
                Comm.Parameters["@AGE_ID"].Value=1;

                from10to18 = Convert.ToInt32(Comm.ExecuteScalar());
                from10to18Count = from10to18;

                Comm.Parameters["@AGE_ID"].Value = 2;

                from18to25 = Convert.ToInt32(Comm.ExecuteScalar());
                from18to25Count = from18to25;

                Comm.Parameters["@AGE_ID"].Value = 3;

                from25to40 = Convert.ToInt32(Comm.ExecuteScalar());
                from25to40Count = from25to40;
                //----------------------------------------------------------------------------------------------------

                //----------------------PACKAGES---------------------------------------

                Comm.CommandText = @"SELECT  PP.ID,PP.NAME AS 'NAME', 
                                                           PACKAGESCOUNT = (SELECT COUNT(TP.Id) FROM TRANZACTIONS_PACKAGES TP  WHERE TP.PACKAGES_ID = PP.Id)
                                                      FROM PRICE_PACKAGES PP ";
                SqlDataReader reader = Comm.ExecuteReader();

                string PackagesItem = "['{0} ( {1} )', {1}],";

                while (reader.Read())
                {
                    Packages+=string.Format(PackagesItem,reader["NAME"].ToString(),reader["PACKAGESCOUNT"].ToString());
                    
                }
                reader.Close();
                Packages = Packages.Remove(Packages.Length - 1, 1);

                //-----------------------------------------------

                //----------------------CATEGORY---------------------------------------

                Comm.CommandText = @"      SELECT  DC.ID,DC.NAME as 'NAME', 
                                      CATEGORYCOUNT = (SELECT COUNT(TC.Id) FROM  TRANZACTIONS_CATEGORY  TC WHERE TC.DAVICE_CATEGORY= DC.Id)
                                      FROM DEVICE_CATEGORY DC  ";
           reader = Comm.ExecuteReader();

                string CategoryItem = "['{0} ( {1} )', {1}],";

                while (reader.Read())
                {
                    Category += string.Format(CategoryItem, reader["NAME"].ToString(), reader["CATEGORYCOUNT"].ToString());

                }
                Category = Category.Remove(Category.Length - 1, 1);
                reader.Close();

                //-----------------------------------------------

                //----------------------DEVICE---------------------------------------

                Comm.CommandText = @"   SELECT  D.ID,D.NAME, 
                                                  DEVICECOUNT = (SELECT COUNT(TD.DEVICE_ID) FROM  TRANZACTIONS_DEVICE  TD WHERE TD.DEVICE_ID=D.Id)
                                              FROM DEVICES D   ";
                reader = Comm.ExecuteReader();

                string DeviceItem = "['{0} ( {1} )', {1}],";

                while (reader.Read())
                {
                    Device += string.Format(DeviceItem, reader["NAME"].ToString(), reader["DEVICECOUNT"].ToString());

                }
                Device = Device.Remove(Device.Length - 1, 1);
                reader.Close();

                //-----------------------------------------------

                //----------------------GAMES---------------------------------------

                Comm.CommandText = @"   	  SELECT  G.NAME as 'NAME', 
                                      GAMESCOUNT = (SELECT COUNT(TG.GAME_ID) FROM  TRANZACTIONS_GAME TG WHERE TG.GAME_ID= G.NAME)
                                      FROM GAMES G  ";
                reader = Comm.ExecuteReader();

                string GameItem = "['{0} ( {1} )', {1}],";

                while (reader.Read())
                {
                    Games += string.Format(GameItem, reader["NAME"].ToString(), reader["GAMESCOUNT"].ToString());

                }
                Games = Games.Remove(Games.Length - 1, 1);

                //-----------------------------------------------
             


                










            }




        }








    }

    public struct Sport_member_info
    {
        public string label { get; set; }
        public string value { get; set; }
    }

}