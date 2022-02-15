using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };

            GoToHomePage();
            EnterUsername(account.Name);
            ClickLogin();
            EnterPassword(account.Password);
            ClickLogin();
        }
        private void ClickLogin()
        {
            driver.FindElement(By.XPath("//input[@type= 'submit']")).Click();
        }
        private void EnterUsername(string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
        }
        private void EnterPassword(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
        }
        private void GoToHomePage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
        }
        public void Logout()
        {
            driver.FindElement(By.ClassName("user-info")).Click();
            driver.FindElement(By.CssSelector("#navbar-container > div.navbar-buttons.navbar-header.navbar-collapse.collapse > ul > li.grey.open > ul > li:nth-child(4) > a")).Click();
        }
    }
}