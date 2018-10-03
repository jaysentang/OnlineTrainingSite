using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for PasswordReset
/// </summary>
public class PasswordReset
{
    public PasswordReset(String userid, String useremail, String passwordToken)
    {
        //
        // TODO: Add constructor logic here
        //

        String connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connectionString);
        string activationCode = Guid.NewGuid().ToString();

        try
        {

            connection.Open();
            String queryString = "INSERT INTO daifuku.aspnetactivation VALUES(@userid, @activationcode)";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@activationcode", activationCode);
            HttpRequest request = HttpContext.Current.Request;
            if (cmd.ExecuteNonQuery() >= 1)
            {
                //string test = request.Url.AbsoluteUri.Replace("Admin/Register2", Convert.ToString("Account/Activation.aspx?ActivationCode="));
                MailMessage mail = new MailMessage("qatestreport@daifuku.com.sg", useremail);
                mail.Subject = "Password Reset";
                string body = "Hello, welcome to Daifuku Training Site";
                body += "<br /><br />Please click the following link to reset your password.";
                body += "<br /><a href = " + "http://203.149.185.100/Training/Account/ConfirmResetPassword.aspx?UserId=" + userid + "&Token="+passwordToken +">Reset Password.</a>";
                body += "<br /><br />Thanks";
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.daifuku.com.sg";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential("qatestreport@daifuku.com.sg", "D@ifuku!1");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mail);



            }
            else
            {

            }

        }
        catch (Exception ex)
        {

            this.error_message = ex.Message;
        }
        finally
        {
            connection.Close();

        }

    }

    public string error_message
    {
        get; set;
    }
}