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
            app.Group.SelectGroup(1);
            driver.FindElement(By.Name("edit")).Click();

        }
    }
}
