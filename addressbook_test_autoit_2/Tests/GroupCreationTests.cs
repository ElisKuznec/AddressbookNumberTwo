using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()

        {
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "newOne"
            };
            app.Group.Add(newGroup);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }

}