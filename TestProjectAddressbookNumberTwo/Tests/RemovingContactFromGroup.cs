using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    class RemovingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {

            string filterName = "[all]";

            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            ContactData newcontact = new ContactData("FunnyName", "LuckyLastname");
            GroupData newgroup = new GroupData("TrueNaming");

            if (groupList.Count == 0)
            {
                app.Group.CreateGroup(newgroup);
                if (contactList.Count == 0)
                {
                    app.Contact.FullContactCreation(newcontact);
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> contactInGroup = group.GetContact();
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    app.Contact.AddContactToGroup(contact, group, filterName);
                }
            }
            else
            {
                if (contactList.Count == 0)
                {
                    app.Contact.FullContactCreation(newcontact);
                }
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> contactInGroup = group.GetContact();
                if (contactInGroup.Count == 0)
                {
                    ContactData contact = ContactData.GetAll().Except(contactInGroup).First();
                    app.Contact.AddContactToGroup(contact, group, filterName);
                }
            }

            GroupData groupAfterVerify = GroupData.GetAll()[0];
            List<ContactData> oldList = groupAfterVerify.GetContact();
            ContactData contactInGroupAfterVerify = GroupData.GetAll()[0].GetContact().First();

            app.Contact.RemovingContactFromGroup(contactInGroupAfterVerify, groupAfterVerify);

            List<ContactData> newList = groupAfterVerify.GetContact();
            oldList.Remove(contactInGroupAfterVerify);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}