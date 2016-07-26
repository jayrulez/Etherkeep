using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services.Email
{
    public class EmailSender : IEmailSender
    {
        private IEmailSenderOptions Options;

        public EmailSender(IEmailSenderOptions options)
        {
            this.Options = options;
        }
        public void SendEmail()
        {

        }
    }
}
