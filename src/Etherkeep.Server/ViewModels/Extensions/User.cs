using Etherkeep.Server.Data.Entities;
using Etherkeep.Server.ViewModels.Account;

namespace Etherkeep.Server.ViewModels.Extensions
{
    public static partial class Extensions
    {
        public static ProfileViewModel GetProfileViewModel(this User source)
        {
            var destination = new ProfileViewModel();

            if(source != null)
            {
                destination.Id = source.Id;
                destination.UserName = source.UserName;
                destination.EmailAddress = source.Email;
                destination.EmailAddressVerified = source.EmailConfirmed;
                destination.MobileNumber = source.PhoneNumber;
                destination.MobileNumberVerified = source.PhoneNumberConfirmed;
                destination.FirstName = source.FirstName;
                destination.LastName = source.LastName;
            }

            return destination;
        }
    }
}
