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
    class SuccessLoginTests : BaseTest
    {
        [TestCaseSource(typeof(ReaderUserData),"GetUserData")]
        public void UserDataIsCorrect(User user)
        {
            //Arrange 
            string expectedTitle = "My Account";

            //Act
            string actualTitle = Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email, user.password)
                .GetTitleText();

            //Assert
            Assert.AreEqual(expectedTitle, actualTitle);  
        }

        [TearDown]
        public void AfterAll()
        {
            Pages.AccountPage
                .GoToLogoutPage()
                .SuccessLogout();
        }    
    }



}
