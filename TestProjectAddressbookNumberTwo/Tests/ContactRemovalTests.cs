using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navi.HomePage();
            app.Contact
                .SelectContact(1)
                .DeleteSelectedContact()
                .AcceptDeletingContact();
            app.Navi.GoToGroupPage();
        }

    }
}
