using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            int indexToRemove = 2;
            app.Contact.AddIfNoContacts(indexToRemove);

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData contactToRemove = oldContact[indexToRemove - 1];

            app.Contact.Remove(1);


            Assert.AreEqual(oldContact.Count - 1, app.Contact.GetContactCount());

            oldContact.Remove(contactToRemove);
            List<ContactData> newContact = ContactData.GetAll();

            oldContact.RemoveAt(indexToRemove);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            //foreach (var contact in newContact
            //    )
            //{
            //    Assert.AreNotEqual(contact.Id, contactToRemove.Id);
            //}

        }

    }
}
