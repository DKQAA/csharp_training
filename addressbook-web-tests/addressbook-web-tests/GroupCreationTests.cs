using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("Astro");
            group.Header = "Boom";
            group.Footer = "Disk";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCeation();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }
    }
}
