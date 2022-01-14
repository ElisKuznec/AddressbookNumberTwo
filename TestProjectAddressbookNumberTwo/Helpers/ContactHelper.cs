using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace webAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contactsList = new List<ContactData>();
            manager.Navi.GoToHomePage();

            ICollection<IWebElement> webContactElements = driver.FindElements(By.CssSelector("tr[name='entry']"));

            foreach (IWebElement element in webContactElements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                IWebElement lastName = cells[1];
                IWebElement firstName = cells[2];
                contactsList.Add(new ContactData(firstName.Text, lastName.Text));
            }

            return contactsList;
        }

        public ContactHelper SaveUpdate()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper AcceptDeletingContact()
        {
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }

        public ContactHelper DeleteSelectedContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper ToTheContactCreatingForm()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper EnterNotes(string note)
        {
            Type(By.Name("notes"), note);
            return this;
        }

        public ContactHelper EnterHome(string addphone)
        {
            Type(By.Name("phone2"), addphone);
            return this;
        }

        public ContactHelper EnterAddress(string address)
        {
            Type(By.Name("address2"), address);
            return this;
        }

        public ContactHelper EnterDates()
        {
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("October");
            driver.FindElement(By.XPath("//option[@value='October']")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("13");
            driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[15]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("September");
            driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[10]")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1");
            return this;
        }

        public ContactHelper SelectGroup()
        {
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByIndex(0);
            driver.FindElement(By.XPath("//div[@id='content']/form/select[5]/option[2]")).Click();
            return this;
        }

        public ContactHelper EnterHomepage(string homepage)
        {
            Type(By.Name("homepage"), homepage);
            return this;
        }

        public ContactHelper EnterEmails(ContactData e)
        {
            Type(By.Name("email"), e.Emailone);
            Type(By.Name("email2"), e.Emailtwo);
            Type(By.Name("email3"), e.Emailthree);
            return this;
        }

        public ContactHelper EnterTelephoneNumbers(ContactData numb)
        {
            Type(By.Name("home"), numb.Homenumb);
            Type(By.Name("mobile"), numb.Mobilenumb);
            Type(By.Name("work"), numb.Worknumb);
            Type(By.Name("fax"), numb.Faxnumb);
            return this;
        }

        public ContactHelper FullContactCreation(ContactData fullData)
        {
            ToTheContactCreatingForm();
            EnterFullName(fullData);
            EnterNickname("Lis");
            EnterCompanyInformation(fullData);
            EnterTelephoneNumbers(fullData);
            EnterEmails(fullData);
            EnterHomepage("1");
            EnterDates();
            SelectGroup();
            EnterAddress("1/12");
            EnterHome("2");
            EnterNotes("3");
            SaveContact();
            manager.Navi.ToTheHomePage();
            return this;
        }

        public ContactHelper EnterCompanyInformation(ContactData info)
        {
            Type(By.Name("title"), info.Companytitle);
            Type(By.Name("company"), info.Companyname);
            Type(By.Name("address"), info.Companyaddress);
            return this;
        }

        public ContactHelper EnterNickname(string nick)
        {
            Type(By.Name("nickname"), nick);
            return this;
        }

        public ContactHelper EnterFullName(ContactData word)
        {
            Type(By.Name("firstname"), word.Name);
            Type(By.Name("middlename"), word.Middlename);
            Type(By.Name("lastname"), word.Lastname);
            return this;
        }

        public ContactHelper SaveContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper CreateSimpleContact(ContactData simpleData)
        {
            ToTheContactCreatingForm();
            EnterFullName(new ContactData(simpleData.Name, simpleData.Lastname));
            SaveContact();
            return this;
        }

        public void AddIfNoContacts(int index)
        {
            while (!IsElementPresent(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td")))
            {
                CreateSimpleContact(new ContactData("Simple", "One"));
                manager.Navi.GoToHomePage();
            }
        }

        public ContactHelper ModifyContact(ContactData newData)
        {
            UpdateContact();
            EnterFullName(newData);
            EnterNickname("Lis");
            EnterCompanyInformation(newData);
            EnterTelephoneNumbers(newData);
            EnterEmails(newData);
            EnterHomepage("3");
            EnterAddress("11/12");
            EnterHome("3");
            EnterNotes("3");
            SaveUpdate();
            manager.Navi.GoToHomePage();
            return this;
        }
    }
}