using System;
using System.Linq;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using TrainingSite;

public partial class Admin_Register : Page
{
    public Boolean registerResult = new Boolean();
    protected void Page_Load(object sender, EventArgs e)
    {
           
    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = UserName.Text, Email = Email.Text, EmailConfirmed=true};
        
        var role = Role.SelectedValue;
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            registerResult = result.Succeeded;
            user = manager.FindByName(UserName.Text);
            manager.AddToRole(user.Id, role);
            manager.SetEmail(user.Id, Email.Text);
            ErrorMessage.Text = "Registration successfully.";
            message.Attributes["class"] = "text-success";

        }
        else
        {
            registerResult = result.Succeeded;
            ErrorMessage.Text = result.Errors.FirstOrDefault();
            message.Attributes["class"] = "text-danger";
        }
        
    }

    protected void Email_TextChanged(object sender, EventArgs e)
    {
        var manager = new UserManager();
        manager.FindByEmail(Email.Text);
        if (manager != null) {
            ErrorMessage.Text = "Email is being used by other user, please use another email.";
        }
    }
}