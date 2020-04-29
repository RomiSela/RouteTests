using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Common;

namespace FluentAssertionsExtensions
{
    public static class AssertionExtensions
    {
        public static RecordAssertions Should(this PurchaseDataOutput instance) =>
            new RecordAssertions(instance);
    }
}
