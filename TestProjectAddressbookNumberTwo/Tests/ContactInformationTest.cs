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
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);

        }

        [Test]
        public void TestContactInformationIcon()
        {
            ContactData fromIcon = app.Contact.GetContactInformationFromIcon(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromIcon, fromForm);
            Assert.AreEqual(fromIcon.Address, fromForm.Address);
            Assert.AreEqual(fromIcon.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromIcon.AllMails, fromForm.AllMails);
        }

    }
}