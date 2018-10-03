using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainingSite;

public partial class Admin_Register2 : Page
{
    public Boolean registerResult = new Boolean();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ErrorMessage.Text = "";
           // getdropdown();
        }
    }
    /*
    protected void getdropdown()
    {
        selectedProject.Items.Clear();
        //selectedSection2.Items.Clear();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.project";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedProject.DataSource = table;
            selectedProject.DataValueField = "Id";
            selectedProject.DataTextField = "Text";
            selectedProject.DataBind();



        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }
    }
    */
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        String projectid = "";
        String userid = authenticationManager.User.Identity.GetUserId().ToString();
        using (daifukuEntities db = new daifukuEntities()) {
            aspnetuser loginuser = (aspnetuser)db.aspnetusers.FirstOrDefault(x=> x.Id == userid);
            projectid = loginuser.ProjectId;
        }
        var manager = new UserManager();
        var user = new ApplicationUser() { UserName = Username.Text, Email = Username.Text+"@email.com", EmailConfirmed = true, ProjectId = projectid};

        var role = "User";
        IdentityResult result = manager.Create(user);
        if (result.Succeeded)
        {
            registerResult = result.Succeeded;
            user = manager.FindByName(Username.Text);
            manager.AddToRole(user.Id, role);
            manager.AddPassword(user.Id, password.Text);
            manager.SetEmail(user.Id, Username.Text + "@email.com");


            using (daifukuEntities db = new daifukuEntities()) {
                aspnetuser a = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == user.Id);
                a.EmailConfirmed = true;
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            ErrorMessage.Text = "Registration successfully.";
            message.Attributes["class"] = "text-success";
            Username.Text = "";
            //GenerateEmail sendEmail = new GenerateEmail(user.Id, Email.Text);
            

        }
        else
        {
            registerResult = result.Succeeded;
            ErrorMessage.Text = result.Errors.FirstOrDefault();
            message.Attributes["class"] = "text-danger";
        }

    }
    /*
    protected void Email_TextChanged(object sender, EventArgs e)
    {
        var manager = new UserManager();
        manager.FindByEmail(Email.Text);
        if (manager != null)
        {
            ErrorMessage.Text = "Email is being used by other user, please use another email.";
        }
    }
    */
}