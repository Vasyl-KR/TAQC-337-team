using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;
        private ListUsers users;
        private User user;

        [OneTimeSetUp]
        public void CreateNecessaryObjects()
        {
            users = ReaderUserData.GetUsersData();
            user = users.Users[1];
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }

        [OneTimeTearDown]
        public void ClearResources()
        {
            driver.Quit();
            driver.Dispose();
        }

       

        [Test]
        public void Test_Register_User()
        {
            string expectedResult = "Your Account Has Been Created!";
            string actualResult = String.Empty;

            RegisterPage registerPage = new RegisterPage(driver).GoToRegisterPage();
           
            //fill fields
            registerPage.SetFirstName(user.firstName);
            registerPage.SetLastName(user.lastName);
            registerPage.SetEmail(user.email);
            registerPage.SetTelephone(user.telephone);
            registerPage.SetFax(user.fax);
            registerPage.SetCompany(user.company);
            registerPage.SetAddress1(user.address_1);
            registerPage.SetAddress2(user.address_2);
            registerPage.SetCity(user.city);
            registerPage.SetPostCode(user.postCode);
            registerPage.SetCountry(user.country);        
            registerPage.SetRegion(user.region);
            registerPage.SetPassword(user.password);
            registerPage.SetConfirmPassword(user.password);
            registerPage.SetNewsLetter(false);
            registerPage.CheckAgreePrivacyPolicy();
            ConfirmationRegisterPage confirmationRegisterPage = registerPage.ClickButtonContinue();

            actualResult = confirmationRegisterPage.H1Element.Text;
            confirmationRegisterPage.ClickConfirmationButtonContinue();

            Assert.AreEqual(expectedResult, actualResult);
        }    
    }
}
