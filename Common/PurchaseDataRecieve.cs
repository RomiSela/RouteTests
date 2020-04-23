using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PurchaseDataRecieve : PurchaseData
    {
        public string PurchaseId { get; set; }
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public DateTime DbAddDate { get; set; }
        public double PricePerPayment { get; set; }
        public string IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public PurchaseDataRecieve()
        { }

        public PurchaseDataRecieve(string purchaseId, char storeType, char activityDays, DateTime dbAddDate, double pricePerPayment, string isValid, string whyInvalid, string storeId, string creditCardNumber, string purchaseDate, double purchasePrice, string numberOfPayments) : base(storeId, creditCardNumber, purchaseDate, purchasePrice, numberOfPayments)
        {
            PurchaseId = purchaseId;
            StoreType = storeType;
            ActivityDays = activityDays;
            DbAddDate = dbAddDate;
            PricePerPayment = pricePerPayment;
            IsValid = isValid;
            WhyInvalid = whyInvalid;
        }
    }
}
