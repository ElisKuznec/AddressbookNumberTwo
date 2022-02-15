using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]

    public class ProjectTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData
            {
                ProjectName = "pr0" + DateTime.Now.ToString(),
                ProjectDescription = "Description"
            };

            List<ProjectData> oldProjects = app.API.GetAPIProjectsList(account);


            app.Auth.Login();
            app.Project.CreateProject(project);

            List<ProjectData> newProjects = app.API.GetAPIProjectsList(account);

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Auth.Logout();
        }
        [Test]
        public void ProjectDeletionTest()
        {
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            ProjectData newproject = new ProjectData
            {
                ProjectName = "pr0" + DateTime.Now.ToString(),
                ProjectDescription = "Description"
            };
            if (app.API.GetAPIProjectsList(account).Count == 0)
            {
                app.Project.CreateProject(newproject);
            }


            List<ProjectData> oldProjects = app.API.GetAPIProjectsList(account);
            ProjectData delproject = new ProjectData
            {
                ProjectName = oldProjects[0].ProjectName,
                ProjectDescription = oldProjects[0].ProjectDescription
            };

            app.Auth.Login();
            app.Project.RemoveProject();


            List<ProjectData> newProjects = app.API.GetAPIProjectsList(account);

            oldProjects.Remove(delproject);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);

            app.Auth.Logout();
        }
    }
}