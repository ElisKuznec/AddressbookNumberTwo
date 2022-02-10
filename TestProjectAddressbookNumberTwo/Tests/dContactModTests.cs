using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class dContactModTests : ContactTestBase
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

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldContactData = oldContact[indexToModify - 1];

            app.Contact.Modify(1, newData);
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll();

            oldContact[indexToModify-1].Name = newData.Name;
            oldContact[indexToModify-1].Lastname = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);

            foreach (var contact in newContact)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual($"{newData.Lastname} {newData.Name}", $"{contact.Lastname} {contact.Name}");
                }
            }
        }

    }
 }

