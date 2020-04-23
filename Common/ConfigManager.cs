using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class ConfigManager
    {
        public static string DbServer => ConfigurationManager.AppSettings["DB_SERVER"];
        public static string DbName => ConfigurationManager.AppSettings["DB_NAME"];
        public static string DbUid => ConfigurationManager.AppSettings["DB_UID"];
        public static string DbPassword => ConfigurationManager.AppSettings["DB_PASSWORD"];
        public static string DbPullAllQuery => ConfigurationManager.AppSettings["DB_PULL_ALL"];
        public static string PurchaseIdDb => ConfigurationManager.AppSettings["PURCHASE_ID"];
        public static string StoreTypeDb => ConfigurationManager.AppSettings["STORE_TYPE"];
        public static string StoreIdDb => ConfigurationManager.AppSettings["STORE_ID"];
        public static string ActivityDaysDb => ConfigurationManager.AppSettings["ACTIVITY_DAYS"];
        public static string CreditCardDb => ConfigurationManager.AppSettings["CREDIT_CARD_NUMBER"];
        public static string PurchaseDateDb => ConfigurationManager.AppSettings["PURCHASE_DATE"];
        public static string AddedToDb => ConfigurationManager.AppSettings["ADD_TO_DB_DATE"];
        public static string PurchasePriceDb => ConfigurationManager.AppSettings["PURCHASE_PRICE"];
        public static string NumberOfPaymentsDb => ConfigurationManager.AppSettings["NUMBER_OF_PAYMENTS"];
        public static string PricePerPaymentDb => ConfigurationManager.AppSettings["PRICE_PER_PAYMENT"];
        public static string IsValidDb => ConfigurationManager.AppSettings["IS_VALID"];
        public static string WhyInvalidDb => ConfigurationManager.AppSettings["WHY_INVALID"];
        public static string RabbitUserName => ConfigurationManager.AppSettings["RABBIT_USER_NAME"];
        public static string RabbitPassword => ConfigurationManager.AppSettings["RABBIT_PASSWORD"];
        public static string RabbitHostName => ConfigurationManager.AppSettings["RABBIT_HOST_NAME"];
        public static string RabbitVirtualHost => ConfigurationManager.AppSettings["RABBIT_VIRTUAL_HOST"];
        public static int RabbitPort => int.Parse(ConfigurationManager.AppSettings["RABBIT_PORT"]);
    }
}
