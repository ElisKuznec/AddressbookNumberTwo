using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressBookTests
{
    public class FullNameData : IEquatable<FullNameData>, IComparable<FullNameData>
    {
        private string name;
        private string middlename;
        private string lastname;

        public FullNameData(string name)
        {
            this.name = name;
        }

        public FullNameData(string name, string text) : this(name)
        {

        }

        public bool Equals(FullNameData other)
        {
            if (Object.ReferenceEquals(other, null))

            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
            return Middlename == other.Middlename;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
            return Middlename.GetHashCode();
        }

        public int CompareTo(FullNameData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
            return Middlename.CompareTo(other.Middlename);
        }
        public override string ToString()
        {
            return $"contact = {name} {middlename}";
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
    }
}
