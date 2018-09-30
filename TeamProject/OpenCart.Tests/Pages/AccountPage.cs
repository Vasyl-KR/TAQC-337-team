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

        public IWebElement ModifyAddressBook
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/address')]")); } }

        public IWebElement ModifyWishList
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/wishlist')]")); } }

        public IWebElement OrderHistory
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/order')]")); } }

        public IWebElement Downloads
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/download')]")); } }

        public IWebElement RewardPoints
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/reward')]")); } }

        public IWebElement ReturnRequests
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/return')]")); } }

        public IWebElement Transactions
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/transaction')]")); } }

        public IWebElement RecurringPayments
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/recurring')]")); } }

        public IWebElement SubUnsubToNewsletter
        { get { return driver.FindElement(By.XPath("//div[@id='content']//ul[@class='list-unstyled']//a[contains(@href,'account/newsletter')]")); } }



        public AccountPage(IWebDriver driver) : base(driver) { }
    }
}
