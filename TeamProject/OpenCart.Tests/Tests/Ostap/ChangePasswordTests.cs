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
            LoginPage loginPage = new LoginPage(driver);
            //Console.WriteLine(loginPage.GetCurrencyText());

            loginPage.GetRegiser();
            Thread.Sleep(3000);
            loginPage.GetLogin();
            Thread.Sleep(3000);
            loginPage.ClickMyAccountDropDownMenu();
            loginPage.GetRegiser();
            Thread.Sleep(3000);
            loginPage.GetLogin();
            Thread.Sleep(3000);
        }
    }
}
