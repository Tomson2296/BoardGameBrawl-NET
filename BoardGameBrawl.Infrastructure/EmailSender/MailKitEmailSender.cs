using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure.EmailSender
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailKitEmailSender(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string message)
        {
            try
            {
                // Using saved EmailConfiguration
                var username = _configuration.GetSection("EmailConfiguration:Username").Value;
                var smtp = _configuration.GetSection("EmailConfiguration:Smtp").Value;
                bool portParsed = int.TryParse(_configuration.GetSection("EmailConfiguration:Port").Value, out int port);
                var from = _configuration.GetSection("EmailConfiguration:From").Value;
                var password = _configuration.GetSection("EmailConfiguration:Password").Value;

                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Text) { Text = message };

                // send email using OAuth 2.0 Google credentials
                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, port, SecureSocketOptions.StartTls);
                    client.Authenticate(username, password);
                    client.Send(email);
                    client.Disconnect(true);
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
