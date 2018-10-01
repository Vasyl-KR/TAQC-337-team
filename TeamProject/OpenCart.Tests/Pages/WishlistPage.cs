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
using System.Collections.ObjectModel;

namespace OpenCartTests.Pages
{
    public class WishlistPage : ATopComponent
    {

        #region Locators
        // Label locators
        private const string ProductPrice_XPATH = "//td[contains(@class,'text-right')]//div[contains(@class,'price')]";
        private const string CartTotal_ID = "cart-total";
        private const string Cart_XPATH = "//button[contains(@class,'btn btn-inverse btn-block btn-lg dropdown-toggle')]";
        private const string AddedToCartProducts_XPATH = "//table[contains(@class,'table table-striped')]";
        // Buttons locators
        private const string AddToCart_BTN_XPATH = "//td[contains(@class,'text-right')]//button[contains(@class,'btn btn-primary')]";
        private const string RemoveFromCart_BTN_XPATH = "//button[contains(@class,'btn btn-danger btn-xs')]";

        #endregion
        #region Properties

        public IWebElement AddedToCartProduct
        { get { return driver.FindElement(By.XPath(AddedToCartProducts_XPATH)); } }

        public IWebElement ProductPriceLabel
        { get { return driver.FindElement(By.XPath(ProductPrice_XPATH)); } }

        public IWebElement CartTotalPrice
        { get { return driver.FindElement(By.Id(CartTotal_ID)); } }

        public IWebElement CartButton
        { get { return driver.FindElement(By.XPath(Cart_XPATH)); } }

        public IWebElement AddToCartButton
        { get { return driver.FindElement(By.XPath(AddToCart_BTN_XPATH)); } }

        public IWebElement RemoveFromCartButton
        { get { return driver.FindElement(By.XPath(RemoveFromCart_BTN_XPATH)); } }

        #endregion

        #region Constructor and Verify

        public WishlistPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements();
        }

        public void VerifyWebElements()
        {
            IWebElement element;
            element = AddToCartButton;
            element = ProductPriceLabel;
            element = CartTotalPrice;
        }
        #endregion
        #region Methods


        public string GetProductPriceText()
        {
            return ProductPriceLabel.Text;
        }

        public string GetTotalCartText()
        {
            return CartTotalPrice.Text;
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        public void ClickCartButton()
        {
            CartButton.Click();
        }

        public void ClickRemoveFromCart()
        {
            RemoveFromCartButton.Click();
        }

        public string GetTotalCartPrice()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => CartTotalPrice.Text.Contains(GetProductPriceText()));
            string[] price = CartTotalPrice.Text.Split('-');
            return price[1].Replace(" ", String.Empty);
        }

        public void ClearTotalCart()
        {
            ClickCartButton();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(driver => RemoveFromCartButton).Click() ;
            Console.WriteLine("Cart is clear");
        }
        #endregion
    }
}


