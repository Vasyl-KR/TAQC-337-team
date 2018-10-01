using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartTests.Pages
{

    public class RegisterPage: ATopComponent
    {
        #region Locators
        private const string IdFirstName = "input-firstname";
        private const string IdLastName = "input-lastname";
        private const string IdEmail = "input-email";
        private const string IdTelephone = "input-telephone";
        private const string IdFax = "input-fax";

        private const string IdCompany = "input-company";
        private const string IdAddress1 = "input-address-1";
        private const string IdAddress2 = "input-address-2";
        private const string IdCity = "input-city";
        private const string IdPostCode = "input-postcode";
        private const string IdCountry = "input-country";
        private const string IdRegion = "input-zone";

        private const string IdPassword = "input-password";
        private const string IdConfirmPassword = "input-confirm";
        private const string NameCheckBox = "newsletter";
        private const string NameAgreePrivacyPolicy = "agree";

        private const string CssSelectorBtnContinue = "input.btn.btn-primary";

        #endregion

        #region Fields

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public RegisterPage(IWebDriver driver) : base(driver)
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

        #region Private Methods

        private void ClickInputField(IWebElement webElement)
        {
            webElement.Click();
        }

        private void ClearInputField(IWebElement webElement)
        {
            webElement.Clear();
        }

        private void SetInputField(IWebElement webElement, string text)
        {
            webElement.SendKeys(text);
        }

        private void SelectFromDropDownList(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }
       
        #endregion 

        #region Methods

        public RegisterPage GoToRegisterPage()
        {
            ClickRegiser();
            return new RegisterPage(driver);
        }

        public void SetFirstName(string firstName)
        {
            ClickInputField(FirstName);
            ClearInputField(FirstName);
            SetInputField(FirstName, firstName);
        }

        public void SetLastName(string lastName)
        {
            ClickInputField(LastName);
            ClearInputField(LastName);
            SetInputField(LastName, lastName);
        }

        public void SetEmail(string email)
        {
            ClickInputField(Email);
            ClearInputField(Email);
            SetInputField(Email, email);
        }

        public void SetTelephone(string telephone)
        {
            ClickInputField(Telephone);
            ClearInputField(Telephone);
            SetInputField(Telephone, telephone);
        }

        public void SetFax(string fax)
        {
            ClickInputField(Fax);
            ClearInputField(Fax);
            SetInputField(Fax, fax);
        }

        public void SetCompany(string company)
        {
            ClickInputField(Company);
            ClearInputField(Company);
            SetInputField(Company, company);
        }

        public void SetAddress1(string address1)
        {
            ClickInputField(Address1);
            ClearInputField(Address1);
            SetInputField(Address1, address1);
        }

        public void SetAddress2(string address2)
        {
            ClickInputField(Address2);
            ClearInputField(Address2);
            SetInputField(Address2, address2);
        }

        public void SetCity(string city)
        {
            ClickInputField(City);
            ClearInputField(City);
            SetInputField(City, city);
        }

        public void SetPostCode(string postCode)
        {
            ClickInputField(PostCode);
            ClearInputField(PostCode);
            SetInputField(PostCode, postCode);
        }

        public void SetCountry(string country)
        {
            ClickInputField(Country);
            SelectFromDropDownList(Country, country);
        }

        public void SetRegion(string region)
        {
            ClickInputField(Region);
            SelectFromDropDownList(Region, region);
        }

        public void SetPassword(string password)
        {
            ClickInputField(Password);
            ClearInputField(Password);
            SetInputField(Password, password);
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            ClickInputField(ConfirmPassword);
            ClearInputField(ConfirmPassword);
            SetInputField(ConfirmPassword, confirmPassword);
        }

        public void SetNewsLetter(bool yesOrNo = true)
        {
            if (yesOrNo)
            {
                CheckBox[0].Click();
            }
            else { CheckBox[1].Click();}
        }

        public void CheckAgreePrivacyPolicy()
        {
            AgreePrivacyPolicy.Click();
        }

        public ConfirmationRegisterPage ClickButtonContinue()
        {
            BtnContinue.Click();
            return new ConfirmationRegisterPage(driver);
        }

        #endregion
    }

    public class ConfirmationRegisterPage: ATopComponent
    {
        private readonly IWebDriver driver;

        private const string XPathBtnContinue = "//div[@class='pull-right']//a[contains(@href, 'account/account')]";

        private const string XPathParagraphText = "//div[@id ='content']/p";

        private const string XPathH1Text = "//div[@id ='content']/h1";

        public ConfirmationRegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement H1Element
        {
            get { return driver.FindElement(By.XPath(XPathH1Text)); }
        }

        public ReadOnlyCollection<IWebElement> PElements
        {
            get { return driver.FindElements(By.XPath(XPathParagraphText)); }
        }

        public IWebElement BtnConfirmationContinue
        {
            get { return driver.FindElement(By.XPath(XPathBtnContinue)); }
        }

        public void ClickConfirmationButtonContinue()
        {
            BtnConfirmationContinue.Click();
        }


    }
}
