using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCartTests.Pages;
using System.Threading;

namespace OpenCartTests.Tests.Dimon
{
    [TestFixture]
    class SearchSortAndShow
    {
        private IWebDriver driver;
        private ProductsList products;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            products = ProductsData.GetProductData();
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            // driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
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
        public void Search_Default()
        {
            // Arrange
            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Navigate().GoToUrl(mainUrl);
            //int expectedCount = 15;
            //string[] expectedText = products.Products.SearchDefault.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //string[] actualText = new string[16];
            //int i = 0;
            //string expectedShowing = "Showing 1 to 15 of 55 (4 Pages)";

            // Act

            //driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click(); // Click on 'Search' button 
            //driver.FindElement(By.CssSelector("#input-search")).SendKeys("a"); // Input 'a' in 'Search' field on 'Search' page
            //driver.FindElement(By.CssSelector("#description")).Click(); // Click on 'Search in product descriptions' button on 'Search' page
            //driver.FindElement(By.CssSelector("#button-search")).Click(); // Click on 'Search' button on 'Search' page
            //int actualCount = driver.FindElements(By.CssSelector(".product-thumb")).Count; // Count how many products on page
            //IList<IWebElement> listOfProducts = driver.FindElements(By.XPath("//div[contains(@class, 'caption')]//a")); // List with all products names
            //string actualShowing = driver.FindElement(By.XPath("//div[contains(@class, 'col') and contains(text(), 'Showing')]")).Text; // Get text from the bottom of the page about products on page

            // Assert

            //foreach (IWebElement product in listOfProducts) // Assert expected product names and actual match
            //{
            //    actualText[i] = product.Text;
            //    Assert.AreEqual(expectedText[i], actualText[i]);
            //    i++;
            //}
            //Assert.AreEqual(actualCount, expectedCount); // Assert expected count and actual match
            //Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }
    }
}
