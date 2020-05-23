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
        private PurchaseDataOutput _purchaseDataRecieve => Subject as PurchaseDataOutput;
        protected override string Identifier => " ";

        public RecordAssertions(PurchaseDataOutput purchase) : base(purchase)
        {  }

        [CustomAssertion]
        public AndConstraint<RecordAssertions> BeAddedCorrectlyToDb(PurchaseData purchaseDataToSend, ValidationOptions validationOption)
        {
            _purchaseDataRecieve.ActivityDays.Should().Be(purchaseDataToSend.StoreId[1]);
            _purchaseDataRecieve.CreditCardNumber.Should().Be(purchaseDataToSend.CreditCardNumber);

            if (purchaseDataToSend.NumberOfPayments == null || purchaseDataToSend.NumberOfPayments == "FULL")
            {
                _purchaseDataRecieve.NumberOfPayments.Should().Be("1");
                _purchaseDataRecieve.PricePerPayment.Should().Be(double.Parse(purchaseDataToSend.PurchasePrice));
            }
            else
            {
                _purchaseDataRecieve.NumberOfPayments.Should().Be(purchaseDataToSend.NumberOfPayments);
                _purchaseDataRecieve.PricePerPayment.Should().Be(double.Parse(purchaseDataToSend.PurchasePrice) / int.Parse(purchaseDataToSend.NumberOfPayments));
            }

            double.Parse(_purchaseDataRecieve.PurchasePrice).Should().Be(double.Parse(purchaseDataToSend.PurchasePrice));
            _purchaseDataRecieve.StoreId.Should().Be(purchaseDataToSend.StoreId);
            _purchaseDataRecieve.StoreType.Should().BeEquivalentTo(purchaseDataToSend.StoreId[0]);
            if(validationOption.Equals( ValidationOptions.Correct))
            {
                _purchaseDataRecieve.IsValid.Should().Be("1");
                _purchaseDataRecieve.WhyInvalid.Should().BeNullOrEmpty();
            }
            else 
            {
                _purchaseDataRecieve.IsValid.Should().Be("0");
                if (validationOption.Equals(ValidationOptions.InvalidCreditCard))
                {
                    _purchaseDataRecieve.WhyInvalid.Should().Be("The credit card number is not valid");
                }
                else if(validationOption.Equals(ValidationOptions.InvalidNumberOfPayments))
                {
                    _purchaseDataRecieve.WhyInvalid.Should().Be("Number of installments cant be higher than price*10");
                }
                else if(validationOption.Equals(ValidationOptions.InvalidPricePerPayment))
                {
                    _purchaseDataRecieve.WhyInvalid.Should().Be("Price per installment cant be higher than 5000");
                }
                else if(validationOption.Equals(ValidationOptions.PurchaseDateWhenStoreClose))
                {
                    _purchaseDataRecieve.WhyInvalid.Should().Be("Purchase was made on a day that the store is closed");
                }
                else
                {
                    _purchaseDataRecieve.WhyInvalid.Should().Be("The purchase date cant be in the future");
                }
            }
            return new AndConstraint<RecordAssertions>(this);
        }
    }
}
