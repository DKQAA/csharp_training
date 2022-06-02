using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = new ContactData("Andrey","Abatov");
            newData.Address = "Bronx";
            newData.HomePhone = "+73472356514";
            newData.MobilePhone = "+79003332100";
            newData.WorkPhone = "+79436548998";
            newData.Email = "cat2000@ya.ru";
            newData.Email2 = "wowworld100@google.com";
            newData.Email3 = "slimboos@rambler.ru";


            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldDataCon = oldContacts[0];

            app.Contacts.Modify(0, newData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts) 
            {
                if (contact.Id == oldDataCon.Id)
                {
                    Assert.AreEqual(contact.FirstName, newData.FirstName);
                    Assert.AreEqual(contact.LastName, newData.LastName);
                }
            }

        }
    }
}
