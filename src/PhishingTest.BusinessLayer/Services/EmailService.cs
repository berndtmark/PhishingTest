using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using PhishingTest.Models.Models;
using Microsoft.Extensions.Options;

namespace PhisingTest.BusinessLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _EmailSetting;

        public EmailService(IOptions<EmailSetting> settings)
        {
            _EmailSetting = settings.Value;
        }

        public async Task SendEmailAsync(string emailAddress, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_EmailSetting.FromName, _EmailSetting.FromAddress));
            emailMessage.To.Add(new MailboxAddress("", emailAddress));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                //client.LocalDomain = "some.domain.com";
                await client.ConnectAsync(_EmailSetting.SmtpServer, 25, SecureSocketOptions.Auto).ConfigureAwait(false);
                await client.AuthenticateAsync(_EmailSetting.UserName, _EmailSetting.Password);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
