using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace OpenCartTests.Pages
{
    public class RepeatAccountPage:AccountPage
    {
        public IWebElement SuccessChangePasswordLabel
        { get { return driver.FindElement(By.CssSelector(".alert.alert-success")); } }

        public RepeatAccountPage(IWebDriver driver) : base(driver) { }

        public string GetSuccessChangePasswordLabelText()
        {
            return SuccessChangePasswordLabel.Text;
        }
    }
}
