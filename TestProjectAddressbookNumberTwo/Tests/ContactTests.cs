using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace webAddressBookTests
{
    [TestFixture]
    public class ContactTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactProvider()
            
        {
           List<ContactData> contacts = new List<ContactData>();
           for (int i = 0; i < 3; i++)
           {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(15))
                {
                });
           }
            return contacts;
           }
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Name = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }


        [Test, TestCaseSource("ContactDataFromExcelFile")]
            
            public void ContactTest(ContactData newOne)
            
            {
                List<ContactData> oldContacts = ContactData.GetAll();

                app.Contact.FullContactCreation(newOne);

                List<ContactData> newContacts = ContactData.GetAll();

                oldContacts.Add(newOne);
                oldContacts.Sort();
                newContacts.Sort();

                Assert.AreEqual(oldContacts, newContacts);
            }
      }
}
