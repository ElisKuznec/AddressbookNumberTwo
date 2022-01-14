using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string name;
        private string middlename;
        private string lastname;

        private string homenumb = "5555";
        private string mobilenumb = "2";
        private string worknumb = "2";
        private string faxnumb = "2";

        private string emailone = "example.com";
        private string emailtwo = "6";
        private string emailthree = "6";

        private string companytitle = "Tetra";
        private string companyname = "OOO";
        private string companyaddress = "Sona";

        public ContactData(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))

            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name & Lastname == other.Lastname;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() & Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name) & Lastname.CompareTo(other.Lastname);
        }
        public override string ToString()
        {
            return $"contact = {name} {lastname}";
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
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


