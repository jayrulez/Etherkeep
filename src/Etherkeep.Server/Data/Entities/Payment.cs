using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
