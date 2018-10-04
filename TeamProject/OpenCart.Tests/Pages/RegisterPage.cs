using System.Collections.Generic;
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

        public IWebElement InputFirstNameField
        {
            get { return driver.FindElement(By.Id(IdFirstName)); }
        }

        public IWebElement InputLastNameField
        {
            get { return driver.FindElement(By.Id(IdLastName)); }
        }

         
        public IWebElement InputEmailField
        {
            get { return driver.FindElement(By.Id(IdEmail)); }
        }

         
        public IWebElement InputTelephoneField
        {
            get { return driver.FindElement(By.Id(IdTelephone)); }
        }

        
        public IWebElement Fax
        {
            get { return driver.FindElement(By.Id(IdFax)); }
        }

         
        public IWebElement InputCompanyField
        {
            get { return driver.FindElement(By.Id(IdCompany)); }
        }

         
        public IWebElement InputAddress1Field
        {
            get { return driver.FindElement(By.Id(IdAddress1)); }
        }

         
        public IWebElement InputAddress2Field
        {
            get { return driver.FindElement(By.Id(IdAddress2)); }
        }

         
        public IWebElement InputCityField
        {
            get { return driver.FindElement(By.Id(IdCity)); }
        }

        
        public IWebElement InputPostCodeField
        {
            get { return driver.FindElement(By.Id(IdPostCode)); }
        }

         
        public IWebElement InputCountryField
        {
            get { return driver.FindElement(By.Id(IdCountry)); }
        }

         
        public IWebElement InputRegionField
        {
            get { return driver.FindElement(By.Id(IdRegion)); }
        }

        
        public IWebElement InputPasswordField
        {
            get { return driver.FindElement(By.Id(IdPassword)); }
        }

         
        public IWebElement InputConfirmPasswordField
        {
            get { return driver.FindElement(By.Id(IdConfirmPassword)); }
        }

        
        public IList<IWebElement> CheckBoxYesNoItems
        {
            get { return driver.FindElements(By.Name(NameCheckBox)); }
        }

         
        public IWebElement CheckAgreeTerms
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       
        public void SetFirstName(string firstName)
        {
            ClickInputField(InputFirstNameField);
            ClearInputField(InputFirstNameField);
            SetInputField(InputFirstNameField, firstName);
        }

        public void SetLastName(string lastName)
        {
            ClickInputField(InputLastNameField);
            ClearInputField(InputLastNameField);
            SetInputField(InputLastNameField, lastName);
        }

        public void SetEmail(string email)
        {
            ClickInputField(InputEmailField);
            ClearInputField(InputEmailField);
            SetInputField(InputEmailField, email);
        }

        public void SetTelephone(string telephone)
        {
            ClickInputField(InputTelephoneField);
            ClearInputField(InputTelephoneField);
            SetInputField(InputTelephoneField, telephone);
        }

        public void SetFax(string fax)
        {
            ClickInputField(Fax);
            ClearInputField(Fax);
            SetInputField(Fax, fax);
        }

        public void SetCompany(string company)
        {
            ClickInputField(InputCompanyField);
            ClearInputField(InputCompanyField);
            SetInputField(InputCompanyField, company);
        }

        public void SetAddress1(string address1)
        {
            ClickInputField(InputAddress1Field);
            ClearInputField(InputAddress1Field);
            SetInputField(InputAddress1Field, address1);
        }

        public void SetAddress2(string address2)
        {
            ClickInputField(InputAddress2Field);
            ClearInputField(InputAddress2Field);
            SetInputField(InputAddress2Field, address2);
        }

        public void SetCity(string city)
        {
            ClickInputField(InputCityField);
            ClearInputField(InputCityField);
            SetInputField(InputCityField, city);
        }

        public void SetPostCode(string postCode)
        {
            ClickInputField(InputPostCodeField);
            ClearInputField(InputPostCodeField);
            SetInputField(InputPostCodeField, postCode);
        }

        public void SetCountry(string country)
        {
            ClickInputField(InputCountryField);
            SelectFromDropDownList(InputCountryField, country);
        }

        public void SetRegion(string region)
        {
            ClickInputField(InputRegionField);
            SelectFromDropDownList(InputRegionField, region);
        }

        public void SetPassword(string password)
        {
            ClickInputField(InputPasswordField);
            ClearInputField(InputPasswordField);
            SetInputField(InputPasswordField, password);
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            ClickInputField(InputConfirmPasswordField);
            ClearInputField(InputConfirmPasswordField);
            SetInputField(InputConfirmPasswordField, confirmPassword);
        }

        public void SetNewsLetter(bool yesOrNo = true)
        {
            if (yesOrNo)
            {
                CheckBoxYesNoItems[0].Click();
            }
            else { CheckBoxYesNoItems[1].Click();}
        }

        public void SetCheckAgreeTerms()
        {
            CheckAgreeTerms.Click();
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

        

        #region Locators 

        private const string XPathBtnConfirmationContinue = "//div[@class='pull-right']//a[contains(@href, 'account/account')]";

        private const string XPathSuccessParagraphText = "//div[@id ='content']/p";

        private const string XPathSuccessH1Text = "//div[@id ='content']/h1";

        #endregion

        #region Fields

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public ConfirmationRegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Proporties

        public IWebElement SuccessH1Element
        {
            get { return driver.FindElement(By.XPath(XPathSuccessH1Text)); }
        }

        public ReadOnlyCollection<IWebElement> SuccessPElements
        {
            get { return driver.FindElements(By.XPath(XPathSuccessParagraphText)); }
        }

        public IWebElement BtnConfirmationContinue
        {
            get { return driver.FindElement(By.XPath(XPathBtnConfirmationContinue)); }
        }

        #endregion

        #region Methods

        public void ClickConfirmationButtonContinue()
        {
            BtnConfirmationContinue.Click();
        }

        #endregion
    }
}
