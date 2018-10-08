using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace OpenCartTests.Pages
{
    public class ChangePasswordPage : ATopComponent
    {
        #region Constants
        private const string Password_INPUT_ID = "input-password";
        private const string PasswordConfirm_INPUT_ID = "input-confirm";
        private const string Confirm_BTN_CSSSELECTOR = "input.btn.btn-primary";
        #endregion

        #region Properies

        public IWebElement PasswordInput
        { get { return driver.FindElement(By.Id("input-password")); } }

        public IWebElement PasswordConfirmInput
        { get { return driver.FindElement(By.Id("input-confirm")); } }

        public IWebElement ContinueButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }

        public IWebElement PasswordErrorMessage
        { get { return driver.FindElement(By.XPath("//input[@id='input-password']/following-sibling::div[@class='text-danger']")); } }

        public IWebElement PasswordConfirmErrorMessage
        { get { return driver.FindElement(By.XPath("//input[@id='input-confirm']/following-sibling::div[@class='text-danger']")); } }

        #endregion

        public ChangePasswordPage(IWebDriver driver) : base(driver) { }

        #region Methods

        #region Password

        //Passwoed field

        /// <summary>Get text from password field</summary>
        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        /// <summary>Get error message text</summary>
        public string GetPasswordErrorMessageText()
        {
            return PasswordErrorMessage.Text;
        }

        /// <summary>Set text into password field</summary>
        public void SetPasswordInput(string text)
        {
            PasswordInput.SendKeys(text);
        }

        /// <summary>Clear password field</summary>
        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        /// <summary>Click on password field</summary>
        public void ClickPasswordInput()
        {
            PasswordInput.Click();
        }

        /// <summary>Input password into password field</summary>
        public ChangePasswordPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        #endregion

        #region Password Confirm

        /// <summary>Get text from password confirm field</summary>
        public string GetPasswordConfirmInputText()
        {
            return PasswordConfirmInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        /// <summary>Get error message confirm text</summary>
        public string GetPasswordConfirmErrorMessageText()
        {
            return PasswordConfirmErrorMessage.Text;
        }

        /// <summary>Set text into password confirm field</summary>
        public void SetPasswordConfirmInput(string text)
        {
            PasswordConfirmInput.SendKeys(text);
        }

        /// <summary>Clear password confirm field</summary>
        public void ClearPasswordConfirmInput()
        {
            PasswordConfirmInput.Clear();
        }

        /// <summary>Click on password confirm field</summary>
        public void ClickPasswordConfirmInput()
        {
            PasswordConfirmInput.Click();
        }

        // Functional

        /// <summary>Input password into password confirm field</summary>
        public ChangePasswordPage SetPasswordConfirmInputClear(string text)
        {
            ClickPasswordConfirmInput();
            ClearPasswordConfirmInput();
            SetPasswordConfirmInput(text);
            return this;
        }

        #endregion

        // Buttons

        /// <summary>Click on confirm button</summary>
        public void ClickConfirmButton()
        {
            ContinueButton.Click();
        }

        //Functional

        /// <summary>
        /// Input password and confirm password
        /// </summary>
        /// <param name="newPassword">Password</param>
        /// <param name="newPasswordConfirm">Confirm password</param>
        private void SetNewPasswordData(string newPassword, string newPasswordConfirm)
        {
            SetPasswordInputClear(newPassword);
            SetPasswordConfirmInputClear(newPasswordConfirm);
            ClickConfirmButton();
        }

        /// <summary>
        /// Change user password using correct passwords
        /// </summary>
        /// <param name="newPassword">Password</param>
        /// <param name="newPasswordConfirm">Confirm password</param>
        /// <returns>MyAccount page</returns>
        public AccountPage SuccessChangePassword(string newPassword, string newPasswordConfirm)
        {
            SetNewPasswordData(newPassword, newPasswordConfirm);
            return new AccountPage(driver);
        }

        /// <summary>
        /// Try to change user password with incorrect passwords
        /// </summary>
        /// <param name="incorrectNewPassword">Incorrect password</param>
        /// <param name="incorrectNewPasswordConfirm">Incorrect password confirm</param>
        /// <returns>Change password page</returns>
        public ChangePasswordPage UnsuccessChangePassword(string incorrectNewPassword, string incorrectNewPasswordConfirm)
        {
            SetNewPasswordData(incorrectNewPassword, incorrectNewPasswordConfirm);
            return new ChangePasswordPage(driver);
        }
        #endregion
    }
}
