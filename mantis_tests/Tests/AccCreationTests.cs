using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData account = new AccountData()
            {
                Username = "testuser42",
                Password = "password",
                Email = "testuser42@localhost.localdomain"
            };
            
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);

            if(existingAccount != null)
            {
                app.Admin.DeleteAccount(account);
            }       

            app.James.Delete(account);
            app.James.Add(account);
            
            app.Registration.Register(account);
        }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");

        }
    }
}