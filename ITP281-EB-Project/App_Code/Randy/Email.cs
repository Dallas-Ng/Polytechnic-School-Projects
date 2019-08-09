using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    public Email()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int SendInvoice(string email, string text)
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
            message.IsBodyHtml = true;
            message.Subject = "Invoice";
            message.Body = Body;

            SmtpClient cilent = new SmtpClient("smtp.gmail.com", 587);
            cilent.Credentials = new System.Net.NetworkCredential(companyEmail, "Eb180522Y");
            cilent.EnableSsl = true;
            cilent.Send(message);
        }
        catch (Exception ex)
        {
            string error = ex.StackTrace;
        }

        return output;
    }
}