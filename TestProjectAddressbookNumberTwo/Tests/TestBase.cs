﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace webAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupAppManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
