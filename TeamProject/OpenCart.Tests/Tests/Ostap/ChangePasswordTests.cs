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
    class ChangePasswordTests:BaseTest
    {
        private User user;
        //[Test]
        public void SuccessChangePassword()
        {
            user = ReaderUserData.GetUsers().Users.FirstOrDefault(u => u.email == "ostap@gmail.com");
            string correctPassword = "qwerty1234"; 
            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email,user.password);

            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(correctPassword);

            string expectedSuccsesChangePassMes = "Success: Your password has been successfully updated.";
            string actualSuccsesChangePassMes = Pages.AccountPage.GetSuccessChangePasswordLabelText();

            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(user.password);

            Assert.AreEqual(expectedSuccsesChangePassMes, actualSuccsesChangePassMes);
        }

        [Test]
        public void UnSuccessChangePassword()
        {
            user = ReaderUserData.GetUsers().Users.FirstOrDefault(u => u.email == "ostap@gmail.com");
            string incorrectPassword = "qwe";
            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email, user.password);

            Pages.AccountPage
                .GoToChangePassword()
                .SetPasswordInputClear(incorrectPassword)
                .SetPasswordConfirmInputClear(incorrectPassword)
                .ClickConfirmButton();

            Console.WriteLine(Pages.ChangePasswordPage.GetPasswordConfirmationErrorMessageText());


        }
    }
}
