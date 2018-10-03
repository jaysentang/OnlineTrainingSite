using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using TrainingSite;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text };
        var role = Role.SelectedValue;
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            user = manager.FindByName(UserName.Text);
            manager.AddToRole(user.Id, role);
            IdentityHelper.SignIn(manager, user, isPersistent: false);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}