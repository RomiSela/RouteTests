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
        public double PurchasePrice { get; set; }
        public string NumberOfPayments { get; set; }

        public PurchaseData()
        { }

        public PurchaseData(string storeId, string creditCardNumber, string purchaseDate, double purchasePrice, string numberOfPayments)
        {
            StoreId = storeId;
            CreditCardNumber = creditCardNumber;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            NumberOfPayments = numberOfPayments;
        }

        public override string ToString()
        {
            string s = $"{StoreId},{CreditCardNumber},{PurchaseDate},{PurchasePrice},{NumberOfPayments}";
            return s;
        }

        public static PurchaseData RandomData()
        {
            return new PurchaseData($"DD{Generate.GenerateA5DigitsNumber()}", "4557446145890236", "2019-09-03", 100.0, null);
        }
    }
}
