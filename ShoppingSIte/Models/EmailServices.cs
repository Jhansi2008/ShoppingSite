using ShoppingSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShoppingSIte.Models
{
    public class EmailServices
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        public void Email(ApplicationUser user,string subject,string body)
        {
            string mailAddress = ConfigurationManager.AppSettings["MailAddress"];
            string smtpClient = ConfigurationManager.AppSettings["SMTPClient"];
            string senderEmail= ConfigurationManager.AppSettings["SenderEmail"];
            string senderPassword= ConfigurationManager.AppSettings["SenderPassword"];
            int port= Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            mail.From = new System.Net.Mail.MailAddress(mailAddress);
            mail.To.Add(user.Email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpClient);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

       
    }
}