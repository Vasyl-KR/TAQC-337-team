using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartTests.Pages
{
    public class RegisterPage : ATopComponent
    {
        #region Locators
        //Personal Details Fields
        private const string firstnameInputId = "input-firstname";
        private const string lastnameInputId = "input-lastname";
        private const string emailInputId = "input-email";
        private const string telephoneInputId = "input-telephone";
        private const string faxInputId = "input-fax";
        //Address Fields
        private const string companyInputId = "input-company";
        private const string address1InputId = "input-address-1";
        private const string address2InputId = "input-address-2";
        private const string cityInputId = "input-city";
        private const string postcodeInputId = "input-postcode";
        private const string countryInputId = "input-country";
        private const string regionInputId = "input-zone";
        //Passwords Fields
        private const string passwordInputId = "input-password";
        private const string confirmPasswordInputId = "input-confirm";
        //CheckBox News Letters
        private const string checkBoxInputName = "newsletter";
        //Check Privacy Policy
        private const string agreeTermsInputName = "agree";
        // Button Continue
        private const string continueBtnCssSelector = "input.btn.btn-primary";
        //Warning Message For Requared Fields 
        private const string frstNameWarningMessageXPath = "//input[@id='input-firstname']/following-sibling::div[@class='text-danger']";
        private const string lastNameWarningMessageXPath = "//input[@id='input-lastname']/following-sibling::div[@class='text-danger']";
        private const string emailWarningMessageXPath = "//input[@id='input-email']/following-sibling::div[@class='text-danger']";
        private const string telephoneWarningMessageXPath = "//input[@id='input-telephone']/following-sibling::div[@class='text-danger']";
        private const string address1WarningMessageXPath = "//input[@id='input-address-1']/following-sibling::div[@class='text-danger']";
        private const string cityWarningMessageXPath = "//input[@id='input-city']/following-sibling::div[@class='text-danger']";
        private const string countryWarningMessageXPath = "//select[@id='input-country']/following-sibling::div[@class='text-danger']";
        private const string regionWarningMessageXPath = "//select[@id='input-zone']/following-sibling::div[@class='text-danger']";
        private const string passwordWarningMessageXPath = "//input[@id='input-password']/following-sibling::div[@class='text-danger']";
        private const string confirmPasswordWarningMessageXPath = "//input[@id='input-confirm']/following-sibling::div[@class='text-danger']";
        private const string agreeTermsWarningMessageCssSelector = "div.alert.alert-danger";

        #endregion

        #region Fields
        //Warning message for empty fields
        public const string FirstNameWarningText = "First Name must be between 1 and 32 characters!";
        public const string LastNameWarningText = "Last Name must be between 1 and 32 characters!";
        public const string EmailWarningText = "E-Mail Address does not appear to be valid!";
        public const string TelephoneWarningText = "Telephone must be between 3 and 32 characters!";
        public const string Address1WarningText = "Address 1 must be between 3 and 128 characters!";
        public const string CityWarningText = "City must be between 2 and 128 characters!";
        public const string PostCodeWarningText = "Postcode must be between 2 and 10 characters!";
        public const string CountryWarningText = "Please select a country!";
        public const string RegionWarningText = "Please select a region / state!";
        public const string PasswordWarningText = "Password must be between 4 and 20 characters!";
        public const string ConfirmWarningText = "Password confirmation does not match password!";
        public const string AgreeTermsWarningText = "Warning: You must agree to the Privacy Policy!";
        public const string ShotPassword = "1q!";
        public const string PleseSelect = " --- Please Select --- ";

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Proporties

        //Warning Messages For Requared Fields 
       public IWebElement FirstNameWarningMessage
        {
            get { return driver.FindElement(By.XPath(frstNameWarningMessageXPath)); }
        }

        public IWebElement LastNameWarningMessage
        {
            get { return driver.FindElement(By.XPath(lastNameWarningMessageXPath)); }
        }

        public IWebElement EmailWarningMessage
        {
            get { return driver.FindElement(By.XPath(emailWarningMessageXPath)); }
        }

        public IWebElement TelephoneWarningMessage
        {
            get { return driver.FindElement(By.XPath(telephoneWarningMessageXPath)); }
        }

        public IWebElement Address1WarningMessage
        {
            get { return driver.FindElement(By.XPath(address1WarningMessageXPath)); }
        }

        public IWebElement CityWarningMessage
        {
            get { return driver.FindElement(By.XPath(cityWarningMessageXPath)); }
        }

        public IWebElement CountryWarningMessage
        {
            get { return driver.FindElement(By.XPath(countryWarningMessageXPath)); }
        }

        public IWebElement RegionWarningMessage
        {
            get { return driver.FindElement(By.XPath(regionWarningMessageXPath)); }
        }

        public IWebElement PasswordWarningMessage
        {
            get { return driver.FindElement(By.XPath(passwordWarningMessageXPath)); }
        }

        public IWebElement ConfirmPasswordWarningMessage
        {
            get { return driver.FindElement(By.XPath(confirmPasswordWarningMessageXPath)); }
        }

        public IWebElement AgreeTermsWarningMessage
        {
            get { return driver.FindElement(By.CssSelector(agreeTermsWarningMessageCssSelector)); }
        }

        //Input Fields
        public IWebElement InputFirstName
        {
            get { return driver.FindElement(By.Id(firstnameInputId)); }
        }

        public IWebElement InputLastName
        {
            get { return driver.FindElement(By.Id(lastnameInputId)); }
        }

        public IWebElement InputEmail

        {
            get { return driver.FindElement(By.Id(emailInputId)); }
        }

        public IWebElement InputTelephone
        {
            get { return driver.FindElement(By.Id(telephoneInputId)); }
        }

        public IWebElement InputFax
        {
            get { return driver.FindElement(By.Id(faxInputId)); }
        }

        public IWebElement InputCompany
        {
            get { return driver.FindElement(By.Id(companyInputId)); }
        }

        public IWebElement InputAddress1
        {
            get { return driver.FindElement(By.Id(address1InputId)); }
        }

        public IWebElement InputAddress2
        {
            get { return driver.FindElement(By.Id(address2InputId)); }
        }

        public IWebElement InputCity
        {
            get { return driver.FindElement(By.Id(cityInputId)); }
        }

        public IWebElement InputPostCode
        {
            get { return driver.FindElement(By.Id(postcodeInputId)); }
        }

        public IWebElement InputCountry
        {
            get { return driver.FindElement(By.Id(countryInputId)); }
        }

        public IWebElement InputRegion
        {
            get { return driver.FindElement(By.Id(regionInputId)); }
        }

        public IWebElement InputPassword
        {
            get { return driver.FindElement(By.Id(passwordInputId)); }
        }

        public IWebElement InputConfirmPassword
        {
            get { return driver.FindElement(By.Id(confirmPasswordInputId)); }
        }

        public IList<IWebElement> CheckBoxYesNoItems
        {
            get { return driver.FindElements(By.Name(checkBoxInputName)); }
        }

        public IWebElement CheckAgreeTerms
        {
            get { return driver.FindElement(By.Name(agreeTermsInputName)); }
        }

        public IWebElement BtnContinue
        {
            get { return driver.FindElement(By.CssSelector(continueBtnCssSelector)); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method for click on field
        /// </summary>
        /// <param name="webElement"></param>
        private void ClickOnField(IWebElement webElement)
        {
            webElement.Click();
        }

        /// <summary>
        /// Method for cleaning field with data
        /// </summary>
        /// <param name="webElement"></param>
        private void ClearDataInField(IWebElement webElement)
        {
            webElement.Clear();
        }

        /// <summary>
        /// Method for input data in a field
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="text"></param>
        private void SetDataInField(IWebElement webElement, string text)
        {
            webElement.SendKeys(text);
        }

        /// <summary>
        /// Method for select data from drop down list
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="text"></param>
        private void SelectFromDropDownList(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method for input data in First Name field
        /// </summary>
        /// <returns></returns> 
        public void SetFirstName(string textFirstName)
        {
            ClickOnField(InputFirstName);
            ClearDataInField(InputFirstName);
            SetDataInField(InputFirstName, textFirstName);
        }

        /// <summary>
        /// Method for input data in Last Name field
        /// </summary>
        /// <param name="textLastName"></param>
        public void SetLastName(string textLastName)
        {
            ClickOnField(InputLastName);
            ClearDataInField(InputLastName);
            SetDataInField(InputLastName, textLastName);
        }

        /// <summary>
        /// Method for input data in Email field
        /// </summary>
        /// <param name="textEmail"></param>
        public void SetEmail(string textEmail)
        {
            ClickOnField(InputEmail);
            ClearDataInField(InputEmail);
            SetDataInField(InputEmail, textEmail);
        }

        /// <summary>
        /// Method for input data in Telephone field
        /// </summary>
        /// <param name="textTelephone"></param>
        public void SetTelephone(string textTelephone)
        {
            ClickOnField(InputTelephone);
            ClearDataInField(InputTelephone);
            SetDataInField(InputTelephone, textTelephone);
        }

        /// <summary>
        /// Method for input data in Fax field
        /// </summary>
        /// <param name="textFax"></param>
        public void SetFax(string textFax)
        {
            ClickOnField(InputFax);
            ClearDataInField(InputFax);
            SetDataInField(InputFax, textFax);
        }

        /// <summary>
        /// Method for input data in Company field
        /// </summary>
        /// <param name="textCompany"></param>
        public void SetCompany(string textCompany)
        {
            ClickOnField(InputCompany);
            ClearDataInField(InputCompany);
            SetDataInField(InputCompany, textCompany);
        }

        /// <summary>
        /// Method for input data in Address_1 field
        /// </summary>
        /// <param name="textAddress1"></param>
        public void SetAddress1(string textAddress1)
        {
            ClickOnField(InputAddress1);
            ClearDataInField(InputAddress1);
            SetDataInField(InputAddress1, textAddress1);
        }

        /// <summary>
        ///  Method for input data in Address_2 field
        /// </summary>
        /// <param name="textAddress2"></param>
        public void SetAddress2(string textAddress2)
        {
            ClickOnField(InputAddress2);
            ClearDataInField(InputAddress2);
            SetDataInField(InputAddress2, textAddress2);
        }

        /// <summary>
        ///  Method for input data in City field
        /// </summary>
        /// <param name="textCity"></param>
        public void SetCity(string textCity)
        {
            ClickOnField(InputCity);
            ClearDataInField(InputCity);
            SetDataInField(InputCity, textCity);
        }

        /// <summary>
        ///  Method for input data in PostCode field
        /// </summary>
        /// <param name="textPostCode"></param>
        public void SetPostCode(string textPostCode)
        {
            ClickOnField(InputPostCode);
            ClearDataInField(InputPostCode);
            SetDataInField(InputPostCode, textPostCode);
        }

        /// <summary>
        ///  Method for input data in Country field
        /// </summary>
        /// <param name="textCountry"></param>
        public void SetCountry(string textCountry)
        {
            ClickOnField(InputCountry);
            SelectFromDropDownList(InputCountry, textCountry);
        }

        /// <summary>
        ///  Method for input data in Region/State field
        /// </summary>
        /// <param name="textRegion"></param>
        public void SetRegion(string textRegion)
        {
            ClickOnField(InputRegion);
            SelectFromDropDownList(InputRegion, textRegion);
        }

        /// <summary>
        /// Method for input data in Password field
        /// </summary>
        /// <param name="textPassword"></param>
        public void SetPassword(string textPassword)
        {
            ClickOnField(InputPassword);
            ClearDataInField(InputPassword);
            SetDataInField(InputPassword, textPassword);
        }

        /// <summary>
        /// Method for input data in ConfirmPassword field
        /// </summary>
        /// <param name="textConfirmPassword"></param>
        public void SetConfirmPassword(string textConfirmPassword)
        {
            ClickOnField(InputConfirmPassword);
            ClearDataInField(InputConfirmPassword);
            SetDataInField(InputConfirmPassword, textConfirmPassword);
        }

        /// <summary>
        /// Method for select Yes or No for Subscribing news letters
        /// </summary>
        /// <param name="yesOrNo"></param>
        public void SelectNewsLetter(bool yesOrNo = true)
        {
            if (yesOrNo)
            {
                CheckBoxYesNoItems[0].Click();
            }
            else
            {
                CheckBoxYesNoItems[1].Click();
            }
        }

        /// <summary>
        /// Method for set mark in a checkbox with the terms
        /// </summary>
        public void SetCheckAgreeTerms()
        {
            CheckAgreeTerms.Click();
        }

        /// <summary>
        /// Method for click button Continue
        /// </summary>
        /// <returns></returns>
        public void ClickButtonContinue()
        {
            BtnContinue.Click();
        }

        #endregion
    }

    public class ConfirmationRegisterPage : ATopComponent
    {
        #region Locators 
        //Confirmation Button Continur 
        private const string confirmationContinueBtnXPath =
                    "//div[@class='pull-right']//a[contains(@href, 'account/account')]";       
        //Paragraph text
        private const string successParagraphTextXPath = "//div[@id ='content']/p";
        //Header text
        private const string successH1TextXPath = "//div[@id ='content']/h1";

        #endregion

        #region Fields

        public const string ExpectedSuccessMessage = "Your Account Has Been Created!";
        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public ConfirmationRegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Proporties

        public IWebElement SuccessMessageH1Element
        {
            get { return driver.FindElement(By.XPath(successH1TextXPath)); }
        }

        public ReadOnlyCollection<IWebElement> SuccessMessagePElements
        {
            get { return driver.FindElements(By.XPath(successParagraphTextXPath)); }
        }

        public IWebElement BtnConfirmationContinue
        {
            get { return driver.FindElement(By.XPath(confirmationContinueBtnXPath)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method for click button Continue
        /// </summary>
        public void ClickConfirmationButtonContinue()
        {
            BtnConfirmationContinue.Click();
        }

        #endregion
    }
}
