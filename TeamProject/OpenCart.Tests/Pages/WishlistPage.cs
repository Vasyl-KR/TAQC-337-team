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

        #region Properties

        [FindsBy(How = How.XPath, Using = "//table[contains(@class,'table table-striped')]")]
        public IWebElement AddedToCartProduct
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'alert alert-success')]")]
        public IWebElement ModifyMessage
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'wish list is empty')]")]
        public IWebElement EmptyWishlistMessage
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your shopping cart is empty!')]")]
        public IWebElement EmptyCartMessage
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'alert alert-success')]//a[contains(text(),'MacBook')]")]
        public IWebElement SuccessMessage
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(@class,'text-right')]//div[contains(@class,'price')]")]
        public IWebElement ProductPriceLabel
        { get; set; }

        [FindsBy(How = How.XPath,Using ="//a[contains(text(),'MacBook')]")]
        public IWebElement ProductNameLabel
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//tbody//tr")]
        public IList<IWebElement> ProductsRow
        { get; set; }

        [FindsBy(How = How.Id, Using = "cart-total")]
        public IWebElement CartTotalPrice
        { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'btn btn-danger')]")]
        public IWebElement RemoveFromWishlistButton
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

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'btn btn-primary')]")]
        public IWebElement ContinueButton
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

        public string GetEmptylistMessage()
        {
            if (WaitForElementPresent(EmptyWishlistMessage))
            {
                return EmptyWishlistMessage.Text;
            }
            else
            {
                return "Some items still in your Wishlist";
            }
        }
        public string GetEmptyCartMessage()
        {
            ClickCartButton();
            if (WaitForElementPresent(EmptyCartMessage))
            {
                return EmptyCartMessage.Text;
            }
            else
            {
                return "Some items still in your Cart";
            }
        }

        public string GetSuccessMessage()
        {
      
            if (WaitForElementPresent(SuccessMessage))
            {
                return SuccessMessage.Text;
            }
            else
            {
                return "item not added";
            }
        }

        public string GetModifyListMessage()
        {
            return ModifyMessage.Text;
        }

        public string GetProductPriceText()
        {
            return ProductPriceLabel.Text;
        }

        public string GetProductName()
        {
            return "MacBook";
            //return ProductNameLabel.Text;
        }

        public string GetTotalCartText()
        {
            return CartTotalPrice.Text;
        }
        public int GetProductsRows()
        {

            return ProductsRow.ToArray().Length;
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

        public void ClickRemoveFromWishlist()
        {
            RemoveFromWishlistButton.Click();
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public string GetTotalCartPrice()
        {
            WaitForElementTextContains(CartTotalPrice, GetProductPriceText());

            string[] price = CartTotalPrice.Text.Split('-');
            return price[1].Replace(" ", String.Empty);
        }

        public void ClearWishlist()
        {

            if (WaitForElementPresent(RemoveFromWishlistButton))
            {
                ClickRemoveFromWishlist();
            }
            else
            {
                Console.WriteLine("Wishlist is clear");
            }
        }

        public void ClearTotalCart()
        {

            ClickCartButton();
            if (WaitForElementPresent(CartTotalPrice))
            {
                ClickRemoveFromCart();
            }
            else
            {
                Console.WriteLine("Cart is clear");
            }
        }


        public void ClearTotalCartWait()
        {
           
            WaitForElementPresent(RemoveFromCartButton);
        }

        #endregion


    }

}


