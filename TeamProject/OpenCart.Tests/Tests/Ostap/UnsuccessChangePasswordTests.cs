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
    class UnsuccessChangePasswordTests : BaseTest
    {
        private User user;

        [SetUp]
        public void LogIn()
        {
            user = ReaderUserData.GetUsers().Users.FirstOrDefault(u => u.email == "ostap@gmail.com");

            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email, user.password);
        }

        [TearDown]
        public void LogOut()
        {
            Pages.ChangePasswordPage
                .GoToLogoutPage()
                .SuccessLogout();
        }


        [Test]
        public void PasswordsNotMatch()
        {
            //Arrange

            string password = Passwords.Correct1;
            string passwordConfirm = Passwords.Correct2;
            string expectedPasswordConfirmErrorMessage = "Password confirmation does not match password!";

            //Act
            string actualPasswordConfirmErrorMessage = Pages.AccountPage
                .GoToChangePassword()
                .UnsuccessChangePassword(password, passwordConfirm)
                .GetPasswordConfirmErrorMessageText();

            //Accert
            Assert.AreEqual(expectedPasswordConfirmErrorMessage, actualPasswordConfirmErrorMessage, "Error messages aren't equal");
        }

        [TestCase(Passwords.TooShort)]
        [TestCase(Passwords.TooLong)]
        public void PasswordsAreNotInRange(string password)
        {
            string expectedPasswordErrorMessage = "Password must be between 4 and 20 characters!";
            string actualPasswordErrorMessage = Pages.AccountPage
                .GoToChangePassword()
                .UnsuccessChangePassword(password, password)
                .GetPasswordErrorMessageText();
            Assert.AreEqual(expectedPasswordErrorMessage, actualPasswordErrorMessage, "Error messages aren't equal");
        }

        [Test]
        public void PasswordsAreNotInRangeAndNotMatch()
        {
            string password = Passwords.TooShort;
            string passwordConfirm = Passwords.Correct1;
            string expectedPasswordErrorMessage = "Password must be between 4 and 20 characters!";
            string expectedPasswordConfirmErrorMessage = "Password confirmation does not match password!";

            Pages.AccountPage
                .GoToChangePassword()
                .UnsuccessChangePassword(password, passwordConfirm);

            string actualPasswordErrorMessage = Pages.ChangePasswordPage
                 .GetPasswordErrorMessageText();

            string actualPasswordConfirmErrorMessage = Pages.ChangePasswordPage
                 .GetPasswordConfirmErrorMessageText();

            Assert.AreEqual(expectedPasswordErrorMessage, actualPasswordErrorMessage, "Error messages for password aren't equal");
            Assert.AreEqual(expectedPasswordConfirmErrorMessage, actualPasswordConfirmErrorMessage, "Error messages for password confirm aren't equal");
        }
    }
}
