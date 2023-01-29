using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int OrderType { get; set; }
        public int OrderClientId { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly? OrderCompleteDate { get; set; }
        public int OrderStatus { get; set; }
        public decimal? OrderSum { get; set; }
        public string? OrderDescription { get; set; }

        public virtual Client OrderClient { get; set; } = null!;
        public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;
        public virtual OrderType OrderTypeNavigation { get; set; } = null!;
    }
}
