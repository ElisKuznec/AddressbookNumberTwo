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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            CreateNewGroup();
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";
            NamingFields(group);
            SaveGroup();
            Logout();
        }
    }
}
