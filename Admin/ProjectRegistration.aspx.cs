using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProjectRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        using (daifukuEntities1 db = new daifukuEntities1()) {
            int counter = db.projects.Count(x => x.Text == Project.Text);
            if (counter == 0) {
                project Project = new project();
                Project.Id = Guid.NewGuid().ToString();
                Project.Text = this.Project.Text;
                db.Entry(Project).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                ErrorMessage.Text = "Section Added.";
                message.Attributes["class"] = "text-success";
                this.Project.Text = "";
            }

            else
            {
                ErrorMessage.Text = "Project already exist, please try alternative name.";
            }
        }

    }
}