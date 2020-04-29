using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using FluentAssertionsExtensions;

namespace ETL_Tests
{
    [TestClass]
    public class Tests : TestBase
    {
        [TestMethod]
        public void SendValidRecord()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateValidRecord();

            //Act
            RabbitMQManager.SendOnePurchaseDate(purchaseDataToSend);

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.Correct);
        }

        [TestMethod]
        public void InvalidCreditCasrNumber()
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
    }
}
