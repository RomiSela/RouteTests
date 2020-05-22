using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using FluentAssertionsExtensions;

namespace ETL_Tests
{
    [TestClass]
    public class ValidRecordsTests : TestBase
    {
        [TestMethod]
        public void ValidRecord()
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

        
    }
}
