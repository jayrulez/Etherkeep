using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Shared.Services.Sms
{
    public class SmsSender: ISmsSender
    {
        private readonly IOptions<SmsSenderOptions> options;
        private readonly ILogger logger;
        public SmsSender(IOptions<SmsSenderOptions> options, ILoggerFactory loggerFactory)
        {
            this.options = options;
            this.logger = loggerFactory.CreateLogger<SmsSender>();
        }

        public Task<bool> SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult<bool>(false);
        }
    }
}
