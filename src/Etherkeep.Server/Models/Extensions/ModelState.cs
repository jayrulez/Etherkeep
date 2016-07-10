using Etherkeep.Server.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static ResponseModel<ErrorViewModel> GetErrorResponse(this ModelStateDictionary source)
        {
            if(source != null)
            {
                foreach(var modelState in source)
                {
                    foreach(var error in modelState.Value.Errors)
                    {
                        return new ResponseModel<ErrorViewModel>(new ErrorViewModel() { ErrorDescription = error.ErrorMessage });
                    }
                }
            }

            return new ResponseModel<ErrorViewModel>(new ErrorViewModel() { ErrorDescription = string.Empty });
        }
    }
}
