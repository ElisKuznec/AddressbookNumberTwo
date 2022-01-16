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
            app.Navi.GoToGroupPage();
            int indexToMod = 1;
            app.Group.AddIfNoGroups(indexToMod);

            List<GroupData> oldGroups = app.Group.GetGroupList();
            GroupData oldData = oldGroups[0];
            
            GroupData group = new GroupData("test");
            group.Header = null;
            group.Footer = null;

            app.Group.ModifyGroup(group);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();

            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupForMatching in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(group.Name, groupForMatching.Name);
                }
            }

        }
    }
}
