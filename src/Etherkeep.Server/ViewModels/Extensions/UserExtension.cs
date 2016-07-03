using Etherkeep.Server.Data.Entities;

namespace Etherkeep.Server.ViewModels.Extensions
{
    public static partial class Extensions
    {
        public static UserViewModel ToViewModel(this User source)
        {
            var destination = new UserViewModel();

            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.EmailAddress = source.PrimaryEmailAddress?.PrimaryEmailAddress;
            destination.MobileNumber = source.PrimaryMobileNumber?.MobileNumber.Canonical;
            destination.PinCodeSet = !string.IsNullOrEmpty(source.PinCode);

            return destination;
        }
    }
}
