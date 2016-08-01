using Etherkeep.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Services
{
    public interface IUserActionService
    {
        Task LogAsync(User user, string actionType, IDictionary<string, string> parameters);
    }
}
