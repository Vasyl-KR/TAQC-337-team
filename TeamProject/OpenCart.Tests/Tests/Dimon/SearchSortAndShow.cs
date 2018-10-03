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
            string[] expectedText = products.Products.SearchDefault.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            int i = 0;
            string searchText = "a";
            string expectedShowing = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }

        [Test]
        public void Search_AZ_NameSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedText = products.Products.SearchAZNameSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowing = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            searchPage.ClickSortDDMenu();
            searchPage.ClickSortNameAZ();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }

        [Test]
        public void Search_LowHigh_PriceSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedText = products.Products.SearchLowHighPriceSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            int i = 0;
            string searchText = "a";
            string expectedShowing = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            searchPage.ClickSortDDMenu();
            searchPage.ClickSortPriceLowHigh();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductCostList();
            string actualShowing = searchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }

        [Test]
        public void Search_ZA_ModelSort()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedText = products.Products.SearchZAModelSort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowing = "Showing 1 to 15 of 55 (4 Pages)";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            searchPage.ClickSortDDMenu();
            searchPage.ClickSortModelZA();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }

        [Test]
        public void Search_ZA_ModelSort_Show50()
        {
            // Arrange
            int expectedCountOfProducts = 50;
            string[] expectedText = products.Products.SearchZAModelSortShow50.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[51];
            string searchText = "a";
            int i = 0;
            string expectedShowing = "Showing 1 to 50 of 55 (2 Pages)";

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            searchPage.ClickSortDDMenu();
            searchPage.ClickSortModelZA();
            searchPage.ClickShowDDMenu();
            searchPage.ClickShow_50();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
        }

        [Test]
        public void Search_Type_List()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedText = products.Products.SearchTypeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowing = "Showing 1 to 15 of 35 (3 Pages)";
            bool isList = false;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchButton();
            searchPage.ClickListBtn();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();
            bool listOrNot = searchPage.GetListOrNot();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(expectedCountOfProducts, actualCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
            Assert.AreEqual(true, listOrNot); // Assert expected display type and actual
        }

        [Test]
        public void Search_Type_Grid()
        {
            // Arrange
            int expectedCountOfProducts = 15;
            string[] expectedText = products.Products.SearchTypeList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[16];
            string searchText = "a";
            int i = 0;
            string expectedShowing = "Showing 1 to 15 of 35 (3 Pages)";
            bool isGrid = false;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchButton();
            searchPage.ClickGridBtn();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();
            string actualShowing = searchPage.GetProductsShowingText();
            bool gridOrNot = searchPage.GetGridOrNot();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(expectedCountOfProducts, actualCountOfProducts); // Assert expected count and actual match
            Assert.AreEqual(expectedShowing, actualShowing); // Assert expected text and actual match
            Assert.AreEqual(true, gridOrNot); // Assert expected display type and actual
        }
    }
}
