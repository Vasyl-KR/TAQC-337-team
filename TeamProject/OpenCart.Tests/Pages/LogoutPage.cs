using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class LogoutPage:ATopComponent
    {
        private const string Logout_BTN_CSSSELECTOR = "a.btn.btn-primary";

        public IWebElement LogoutButton
        { get { return driver.FindElement(By.CssSelector(Logout_BTN_CSSSELECTOR)); } }

        public LogoutPage(IWebDriver driver) : base(driver) { }

        public void ClickLogoutButton()
        {
            LogoutButton.Click();
        }

        public HomePage SuccessLogout()
        {
            ClickLogoutButton();
            return new HomePage(driver);
        }
    }
}
