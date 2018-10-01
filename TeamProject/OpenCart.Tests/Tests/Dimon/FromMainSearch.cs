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
    class FromMainSearch
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
        public void Search_From_Main_Nothing()
        {
            // Arrange
            string expected = "There is no product that matches the search criteria.";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            string actual = searchPage.GetNoProductsLabelText();

            // Assert
            Assert.AreEqual(expected, actual); // If error text match
        }

        [Test]
        public void Search_From_Main_Acer()
        {
            // Arrange
            int expectedCount = 2;
            string[] expectedText = products.Products.SearchMainAcer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); //{ "Acer Chromebook 11-CB3-111", "Acer TravelMate P249-M" };
            string[] actualText = new string[3];
            string searchText = "Acer";
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetMainSearch(searchText);
            searchPage.ClickMainSearch();
            int actualCount = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCount, expectedCount); // Assert expected count and actual match 
        }

        [Test]
        public void Search_From_Main_notExist()
        {
            // Arrange
            string expected = "There is no product that matches the search criteria.";
            string searchText = "notExist";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.SetMainSearch(searchText);
            searchPage.ClickMainSearch();
            string actual = searchPage.GetNoProductsLabelText();

            // Assert
            Assert.AreEqual(expected, actual); // If error text match
        }
    }
}