using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using FluentAssertionsExtensions;

namespace ETL_Tests
{
    [TestClass]
    public class InvalidRecordsTests : TestBase
    {
        [TestMethod]
        public void InvalidCreditCardNumber()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateInvalidCredirCardRecord();

            //Act
            RabbitMQManager.SendOnePurchaseDate(purchaseDataToSend);

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.InvalidCreditCard);
        }

        [TestMethod]
        public void RecordWithInvalidNumberOfPayments()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateRecordWithInvalidNumberOfPayments();

            //Act
            RabbitMQManager.SendOnePurchaseDate(purchaseDataToSend);

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.InvalidNumberOfPayments);
        }

        [TestMethod]
        public void RecordWithDateWhenStoreClose()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateRecordWithDateWhenClose();

            //Act
            RabbitMQManager.SendOnePurchaseDate(purchaseDataToSend);

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.PurchaseDateWhenStoreClose);
        }

        public void RecordWithDateAfterInsertionDate()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateRecordWithDateLaterThanNow();

            //Act
            RabbitMQManager.SendOnePurchaseDate(purchaseDataToSend);

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.PurchaseDateAfterInsertionDate);
        }
    }
}
