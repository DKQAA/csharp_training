using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("Andrey","Brotskiy");

            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactInt in newContacts)
            {
                Assert.AreNotEqual(contactInt.Id, toBeRemoved.Id);
            }

        }
    }
}
