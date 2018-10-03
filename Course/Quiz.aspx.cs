using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Course_Quiz : System.Web.UI.Page
{
    //public exam Exam;
    //protected DataTable table;
    protected List<question> questionList = new List<question>();
    public void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(Request.QueryString["examid"]))
        {

            using (Entities db = new Entities())
            {

                var exam = (from a in db.questions.ToList()
                            where a.ExamId == Request.QueryString["examid"]

                            select new
                            {
                                question = a,
                                answer = from answer in db.answers.ToList()
                                         where answer.QuestionId == a.Id
                                         select answer

                            }).ToList();




                foreach (var i in exam)
                {
                    question q = new question();
                    q.Id = i.question.Id;
                    q.Text = i.question.Text;
                    //q.Points = i.question.Points;
                    q.ExamId = i.question.ExamId;
                    foreach (var t in i.answer)
                    {
                        q.answers.Add(new answer() { Id = t.Id, IsAnswer = t.IsAnswer, QuestionId = t.QuestionId, Text = t.Text });

                    }
                    q.answers = q.answers.OrderBy(s => Guid.NewGuid()).ToList();
                    questionList.Add(q);
                }
                questionList = questionList.OrderBy(f => Guid.NewGuid()).ToList();
            }
            //title
            String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                String queryString = "SELECT * FROM daifuku.coursesection WHERE Id=@sectionid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@sectionid", Request.QueryString["examid"]);
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();
            }

            foreach (DataRow datarow in table.Rows)
            {

                Header.InnerText = datarow["Header"].ToString() + " - Quiz";
                Page.Title = datarow["Header"].ToString();

            }

        }
        else {

            //error page

            Response.Redirect("~/Error/CustomErrorPage.aspx");
        } 
       
    }
}