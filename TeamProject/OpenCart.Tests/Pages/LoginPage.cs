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
        public IWebElement LoginInput
        { get { return driver.FindElement(By.Id("input-email")); } }

        public IWebElement PasswordInput
        { get { return driver.FindElement(By.Id("input-password")); } }

        public IWebElement SigninButton
        { get { return driver.FindElement(By.CssSelector("input.btn.btn-primary")); } }

        public IWebElement RegisterButton
        { get { return driver.FindElement(By.CssSelector("a.btn.btn-primary")); } }

        public IWebElement ForgottenPassButton
        { get { return driver.FindElement(By.XPath("//div[@class='well']//a[contains(@href,'account/forgotten')]")); } }

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

        public void SetLoginInputClear(string text)
        {
            ClickLoginInput();
            ClearLoginInput();
            SetLoginInput(text);
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

        public void SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
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
