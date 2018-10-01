using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace OpenCartTests.Tests.Ostap
{
    [TestFixture]
    class ChangePasswordTests
    {
        private IWebDriver driver;
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }
        
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            LoginPage loginPage = new HomePage(driver).GoToLoginPage();

            AccountPage accountPage =loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty123");

            ChangePasswordPage changePasswordPage = accountPage.GoToChangePassword();
            accountPage = changePasswordPage.SuccessChangePassword("qwerty1234");

            LogoutPage logoutPage = accountPage.GoToLogoutPage();
            loginPage = logoutPage.GoToLoginPage();
            loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty1234");

            changePasswordPage = accountPage.GoToChangePassword();
            accountPage = changePasswordPage.SuccessChangePassword("qwerty123");
            accountPage.GoToLogoutPage();
        }
    }
}
