using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SectionAddition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();


        /*try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.coursesection ORDER BY SectionOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);

            sectionList.DataSource = cmd.ExecuteReader();
            sectionList.DataTextField = "Header";
            sectionList.DataValueField = "Id";
            sectionList.DataBind();
            
        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }
        */

        if (!Page.IsPostBack) {
            getprojectdropdown();
           // getdropdown();
       
        }

    }

    protected void getprojectdropdown() {
        selectedProject.Items.Clear();
        selectedProject2.Items.Clear();
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

            selectedProject2.DataSource = table;
            selectedProject2.DataValueField = "Id";
            selectedProject2.DataTextField = "Text";
            selectedProject2.DataBind();

            selectedProject3.DataSource = table;
            selectedProject3.DataValueField = "Id";
            selectedProject3.DataTextField = "Text";
            selectedProject3.DataBind();

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }
        getdropdownSection(selectedProject2.SelectedValue);
        getdropdownSection2(selectedProject3.SelectedValue);
    }

    protected void getdropdownSection(String selectprojectid) {
        selectedSection.Items.Clear();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.coursesection where ProjectId=@projectid ORDER BY SECTIONORDER";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", selectprojectid);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedSection.DataSource = table;
            selectedSection.DataValueField = "Id";
            selectedSection.DataTextField = "Header";
            selectedSection.DataBind();
            if (selectedSection.Items.Count <= 0) {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
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
    }
    protected void getdropdownSection2(String selectprojectid)
    {
        selectedSection2.Items.Clear();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.coursesection where ProjectId=@projectid ORDER BY SECTIONORDER";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", selectprojectid);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedSection2.DataSource = table;
            selectedSection2.DataValueField = "Id";
            selectedSection2.DataTextField = "Header";
            selectedSection2.DataBind();
            if (selectedSection.Items.Count <= 0)
            {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
            }
            else {
                ErrorMessage.Text = "";
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
    }
    /*
    protected void getdropdown() {
      
        selectedSection.Items.Clear();
        selectedSection2.Items.Clear();


        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.coursesection ORDER BY SECTIONORDER";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedSection.DataSource = table;
            selectedSection.DataValueField = "Id";
            selectedSection.DataTextField = "Header";
            selectedSection.DataBind();
            selectedSection2.DataSource = table;
            selectedSection2.DataValueField = "Id";
            selectedSection2.DataTextField = "Header";
            selectedSection2.DataBind();

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
    
    protected void update_Click(object sender, EventArgs e)
    {
        string leftAllItems = Request.Form[sectionList.UniqueID];
        var oldList =  sectionList.Items.Cast<ListItem>().ToArray();
        sectionList.Items.Clear();
        if (!string.IsNullOrEmpty(leftAllItems))
        {
            int order = 1;
            foreach (string item in leftAllItems.Split(','))
            { string header="";
                
                for (int a = 0; a < oldList.Length; a++) {
                    if (oldList[a].Value.Equals(item)) {
                        header = oldList[a].Text;
                        break;
                    }
                }
                ListItem nitem = new ListItem (header,item);
                sectionList.Items.Add(nitem);
                updateDatabase(item, order);
                order++;
            }
        }

        Response.Redirect("~/Admin/SectionAddition.aspx");
    }

    protected void updateDatabase(string sectionid, int sectionorder) {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();


        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.coursesection SET SectionOrder=@sectionorder WHERE Id=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionorder", sectionorder);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }



    }*/


    protected void Submit_Click(object sender, EventArgs e)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "INSERT INTO daifuku.coursesection VALUES(@sectionid,@sectionheader,@sectionorder,@quiz,@projectid)";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", Guid.NewGuid().ToString());
            cmd.Parameters.AddWithValue("sectionheader", SectionHeader.Text);
            cmd.Parameters.AddWithValue("sectionorder", getSectionRow(selectedProject.SelectedValue));
            cmd.Parameters.AddWithValue("quiz", 0);
            cmd.Parameters.AddWithValue("projectid",selectedProject.SelectedValue);
            if (cmd.ExecuteNonQuery() > 0) {
                ErrorMessage.Text = "Section Added.";
                message.Attributes["class"] = "text-success";
                SectionHeader.Text = "";
                // getdropdown();
               // getprojectdropdown();
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
    }

    public int getSectionRow(String projectid)
    {
        int count = 0;
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select Count(*) FROM daifuku.coursesection where ProjectId=@projectid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", projectid);
            count = Convert.ToInt32(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }

        return count + 1;
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (Upload.HasFile)
        {
            string FileExtension = System.IO.Path.GetExtension(Upload.FileName);
            if (FileExtension.ToLower() != ".mp4" && FileExtension.ToLower() != ".webm") {
                ErrorMessage.Text = "Upload file must be in .mp4 or .webm format.";
                message.Attributes["class"] = "text-danger";
            }
            else {
                String courseid = Guid.NewGuid().ToString();
                updateDatabase(courseid, selectedSection.SelectedValue, FileExtension.ToLower());
                Upload.SaveAs(Server.MapPath("~/Course/video/" + courseid + FileExtension));
                CourseHeader.Text = "";
                ErrorMessage.Text = "Course Added.";
                message.Attributes["class"] = "text-success";
            }
        }
        else {
            ErrorMessage.Text = "No file was Uploaded.";
            message.Attributes["class"] = "text-danger";
            
        }
        

    }


    protected void updateDatabase(string filename, string sectionid, string fileExtension) {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "INSERT INTO daifuku.course VALUES(@courseid,@header,@path,@desc,@sectionid,@courseorder)";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("courseid", filename);
            cmd.Parameters.AddWithValue("header", CourseHeader.Text);
            cmd.Parameters.AddWithValue("path", "video/"+filename + fileExtension);
            cmd.Parameters.AddWithValue("desc", null);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            cmd.Parameters.AddWithValue("courseorder", getCourseRow(sectionid));
            
            if (cmd.ExecuteNonQuery() > 0)
            {
                ErrorMessage.Text = "Section Added.";
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
        }
    }


    public int getCourseRow(string sectionid)
    {
        int count = 0;
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select Count(*) FROM daifuku.course WHERE SectionId=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            count = Convert.ToInt32(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally
        {
            connection.Close();
        }

        return count + 1;
    }

    protected void selectedProject2_SelectedIndexChanged(object sender, EventArgs e)
    {

        selectedSection.Items.Clear();
       
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.coursesection Where ProjectId=@projectid ORDER BY SECTIONORDER";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", selectedProject2.SelectedValue);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedSection.DataSource = table;
            selectedSection.DataValueField = "Id";
            selectedSection.DataTextField = "Header";
            selectedSection.DataBind();
            if (selectedSection.Items.Count <= 0)
            {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
            }
            else {
                ErrorMessage.Text = "";
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
    }

    protected void selectedProject3_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedSection2.Items.Clear();

        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.coursesection Where ProjectId=@projectid ORDER BY SECTIONORDER";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", selectedProject3.SelectedValue);
            MySqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            selectedSection2.DataSource = table;
            selectedSection2.DataValueField = "Id";
            selectedSection2.DataTextField = "Header";
            selectedSection2.DataBind();
            if (selectedSection2.Items.Count <= 0)
            {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
            }
            else
            {
                ErrorMessage.Text = "";
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
    }
}