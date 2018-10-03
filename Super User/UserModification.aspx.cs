using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using TrainingSite;
using MySql.Data.MySqlClient;
using Microsoft.Owin.Security;
using System.Data;
using Microsoft.AspNet.Identity;

public partial class Admin_Modify : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void getdropdown(string selectedproject)
    {
        //DropDownList ddl = (DropDownList)User_Detail.FindControl("selectedProject");
        //ddl.Items.Clear();
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
           // ddl.DataSource = table;
           // ddl.DataValueField = "Id";
           // ddl.DataTextField = "Text";
           // ddl.DataBind();
           // ddl.SelectedValue = selectedproject;
            


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
    protected void getUserProfile(object sender, EventArgs e)
    {
        UserDetails.DataSource = null;
        UserDetails.DataBind();
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

        Page.Validate("modify");
        if (Page.IsValid)
        {
            String projectid = "";
            String userid = authenticationManager.User.Identity.GetUserId().ToString();
            using (daifukuEntities db = new daifukuEntities())
            {
                aspnetuser loginuser = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userid);
                projectid = loginuser.ProjectId;
            }

            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            // String user_email = Session["UserEmail"].ToString();
            MySqlDataReader reader;
            MySqlCommand cmd;
            DataTable table = new DataTable();
            String queryString = "";
            try
            {
                connection.Open();
                if (Username.Text.ToString().Length > 0)
                {
                    queryString = "SELECT Id,UserName,LockoutEnabled FROM daifuku.aspnetusers WHERE UserName LIKE @username AND ProjectId=@projectid";
                    cmd = new MySqlCommand(queryString, connection);
                    cmd.Parameters.AddWithValue("username", Username.Text.ToString()+"%");
                    cmd.Parameters.AddWithValue("projectid", projectid);
                }
                else {
                    queryString = "SELECT * FROM daifuku.aspnetusers WHERE ProjectId=@projectid";
                    cmd = new MySqlCommand(queryString, connection);
                    cmd.Parameters.AddWithValue("projectid", projectid);

                }
          
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                  
                    ErrorMessage.Text = "";
                    //     Session["email"] = Email.Text.ToString();
                    table.Load(reader);
                    UserDetails.DataSource = table;
                    UserDetails.DataBind();

                 //   getdropdown(reader.GetString("ProjectId"));
                }
                else
                {
                    ErrorMessage.Text = "No records found.";
                }

                reader.Close();
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

    }


    protected string getBanStatus(object status) {
        if (Convert.ToBoolean(status)) {

            return "Enable";
        }
        else {
            return "Disable";
        }
              

    }



    protected void UserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        UserDetails.PageIndex = e.NewPageIndex;
    }

    protected void UserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        using (daifukuEntities db = new daifukuEntities())
        {

            if (e.CommandName.Equals("DeleteUser"))
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {

                    string userid = e.CommandArgument.ToString();
                    aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userid);
                    if (user != null)
                    {

                        
                        db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        ErrorMessage.Text = "User Deleted.";
                        message.Attributes["class"] = "text-success";
                    }



                    if (UserDetails.EditIndex != -1)
                    {
                        UserDetails.EditIndex = -1;
                    }

                    getUserProfile(this.getProfile, null);

                }
            }
            else if (e.CommandName.Equals("BanUser")) {

                string userid = e.CommandArgument.ToString();
                //get button text from userdetail
                Button Banbutton = (Button)UserDetails.TemplateControl.FindControl("BanButton");
                aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userid);
                if (user != null) {
                    if (user.LockoutEnabled)
                    {
                        user.LockoutEnabled = false;
                      //  Banbutton.Text = "Enable";
                     
                    }
                    else {
                        user.LockoutEnabled = true;
                     //   Banbutton.Text = "Disable";
                       
                    }
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    
                }

                if (UserDetails.EditIndex != -1)
                {
                    UserDetails.EditIndex = -1;
                }

                getUserProfile(this.getProfile, null);

            }
            else
            {
                return;
            }
        }
    }
}