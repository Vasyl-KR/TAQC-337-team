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

namespace OpenCartTests.Tests.Pavlo
{
    [TestFixture]
    class WishListTest
    {
        readonly string password = "12345";
        readonly string login = "pristayko.pavlo@gmail.com";
        private IWebDriver driver;
        private WishlistPage wishlistPage;

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

        [TearDown]
        public void ClearCart()
        {
            wishlistPage.ClearTotalCart();
        }

        [Test]
        public void AddToWishlistTest()
        {
            Login(login, password);

            HomePage homePage = new HomePage(driver);
            LaptopsAndNotebooksPage lapAndNotePage = homePage.GoToLaptopPage();

            wishlistPage = lapAndNotePage.AddToWishlist();
            wishlistPage.ClickAddToCartButton();
            
            string totalPrice = wishlistPage.GetTotalCartPrice();
            string actualPrice = wishlistPage.GetProductPriceText();

            Assert.AreEqual(totalPrice, actualPrice);
           
        }
        private void Login(string log, string pass)
        {

            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/login");

            driver.FindElement(By.Id("input-email")).SendKeys(log);
            driver.FindElement(By.Id("input-password")).SendKeys(pass);
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        }
    }
}
