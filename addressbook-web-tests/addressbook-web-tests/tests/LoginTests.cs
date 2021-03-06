using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            // prepare
            app.Auth.Logout();
            Thread.Sleep(1000);

            //action
            AccountData account = new AccountData("admin", "54321");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
