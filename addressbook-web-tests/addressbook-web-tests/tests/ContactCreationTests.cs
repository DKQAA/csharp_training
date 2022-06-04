using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("Pavel","Abidov");

            contact.MiddleName = "Ivanovic";
            contact.NickName = "BigDragon";
            contact.Address = "Monte Carlo";
            contact.HomePhone = "+73472356515";
            contact.MobilePhone = "+79003332100";
            contact.WorkPhone = "+79436548998";
            contact.FaxPhone = "+734725644";
            contact.Email = "dragon2000@ya.ru";
            contact.Email2 = "hiworld100@google.com";
            contact.Email3 = "bigfish@rambler.ru";


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
