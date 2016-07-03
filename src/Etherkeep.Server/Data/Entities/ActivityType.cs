using System.Collections.Generic;

namespace Etherkeep.Server.Data.Entities
{
    public class ActivityType
    {
        public string Id { get; set; }
        public string Template { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
