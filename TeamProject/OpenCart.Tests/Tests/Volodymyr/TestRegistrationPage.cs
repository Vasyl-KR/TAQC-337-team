using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

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

            Pages.PagesList pages = new Pages.PagesList(driver);

            // go to RegisterPage
            pages.RegisterPage.GoToRegisterPage();
            
            //fill fields
            pages.RegisterPage.SetFirstName(user.firstName);
            pages.RegisterPage.SetLastName(user.lastName);
            pages.RegisterPage.SetEmail(user.email);
            pages.RegisterPage.SetTelephone(user.telephone);
            pages.RegisterPage.SetFax(user.fax);
            pages.RegisterPage.SetCompany(user.company);
            pages.RegisterPage.SetAddress1(user.address_1);
            pages.RegisterPage.SetAddress2(user.address_2);
            pages.RegisterPage.SetCity(user.city);
            pages.RegisterPage.SetPostCode(user.postCode);
            pages.RegisterPage.SetCountry(user.country);
           // pages.WaitForElementTextContains(pages.RegisterPage.InputCountryField, user.country);
            pages.RegisterPage.SetRegion(user.region);
           //  pages.WaitForElementTextContains(pages.RegisterPage.InputRegionField, user.region);
            pages.RegisterPage.SetPassword(user.password);
            pages.RegisterPage.SetConfirmPassword(user.password);
            pages.RegisterPage.SetNewsLetter(false);
            pages.RegisterPage.SetCheckAgreeTerms();
            pages.RegisterPage.ClickButtonContinue();

            actualResult = pages.ConfirmationRegisterPage.SuccessH1Element.Text;
            pages.ConfirmationRegisterPage.ClickConfirmationButtonContinue();

            Assert.AreEqual(expectedResult, actualResult);
        }    
    }
}
