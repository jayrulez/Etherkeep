using System;
using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ActivityParam> ActivityParams { get; set; }
    }
}
