using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum ValidationOptions
    {
        Correct,
        InvalidCreditCard,
        InvalidNumberOfPayments,
        PurchaseDateWhenStoreClose,
        InvalidPricePerPayment,
        PurchaseDateAfterInsertionDate
    }
}
