using Etherkeep.Server.ViewModels.Account;
using Etherkeep.Server.ViewModels.User;
using Entities = Etherkeep.Server.Data.Entities;

namespace Etherkeep.Server.ViewModels.Extensions
{
    public static partial class Extensions
    {
        public static UserViewModel ToUserViewModel(this Entities.User source)
        {
            var destination = new UserViewModel();

            if (source != null)
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
