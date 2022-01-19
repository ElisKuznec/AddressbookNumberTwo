using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            System.Console.Out.Write(app.Contact.GetNumberOfSearchResult());
        }

    }
}