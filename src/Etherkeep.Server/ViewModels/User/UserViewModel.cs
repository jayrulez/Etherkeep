using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailAddressVerified { get; set; }
        public string MobileNumber { get; set; }
        public bool MobileNumberVerified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
