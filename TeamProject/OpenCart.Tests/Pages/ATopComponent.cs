﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    // TODO
    #region DropDownMenu's
    class CurrencyDropDownMenu
    {
        private IWebDriver driver;

        public IWebElement EUR
        { get { return driver.FindElement(By.Name("EUR")); } }

        public IWebElement GBP
        { get { return driver.FindElement(By.Name("GBP")); } }

        public IWebElement USD
        { get { return driver.FindElement(By.Name("USD")); } }

        public CurrencyDropDownMenu(IWebDriver driver)
        {
            this.driver = driver;
        }
    }

    class MyAccountDropDownMenu
    {
        private IWebDriver driver;

        public IWebElement Register
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/register')]")); } }

        public IWebElement Login
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/login')]")); } }

        public IWebElement MyAccount
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/account')]")); } }

        public IWebElement OrderHistory
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/aorder')]")); } }

        public IWebElement Transactions
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/transaction')]")); } }

        public IWebElement Downloads
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/download')]")); } }

        public IWebElement Logout
        { get { return driver.FindElement(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right']//a[contains(@href,'account/logout')]")); } }

        public MyAccountDropDownMenu(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
    #endregion
    #region abstract class AtopComponent
    public abstract class ATopComponent
    {
        #region Constants
        private const string Currency_BTN_CSSSELECTOR = ".btn-link.dropdown-toggle";
        private const string MyAccount_BTN_XPATH = "//a[@title='My Account']";
        private const string MainSearch_INPUT_CSSSELECTOR = ".form-control.input-lg";
        private const string MainSearch_BTN_CSSSELECTOR = ".btn.btn-default.btn-lg";
        private const string Laptops_BTN_XPATH = "//a[text() = 'Laptops & Notebooks']";
        private const string ShowAllLaptops_BTN_XPATH = "//a[text() = 'Show All Laptops & Notebooks']";

        public const string ARIA_EXPANDED_ATTRIBUTE = "aria-expanded";
        public const string VALUE_ATTRIBUTE = "value";
        #endregion

        private WebDriverWait wait;
        protected IWebDriver driver;

        protected IWebElement WaitForElementTextContains(IWebElement webElement, string expectedStr)
        {
            bool rez = wait.Until(driver => webElement.Text.Contains(expectedStr));
            if (rez)
            {
                return webElement;
            }
            else
            {
                return null;
            }
        }

        #region Waiter
        protected bool WaitForElementPresent(IWebElement webElement)
        {
            return wait.Until(driver => webElement.Displayed);

        }

        protected bool WaitForElementTextContainsEC(IWebElement webElement, string expectedStr)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, expectedStr));
        }

        

        public IWebElement Currency
        {
            get { return driver.FindElement(By.CssSelector(Currency_BTN_CSSSELECTOR)); }
        }
        #endregion
        
        #region Properties
        public IWebElement MyAccount
        {
            get { return driver.FindElement(By.XPath(MyAccount_BTN_XPATH)); }
        }

        // Dimon MainSearch
        public IWebElement MainSearchInput
        {
            get { return driver.FindElement(By.CssSelector(MainSearch_INPUT_CSSSELECTOR)); }
        }

        public IWebElement MainSearchButton
        {
            get { return driver.FindElement(By.CssSelector(MainSearch_BTN_CSSSELECTOR)); }
        }

        // Vasyl - Navigation Bar
        public IWebElement LaptopsDropdownMenu
        { get { return driver.FindElement(By.XPath(Laptops_BTN_XPATH)); } }
        public IWebElement ShowAllLaptops
        { get { return driver.FindElement(By.XPath(ShowAllLaptops_BTN_XPATH)); } }
        #endregion

        private CurrencyDropDownMenu currencyDropDownMenu;
        private MyAccountDropDownMenu myAccountDropDownMenu;
        #region Methods
        protected ATopComponent(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Method gets text from Currency DropDown menu
        /// </summary>
        /// <returns></returns>
        public string GetCurrencyText()
        {
            return Currency.Text;
        }

        /// <summary>
        /// Method click on Currency DropDown menu
        /// </summary>
        public void ClickCurrencyDropDownMenu()
        {
            Currency.Click();
        }

        /// <summary>
        /// Method open Currency DropDown menu if closed
        /// </summary>
        public void OpenCurrencyDropDownMenu()
        {
            if (Currency.GetAttribute(ARIA_EXPANDED_ATTRIBUTE).Equals("false"))
            {
                Currency.Click();
            }
            currencyDropDownMenu = new CurrencyDropDownMenu(driver);
        }

        /// <summary>
        /// Method gets MyAccount text from MyAccount DropDown menu
        /// </summary>
        /// <returns></returns>
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        /// <summary>
        /// Method click on MyAccount DropDown menu
        /// </summary>
        public void ClickMyAccountDropDownMenu()
        {
            MyAccount.Click();
        }

        /// <summary>
        /// Method open MyAccount DropDown menu if closed
        /// </summary>
        public void OpenMyAccountDropDownMenu()
        {
            if (MyAccount.GetAttribute(ARIA_EXPANDED_ATTRIBUTE) != "true")
            {
                MyAccount.Click();
            }
            myAccountDropDownMenu = new MyAccountDropDownMenu(driver);
        }

        /// <summary>
        /// Method Get Login button from MyAccount DropDown menu
        /// </summary>
        /// <returns></returns>
        public IWebElement GetLogin()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Login;
        }

        /// <summary>
        /// Method click on Login in MyAccount DropDown menu
        /// </summary>
        public void ClickLogin()
        {
            GetLogin().Click();
        }

        /// <summary>
        /// Method goes to Login
        /// </summary>
        /// <returns></returns>
        public LoginPage GoToLoginPage()
        {
            GetLogin();
            ClickLogin();
            return new LoginPage(driver);
        }

        /// <summary>
        /// Method Get Register button from MyAccount DropDown menu
        /// </summary>
        /// <returns></returns>
        public IWebElement GetRegister()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Register;
        }

        /// <summary>
        /// Method click on Register in MyAccount DropDown menu
        /// </summary>
        public void ClickRegiser()
        {
            GetRegister().Click();
        }

        /// <summary>
        /// Method Get MyAccount button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public IWebElement GetMyAccount()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.MyAccount;
        }

        public void ClickMyAccount()
        {
            GetMyAccount().Click();
        }

        /// <summary>
        /// Method Get Order History button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public IWebElement GetOrderHistory()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.OrderHistory;
        }

        public void ClickOrderHistory()
        {
            GetOrderHistory().Click();
        }

        /// <summary>
        /// Method Get Transactions button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public IWebElement GetTransactions()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Transactions;
        }

        public void ClickTransactions()
        {
            GetTransactions().Click();
        }

        /// <summary>
        /// Method Get Downloads button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public IWebElement GetDownloads()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Downloads;
        }

        public void ClickDownloads()
        {
            GetDownloads().Click();
        }

        /// <summary>
        /// Method Get Logout button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public IWebElement GetLogout()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Logout;
        }

        public void ClickLogout()
        {
            GetLogout().Click();
        }

        /// <summary>
        /// Method Get Logout button from MyAccount DropDown menu (Logined)
        /// </summary>
        /// <returns></returns>
        public LogoutPage GoToLogoutPage()
        {
            GetLogout();
            ClickLogout();
            return new LogoutPage(driver);
        }

        /// <summary>
        /// Method sets search input field with
        /// </summary>
        /// <param name="searchtext">text to search</param>
        public void SetMainSearch(string searchtext)
        {
            MainSearchInput.SendKeys(searchtext);
        }

        public void ClickMainSearch()
        {
            MainSearchButton.Click();
        }

        // Vasyl - Navigation Bar
        public void ClickLaptopsDropdownMenu()
        {
            LaptopsDropdownMenu.Click();
        }

        public void ClickShowAllLaptops()
        {
            ShowAllLaptops.Click();
        }

        public LaptopsAndNotebooksPage GoToLaptopPage()
        {
            ClickLaptopsDropdownMenu();
            ClickShowAllLaptops();
            return new LaptopsAndNotebooksPage(driver);
        }
        #endregion
    }
    #endregion
}
