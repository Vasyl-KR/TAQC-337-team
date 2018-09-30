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
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
           
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [Test]
        public void AddToComparisionTest()
        {
            HomePage homePage = new HomePage(driver);
            LaptopsAndNotebooksPage laptopsPage = homePage.GoToLaptopPage();

            string selectedProduct = laptopsPage.GetFirstProductLinkText();

            laptopsPage.ClickCompareThisProductButton();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver drv) =>
            {
                bool actual =  laptopsPage.GetProductComparisonLinkText().Contains("1");
                return actual;

            });
            wait.Until(waitForElement);
            //    //Thread.Sleep(2000);

            ProductComparisonPage productComparisonPage = laptopsPage.GoToComparison();

            string actualProduct = productComparisonPage.GetLastProductText();
            Assert.AreEqual(selectedProduct, actualProduct, "Comparison failed");

        }
        [Test]
        public void RemoveFromCompareTableTest()
        {
            HomePage homePage = new HomePage(driver);
            LaptopsAndNotebooksPage laptopsPage = homePage.GoToLaptopPage();
            ProductComparisonPage productComparisonPage = laptopsPage.GoToComparison();
            productComparisonPage.ClickRemoveLastProductButton();
            Assert.AreEqual("You have not chosen any products to compare.",
                productComparisonPage.GetNoProductsToCompareLabelText(), "Removing failed");

        }

    }
}