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
        private static void ValidFieldsRecord(this PurchaseData purchaseData)
        {
            purchaseData.StoreId = $"AA{GenerateFields.GenerateA5DigitsNumber()}";
            purchaseData.CreditCardNumber = "4557446145890236";
            purchaseData.PurchaseDate = "2019-09-03";
            purchaseData.PurchasePrice = "100.0";
        }

        public static void CreateValidRecord(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
        }

        public static void CreateValidRecordPriceOver5000(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
            purchaseData.PurchasePrice = "12000";
        }

        public static void CreateInvalidCredirCardRecord(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
            purchaseData.CreditCardNumber = "455744645890236";
        }

        public static void CreateRecordWithDateWhenClose(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
            purchaseData.StoreId = $"AC{GenerateFields.GenerateA5DigitsNumber()}";
            purchaseData.PurchaseDate = "2020-04-18";
        }

        public static void CreateRecordWithDateNotInFormat(this PurchaseData purchaseData, string testCase)
        {
            ValidFieldsRecord(purchaseData);

            if (testCase == "notExist")
            {
                purchaseData.PurchaseDate = "2020-04-32";
            }
            else if(testCase == "randomNumber")
            {
                purchaseData.PurchaseDate = "4355";
            }
            else if(testCase== "notInOrder")
            {
                purchaseData.PurchaseDate = "18-04-2020";
            }
        }

        public static void CreateRecordWithDateLaterThanNow(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
            DateTime d = DateTime.Now;
            d.AddDays(1);
            purchaseData.PurchaseDate = $"{d.Year}-{d.Month}-{d.Day}";
        }

        public static void CreateRecordWithInvalidNumberOfPayments(this PurchaseData p)
        {
            ValidFieldsRecord(p);
            p.NumberOfPayments = "15000";
        }

        public static void CreateRecordWithInvalidStoreId(this PurchaseData purchaseData, int testCase)
        {
            ValidFieldsRecord(purchaseData);
            if (testCase == 1)
            {
                purchaseData.StoreId = $"TA{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if(testCase==2)
            {
                purchaseData.StoreId = $"AL{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if(testCase ==3)
            {
                purchaseData.StoreId = $"aA{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (testCase == 4)
            {
                purchaseData.StoreId = $"Aa{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (testCase == 5)
            {
                purchaseData.StoreId = $"3A{GenerateFields.GenerateA5DigitsNumber()}";
            }
            else if (testCase == 6)
            {
                purchaseData.StoreId = $"A3{GenerateFields.GenerateA5DigitsNumber()}";
            }
        }

        public static void CreateRecordWithImpossiblePrice(this PurchaseData purchaseData)
        {
            ValidFieldsRecord(purchaseData);
            purchaseData.PurchasePrice = "@";
        }

        public static void CreateRecordWithImpossibleNumberOfPayments(this PurchaseData purchaseData, int testCase)
        {
            ValidFieldsRecord(purchaseData);
            if(testCase == 1)
            {
                purchaseData.NumberOfPayments = "full";
            }
            else if(testCase == 2)
            {
                purchaseData.NumberOfPayments = "-2";
            }
            else if(testCase == 3)
            {
                purchaseData.NumberOfPayments = "&";
            }
        }
    }
}
