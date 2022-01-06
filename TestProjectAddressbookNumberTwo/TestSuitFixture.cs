using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [SetUpFixture]
    public class TestSuitFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navi.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
