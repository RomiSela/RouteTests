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
        private string ArrangeRecordWithImpossibleDate(string testCase)
        {
            PurchaseData recordWithInvalidDate = new PurchaseData();
            recordWithInvalidDate.CreateRecordWithDateNotInFormat(testCase);
            string twoRecords = ArrangeOneValidAndOneInString(recordWithInvalidDate.ToString());
            return twoRecords;
        }

        [TestMethod]
        private string ArrangeTestRecordWithImpossibleStoreId(int testCase)
        {
            PurchaseData recordWithInvalidStoreId = new PurchaseData();
            recordWithInvalidStoreId.CreateRecordWithInvalidStoreId(testCase);
            string twoRecords = ArrangeOneValidAndOneInString(recordWithInvalidStoreId.ToString());
            return twoRecords;
        }

        [TestMethod]
        private string ArrangeTestRecordWithImpossibleNumberOfPayments(int testCase)
        {
            PurchaseData recordWithInvalidStoreId = new PurchaseData();
            recordWithInvalidStoreId.CreateRecordWithImpossibleNumberOfPayments(testCase);
            string twoRecords = ArrangeOneValidAndOneInString(recordWithInvalidStoreId.ToString());
            return twoRecords;
        }

        [TestMethod]
        public void RecordWithoutMustHaveFieldStoreId()
        {
            //Arenge
            string twoRecords = ArrangeOneValidAndOneInString("4557446145890236,2019-09-03,100.0");

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
            string twoRecords = ArrangeOneValidAndOneInString("AA12345,2019-09-03,100.0");

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
            string twoRecords = ArrangeOneValidAndOneInString("AA12345,4557446145890236,100.0");

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
            string twoRecords = ArrangeOneValidAndOneInString("AA12345,4557446145890236,2019-09-03");

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
            string twoRecords = ArrangeOneValidAndOneInString("AA12345,4557446145890236,2019-09-32,100.0");

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
            string twoRecords = ArrangeRecordWithImpossibleDate("notExist");

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
            string twoRecords = ArrangeRecordWithImpossibleDate("randomNumber");

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
            string twoRecords = ArrangeRecordWithImpossibleDate("notInOrder");

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(1);

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(2);

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(3);

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(4);

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(5);

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
            string twoRecords = ArrangeTestRecordWithImpossibleStoreId(6);

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
            string twoRecords = ArrangeOneValidAndOneInString("AA12345,4557446145890236,2019-09-03,one");

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWith8CharsInStoreId()
        {
            //Arenge
            string twoRecords = ArrangeOneValidAndOneInString("AA123454,4557446145890236,2019-09-03,100.0");

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithout5DigitsInStoreId()
        {
            //Arenge
            string twoRecords = ArrangeOneValidAndOneInString("AA1234@,4557446145890236,2019-09-03,100.0");

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithImpossibleNumberOfPaymentsfull()
        {
            //Arenge
            string twoRecords = ArrangeTestRecordWithImpossibleNumberOfPayments(1);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithImpossibleNumberOfPaymentsANegativeNumber()
        {
            //Arenge
            string twoRecords = ArrangeTestRecordWithImpossibleNumberOfPayments(2);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

        [TestMethod]
        public void RecordWithImpossibleNumberOfPaymentsRandomChar()
        {
            //Arenge
            string twoRecords = ArrangeTestRecordWithImpossibleNumberOfPayments(3);

            //Act
            RabbitMQManager.SendString(twoRecords);

            //Assert
            List<PurchaseDataOutput> outputPurchases = DalAccess.PullAllPurchasesData();
            outputPurchases.Count.Should().Be(1);
        }

    }
}
