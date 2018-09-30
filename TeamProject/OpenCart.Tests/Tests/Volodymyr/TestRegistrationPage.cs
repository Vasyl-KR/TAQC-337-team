using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace HW_Automated
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
        public void Test_Register_User()
        {
            string expectedResult = "Your Account Has Been Created!";
            string actualResult = String.Empty;

            RegisterPage page = new RegisterPage(driver).GoToRegisterPage();
           
            //fill fields
            page.SetFirstName(user.firstName);
            page.SetLastName(user.lastName);
            page.SetEmail(user.email);
            page.SetTelephone(user.telephone);
            page.SetFax(user.fax);
            page.SetCompany(user.company);
            page.SetAddress1(user.address_1);
            page.SetAddress2(user.address_2);
            page.SetCity(user.city);
            page.SetPostCode(user.postCode);
            page.SetCountry(user.country);        
            page.SetRegion(user.region);
            page.SetPassword(user.password);
            page.SetConfirmPassword(user.password);
            page.SetNewsLetter(false);
            page.CheckAgreePrivacyPolicy();
            page.ClickButtonContinue();

            actualResult = driver.FindElement(By.XPath("//div[contains(@class,'col-sm-9')]/h1")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }    
    }
}
