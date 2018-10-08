using OpenCartTests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
   public class EditAddressPage : ATopComponent
    {
        #region 
        [FindsBy(How = How.Id, Using = "input-country")]
        private IWebElement SelectCountry { get; set; }

        [FindsBy(How = How.Id, Using = "input-zone")]
        private IWebElement SelectRegion { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-default")]
        private IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        private IWebElement BtnContinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#input-firstname")]
        private IWebElement InputFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "input-lastname")]
        private IWebElement InputLastName { get; set; }

        [FindsBy(How = How.Id, Using = "input-company")]
        private IWebElement InputCompany { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-1")]
        private IWebElement InputAddress1 { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-2")]
        private IWebElement InputAddress2 { get; set; }

        [FindsBy(How = How.Id, Using = "input-city")]
        private IWebElement InputCity { get; set; }

        [FindsBy(How = How.Id, Using = "input-postcode")]
        private IWebElement InputPostCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".text-danger")]
        private IWebElement ValidationMessage { get; set; }
        #endregion

        #region
        public EditAddressPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            VerifyWebElements_INPUTS();
            VerifyWebElements_BTN_SELECT();
        }

        private void VerifyWebElements_INPUTS()
        {
            IWebElement element = InputFirstName;
            element = InputLastName;
            element = InputCompany;
            element = InputAddress1;
            element = InputAddress2;
            element = InputCity;
            element = InputPostCode;
        }


        private void VerifyWebElements_BTN_SELECT()
        {
            IWebElement element = BtnBack;
            element = BtnContinue;
            element = SelectCountry;
            element = SelectRegion;
        }

        private void ClickInputField(IWebElement webElement)
        {
            webElement.Click();
        }

        private void ClearInputField(IWebElement webElement)
        {
            webElement.Clear();
        }

        private void SetInputField(string text, IWebElement webElement)
        {
            webElement.SendKeys(text);
        }

        private void ClickButtonContinue()
        {
            BtnContinue.Click();
        }

        #endregion

        #region
        public AddressPage ClickBackButton()
        {
            BtnBack.Click();
            return new AddressPage(driver);
        }

        public EditAddressPage SetClearInputField(string text, IWebElement webElement)
        {

            ClickInputField(webElement);

            ClearInputField(webElement);

            SetInputField(text, webElement);

            return this;
        }

        public EditAddressPage SetSelectField(string text, IWebElement webElement)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
            return this;
        }

        public AddressPage SuccessfullEditionAddress(User user)
        {

            SetClearInputField(user.firstName, InputFirstName);
            SetClearInputField(user.lastName, InputLastName);
            SetClearInputField(user.address_1, InputAddress1);
            SetClearInputField(user.city, InputCity);
            SetClearInputField(user.postCode, InputPostCode);
            SetSelectField(user.country, SelectCountry);
            SetSelectField(user.region, SelectRegion);
            ClickButtonContinue();
            return new AddressPage(driver);
        }

        public EditAddressPage UnsuccessfullEditionAddress(User user)
        {

            SetClearInputField(user.firstName, InputFirstName);
            SetClearInputField(user.lastName, InputLastName);
            SetClearInputField(user.address_1, InputAddress1);
            SetClearInputField(user.city, InputCity);
            SetClearInputField(user.postCode, InputPostCode);
            SetSelectField(user.country, SelectCountry);
            SetSelectField(user.region, SelectRegion);
            ClickButtonContinue();
            return this;
        }

        public string GetWarningMessage()
        {
            return ValidationMessage.Text;
        }
        #endregion
    }
}
