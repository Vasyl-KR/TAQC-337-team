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
        #region Constants

        private const string Logout_BTN_CSSSELECTOR = "a.btn.btn-primary";

        #endregion

        #region Properties

        public IWebElement LogoutButton
        { get { return driver.FindElement(By.CssSelector(Logout_BTN_CSSSELECTOR)); } }

        #endregion

        public LogoutPage(IWebDriver driver) : base(driver) { }

        #region Methods

        //Buttons

        public void ClickLogoutButton()
        {
            LogoutButton.Click();
        }

        //Functional

        public HomePage SuccessLogout()
        {
            ClickLogoutButton();
            return new HomePage(driver);
        }

        #endregion
    }
}
