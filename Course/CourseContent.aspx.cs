using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Course_CourseContent : System.Web.UI.Page
{
    String userId, projectId = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        if (authenticationManager.User.Identity.IsAuthenticated)
        {
            userId = authenticationManager.User.Identity.GetUserId();
        }

        using (daifukuEntities db = new daifukuEntities())
        {
            aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userId);
            projectId = user.ProjectId;
        }

        DataTable table = new DataTable();
        String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //get number of section
        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.coursesection Where daifuku.coursesection.ProjectId=@projectid ORDER BY SectionOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", projectId);
            adapter.SelectCommand = cmd;
            adapter.Fill(table);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
            adapter.Dispose();
        }

        foreach (DataRow datarow in table.Rows)
        {
            String sectionId = datarow["Id"].ToString();
            String sectionTitle = datarow["Header"].ToString();
            
            HtmlGenericControl divTag = new HtmlGenericControl("div");
            divTag.Attributes.Add("class", "form-group form-background");

            HtmlGenericControl label = new HtmlGenericControl("span");
            label.Attributes.Add("data-toggle", "collapse");
            label.Attributes.Add("data-target", "#" + sectionId);
            label.Attributes.Add("class", "course-section-header");
            label.InnerHtml = sectionTitle;

            /*
            Label label = new Label();
            label.Text = sectionTitle;
            label.Attributes.Add("data-toggle", "collapse");
            label.Attributes.Add("data-target", "#" + sectionId);
            label.Attributes.Add("class", "course-section-header");
            */




            HtmlGenericControl divContent = new HtmlGenericControl("div");
            divContent.Attributes.Add("id", sectionId);
            divContent.Attributes.Add("class", "collapse course-list-header");
            //divContent.InnerHtml = "hello";

            divContent.Controls.Add(readDataBasedOnId(sectionId, label));
            divTag.Controls.Add(label);
            //readDataBasedOnId(sectionId);
            divTag.Controls.Add(divContent);
            container.Controls.Add(divTag);

        }



       

    }


    public Control readDataBasedOnId(String sectionid, HtmlGenericControl label)
    {
        String courseId = String.Empty;
        int listQty = 0;
        /*
        Repeater repeater = new Repeater();
        repeater.HeaderTemplate = new MyTemplate(ListItemType.Header, sectionid);
        repeater.ItemTemplate = new MyTemplate(ListItemType.Item, sectionid);
        repeater.FooterTemplate = new MyTemplate(ListItemType.Footer, sectionid);
        repeater.DataBind();
        */
        DataTable table = new DataTable();
        String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //get number of section
        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.course where SectionId=@sectionid Order By CourseOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            adapter.SelectCommand = cmd;
            adapter.Fill(table);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
            adapter.Dispose();
        }

        HtmlGenericControl leadList = new HtmlGenericControl("ul");
        leadList.Attributes.Add("class", "nav");
        foreach (DataRow datarow in table.Rows)
        {
            courseId = datarow["Id"].ToString();
            String courseTitle = datarow["Header"].ToString();
            HtmlGenericControl list = new HtmlGenericControl("li");
           
            //list.ID = courseId;
            list.Attributes.Add("class", "course-list-item");
            //HtmlContainerControl link = (HtmlContainerControl)new HtmlGenericControl("a");
            HtmlAnchor link = new HtmlAnchor();
            //link.Attributes.Add("href", "https://www.youtube.com/watch?v=DWdOZS4p1PM");
            //link.Attributes.Add("rel","prettyPhoto");
            // link.Attributes.Add("href","#");
            //link.Attributes.Add("id", courseId);
            link.ID = courseId;
            link.Name = sectionid;
            link.Attributes.Add("class", "customlink");
            link.Attributes.Add("runat","server");
            link.ServerClick += new EventHandler(CourseClick);
            //link.Attributes.Add("onclick","return true;");
            //HtmlAnchor lnkFre = link as HtmlAnchor;
            //lnkFre.ServerClick += new EventHandler(CourseClick);
            // link.Attributes.Add("onprerender", "setEventHandler");
            if (isChecked(courseId))
            {
                link.InnerHtml = "<i class=\"glyphicon glyphicon-play-circle\" style=\"margin-right:6px;\"></i>" + courseTitle + "<i class=\"glyphicon glyphicon-ok\" style=\"margin-right:6px;\"></i>";
            }
            else {
                link.InnerHtml = "<i class=\"glyphicon glyphicon-play-circle\" style=\"margin-right:6px;\"></i>" + courseTitle + "<i class=\"glyphicon glyphicon-ok seen\" style=\"margin-right:6px;\"></i>";
            }
            //link.Attributes.Add("class", "glyphicon glyphicon-play-circle");
            // link.InnerText = courseTitle;
            list.Controls.Add(link);
            
           // list.InnerText = courseTitle;
            leadList.Controls.Add(list);
            listQty++;
        }

        //add quiz here
        DataTable quiz = new DataTable();
        MySqlDataAdapter quizAdapter = new MySqlDataAdapter();
        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.exam where Id=@sectionid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("sectionid", sectionid);
            quizAdapter.SelectCommand = cmd;
            quizAdapter.Fill(quiz);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
            quizAdapter.Dispose();
        }

        foreach (DataRow row in quiz.Rows) {
            String quizId = row["Id"].ToString();
            String  quizTitle = row["Header"].ToString();
            HtmlGenericControl list = new HtmlGenericControl("li");

            //list.ID = courseId;
            list.Attributes.Add("class", "course-list-item");
            //HtmlContainerControl link = (HtmlContainerControl)new HtmlGenericControl("a");
            HtmlAnchor link = new HtmlAnchor();
            //link.Attributes.Add("href", "https://www.youtube.com/watch?v=DWdOZS4p1PM");
            //link.Attributes.Add("rel","prettyPhoto");
            // link.Attributes.Add("href","#");
            //link.Attributes.Add("id", courseId);
            link.ID = quizId;
            link.Name = courseId;
            //link.Name = sectionid;
            link.Attributes.Add("class", "customlink");
            link.Attributes.Add("runat", "server");
            link.ServerClick += new EventHandler(QuizClick);
            //link.Attributes.Add("onclick","return true;");
            //HtmlAnchor lnkFre = link as HtmlAnchor;
            //lnkFre.ServerClick += new EventHandler(CourseClick);
            // link.Attributes.Add("onprerender", "setEventHandler");
            if (isTaken(quizId))
            {
                link.InnerHtml = "<i class=\"glyphicon glyphicon-pencil\" style=\"margin-right:6px;\"></i>" + quizTitle + "<i class=\"glyphicon glyphicon-ok\" style=\"margin-right:6px;\"></i>";
            }
            else
            {
                link.InnerHtml = "<i class=\"glyphicon glyphicon-pencil\" style=\"margin-right:6px;\"></i>" + quizTitle + "<i class=\"glyphicon glyphicon-ok seen\" style=\"margin-right:6px;\"></i>";
            }
            //link.Attributes.Add("class", "glyphicon glyphicon-play-circle");
            // link.InnerText = courseTitle;
            list.Controls.Add(link);

            // list.InnerText = courseTitle;
            leadList.Controls.Add(list);
            listQty++;
        }

        label.InnerHtml += "<span style=\"float:right\">"+listQty+"</span>";
        return leadList;
    }

    protected Boolean isTaken(string examId) {
        String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.taken where UserId=@userid AND ExamId=@courseId";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("userid", userId);
            cmd.Parameters.AddWithValue("courseId", examId);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return false;
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
            adapter.Dispose();
        }

        return true;
    }


    protected Boolean isChecked(string courseId) {
        String connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        try
        {
            connection.Open();
            String queryString = "SELECT * FROM daifuku.seen where UserId=@userid AND CourseId=@courseId";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("userid", userId);
            cmd.Parameters.AddWithValue("courseId", courseId);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) {
                return false;
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
            adapter.Dispose();
        }

        return true;
    }

    protected void Page_Init(object sender, EventArgs e)
    {



    }

    protected void CourseClick(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        //user.Value = authenticationManager.User.Identity.GetUserId();
        if (authenticationManager.User.Identity.IsAuthenticated)
        {
            userId = authenticationManager.User.Identity.GetUserId();
        }

        using (daifukuEntities db = new daifukuEntities())
        {
            aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userId);
            projectId = user.ProjectId;
        }

        var courseid = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).ID;
        var sectionid = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).Name;

        Response.Redirect("~/Course/Loading.aspx?sectionid=" + sectionid + "&courseid=" + courseid + "&projectid=" +projectId);
    }




    protected void QuizClick(object sender, EventArgs e) {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        //user.Value = authenticationManager.User.Identity.GetUserId();
        if (authenticationManager.User.Identity.IsAuthenticated)
        {
            userId = authenticationManager.User.Identity.GetUserId();
        }

        using (daifukuEntities db = new daifukuEntities())
        {
            aspnetuser user = (aspnetuser)db.aspnetusers.FirstOrDefault(x => x.Id == userId);
            projectId = user.ProjectId;
        }

        var examid = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).ID;
        var courseid = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).Name;

        Response.Redirect("~/Course/Quiz.aspx?examid=" + examid + "&courseid=" + courseid + "&projectid=" + projectId);
    }
}
       
    

    