using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string allContactDetails;

        public ContactData (string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public ContactData() 
        {
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
            return " Firstname= " + FirstName + "\nLastname= " + LastName + "\nMiddleName= " + MiddleName + "\nNickName= " + NickName +
                   "\nAddress= " + Address + "\nHomePhone= " + HomePhone + "\nMobilePhone= " + MobilePhone + "\nWorkPhone= " + WorkPhone +
                  "\nFaxPhone= " + FaxPhone + "\nEmail= " + Email + "\nEmail2= " + Email2 + "\nEmail3= " + Email3;
       
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

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string FaxPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }


        public string AllContactDetails
        {
            
            get
            {
                if (allContactDetails != null)
                {
                    return allContactDetails;
                }
                else
                {
                    string allDetails = (CleanUpAllDetails(GetContacts(FirstName, MiddleName, LastName, NickName, Title, Company, Address))
                                           + CleanUpAllDetails(GetPhones(HomePhone, MobilePhone, WorkPhone, FaxPhone))
                                           + CleanUpAllDetails(GetEmail(Email, Email2, Email3, Homepage))).Trim();
                    return allDetails;
                }
            }
            set
            {
                allContactDetails = value;
            }
        }


        private string GetContacts(string firstname, string middlename, string lastname, string nickname, string title, string company, string address)
        {
            return CleanUpAllDetails(GetNameFull(firstname, middlename, lastname))
                        + CleanUpAllDetails(nickname)
                        + CleanUpAllDetails(title)
                        + CleanUpAllDetails(company)
                        + CleanUpAllDetails(address);
        }

        private string GetNameFull(string firstname, string middlename, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = FirstName + " ";
            }
            if (middlename != null && middlename != "")
            {
                bufer = bufer + MiddleName + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + LastName + " ";
            }
            return bufer.Trim();
        }

        private string GetPhones(string home, string mobile, string work, string fax)
        {
            string bufer = "";
            if (home != null && home != "")
            {
                bufer = bufer + "H: " + HomePhone + "\r\n";
            }
            if (mobile != null && mobile != "")
            {
                bufer = bufer + "M: " + MobilePhone + "\r\n";
            }
            if (work != null && work != "")
            {
                bufer = bufer + "W: " + WorkPhone + "\r\n";
            }
            if (fax != null && fax != "")
            {
                bufer = bufer + "F: " + FaxPhone + "\r\n";
            }
            return bufer;
        }

        private string GetEmail(string email, string email2, string email3, string homepage)
        {
            string bufer = "";
            if (email != null && email != "")
            {
                bufer = bufer + email + "\r\n";
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + email2 + "\r\n";
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + email3 + "\r\n";
            }
            if (homepage != null && homepage != "")
            {
                bufer = bufer + "Homepage:" + "\r\n" + homepage + "\r\n";
            }
            return bufer;
        }


        private string CleanUpAllDetails(string detail) 
        {
            if (detail == null || detail == "")
            {
                return "";
            }
            return detail + "\r\n";
        }


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

        public static List<ContactData> GetContactAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }


    }
}
