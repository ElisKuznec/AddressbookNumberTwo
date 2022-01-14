using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactTests : AuthTestBase
    { 

        [Test]
        public void ContactTest()
        {

            ContactData newOne = new ContactData("Elis", "Nicññk");

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.FullContactCreation(newOne);

            List<ContactData> newContacts = app.Contact.GetContactList();

            oldContacts.Add(newOne);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
