using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {


            GroupData newData = new GroupData("NewGood");
            newData.Header = "big";
            newData.Footer = "group";

            if (app.Groups.GroupCreated() == false)
            {
                app.Groups.Create(newData);
            }

            app.Groups.Modify(1, newData);

        }
    }
}
