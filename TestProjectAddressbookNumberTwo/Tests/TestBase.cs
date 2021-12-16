using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        
        [SetUp]
        public void UnitTest()
        {
            app = new ApplicationManager();
            app.Navi.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop(); 
        }
    }
}
