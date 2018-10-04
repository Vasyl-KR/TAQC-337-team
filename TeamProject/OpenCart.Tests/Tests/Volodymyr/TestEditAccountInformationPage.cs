using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestEditAccountInformationPage
    {
        private IWebDriver driver;
        private ListUsers users;
        private User user;

        [OneTimeSetUp]
        public void CreateNecessaryObjects()
        {
            users = ReaderUserData.GetUsersData();
            user = users.Users[0];
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
        public void Test_Edit_Account_Information_Page()
        {
            string expectedResult = "Success: Your account has been successfully updated.";
            string actualResult = String.Empty;
            Pages.PagesList pages = new Pages.PagesList(driver);
            pages.LoginPage.GoToLoginPage();

            pages.LoginPage.SetLoginInputClear(user.email)
              .SetPasswordInputClear(user.password)
                .ClickSigninButton();

            pages.AccountPage.ClickEditAccountInformation();

            //fill fields
            pages.EditAccountInformationPage.SetFirstName(user.firstName);
            pages.EditAccountInformationPage.SetLastName(user.lastName);
            pages.EditAccountInformationPage.SetEmail(user.email);
            pages.EditAccountInformationPage.SetTelephone(user.telephone);
            pages.EditAccountInformationPage.SetFax("+380099900");
            pages.EditAccountInformationPage.ClickButtonContinue();

            actualResult = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
