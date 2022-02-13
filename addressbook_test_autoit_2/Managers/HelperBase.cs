using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit

{
    public class HelperBase
    {
        protected AppManager manager;
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            WINTITLE = AppManager.WINTITLE;
            this.aux = manager.Aux;
        }

    }
}
