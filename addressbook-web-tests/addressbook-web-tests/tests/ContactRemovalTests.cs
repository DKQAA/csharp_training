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
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("Andrey","Brotskiy");
            newData.Address = "Paris";
            newData.HomePhone = "+73472356515";
            newData.MobilePhone = "+79003332100";
            newData.WorkPhone = "+79436548998";
            newData.Email = "cat2000@ya.ru";
            newData.Email2 = "byworld100@google.com";
            newData.Email3 = "oldfish@rambler.ru";


            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = ContactData.GetContactAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetContactAll();
            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactInt in newContacts)
            {
                Assert.AreNotEqual(contactInt.Id, toBeRemoved.Id);
            }

        }
    }
}
