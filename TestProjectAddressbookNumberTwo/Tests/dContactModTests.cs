using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class dContactModTests : AuthTestBase
    {
        [Test]

        public void ContactModTest()
        {
            int indexToModify = 1;
            ContactData newData = new ContactData("Annie", "Spark");
            newData.Mobilenumb = "555-090-097";
            newData.Emailone = "NOTexample@int.com";
            newData.Address = "Nottingham 77/11";
            app.Contact.AddIfNoContacts(indexToModify);

            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.ModifyContact(newData);
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContact[indexToModify].Name = newData.Name;
            oldContact[indexToModify].Lastname = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
        }

    }
 }

