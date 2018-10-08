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
        public void AddToWishlist_WithoutLogin()
        {
            //Arrange
            string actualMessage;
            string expectedMessage;

            //Act
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();

            expectedMessage = "New Customer";
            actualMessage = Pages.LoginPage.GetNewCustomerLabel();
            //Assert

            Assert.AreEqual(expectedMessage, actualMessage, "Message is incorrect");
        }

        [Test]
        public void RemoveFromWishlist()
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
        public void AddToCart_CompareMessage()
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
            /*Adding laptop to cart*/
            Pages.WishlistPage.ClickAddToCartButton();

            /*Waiting for message*/
            expectedName = Pages.WishlistPage.GetProductName();
            actualName = Pages.WishlistPage.GetSuccessMessage();

            //Assert
            Assert.AreEqual(expectedName, actualName, "Adding to cart failed");
            /*Cleaning Cart after adding*/
            Pages.WishlistPage.ClearTotalCart();
        }

        //[Test]
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
        public void AddToWishlistDuplicate()
        {
            //Arrange
            int expectedAmount;
            int actualAmount;

            //Act
            /*Loggining*/
            Pages.HomePage.GoToLoginPage().SuccessRegistratorLogin(login, password);
            /*Opening Laptop page*/
            Pages.HomePage.GoToLaptopPage();
            /*Adding laptop to wishlist*/
            Pages.LaptopsAndNotebooksPage.AddToWishlist();
            /*Adding the same product to wishlist*/
            Pages.HomePage.GoToLaptopPage();
            Pages.LaptopsAndNotebooksPage.AddToWishlist();

            /*Getting amount of products in wishlist */
            expectedAmount = 1;
            actualAmount = Pages.WishlistPage.GetProductsRows();

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount, "Duplicate was added");

        }
        [Test]
        public void PressContinueButton()
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
            /*Go to my account*/
            Pages.WishlistPage.ClickContinueButton();

            expectedMessage = "My Account";
            actualMessage = Pages.AccountPage.GetAccountLabelText();
            //Assert

            Assert.AreEqual(expectedMessage, actualMessage, "Message is incorrect");
        }


        [TestCase(4)]
        public void Add_4_ProductsToWishlist(int x)
        {
            //Arrange
            int expectedAmount;
            int actualAmount;
            //Act
            //Go to products page
            Pages.HomePage.GoToLaptopPage();
            //Add 4 products to comparision
            for (int i = 0; i < x; i++)
            {
                string name = Pages.LaptopsAndNotebooksPage.CompareProductLinks[i].Text;
                Pages.LaptopsAndNotebooksPage.AddToWishlistByName(name);
            }
            //Go to products comparison
            Pages.LaptopsAndNotebooksPage.ClickWishlistLink();

            expectedAmount = x;
            actualAmount = Pages.WishlistPage.GetProductsRows();

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount, "Adding failed");
        }
    }
}
