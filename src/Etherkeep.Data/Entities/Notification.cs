using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<NotificationParameter> Parameters { get; set; }
    }
}
