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
            //driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=product/category&path=18");
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void AddToComparisionTest()
        {
            LaptopsAndNotebooksPage lapAndNotePage = new LaptopsAndNotebooksPage(driver);

            string selectedProduct = lapAndNotePage.GetFirstProductLinkText();

            ProductComparisonPage productComparisonPage = lapAndNotePage.AddToCompare();

            string actualProduct = productComparisonPage.GetLastProductText();
            Assert.AreEqual(selectedProduct, actualProduct);
            //
        }
    }
}