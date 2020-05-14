using ComicStoreBL.Interfaces;
using ComicStoreBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Services
{
    public class EmailOrderProcessorService : IMailOrderProcessor
    {
        private readonly EmailSettingsBL emailSettings;

        public EmailOrderProcessorService(EmailSettingsBL settings)
        {
            emailSettings = settings;
        }

        public void SendEmail(Cart cart, OrderDetailsBL shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New order is processed")
                    .AppendLine("---")
                    .AppendLine("Products:");

                foreach (var item in cart.GetAllProducts)
                {
                    var subtotal = item.ComicBookBL.Price * item.Quantity;
                    body.AppendFormat("{0} x {1} (total: {2:c}",
                        item.Quantity, item.ComicBookBL.Name, subtotal);
                }

                body.AppendFormat("Total Price: {0:c}", cart.GetTotalPrice())
                    .AppendLine("---")
                    .AppendLine("Shipping details:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.Street)
                    .AppendLine(shippingInfo.Appartment ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.PhoneNumber.ToString())
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,	// from
                                       emailSettings.MailToAddress,		// to 
                                       "New order is shipped!",		    // theme
                                       body.ToString()); 				// body

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
