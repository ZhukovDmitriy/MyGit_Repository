using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace Portfolio.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "zhukov160288@gmail.com";
        public string MailFromAddress = "code4net@user11007.realhost-free.net";
        public bool UseSsl = true;
        public string UserName = "Dmitriy";
        public string Password = "Dima32167_";
        public string ServerName = "scp.realhost.pro";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"d:\portfolio-message";
    }

    public class EmailOrderProcessor
    {
        public EmailSettings emailSettings;

        public void ProcessOrder(ShippingDetails shippingInfo)
        {
            emailSettings = new EmailSettings();

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation
                        = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()

                    .AppendLine("A new order has been submited")
                    .AppendLine("---")
                    .AppendLine("Items:");

                body.AppendFormat("Total order value: ")
                    .AppendLine("---")
                    .AppendLine("Ship to: ")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Phone)
                    .AppendLine(shippingInfo.Message)
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "New order submited!",
                    body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
