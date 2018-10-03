<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using MySql.Data.MySqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Configuration;
using System.Data;

public class Handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        if (context.Request.QueryString["method"] == null || context.Request.QueryString["sectionid"]==null || context.Request.QueryString["courseid"] == null) {

            //forward to error page
            context.Response.Redirect("~/Error/CustomErrorPage.aspx");

        }

        else {
            string methodname = context.Request.QueryString["method"];
            string courseid = context.Request.QueryString["courseid"];
            string sectionid = context.Request.QueryString["sectionid"];
            string projectid = context.Request.QueryString["projectid"];
            // MsgResponse objResponse = new MsgResponse();
            string Returnmsg = string.Empty;
            switch (methodname)
            {
                case "getupdate":
                    context.Response.ContentType = "text/plain";
                    UpdateSeen(courseid);
                    break;
            }
            //check next order of the current video
            DataTable table = checknextvideo(courseid, sectionid, projectid);
            for (int a = 0; a < table.Rows.Count; a++) {
                if (table.Rows[a]["sectionid"].ToString().Equals(sectionid) && table.Rows[a]["courseid"].ToString().Equals(courseid)) {
                    if (table.Rows[a]["Quiz"].ToString().Equals(Boolean.TrueString) && !table.Rows[a]["SectionOrder"].ToString().Equals(table.Rows[a+1]["SectionOrder"].ToString())){
                        Returnmsg = table.Rows[a + 1]["sectionid"].ToString() + "," + table.Rows[a + 1]["courseid"].ToString() + "," + true + "," + table.Rows[a]["sectionid"].ToString();
                    }
                    else if(a + 1 != table.Rows.Count)
                    {
                        Returnmsg = table.Rows[a + 1]["sectionid"].ToString() + "," + table.Rows[a + 1]["courseid"].ToString() + "," + false;
                    }
                    break;
                }

            }
            //
            // foreach (DataRow dr in table.Rows) {
            //   if (dr["sectionid"].ToString().Equals(sectionid) && dr["courseid"].ToString().Equals(courseid)) {

            //            }
            //       }
            context.Response.Write(Returnmsg);
        }
    }

    public DataTable checknextvideo(String courseid, String sectionid, String projectid) {
        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        DataTable table = new DataTable();

        try
        {
            connection.Open();
            String queryString = "SELECT coursesection.Id as sectionid, coursesection.Quiz ,coursesection.SectionOrder,course.Id as courseid, course.CourseOrder FROM daifuku.coursesection, daifuku.course where coursesection.ProjectId=@projectid AND coursesection.Id = course.SectionId order by SectionOrder, CourseOrder";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("projectid", projectid);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) {
                table.Load(reader);
            }

        }
        catch (Exception ex)
        {

        }

        finally
        {
            connection.Close();
        }
        return table;
    }

    public void UpdateSeen(String courseid)
    {
        String userId = null;
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        if (authenticationManager.User.Identity.IsAuthenticated)
        {
            userId = authenticationManager.User.Identity.GetUserId();
        }

        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            String queryString = "Select * from daifuku.seen where UserId=@userid AND CourseId=@courseid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@userid", userId);
            cmd.Parameters.AddWithValue("@courseid", courseid);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            if (!reader.HasRows)
            { //insert
                flag = true;
                reader.Close();
            }
            if (flag) {

                queryString = "INSERT INTO daifuku.seen VALUES(@userid, @courseid)";
                cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.Parameters.AddWithValue("@courseid", courseid);
                if (cmd.ExecuteNonQuery() >= 1)
                {

                }
            }
        }
        catch (Exception ex)
        {

        }

        finally
        {
            connection.Close();
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}