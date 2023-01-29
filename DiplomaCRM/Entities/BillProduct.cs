using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class BillProduct
    {
        public int BillProductId { get; set; }
        public int BillId { get; set; }
        public string BillProductName { get; set; } = null!;
        public int BillProductQuantity { get; set; }
        public decimal BillProductPrice { get; set; }

        public virtual Bill Bill { get; set; } = null!;
    }
}
