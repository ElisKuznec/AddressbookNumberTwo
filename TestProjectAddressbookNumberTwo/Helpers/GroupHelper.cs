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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        { }

        public void AddIfNoGroups(int index)
        {
            while (!IsElementPresent(By.XPath($"//div[@id='content']/form/span[{index + 1}]/input")))
            {
                CreateGroup(new GroupData("Sadness"));
            }
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;

        }

        public GroupHelper ToEdithGroupForm()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        private List<GroupData> groupCache = null;

        internal List<GroupData> GetGroupList()
        {
            if(groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navi.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if(i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else 
                    { 
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                    
                }
            }
            
            return new List<GroupData>(groupCache);
        }

        public GroupHelper CreateGroup(GroupData group) 
        {
            CreateNewGroup();
            NamingFields(group);
            SaveGroup();
            manager.Navi.GoToGroupPage();
            return this;
        }

        public GroupHelper ModifyGroup(GroupData newName)
        {
            SelectGroup(0);
            ToEdithGroupForm();
            NamingFields(newName);
            UpdateGroup();
            manager.Navi.GoToGroupPage();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper CreateNewGroup()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper NamingFields(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        public GroupHelper SaveGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
    }
}
