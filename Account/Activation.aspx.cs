using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using System;
using System.Web;
using System.Web.Configuration;

using TrainingSite;

public partial class Account_Activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        Context.GetOwinContext().Authentication.SignOut();

        if (!this.IsPostBack) {

            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
            String userId = !string.IsNullOrEmpty(Request.QueryString["UserId"]) ? Request.QueryString["UserId"] : Guid.Empty.ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                String queryString = "DELETE FROM daifuku.aspnetactivation WHERE Code=@activationcode";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@activationcode", activationCode);
              
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    
                    String queryString2 = "UPDATE daifuku.aspnetusers SET EmailConfirmed=@confirm WHERE Id=@userid";
                    cmd = new MySqlCommand(queryString2, connection);
                    cmd.Parameters.AddWithValue("@confirm", true);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    if (cmd.ExecuteNonQuery() >= 1)
                    {

                        FailureText.Text = "Activation successful.";
                        var manager = new UserManager();
                        ApplicationUser user = manager.FindById(userId);
                        if (user != null)
                        {
                            IdentityHelper.SignIn(manager, user, true);
                            Response.Redirect("~/Account/Manage.aspx");
                        }
            
                    }
                    else {
                        FailureText.Text = "Invalid User Id";
                        ErrorMessage.Visible = true;
                    }
                   

                }
                else
                {
                    FailureText.Text = "Invalid Activation Token.";
                    ErrorMessage.Visible = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();

            }
        }
    }
}