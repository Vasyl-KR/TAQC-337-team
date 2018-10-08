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
        #region Constants
        private const string AccountInformation_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/edit')]";
        private const string ChangePassword_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/password')]";
        private const string AddressBookEntries_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/address')]";
        private const string WishList_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/wishlist')]";
        private const string OrderHistory_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/order')]";
        private const string Downloads_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/download')]";
        private const string RewardPoints_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/reward')]";
        private const string ReturnRequests_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/return')]";
        private const string Transactions_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/transaction')]";
        private const string RecurringPayments_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/recurring')]";
        private const string SubUnsubToNewsletter_BTN_XPATH = "//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/newsletter')]";
        private const string SuccessAlert_Label_CSSSELECTOR = ".alert.alert-success";
        private const string MyAccount_Label = "//h2[contains(text(),'My Account')]";

        #endregion

        #region Properties

        public IWebElement EditAccountInformation
        { get { return driver.FindElement(By.XPath(AccountInformation_BTN_XPATH)); } }

        public IWebElement ChangePassword
        { get { return driver.FindElement(By.XPath(ChangePassword_BTN_XPATH)); } }

        public IWebElement ModifyAddressBookEntries
        { get { return driver.FindElement(By.XPath(AddressBookEntries_BTN_XPATH)); } }

        public IWebElement ModifyWishList
        { get { return driver.FindElement(By.XPath(WishList_BTN_XPATH)); } }

        public IWebElement ViewOrderHistory
        { get { return driver.FindElement(By.XPath(OrderHistory_BTN_XPATH)); } }

        public IWebElement ViewDownloads
        { get { return driver.FindElement(By.XPath(Downloads_BTN_XPATH)); } }

        public IWebElement RewardPoints
        { get { return driver.FindElement(By.XPath(RewardPoints_BTN_XPATH)); } }

        public IWebElement ReturnRequests
        { get { return driver.FindElement(By.XPath(ReturnRequests_BTN_XPATH)); } }

        public IWebElement ViewTransactions
        { get { return driver.FindElement(By.XPath(Transactions_BTN_XPATH)); } }

        public IWebElement RecurringPayments
        { get { return driver.FindElement(By.XPath(RecurringPayments_BTN_XPATH)); } }

        public IWebElement SubUnsubToNewsletter
        { get { return driver.FindElement(By.XPath(SubUnsubToNewsletter_BTN_XPATH)); } }

        public IWebElement AccountLabel
        { get { return driver.FindElement(By.XPath(MyAccount_Label)); } }

        public IWebElement SuccessLabel
        { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }

        #endregion

        public AccountPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements();
        }

        public void VerifyWebElements()
        {
            IWebElement element = EditAccountInformation;
            element = ChangePassword;
            element = ModifyAddressBookEntries;
        }

        #region Methods

        /// <summary>Get text from alert message</summary>
        public string GetSuccessChangePasswordMessageText()
        {
            return SuccessLabel.Text;
        }

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

        public string GetSuccessChangePasswordMessageText()
        {
            return SuccessLabel.Text;
        }

        public string GetAccountLabelText()
        {
            return AccountLabel.Text;
        }
        #endregion
    }
}
