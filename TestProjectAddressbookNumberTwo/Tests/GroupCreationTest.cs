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
            app.Navi.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Group.CreateNewGroup();
            GroupData group = new GroupData("test1");
            group.Header = "test2";
            group.Footer = "test3";
            app.Group.NamingFields(group);
            app.Group.SaveGroup();
            app.Exit.Logout();
        }
    }
}
