using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("Andrey");
            newData.LastName = "Anikin";

            if (app.Contacts.ContactCreated() == false)
            {
                app.Contacts.Create(newData);
            }

            app.Contacts.Remove(2);
        }
    }
}
