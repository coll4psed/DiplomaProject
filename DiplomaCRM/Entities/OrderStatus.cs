using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusValue { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
