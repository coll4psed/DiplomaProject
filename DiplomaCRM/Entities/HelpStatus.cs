using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class HelpStatus
    {
        public HelpStatus()
        {
            HelpRequests = new HashSet<HelpRequest>();
        }

        public int HelpStatusId { get; set; }
        public string HelpStatusValue { get; set; } = null!;

        public virtual ICollection<HelpRequest> HelpRequests { get; set; }
    }
}
