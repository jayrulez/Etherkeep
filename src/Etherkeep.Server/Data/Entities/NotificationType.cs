using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class NotificationType
    {
        public string Id { get; set; }
        public string Template { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
