using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public AppManager app;

        [SetUp]
        public void initApplication()
        {
            app = new AppManager();
        }
        [TearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}