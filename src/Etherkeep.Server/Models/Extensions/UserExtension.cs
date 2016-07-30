using Etherkeep.Server.Models.User;
using Entities = Etherkeep.Data.Entities;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static UserModel ToUserModel(this Entities.User source)
        {
            var destination = new UserModel();

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
