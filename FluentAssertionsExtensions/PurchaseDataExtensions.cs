using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace FluentAssertionsExtensions
{
    public static class PurchaseDataExtensions
    {
        public static void CreateValidRecord(this PurchaseData p)
        {
            p.StoreId = $"AA{Generate.GenerateA5DigitsNumber()}";
            p.CreditCardNumber = "4557446145890236";
            p.PurchaseDate = "2019-09-03";
            p.PurchasePrice = 100.0;
        }

        public static void CreateInvalidCredirCardRecord(this PurchaseData p)
        {
            p.StoreId = $"BA{Generate.GenerateA5DigitsNumber()}";
            p.CreditCardNumber = "455744645890236";
            p.PurchaseDate = "2019-09-03";
            p.PurchasePrice = 100.0;
        }

        public static void CreateRecordWithDateWhenClose(this PurchaseData p)
        {
            p.StoreId = $"AC{Generate.GenerateA5DigitsNumber()}";
            p.CreditCardNumber = "455744645890236";
            p.PurchaseDate = "2020-04-18";
            p.PurchasePrice = 100.0;
        }
    }
}
