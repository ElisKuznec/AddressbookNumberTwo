using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navi.GoToGroupPage();

            int indexToRemove = 1;
            app.Group.AddIfNoGroups(indexToRemove);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[indexToRemove];
            
            app.Group.Remove(toBeRemoved);
            

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            
            oldGroups.RemoveAt(indexToRemove);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
