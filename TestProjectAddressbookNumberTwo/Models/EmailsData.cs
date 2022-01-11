using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    public class EmailsData
    {
        private string emailone;
        private string emailtwo = "6";
        private string emailthree = "6";

        public EmailsData(string emailone)
        {
            this.emailone = emailone;
        }

        public string Emailone
        {
            get
            {
                return emailone;
            }
            set
            {
                emailone = value;
            }
        }

        public string Emailtwo
        {
            get
            {
                return emailtwo;
            }
            set
            {
                emailtwo = value;
            }
        }

        public string Emailthree
        {
            get
            {
                return emailthree;
            }
            set
            {
                emailthree = value;
            }
        }
    }
}
