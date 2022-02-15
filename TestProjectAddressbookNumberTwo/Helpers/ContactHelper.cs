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

        public ContactData GetContactInformationFromIcon(int index)
        {
            manager.Navi.GoToHomePage();
            SelectPersonalDetalis(index);

            string[] info = driver.FindElement(By.CssSelector("div#content")).Text.Split('\r', '\n');
            string[] allName = info[0].Split(' ');
            string name = allName[0];
            string lastname = allName[2];
            string address = info[8];

            string homenumb = Regex.Replace(info[12], @"[()H: -]", "");
            string mobilenumb = Regex.Replace(info[14], @"[()M: -]", "");
            string worknumb = Regex.Replace(info[16], @"[()W: -]", "");
            string phone = Regex.Replace(info[40], @"[()P: -]", "");
            string allPhone = $"{homenumb}\r\n{mobilenumb}\r\n{worknumb}\r\n{phone}";

            string emailone = info[20];
            string emailtwo = info[22];
            string emailthree = info[24];
            string allMails = $"{emailone}\r\n{emailtwo}\r\n{emailthree}";

            return new ContactData(name, lastname)
            {
                Address = address,
                AllPhones = allPhone,
                AllMails = allMails
            };
        }


            public ContactData GetContactInformationFromEditForm()
        {
            manager.Navi.GoToHomePage();
            UpdateContact(0);
            string name = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nick = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string companytitle = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homenumb = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilenumb = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string worknumb = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string emailone = driver.FindElement(By.Name("email")).GetAttribute("value");
            string emailtwo = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string emailthree = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string birthmonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[1]")).Text;
            string birthyear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string annyversaryday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string annyversarymounth = driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[1]")).Text;
            string annyversaryyear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).Text;
            string notes = driver.FindElement(By.Name("notes")).Text;



            return new ContactData(name.Trim(), lastname.Trim())
            {
                Middlename = middlename,
                Nickname = nick,
                Companyname = company,
                Companytitle = companytitle,
                Homenumb = homenumb,
                Mobilenumb = mobilenumb,
                Worknumb = worknumb,
                Address = address,
                Emailone = emailone,
                Emailtwo = emailtwo,
                Phone = phone,
                Emailthree = emailthree,
                Faxnumb = fax,
                Homepage = homepage,
                Birthday = birthday,
                Birthmonth = birthmonth,
                Birthyear = birthyear,
                Annyversaryday = annyversaryday,
                Annyversarymounth = annyversarymounth,
                Annyversaryyear = annyversaryyear,
                Address2 = address2,
                Notes = notes
            };


        }

        public ContactHelper SelectPersonalDetalis(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public string GetContactInformationFromDetailsForm()
        {
            manager.Navi.GoToHomePage();
            SelectPersonalDetalis(0);
            string AllDetails = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            return AllDetails;
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

        public ContactHelper AddIfNoContacts()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
            {
                CreateSimpleContact(new ContactData("Simple", "One"));
                manager.Navi.GoToHomePage();
            }
            return this;
        }

        public ContactHelper ModifyContact(ContactData newData)
        {
            EnterFullName(newData);
            EnterNickname("Lis");
            EnterCompanyInformation(newData);
            EnterTelephoneNumbers(newData);
            EnterEmails(newData);
            EnterHomepage("3");
            EnterAddress(newData);
            EnterHome("3");
            EnterNotes("3");
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

        public void RemovingContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navi.GoToHomePage();
            SelectGroupInFilter(group.Name);
            SelectContactToAddToGroup(contact.Id);
            CommitToRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SelectGroupInFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void CommitToRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group, string filtername)
        {
            manager.Navi.GoToHomePage();
            GroupFilter(filtername);
            SelectContactToAddToGroup(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitToAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CommitToAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void SelectContactToAddToGroup(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        public void GroupFilter(string filterName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(filterName);
        }

        private ContactHelper SelectContactToUpdate(string id)
        {
           driver.FindElement(By.XPath("//tr[./td[./input[@name='selected[]' and @value='" + id + "']]]")).FindElement(By.XPath(".//img[@alt='Edit']")).Click();
           return this;
        }

        private ContactHelper SelectContactToUpdate(int index)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{index + 1}]/td[8]")).Click();
            return this;
        }

        private ContactHelper SelectContactToDelete(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value= '" + id + "'])")).Click();
            return this;
        }

        private ContactHelper SelectContactToDelete(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 1) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 1) + "]/td/input")).Click();
            return this;
        }


        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData name)
        {
            manager.Navi.GoToHomePage();
            SelectContactToUpdate(contact.Id);
            ModifyContact(name);
            SaveUpdate();
            manager.Navi.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int row, ContactData newName)
        {
            manager.Navi.GoToHomePage();
            SelectContactToUpdate(row);
            ModifyContact(newName);
            SaveUpdate();
            manager.Navi.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int row)
        {
            manager.Navi.GoToHomePage();
            SelectContactToDelete(row);
            DeleteSelectedContact();
            AcceptDeletingContact();
            manager.Navi.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navi.GoToHomePage();
            SelectContactToDelete(contact.Id);
            DeleteSelectedContact();
            AcceptDeletingContact();
            manager.Navi.GoToHomePage();
            return this;
        }


    }
}