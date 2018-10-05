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
        [Test]
        public void SuccessChangePassword()
        {
            user = ReaderUserData.GetUsers().Users.FirstOrDefault(u => u.email == "ostap@gmail.com");
            string newPassword = "qwerty1234"; 
            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email,user.password);

            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(newPassword);

            string expected = "Success: Your password has been successfully updated.";
            string actual = Pages.AccountPage.GetSuccessChangePasswordLabelText();

            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(user.password);

            Assert.AreEqual(expected, actual);
        }
    }
}
