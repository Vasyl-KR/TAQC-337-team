using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
   public class Pages
    {
        private readonly IWebDriver driver;

        public Pages (IWebDriver driver)
        {
            this.driver = driver;
            PageInitializator(driver);
        }

        private void PageInitializator(IWebDriver driver)
        {
            new AccountPage(driver);
            new AddressPage(driver);
            new ChangePasswordPage(driver);
            new EditAccountInformationPage(driver);
            new EditAddressPage(driver);
            new HomePage(driver);
            new LaptopsAndNotebooksPage(driver);
            new LoginPage(driver);
            new LogoutPage(driver);
            new ProductComparisonPage(driver);
            new RegisterPage(driver);
            new RepeatLoginPage(driver);
            new SearchPage(driver);
            new WishlistPage(driver);
        }
   
    }
}
