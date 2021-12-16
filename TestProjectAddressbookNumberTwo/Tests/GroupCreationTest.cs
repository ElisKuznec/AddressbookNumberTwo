using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {

        [Test]
        public void GroupCreationTests()
        {
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";
            app.Group.Create(group);
            app.Exit.Logout();
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Group.Create(group);
            app.Exit.Logout();
        }
    }
}
