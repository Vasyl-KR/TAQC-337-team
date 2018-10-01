﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartTests.Pages
{
    class EditAccountInformationPage: ATopComponent
    {
        #region Locators

        private const string IdFirstName = "input-firstname";
        private const string IdLastName = "input-lastname";
        private const string IdEmail = "input-email";
        private const string IdTelephone = "input-telephone";
        private const string IdFax = "input-fax";

        private const string CssSelectorBtnBack = "input.btn.btn-default";
        private const string CssSelectorBtnContinue = "input.btn.btn-primary";

        #endregion

        #region Fields

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public EditAccountInformationPage(IWebDriver driver) : base(driver)
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

        public IWebElement BtnBack
        {
            get { return driver.FindElement(By.CssSelector(CssSelectorBtnBack)); }
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

        #endregion

        #region Methods
        
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

        public void ClickButtonBack()
        {
            BtnBack.Click();
        }

        public void ClickButtonContinue()
        {
            BtnContinue.Click();
        }

        #endregion
    }
}