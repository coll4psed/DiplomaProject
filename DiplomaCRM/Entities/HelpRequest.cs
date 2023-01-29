using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class HelpRequest
    {
        public int HelpId { get; set; }
        public int HelpClientId { get; set; }
        public string HelpSubject { get; set; } = null!;
        public DateOnly HelpDate { get; set; }
        public string? HelpDescription { get; set; }
        public int HelpStatus { get; set; }

        public virtual Client HelpClient { get; set; } = null!;
        public virtual HelpStatus HelpStatusNavigation { get; set; } = null!;
    }
}
