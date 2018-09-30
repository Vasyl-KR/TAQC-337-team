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

namespace OpenCartTests.Tests.Dimon
{
    [TestFixture]
    class SearchFunctionality
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
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void Search_Criteria()
        {
            // Arrange
            int expectedCount = 7;
            string[] expectedText = products.Products.SearchCriteria.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[8];
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
                
            // Assert

            //// Arrange
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Navigate().GoToUrl(mainUrl);
            //int expectedCount = 7;
            //string[] expectedText = products.Products.SearchCriteria.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ////string[] expectedText = { "Apple Cinema 30\"", "Apple iPad 2", "Apple iPad 3", "Apple iPad 4", "Apple iPad Air", "Apple iPhone SE 64GB", "Apple Magic Mouse" };
            //string[] actualText = new string[8];
            //int i = 0;

            //// Act
            //driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click(); // Click on 'Search' button 
            //driver.FindElement(By.CssSelector("#input-search")).SendKeys("Apple"); // Input 'Apple' in 'Search' field on 'Search' page
            //driver.FindElement(By.CssSelector("#button-search")).Click(); // Click on 'Search' button on 'Search' page
            //int actualCount = driver.FindElements(By.CssSelector(".product-thumb")).Count; // Count how many products on page
            //IList<IWebElement> listOfProducts = driver.FindElements(By.XPath("//div[contains(@class, 'caption')]//a")); // List with all products names

            //// Assert
            //foreach (IWebElement product in listOfProducts) // Assert expected product names and actual match
            //{
            //    actualText[i] = product.Text;
            //    Assert.AreEqual(expectedText[i], actualText[i]);
            //    i++;
            //}
            //Assert.AreEqual(actualCount, expectedCount); // Assert expected count and actual match 
        }
    }
}
