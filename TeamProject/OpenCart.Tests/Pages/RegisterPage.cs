using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace OpenCartTests.Pages
{
   

    public class RegisterPage
    {
        #region Locators
        public const string IdFirstName = "input-firstname";
        public const string IdLastName = "input-lastname";
        public const string IdEmail = "input-email";
        public const string IdTelephone = "input-telephone";
        public const string IdFax = "input-fax";

        public const string IdCompany = "input-company";
        public const string IdAddress1 = "input-address-1";
        public const string IdAddress2 = "input-address-2";
        public const string IdCity = "input-city";
        public const string IdPostCode = "input-postcode";
        public const string IdCountry = "input-country";
        public const string IdRegion = "input-zone";

        public const string IdPassword = "input-password";
        public const string IdConfirmPassword = "input-confirm";
        public const string NameCheckBox = "newsletter";
        public const string NameAgreePrivacyPolicy = "agree";

        public const string CssSelectorBtnContinue = "input.btn.btn-primary";

        #endregion

        #region Fields

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Proporties

        public IWebElement FirstName
        {
            get { return driver.FindElement(By.Id(IdFirstName)); }
        }

        public IWebElement LastName
        {
            get { return driver.FindElement(By.Id(IdLastName)); }
        }

        public IWebElement Email
        {
            get { return driver.FindElement(By.Id(IdEmail)); }
        }

        public IWebElement Telephone
        {
            get { return driver.FindElement(By.Id(IdTelephone)); }
        }

        public IWebElement Fax
        {
            get { return driver.FindElement(By.Id(IdFax)); }
        }

        public IWebElement Company
        {
            get { return driver.FindElement(By.Id(IdCompany)); }
        }

        public IWebElement Address1
        {
            get { return driver.FindElement(By.Id(IdAddress1)); }
        }

        public IWebElement Address2
        {
            get { return driver.FindElement(By.Id(IdAddress2)); }
        }

        public IWebElement City
        {
            get { return driver.FindElement(By.Id(IdCity)); }
        }

        public IWebElement PostCode
        {
            get { return driver.FindElement(By.Id(IdPostCode)); }
        }

        public IWebElement Country
        {
            get { return driver.FindElement(By.Id(IdCountry)); }
        }

        public IWebElement Region
        {
            get { return driver.FindElement(By.Id(IdRegion)); }
        }

        public IWebElement Password
        {
            get { return driver.FindElement(By.Id(IdPassword)); }
        }

        public IWebElement ConfirmPassword
        {
            get { return driver.FindElement(By.Id(IdConfirmPassword)); }
        }

        public ReadOnlyCollection<IWebElement> CheckBox
        {
            get { return driver.FindElements(By.Name(NameCheckBox)); }
        }
        public IWebElement AgreePrivacyPolicy
        {
            get { return driver.FindElement(By.Name(NameAgreePrivacyPolicy)); }
        }

        public IWebElement BtnContinue
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorBtnContinue)); }
        }

        #endregion

        #region Methods



        #endregion


        //    private IWebDriver driver;
        //    private ListUsers users;
        //    private User user;

        //    [OneTimeSetUp]
        //    public void CreateNecessaryObjects()
        //    {
        //        users = UserData.GetUsersData();
        //        driver = new ChromeDriver();
        //        user = users.Users[0];

        //    }

        //    [OneTimeTearDown]
        //    public void ClearResources()
        //    {
        //        driver.Quit();
        //        driver.Dispose();
        //    }

        //    private void GetMyAccountOption(MyAccount account)
        //    {
        //        IWebElement myAcount = driver.FindElement(By.CssSelector("i.fa.fa-user"));
        //        myAcount.Click();

        //        switch (account)
        //        {
        //            case MyAccount.Register:
        //                driver.FindElement(By.XPath("//a[contains(@href, '/register')]")).Click();
        //                break;

        //            case MyAccount.Login:
        //                driver.FindElement(By.XPath("//a[contains(@href, '/login')]")).Click();
        //                break;

        //            case MyAccount.MyAccount:
        //                driver.FindElement(By.LinkText("My Account")).Click();
        //                break;

        //            case MyAccount.OrderHistory:
        //                driver.FindElement(By.LinkText("Order History")).Click();
        //                break;

        //            case MyAccount.Transactions:
        //                driver.FindElement(By.LinkText("Transactions")).Click();
        //                break;

        //            case MyAccount.Downloads:
        //                driver.FindElement(By.LinkText("Downloads")).Click();
        //                break;

        //            case MyAccount.Logout:
        //                driver.FindElement(By.LinkText("Logout")).Click();
        //                break;
        //        }
        //    }

        //    [Test, Order(1)]
        //    public void Test_Register_User()
        //    {
        //        string expectedResult = "Your Account Has Been Created!";
        //        string actualResult = String.Empty;

        //        driver.Navigate().GoToUrl("https://fierysky.000webhostapp.com/index.php?route=common/home");
        //        GetMyAccountOption(MyAccount.Register);

        //        //fill fields
        //        driver.FindElement(By.Id("input-firstname")).SendKeys(user.firstName);
        //        driver.FindElement(By.Id("input-lastname")).SendKeys(user.lastName);
        //        driver.FindElement(By.Id("input-email")).SendKeys(user.email);
        //        driver.FindElement(By.Id("input-telephone")).SendKeys(user.telephone);
        //       // driver.FindElement(By.Id("input-fax")).SendKeys(user.fax);
        //      //  driver.FindElement(By.Id("input-company")).SendKeys(user.company);
        //      //  driver.FindElement(By.Id("input-address-1")).SendKeys(user.address_1);
        //       // driver.FindElement(By.Id("input-address-2")).SendKeys(user.address_2);
        //       // driver.FindElement(By.Id("input-city")).SendKeys(user.city);
        //       // driver.FindElement(By.Id("input-postcode")).SendKeys(user.postCode);
        //      //  driver.FindElement(By.Id("input-country")).SendKeys(user.country);

        //        // wait for entered region
        //        //WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //        //driverWait.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.Id("input-country")),
        //        //            user.country));

        //      //  driver.FindElement(By.Id("input-zone")).SendKeys(user.region);
        //        driver.FindElement(By.Id("input-password")).SendKeys(user.password);
        //        driver.FindElement(By.Id("input-confirm")).SendKeys(user.password);

        //        //check Yes radio button
        //        IList<IWebElement> radioButton = driver.FindElements(By.Name("newsletter"));
        //        radioButton.ElementAt(0).Click();

        //        //check agree terms check box
        //        driver.FindElement(By.Name("agree")).Click();

        //        // click button Continue
        //        driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        //        actualResult = driver.FindElement(By.XPath("//div[contains(@class,'col-sm-9')]/h1")).Text;

        //        Assert.AreEqual(expectedResult, actualResult);

        //        GetMyAccountOption(MyAccount.Logout);
        //    }

        //    //[Test ]
        //    //public void Test_Edit_User()
        //    //{
        //    //    string expectedResult = "Success: Your account has been successfully updated.";
        //    //    string actualResult = String.Empty;

        //    //    //fill fields
        //    //    driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=common/home");
        //    //    GetMyAccountOption(MyAccount.Login);

        //    //    // fill login fields
        //    //    driver.FindElement(By.Id("input-email")).SendKeys(user.email);
        //    //    driver.FindElement(By.Id("input-password")).SendKeys(user.password);

        //    //    // click button Login
        //    //    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        //    //    //click edit account
        //    //    driver.FindElement(By.LinkText("Edit your account information")).Click();

        //    //    driver.FindElement(By.Id("input-firstname")).Clear();
        //    //    driver.FindElement(By.Id("input-firstname")).SendKeys("NewVVV");
        //    //    driver.FindElement(By.Id("input-lastname")).Clear();
        //    //    driver.FindElement(By.Id("input-lastname")).SendKeys("NewLLL");
        //    //    driver.FindElement(By.Id("input-email")).Clear();
        //    //    driver.FindElement(By.Id("input-email")).SendKeys("some@gmail.com");
        //    //    driver.FindElement(By.Id("input-telephone")).Clear();
        //    //    driver.FindElement(By.Id("input-telephone")).SendKeys("+38000000");
        //    //    driver.FindElement(By.Id("input-fax")).Clear();
        //    //    driver.FindElement(By.Id("input-fax")).SendKeys("+380000000");

        //    //    // click button Continue
        //    //    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

        //    //    actualResult = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;

        //    //    Assert.AreEqual(expectedResult, actualResult);

        //    //    GetMyAccountOption(MyAccount.Logout);

        //    //}
        //}


    }

}
