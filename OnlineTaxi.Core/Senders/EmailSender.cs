using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Domain.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace OnlineTaxi.Core.Senders
{
    public static class EmailSender
    {

        public static bool Send(string to, string subject, string body)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress fromMailAddress = new MailboxAddress("aghil", "aghil1373@gmail.com");
            message.From.Add(fromMailAddress);

            MailboxAddress toMailAddress = new MailboxAddress("User", to);
            message.To.Add(toMailAddress);

            message.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;

            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, true);
            smtpClient.Authenticate("Aghil1373@gmail.com", "zluhsfmkjkjkvwuq");

            smtpClient.Send(message);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();


            return true;
        }
    }
}
