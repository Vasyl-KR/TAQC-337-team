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


            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--start-maximized");
            //Driver = new ChromeDriver(chromeOptions);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Driver.Navigate().GoToUrl(URL_LoginPage);

            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(EMAIL, PASSWORD);

            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");

            //NUnit.Framework.Assert.AreEqual(new HomePage(driver)
            //   .GoToLoginPage()
            //   .SuccessRegistratorLogin(email, password), new AccountPage(driver));
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
