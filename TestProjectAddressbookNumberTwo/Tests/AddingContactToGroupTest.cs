using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    class AddingContactToGroupTest : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            string filterName = "[all]";

            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newcontact = new ContactData("Sollus", "Lua");
            GroupData newgroup = new GroupData("GroupNameForTesting");

            if (groupList.Count == 0)
            {
                app.Group.CreateGroup(newgroup);
                if (contactList.Count == 0)
                {
                    app.Contact.FullContactCreation(newcontact);
                }
            }
            else
            {
                if (contactList.Count == 0)
                {
                    app.Contact.FullContactCreation(newcontact);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContact();

            if (oldList.SequenceEqual(ContactData.GetAll()))
            {
                app.Contact.FullContactCreation(newcontact);
            }

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group, filterName);

            List<ContactData> newList = group.GetContact();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}