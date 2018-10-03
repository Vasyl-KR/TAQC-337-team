using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
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
        private const string URL_LoginPage = "http://atqc-shop.epizy.com/index.php?route=account/login";


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            users = ReaderUserData.GetUsersData();
            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl(URL_LoginPage);

            new HomePage(driver)
                .GoToLoginPage()
                .SuccessRegistratorLogin(email, password);

            // NUnit.Framework.CollectionAssert.AreEqual(LogIn(email, password), new AccountPage);
        }

        [Test]
        public void Add_newAddress()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            AddressPage addressPage = new AddressPage(driver);
            PageFactory.InitElements(driver, addressPage);
            int BeforeAdding = addressPage.ListAddresses.Count();
            EditAddressPage editAddressPage = addressPage.ClickNewAddressButton();
            PageFactory.InitElements(driver, editAddressPage);
            addressPage = editAddressPage
                .SuccessfullEditionAddress(users.Users[1]); 
             int AfterAdding = addressPage.ListAddresses.Count();

            NUnit.Framework.Assert.AreEqual(BeforeAdding + 1, AfterAdding, "Compare the text of the comunicat about creating" + BeforeAdding + " " + AfterAdding);

        }

        [Test]
        public void Edite_Address()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");           
            AddressPage addressPage = new AddressPage(driver);
            PageFactory.InitElements(driver,addressPage);
            EditAddressPage editAddressPage = addressPage
                .EditRaw(2);
            PageFactory.InitElements(driver, editAddressPage);
            string actual = editAddressPage
                .SuccessfullEditionAddress(users.Users[0])
                .GetMessageBox();
 
            string expected = "Your address has been successfully updated";

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare the text of the comunicat about edit");
        }

        [Test]
        public void Delete_Address()
        {
            
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            AddressPage addressPage = new AddressPage(driver);
            PageFactory.InitElements(driver,addressPage);
            string actual = addressPage.DeleteRaw(2).GetMessageBox();

            string expected = "Your address has been successfully deleted"; 
            NUnit.Framework.Assert.AreEqual(expected, actual, "Compare the text of the comunicat about delite");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            new HomePage(driver)
                .GoToLogoutPage();

            driver.Quit();
            driver.Dispose();
        }

    }
}

