using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace webAddressBookTests
{
    [TestFixture]
    public class LoginTests : AuthTestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "1234");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn());
        }
    }
}
