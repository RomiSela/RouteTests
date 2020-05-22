using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PurchaseData
    {
        public string StoreId { get; set; }
        public string CreditCardNumber { get; set; }
        public string PurchaseDate { get; set; }
        public string PurchasePrice { get; set; }
        public string NumberOfPayments { get; set; }

        public PurchaseData()
        { }

        public PurchaseData(string storeId, string creditCardNumber, string purchaseDate, string purchasePrice, string numberOfPayments)
        {
            StoreId = storeId;
            CreditCardNumber = creditCardNumber;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            NumberOfPayments = numberOfPayments;
        }

        public override string ToString()
        {
            if (NumberOfPayments != null)
            {
                return $"{StoreId},{CreditCardNumber},{PurchaseDate},{PurchasePrice},{NumberOfPayments}";
            }
            return $"{StoreId},{CreditCardNumber},{PurchaseDate},{PurchasePrice}";
        }

    }
}
