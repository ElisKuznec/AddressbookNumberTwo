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
            ContactData newData = new ContactData("Annie", "Spark");
            newData.Mobilenumb = "555-090-097";
            newData.Emailone = "NOTexample@int.com";
            newData.Address = "Nottingham 77/11";
            
            app.Contact.AddIfNoContacts();

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeModified = oldContact[0];

            ContactData oldData = oldContact[0];

            app.Contact.Modify(oldData, newData);
            Assert.AreEqual(oldContact.Count, app.Contact.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll();

            oldContact[0].Name = newData.Name;
            oldContact[0].Lastname = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);

            foreach (var contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual($"{newData.Lastname} {newData.Name}", $"{toBeModified.Lastname} {toBeModified.Name}");
                }
            }
        }

    }
 }

