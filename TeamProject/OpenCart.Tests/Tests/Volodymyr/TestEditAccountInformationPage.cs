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

            LoginPage loginPage = new LoginPage(driver).GoToLoginPage();
            loginPage.SetLoginInputClear(user.email)
              .SetPasswordInputClear(user.password)
                .ClickSigninButton();

            AccountPage accountPage = new AccountPage(driver);
            accountPage.ClickEditAccountInformation();

            EditAccountInformationPage editAccountInformationPage = new EditAccountInformationPage(driver);
            
            //fill fields
            editAccountInformationPage.SetFirstName(user.firstName);
            editAccountInformationPage.SetLastName(user.lastName);
            editAccountInformationPage.SetEmail(user.email);
            editAccountInformationPage.SetTelephone(user.telephone);
            editAccountInformationPage.SetFax("+380099900");
            editAccountInformationPage.ClickButtonContinue();

            actualResult = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
