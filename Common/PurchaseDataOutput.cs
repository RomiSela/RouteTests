using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PurchaseDataOutput : PurchaseData
    {
        public string PurchaseId { get; set; }
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public DateTime InsertionDate { get; set; }
        public double PricePerPayment { get; set; }
        public string IsValid { get; set; }
        public string WhyInvalid { get; set; }

    }
}
