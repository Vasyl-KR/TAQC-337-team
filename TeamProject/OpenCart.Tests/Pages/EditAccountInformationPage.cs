﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OpenCartTests.Pages
{
    public class EditAccountInformationPage : ATopComponent
    {
        #region Fields

        public const string DefaultFax = "+380999777555";
        public const string ExpectedSuccessMessage = "Success: Your account has been successfully updated.";
        public const string FirstNameWarningText = "First Name must be between 1 and 32 characters!";
        public const string LastNameWarningText = "Last Name must be between 1 and 32 characters!";
        public const string EmailWarningText = "E-Mail Address does not appear to be valid!";
        public const string TelephoneWarningText = "Telephone must be between 3 and 32 characters!";

        private readonly IWebDriver driver;

        #endregion

        #region Constructors

        public EditAccountInformationPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region Proporties

        //Warning Messages For Requared Fields 
        [FindsBy(How = How.XPath, Using = "//input[@id='input-firstname']/following-sibling::div[@class='text-danger']")]
        public IWebElement FirstNameWarningMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='input-lastname']/following-sibling::div[@class='text-danger']")]
        public IWebElement LastNameWarningMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='input-email']/following-sibling::div[@class='text-danger']")]
        public IWebElement EmailWarningMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='input-telephone']/following-sibling::div[@class='text-danger']")]
        public IWebElement TelephoneWarningMessage { get; set; }

        //input fields
        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-success")]
        public IWebElement SuccessMessage { get; set; }

        [FindsBy(How = How.Id, Using = "input-firstname")]
        public IWebElement InputFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "input-lastname")]
        public IWebElement InputLastName { get; set; }

        [FindsBy(How = How.Id, Using = "input-email")]
        public IWebElement InputEmail { get; set; }

        [FindsBy(How = How.Id, Using = "input-telephone")]
        public IWebElement InputTelephone { get; set; }

        [FindsBy(How = How.Id, Using = "input-fax")]
        public IWebElement InputFax { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn.btn-default")]
        public IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn.btn-primary")]
        public IWebElement BtnContinue { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method for click on field
        /// </summary>
        /// <param name="webElement"></param>
        public void ClickOnField(IWebElement webElement)
        {
            webElement.Click();
        }

        /// <summary>
        /// Method for cleaning field with data
        /// </summary>
        /// <param name="webElement"></param>
        public void ClearDataInField(IWebElement webElement)
        {
            webElement.Clear();
        }

        /// <summary>
        /// Method for input data in a field
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="text"></param>
        public void SetDataInField(IWebElement webElement, string text)
        {
            webElement.SendKeys(text);
        }

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
        /// Method for click button Back
        /// </summary>
        /// <returns></returns>
        public void ClickButtonBack()
        {
            BtnBack.Click();
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
}
