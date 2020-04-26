using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


// TODO: why is this here
namespace FluentAssertionsExtensions
{
    public static class PurchaseDataExtensions
    {
        // TODO: you don't want to create a function for each test like this
        // you can use the valid record and set the values to whatever you want during the test
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
