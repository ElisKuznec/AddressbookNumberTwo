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
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectHelper CreateProject(ProjectData project)
        {
            OpenExplorer();
            OpenProjectsList();
            InitNewProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        private List<ProjectData> projectList = new List<ProjectData>();

        public List<ProjectData> GetProjectList()
        {
            manager.Navi.GoToProjectsPage();
            projectList.Clear();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    ProjectName = element.Text
                });
            }
            return projectList;

        }

        private void ClickOnProjectLink()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a")).Click();
        }

        private void SubmitRemoval()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div[2]/div/form/fieldset/input[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/form/input[4]")).Click();
        }


        public ProjectHelper RemoveProject()
        {
            OpenExplorer();
            OpenProjectsList();
            ClickOnProjectLink();
            SubmitRemoval();
            return this;
        }

        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }


        public ProjectHelper InitNewProjectCreation()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[1]/form/button")).Click();
            return this;

        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.ProjectName);
            Type(By.Name("description"), project.ProjectDescription);
            return this;

        }


        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            return this;

        }


        public ProjectHelper SelectProject()
        {
            driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a[1]")).Click();
            return this;
        }

        public ProjectHelper Remove()
        {
            driver.FindElement(By.XPath("//fieldset/input[@type='submit']")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            return this;
        }

        public List<ProjectData> GetProjectListByWeb()
        {
            mantis_tests.Mantis.MantisConnectPortTypeClient client = new mantis_tests.Mantis.MantisConnectPortTypeClient();
            mantis_tests.Mantis.IssueData issue = new mantis_tests.Mantis.IssueData();
            OpenExplorer();
            OpenProjectsList();
            projectList.Clear();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    ProjectName = element.Text
                });
            }
            return projectList;
        }

        private void OpenExplorer()
        {
            driver.FindElement(By.CssSelector(".nav-list > li:nth-child(7) > a:nth-child(1) > span:nth-child(2)")).Click();
        }

        private void OpenProjectsList()
        {
            driver.FindElement(By.CssSelector(".nav-tabs > li:nth-child(3) > a:nth-child(1)")).Click();
        }
    }
}