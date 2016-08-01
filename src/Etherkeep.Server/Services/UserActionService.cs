using Etherkeep.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etherkeep.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Etherkeep.Server.Services
{
    public class UserActionService : IUserActionService
    {
        private ApplicationDbContext _dbContext;
        private ILogger _logger;

        public UserActionService(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<UserActionService>();
        }

        public async Task LogAsync(User user, string actionType, IDictionary<string, string> parameters = null)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (actionType == null)
                {
                    throw new ArgumentNullException(nameof(actionType));
                }

                var userAction = new UserAction();

                userAction.User = user;
                userAction.ActionType = actionType;

                if(parameters != null)
                {
                    foreach(var parameter in parameters)
                    {
                        userAction.Parameters.Add(new UserActionParameter()
                        {
                            Parameter = parameter.Key,
                            Value = parameter.Value
                        });
                    }
                }

                _dbContext.UserActions.Add(userAction);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
