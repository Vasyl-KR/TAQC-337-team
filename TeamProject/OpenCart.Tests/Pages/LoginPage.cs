using OpenCartTests.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class LoginPage : ATopComponent
    {
        #region Constants
        private const string Login_INPUT_ID = "input-email";
        private const string Password_INPUT_ID = "input-password";
        private const string Signin_BTN_CSSSELECTOR = "input.btn.btn-primary";
        private const string Register_BTN_CSSSELECTOR = "a.btn.btn-primary";
        private const string ForgottenPass_BTN_XPATH = "//div[@class='well']//a[contains(@href,'account/forgotten')]";
        #endregion

        public IWebElement LoginInput
        { get { return driver.FindElement(By.Id(Login_INPUT_ID)); } }

        public IWebElement PasswordInput
        { get { return driver.FindElement(By.Id(Password_INPUT_ID)); } }

        public IWebElement SigninButton
        { get { return driver.FindElement(By.CssSelector(Signin_BTN_CSSSELECTOR)); } }

        public IWebElement RegisterButton
        { get { return driver.FindElement(By.CssSelector(Register_BTN_CSSSELECTOR)); } }

        public IWebElement ForgottenPassButton
        { get { return driver.FindElement(By.XPath(ForgottenPass_BTN_XPATH)); } }

        public LoginPage(IWebDriver driver) : base(driver) { }

        private void VerifyWebElements()
        {
            IWebElement temp = LoginInput;
            temp = PasswordInput;
            temp = SigninButton;
            temp = RegisterButton;
            temp = ForgottenPassButton;
        }

        public string GetLoginInputText()
        {
            return LoginInput.GetAttribute(VALUE_ATTRIBUTE);
        }

        public void SetLoginInput(string text)
        {
            LoginInput.SendKeys(text);
        }

        public void ClearLoginInput()
        {
            LoginInput.Clear();
        }

        public void ClickLoginInput()
        {
            LoginInput.Click();
        }

        // Functional

        public LoginPage SetLoginInputClear(string text)
        {
            ClickLoginInput();
            ClearLoginInput();
            SetLoginInput(text);
            return this;
        }

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

        public LoginPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        public void ClickSigninButton()
        {
            SigninButton.Click();
        }

        public void ClickForgottenPassButton()
        {
            ForgottenPassButton.Click();
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }

        private void SetLoginData(string login, string password)
        {
            SetLoginInputClear(login);
            SetPasswordInputClear(password);
            ClickSigninButton();
        }

        public RepeatLoginPage UnsuccessfulLogin(string invalidLogin, string invalidPassword)
        {
            SetLoginData(invalidLogin, invalidPassword);
            return new RepeatLoginPage(driver);
        }


        public AccountPage SuccessRegistratorLogin(string registratorLogin, string registratorPassword)
        {
            SetLoginData(registratorLogin, registratorPassword);
            return new AccountPage(driver);
        }
    }
}
