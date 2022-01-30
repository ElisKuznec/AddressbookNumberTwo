using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace webAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navi.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string name = cells[2].Text;
            string address = cells[3].Text;
            string allMails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(name, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllMails = allMails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navi.GoToHomePage();
            UpdateContact(0);
            string name = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homenumb = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilenumb = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string worknumb = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string emailone = driver.FindElement(By.Name("email")).GetAttribute("value");
            string emailtwo = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string emailthree = driver.FindElement(By.Name("email3")).GetAttribute("value");



            return new ContactData(name, lastname)
            {
                
                Homenumb = homenumb,
                Mobilenumb = mobilenumb,
                Worknumb = worknumb,
                Address = address,
                Emailone = emailone,
                Emailtwo = emailtwo,
                Phone = phone,
                Emailthree = emailthree,


            };


        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            manager.Navi.GoToHomePage();
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navi.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> row = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(row[2].Text, row[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }


        public ContactHelper SaveUpdate()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper UpdateContact(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row + 2) + "]/td[8]/a/img")).Click();
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
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int row)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[" + (row + 2) + "]/ td")).Click();
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

        public ContactHelper EnterAddress(ContactData add)
        {
            Type(By.Name("address2"), add.Address);
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
            EnterAddress(fullData);
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
            contactCache = null;
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
            UpdateContact(1);
            EnterFullName(newData);
            EnterNickname("Lis");
            EnterCompanyInformation(newData);
            EnterTelephoneNumbers(newData);
            EnterEmails(newData);
            EnterHomepage("3");
            EnterAddress(newData);
            EnterHome("3");
            EnterNotes("3");
            SaveUpdate();
            manager.Navi.GoToHomePage();
            return this;
        }

        public int GetNumberOfSearchResult()

        {
            manager.Navi.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public int GetContactCount()
        {
            manager.Navi.GoToHomePage();
            return driver.FindElements(By.CssSelector("[name='entry']")).Count;
        }
    }
}