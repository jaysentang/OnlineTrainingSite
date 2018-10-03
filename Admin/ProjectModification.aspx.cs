using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProjectModification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ErrorMessage.Text = "";
            getdropdown();
        }
    }


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
    protected void Submit_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        SectionDetail.DataSource = null;
        SectionDetail.DataBind();
        string sectionid = selectedProject.SelectedValue;
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select daifuku.Project.Text, count(daifuku.coursesection.ProjectId) as Section from daifuku.project left join daifuku.coursesection ON daifuku.coursesection.ProjectId=daifuku.project.Id Where daifuku.project.Id =@projectid group by ProjectId";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", sectionid);
            ProjectDetail.DataSource = cmd.ExecuteReader();
            ProjectDetail.DataBind();

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

    protected Object checkValue(Object course)
    {
        if (Convert.ToInt32(course) <= 0)
        {
            ((Button)ProjectDetail.FindControl("displaySection")).Enabled = false;
        }
        return course;
    }


    protected void displaySection_Click(object sender, EventArgs e)
    {
        string projectid = selectedProject.SelectedValue;

        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        //get order based on id
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();

        try
        {
            connection.Open();
            String queryString = "SELECT Header as 'Section Title' from daifuku.coursesection WHERE ProjectId=@projectid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", projectid);

            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            SectionDetail.DataSource = table;
            SectionDetail.DataBind();
            ErrorMessage.Text = "";
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

    protected void Update_Click(object sender, EventArgs e)
    {
        string projectid = selectedProject.SelectedValue;
        string newprojectheader = ((TextBox)ProjectDetail.FindControl("newProjectHeader")).Text;
        using (daifukuEntities1 db = new daifukuEntities1())
        {
            int counter = db.projects.Count(x => x.Text == newprojectheader);
            if (counter == 0)
            {
                project Project = (project)db.projects.FirstOrDefault(x => x.Id == projectid);
                Project.Text = newprojectheader;
                db.Entry(Project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ErrorMessage.Text = "Section Updated";
                message.Attributes["class"] = "text-success";
            }

            else
            {
                ErrorMessage.Text = "Project already exist, please try alternative name.";
                message.Attributes["class"] = "text-danger";
            }
        }

        SectionDetail.DataSource = null;
        SectionDetail.DataBind();
        getdropdown();
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            int order = 0;
            string projectid = selectedProject.SelectedValue;
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            //get order based on id
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            Boolean flag = false;
            /*
            try
            {
                connection.Open();
                String queryString = "SELECT SectionOrder from daifuku.project WHERE Id=@projectid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("projectid", projectid);
                adapter.SelectCommand = cmd;
                adapter.Fill(table);

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
            finally
            {
                connection.Close();
            }
            //get order
            foreach (DataRow row in table.Rows)
            {
                order = Convert.ToInt32(row["SectionOrder"].ToString());
            }
            */

            try
            {
                connection.Open();
                String queryString = "DELETE from daifuku.project WHERE Id=@projectid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("projectid", projectid);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //flag = true;

                    ErrorMessage.Text = "Project Deleted";
                    message.Attributes["class"] = "text-success";
                }

            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message.ToString();
            }
            finally
            {
                connection.Close();
                getdropdown();
                ProjectDetail.DataSource = null;
                ProjectDetail.DataBind();
                SectionDetail.DataSource = null;
                SectionDetail.DataBind();
            }

            //update order after delete
            /*
            if (flag)
            {
                try
                {
                    connection.Open();
                    String queryString = "UPDATE daifuku.coursesection SET SectionOrder = SectionOrder - 1 Where SectionOrder > @order";
                    MySqlCommand cmd = new MySqlCommand(queryString, connection);
                    cmd.Parameters.AddWithValue("order", order);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        ErrorMessage.Text = "Section Deleted";
                        message.Attributes["class"] = "text-success";
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    connection.Close();
                    getdropdown();
                    ProjectDetail.DataSource = null;
                    ProjectDetail.DataBind();
                    SectionDetail.DataSource = null;
                    SectionDetail.DataBind();
                }
                
            }*/
        }
    }

}