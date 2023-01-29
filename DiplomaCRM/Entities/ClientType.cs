using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class ClientType
    {
        public ClientType()
        {
            Clients = new HashSet<Client>();
        }

        public int ClientTypeId { get; set; }
        public string ClientTypeValue { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}
