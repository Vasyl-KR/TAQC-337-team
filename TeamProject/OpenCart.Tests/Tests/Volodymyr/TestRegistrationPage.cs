using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


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
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

        //[Test ]
        //public void Test_Edit_User()
        //{
        //    string expectedResult = "Success: Your account has been successfully updated.";
        //    string actualResult = String.Empty;

        //    //fill fields
        //    driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=common/home");
        //    GetMyAccountOption(MyAccount.Login);

        //    // fill login fields
        //    driver.FindElement(By.Id("input-email")).SendKeys(user.email);
        //    driver.FindElement(By.Id("input-password")).SendKeys(user.password);

        //    // click button Login
        //    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        //    //click edit account
        //    driver.FindElement(By.LinkText("Edit your account information")).Click();

        //    driver.FindElement(By.Id("input-firstname")).Clear();
        //    driver.FindElement(By.Id("input-firstname")).SendKeys("NewVVV");
        //    driver.FindElement(By.Id("input-lastname")).Clear();
        //    driver.FindElement(By.Id("input-lastname")).SendKeys("NewLLL");
        //    driver.FindElement(By.Id("input-email")).Clear();
        //    driver.FindElement(By.Id("input-email")).SendKeys("some@gmail.com");
        //    driver.FindElement(By.Id("input-telephone")).Clear();
        //    driver.FindElement(By.Id("input-telephone")).SendKeys("+38000000");
        //    driver.FindElement(By.Id("input-fax")).Clear();
        //    driver.FindElement(By.Id("input-fax")).SendKeys("+380000000");

        //    // click button Continue
        //    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        //    actualResult = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;

        //    Assert.AreEqual(expectedResult, actualResult);

        //    GetMyAccountOption(MyAccount.Logout);

        //}
    }
}
