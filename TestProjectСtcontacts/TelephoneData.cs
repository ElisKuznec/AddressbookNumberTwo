using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactTests
{
    internal class TelephoneData
    {
        private string homenumb;
        private string mobilenumb = "";
        private string worknumb = "";
        private string faxnumb = "";

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
