using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }

    }
}