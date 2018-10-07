using OpenQA.Selenium;

namespace OpenCartTests.Pages
{
    public class PagesList
    {
        #region Fields

        private IWebDriver driver;

        #endregion

        #region Proporties

        public AccountPage AccountPage
        {
            get { return new AccountPage(driver); }
        }

        public AddressPage AddressPage
        {
            get { return new AddressPage(driver); }
        }

        public ChangePasswordPage ChangePasswordPage
        {
            get { return new ChangePasswordPage(driver); }
        }

        public ConfirmationRegisterPage ConfirmationRegisterPage
        {
            get { return new ConfirmationRegisterPage(driver); }
        }

        public EditAccountInformationPage EditAccountInformationPage
        {
            get { return new EditAccountInformationPage(driver); }
        }

        public EditAddressPage EditAddressPage
        {
            get { return new EditAddressPage(driver); }
        }

        public HomePage HomePage
        {
            get { return new HomePage(driver); }
        }

        public LaptopsAndNotebooksPage LaptopsAndNotebooksPage
        {
            get { return new LaptopsAndNotebooksPage(driver); }
        }

        public LoginPage LoginPage
        {
            get { return new LoginPage(driver); }
        }

        public LogoutPage LogoutPage
        {
            get { return new LogoutPage(driver); }
        }

        public ProductComparisonPage ProductComparisonPage
        {
            get { return new ProductComparisonPage(driver); }
        }

        public RegisterPage RegisterPage
        {
            get { return new RegisterPage(driver); }
        }

        public SearchPage SearchPage
        {
            get { return new SearchPage(driver); }
        }

        public WishlistPage WishlistPage
        {
            get { return new WishlistPage(driver); }
        }

        #endregion

        #region Constructors

        public PagesList(IWebDriver driver)
        {
            this.driver = driver;
        }

        #endregion
    }
}
