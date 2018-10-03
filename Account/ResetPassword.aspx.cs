using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingSite;

public partial class Account_ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        //UserManager manager = new UserManager();//Startup.UserManagerFactory();
        var manager = Request.GetOwinContext().GetUserManager<UserManager>();
        ApplicationUser user = manager.FindByEmail(Email.Text);
        if (user != null)
        {
            //var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("TrainingSite");
            //manager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<IdentityUser>(provider.Create("PasswordReset")) { TokenLifespan = TimeSpan.FromMinutes(2) };
           // manager.UserTokenProvider = Startup.UserManagerFactory().UserTokenProvider;
            PasswordReset sendEmail = new PasswordReset(user.Id, Email.Text, manager.GeneratePasswordResetToken(user.Id));
            FailureText.Text = "A link has been sent to the email, please check.";
            ErrorMessage.Visible = true;
            message.Attributes["class"] = "text-success";
            Email.Text = "";
        }
        else
        {
            FailureText.Text = "Email "+Email.Text+" not found.";
            ErrorMessage.Visible = true;
        }
    }
}