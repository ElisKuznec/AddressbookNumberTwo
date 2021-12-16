using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navi.GoToHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navi.GoToGroupPage();
            app.Group.SelectGroup(1);
            app.Group.DeleteGroup();
            app.Navi.ReturnToGroupPage();
            app.Exit.Logout();
        }
    }
}
