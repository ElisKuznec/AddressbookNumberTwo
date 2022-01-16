﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class dContactModTests : AuthTestBase
    {
        [Test]

        public void ContactModTest()
        {

            ContactData newData = new ContactData("Annie", "Spark");
            int indexToModify = 1;
            app.Contact.AddIfNoContacts(indexToModify);

            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData oldData = oldContact[0];

            app.Contact.ModifyContact(newData);

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContact[0].Name = newData.Name;
            oldContact[0].Middlename = newData.Lastname;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Name, contact.Name);
                }
            }
        }

    }
 }

