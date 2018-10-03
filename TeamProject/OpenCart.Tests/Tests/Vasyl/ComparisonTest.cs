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
    public class ComparisonTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
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

        [Test, Order(1)]
        public void AddToComparisionTest()
        {
            //Arrange
            Pages.Pages pages = new Pages.Pages(driver);
            string selectedProduct;
            string actualProduct;

            //Act
            //Go to products page
            pages.HomePage.GoToLaptopPage();
            //Add product to comparison
            selectedProduct = pages.LaptopsAndNotebooksPage.GetFirstProductLinkText();
            pages.LaptopsAndNotebooksPage.ClickCompareThisProductButton();
            //Wait for adding
            pages.WaitForElementTextContains(pages.LaptopsAndNotebooksPage.ProductComparisonLink, "1");
            //Go to products comparison
            pages.LaptopsAndNotebooksPage.GoToComparison();
            actualProduct = pages.ProductComparisonPage.GetLastProductText();

            //Assert
            Assert.AreEqual(selectedProduct, actualProduct, "Comparison failed");
        }
        [Test, Order(2)]
        public void RemoveFromCompareTableTest()
        {
            //Arrange
            Pages.Pages pages = new Pages.Pages(driver);

            //Act
            //Go to products page
            pages.HomePage.GoToLaptopPage();
            //Add product to comparison
            pages.LaptopsAndNotebooksPage.ClickCompareThisProductButton();
            //Wait for adding
            pages.WaitForElementTextContains(pages.LaptopsAndNotebooksPage.ProductComparisonLink, "1");
            //Go to products comparison
            pages.LaptopsAndNotebooksPage.GoToComparison();
            //Remove product from comparison
            pages.ProductComparisonPage.ClickRemoveLastProductButton();
            
            //Assert
            Assert.AreEqual("You have not chosen any products to compare.",
                pages.ProductComparisonPage.GetNoProductsToCompareLabelText(), "Removing failed");

        }
        [TestCase (4), Order(3)]
        public void Add_4_ProductsToCompareTest(int x)
        {
            //Arrange
            Pages.Pages pages = new Pages.Pages(driver);

            //Act
            //Go to products page
            pages.HomePage.GoToLaptopPage();
            //Add 4 products to comparision
            for (int i = 0; i < x; i++)
            {
                pages.LaptopsAndNotebooksPage.CompareProductButtons[i].Click();
                pages.WaitForElementTextContains(pages.LaptopsAndNotebooksPage.ProductComparisonLink, (i + 1).ToString());
                //Thread.Sleep(500);
            }
            //Go to products comparison
            pages.LaptopsAndNotebooksPage.GoToComparison();

            //Assert
            Assert.AreEqual(x, pages.ProductComparisonPage.AllProducts.Count, "Adding failed");
        }
    }
}