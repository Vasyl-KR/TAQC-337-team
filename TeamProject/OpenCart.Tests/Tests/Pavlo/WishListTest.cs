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
        public void AddToWishlistTest()
        {
            //Arrange
            string totalPrice;
            string actualPrice;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Cleaning Cart before adding*/
            Pages.WishlistPage.ClearTotalCart();
            /*Adding laptop to cart*/
            Pages.WishlistPage.ClickAddToCartButton();

            /*Waiting for change total price*/
            totalPrice = Pages.WishlistPage.GetTotalCartPrice();
            actualPrice = Pages.WishlistPage.GetProductPriceText();

            //Assert
            Assert.AreEqual(totalPrice, actualPrice, "Adding failed");

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
            /**/
            Pages.WishlistPage.ClearWishlist();

            /*Waiting for message to show*/
            actualMessage = Pages.WishlistPage.GetEmptylistMessage();
            expectedMessage = "Your wish list is empty.";

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage, "No message");
        }

        [Test]
        public void RemoveFromCartTest()
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
            /*Clearing cart*/
            //Pages.WishlistPage.ClearWishlist();

            /*Waiting for message to show*/
            actualMessage = Pages.WishlistPage.GetEmptyCartMessage() ;
            expectedMessage = "Your shopping cart is empty!";

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage,"No message");
        }

    }
}
