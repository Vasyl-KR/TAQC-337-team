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
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCartTests.Tests.Pavlo
{
    [TestFixture]
    class WishListTest
    {
        readonly string password = "12345";
        readonly string login = "pristayko.pavlo@gmail.com";
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
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
        public void AddToWishlistTest()
        {
            //Arrange
            Pages.Pages pages = new Pages.Pages(driver);
            string totalPrice;
            string actualPrice;

            //Act
            /*Logining*/
            pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login,password);
            /*Opening Laptop page*/
            pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Cleaning Cart before adding*/
            pages.WishlistPage.ClearTotalCart(pages.WaitForElementPresent(pages.WishlistPage.CartTotalPrice));
            /*Adding laptop to cart*/
            pages.WishlistPage.ClickAddToCartButton();
            /*Waiting for change total price*/
            pages.WaitForElementTextContains(pages.WishlistPage.CartTotalPrice,pages.WishlistPage.GetProductPriceText());

            totalPrice = pages.WishlistPage.GetTotalCartPrice();
            actualPrice = pages.WishlistPage.GetProductPriceText();

            //Assert
            Assert.AreEqual(totalPrice, actualPrice,"Adding failed");
           
        }

    }
}
