using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenCartTests.Data;

namespace OpenCartTests.Tests.Ostap
{
    [TestFixture]
    class UnsuccessLoginTests : BaseTest
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            Pages = new PagesList(Driver);
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            Pages.HomePage
               .GoToLoginPage();
        }

        [TestCase("wrongEmail@sample.com","qwerty")]
        [TestCase("", "")]
        [TestCase("ostap@gmail.com", "wrongpassword")]
        public void UnsuccessUserData(string email, string password)
        {
            string expectedErrorMessage = "Warning: No match for E-Mail Address and/or Password.";

            string actualErrorMessage = Pages.LoginPage
               .UnsuccessfulLogin(email, password)
               .GetInvalidLoginLabelText();

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error messages are not equal");
        }

        [TestCase("vasya@gmail.com", "wrongpassword")]
        public void ToManyLoginsWithIncorrectPass(string email, string password)
        {
            //Arrange
            string expectedErrorMessage = "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";

            //Act
            for (int i = 0; i < 6; i++)
            {
                Pages.LoginPage
               .UnsuccessfulLogin(email, password);
            }
            string actualErrorMessage = Pages.LoginPage                
              .GetInvalidLoginLabelText();

            //Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error messages are not equal");

        }
    }
}
