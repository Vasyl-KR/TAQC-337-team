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
    class WishListTest : BaseTest
    {
        readonly string password = "12345";
        readonly string login = "pristayko.pavlo@gmail.com";

        [Test]
        public void AddToWishlist()
        {
            //Arrange
            string expectedName;
            string actualName;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();

            /*Getting laptop name*/
            expectedName = "MacBook";
            actualName = Pages.WishlistPage.GetProductName();

            //Assert
            Assert.AreEqual(expectedName, actualName, "Adding failed");

        }

        [Test]
        public void RemoveFromWishlistTest()
        {
            //Arrange
            string actualMessage;
            string expectedMessage;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Removing laptop from wishlist*/
            Pages.WishlistPage.ClearWishlist();

            /*Waiting for message to show*/
            actualMessage = Pages.WishlistPage.GetEmptylistMessage();
            expectedMessage = "Your wish list is empty.";

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage, "No message");
        }

        [Test]
        public void AddToCart()
        {
            //Arrange
            string expectedPrice;
            string actualPrice;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Adding laptop to cart*/
            Pages.WishlistPage.ClickAddToCartButton();

            /*Waiting for change total price*/
            expectedPrice = Pages.WishlistPage.GetProductPriceText();
            actualPrice = Pages.WishlistPage.GetTotalCartPrice();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice, "Adding to cart failed");
            /*Cleaning Cart after adding*/
            Pages.WishlistPage.ClearTotalCart();
        }

        [Test]
        public void RemoveFromCart()
        {
            //Arrange
            string actualMessage;
            string expectedMessage;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Adding laptop to cart*/
            Pages.WishlistPage.ClickAddToCartButton();
            /*Cleaning cart*/
            Pages.WishlistPage.ClearTotalCart();


            /*Waiting for message to show*/
            actualMessage = Pages.WishlistPage.GetEmptyCartMessage();
            expectedMessage = "Your shopping cart is empty!";

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage, "No message");
        }

        [Test]
        public void AddToCartDuplicate()
        {
            //Arrange
            string expectedPrice;
            string actualPrice;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Adding laptop to cart*/
            Pages.WishlistPage.ClickAddToCartButton();

            /*Waiting for change total price*/
            expectedPrice = Pages.WishlistPage.GetProductPriceText();
            actualPrice = Pages.WishlistPage.GetTotalCartPrice();

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice, "Adding to cart failed");
            /*Cleaning Cart after adding*/
            Pages.WishlistPage.ClearTotalCart();
        }


    }
}
