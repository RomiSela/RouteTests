using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;

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

        [TestCleanup]
        public void TestCleanup()
        {
            DalAccess.DeleteAllRows();
        }
    }
}
