using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            app.Navi.HomePage();

            int indexToRemove = 1;
            app.Contact.AddIfNoContacts(indexToRemove);

            List<ContactData> oldContact = app.Contact.GetContactList();
            
            app.Contact
                .SelectContact(0)
                .DeleteSelectedContact()
                .AcceptDeletingContact();
            app.Navi.GoToGroupPage();

            List<ContactData> newContact = app.Contact.GetContactList();

            ContactData toBeRemoved = oldContact[0];
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactData group in newContact)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }

    }
}
