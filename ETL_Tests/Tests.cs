using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateValidRecord();
            RabbitMQManager.Send(purchaseDataToSend);

            PurchaseDataRecieve relevantPurchase = DalAccess.PullLastPurchasesData(purchaseDataToSend.StoreId);

            relevantPurchase.Should().ExistsCorrectlyInDb(purchaseDataToSend);
        }

        [TestMethod]
        public void InvalidCreditCasrNumber()
        {
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateInvalidCredirCardRecord();
            RabbitMQManager.Send(purchaseDataToSend);

            PurchaseDataRecieve relevantPurchase = DalAccess.PullLastPurchasesData(purchaseDataToSend.StoreId);
            relevantPurchase.Should().ExistsCorrectlyInDbWithCredirCardInvalid(purchaseDataToSend);
        }

        [TestMethod]
        public void RecordWithDateWhenStoreClose()
        {
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateRecordWithDateWhenClose();
            RabbitMQManager.Send(purchaseDataToSend);

            PurchaseDataRecieve relevantPurchase = DalAccess.PullLastPurchasesData(purchaseDataToSend.StoreId);
            relevantPurchase.Should().ExistsCorrectlyInDbWithDateWhenClose(purchaseDataToSend);
        }
    }
}
