using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // TODO: weird naming. its not clear if it's the output or input
    public class PurchaseDataRecieve : PurchaseData
    {
        public string PurchaseId { get; set; }
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }

        // TODO: it's called insertion time. you should use the same name.
        public DateTime DbAddDate { get; set; }
        public double PricePerPayment { get; set; }
        public string IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public PurchaseDataRecieve()
        { }

        // TODO: why do you need this? you're probably not going to use it...
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
