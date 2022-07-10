using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace AgendaMais.Util
{
    public static class SendMail
    {
        public static void Send(string subject, string body, string to)
        {
            MailAddress fromAddress = new MailAddress("batistamza@gmail.com", "Moisés Batista da Silva");
            MailAddress toAddress = new MailAddress(to);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromAddress.Address, "qsukhaqjuybtsfsh");

            using var message = new MailMessage();

            message.From = fromAddress;
            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            smtp.Send(message);
        }
    }
}
