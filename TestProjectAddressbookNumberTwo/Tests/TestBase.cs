using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }
    }
}
