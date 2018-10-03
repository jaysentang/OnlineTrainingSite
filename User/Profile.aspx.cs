using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingSite;

public partial class User_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ErrorMessage.Text = "";
            ErrorMessage.Visible = false;
            message.Attributes["class"] = "text-danger";

            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            if (authenticationManager.User.Identity.IsAuthenticated) { 
                string userid = authenticationManager.User.Identity.GetUserId();
                UserManager manager = new UserManager();
                ApplicationUser user = manager.FindById(userid);
               // Email.Text = user.Email;
                //Username.Text = user.UserName;
            }
        }
    }

    /*

        protected void EmailValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Email.Text.Length <= 0)
            {
                ErrorMessage.Text = "Empty email are not allowed.";
                ErrorMessage.Visible = true;
                Email.Focus();
                Session["Email"] = false;

            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(Email.Text, "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?") == false)
            {

                ErrorMessage.Text = "Email is invalid.";
                ErrorMessage.Visible = true;
                Email.Focus();
                Session["Email"] = false;

            }
            else {

                Session["Email"] = true;
            }

        }



        protected void changeEmail_Click(object sender, EventArgs e)
        {

            if (Session["Email"] != null && Convert.ToBoolean(Session["Email"]) != false)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                string userid = authenticationManager.User.Identity.GetUserId();
                var manager = new UserManager();
                ApplicationUser user = manager.FindById(userid);
                if (!Email.Text.Equals(user.Email))
                {
                    user.Email = Email.Text;
                    IdentityResult result = manager.Update(user);
                    if (result.Succeeded)
                    {
                        ErrorMessage.Text = "Email Updated.";
                        ErrorMessage.Visible = true;
                        message.Attributes["class"] = "text-success";
                        Email.Text = user.Email;
                    }
                    else
                    {
                        ErrorMessage.Text = result.Errors.ElementAt(0);
                        ErrorMessage.Visible = true;

                    }
                }
                else
                {
                    ErrorMessage.Text = "Email can't be re-use, please enter new email for the change.";
                    ErrorMessage.Visible = true;
                }

            }
            else
            {
                Session["Email"] = null;
            }
        }

        protected void changeUsername_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Convert.ToBoolean(Session["Username"]) != false)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                string userid = authenticationManager.User.Identity.GetUserId();
                var manager = new UserManager();
                ApplicationUser user = manager.FindById(userid);

                    user.UserName = Username.Text;
                    IdentityResult result = manager.Update(user);
                    if (result.Succeeded)
                    {
                        ErrorMessage.Text = "Username Updated.";
                        ErrorMessage.Visible = true;
                        message.Attributes["class"] = "text-success";
                        Username.Text = user.UserName;
                    }
                    else
                    {
                        ErrorMessage.Text = result.Errors.ElementAt(0);
                        ErrorMessage.Visible = true;

                    }


            }
            else
            {
                Session["Username"] = null;
            }

        }

        protected void UsernameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Username.Text.Length <= 0)
            {
                ErrorMessage.Text = "Empty Username are not allowed.";
                ErrorMessage.Visible = true;
                Username.Focus();
                Session["Username"] = false;

            }
            else
            {

                Session["Username"] = true;
            }
        }

        */

    protected void changePassword_Click(object sender, EventArgs e)
    {
        UserManager manager = new UserManager();
        IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
        if (result.Succeeded)
        {
            ErrorMessage.Text = "Password Changed.";
            ErrorMessage.Visible = true;
            message.Attributes["class"] = "text-success";
        }
        else
        {
            ErrorMessage.Text = result.Errors.ElementAt(0);
            ErrorMessage.Visible = true;
            message.Attributes["class"] = "text-danger";
            CurrentPassword.Focus();
        }
    }
}