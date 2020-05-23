using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using Common;
using FluentAssertionsExtensions;

namespace ETL_Tests
{
    [TestClass]
    public class TestBase
    {
        public RabbitMQManager RabbitMQManager { get; set; }
        public DalAccess DalAccess { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            RabbitMQManager = new RabbitMQManager();
            RabbitMQManager.Connect();
            DalAccess = new DalAccess();
            DalAccess.ConnectToDb();
        }

        [TestMethod]
        protected string ArrangeOneValidAndOneInString(string record)
        {
            PurchaseData validPurchaseData = new PurchaseData();
            validPurchaseData.CreateValidRecord();
            string twoRecords = $"{validPurchaseData.ToString()}/l{record}";
            twoRecords = twoRecords.Replace("/l", Environment.NewLine);
            return twoRecords;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DalAccess.DeleteAllRows();
        }
    }
}
