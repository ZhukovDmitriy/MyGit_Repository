using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using CompAccessory.Domain.Abstract;
using CompAccessory.Domain.Entites;

namespace CompAccessory.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "order@example.com";
        public string MailFromAddress = "compaccessory@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\comp_accessory_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            // Класс SmtpClient предназначен для работы с протоколом SMTP и отправки электронной почты
            using (var smtpClient = new SmtpClient())
            {
                // Этот класс определяет ряд свойств, которые позволяют настроить отправку:

                // EnableSsl: указывает, будет ли использоваться протокол SSL при отправке.
                // SSL (Secure Sockets Layer - уровень защищенных сокетов) представляет собой криптографический протокол,
                // который обеспечивает защищенную передачу информации в Интернете.
                smtpClient.EnableSsl = emailSettings.UseSsl;

                // Host: smtp-сервер, с которого производится отправление почты. Например, smtp.yandex.ru
                // SMTP (англ. Simple Mail Transfer Protocol — простой протокол передачи почты)
                // — это широко используемый сетевой протокол, предназначенный для передачи электронной почты в сетях TCP/IP.
                smtpClient.Host = emailSettings.ServerName;

                // Port: порт, используемый smtp-сервером. Если не указан, то по умолчанию используется 25 порт.
                smtpClient.Port = emailSettings.ServerPort;

                smtpClient.UseDefaultCredentials = false;

                // Credentials: аутентификационные данные отправителя ( Аутентификация — процедура проверки подлинности)
                smtpClient.Credentials =
                                    // Для аутентификации пользователя создадим экземпляр класса NetworkCredential. 
                                    // Этот класс обеспечивает информацию с целью удостоверения личности пользователя для базовой аутентификации
                                    new NetworkCredential(emailSettings.Username, emailSettings.Password);

                // Если поставить WriteAsFile = true, то сообщения электронной почты будут записываться в файл внутри каталога,
                // указанного в свойстве FileLocation. Этот каталог должен существовать и допускать запись. 
                // Записанные файлы имеют расширение .eml и могут быть прочитаны с помощью любого текстового редактора
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()

                    // AppendLine добавляет знак завершения строки по умолчанию в конец текущего объекта StringBuilder
                    // [Пример:]
                    // StringBuilder sb = new StringBuilder();
                    // string line = "A line of text.";

                    // sb.AppendLine("The first line of text.");
                    // sb.AppendLine(line);

                    // [Результат:]
                    // The first line of text.
                    // A line of text.

                    .AppendLine("Новый заказ был отправлен")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Accessory.Price * line.Quantity;
                    // AppendFormat	добавляет строку, сформированную в соответствии со спецификатором формата {0} {1} и т.д.
                    body.AppendFormat("{0} x {1} (итого: {2:c})", line.Quantity, line.Accessory.Name, subtotal);
                }

                body.AppendFormat("Общая стоимость заказа: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Email)
                    .AppendLine(shippingInfo.Line)
                    .AppendLine(shippingInfo.City);

                // MailMessage. Данный класс представляет собой отправляемое сообщение
                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,              // От кого
                    emailSettings.MailToAddress,                // Кому
                    "Новый заказ отправлен!",                   // Тема
                    body.ToString());                           // Тело письма

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
