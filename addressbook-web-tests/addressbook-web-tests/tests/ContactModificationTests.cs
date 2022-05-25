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



            ContactData newData = new ContactData("Andrey");
            newData.LastName = null;

            app.Contacts.Modify(2, newData);

        }
    }
}
