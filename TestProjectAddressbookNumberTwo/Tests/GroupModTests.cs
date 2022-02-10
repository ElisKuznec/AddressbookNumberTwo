using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupModTests : GroupTestBase
    {
        [Test]
        public void GroupModTest()
        { 

            int indexToMod = 1;
            app.Group.AddIfNoGroups(indexToMod);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldGroupData = oldGroups[indexToMod-1];
            
            GroupData group = new GroupData("test");
            group.Header = null;
            group.Footer = null;

            app.Group.ModifyGroup(group);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[indexToMod].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupForMatching in newGroups)
            {
                if(group.Id == oldGroupData.Id)
                {
                    Assert.AreEqual(group.Name, groupForMatching.Name);
                }
            }

        }
    }
}
