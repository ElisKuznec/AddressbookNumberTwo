using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
                .SelectContact(1)
                .DeleteSelectedContact()
                .AcceptDeletingContact();
            app.Navi.GoToGroupPage();

            Assert.AreEqual(oldContact.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(indexToRemove);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }

    }
}
