using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class Admin_SectionModification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ErrorMessage.Text = "";
            TabContent.ActiveTabIndex = 0;
            getprojectdropdown();
            getdropdown();
           



        }
    }

    protected void getsectionlistbox(string projectid)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();


        try
        {
            
            connection.Open();
            String queryString = "SELECT * FROM daifuku.coursesection Where ProjectId=@projectid ORDER BY SectionOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", projectid);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                sectionList.DataSource = reader;
                sectionList.DataTextField = "Header";
                sectionList.DataValueField = "Id";
                sectionList.DataBind();
                sectionList.SelectedIndex = 0;
                getcourselistbox(sectionList.SelectedValue);
            }
            else
            {
                sectionList.Items.Clear();
                sectionList.DataSource = null;
                sectionList.DataBind();
                sectionList.Enabled = false;

                courseList.Items.Clear();
                courseList.DataSource = null;
                courseList.DataBind();
                courseList.Enabled = false;

                ErrorMessage.Text = "this project doesn't have section and course.";
                //error messaage with clean listbox
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

    protected void getcourselistbox(string selectedsection)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();


        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.course Where SectionId=@sectionid ORDER BY CourseOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", selectedsection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                courseList.DataSource = reader;
                courseList.DataTextField = "Header";
                courseList.DataValueField = "Id";
                courseList.DataBind();
                courseList.SelectedIndex = 0;
                courseList.Enabled = true;
                ErrorMessage.Text = "";
            }
            else
            {
                courseList.Items.Clear();
                courseList.DataSource = null;
                courseList.DataBind();
                courseList.Enabled = false;
                ErrorMessage.Text = "this section doesn't have course.";
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

    protected void updateSectionOrder(string sectionid, int sectionorder)
    {
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



    }

    protected void getprojectdropdown()
    {
        
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
           

            selectedProject2.DataSource = table;
            selectedProject2.DataValueField = "Id";
            selectedProject2.DataTextField = "Text";
            selectedProject2.DataBind();

            selectedProject3.DataSource = table;
            selectedProject3.DataValueField = "Id";
            selectedProject3.DataTextField = "Text";
            selectedProject3.DataBind();

            selectedProject4.DataSource = table;
            selectedProject4.DataValueField = "Id";
            selectedProject4.DataTextField = "Text";
            selectedProject4.DataBind();

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
        getsectionlistbox(selectedProject3.SelectedValue);
        getdropdownSection2(selectedProject4.SelectedValue);
    }

    protected void getdropdownSection(String selectprojectid)
    {
        selectedCourseSection.Items.Clear();
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
            selectedCourseSection.DataSource = table;
            selectedCourseSection.DataValueField = "Id";
            selectedCourseSection.DataTextField = "Header";
            selectedCourseSection.DataBind();
            if (selectedCourseSection.Items.Count <= 0)
            {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
            }
            else {
                ErrorMessage.Text = "";
                getcoursedropdown(selectedCourseSection.SelectedValue);
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
            if (selectedSection2.Items.Count <= 0)
            {

                ErrorMessage.Text = "No section in this Project, please create a section first.";
                message.Attributes["class"] = "text-danger";
            }
            else
            {
                ErrorMessage.Text = "";
                //getsectionlistbox(selectprojectid);
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

    protected void getdropdown()
    {
        selectedSection.Items.Clear();
       // selectedSection2.Items.Clear();
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

           // loadselectedIndex(selectedSection2.SelectedValue);

           // selectedCourseSection.DataSource = table;
           // selectedCourseSection.DataValueField = "Id";
           // selectedCourseSection.DataTextField = "Header";
           // selectedCourseSection.DataBind();
            

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

    protected void getdropdown(string selectedproject)
    {
        DropDownList ddl = (DropDownList)SectionDetail.FindControl("selectedProject");
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

    protected void Submit_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        CourseDetail.DataSource = null;
        CourseDetail.DataBind();
        string sectionid = selectedSection.SelectedValue;
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataReader reader;
        try
        {
            connection.Open();
            String queryString = "Select daifuku.coursesection.Header, daifuku.coursesection.ProjectId, count(daifuku.course.SectionId) as course from daifuku.coursesection left join daifuku.course ON daifuku.course.SectionId=daifuku.coursesection.id WHere daifuku.coursesection.Id =@sectionid group by SectionId";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                SectionDetail.DataSource = reader;
                SectionDetail.DataBind();
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

    protected void Update_Click(object sender, EventArgs e)
    {
        string sectionid = selectedSection.SelectedValue;
        string oldprojectid="";
        int order = 0;
        DropDownList ddl = (DropDownList)SectionDetail.FindControl("selectedProject");
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        //get section order
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();
        Boolean flag = false;
       
        try
        {
            connection.Open();
            String queryString = "SELECT SectionOrder, ProjectId from daifuku.coursesection WHERE Id=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
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
            oldprojectid = row["ProjectId"].ToString();
        }


        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.coursesection SET Header = @header, SectionOrder=@order, ProjectId=@projectid WHERE Id=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("header", ((TextBox)SectionDetail.FindControl("newSectionHeader")).Text);
            cmd.Parameters.AddWithValue("order", getSectionRow(ddl.SelectedValue));
            cmd.Parameters.AddWithValue("projectid", ddl.SelectedValue);
            cmd.Parameters.AddWithValue("sectionid", sectionid);

            if (cmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }

        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message.ToString();
        }
        finally {
            connection.Close();
        }

        //update order
        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.coursesection SET SectionOrder = SectionOrder - 1 Where Projectid=@projectid and SectionOrder > @order";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", oldprojectid);
            cmd.Parameters.AddWithValue("order", order);
            if (cmd.ExecuteNonQuery() > 0 && flag)
            {
                ErrorMessage.Text = "Section Updated";
                message.Attributes["class"] = "text-success";
            }
            else if (flag) {
                ErrorMessage.Text = "Section Updated";
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
            CourseDetail.DataSource = null;
            CourseDetail.DataBind();
            getdropdown();
            getprojectdropdown();
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

    protected void Delete_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            int order = 0;
            string oldprojectid = "";
            string sectionid = selectedSection.SelectedValue;
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            //get order based on id
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            Boolean flag = false;
            try
            {
                connection.Open();
                String queryString = "SELECT SectionOrder, ProjectId from daifuku.coursesection WHERE Id=@sectionid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("sectionid", sectionid);
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
                oldprojectid = row["ProjectId"].ToString();
            }


            try
            {
                connection.Open();
                String queryString = "DELETE from daifuku.coursesection WHERE Id=@sectionid AND ProjectId=@projectid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("sectionid", sectionid);
                cmd.Parameters.AddWithValue("projectid", oldprojectid);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
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

            //update order after delete
            if (flag)
            {
                try
                {
                    connection.Open();
                    String queryString = "UPDATE daifuku.coursesection SET SectionOrder = SectionOrder - 1 Where Projectid=@projectid and SectionOrder > @order";
                    MySqlCommand cmd = new MySqlCommand(queryString, connection);
                    cmd.Parameters.AddWithValue("order", order);
                    cmd.Parameters.AddWithValue("projectid", oldprojectid);
                    if (cmd.ExecuteNonQuery() > 0 && flag)
                    {
                        ErrorMessage.Text = "Section Deleted";
                        message.Attributes["class"] = "text-success";
                    }
                    else if (flag) {
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
                    SectionDetail.DataSource = null;
                    SectionDetail.DataBind();
                    CourseDetail.DataSource = null;
                    CourseDetail.DataBind();
                    getdropdown();
                    getprojectdropdown();
                }
            }
        }
    }

    protected Object checkValue(Object course)
    {
        if (Convert.ToInt32(course) <= 0)
        {
            ((Button)SectionDetail.FindControl("displayCourse")).Enabled = false;
        }
        return course;
    }

    protected void displayCourse_Click(object sender, EventArgs e)
    {
        string sectionid = selectedSection.SelectedValue;

        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        //get order based on id
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();

        try
        {
            connection.Open();
            String queryString = "SELECT Header as 'Course Title' from daifuku.course WHERE SectionId=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);

            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            CourseDetail.DataSource = table;
            CourseDetail.DataBind();
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

    protected void selectedCourseSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcoursedropdown(selectedCourseSection.SelectedValue);
        selectedCourseSection.Focus();
    }

    protected void getcoursedropdown(String sectionid)
    {
        selectedCourse.Items.Clear();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select Id, Header FROM daifuku.course Where SectionId=@sectionid ORDER BY CourseOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                courseddl.Visible = true;
                Submit_2.Enabled = true;
                table.Load(reader);
                ErrorMessage.Text = "";
                selectedCourse.DataSource = table;
                selectedCourse.DataValueField = "Id";
                selectedCourse.DataTextField = "Header";
                selectedCourse.DataBind();
            }
            else
            {
                courseddl.Visible = false;
                Submit_2.Enabled = false;
                CourseDetail_2.DataSource = null;
                CourseDetail_2.DataBind();
                ErrorMessage.Text = "No Course was found in this section.";
                message.Attributes["class"] = "text-danger";
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

    protected void Submit_2_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        string sectionid = selectedCourseSection.SelectedValue;
        string courseid = selectedCourse.SelectedValue;
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        //get order based on id
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();

        try
        {
            connection.Open();
            String queryString = "SELECT Header as 'Course Title', Path from daifuku.course WHERE SectionId=@sectionid AND Id=@courseid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            cmd.Parameters.AddWithValue("courseid", courseid);
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            CourseDetail_2.DataSource = table;
            CourseDetail_2.DataBind();
            ((HtmlSource)CourseDetail_2.FindControl("cVideo")).Src = "../Course/" + table.Rows[0]["Path"].ToString();
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

    protected void Update_2_Click(object sender, EventArgs e)
    {
        string FileExtension = System.IO.Path.GetExtension(((FileUpload)CourseDetail_2.FindControl("Upload")).FileName);
        if (((FileUpload)CourseDetail_2.FindControl("Upload")).HasFile)
        {


            if (FileExtension.ToLower() != ".mp4" && FileExtension.ToLower() != ".webm")
            {
                ErrorMessage.Text = "Upload file must be in .mp4 or .webm format.";
                message.Attributes["class"] = "text-danger";
            }
            else
            {

                updateDatabase(selectedCourse.SelectedValue, selectedCourseSection.SelectedValue, FileExtension.ToLower());
                //delete old video
                string file = Server.MapPath("~/Course/video/" + selectedCourse.SelectedValue + ".mp4");
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }

                string file2 = Server.MapPath("~/Course/video/" + selectedCourse.SelectedValue + ".webm");
                if (System.IO.File.Exists(file2))
                {
                    System.IO.File.Delete(file2);
                }

                updateSeen(selectedCourse.SelectedValue);

                //update seen table
                ((FileUpload)CourseDetail_2.FindControl("Upload")).SaveAs(Server.MapPath("~/Course/video/" + selectedCourse.SelectedValue + FileExtension));
                CourseDetail_2.DataSource = null;
                CourseDetail_2.DataBind();
                getdropdown();
                ErrorMessage.Text = "Course Updated.";
                message.Attributes["class"] = "text-success";
            }
        }
        else
        {
            updateDatabase(selectedCourse.SelectedValue, selectedCourseSection.SelectedValue, FileExtension.ToLower());
            CourseDetail_2.DataSource = null;
            CourseDetail_2.DataBind();
            getdropdown();
            ErrorMessage.Text = "Course Updated.";
            message.Attributes["class"] = "text-success";
        }


    }

    protected void updateSeen(string courseid)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "DELETE from daifuku.seen WHERE CourseId=@courseid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("courseid", courseid);
            if (cmd.ExecuteNonQuery() > 0)
            {

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

    protected void updateDatabase(string filename, string sectionid, string fileExtension)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "";
            if (((FileUpload)CourseDetail_2.FindControl("Upload")).HasFile)
            {
                queryString = "UPDATE daifuku.course SET Header=@title, Path=@path WHERE Id=@courseid AND SectionId=@sectionid";
            }
            else
            {
                queryString = "UPDATE daifuku.course SET Header=@title WHERE Id=@courseid AND SectionId=@sectionid";
            }
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("courseid", filename);
            cmd.Parameters.AddWithValue("title", ((TextBox)CourseDetail_2.FindControl("newCourseTitle")).Text);
            if (((FileUpload)CourseDetail_2.FindControl("Upload")).HasFile)
            {
                cmd.Parameters.AddWithValue("path", "video/" + filename + fileExtension);

            }
            cmd.Parameters.AddWithValue("sectionid", sectionid);

            if (cmd.ExecuteNonQuery() > 0)
            {

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


    protected void Delete_2_Click(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string sectionid = selectedCourseSection.SelectedValue;
            string courseid = selectedCourse.SelectedValue;
            string file = Server.MapPath("~" + ((HtmlSource)CourseDetail_2.FindControl("cVideo")).Src.Substring(2));
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            //get order based on id
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            int order = 0;
            Boolean flag = false;
            try
            {
                connection.Open();
                String queryString = "SELECT CourseOrder from daifuku.course WHERE SectionId=@sectionid AND Id=@courseid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("sectionid", sectionid);
                cmd.Parameters.AddWithValue("courseid", courseid);
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
                order = Convert.ToInt32(row["CourseOrder"].ToString());
            }



            try
            {
                connection.Open();
                String queryString = "DELETE from daifuku.course WHERE SectionId=@sectionid AND Id=@courseid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("sectionid", sectionid);
                cmd.Parameters.AddWithValue("courseid", courseid);
                if (cmd.ExecuteNonQuery() > 0)
                {


                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }

                    flag = true;

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

            if (flag)
            {
                try
                {
                    connection.Open();
                    String queryString = "UPDATE daifuku.course SET CourseOrder = CourseOrder - 1 Where CourseOrder > @order AND SectionId=@sectionid";
                    MySqlCommand cmd = new MySqlCommand(queryString, connection);
                    cmd.Parameters.AddWithValue("order", order);
                    cmd.Parameters.AddWithValue("sectionid", sectionid);
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
                    CourseDetail_2.DataSource = null;
                    CourseDetail_2.DataBind();
                    ErrorMessage.Text = "Course deleted.";
                    message.Attributes["class"] = "text-success";
                }
            }
        }
    }




    protected void Update_3_Click(object sender, EventArgs e)
    {
        string sectionItems = Request.Form[sectionList.UniqueID];
        string courseItems = Request.Form[courseList.UniqueID];
        String sectionid = (String)Session["selectedsection"];
        var oldList = sectionList.Items.Cast<ListItem>().ToArray();
        var oldList_2 = courseList.Items.Cast<ListItem>().ToArray();

        sectionList.Items.Clear();
        if (!string.IsNullOrEmpty(sectionItems))
        {
            int order = 1;
            foreach (string item in sectionItems.Split(','))
            {
                string header = "";

                for (int a = 0; a < oldList.Length; a++)
                {
                    if (oldList[a].Value.Equals(item))
                    {
                        header = oldList[a].Text;
                        break;
                    }
                }
                ListItem nitem = new ListItem(header, item);
                sectionList.Items.Add(nitem);
                updateSectionOrder(item, order);
                order++;
            }
        }

        if (!string.IsNullOrEmpty(courseItems))
        {
            int order = 1;
            foreach (string item in courseItems.Split(','))
            {
                string header = "";

                for (int a = 0; a < oldList_2.Length; a++)
                {
                    if (oldList_2[a].Value.Equals(item))
                    {
                        header = oldList_2[a].Text;
                        break;
                    }
                }
                ListItem nitem = new ListItem(header, item);
                courseList.Items.Add(nitem);
                updateCourseOrder(sectionid, item, order);
                order++;
            }
        }

        //Response.Redirect("~/Admin/SectionModification.aspx");
        //TabContent.ActiveTabIndex = 2;
        getsectionlistbox(selectedProject3.SelectedValue);
        ErrorMessage.Text = "Order updated.";
        message.Attributes["class"] = "text-success";
    }

    protected void updateCourseOrder(String sectionid, String courseid, int order)
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        // String user_email = Session["UserEmail"].ToString();


        try
        {
            connection.Open();
            String queryString = "UPDATE daifuku.course SET CourseOrder=@courseorder WHERE Id=@courseid AND SectionId=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("courseorder", order);
            cmd.Parameters.AddWithValue("courseid", courseid);
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




    }

    protected void sectionList_SelectedIndexChanged(object sender, EventArgs e)
    {

        getcourselistbox(sectionList.SelectedValue);
        string sectionItems = Request.Form[sectionList.UniqueID];
        if (!sectionItems.Contains(","))
        {
            Session["selectedsection"] = sectionList.SelectedValue;
        }

    }


    protected void GetQuestionList(object sender, EventArgs e)
    {
        answersection.Visible = false;
        AnswerList.DataSource = null;
        AnswerList.DataBind();
        getquestionlist(selectedSection2.SelectedValue);
    }

    protected void getanswerlist(string selectedquestion) {

        AnswerList.DataSource = null;
        AnswerList.DataBind();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.answer Where QuestionId=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", selectedquestion);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //courseddl.Visible = true;
                //Submit_2.Enabled = true;
                table.Load(reader);
                ErrorMessage.Text = "";
                AnswerList.DataSource = table;
                AnswerList.DataBind();
                


                //Bind with isAnswer dropdown


                //QuestionDropDown.DataSource = table;
                //QuestionDropDown.DataValueField = "Id";
                //QuestionDropDown.DataTextField = "Header";
                //QuestionDropDown.DataBind();
                //QuestionDropDown.Enabled = true;
            }
            else
            {
                //courseddl.Visible = false;
                //Submit_2.Enabled = false;
                //CourseDetail_2.DataSource = null;
                //CourseDetail_2.DataBind();
                // QuestionDropDown.Enabled = false;
                ErrorMessage.Text = "No Answers was found in this Question.";
                message.Attributes["class"] = "text-danger";
               // answersection.Visible = false;
                //hide the below section
            }
            answersection.Visible = true;
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


    protected void getquestionlist(string selectedSection)
    {

        QuestionList.DataSource = null;
        QuestionList.DataBind();
        DataTable table = new DataTable();
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            String queryString = "Select * FROM daifuku.question Where ExamId=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", selectedSection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //courseddl.Visible = true;
                //Submit_2.Enabled = true;
                table.Load(reader);
                ErrorMessage.Text = "";
                QuestionList.DataSource = table;
                QuestionList.DataBind();
                //QuestionDropDown.DataSource = table;
                //QuestionDropDown.DataValueField = "Id";
                //QuestionDropDown.DataTextField = "Header";
                //QuestionDropDown.DataBind();
                //QuestionDropDown.Enabled = true;
            }
            else
            {
                //courseddl.Visible = false;
                //Submit_2.Enabled = false;
                //CourseDetail_2.DataSource = null;
                //CourseDetail_2.DataBind();
               // QuestionDropDown.Enabled = false;
                ErrorMessage.Text = "No Quiz was found in this section.";
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


    protected void SelectedQuestion(object sender, GridViewCommandEventArgs e) {

        using (Entities db = new Entities())
        {

           if (e.CommandName.Equals("DeletedQuiz"))
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    string sectionid = selectedSection2.SelectedValue;
                    string questionid = e.CommandArgument.ToString();
                    exam Exam = (exam)db.exams.FirstOrDefault(x => x.Id == sectionid);
                    if (Exam != null)
                    {
                        question Question = new question();
                        Question.Id = questionid;
                        Question.ExamId = sectionid;

                        //Exam.questions.Remove(Question);
                        db.Entry(Question).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();

                    }
                    //update totalpoint
                    Exam.TotalPoints = Exam.questions.Count;
                    db.Entry(Exam).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    //if no more question in the section delete the quiz section.
                    if (Exam.questions.Count == 0)
                    {
                        db.Entry(Exam).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                    ErrorMessage.Text = "Question Deleted.";
                    message.Attributes["class"] = "text-success";
                    if (QuestionList.EditIndex != -1) { 
                        QuestionList.EditIndex = -1;
                    }
                    getquestionlist(selectedSection2.SelectedValue);
                }
            }
            else
            {
                return;
            }
        }
    }

    protected void Unnamed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        QuestionList.PageIndex = e.NewPageIndex;
        getquestionlist(selectedSection2.SelectedValue);
    }

    protected void QuestionList_RowEditing(object sender, GridViewEditEventArgs e)
    {

        QuestionList.EditIndex = e.NewEditIndex;
        answersection.Visible = false;
        AnswerList.EditIndex = -1;
        AnswerList.DataSource = null;
        AnswerList.DataBind();
        
        getquestionlist(selectedSection2.SelectedValue);
    }

    protected void QuestionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string sectionid = selectedSection2.SelectedValue;
        string id = QuestionList.DataKeys[e.RowIndex].Value.ToString();
        GridViewRow row = (GridViewRow)QuestionList.Rows[e.RowIndex];
        TextBox quiz = (TextBox)row.Cells[3].Controls[0];

        using (Entities db = new Entities())
        {

            exam Exam = (exam)db.exams.FirstOrDefault(x => x.Id == sectionid);
            if (Exam != null)
            {
                question Question = new question();
                Question.Id = id;
                Question.ExamId = sectionid;
                Question.Text = quiz.Text;

                //update question text.
                db.Entry(Question).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
          

        }

        QuestionList.EditIndex = -1;
        getquestionlist(selectedSection2.SelectedValue);
        ErrorMessage.Text = "Question Modified.";
        message.Attributes["class"] = "text-success";
    }


    protected void SelectedAnswer(object sender, GridViewCommandEventArgs e)
    {
        //add answer delete portion
        using (Entities db = new Entities())
        {

            if (e.CommandName.Equals("DeletedAns"))
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    string questionid = QuestionList.SelectedDataKey.Value.ToString();
                    string ansid = e.CommandArgument.ToString();
                    //exam Exam = (exam)db.exams.FirstOrDefault(x => x.Id == sectionid);
                   // if (Exam != null)
                   // {
                        answer answer = new answer();
                        answer.Id = ansid;
                        answer.QuestionId = questionid;

                        //Exam.questions.Remove(Question);
                        db.Entry(answer).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();

                    //}
                    //update totalpoint
                    /*
                    Exam.TotalPoints = Exam.questions.Count;
                    db.Entry(Exam).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    //if no more question in the section delete the quiz section.
                    if (Exam.questions.Count == 0)
                    {
                        db.Entry(Exam).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                    */
                    ErrorMessage.Text = "Answer Deleted.";
                    message.Attributes["class"] = "text-success";
                    if (QuestionList.EditIndex != -1)
                    {
                        QuestionList.EditIndex = -1;
                    }
                    if (AnswerList.EditIndex != -1)
                    {
                        AnswerList.EditIndex = -1;
                    }
                    getanswerlist(QuestionList.SelectedDataKey.Value.ToString());
                }
            }
            else
            {
                return;
            }
        }

    }


    protected void AnswerList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AnswerList.EditIndex = e.NewEditIndex;
        //answersection.Visible = false;
        //AnswerList.DataSource = null;
        //AnswerList.DataBind();
        // getquestionlist(selectedSection2.SelectedValue);
        getanswerlist(QuestionList.SelectedDataKey.Value.ToString());
    }

    protected void AnswerList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
                string questionid = QuestionList.SelectedDataKey.Value.ToString();
                string id = AnswerList.DataKeys[e.RowIndex].Value.ToString();
                GridViewRow row = (GridViewRow)AnswerList.Rows[e.RowIndex];
                CheckBox correct = (CheckBox)row.Cells[2].Controls[0];
                TextBox quiz = (TextBox)row.Cells[3].Controls[0];

                            using (Entities db = new Entities())
                            {
                                answer ans = new answer();
                                ans.Id = id;
                                ans.QuestionId = questionid;
                                ans.Text = quiz.Text;
                                ans.IsAnswer = correct.Checked;
                                //update question text.
                                db.Entry(ans).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();



                            }
                AnswerList.EditIndex = -1;
                getanswerlist(QuestionList.SelectedDataKey.Value.ToString());
                ErrorMessage.Text = "Answer Modified.";
                message.Attributes["class"] = "text-success";
            
          
        
    }

    protected void AddAnswer_Click(object sender, EventArgs e)
    {
        if (Answer.Text.Length > 0)
        {
            if (AnswerList.EditIndex == -1)
            {
                string selectedquestionid = QuestionList.SelectedDataKey.Value.ToString();
                string sectionid = selectedSection2.SelectedValue;
                using (Entities db = new Entities())
                {
                    exam Exam = (exam)db.exams.FirstOrDefault(x => x.Id == sectionid);
                    if (Exam != null)
                    {
                        // question Question = new question();
                        // Question.Id = Guid.NewGuid().ToString();
                        //Question.Text = objUsr.Questions;
                        // Question.Points = objUsr.point;
                        //Question.ExamId = Exam.Id;
                        question ques = Exam.questions.FirstOrDefault(x => x.Id == selectedquestionid);

                        answer ans = new answer();
                        ans.Id = Guid.NewGuid().ToString();
                        ans.Text = Answer.Text;
                        ans.IsAnswer = false;
                        ans.QuestionId = selectedquestionid;
                        ques.answers.Add(ans);
                        // db.Entry(ques).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                Answer.Text = "";
                getanswerlist(QuestionList.SelectedDataKey.Value.ToString());
                ErrorMessage.Text = "New answer added.";
                message.Attributes["class"] = "text-success";
            }
            else {
                Answer.Text = "";
                ErrorMessage.Text = "Please complete the answer update before proceed next action.";
                message.Attributes["class"] = "text-danger";
                return;
            }
        }
        else {
            ErrorMessage.Text = "Add empty answer is not allowed.";
            message.Attributes["class"] = "text-danger";
        }
    }

    protected void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        getanswerlist(QuestionList.SelectedDataKey.Value.ToString());
        QuestionList.SelectedRow.Cells[3].BackColor = System.Drawing.Color.LimeGreen;
    }

    protected void QuestionList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (QuestionList.EditIndex != -1)
        {
            ErrorMessage.Text = "Please complete the question update before proceed next action.";
            message.Attributes["class"] = "text-danger";
            e.Cancel=true;
            return;
        }
        if (QuestionList.SelectedRow!=null)
        QuestionList.SelectedRow.Cells[3].BackColor = System.Drawing.Color.White;
    }


    protected void AnswerList_DataBound(object sender, EventArgs e)
    {
        for(int a=0; a< AnswerList.Rows.Count; a++) {
        CheckBox chk = (CheckBox)AnswerList.Rows[a].Cells[2].Controls[0];
            chk.Text = " ";
        chk.CssClass = "squaredFour";
       
        }
    }

    protected void selectedProject2_SelectedIndexChanged(object sender, EventArgs e)
    {
        getdropdownSection(selectedProject2.SelectedValue);
    }

    protected void selectedProject3_SelectedIndexChanged(object sender, EventArgs e)
    {
        getsectionlistbox(selectedProject3.SelectedValue);
    }

    protected void selectedProject4_SelectedIndexChanged(object sender, EventArgs e)
    {
        getdropdownSection2(selectedProject4.SelectedValue);
    }
}