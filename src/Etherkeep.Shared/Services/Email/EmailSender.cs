using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Shared.Services.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailSenderOptions> Options;
        private readonly ILogger logger;

        public EmailSender(IOptions<EmailSenderOptions> options, ILoggerFactory loggerFactory)
        {
            this.Options = options;
            this.logger = loggerFactory.CreateLogger<EmailSender>();
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mailMessage = new MimeMessage();

                mailMessage.From.Add(new MailboxAddress(Options.Value.FromName, Options.Value.FromAddress));

                if (!string.IsNullOrEmpty(Options.Value.ReplyToAddress))
                {
                    mailMessage.ReplyTo.Add(new MailboxAddress(Options.Value.FromName, Options.Value.ReplyToAddress));
                }

                mailMessage.To.Add(new MailboxAddress("", email));

                mailMessage.Subject = subject;

                var builder = new BodyBuilder();

                builder.TextBody = message;

                mailMessage.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(this.Options.Value.Server, this.Options.Value.Port, this.Options.Value.UseSsl)
                        .ConfigureAwait(false);

                    if (this.Options.Value.RequiresAuthentication)
                    {
                        await client.AuthenticateAsync(this.Options.Value.User, this.Options.Value.Password);
                    }

                    await client.SendAsync(mailMessage);

                    await client.DisconnectAsync(true).ConfigureAwait(false);

                    return true;
                }
            }catch(Exception ex)
            {
                this.logger.LogError(ex.Message);

                return false;
            }
        }
    }
}
