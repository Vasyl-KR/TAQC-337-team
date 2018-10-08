using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class AddressPage : ATopComponent
    {
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-default")]
        private IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-success")]
        private IWebElement UnsuccessfulMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.alert.alert-warning")]
        private IWebElement SuccessfulMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        private IWebElement BtnNewAddress { get; set; }

        [FindsBy(How = How.TagName, Using = "tr")]
        private IList<IWebElement> ListAddresses { get; set; }

        public AddressPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement element = BtnBack;
            element = BtnNewAddress;
            var e = ListAddresses;
        }

        public EditAddressPage ClickNewAddressButton()
        {
            BtnNewAddress.Click();
            return new EditAddressPage(driver);
        }

        public EditAddressPage EditRaw(int index)
        {
            ListAddresses.ElementAt(index).FindElement(By.XPath("//tr[" + index + "]/td/a[text() = 'Edit']")).Click();
            return new EditAddressPage(driver);
        }

        public AddressPage DeleteRaw(int index)
        {
            ListAddresses.ElementAt(index).FindElement(By.XPath("//tr[" + index + "]/td/a[text() = 'Delete']")).Click();
            return this;
        }

        /// <summary>
        /// Get address information about Person using firstname and lastname
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public string GetAddressIfno(string firstname, string lastname)
        {
            return ListAddresses.ElementAt(0).FindElement(By.XPath("//td[contains(text(),'" + firstname + " " + lastname + "')]")).Text;
        }

        /// <summary>
        /// Get address information by raw number
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetAddressIfno(int index)
        {
            return ListAddresses.ElementAt(index).FindElement(By.XPath("//td[contains(@class, 'text-left')]")).Text;
        }

        public IWebElement GetRaw(int index)
        {
            try
            {
                return ListAddresses.ElementAt(index);
            }
            catch (Exception e)
            {
                return ListAddresses.ElementAt(0);
            }
        }

        public string GetSuccessfulMessage()
        {
            return UnsuccessfulMessage.Text;
        }

        public string GetUnsuccessfulMessage()
        {
            return SuccessfulMessage.Text;
        }

        public int ListAddressesLenght()
        {
            return ListAddresses.Count();
        }

    }
}
