﻿using System;
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
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts);
        }

        [Test]
        public void Search_Description()
        {
            // Arrange
            int expectedCountOfProducts = 10;
            string[] expectedText = products.Products.SearchDescription.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[11];
            string searchText = "Apple";
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickSearchButton();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts);
        }

        [Test]
        public void Search_Category()
        {
            // Arrange
            int expectedCountOfProducts = 4;
            string[] expectedText = products.Products.SearchCategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[5];
            string searchText = "Apple";
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickCategoriesDropDownMenu();
            searchPage.ClickCategoryTablets();
            searchPage.ClickSearchButton();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match 
        }

        [Test]
        public void Search_Subcategory()
        {
            // Arrange
            int expectedCountOfProducts = 4;
            string[] expectedText = products.Products.SearchSubcategory.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] actualText = new string[5];
            string searchText = "Apple";
            int i = 0;

            // Act
            SearchPage searchPage = new SearchPage(driver);
            searchPage.ClickMainSearch();
            searchPage.SetSearchCriteriaInput(searchText);
            searchPage.ClickSearchInDescriptionCheckBox();
            searchPage.ClickCategoriesDropDownMenu();
            searchPage.ClickCategoryTablets();
            searchPage.ClickSearchInSubcategoriesCheckBox();
            searchPage.ClickSearchButton();
            int actualCountOfProducts = searchPage.CountProductBlocks();
            IList<IWebElement> listofProducts = searchPage.GetProductNameList();

            // Assert
            foreach (IWebElement product in listofProducts) // Assert expected product names and actual match
            {
                actualText[i] = product.Text;
                Assert.AreEqual(expectedText[i], actualText[i]);
                i++;
            }
            Assert.AreEqual(actualCountOfProducts, expectedCountOfProducts); // Assert expected count and actual match 
        }
    }
}
