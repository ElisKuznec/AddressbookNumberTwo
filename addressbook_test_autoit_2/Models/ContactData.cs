using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }


        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return 1;
            }
            if (this.Name != other.Name)
            {
                return Name.CompareTo(other.Name);
            }
            else
            if (this.Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            return 0;
        }



        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Name == other.Name && Lastname == other.Lastname;
        }
    }
}