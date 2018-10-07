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
        public IWebElement SelectCountry { get; set; }

        [FindsBy(How = How.Id, Using = "input-zone")]
        public IWebElement SelectRegion { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-default")]
        public IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        public IWebElement BtnContinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#input-firstname")]
        public IWebElement InputFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "input-lastname")]
        public IWebElement InputLastName { get; set; }

        [FindsBy(How = How.Id, Using = "input-company")]
        public IWebElement InputCompany { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-1")]
        public IWebElement InputAddress1 { get; set; }

        [FindsBy(How = How.Id, Using = "input-address-2")]
        public IWebElement InputAddress2 { get; set; }

        [FindsBy(How = How.Id, Using = "input-city")]
        public IWebElement InputCity { get; set; }

        [FindsBy(How = How.Id, Using = "input-postcode")]
        public IWebElement InputPostCode { get; set; }
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

        public void ClickInputField(IWebElement webElement)
        {
            webElement.Click();
        }

        public void ClearInputField(IWebElement webElement)
        {
            webElement.Clear();
        }

        public void SetInputField(string text, IWebElement webElement)
        {
            webElement.SendKeys(text);
        }

        public void ClickButtonContinue()
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
            return driver.FindElement(By.CssSelector(".text-danger")).Text;
        }
        #endregion
    }
}
