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
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchDefault.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            int i = 0;
            string searchText = "a";
            string expectedShowingText = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
        }

        [Test]
        public void Search_AZ_NameSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchAZNameSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowingText = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSortDDMenu();
            /* Click on Name('A - Z') to select how to sort seached products */
            pages.SearchPage.ClickSortNameAZ();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
        }

        [Test]
        public void Search_LowHigh_PriceSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchLowHighPriceSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            int i = 0;
            string searchText = "a";
            string expectedShowingText = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSortDDMenu();
            /* Click on Price('Low - High') to select how to sort seached products */
            pages.SearchPage.ClickSortPriceLowHigh();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get cost of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductCostList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
        }

        [Test]
        public void Search_ZA_ModelSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchZAModelSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowingText = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSortDDMenu();
            /* Click on Model('Z - A') to select how to sort seached products */
            pages.SearchPage.ClickSortModelZA();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
        }

        [Test]
        public void Search_ZA_ModelSort_Show50()
        {
            // Arrange
            int expectedCountOfProducts = 50;
            string[] expectedTextAppears = products.Products.SearchZAModelSortShow50.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[51];
            string searchText = "a";
            int i = 0;
            string expectedShowingText = "Showing 1 to 50 of 55 (2 Pages)";

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSortDDMenu();
            /* Click on Model('Z - A') to select how to sort seached products */
            pages.SearchPage.ClickSortModelZA();
            /* Click on Show drop down menu to pick how many products need to show on Search page */
            pages.SearchPage.ClickShowDDMenu();
            /* Click on '50' to show 50 products */
            pages.SearchPage.ClickShow_50();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowing = pages.SearchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, expectedShowingText); // Assert expected text and actual match
        }

        [Test]
        public void Search_Type_List()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchTypeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowingText = "Showing 1 to 15 of 35 (3 Pages)";
            bool isList = false;

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on List button to change to 'List' type of view */
            pages.SearchPage.ClickListBtn();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();
            /* Get 'true' if type of view is 'List'*/
            bool listOrNot = pages.SearchPage.GetListOrNot();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(expectedCountOfProducts, actualCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
            Assert.AreEqual(true, listOrNot); // Assert expected display type and actual
        }

        [Test]
        public void Search_Type_Grid()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedTextAppears = products.Products.SearchTypeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowingText = "Showing 1 to 15 of 35 (3 Pages)";
            bool isGrid = false;

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Click on Sort drop down menu to pick how to sort on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Click on Grid button to change to 'Grid' type of view */
            pages.SearchPage.ClickGridBtn();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();
            /* Get Showing text on the bottom of the Search page */
            string actualShowingText = pages.SearchPage.GetProductsShowingText();
            /* Get 'true' if type of view is 'Grid'*/
            bool gridOrNot = pages.SearchPage.GetGridOrNot();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(expectedCountOfProducts, actualCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowingText, actualShowingText); // Assert expected text and actual match
            Assert.AreEqual(true, gridOrNot); // Assert expected display type and actual
        }
    }
}
