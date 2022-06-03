using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string contactDetails;

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName && FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return LastName + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }

                else
                {
                    return (PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string PhoneCleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        private string EmailCleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return Regex.Replace(email, "[ ]", "") + "\r\n";

        }

        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return contactDetails;
                }
                else
                {
                    string fullName = FullNameGluing();
                    string address = Address + "\r\n" + "\r\n";
                    string phones = PhoneGluing(HomePhone) + PhoneGluing(MobilePhone) + PhoneGluing(WorkPhone) + "\r\n";
                    string contactDetails = fullName + address + phones + AllEmails;
                    return contactDetails;
                }
            }
            set
            {
                contactDetails = value;
            }
        }

        private string FullNameGluing()
        {
            if (LastName.Length > 0 && FirstName.Length > 0)
            {
                string fullName = (FirstName + " " + LastName + "\r\n");
                return fullName;
            }
            else
            {
                string fullName = (FirstName + LastName + "\r\n");
                return fullName;
            }
        }

        private string PhoneGluing(string phone)
        {
            if (!string.IsNullOrEmpty(phone))
            {
                if (phone == HomePhone) { phone = "H: " + HomePhone + "\r\n"; }
                else if (phone == WorkPhone) { phone = "W: " + WorkPhone + "\r\n"; }
                else if (phone == MobilePhone) { phone = "M: " + MobilePhone + "\r\n"; }
            }
            return phone;
        }
    }
}
