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
        AccountData account = new AccountData()
        {
            Username = "administrator",
            Password = "root",

        };

        ProjectData project = new ProjectData
        {
            ProjectName = "project_" + DateTime.Now.ToString(),
            ProjectDescription = "Description"
        };



        [Test]
        public void TestProjectCreation()
        {
            app.Auth.Login(account);
            app.Navi.GoToProjectsPage();

            List<ProjectData> oldProjects = app.Project.GetProjectList();
            app.Project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectList().Count);

            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }

        [Test]
        public void TestProjectRemoval()
        {

            app.Auth.Login(account);
            app.Navi.GoToProjectsPage();

            List<ProjectData> projectsList = app.Project.GetProjectList();
            if (projectsList.Count == 0)
            {
                app.Project.Create(project);
            }

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Remove(1);

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectList().Count);

            List<ProjectData> newProjects = app.Project.GetProjectList();
            oldProjects.Remove(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}