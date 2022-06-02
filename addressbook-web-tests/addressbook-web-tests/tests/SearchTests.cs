using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.SearchInput();
            app.Contacts.GetNumberOfSearchResults();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetNumberOfSearchResults());
        }
    }
}
