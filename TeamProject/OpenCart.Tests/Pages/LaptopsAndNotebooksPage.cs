using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

#pragma warning disable
namespace OpenCartTests.Pages
{
    public class LaptopsAndNotebooksPage : ATopComponent
    {
        // Label locators
        private const string LAPTOPS_AND_NOTEBOOKS_LABEL = "h2"; // cssSelector
        private const string SUCCESS_ALERT_MESSAGE = "//div[@class = 'alert alert-success']"; // XPath

        // Link locators
        private const string COMPARABLE_PRODUCT_LINK = "//div[@class = 'alert alert-success']/child::a"; //XPath
        private const string PRODUCT_COMPARISON_LINK = "compare-total"; //XPath
        private const string FIRST_PRODUCT_LINK = ".caption h4:first-of-type"; //cssSelector
        private const string PRODUCT_LINKS = "//h4"; //XPath
        private const string WISHLIST_ID = "wishlist-total"; 
        // Buttons locators
        private const string COMPARE_THIS_PRODUCT_BUTTON = "//button[@data-original-title = 'Compare this Product']"; //XPath
        private const string ADD_TO_WISHLIST_BUTTON = "//div[contains(@class, 'product-layout')]//a[contains(text(),'MacBook')]/../../following-sibling::div/button[contains(@data-original-title,'Wish')]";//XPath
        private const string CLOSE_ALERT_BUTTON = "//button[@class = 'close']"; //XPath

        // Properties
        public IWebElement LaptopsAndNotebooksLabel
        { get { return driver.FindElement(By.CssSelector(LAPTOPS_AND_NOTEBOOKS_LABEL)); } }

        public IWebElement SuccessAlertMessage
        { get { return driver.FindElement(By.XPath(SUCCESS_ALERT_MESSAGE)); } }
   
        public IWebElement ComparableProductLink
        { get { return driver.FindElement(By.XPath(COMPARABLE_PRODUCT_LINK)); } }

        public IWebElement ProductComparisonLink
        { get { return driver.FindElement(By.Id(PRODUCT_COMPARISON_LINK)); } }

        public IWebElement FirstProductLink
        { get { return driver.FindElement(By.CssSelector(FIRST_PRODUCT_LINK)); } }

        public IWebElement WishListLink
        { get { return driver.FindElement(By.Id(WISHLIST_ID)); } }

        public IWebElement CompareThisProductButton
        { get { return driver.FindElement(By.XPath(COMPARE_THIS_PRODUCT_BUTTON)); } }

        public List<IWebElement> CompareProductButtons
        { get { return driver.FindElements(By.XPath(COMPARE_THIS_PRODUCT_BUTTON)).ToList(); } }

        public List<IWebElement> AddToWishlistButtons
        { get { return driver.FindElements(By.XPath(ADD_TO_WISHLIST_BUTTON)).ToList(); } }

        public List<IWebElement> CompareProductLinks
        { get { return driver.FindElements(By.XPath(PRODUCT_LINKS)).ToList(); } }

        public IWebElement CloseAlertButton
        { get { return driver.FindElement(By.XPath(CLOSE_ALERT_BUTTON)); } }

        public IWebElement AddToWishlistButton
        { get { return driver.FindElement(By.XPath(ADD_TO_WISHLIST_BUTTON)); } }

        // Constructor
        public LaptopsAndNotebooksPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement element = LaptopsAndNotebooksLabel;
            element = FirstProductLink;
            element = WishListLink;
            element = CompareThisProductButton;
            element = AddToWishlistButton;
        }

        public string GetLaptopsAndNotebooksLabelText()
        {
            return LaptopsAndNotebooksLabel.Text;
        }

        public string GetSuccessAlertMessageText()
        {
            return SuccessAlertMessage.Text;
        }

        public string GetFirstProductLinkText()
        {
            return FirstProductLink.Text;
        }

        public void ClickFirstProductLink()
        {
            FirstProductLink.Click();
        }

        public void ClickComparableProductLink()
        {
            ComparableProductLink.Click();
        }
        public string GetProductComparisonLinkText()
        {
            return ProductComparisonLink.Text;
        }

        public void ClickProductComparisonLink()
        {
            ProductComparisonLink.Click();
        }

        public void ClickWishlistLink()
        {
            WishListLink.Click();
        }


        public void ClickCompareThisProductButton()
        {
            CompareThisProductButton.Click();
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(SUCCESS_ALERT_MESSAGE)));
            //WaitForElementTextContains(ProductComparisonLink, "1");
            //Thread.Sleep(800);
        }

        public void ClickAddToWishListButton()
        {
            AddToWishlistButton.Click();
        }

        public ProductComparisonPage GoToComparison()
        {
            ClickProductComparisonLink();
            return new ProductComparisonPage(driver);
        }
        public bool CompareProductByName(string name)
        {
            int count = 0;
            foreach (IWebElement item in CompareProductLinks)
            {
                if(item.Text.Contains(name))
                {
                    CompareProductButtons[count].Click();
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(SUCCESS_ALERT_MESSAGE)));
                    CloseAlertButton.Click();
                    //Thread.Sleep(800);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool AddToWishlistByName(string name)
        {
            int count = 0;
            foreach (IWebElement item in CompareProductLinks)
            {
                if (item.Text.Contains(name))
                {
                    AddToWishlistButtons[count].Click();
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(SUCCESS_ALERT_MESSAGE)));
                    CloseAlertButton.Click();
                    //Thread.Sleep(800);
                    return true;
                }
                count++;
            }
            return false;
        }
        public WishlistPage AddToWishlist()
        {
            ClickAddToWishListButton();
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(SUCCESS_ALERT_MESSAGE))); //work for me @Vasyl
            ClickWishlistLink();
            return new WishlistPage(driver);
        }
    }
}
