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
            new HomePage(driver)
                .GoToLoginPage()
                .SuccessRegistratorLogin("ostap@gmail.com", "qwerty123")
                .GoToChangePassword()
                .SuccessChangePassword("qwerty1234")
                .GoToLogoutPage()
                .GoToLoginPage()
                .SuccessRegistratorLogin("ostap@gmail.com", "qwerty1234")
                .GoToChangePassword()
                .SuccessChangePassword("qwerty123")
                .GoToLogoutPage();
        }
    }
}
