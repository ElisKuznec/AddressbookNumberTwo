using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm();

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);

        }

        [Test]
        public void ContactDetailTest()
        {
            string fromDetails = app.Contact.GetContactInformationFromDetailsForm();
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm();

            Assert.AreEqual(fromDetails, fromForm.AllData);
        }

    }
}