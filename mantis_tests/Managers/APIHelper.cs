using System.Collections.Generic;
namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, IssueData issueData, ProjectData project)
        {
            mantis_tests.Mantis.MantisConnectPortTypeClient client = new mantis_tests.Mantis.MantisConnectPortTypeClient();
            mantis_tests.Mantis.IssueData issue = new mantis_tests.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantis_tests.Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
        public List<ProjectData> GetAPIProjectsList(AccountData account)
        {
            var projectList = new List<ProjectData>();
            mantis_tests.Mantis.MantisConnectPortTypeClient client = new mantis_tests.Mantis.MantisConnectPortTypeClient();
            mantis_tests.Mantis.ProjectData[] projectData = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (var project in projectData)
            {
                projectList.Add(new ProjectData
                {
                    Id = project.id,
                    ProjectDescription = project.description,
                    ProjectName = project.name
                });
            }
            return projectList;
        }
    }
}