using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using FluentAssertions;

namespace ETL_Tests
{
    [TestClass]
    public class Tests : TestBase
    {
        [TestMethod]
        public void SendValidRecord()
        {
            PurchaseData p = PurchaseData.RandomData();
            RabbitMQManager.Send(p);
            List<PurchaseDataRecieve> AllPurchasesAfter = DalAccess.PullAllPurchasesData();
            PurchaseDataRecieve relevantPurchase = new PurchaseDataRecieve();
            foreach(var purchase in AllPurchasesAfter)
            {
                if (purchase.StoreId.Equals(p.StoreId))
                    relevantPurchase = purchase;
            }

            relevantPurchase.ActivityDays.Should().Be(p.StoreId[1]);
            relevantPurchase.CreditCardNumber.Should().Be(p.CreditCardNumber);

            if (p.NumberOfPayments == null || p.NumberOfPayments == "FULL")
            {
                relevantPurchase.NumberOfPayments.Should().Be("1");
                relevantPurchase.PricePerPayment.Should().Be(p.PurchasePrice);
            }
            else
            {
                relevantPurchase.NumberOfPayments.Should().Be(p.NumberOfPayments);
                relevantPurchase.PricePerPayment.Should().Be(p.PurchasePrice / int.Parse(p.NumberOfPayments));
            }

            relevantPurchase.PurchasePrice.Should().Be(p.PurchasePrice);
            relevantPurchase.StoreId.Should().Be(p.StoreId);
            relevantPurchase.StoreType.Should().BeEquivalentTo(p.StoreId[0]);
            relevantPurchase.IsValid.Should().Be("True");
            relevantPurchase.WhyInvalid.Should().BeNullOrEmpty();
        }
    }
}
