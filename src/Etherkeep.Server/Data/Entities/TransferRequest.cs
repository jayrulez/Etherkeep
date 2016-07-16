using Etherkeep.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class TransferRequest
    {
        public int Id { get; set; }
        public TransferType Type { get; set; }
    }
}
