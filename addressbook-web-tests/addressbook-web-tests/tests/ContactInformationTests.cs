using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

          
            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromForm.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationDetails() 
        {
            ContactData fromTable = app.Contacts.GetFullContactInformationEditForm(0); 
            ContactData fromForm = app.Contacts.GetContactInformationFromEditFormDetails(0);

            // verification
            Console.Write("------------------------------");
            Console.Out.Write(fromTable.AllContactDetails);
            Console.Write("------------------------------");
            Console.Out.Write(fromForm.AllContactDetails);
            Console.Write("------------------------------");

            Assert.AreEqual(fromTable.AllContactDetails, fromForm.AllContactDetails);
        }

    }
}
