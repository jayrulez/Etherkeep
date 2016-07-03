using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherkeep.Server.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public NotificationType NotificationType { get; set; }
        public virtual User User { get; set; }
        public virtual User SubjectUser { get; set; }
        public virtual ICollection<NotificationParam> NotificationParams { get; set; }
    }
}
