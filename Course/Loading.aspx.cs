using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Linq;


public partial class Course_Loading : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        // ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        // sm.EnablePageMethods = true;

        //check section
        if (!string.IsNullOrEmpty(Request.QueryString["sectionid"]))
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            try {
                connection.Open();
                String queryString = "SELECT * FROM daifuku.coursesection WHERE Id=@sectionid and ProjectId=@projectid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("sectionid", Request.QueryString["sectionid"].ToString());
                cmd.Parameters.AddWithValue("projectid", Request.QueryString["projectid"].ToString());
                MySqlDataReader reader = cmd.ExecuteReader();
               
                if (!reader.HasRows)
                { //insert
                    reader.Close();
                    Response.Redirect("~/Error/CustomErrorPage.aspx");
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error/CustomErrorPage.aspx");
            }

            finally
            {
                connection.Close();
            }

        }
        else {
            Response.Redirect("~/Error/CustomErrorPage.aspx");
        }


        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        user.Value = authenticationManager.User.Identity.GetUserId();
      

        if (!string.IsNullOrEmpty(Request.QueryString["courseid"]))
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                String queryString = "SELECT * FROM daifuku.course WHERE Id=@courseid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@courseid", Request.QueryString["courseid"].ToString());
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();
            }

            if (table.Rows.Count == 0) {

                Response.Redirect("~/Error/CustomErrorPage.aspx");
            }

            foreach (DataRow datarow in table.Rows)
            {
                String path = datarow["Path"].ToString();
                Header.InnerText = datarow["Header"].ToString();
                Page.Title = datarow["Header"].ToString();

                cVideo2.Src = path;
                cVideo2.Attributes.Add("type", "video/webm");

                cVideo.Src = path;
                cVideo.Attributes.Add("type", "video/mp4");

                
            }

            //load comment here
        }
        else {

            Response.Redirect("~/Error/CustomErrorPage.aspx");

        }
    }

    
}