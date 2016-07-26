using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services.Email
{
    public class EmailSenderOptions : IEmailSenderOptions
    {
        private ISmtpOptions SmtpOptions;

        /*private string FromName;
        private string FromAddress;
        private string ReplyToAddress;*/

        public EmailSenderOptions(ISmtpOptions smtpOptions)
        {
            this.SmtpOptions = smtpOptions;
        }
    }
}
