using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    // TODO
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

    public abstract class ATopComponent
    {
        protected IWebDriver driver;

        public IWebElement Currency
        {
            get { return driver.FindElement(By.CssSelector(".btn-link.dropdown-toggle")); }
        }

        public IWebElement MyAccount
        {
            get { return driver.FindElement(By.XPath("//a[@title='My Account']")); }
        }


        private CurrencyDropDownMenu currencyDropDownMenu;
        private MyAccountDropDownMenu myAccountDropDownMenu;

        protected ATopComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetCurrencyText()
        {
            return Currency.Text;
        }

        public void ClickCurrencyDropDownMenu()
        {
            Currency.Click();
        }

        public void OpenCurrencyDropDownMenu()
        {
            if (Currency.GetAttribute("aria-expanded").Equals("false"))
            {
                Currency.Click();
            }
            currencyDropDownMenu = new CurrencyDropDownMenu(driver);           
        }

        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccountDropDownMenu()
        {
            MyAccount.Click();
        }

        public void OpenMyAccountDropDownMenu()
        {
           // Console.WriteLine(MyAccount.GetAttribute("aria-expanded"));
            if (MyAccount.GetAttribute("aria-expanded") != "true")
            {
                MyAccount.Click();
            }
            myAccountDropDownMenu = new MyAccountDropDownMenu(driver);
        }

        public IWebElement GetLogin()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Login;
        }

        public void ClickLogin()
        {
            GetLogin().Click(); 
        }

        public IWebElement GetRegiser()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Register;
        }

        public void ClickRegiser()
        {
            GetRegiser().Click();
        }

        public IWebElement GetMyAccount()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.MyAccount;
        }

        public void ClickMyAccount()
        {
            GetMyAccount().Click();
        }

        public IWebElement GetOrderHistory()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.OrderHistory;
        }

        public void ClickOrderHistory()
        {
            GetOrderHistory().Click();
        }

        public IWebElement GetTransactions()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Transactions;
        }

        public void ClickTransactions()
        {
            GetTransactions().Click();
        }

        public IWebElement GetDownloads()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Downloads;
        }

        public void ClickDownloads()
        {
            GetDownloads().Click();
        }

        public IWebElement GetLogout()
        {
            OpenMyAccountDropDownMenu();
            return myAccountDropDownMenu.Logout;
        }
        public void ClickLogout()
        {
            GetLogout().Click();
        }
    }
}
