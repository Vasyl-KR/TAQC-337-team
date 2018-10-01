using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class AccountPage : ATopComponent
    {
        public IWebElement EditAccountInformation
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/edit')]")); } }

        public IWebElement ChangePassword
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/password')]")); } }

        public IWebElement ModifyAddressBookEntries
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/address')]")); } }

        public IWebElement ModifyWishList
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/wishlist')]")); } }

        public IWebElement ViewOrderHistory
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/order')]")); } }

        public IWebElement ViewDownloads
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/download')]")); } }

        public IWebElement RewardPoints
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/reward')]")); } }

        public IWebElement ReturnRequests
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/return')]")); } }

        public IWebElement ViewTransactions
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/transaction')]")); } }

        public IWebElement RecurringPayments
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/recurring')]")); } }

        public IWebElement SubUnsubToNewsletter
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/newsletter')]")); } }


        public AccountPage(IWebDriver driver) : base(driver) { }

        public IWebElement GetEditAccountInformation()
        {
            return EditAccountInformation;
        }

        public void ClickEditAccountInformation()
        {
            GetEditAccountInformation().Click();
        }

        public IWebElement GetChangePassword()
        {
            return ChangePassword;
        }

        public void ClickChangePassword()
        {
            GetChangePassword().Click();
        }

        public ChangePasswordPage GoToChangePassword()
        {
            GetChangePassword();
            ClickChangePassword();
            return new ChangePasswordPage(driver);
        }

        public IWebElement GetModifyAddressBookEntries()
        {
            return ModifyAddressBookEntries;
        }

        public void ClickModifyAddressBookEntries()
        {
            GetModifyAddressBookEntries().Click();
        }

        public IWebElement GetModifyWishList()
        {
            return ModifyWishList;
        }

        public void ClickModifyWishList()
        {
            GetModifyWishList().Click();
        }

        public IWebElement GetViewOrderHistory()
        {
            return ViewOrderHistory;
        }

        public void ClickViewOrderHistory()
        {
            GetViewOrderHistory().Click();
        }

        public IWebElement GetViewDownloads()
        {
            return ViewDownloads;
        }

        public void ClickViewDownloads()
        {
            GetViewDownloads().Click();
        }

        public IWebElement GetRewardPoints()
        {
            return RewardPoints;
        }

        public void ClickRewardPoints()
        {
            GetRewardPoints().Click();
        }

        public IWebElement GetReturnRequests()
        {
            return ReturnRequests;
        }

        public void ClickReturnRequests()
        {
            GetReturnRequests().Click();
        }

        public IWebElement GetViewTransactions()
        {
            return ViewTransactions;
        }

        public void ClickViewTransactions()
        {
            GetViewTransactions().Click();
        }

        public IWebElement GetRecurringPayments()
        {
            return RecurringPayments;
        }

        public void ClickRecurringPayments()
        {
            GetRecurringPayments().Click();
        }

        public IWebElement GetSubUnsubToNewsletter()
        {
            return SubUnsubToNewsletter;
        }

        public void ClickSubUnsubToNewsletter()
        {
            GetSubUnsubToNewsletter().Click();
        }
    }
}
