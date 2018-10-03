using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Re_activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                String queryString = "DELETE FROM daifuku.aspnetactivation WHERE Id=@userid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@userid", Request.QueryString["UserId"]);
                if (cmd.ExecuteNonQuery() >= 1)
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally {
                connection.Close();
            }

                GenerateEmail email = new GenerateEmail(Request.QueryString["UserId"], Request.QueryString["Email"]);
                ErrorMessage.Visible = true;
                FailureText.Text="Activation link has been sent to "+ Request.QueryString["Email"] + ".";
            
        }
    }
}