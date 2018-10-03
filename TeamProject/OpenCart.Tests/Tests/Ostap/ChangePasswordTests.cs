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

namespace OpenCartTests.Tests.Ostap
{
    [TestFixture]
    class ChangePasswordTests:BaseTest
    {
        private IWebDriver driver;


        [Test]
        public void Test()
        {
            LoginPage loginPage = new HomePage(driver).GoToLoginPage();

            AccountPage accountPage =loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty123");

            ChangePasswordPage changePasswordPage = accountPage.GoToChangePassword();
            accountPage = changePasswordPage.SuccessChangePassword("qwerty1234");// add SuccessAccountPage

            LogoutPage logoutPage = accountPage.GoToLogoutPage();
            loginPage = logoutPage.GoToLoginPage();
            loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty1234");

            changePasswordPage = accountPage.GoToChangePassword();
            accountPage = changePasswordPage.SuccessChangePassword("qwerty123");
            accountPage.GoToLogoutPage();
        }

        /*
         * перейменувати методи і константи, кнопки 
         * змінити назви локаторів
         * 
         */
    }
}
