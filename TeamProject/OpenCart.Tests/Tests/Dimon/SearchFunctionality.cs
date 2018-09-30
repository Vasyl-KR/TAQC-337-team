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
            string searchText = "Apple";
            string[] expectedText = products.Products.SearchCriteria.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[8];
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchButton();
            int actualCount = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
           // Assert.AreEqual(actualCount, expectedCount);
        }
    }
}
