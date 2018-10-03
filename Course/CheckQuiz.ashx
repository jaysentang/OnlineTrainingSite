<%@ WebHandler Language="C#" Class="CheckQuiz" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

public class CheckQuiz : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();

        //deserialize the object
        selectAnswer objUsr = new JavaScriptSerializer().Deserialize<selectAnswer>(strJson);
        string Returnmsg = string.Empty;
        if (objUsr != null)
        {

            string examid = context.Request.QueryString["examid"];
            using (Entities db = new Entities())
            {
                var exam = (exam)db.exams.FirstOrDefault(f => f.Id == examid);
                int correct_ans = 0;

                for (int a = 0; a < objUsr.data.Count; a++)
                {
                    var ans = (from t in db.answers.ToList() where t.Id == objUsr.data[a].id && t.QuestionId == objUsr.data[a].question select t); //db.answers.Where(x => (x.Id == objUsr.data[a].id) && (x.QuestionId == objUsr.data[a].question))
                    foreach (var i in ans)
                    {
                        if (i.IsAnswer)
                        {
                            correct_ans++;

                        }
                    }



                }
                UpdateTaken(examid);
                Returnmsg = correct_ans + "/" + exam.TotalPoints;
                context.Response.Write(Returnmsg);
            }


        }
        else {
            context.Response.Redirect("~/Error/CustomErrorPage.aspx");
        }
    }


    public void UpdateTaken(String courseid)
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
            String queryString = "SELECT * from daifuku.taken where UserId=@userid AND ExamId=examid";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@userid", userId);
            cmd.Parameters.AddWithValue("@examid", courseid);
            MySqlDataReader reader = cmd.ExecuteReader();
            bool flag = false;
            if (!reader.HasRows)
            { //insert
                flag = true;
                reader.Close();
            }

            if (flag) {

                queryString  = "INSERT INTO daifuku.taken VALUES(@userid, @courseid)";
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

    public class selectAnswer{
        public List<details> data { get; set; }
    }

    public class details {
        public string id { get; set; }
        public string question { get; set; }
    }


}