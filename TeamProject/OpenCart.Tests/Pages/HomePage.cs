using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OpenCartTests.Pages
{
    public class HomePage:ATopComponent
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public LoginPage GoToLoginPage()
        {
            ClickLogin();
            return new LoginPage(driver);
        }
    }
}
