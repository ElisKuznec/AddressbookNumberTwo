using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactTests : TestBase
    { 

        [Test]
        public void ContactTest()
        {
            app.Navi.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.ToTheContactCreatingForm();
            FullNameData word = new FullNameData("Elis");
            word.Middlename = "Kuznec";
            word.Lastname = "Nick";
            app.Contact.EnterFullName(word);
            app.Contact.EnterNickname("Lis");
            app.Contact.EnterCompanyInformation(new CompanyData("company","comp","add"));
            app.Contact.EnterTelephoneNumbers(new TelephoneData("88-94-55"));
            app.Contact.EnterEmails(new EmailsData("example@int.com"));
            app.Contact.EnterHomepage("");
            app.Contact.EnterDates();
            app.Contact.SelectGroup();
            app.Contact.EnterAddress("1/12");
            app.Contact.EnterHome("");
            app.Contact.EnterNotes("");
            app.Contact.SaveContact();
            app.Navi.ToTheHomePage();
            app.Exit.Logout();
        }
    }
}
