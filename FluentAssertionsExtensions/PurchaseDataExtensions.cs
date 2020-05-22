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
            p.PurchasePrice = "100.0";
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

        public static void CreateRecordWithDateNotInFormat(this PurchaseData p, string whichCase)
        {
            ValidFieldsRecord(p);

            if (whichCase == "notExist")
            {
                p.PurchaseDate = "2020-04-32";
            }
            else if(whichCase == "randomNumber")
            {
                p.PurchaseDate = "4355";
            }
            else if(whichCase== "notInOrder")
            {
                p.PurchaseDate = "18-04-2020";
            }
        }

        public static void CreateRecordWithDateLaterThanNow(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            DateTime d = DateTime.Now;
            d.AddDays(1);
            p.PurchaseDate = $"{d.Year}-{d.Month}-{d.Day}";
        }

        public static void CreateRecordWithInvalidNumberOfPayments(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            p.NumberOfPayments = "15000";
        }

        public static void CreateRecordWithInvalidStoreId(this PurchaseData p, int number)
        {
            ValidFieldsRecord(p);
            if (number == 1)
            {
                p.StoreId = $"TA{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if(number==2)
            {
                p.StoreId = $"AL{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if(number ==3)
            {
                p.StoreId = $"aA{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (number == 4)
            {
                p.StoreId = $"Aa{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (number == 5)
            {
                p.StoreId = $"3A{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (number == 6)
            {
                p.StoreId = $"A3{GenerateFields.GenerateA5DigitsNumber()}";
            }
        }

        public static void CreateRecordWithInvalidNumberOfPayment(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            p.PurchasePrice = "@";
        }
    }
}
