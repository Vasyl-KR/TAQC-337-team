using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Vasyl
{
    [TestFixture]
    public class ComparisionTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
           
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void AddToComparisionTest()
        {
            HomePage homePage = new HomePage(driver);
            LaptopsAndNotebooksPage lapAndNotePage = homePage.GoToLaptopPage();

            string selectedProduct = lapAndNotePage.GetFirstProductLinkText();

            ProductComparisonPage productComparisonPage = lapAndNotePage.AddToCompare();

            string actualProduct = productComparisonPage.GetLastProductText();
            Assert.AreEqual(selectedProduct, actualProduct);
            //
        }
    }
}