using Etherkeep.Data.Entities;
using OpenIddict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Etherkeep.Shared.Identity
{
    public class ApplicationUserManager : OpenIddictUserManager<User>
    {
        public ApplicationUserManager(IServiceProvider services, IOpenIddictUserStore<User> store, IOptions<IdentityOptions> options, ILogger<OpenIddictUserManager<User>> logger, IPasswordHasher<User> hasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors) 
            : base(services, store, options, logger, hasher, userValidators, passwordValidators, keyNormalizer, errors)
        {
        }
    }
}
