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

namespace OpenCartTests.Pages
{
    //By Vasyl
    public class ProductComparisonPage : ATopComponent
    {

        // Label locators
        private const string COMPARISON_LABEL = "h1"; // cssSelector
        private const string PRODUCT_DETAILS_LABEL = "//thead/descendant::*[contains(text(), 'Product Details')]"; // XPath
        private const string PRODUCT_LABEL = "//td[text() = 'Product']"; // XPath

        // Link locators
        private const string FIRST_PRODUCT_LINK = "//td[text() = 'Product']/following-sibling::td[1]"; //XPath
        private const string LAST_PRODUCT_LINK = "//td[text() = 'Product']/following-sibling::td[last()]"; //XPath

        // Buttons locators
        private const string ADD_TO_CART_FIRST_BUTTON = "//tbody[last()]/tr[last()]/descendant::input[1]"; //XPath
        private const string ADD_TO_CART_LAST_BUTTON = "//tbody[last()]/tr[last()]/descendant::input[last()]"; //XPath
        private const string REMOVE_FIRST_BUTTON = "//tbody[last()]/tr[last()]/descendant::a[1]"; //XPath
        private const string REMOVE_LAST_BUTTON = "//tbody[last()]/tr[last()]/descendant::a[last()]"; //XPath

        // Labels properties
        public IWebElement ProductComparisonLabel
        { get { return driver.FindElement(By.CssSelector(COMPARISON_LABEL)); } }
        public IWebElement ProductDetailsLabel
        { get { return driver.FindElement(By.XPath(PRODUCT_DETAILS_LABEL)); } }
        public IWebElement ProductLabel
        { get { return driver.FindElement(By.XPath(PRODUCT_LABEL)); } }
        // Link properties
        public IWebElement FirstProduct
        { get { return driver.FindElement(By.XPath(FIRST_PRODUCT_LINK)); } }
        public IWebElement LastProduct
        { get { return driver.FindElement(By.XPath(LAST_PRODUCT_LINK)); } }
        // Buttons properties
        public IWebElement AddToCartFirstButton
        { get { return driver.FindElement(By.XPath(ADD_TO_CART_FIRST_BUTTON)); } }
        public IWebElement AddToCartLastButton
        { get { return driver.FindElement(By.XPath(ADD_TO_CART_LAST_BUTTON)); } }
        public IWebElement RemoveFirstProductButton
        { get { return driver.FindElement(By.XPath(REMOVE_FIRST_BUTTON)); } }
        public IWebElement RemoveLastProductButton
        { get { return driver.FindElement(By.XPath(REMOVE_LAST_BUTTON)); } }

        // Constructor
        public ProductComparisonPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement element = ProductComparisonLabel;
            element = ProductDetailsLabel;
            element = ProductLabel;
            element = FirstProduct;
            element = LastProduct;
            element = AddToCartFirstButton;
            element = AddToCartLastButton;
            element = RemoveFirstProductButton;
            element = RemoveLastProductButton;
        }

        public string GetProductComparisonLabelText()
        {
            return ProductComparisonLabel.Text;
        }

        public string GetProductDetailsLabelText()
        {
            return ProductDetailsLabel.Text;
        }

        public string GetProductLabelText()
        {
            return ProductLabel.Text;
        }

        public string GetFirstProductText()
        {
            return FirstProduct.Text;
        }

        public void ClickFirstProductLink()
        {
            FirstProduct.Click();
        }

        public string GetLastProductText()
        {
            return LastProduct.Text;
        }

        public void ClickLastProductLink()
        {
            LastProduct.Click();
        }

        public void ClickAddToCartFirstButton()
        {
            AddToCartFirstButton.Click();
        }

        public void ClickAddToCartLastButton()
        {
            AddToCartLastButton.Click();
        }

        public void ClickRemoveFirstProductButton()
        {
            RemoveFirstProductButton.Click();
        }

        public void ClickRemoveLastProductButton()
        {
            RemoveLastProductButton.Click();
        }
    }
}
