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
        private static void ValidFieldsRecord(this PurchaseData p)
        {
            p.StoreId = $"AA{GenerateFields.GenerateA5DigitsNumber()}";
            p.CreditCardNumber = "4557446145890236";
            p.PurchaseDate = "2019-09-03";
            p.PurchasePrice = 100.0;
        }

        public static void CreateValidRecord(this PurchaseData p)
        {
            ValidFieldsRecord(p);
        }

        public static void CreateInvalidCredirCardRecord(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            p.CreditCardNumber = "455744645890236";
        }

        public static void CreateRecordWithDateWhenClose(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            p.StoreId = $"AC{GenerateFields.GenerateA5DigitsNumber()}";
            p.PurchaseDate = "2020-04-18";
        }
    }
}
