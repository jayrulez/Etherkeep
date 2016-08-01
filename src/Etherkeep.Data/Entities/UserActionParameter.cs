using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class UserActionParameter
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }

        public virtual UserAction Action { get; set; }
    }
}
