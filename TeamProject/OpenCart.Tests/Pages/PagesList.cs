using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartTests.Pages
{
   public class PagesList
    {
        #region Fields

      //  private WebDriverWait wait;
        private IWebDriver driver;

        #endregion

        #region Proporties

        public AccountPage AccountPage => new AccountPage(driver);

        public AddressPage AddressPage => new AddressPage(driver);

        public ChangePasswordPage ChangePasswordPage => new ChangePasswordPage(driver);

        public ConfirmationRegisterPage ConfirmationRegisterPage => new ConfirmationRegisterPage(driver);

        public EditAccountInformationPage EditAccountInformationPage => new EditAccountInformationPage(driver);

        public EditAddressPage EditAddressPage => new EditAddressPage(driver);

        public HomePage HomePage => new HomePage(driver);

        public LaptopsAndNotebooksPage LaptopsAndNotebooksPage => new LaptopsAndNotebooksPage(driver);

        public LoginPage LoginPage => new LoginPage(driver);

        public LogoutPage LogoutPage => new LogoutPage(driver);

        public ProductComparisonPage ProductComparisonPage => new ProductComparisonPage(driver);

        public RegisterPage RegisterPage => new RegisterPage(driver);

        public SearchPage SearchPage => new SearchPage(driver);

        public WishlistPage WishlistPage => new WishlistPage(driver);

        #endregion

        #region Constructors

        public PagesList (IWebDriver driver)
        {
           // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            this.driver = driver;          
        }
        #endregion

        //public IWebElement WaitForElementTextContains(IWebElement webElement,string expectedStr)
        //{
        //    bool rez=wait.Until(driver => webElement.Text.Contains(expectedStr));
        //    if (rez)
        //    {
        //        return webElement;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public bool WaitForElementPresent(IWebElement webElement)
        //{
        //    return wait.Until(driver => webElement.Displayed);
            
        //}

        //public bool WaitForElementTextContainsEC(IWebElement webElement, string expectedStr)
        //{
        //    return wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, expectedStr));
        //}


    }
}
