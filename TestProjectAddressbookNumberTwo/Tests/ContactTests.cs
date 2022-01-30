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
            public static IEnumerable<ContactData> RandomContactProvider()
            
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < 3; i++)
                {
                    contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(15))
                    {
                    });
                }
                return contacts;
            }

            [Test, TestCaseSource("RandomContactProvider")]
            
            public void ContactTest(ContactData newOne)
            
            {
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
