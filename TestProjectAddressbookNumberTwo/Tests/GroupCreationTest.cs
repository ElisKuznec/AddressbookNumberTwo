using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {

        [Test]
        public void GroupCreationTests()
        {
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count +1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTests()
        {
            GroupData group = new GroupData("a'");
            group.Header = "a'";
            group.Footer = "a'";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
