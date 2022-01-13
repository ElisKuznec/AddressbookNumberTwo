using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupModTests : AuthTestBase
    {
        [Test]
        public void GroupModTest()
        {
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Navi.GoToGroupPage();
            app.Group
                .SelectGroup(0)
                .ToEdithGroupForm();
            GroupData group = new GroupData("test");
            group.Header = null;
            group.Footer = null;
            app.Group
                  .NamingFields(group)
                  .UpdateGroup();
            app.Navi.GoToGroupPage();

            List<GroupData> newGroups = app.Group.GetGroupList();

            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
