using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactModTests : AuthTestBase
    {
        [Test]

        public void ContactModTest() 
        {
            List<FullNameData> oldContact = app.Contact.GetContactList();

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
                .EnterHomepage("3")
                .EnterAddress("11/12")
                .EnterHome("3")
                .EnterNotes("3")
                .SaveUpdate();
            app.Navi.GoToHomePage();

            List<FullNameData> newContact = app.Contact.GetContactList();

            oldContact[0].Name = word.Name;
            oldContact[0].Middlename = word.Middlename;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
        }
    
    }
}
