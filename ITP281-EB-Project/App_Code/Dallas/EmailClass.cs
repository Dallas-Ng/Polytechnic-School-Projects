using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;


/// <summary>
/// Summary description for EmailClass
/// </summary>
public class EmailClass
{
    public EmailClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    /// <summary>
    /// Sends email with information
    /// </summary>
    public static int SendInformation(string email, string text)
    {
        int output = 0;

        try
        {
            string companyEmail = "certcesseducation@gmail.com";
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Static/_Account/Html/Information.html"));

            Body = Body.Replace("#INFORMATION#", text);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(companyEmail);
            message.To.Add(email);
            message.Subject = "Welcome to Certcess!";
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.EnableSsl = true;
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.Send(message);
            output += 1;
        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return output;
    }


    ///
    public static int SendInquiry(string email, string text, string Subject)
    {
        int output = 0;

        try
        {
            string companyEmail = "certcesseducation@gmail.com";
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Static/_Account/Html/Information.html"));

            Body = Body.Replace("#INFORMATION#", text);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(companyEmail);
            message.To.Add(email);
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.EnableSsl = true;
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.Send(message);
            output += 1;
        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return output;
    }



    /// <summary>
    /// Sends email with email confirmation link
    /// </summary>
    public static int SendSignUp(string email)
    {
        int output = 0;
        AccountClass Acc = new AccountClass();

        try
        {
            string companyEmail = "certcesseducation@gmail.com";
            var token = HasherClass.InsertToken(email);
            string link = String.Format("https://Certcess.Azurewebsites.net/Web/A/External_Login.aspx?action=ConfirmEmail&token={0}", token);

            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Static/_Account/Html/EmailConfirm.html"));

            Body = Body.Replace("#USERNAME#", Acc.checkEmail(email));
            Body = Body.Replace("#LINK#", link);
            Body = Body.Replace("#LINK2#", link);



            MailMessage message = new MailMessage();
            message.From = new MailAddress(companyEmail);
            message.To.Add(email);
            message.Subject = "Welcome to Certcess!";
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.EnableSsl = true;
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.Send(message);
            output = 1;
        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return output;
    }



    /// <summary>
    /// Sends teacher approval application with password
    /// </summary>
    public static int sendApplication(string email, string Login_ID, string generatedPassword)
    {
        int output = 0;

        try
        { // Sending email the new teacher
            string companyEmail = "certcesseducation@gmail.com";
            string link = String.Format("Username: {0}\nPassword: {1}", Login_ID, generatedPassword);
            string body = String.Format("Congratulations, you have been approved to be a teacher for Certcess.\n{0} \nPlease change your password on the settings page.\n", link);

            MailMessage message = new MailMessage(companyEmail, email, "Approved Teacher Application", body);

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.EnableSsl = true;
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.Send(message);

            output += 1;
        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return output;
    }


}