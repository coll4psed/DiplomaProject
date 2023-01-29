using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class OrderType
    {
        public OrderType()
        {
            Bills = new HashSet<Bill>();
            Orders = new HashSet<Order>();
        }

        public int OrderTypeId { get; set; }
        public string OrderTypeValue { get; set; } = null!;

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
