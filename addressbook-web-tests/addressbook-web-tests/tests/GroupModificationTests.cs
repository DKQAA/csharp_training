using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.test
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {


            GroupData newData = new GroupData("Cat");
            newData.Header = "Dog";
            newData.Footer = "Fish";


            app.Groups.Modify(1, newData);

        }


    }
}
