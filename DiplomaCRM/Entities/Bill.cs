using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public DateOnly BillDate { get; set; }
        public int BillSenderInfoId { get; set; }
        public int BillClientId { get; set; }
        public int BillOrderTypeId { get; set; }
        public string BillOrderNameGoods { get; set; } = null!;
        public int BillOrderCountGoods { get; set; }
        public decimal BillOrderPrice { get; set; }
        public decimal BillOrderCost { get; set; }

        public virtual Client BillClient { get; set; } = null!;
        public virtual OrderType BillOrderType { get; set; } = null!;
        public virtual CompanyPaymentInfo BillSenderInfo { get; set; } = null!;
    }
}
