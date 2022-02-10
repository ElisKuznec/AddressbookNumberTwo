using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace webAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allphones;
        private string allmails;
        private string fullname;
        private string alldata;
        private string fullNameBlock;
        private string companyBlock;
        private string phonesBlock;
        private string emailBlock;
        private string datesBlock;
        private string lastBlock;


        public ContactData(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        public ContactData()
        {
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

        [Column(Name = "firstname")]
        public string Name { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        
        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "home")]
        public string Homenumb { get; set; }
        
        [Column(Name = "mobile")]
        public string Mobilenumb { get; set; }
        
        [Column(Name = "phone2")]
        public string Phone { get; set; }
        
        [Column(Name = "work")]
        public string Worknumb { get; set; }
        
        [Column(Name = "fax")]
        public string Faxnumb { get; set; }

        [Column(Name = "email")]
        public string Emailone { get; set; }

        [Column(Name = "email2")]
        public string Emailtwo { get; set; }

        [Column(Name = "email3")]
        public string Emailthree { get; set; }

        [Column(Name = "title")]
        public string Companytitle { get; set; }

        [Column(Name = "company")]
        public string Companyname { get; set; }

        [Column(Name = "address")]
        public string Companyaddress { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Birthday { get; set; }

        [Column(Name = "bmonth")]
        public string Birthmonth { get; set; }

        [Column(Name = "byear")]
        public string Birthyear { get; set; }

        [Column(Name = "aday")]
        public string Annyversaryday { get; set; }

        [Column(Name = "amonth")]
        public string Annyversarymounth { get; set; }

        [Column(Name = "ayear")]
        public string Annyversaryyear { get; set; }

        public string Address2 { get; set; }

        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allphones != null)
                {
                    return allphones;
                }
                else
                {
                    return CleanUp(Homenumb) + CleanUp(Mobilenumb) + CleanUp(Phone) + CleanUp(Worknumb).Trim();
                }

            }
            set
            {
                allphones = value;
            }
        }

        private string CleanUp(string numbs)
        {
            if (numbs == null || numbs == "")
            {
                return "";
            }
            return Regex.Replace(numbs, "[ -()]", "") + "\r\n";
        }

        public string Address { get; set; }

        public string AllMails
        {
            get
            {
                if (allmails != null)
                {
                    return allmails;
                }
                else
                {
                    return CleanUp(Emailone) + CleanUp(Emailtwo) + CleanUp(Emailthree).Trim();
                }

            }
            set
            {
                allmails = value;
            }
        }

        private string CleanUpEmails(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
        }

        public string GetAge(string day, string mounth, string year, string fieldn)
        {
            int userMounth;
            int Age;

            switch (mounth)
            {
                case "January":
                    userMounth = 1;
                    break;

                case "February":
                    userMounth = 2;
                    break;

                case "March":
                    userMounth = 3;
                    break;

                case "April":
                    userMounth = 4;
                    break;

                case "May":
                    userMounth = 5;
                    break;

                case "June":
                    userMounth = 6;
                    break;

                case "July":
                    userMounth = 7;
                    break;

                case "August":
                    userMounth = 8;
                    break;

                case "September":
                    userMounth = 9;
                    break;

                case "October":
                    userMounth = 10;
                    break;

                case "November":
                    userMounth = 11;
                    break;

                case "December":
                    userMounth = 12;
                    break;

                default:
                    userMounth = 0;
                    break;
            }

            if (year != "")
            {
                if ((DateTime.Now.Month >= userMounth) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (mounth != null && mounth != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + mounth;
                }
                else
                {
                    FullDate = mounth;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldn + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldn + FullDate;
                }
            }
            else return "";
        }
        public string GetAnniversary(string day, string mounth, string year, string fieldna)
        {
            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (mounth != null && mounth != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + mounth;
                }
                else
                {
                    FullDate = mounth;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != null && year != "")
                {
                    return fieldna + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldna + FullDate;
                }
            }
            else return "";
        }

        public string AllData
        {
            get
            {
                string fullNameBlock = FullNameBlock;
                string compBlock = CompanyBlock;
                string phonesBlock = PhonesBlock;
                string emailBlock = EmailBlock;
                string datesBlock = DatesBlock;
                string lastBlock = LastBlock;
                string allDetails2 = "";



                if (alldata != null)
                {
                    return alldata = "";
                }
                else
                {
                    if (fullNameBlock != "")
                    {
                        allDetails2 = fullNameBlock;
                    }
                    if (compBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNabove(compBlock);
                        }
                        else
                        {
                            allDetails2 = compBlock;
                        }
                    }
                    if (phonesBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(phonesBlock);
                        }
                        else
                        {
                            allDetails2 = phonesBlock;
                        }
                    }
                    if (emailBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(emailBlock);
                        }
                        else
                        {
                            allDetails2 = emailBlock;
                        }
                    }
                    if (datesBlock != null && datesBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(datesBlock);
                        }
                        else
                        {
                            allDetails2 = datesBlock;
                        }
                    }
                    else
                        if (lastBlock != "" && lastBlock != "P:")
                    {
                        allDetails2 += "\r\n";

                    }
                    if (lastBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(lastBlock);
                        }
                        else
                        {
                            allDetails2 = lastBlock;
                        }
                    }
                }
                return allDetails2.Trim();
            }
            set
            {
                alldata = value;
            }
        }

        public string FullNameBlock
        {
            get
            {
                if (fullNameBlock != null)
                {
                    return fullNameBlock;
                }
                else
                {
                    if (ReturnFullName(Name.Trim(), Middlename.Trim(), Lastname.Trim()) != "")
                    {
                        if (Nickname != "")
                        {
                            return (ReturnFullName(Name.Trim(), Middlename.Trim(), Lastname.Trim()) + "\r\n" + Nickname.Trim());
                        }
                        else
                        {
                            return ReturnFullName(Name.Trim(), Middlename.Trim(), Lastname.Trim());
                        }
                    }
                    else
                        return (ReturnDetailwithoutRN(Nickname));
                }
            }
            set
            {
                fullNameBlock = value;
            }
        }

        public string CompanyBlock
        {
            get
            {
                string companyBlock = "";
                if (Companytitle != null && Companytitle != "")
                {
                    companyBlock = Companytitle.Trim();
                }
                if (Companyname != null && Companyname != "")
                {
                    if (companyBlock != null && companyBlock != "")
                    {
                        companyBlock += "\r\n" + Companyname.Trim();
                    }
                    else
                    {
                        companyBlock = Companyname.Trim();
                    }
                }
                if (Address != null && Address != "")
                {
                    if (companyBlock != null && companyBlock != "")
                    {
                        companyBlock += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        companyBlock = Address.Trim();
                    }
                }
                return companyBlock;
            }
            set
            {
                companyBlock = value;
            }
        }

        public string PhonesBlock
        {
            get
            {
                string phonesBlock = "";

                if (Homenumb != null && Homenumb != "")
                {
                    phonesBlock = ("H: " + Homenumb.Trim()).Trim();
                }
                if (Mobilenumb != null && Mobilenumb != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("M: " + Mobilenumb.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("M: " + Mobilenumb.Trim()).Trim();
                    }
                }
                if (Worknumb != null && Worknumb != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("W: " + Worknumb.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("W: " + Worknumb.Trim()).Trim();
                    }
                }
                if (Faxnumb != null && Faxnumb != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("F: " + Faxnumb.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("F: " + Faxnumb.Trim()).Trim();
                    }
                }
                return phonesBlock;
            }
            set
            {
                phonesBlock = value;
            }
        }

        public string EmailBlock
        {
            get
            {
                string emailBlock = "";

                if (Emailone != null && Emailone != "")
                {
                    emailBlock = Emailone;
                }
                if (Emailtwo != null && Emailtwo != "")
                {
                    if (emailBlock != null && emailBlock != "")
                    {
                        emailBlock = emailBlock.Trim() + "\r\n" + Emailtwo.Trim();
                    }
                    else
                    {
                        emailBlock = Emailtwo;
                    }
                }
                if (Emailthree != null && Emailthree != "")
                {
                    if (emailBlock != null && emailBlock != "")
                    {
                        emailBlock = emailBlock + "\r\n" + Emailthree.Trim();
                    }
                    else
                    {
                        emailBlock = Emailthree;
                    }
                }
                if (Homepage != null && Homepage != "")
                {
                    if (emailBlock != null && emailBlock != "")
                    {
                        emailBlock = emailBlock + "\r\n" + "Homepage:\r\n" + Homepage.Trim();
                    }
                    else
                    {
                        emailBlock = "Homepage:\r\n" + Homepage.Trim();
                    }
                }
                return emailBlock;
            }
            set
            {
                emailBlock = value;
            }
        }

        public string DatesBlock
        {
            get
            {
                string birthString = GetAge(Birthday, Birthmonth, Birthyear, "Birthday ");
                string annivString = GetAnniversary(Annyversaryday, Annyversarymounth, Annyversaryyear, "Anniversary ");
                string birthAnnivBlock = "";

                if (birthString != null && birthString != "")
                {
                    DatesBlock = birthString.Trim();
                }
                if (annivString != null && annivString != "")
                {
                    if (birthAnnivBlock != null && birthAnnivBlock != "")
                    {
                        birthAnnivBlock += "\r\n" + annivString.Trim();
                    }
                    else
                    {
                        birthAnnivBlock = annivString.Trim();
                    }
                }
                return birthAnnivBlock;
            }
            set
            {
                DatesBlock = value;
            }
        }

        public string LastBlock
        {
            get
            {
                string lastBlock = "";
                if (Address2.Trim() != null && Address2.Trim() != "")
                {
                    lastBlock = Address2.Trim();
                }
                if (Phone != null && Phone != "")
                {
                    if (lastBlock != null && lastBlock != "")
                    {
                        lastBlock += "\r\n\r\n" + ("P: " + Phone.Trim()).Trim();
                    }
                    else
                    {
                        lastBlock = "\r\n" + ("P: " + Phone.Trim()).Trim();
                    }
                }
                if (Notes.Trim() != null && Notes.Trim() != "")
                {
                    if (lastBlock != null && lastBlock != "")
                    {
                        lastBlock += "\r\n\r\n" + Notes.Trim();
                    }
                    else
                    {
                        lastBlock = Notes.Trim();
                    }
                }
                return lastBlock;
            }
            set
            {
                lastBlock = value;
            }
        }

        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        public string ReturnDetailwithoutRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnDetailwithRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnDetailwithRNRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }

        public string ReturnFullName(string name, string middlename, string lastname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
                if (FullName != "")
                {
                    FullName += " " + middlename;
                }
                else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName;
        }

        public string FullName
        {
            get
            {
                if (fullname != null)
                {
                    return fullname;
                }
                else
                {
                    return Regex.Replace($"{Name} {Middlename} {Lastname}", @"\s+", "");
                }
            }

            set
            {
                fullname = value;
            }
        }


        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }


    }
}


