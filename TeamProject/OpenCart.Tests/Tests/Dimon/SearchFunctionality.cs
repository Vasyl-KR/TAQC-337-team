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
        public void Search_Criteria()
        {
            // Arrange
            int expectedCountOfProducts = 7;
            string searchText = "Apple";
            string[] expectedTextAppears = products.Products.SearchCriteria.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[8];
            int i = 0;

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts);
        }

        [Test]
        public void Search_Description()
        {
            // Arrange
            int expectedCountOfProducts = 10;
            string[] expectedTextAppears = products.Products.SearchDescription.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[11];
            string searchText = "Apple";
            int i = 0;

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

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts);
        }

        [Test]
        public void Search_Category()
        {
            // Arrange
            int expectedCountOfProducts = 4;
            string[] expectedTextAppears = products.Products.SearchCategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[5];
            string searchText = "Apple";
            int i = 0;

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Categories drop down menu to pick category on Search page */
            pages.SearchPage.ClickCategoriesDropDownMenu();
            /* Click on Tablets to select Tablets category to search in */
            pages.SearchPage.ClickCategoryTablets();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match 
        }

        [Test]
        public void Search_Subcategory()
        {
            // Arrange
            int expectedCountOfProducts = 4;
            string[] expectedTextAppears = products.Products.SearchSubcategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualTextAppears = new string[5];
            string searchText = "Apple";
            int i = 0;

            // Act
            Pages.Pages pages = new Pages.Pages(driver);
            /* Click on Search button on Home page */
            pages.HomePage.ClickMainSearch();
            /* Set search text into field on Search page */
            pages.SearchPage.SetSearchCriteriaInput(searchText);
            /* Check the checkbox to search in description */
            pages.SearchPage.ClickSearchInDescriptionCheckBox();
            /* Click on Categories drop down menu to pick category on Search page */
            pages.SearchPage.ClickCategoriesDropDownMenu();
            /* Click on Tablets to select Tablets category to search in */
            pages.SearchPage.ClickCategoryTablets();
            /* Check the checkbox to search in subcategories */
            pages.SearchPage.ClickSearchInSubcategoriesCheckBox();
            /* Click on Search button on Search page */
            pages.SearchPage.ClickSearchButton();
            /* Count how many products appear */
            int actualCountOfProducts = pages.SearchPage.CountProductBlocks();
            /* Get names of each product */
            IList<IWebElement> listofProducts = pages.SearchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualTextAppears[i] = product.Text;
                Assert.AreEqual(expectedTextAppears[i], actualTextAppears[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match 
        }
    }
}
