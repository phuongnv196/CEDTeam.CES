﻿using CEDTeam.CES.Core.Dtos.Email;
using CEDTeam.CES.Core.Interfaces.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace CEDTeam.CES.Infrastructure.Implements.Services
{
    public class EmailService : IEmailService
    {
        private void Send(OutlookMailDto mailDto)
        {
            using (var client = new SmtpClient())
            {
                MimeMessage message = new MimeMessage();
                MailboxAddress from = new MailboxAddress("Vinet Team", "vinetteam@outlook.com");
                message.From.Add(from);
                MailboxAddress to = new MailboxAddress(mailDto.EmailAdress);
                message.To.Add(to);
                message.Subject = mailDto.Subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = mailDto.Html;
                bodyBuilder.TextBody = mailDto.Message;
                message.Body = bodyBuilder.ToMessageBody();

                client.Connect("smtp.office365.com", 587, false);
                client.Authenticate("vinetteam@outlook.com", "vinet@2020");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendEmailWellcome(string email)
        {
            var mail = new OutlookMailDto();
            mail.Subject = "[VinetTeam] - Xác minh tài khoản.";
            mail.Html = @"<p><span style=""color: #ff9900;"">Ch&agrave;o mừng {0} đến với Vinet</span>,&nbsp;</p>"
                        + @"<p>Đ&acirc;y l&agrave; email tự động vui l&ograve;ng kh&ocirc;ng trả lời email n&agrave;y.</p>"
                        + @"<p><span style=""color: #00ff00;""><em>Thanks and Regard.</em></span></p>";
            mail.EmailAdress = email;
            Send(mail);
        }
    }
}