using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Common;
using FluentAssertions.Primitives;

namespace FluentAssertionsExtensions
{
    public class RecordAssertions : ObjectAssertions
    {
        private PurchaseDataRecieve _purchaseDataRecieve => Subject as PurchaseDataRecieve;
        protected override string Identifier => " ";

        public RecordAssertions(PurchaseDataRecieve purchase) : base(purchase)
        {  }

        [CustomAssertion]
        private AndConstraint<RecordAssertions> AllCorrectButValidAndWhy(PurchaseData purchaseDataToSend)
        {
            _purchaseDataRecieve.ActivityDays.Should().Be(purchaseDataToSend.StoreId[1]);
            _purchaseDataRecieve.CreditCardNumber.Should().Be(purchaseDataToSend.CreditCardNumber);

            if (purchaseDataToSend.NumberOfPayments == null || purchaseDataToSend.NumberOfPayments == "FULL")
            {
                _purchaseDataRecieve.NumberOfPayments.Should().Be("1");
                _purchaseDataRecieve.PricePerPayment.Should().Be(purchaseDataToSend.PurchasePrice);
            }
            else
            {
                _purchaseDataRecieve.NumberOfPayments.Should().Be(purchaseDataToSend.NumberOfPayments);
                _purchaseDataRecieve.PricePerPayment.Should().Be(purchaseDataToSend.PurchasePrice / int.Parse(purchaseDataToSend.NumberOfPayments));
            }

            _purchaseDataRecieve.PurchasePrice.Should().Be(purchaseDataToSend.PurchasePrice);
            _purchaseDataRecieve.StoreId.Should().Be(purchaseDataToSend.StoreId);
            _purchaseDataRecieve.StoreType.Should().BeEquivalentTo(purchaseDataToSend.StoreId[0]);
            return new AndConstraint<RecordAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<RecordAssertions> ExistsCorrectlyInDb(PurchaseData purchaseDataToSend)
        {
            _purchaseDataRecieve.Should().AllCorrectButValidAndWhy(purchaseDataToSend);
            _purchaseDataRecieve.IsValid.Should().Be("True");
            _purchaseDataRecieve.WhyInvalid.Should().BeNullOrEmpty();
            return new AndConstraint<RecordAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<RecordAssertions> ExistsCorrectlyInDbWithCredirCardInvalid(PurchaseData purchaseDataToSend)
        {
            _purchaseDataRecieve.Should().AllCorrectButValidAndWhy(purchaseDataToSend);
            _purchaseDataRecieve.IsValid.Should().Be("False");
            _purchaseDataRecieve.WhyInvalid.Should().Be("The credit card number is not valid");
            return new AndConstraint<RecordAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<RecordAssertions> ExistsCorrectlyInDbWithDateWhenClose(PurchaseData purchaseDataToSend)
        {
            _purchaseDataRecieve.Should().AllCorrectButValidAndWhy(purchaseDataToSend);
            _purchaseDataRecieve.IsValid.Should().Be("False");
            _purchaseDataRecieve.WhyInvalid.Should().Be("Purchase was made on a day that the store is closed");
            return new AndConstraint<RecordAssertions>(this);
        }
    }
}
