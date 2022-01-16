using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navi.GoToGroupPage();

            int indexToRemove = 1;
            app.Group.AddIfNoGroups(indexToRemove);

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group
                .SelectGroup(0)
                .DeleteGroup();
            app.Navi.ReturnToGroupPage();

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
