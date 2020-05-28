using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ComicStoreBL.Services
{
    public class ContactUsService : IContactUs
    {
        public async Task SendMailAsync(MailFormBL model) 
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("dariiabormot@gmail.com"));
            message.From = new MailAddress("dariiabormot@outlook.com");
            message.Subject = "Your email subject";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "dariiabormot@outlook.com",
                    Password = "Loktankiko25"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

            }
        }
    }
}
