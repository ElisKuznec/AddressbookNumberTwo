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
            word.Lastname = "Nicññk";
            app.Contact
                .EnterFullName(word)
                .EnterNickname("Lis")
                .EnterCompanyInformation(new CompanyData("company","comp","add"))
                .EnterTelephoneNumbers(new TelephoneData("88-94-55"))
                .EnterEmails(new EmailsData("example@int.com"))
                .EnterHomepage("1")
                .EnterDates()
                .SelectGroup()
                .EnterAddress("1/12")
                .EnterHome("2")
                .EnterNotes("3")
                .SaveContact();
            app.Navi.ToTheHomePage();
        }
    }
}
