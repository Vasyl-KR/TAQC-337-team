using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Threading;
using System.IO;
using OpenCartTests.Data;

namespace OpenCartTests.Pages
{
   public class EditAddressPage : ATopComponent
    {
        #region Constants
        private const string FirstName_INPUT_ID = "input-firstname";
        private const string FirstName_LABEL_XPATH = "//label[contains(@for,'input-firstname')]";
        private const string LastName_INPUT_ID = "input-lastname";
        private const string LastName_LABEL_XPATH = "//label[contains(@for,'input-lastname')]";
        private const string Company_INPUT_ID = "input-company";
        private const string Company_LABEL_XPATH = "//label[contains(@for,'input-company')]";
        private const string Address1_INPUT_ID = "input-address-1";
        private const string Address1_LABEL_XPATH = "//label[contains(@for,'input-address-1')]";
        private const string Address2_INPUT_ID = "input-address-2";
        private const string Address2_LABEL_XPATH = "//label[contains(@for,'input-address-2')]";
        private const string City_INPUT_ID = "input-city";
        private const string City_LABEL_XPATH = "//label[contains(@for,'input-city')]";
        private const string PostCode_INPUT_ID = "input-postcode";
        private const string PostCode_LABEL_XPATH = "//label[contains(@for,'input-postcode')]";
        private const string Country_SELECT_ID = "input-country";
        private const string Region_SELECT_ID = "input-zone";
        private const string Back_BTN_CSSSELECTOR = ".btn.btn-default";
        private const string Country_BTN_CSSSELECTOR = ".btn.btn-primary";
        #endregion

        #region Properties
        public IWebElement SelectCountry { get { return driver.FindElement(By.Id(Country_SELECT_ID)); } }
        public IWebElement SelectRegion { get { return driver.FindElement(By.Id(Region_SELECT_ID)); } }

        public IWebElement BtnBack { get { return driver.FindElement(By.CssSelector(Back_BTN_CSSSELECTOR)); } }
        public IWebElement BtnCountine { get { return driver.FindElement(By.CssSelector(Country_BTN_CSSSELECTOR)); } }
           
        public IWebElement FirstNameLabel{get { return driver.FindElement(By.XPath(FirstName_LABEL_XPATH)); }}
        public IWebElement InputFirstName { get { return driver.FindElement(By.Id(FirstName_INPUT_ID)); }}
        public IWebElement LastNameLabel { get { return driver.FindElement(By.XPath(LastName_LABEL_XPATH)); } }
        public IWebElement InputLastName { get { return driver.FindElement(By.Id(LastName_INPUT_ID)); } }
        public IWebElement CompanyLabel { get { return driver.FindElement(By.XPath(Company_LABEL_XPATH)); } }
        public IWebElement InputCompany { get { return driver.FindElement(By.Id(Company_INPUT_ID)); } }  
        public IWebElement Address1Label { get { return driver.FindElement(By.XPath(Address1_LABEL_XPATH)); } }
        public IWebElement InputAddress1 { get { return driver.FindElement(By.Id(Address1_INPUT_ID)); } }
        public IWebElement Address2Label { get { return driver.FindElement(By.XPath(Address2_LABEL_XPATH)); } }
        public IWebElement InputAddress2 { get { return driver.FindElement(By.Id(Address2_INPUT_ID)); } }
        public IWebElement CityLabel { get { return driver.FindElement(By.XPath(City_LABEL_XPATH)); } }
        public IWebElement InputCity { get { return driver.FindElement(By.Id(City_INPUT_ID)); } }
        public IWebElement PostCodeLabel { get { return driver.FindElement(By.XPath(PostCode_LABEL_XPATH)); } }
        public IWebElement InputPostCode { get { return driver.FindElement(By.Id(PostCode_INPUT_ID)); } }
        #endregion

        public EditAddressPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements_INPUTS();
            VerifyWebElements_LABELS();
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

        private void VerifyWebElements_LABELS()
        {
            IWebElement element = FirstNameLabel;
            element = LastNameLabel;
            element = CompanyLabel;
            element = Address1Label;
            element = Address2Label;
            element = CityLabel;
            element = PostCodeLabel;
        }

        private void VerifyWebElements_BTN_SELECT()
        {
            IWebElement element = BtnBack;
            element = BtnCountine;
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

        public void ClickCountineButton()
        {
            BtnCountine.Click();
        }

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

        public EditAddressPage SetSelectField (string text, IWebElement webElement)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
            //webElement.Click();
            //webElement.FindElement(By.XPath("//option[text() = '" + text + "']")).Click(); 
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
            SetSelectField(user.region , SelectRegion);
            ClickCountineButton();
            return new AddressPage(driver);
        }

    }
}
