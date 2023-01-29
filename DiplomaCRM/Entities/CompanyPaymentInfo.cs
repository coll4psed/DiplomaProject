using System;
using System.Collections.Generic;

namespace DiplomaCRM.Entities
{
    public partial class CompanyPaymentInfo
    {
        public CompanyPaymentInfo()
        {
            Bills = new HashSet<Bill>();
        }

        public int InfoId { get; set; }
        public string InfoInn { get; set; } = null!;
        public string InfoFullName { get; set; } = null!;
        public string InfoAddress { get; set; } = null!;
        public string InfoBookkeeper { get; set; } = null!;
        public string InfoBankName { get; set; } = null!;
        public string InfoBankCity { get; set; } = null!;
        public string InfoPaymentAccount { get; set; } = null!;
        public string InfoBik { get; set; } = null!;
        public string InfoCorrespondentAccount { get; set; } = null!;

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
