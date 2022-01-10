using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactTests : AuthTestBase
    { 

        [Test]
        public void ContactTest()
        {
            app.Contact.
                ToTheContactCreatingForm();
            FullNameData word = new FullNameData("Elis");
            word.Middlename = "Kuznec";
            word.Lastname = "Nick";
            app.Contact
                .EnterFullName(word)
                .EnterNickname("Lis")
                .EnterCompanyInformation(new CompanyData("company","comp","add"))
                .EnterTelephoneNumbers(new TelephoneData("88-94-55"))
                .EnterEmails(new EmailsData("example@int.com"))
                .EnterHomepage("")
                .EnterDates()
                .SelectGroup()
                .EnterAddress("1/12")
                .EnterHome("")
                .EnterNotes("")
                .SaveContact();
            app.Navi.ToTheHomePage();
        }
    }
}
