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

public partial class Admin_Modify : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void getdropdown(string selectedproject)
    {
        DropDownList ddl = (DropDownList)User_Detail.FindControl("selectedProject");
        ddl.Items.Clear();
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
            ddl.DataSource = table;
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Text";
            ddl.DataBind();
            ddl.SelectedValue = selectedproject;
            


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
    protected void getdropdown2(string selecteduser)
    {

        DropDownList ddl = (DropDownList)User_Detail.FindControl("selectedRole");
        ddl.Items.Clear();
        //selectedSection2.Items.Clear();
        DataTable table = new DataTable();
        String selectrole = "";
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.aspnetuserroles Where UserId=@userid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("userid", selecteduser);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) {
                reader.Read();
               selectrole = reader.GetString("RoleId");
               reader.Close();
            }

            String queryString2 = "Select * FROM daifuku.aspnetroles";
            cmd.CommandText = queryString2;
            MySqlDataReader reader2 = cmd.ExecuteReader();
            table.Load(reader2);
            reader2.Close();
            ddl.DataSource = table;
            ddl.DataValueField = "Id";
            ddl.DataTextField = "Name";
            ddl.DataBind();
            ddl.SelectedValue = selectrole;
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
        Page.Validate("modify");
        if (Page.IsValid)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            // String user_email = Session["UserEmail"].ToString();
            MySqlDataReader reader;

            try
            {
                connection.Open();
                String queryString = "SELECT * FROM daifuku.aspnetusers WHERE Email = @email";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@email",Email.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    update.Visible = true;
                    delete.Visible = true;
                    ban.Visible = true;
                    ErrorMessage.Text = "";
                    Session["email"] = Email.Text.ToString();
                    User_Detail.DataSource = reader;
                    User_Detail.DataBind();
                    getdropdown2(reader.GetString("Id"));
                    getdropdown(reader.GetString("ProjectId"));
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

    protected void updateUserProfile(object sender, EventArgs e)
    {
        string email = Session["email"].ToString();
        TextBox contact = (TextBox)User_Detail.FindControl("Contact");
        DropDownList ddl = (DropDownList)User_Detail.FindControl("selectedProject");
        DropDownList ddl2 = (DropDownList)User_Detail.FindControl("selectedRole");
        string userid = "";
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();

        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.aspnetusers SET PhoneNumber=@contact, PhoneNumberConfirmed=@status, ProjectId=@projectid WHERE Email = @email";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@contact", contact.Text);
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@projectid", ddl.SelectedValue);


            using (daifukuEntities db = new daifukuEntities()) {
                aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Email == email);
                userid = user.Id;
            }

            String queryString2 = "UPDATE daifuku.aspnetuserroles Set RoleId =@roleid where UserId =@userid";

            if (cmd.ExecuteNonQuery()>=1)
            {
                cmd.CommandText = queryString2;
                cmd.Parameters.AddWithValue("roleid", ddl2.SelectedValue);
                cmd.Parameters.AddWithValue("userid", userid);
                if (cmd.ExecuteNonQuery() >= 1) { 
                ErrorMessage.Text = "Update successfully.";
                message.Attributes["class"] = "text-success";
                }
            }
            else
            {
                ErrorMessage.Text = "No records update.";
            }

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }
        getupdatedresult();
    }

    protected void ban_Click(object sender, EventArgs e)
    {
        string email = Session["email"].ToString();
        TextBox contact = (TextBox)User_Detail.FindControl("Contact");
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.aspnetusers SET LockoutEnabled=@lockflag WHERE Email = @email";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@lockflag", getbanflag(ban.Text));
            cmd.Parameters.AddWithValue("@email", email);


            if (cmd.ExecuteNonQuery() >= 1)
            {
                ErrorMessage.Text = "Update successfully.";
                message.Attributes["class"] = "text-success";

            }
            else
            {
                ErrorMessage.Text = "No records update.";
            }

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
            
        }

        getupdatedresult();


    }

    protected Boolean getbanflag(String status) {
        if (status.Equals("Ban"))
        {
            return true;

        }
        else {
            return false;
        }
    }
    protected String getstatus(Object status) {
        String result="";
        if (((Boolean)status).Equals(false)){
            result = "Active";
            getbuttonstatus(status);
        }
        else {
            result = "Ban";
            getbuttonstatus(status);
        }
        return result;
    }

    protected void getbuttonstatus(Object status)
    {
        
        if (((Boolean)status).Equals(false))
        {
            ban.Text = "Ban";     
        }

        else
        {
            ban.Text = "Active";
        }
      
    }

    protected void getupdatedresult() {

        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();
        MySqlDataReader reader;

        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.aspnetusers WHERE Email = @email";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@email", Email.Text.ToString());
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                update.Visible = true;
                delete.Visible = true;
                ban.Visible = true;
                ErrorMessage.Text = "";
                Session["email"] = Email.Text.ToString();
                User_Detail.DataSource = reader;
                User_Detail.DataBind();
                getdropdown(reader.GetString("ProjectId"));
                getdropdown2(reader.GetString("Id"));
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

    protected void delete_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {

            string email = Session["email"].ToString();
            TextBox contact = (TextBox)User_Detail.FindControl("Contact");
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                String queryString = "DELETE FROM daifuku.aspnetusers WHERE Email = @email";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@email", email);


                if (cmd.ExecuteNonQuery() >= 1)
                {
                    ErrorMessage.Text = "User has deleted successfully.";
                    message.Attributes["class"] = "text-success";

                }
                else
                {
                    ErrorMessage.Text = "Record not found.";
                }

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
            finally
            {
                connection.Close();

            }
            User_Detail.DataSource = null;
            User_Detail.DataBind();
            update.Visible = false;
            delete.Visible = false;
            ban.Visible = false;
            
        }
        
    }
}