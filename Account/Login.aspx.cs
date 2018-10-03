using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingSite;
using System.Text.RegularExpressions;
using System.Linq;

public partial class Account_Login : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //check current cookie whether contain authenticated user
     
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        if (authenticationManager.User.Identity.IsAuthenticated) {
            if (authenticationManager.User.IsInRole("Administrator"))
            {

                IdentityHelper.RedirectUrl("~/Admin/Dashboard", Response);
            }
            else {
                IdentityHelper.RedirectUrl("~/Course/CourseContent", Response);
            }
        }
      
      
    }

    protected void LogIn(object sender, EventArgs e)
    {
        this.Page.Validate("login");
       var collection =  this.Page.Validators;

        if (this.Page.IsValid)
        {
            // Validate the user password

            if (Email.Text.Length <= 0) {
                FailureText.Text = "Username is required.";
                ErrorMessage.Visible = true;
                return;
            }
            /*
            if (!Regex.IsMatch(Email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {

                FailureText.Text = "Email is invalid.";
                ErrorMessage.Visible = true;
                return;
            }
            */
            if (Password.Text.Length <=0) {

                FailureText.Text = "Password is required.";
                ErrorMessage.Visible = true;
                return;
            }

          
            
            

            var manager = new UserManager();


            // ApplicationUser user = manager.Find(UserName.Text, Password.Text);
            //Verify email
            ApplicationUser user = manager.FindByName(Email.Text);
                //manager.FindByEmail(Email.Text);
                                    
            if (user != null)
            {
               // if (user.EmailConfirmed)
              //  {
                    if (!user.LockoutEnabled)
                    {
                        if (manager.CheckPassword(user, Password.Text))
                        {
                            IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                            using (daifukuEntities db = new daifukuEntities()) {
                            aspnetuser loginuser = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.UserName == Email.Text);
                            loginuser.LastLoginDate = DateTime.Now;
                            db.Entry(loginuser).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        }
                        else
                        {
                            FailureText.Text = "Invalid Username or Password";
                            ErrorMessage.Visible = true;
                        }
                    }
                    else {

                        FailureText.Text = "This account is temporary ban.";
                        ErrorMessage.Visible = true;
                    }
                //   }
                /* else {
                     FailureText.Text = "Email not active yet.";
                     re_active.NavigateUrl = "Re_activation.aspx?Email=" + user.Email + "&UserId=" + user.Id;
                     re_active.Visible = true;
                     ErrorMessage.Visible = true;
                 }*/
                /*
                var userRole = manager.GetRoles(user.Id);
            if (userRole[0].Equals("Administrator"))
            {
                Response.Redirect("~/Admin/Dashboard.apsx");
            }
            else
            {
                Response.Redirect("~/User/Dashboard.aspx");
            }*/
            }
            else
            {
                FailureText.Text = "Invalid Username or Password";
                ErrorMessage.Visible = true;
            }

        }
        else {
            foreach (BaseValidator validator in this.Page.GetValidators("login"))
            {
                if (!validator.IsValid)
                {
                    
                }
            }
            
        }
       

    }
}