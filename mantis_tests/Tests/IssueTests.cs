using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssues : TestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData
            {
                Summary = "administrator",
                Description = "root",
                Category = "1"
            };
            ProjectData project = new ProjectData
            {
                Id = "General"
            };
            app.API.CreateNewIssue(account, issueData, project);
        }
    }
}