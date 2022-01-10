using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactModTests : AuthTestBase
    {
        [Test]

        public void ContactModTest() 
        {
            app.Navi.HomePage();
            FullNameData word = new FullNameData("Sile");
            word.Middlename = "Kuz";
            word.Lastname = "Ni";
            app.Contact
                .UpdateContact()
                .EnterFullName(word)
                .EnterNickname("Lis")
                .EnterCompanyInformation(new CompanyData("co", "co", "a"))
                .EnterTelephoneNumbers(new TelephoneData("8"))
                .EnterEmails(new EmailsData("e"))
                .EnterHomepage("")
                .EnterAddress("11/12")
                .EnterHome("")
                .EnterNotes("")
                .SaveUpdate();
            app.Navi.GoToHomePage(); 
        }
    
    }
}
