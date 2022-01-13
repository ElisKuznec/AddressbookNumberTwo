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
            List<FullNameData> oldContact = app.Contact.GetContactList();

            app.Navi.HomePage();
            app.Contact
                .SelectContact(1)
                .DeleteSelectedContact()
                .AcceptDeletingContact();
            app.Navi.GoToGroupPage();

            List<FullNameData> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);


        }

    }
}
