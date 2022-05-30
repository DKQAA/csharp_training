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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
