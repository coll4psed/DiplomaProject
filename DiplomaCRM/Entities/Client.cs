using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class Client
    {
        public Client()
        {
            Bills = new HashSet<Bill>();
            HelpRequests = new HashSet<HelpRequest>();
            Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public int ClientType { get; set; }
        public string ClientPhone { get; set; } = null!;
        public string ClientEmail { get; set; } = null!;
        public string ClientInn { get; set; } = null!;
        public string ClientAddress { get; set; } = null!;
        public int ClientEmployeeId { get; set; }

        public virtual Employee ClientEmployee { get; set; } = null!;
        public virtual ClientType ClientTypeNavigation { get; set; } = null!;
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<HelpRequest> HelpRequests { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
