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
        private const string Back_BTN_CSSSELECTOR = ".btn.btn-default";
        private const string NewAddress_BTN_CSSSELECTOR = ".btn.btn-primary";
        private const string Addresses_TABLE_TAGNAME = "tr";
        private const string Edit_BTN_XPATH = "//tr[{0}]/td/a[text() = 'Edit']";
        private const string Delete_BTN_XPATH = "//tr[{0}]/td/a[text() = 'Delete']";

        [FindsBy(How = How.CssSelector, Using = Back_BTN_CSSSELECTOR)]
        public IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = NewAddress_BTN_CSSSELECTOR)]
        public IWebElement BtnNewAddress { get; set; }

        [FindsBy(How = How.TagName, Using = Addresses_TABLE_TAGNAME)]
        public IList<IWebElement> ListAddresses { get; set; }

        public AddressPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver,this);
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
            ListAddresses.ElementAt(index).FindElement(By.XPath("//tr[" + index +"]/td/a[text() = 'Delete']")).Click();
            return this;
        }

        public string GetMessageBox()
        {
            return driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;
        }

    }
}
