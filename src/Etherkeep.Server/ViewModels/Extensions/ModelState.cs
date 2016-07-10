﻿using Etherkeep.Server.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etherkeep.Server.ViewModels.Extensions
{
    public static partial class Extensions
    {
        public static ResponseViewModel<ErrorViewModel> GetErrorResponse(this ModelStateDictionary source)
        {
            if(source != null)
            {
                foreach(var modelState in source)
                {
                    foreach(var error in modelState.Value.Errors)
                    {
                        return new ResponseViewModel<ErrorViewModel>(new ErrorViewModel() { ErrorDescription = error.ErrorMessage });
                    }
                }
            }

            return new ResponseViewModel<ErrorViewModel>(new ErrorViewModel() { ErrorDescription = string.Empty });
        }
    }
}