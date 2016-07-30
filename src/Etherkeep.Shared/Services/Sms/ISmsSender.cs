using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Shared.Services.Sms
{
    public interface ISmsSender
    {
        Task<bool> SendSmsAsync(string number, string message);
    }
}
