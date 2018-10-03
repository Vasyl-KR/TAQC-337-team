using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
   public class Pages
    {
        #region Fields

        private readonly IWebDriver driver;
        private AccountPage accountPage;
        private AddressPage addressPage;
        private ChangePasswordPage changePasswordPage;
        private EditAccountInformationPage editAccountInformationPage;
        private EditAddressPage editAddressPage;
        private HomePage homePage;
        private LaptopsAndNotebooksPage laptopsAndNotebooksPage;
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        private ProductComparisonPage productComparisonPage;
        private RegisterPage registerPage;
        private RepeatLoginPage repeatLoginPage;
        private SearchPage searchPage;
        private WishlistPage wishlistPage;
        private RepeatAccountPage repeatAccountPage;


        private WebDriverWait wait;

        #endregion

        #region Proporties

        public AccountPage AccountPage
        {
            get { return accountPage ?? new AccountPage(driver); }
        }
        
        public AddressPage AddressPage
        {
            get { return addressPage ?? new AddressPage(driver); }
        }

        public ChangePasswordPage ChangePasswordPage
        {
            get { return changePasswordPage ?? new ChangePasswordPage(driver); }
        }

        public ConfirmationRegisterPage ConfirmationRegisterPage
        {
            get { return new ConfirmationRegisterPage(driver); }
        }

        public EditAccountInformationPage EditAccountInformationPage
        {
            get { return editAccountInformationPage ?? new EditAccountInformationPage(driver); }
        }

        public EditAddressPage EditAddressPage
        {
            get { return editAddressPage ?? new EditAddressPage(driver); }
        }
        public HomePage HomePage
        {
            get { return homePage ?? new HomePage(driver); }
        }

        public LaptopsAndNotebooksPage LaptopsAndNotebooksPage
        {
            get { return laptopsAndNotebooksPage ?? new LaptopsAndNotebooksPage(driver); }
        }

        public LoginPage LoginPage
        {
            get { return loginPage ?? new LoginPage(driver); }
        }

        public LogoutPage LogoutPage
        {
            get { return logoutPage ?? new LogoutPage(driver); }
        }

        public ProductComparisonPage ProductComparisonPage
        {
            get { return productComparisonPage ?? new ProductComparisonPage(driver); }
        }

        public RegisterPage RegisterPage
        {
            get { return registerPage ?? new RegisterPage(driver); }
        }

        public RepeatLoginPage RepeatLoginPage
        {
            get { return repeatLoginPage ?? new RepeatLoginPage(driver); }
        }
        public RepeatAccountPage RepeatAccountPage
        {
            get { return repeatAccountPage ?? new RepeatAccountPage(driver); }
        }

        public SearchPage SearchPage
        {
            get { return searchPage ?? new SearchPage(driver); }
        }

        public WishlistPage WishlistPage
        {
            get { return wishlistPage ?? new WishlistPage(driver); }
        }

        #endregion

        #region Constructors

        public Pages (IWebDriver driver)
        {
            this.driver = driver;
            // PageInitializator();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        #endregion
        //add all new pages
        private void PageInitializator()
        {
            accountPage = new AccountPage(driver);
            addressPage = new AddressPage(driver);
            changePasswordPage = new ChangePasswordPage(driver);
            editAccountInformationPage = new EditAccountInformationPage(driver);
            editAddressPage = new EditAddressPage(driver);
            homePage = new HomePage(driver);
            laptopsAndNotebooksPage = new LaptopsAndNotebooksPage(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            productComparisonPage = new ProductComparisonPage(driver);
            registerPage = new RegisterPage(driver);
            repeatLoginPage = new RepeatLoginPage(driver);
            repeatAccountPage = new RepeatAccountPage(driver);
            searchPage = new SearchPage(driver);
            wishlistPage = new WishlistPage(driver);
        }

        public IWebElement WaitForElementTextContains(IWebElement webElement,string expectedStr)
        {
            bool rez=wait.Until(driver => webElement.Text.Contains(expectedStr));
            if (rez)
            {
                return webElement;
            }
            else
            {
                return null;
            }
        }

        public bool WaitForElementPresent(IWebElement webElement)
        {
            return wait.Until(driver => webElement.Displayed);
            
        }

        public bool WaitForElementTextContainsEC(IWebElement webElement, string expectedStr)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, expectedStr));
        }


    }
}
