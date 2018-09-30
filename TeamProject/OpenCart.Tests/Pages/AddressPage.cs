using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    class AddressPage : ATopComponent
    {
        private const string Back_BTN_CSSSELECTOR = ".btn.btn-default";
        private const string NewAddress_BTN_CSSSELECTOR = ".btn.btn-primary";
        private const string Addresses_TABLE_TAGNAME = "tr";
        private const string Edit_BTN_XPATH = "//tr[{0}]/td/a[text() = 'Edit']";
        private const string Delete_BTN_XPATH = "//tr[{0}]/td/a[text() = 'Delete']";


        public IWebElement BtnBack { get { return driver.FindElement(By.CssSelector(Back_BTN_CSSSELECTOR)); } }
        public IWebElement BtnNewAddress{ get { return driver.FindElement(By.CssSelector(NewAddress_BTN_CSSSELECTOR)); } }
        public List<IWebElement> ListAddresses { get { return new List<IWebElement>( driver.FindElements(By.TagName(Addresses_TABLE_TAGNAME))); } }

        public AddressPage(IWebDriver driver) : base(driver)
        {
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

        public string GetMessageAddressDeleted()
        {
            return driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;
        }

        public string GetMessageAddressEdited()
        {
            return driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;
        }
    }
}
