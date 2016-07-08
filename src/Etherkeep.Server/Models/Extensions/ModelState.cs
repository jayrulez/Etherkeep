using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models.Extensions
{
    public static partial class Extensions
    {
        public static ResponseModel<ErrorModel> GetErrorResponse(this ModelStateDictionary source)
        {
            if(source != null)
            {
                foreach(var modelState in source)
                {
                    foreach(var error in modelState.Value.Errors)
                    {
                        return new ResponseModel<ErrorModel>(new ErrorModel() { ErrorDescription = error.ErrorMessage });
                    }
                }
            }

            return new ResponseModel<ErrorModel>(new ErrorModel() { ErrorDescription = string.Empty });
        }
    }
}
