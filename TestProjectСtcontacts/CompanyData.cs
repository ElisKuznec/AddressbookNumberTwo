using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactTests
{
    internal class CompanyData
    {
        private string companytitle;
        private string companyname;
        private string companyaddress;

        public CompanyData(string companytitle, string companyname, string companyaddress)
        {
            this.companytitle = companytitle;
            this.companyname = companyname;
            this.companyaddress = companyaddress;
        }

        public string Companytitle
        {
            get
            {
                return companytitle;
            }
            set
            {
                companytitle = value;
            }
        }

        public string Companyname
        {
            get
            {
                return companyname;
            }
            set
            {
                companyname = value;
            }
        }

        public string Companyaddress
        {
            get
            {
                return companyaddress;
            }
            set
            {
                companyaddress = value;
            }
        }
    }
 }
