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
        private const string InvalidLogin_LABEL_CSSSELECTOR = ".alert.alert-danger";
        private const string NewCustomer_LABEL_XPATH = "//h2[contains(text(),'New Customer')]";

        #endregion

        #region Properties


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

        public IWebElement InvalidLoginLabel
        { get { return driver.FindElement(By.CssSelector(InvalidLogin_LABEL_CSSSELECTOR)); } }

        public IWebElement NewCustomerLabel
        { get { return driver.FindElement(By.XPath(NewCustomer_LABEL_XPATH)); } }

        public LoginPage(IWebDriver driver) : base(driver) { }
        #endregion
        private void VerifyWebElements()
        {
            IWebElement temp = LoginInput;
            temp = PasswordInput;
            temp = SigninButton;
            temp = RegisterButton;
            temp = ForgottenPassButton;
        }

        //Lables

        public string GetInvalidLoginLabelText()
        {
            return InvalidLoginLabel.Text;
        }

        //Login field

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

        public LoginPage SetLoginInputClear(string text)
        {
            ClickLoginInput();
            ClearLoginInput();
            SetLoginInput(text);
            return this;
        }

        //Password field

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

        public LoginPage SetPasswordInputClear(string text)
        {
            ClickPasswordInput();
            ClearPasswordInput();
            SetPasswordInput(text);
            return this;
        }

        // Buttons
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



        // Functional

        public string GetNewCustomerLabel()
        {
            return NewCustomerLabel.Text;
        }

        private void SetLoginData(string login, string password)
        {
            SetLoginInputClear(login);
            SetPasswordInputClear(password);
            ClickSigninButton();
        }

        /// <summary>
        /// Try to login with invalid credentials
        /// </summary>
        /// <param name="invalidEmail">Email</param>
        /// <param name="invalidPassword">Password</param>
        /// <returns>Login page</returns>
        public LoginPage UnsuccessfulLogin(string invalidEmail, string invalidPassword)
        {
            SetLoginData(invalidEmail, invalidPassword);
            return new LoginPage(driver);
        }

        /// <summary>
        /// Login in open cart with valid credentials 
        /// </summary>
        /// <param name="registratorEmail">Email</param>
        /// <param name="registratorPassword">Password</param>
        /// <returns>My Account page</returns>
        public AccountPage SuccessRegistratorLogin(string registratorEmail, string registratorPassword)
        {
            SetLoginData(registratorEmail, registratorPassword);
            return new AccountPage(driver);
        }

    }
}
