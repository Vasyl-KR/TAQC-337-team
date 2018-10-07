using NUnit.Framework;
using OpenCartTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{

    [TestFixture]
    public abstract class NazarBaseTest : BaseTest
    {
        private const string EMAIL = "nazar.l135@gmail.com";
        private const string PASSWORD = "lol123";
        private const string URL_LoginPage = "http://atqc-shop.epizy.com/index.php?route=account/login";
        public const string URL_AddressPage = "http://atqc-shop.epizy.com/index.php?route=account/address";
        public ListUsers users
        {
            get
            {
                return ReaderUserData.GetUsers();
            }
        }

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Driver.Navigate().GoToUrl(URL_LoginPage);

            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(EMAIL, PASSWORD);

            Driver.Navigate().GoToUrl(URL_AddressPage);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Pages.HomePage
                .GoToLogoutPage();

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
