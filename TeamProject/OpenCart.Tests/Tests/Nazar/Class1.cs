using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{

    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        private ListUsers users;
        private const string email = "nazar.l135@gmail.com";
        private const string password = "lol123";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            users = ReaderUserData.GetUsersData();
            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LogIn(email, password);
           // NUnit.Framework.CollectionAssert.AreEqual(LogIn(email, password), new AccountPage);
        }

        [Test]
        public void Add_newAddress()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            int BeforeAdding = new AddressPage(driver).ListAddresses.Count();
            int AfterAdding = new AddressPage(driver)
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[1])
                .ListAddresses.Count();

            NUnit.Framework.Assert.AreEqual(BeforeAdding + 1, AfterAdding, "Compare the text of the comunicat about creating");

        }

        [Test]
        public void Edite_Address()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            string actual = new AddressPage(driver)
                .EditRaw(2)
                .SuccessfullEditionAddress(users.Users[0])
                .GetMessageAddressEdited();
 
            string expected = "Your address has been successfully updated";

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare the text of the comunicat about edit");
        }

        [Test]
        public void Delete_Address()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            string actual = new AddressPage(driver).DeleteRaw(2).GetMessageAddressDeleted();
            string expected = "Your address has been successfully deleted";
            NUnit.Framework.Assert.AreEqual(expected, actual, "Compare the text of the comunicat about delite");
        }

        private AccountPage LogIn(string email, string password)
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/login");

            return new HomePage(driver)
                .GoToLoginPage()
                .SuccessRegistratorLogin(email, password);
        }

        private void LogOut()
        {
            new HomePage(driver)
                .GoToLogoutPage();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            LogOut();
            driver.Quit();
            driver.Dispose();
        }

    }
}

