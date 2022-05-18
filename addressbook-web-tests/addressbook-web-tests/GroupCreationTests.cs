﻿using System;
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
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("Astro");
            group.Header = "Boom";
            group.Footer = "Disk";
            FillGroupForm(group);
            SubmitGroupCeation();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
