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
        public ChangePasswordPage(IWebDriver driver) : base(driver) { }


        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public string GetPasswordErrorMessageText()
        {
            return PasswordErrorMessage.Text;
        }

        public void SetPasswordInput(string text)
        {
            PasswordInput.SendKeys(text);
        }

        public void ClearPasswordInput()
        {
            PasswordInput.Clear();
        }

        public void ClickPasswordInput()
        {
            PasswordInput.Click();
        }

        // Functional

        public ChangePasswordPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        public string GetPasswordConfirmInputText()
        {
            return PasswordConfirmInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public string GetPasswordConfirmErrorMessageText()
        {
            return PasswordConfirmErrorMessage.Text;
        }
        public void SetPasswordConfirmInput(string text)
        {
            PasswordConfirmInput.SendKeys(text);
        }

        public void ClearPasswordConfirmInput()
        {
            PasswordConfirmInput.Clear();
        }

        public void ClickPasswordConfirmInput()
        {
            PasswordConfirmInput.Click();
        }

        // Functional

        public ChangePasswordPage SetPasswordConfirmInputClear(string text)
        {
            ClickPasswordConfirmInput();
            ClearPasswordConfirmInput();
            SetPasswordConfirmInput(text);
            return this;
        }

        public void ClickConfirmButton()
        {
            ContinueButton.Click();
        }

        private void SetNewPasswordData(string newPassword, string newPasswordConfirm)
        {            
            SetPasswordInputClear(newPassword);
            SetPasswordConfirmInputClear(newPasswordConfirm);
            ClickConfirmButton();
        }

        public AccountPage SuccessChangePassword(string newPassword, string newPasswordConfirm)
        {
            SetNewPasswordData(newPassword, newPasswordConfirm);
            return new AccountPage(driver);
        }

        
        public ChangePasswordPage UnsuccessChangePassword(string incorrectNewPassword, string incorrectNewPasswordConfirm)
        {
            SetNewPasswordData(incorrectNewPassword, incorrectNewPasswordConfirm);
            return new ChangePasswordPage(driver);
        }

    }
}
