using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    public class TelephoneData
    {
        private string homenumb;
        private string mobilenumb = "2";
        private string worknumb = "2";
        private string faxnumb = "2";

        public TelephoneData(string homenumb)
        {
            this.homenumb = homenumb;
        }
        public string Homenumb
        {
            get
            {
                return homenumb;
            }
            set
            {
                homenumb = value;
            }
        }

        public string Mobilenumb
        {
            get
            {
                return mobilenumb;
            }
            set 
            { 
                mobilenumb = value; 
            }
        }

        public string Worknumb
        {
            get
            {
                return worknumb;
            }
            set
            {
                worknumb = value;
            }
        }
        public string Faxnumb
        {
            get
            {
                return faxnumb;
            }
            set
            {
                faxnumb = value;
            }
        }
    }
}
