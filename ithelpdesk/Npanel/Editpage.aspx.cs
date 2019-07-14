using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Npanel_Editpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void save_click(object sender, EventArgs e)
    {
        using (SqlConnection Conn = new SqlConnection())
        {
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBPath"].ConnectionString;
            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;

            Conn.Open();

            Comm.CommandText = "INSERT INTO ABBAS(SMALL_TEXT,BIG_TEXT,DATE) VALUES(@SMALL_TEXT,@BIG_TEXT,DATEADD(HOUR,11,GETDATE()))";

            Comm.Parameters.Add("@BIG_TEXT", SqlDbType.NVarChar);
            Comm.Parameters["@BIG_TEXT"].Value = big_text_edt.Value;

            Comm.Parameters.Add("@SMALL_TEXT", SqlDbType.NVarChar);
            Comm.Parameters["@SMALL_TEXT"].Value = small_text_edt.Value;
            try
            {
                Comm.ExecuteNonQuery();
            }
            catch (SqlException E)
            {
               
            }

        }
        small_text_edt.Value = null;
        big_text_edt.Value = null;
    }


    protected void team_save_click(object sender, EventArgs e)
    {
        ////////////////////////////1
        if (FileUpload1.HasFile)
        {
            if (!Directory.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/","1"))))
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Npanel/image/{0}/", "1")));

            if (File.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "1", "1"))))
                File.Delete(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "1", "1")));

            FileUpload1.SaveAs(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "1", "1")));

            if (FileUpload1.PostedFile != null)
            {
                // Check the extension of image  
                string extension = Path.GetExtension(FileUpload1.FileName);

                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                {
                    Stream strm = FileUpload1.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        // Print Original Size of file (Height or Width)   
                        int newWidth = 400; // New Width of Image in Pixel  
                        int newHeight = 350; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "1", "1"));
                        thumbImg.Save(targetPath, image.RawFormat);
                        // Print new Size of file (height or Width)  
                        //Show Image  
                    }
                }
            }
        }
        ////////////////////////////2

        if (FileUpload2.HasFile)
        {
            if (!Directory.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/", "2"))))
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Npanel/image/{0}/", "2")));

            if (File.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "2", "2"))))
                File.Delete(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "2", "2")));

            FileUpload2.SaveAs(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "2", "2")));

            if (FileUpload2.PostedFile != null)
            {
                // Check the extension of image  
                string extension = Path.GetExtension(FileUpload2.FileName);

                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                {
                    Stream strm = FileUpload2.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        // Print Original Size of file (Height or Width)   
                        int newWidth = 400; // New Width of Image in Pixel  
                        int newHeight = 350; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "2", "2"));
                        thumbImg.Save(targetPath, image.RawFormat);
                        // Print new Size of file (height or Width)  
                        //Show Image  
                    }
                }
            }
        }
        ////////////////////////////3

        if (FileUpload3.HasFile)
        {
            if (!Directory.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/", "3"))))
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Npanel/image/{0}/", "3")));

            if (File.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "3", "3"))))
                File.Delete(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "3", "3")));

            FileUpload3.SaveAs(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "3", "3")));

            if (FileUpload3.PostedFile != null)
            {
                // Check the extension of image  
                string extension = Path.GetExtension(FileUpload3.FileName);

                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                {
                    Stream strm = FileUpload3.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        // Print Original Size of file (Height or Width)   
                        int newWidth = 400; // New Width of Image in Pixel  
                        int newHeight = 350; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "3", "3"));
                        thumbImg.Save(targetPath, image.RawFormat);
                        // Print new Size of file (height or Width)  
                        //Show Image  
                    }
                }
            }
        }
        ////////////////////////////4

        if (FileUpload4.HasFile)
        {
            if (!Directory.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/", "4"))))
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Npanel/image/{0}/", "4")));

            if (File.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "4", "4"))))
                File.Delete(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "4", "4")));

            FileUpload4.SaveAs(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "4", "4")));

            if (FileUpload4.PostedFile != null)
            {
                // Check the extension of image  
                string extension = Path.GetExtension(FileUpload4.FileName);

                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                {
                    Stream strm = FileUpload4.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        // Print Original Size of file (Height or Width)   
                        int newWidth = 400; // New Width of Image in Pixel  
                        int newHeight = 350; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "4", "4"));
                        thumbImg.Save(targetPath, image.RawFormat);
                        // Print new Size of file (height or Width)  
                        //Show Image  
                    }
                }
            }
        }

        ////////////////////////////5

        if (FileUpload5.HasFile)
        {
            if (!Directory.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/", "5"))))
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Npanel/image/{0}/", "5")));

            if (File.Exists(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "5", "5"))))
                File.Delete(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "5", "5")));

            FileUpload5.SaveAs(Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "5", "5")));

            if (FileUpload5.PostedFile != null)
            {
                // Check the extension of image  
                string extension = Path.GetExtension(FileUpload5.FileName);

                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                {
                    Stream strm = FileUpload5.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        // Print Original Size of file (Height or Width)   
                        int newWidth = 400; // New Width of Image in Pixel  
                        int newHeight = 350; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = Server.MapPath(string.Format("~/Npanel/image/{0}/_{1}.jpg", "5", "5"));
                        thumbImg.Save(targetPath, image.RawFormat);
                        // Print new Size of file (height or Width)  
                        //Show Image  
                    }
                }
            }
        }

    }
}