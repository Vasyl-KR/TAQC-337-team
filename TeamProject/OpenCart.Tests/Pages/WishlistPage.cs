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
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
namespace OpenCartTests.Pages
{
    public class WishlistPage : ATopComponent
    {

        #region Locators
        //// Label locators
        //private const string ProductPrice_XPATH =;
        //private const string CartTotal_ID = ;
        //private const string Cart_XPATH = ;
        //private const string AddedToCartProducts_XPATH =;
        //// Buttons locators
        //private const string AddToCart_BTN_XPATH = ;
        //private const string RemoveFromCart_BTN_XPATH = ;

        #endregion
        #region Properties
        [FindsBy(How = How.XPath, Using = "//table[contains(@class,'table table-striped')]")]
        public IWebElement AddedToCartProduct
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(@class,'text-right')]//div[contains(@class,'price')]")]
        public IWebElement ProductPriceLabel
        { get; set; }

        [FindsBy(How = How.Id, Using = "cart-total")]
        public IWebElement CartTotalPrice
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn btn-inverse btn-block btn-lg dropdown-toggle')]")]
        public IWebElement CartButton
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(@class,'text-right')]//button[contains(@class,'btn btn-primary')]")]
        public IWebElement AddToCartButton
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btn btn-danger btn-xs')]")]
        public IWebElement RemoveFromCartButton
        { get; set; }


        #endregion

        #region Constructor and Verify

        public WishlistPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
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
            string[] price = CartTotalPrice.Text.Split('-');
            return price[1].Replace(" ", String.Empty);
        }

        public void ClearTotalCart(bool rez)
        {
            
            ClickCartButton();
            if (rez)
            {
                RemoveFromCartButton.Click();
            }
            else
            {
                Console.WriteLine("Cart is clear");
            }
        }
        #endregion
    }
}


