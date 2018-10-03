using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using System;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingSite;

public partial class Account_ConfirmResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        Context.GetOwinContext().Authentication.SignOut();


        if (!this.IsPostBack)
        {

            //String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            String userId = !string.IsNullOrEmpty(Request.QueryString["UserId"]) ? Request.QueryString["UserId"] : Guid.Empty.ToString();
            
            //MySqlConnection connection = new MySqlConnection(connectionString);
            //   try
            //  {
            //  connection.Open();
            // String queryString = "DELETE FROM daifuku.aspnetactivation WHERE Code=@activationcode";
            // MySqlCommand cmd = new MySqlCommand(queryString, connection);
            // cmd.Parameters.AddWithValue("@activationcode", activationCode);

            var manager = Request.GetOwinContext().GetUserManager<UserManager>();
            
            ApplicationUser user = manager.FindById(userId);
            int view = 0;
            if (user != null && !string.IsNullOrEmpty(Request.QueryString["Token"]))
            {
                Email.Text = user.Email;
                ErrorMessage.Visible = false;
                FailureText.Text = "";
                view = 0;
            }
            else
            {
                ErrorMessage3.Visible = true;
                FailureText3.Text = "Invalid Token.";
                view = 2;
            }


            multi.ActiveViewIndex = view;

            //  }
            //   catch (Exception ex)
            //   {

            //  }
            //  finally
            //  {
            //     connection.Close();

            //    }
        }

    }




    protected void ResetBtn_Click(object sender, EventArgs e)
    {

        var token = Request.QueryString["Token"].Replace(" ","+");
        var manager = Request.GetOwinContext().GetUserManager<UserManager>();
        ApplicationUser user = manager.FindByEmail(Email.Text);
        IdentityResult result = manager.ResetPassword(user.Id, token, NewPass.Text);
        if (result.Succeeded)
        {
            /*
            var user = manager.FindById(User.Identity.GetUserId());
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
            */
            multi.ActiveViewIndex = 1;
            ErrorMessage2.Visible = true;
            FailureText2.Text = "Password Reset Successfully.";
        }
        else
        {
            AddErrors(result);
        }

    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
            ErrorMessage.Visible = true;
            FailureText.Text += error ;
        }
    }
}
           