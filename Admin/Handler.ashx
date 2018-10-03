<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        try
        {
            string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();

            //deserialize the object
            subject objUsr = new JavaScriptSerializer().Deserialize<subject>(strJson);

            if (objUsr != null)
            {
                using (Entities db = new Entities()) {
                    exam Exam = (exam)db.exams.FirstOrDefault(x => x.Id == objUsr.Id);
                    if (Exam != null)
                    {
                        question Question = new question();
                        Question.Id = Guid.NewGuid().ToString();
                        Question.Text = objUsr.Questions;
                        // Question.Points = objUsr.point;
                        Question.ExamId = Exam.Id;
                        for (int a = 0; a < objUsr.answers.Count; a++)
                        {
                            answer Answer = new answer();
                            Answer.Id = Guid.NewGuid().ToString();
                            Answer.Text = objUsr.answers[a].answer;
                            if (objUsr.correct_answer == a)
                            {
                                Answer.IsAnswer = true;
                            }
                            else
                            {
                                Answer.IsAnswer = false;
                            }
                            Answer.QuestionId = Question.Id;
                            Question.answers.Add(Answer);

                        }

                        Exam.questions.Add(Question);
                        db.SaveChanges();
                    }
                    else
                    {

                        Exam = new exam();
                        Exam.Id = objUsr.Id;
                        Exam.Header = objUsr.Header;

                        question Question = new question();

                        Question.Id = Guid.NewGuid().ToString();
                        Question.Text = objUsr.Questions;
                        // Question.Points = objUsr.point;
                        Question.ExamId = Exam.Id;
                        for (int a = 0; a < objUsr.answers.Count; a++)
                        {
                            answer Answer = new answer();
                            Answer.Id = Guid.NewGuid().ToString();
                            Answer.Text = objUsr.answers[a].answer;
                            if (objUsr.correct_answer == a)
                            {
                                Answer.IsAnswer = true;
                            }
                            else
                            {
                                Answer.IsAnswer = false;
                            }
                            Answer.QuestionId = Question.Id;
                            Question.answers.Add(Answer);

                        }
                        //Question.exam = Exam;
                        Exam.questions.Add(Question);



                        db.exams.Add(Exam);
                        db.SaveChanges();

                    }
                    var total = db.questions.Where(y => y.ExamId == Exam.Id).Count();//.Sum(x => x.Points);
                    Exam.TotalPoints = total;
                    if (db.Entry(Exam).State == System.Data.Entity.EntityState.Modified)
                    {
                        db.SaveChanges();
                    }
                    //set quiz in coursesection to true
                    coursesection section = (coursesection)db.coursesections.FirstOrDefault(x => x.Id == objUsr.Id);
                    if (section != null && section.Quiz==false)
                    {
                        section.Quiz = true;
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                context.Response.Redirect("~/Error/CustomErrorPage.aspx");
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("Error :" + ex.Message);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

    public class subject {

        public string Id { get; set; }
        public string Header { get; set; }
        public string Questions { get; set; }
        public List<details> answers { get; set; }
        public int correct_answer { get; set; }
        //public int point { get; set; }
    }
    public class details {
        public string id { get; set; }
        public string answer { get; set; }


    }

}