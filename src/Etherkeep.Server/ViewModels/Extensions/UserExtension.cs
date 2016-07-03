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
            destination.Email = source.Email;
            destination.PhoneNumber = source.PhoneNumber;

            return destination;
        }
    }
}
