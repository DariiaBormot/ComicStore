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

        public void SendEmail(ShippingDetailsBL shippingInfo, CartService cartService)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.Host;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("We've received your order and will contact you as soon as your package is shipped. You can find purchase information below:")
                    .AppendLine("----------")
                    .AppendLine("Products:");


                foreach (var item in cartService.GetCartItems())
                {
                    var subtotal = item.ComicBook.Price * item.Count;
                    body.AppendFormat("{0} x {1} (total: {2:c}",
                        item.Count, item.ComicBook.Name, subtotal);
                }

                body.AppendFormat("Total Price: {0:c}", cartService.GetTotalPrice())
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
                                       emailSettings.MailFromAddress,	
                                       shippingInfo.Email,	            
                                       "Thank you for your order",		
                                       body.ToString()); 				

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
