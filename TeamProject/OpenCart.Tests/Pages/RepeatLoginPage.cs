using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class RepeatLoginPage : LoginPage
    {

        public IWebElement InvalidLoginLabel
        { get { return driver.FindElement(By.CssSelector(".alert.alert-danger")); } }

        public RepeatLoginPage(IWebDriver driver) : base(driver) { }

        public string GetInvalidLoginLabelText()
        {
            return InvalidLoginLabel.Text;
        }
    }
}
