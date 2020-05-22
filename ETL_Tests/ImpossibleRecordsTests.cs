using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;
using FluentAssertionsExtensions;
using System.Collections.Generic;
using System;

namespace ETL_Tests
{
    [TestClass]
    public class ImpossibleRecordsTests : TestBase
    {
        [TestMethod]
        public void RecordWithoutMustHaveFieldStoreId()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/l4557446145890236,2019-09-03,100.0";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List< PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithoutMustHaveFieldCreditCard()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/lAA12345,2019-09-03,100.0";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithoutMustHaveFieldDate()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/lAA12345,4557446145890236,100.0";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithoutMustHaveFieldPrice()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/lAA12345,4557446145890236,2019-09-03";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithTimeNotInTheRightFormat()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/lAA12345,4557446145890236,2019-09-32,100.0";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithDateNotInFormatOne()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithDateNotInFormat("notExist");
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithDateNotInFormatTwo()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithDateNotInFormat("randomNumber");
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithDateNotInFormatThree()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithDateNotInFormat("notInOrder");
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithFirstLetterDoesntExist()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(1);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithSecondLetterDoesntExist()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(2);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithFirstLetterSmall()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(3);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithSecondLetterSmall()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(4);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithFirstCharNotLetter()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(5);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithSecondCharNotLetter()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidStoreId(6);
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithNotANumberInPrice()
        {
            //Arenge
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            PurchaseData recordWithDateNotInFormat = new PurchaseData();
            recordWithDateNotInFormat.CreateRecordWithInvalidNumberOfPayment();
            string twoRecords = $"{validPurchaseData.ToString()}/l{recordWithDateNotInFormat.ToString()}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }
    }
}
