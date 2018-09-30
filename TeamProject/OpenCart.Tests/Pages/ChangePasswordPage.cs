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
        public IWebElement PasswordInput
        { get { return driver.FindElement(By.Id("input-password")); } }

        public IWebElement PasswordConfirmInput
        { get { return driver.FindElement(By.Id("input-confirm")); } }

        public IWebElement ConfirmButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }

        public ChangePasswordPage(IWebDriver driver) : base(driver) { }


        public string GetPasswordInputText()
        {
            return PasswordInput.GetAttribute(VALUE_ATTRIBUTE);
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
            ConfirmButton.Click();
        }

        private void SetNewPasswordData(string newPassword)
        {            
            SetPasswordInputClear(newPassword);
            SetPasswordConfirmInputClear(newPassword);
            ClickConfirmButton();
        }

        public AccountPage SuccessChangePassword(string newPassword)
        {
            SetNewPasswordData(newPassword);
            return new AccountPage(driver);
        }

        // TODO
        //public AccountPage UnsuccessChangePassword(string registratorLogin, string registratorPassword)
        //{
        //    SetLoginData(registratorLogin, registratorPassword);
        //    return new AccountPage(driver);
        //}

    }
}
