using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
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

            return Lastname == other.Lastname & Name == other.Name;

        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() & Name.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            if (this.Name != other.Name)
            {
                return Name.CompareTo(other.Name);
            }
            return Lastname.CompareTo(other.Lastname) & Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return $"contact = {Lastname} {Name} ";
        }

        public string Name { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }
        public string Homenumb { get; set; }

        public string Mobilenumb { get; set; }

        public string Worknumb { get; set; }

        public string Faxnumb { get; set; }

        public string Emailone { get; set; }

        public string Emailtwo { get; set; }

        public string Emailthree { get; set; }

        public string Companytitle { get; set; }

        public string Companyname { get; set; }

        public string Companyaddress { get; set; }


        public string Id { get; set; }
    }
}


