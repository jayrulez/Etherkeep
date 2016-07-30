using Etherkeep.Server.Models.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static ErrorModel GetErrorResponse(this ModelStateDictionary source)
        {
            if(source != null)
            {
                foreach(var modelState in source)
                {
                    foreach(var error in modelState.Value.Errors)
                    {
                        return new ErrorModel { ErrorDescription = error.ErrorMessage };
                    }
                }
            }

            return new ErrorModel() { ErrorDescription = string.Empty };
        }
    }
}
