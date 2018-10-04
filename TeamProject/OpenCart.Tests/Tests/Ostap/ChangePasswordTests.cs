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


        [Test, Order(1)]
        public void Test()
        {
            Pages.HomePage.GoToLoginPage();

            //string expected = "Success: Your password has been successfully updated.";

            //LoginPage loginPage = new HomePage(Driver).GoToLoginPage();

            //AccountPage accountPage = loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty123");

            //ChangePasswordPage changePasswordPage = accountPage.GoToChangePassword();
            //RepeatAccountPage repeatAccountPage = changePasswordPage.SuccessChangePassword("qwerty1234");

            //string actual = repeatAccountPage.GetSuccessChangePasswordLabelText();

            //Assert.AreEqual(expected, actual);

            //LogoutPage logoutPage = repeatAccountPage.GoToLogoutPage();
            //loginPage = logoutPage.GoToLoginPage();
            //loginPage.SuccessRegistratorLogin("ostap@gmail.com", "qwerty1234");

            //changePasswordPage = accountPage.GoToChangePassword();
            //repeatAccountPage = changePasswordPage.SuccessChangePassword("qwerty123");
            //repeatAccountPage.GoToLogoutPage();
        }
        /*
         * перейменувати методи і константи, кнопки 
         * змінити назви локаторів
         * запитатись як відкривати і закривати браузер
         */
    }
}
