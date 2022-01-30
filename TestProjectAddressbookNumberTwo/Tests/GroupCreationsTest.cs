using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace webAddressBookTests
{
    [TestFixture]
    public class GroupCreationsTest : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }


        [Test, TestCaseSource("GroupDataFromFile")]

        public void GroupCreationTest(GroupData group)
        { 
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count +1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTests()
        {
            GroupData group = new GroupData("a'");
            group.Header = "a'";
            group.Footer = "a'";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
