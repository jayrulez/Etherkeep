using Etherkeep.Server.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel(T result)
        {
            this.Result = result;
        }

        public T Result { get; set; }
        public bool Success
        {
            get
            {
                return !(Result is ErrorViewModel);
            }
        }
    }
}
