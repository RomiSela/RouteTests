using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using FluentAssertionsExtensions;
using System.Collections.Generic;
using System;

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
            RabbitMQManager.SendString(purchaseDataToSend.ToString());

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.Correct);
        }

        [TestMethod]
        public void ValidRecordPriceOver5000()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateValidRecordPriceOver5000();

            //Act
            RabbitMQManager.SendString(purchaseDataToSend.ToString());

            //Assert
            PurchaseDataOutput relevantPurchase = DalAccess.PullPurchasesDataByStoreId(purchaseDataToSend.StoreId);
            relevantPurchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.Correct);
        }

        [TestMethod]
        public void ValidTwoSameRecords()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateValidRecord();
            string twoRecords = $"{purchaseDataToSend.ToString()}/l{purchaseDataToSend.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List< PurchaseDataOutput> purchasesDataOutput = DalAccess.PullAllPurchasesData();
            foreach(PurchaseDataOutput purchase in purchasesDataOutput)
            {
                purchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.Correct);
            }
        }

        [TestMethod]
        public void OneValidOneImpossibleRecords()
        {
            //Arenge
            PurchaseData purchaseDataToSend = new PurchaseData();
            purchaseDataToSend.CreateValidRecord();
            PurchaseData invalidPurchaseData = new PurchaseData();
            invalidPurchaseData.CreateRecordWithImpossibleNumberOfPayments(1);
            string twoRecords = $"{purchaseDataToSend.ToString()}/l{invalidPurchaseData.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> purchasesDataOutput = DalAccess.PullAllPurchasesData();
            purchasesDataOutput.Count.Should().Be(1);
            foreach (PurchaseDataOutput purchase in purchasesDataOutput)
            {
                purchase.Should().BeAddedCorrectlyToDb(purchaseDataToSend, ValidationOptions.Correct);
            }
        }
    }
}
