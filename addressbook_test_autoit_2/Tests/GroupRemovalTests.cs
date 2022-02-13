using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()

        {
            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData GroupToDelete = new GroupData()
            {
                Id = "0"
            };
            app.Group.Delete(GroupToDelete);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }

}