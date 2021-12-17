using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupModTests : TestBase
    {
        [Test]
        public void GroupModTest()
        {
            app.Navi.GoToGroupPage();
            app.Group
                .SelectGroup(1)
                .ToEdithGroupForm();
            GroupData group = new GroupData("test");
            group.Header = "test";
            group.Footer = "test";
            app.Group
                  .NamingFields(group)
                  .UpdateGroup();
            app.Navi.GoToGroupPage();
            app.Exit.Logout();
        }
    }
}
