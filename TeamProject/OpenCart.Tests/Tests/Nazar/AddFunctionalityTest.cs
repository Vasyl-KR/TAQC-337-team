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
    public class AddFunctionalityTest : BaseTest
    {
        private IWebDriver driver;
        private ListUsers users;
        private const string email = "nazar.l135@gmail.com";
        private const string password = "lol123";
        private const string URL_LoginPage = "http://atqc-shop.epizy.com/index.php?route=account/login";


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            users = ReaderUserData.GetUsers();
            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl(URL_LoginPage);

            new HomePage(driver)
                .GoToLoginPage()
                .SuccessRegistratorLogin(email, password);

             //NUnit.Framework.Assert.AreEqual(new HomePage(driver)
             //   .GoToLoginPage()
             //   .SuccessRegistratorLogin(email, password), new AccountPage(driver));
        }

        [Test]
        public void Add_newAddress()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            Pages.PagesList pages = new Pages.PagesList(driver);
            
            int BeforeAdding = pages.AddressPage.ListAddresses.Count();
            
            int AfterAdding = pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[0]) 
                .ListAddresses.Count();

            NUnit.Framework.Assert.AreEqual(BeforeAdding + 1, AfterAdding, "Compare the text of the comunicat about creating" + BeforeAdding + " " + AfterAdding);

        }

        [Test]
        public void Edite_Address()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");
            Pages.PagesList pages = new Pages.PagesList(driver);


            string actual = pages.AddressPage
                .EditRaw(2)
                .SuccessfullEditionAddress(users.Users[0])
                .GetMessageBox();
 
            string expected = "Your address has been successfully updated";

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare the text of the comunicat about edit");
        }

        [Test]
        public void Delete_Address()
        {
            
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/address");

            Pages.PagesList pages = new Pages.PagesList(driver);
           
            string actual = pages.AddressPage.DeleteRaw(2).GetMessageBox();

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

