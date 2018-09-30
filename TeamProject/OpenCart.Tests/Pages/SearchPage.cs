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
    public class SearchPage : ATopComponent
    {
        #region Constants
        // Constans Labels
        private const string SEARCH_LABEL = "h1"; // cssSelector
        private const string SEARCH_CRITERIA_LABEL = "h1+"; // cssSelector
        private const string PRODUCTS_MEETING_LABEL = "h2"; // cssSelector
        private const string NO_PRODUCTS_LABEL = "#button-search + h2 + p"; // cssSelector
        
        // Constans Input fields, checkbox, buttons, dropdown menu, blocks
        private const string SEARCH_CRITERIA_INPUT = "#input-search"; // cssSelector
        private const string CATEGORIES_DD_MENU = "category_id"; // Name
        private const string SEARCH_IN_SUBCAT_CHECKBOX = "sub_category"; // Name
        private const string SEARCH_IN_DESCRIP_CHECKBOX = "#description"; // cssSelector
        private const string SEARCH_BUTTON = "#button-search"; // cssSelector
        private const string PRODUCTS_BLOCK = ".product - thumb"; // cssSelector
        private const string PRODUCTS_NAME_LIST = "//div[contains(@class, 'caption')]//a"; // XPath
        private const string PRODUCTS_COST_LIST = ".price-tax"; // cssSelector
        private const string PRODUCTS_SHOWING = "//div[contains(@class, 'col') and contains(text(), 'Showing')]"; // XPath
        private const string SORT_DD_MENU = "//div//select[contains(@id, 'sort')]"; // XPath
        private const string SHOW_DD_MENU = "input-limit"; // ID
        private const string PRODUCT_COMPARE_BTN = "compare-total"; // ID
        private const string GRID_BTN = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'grid') and contains(@class, 'active')]"; // XPath
        private const string LIST_BTN = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'list') and contains(@class, 'active')]"; // XPath

        // Constans Categories dropdown menu options (only main)
        private const string CATEGORY_ALL_CATEGORIES = "//div//option[text() = 'All Categories']"; // XPath
        private const string CATEGORY_DESKTOPS = "//div//option[text() = 'Desktops']"; // XPath
        private const string CATEGORY_LAPTOP_NOTEBOOKS = "//div//option[text() = 'Laptops & Notebooks']"; // XPath
        private const string CATEGORY_COMPONENTS = "//div//option[text() = 'Components']"; // XPath
        private const string CATEGORY_TABLETS = "//div//option[text() = 'Tablets']"; // XPath
        private const string CATEGORY_SOFTWARE = "//div//option[text() = 'Software']"; //XParh
        private const string CATEGORY_PHONES_PDAs = "//div//option[text() = 'Phones & PDAs']"; //XPath
        private const string CATEGORY_CAMERAS = "//div//option[text() = 'Cameras']"; // XPath
        private const string CATEGORY_MP3 = "//div//option[text() = 'MP3 Players']"; // XPath

        // Constans Sort dropdown menu options
        private const string SORT_DEFAULT = "//div//option[text() = 'Default']";
        private const string SORT_NAME_AZ = "//div//option[text() = 'Name (A - Z)']";
        private const string SORT_NAME_ZA = "//div//option[text() = 'Name (Z - A)']";
        private const string SORT_PRICE_LOWHIGH = "//div//option[text() = 'Price (Low > High)']";
        private const string SORT_PRICE_HIGHLOW = "//div//option[text() = 'Price (High > Low)']";
        private const string SORT_RATING_HIGHEST = "//div//option[text() = 'Rating (Highest)']";
        private const string SORT_RATING_LOWEST = "//div//option[text() = 'Rating (Lowest)']";
        private const string SORT_MODEL_AZ = "//div//option[text() = 'Model (A - Z)']";
        private const string SORT_MODEL_ZA = "//div//option[text() = 'Model (Z - A)']";

        // Constans Show dropdown menu options
        private const string SHOW_15 = "//div//select//option[text() = '15']";
        private const string SHOW_25 = "//div//select//option[text() = '25']";
        private const string SHOW_50 = "//div//select//option[text() = '50']";
        private const string SHOW_75 = "//div//select//option[text() = '75']";
        private const string SHOW_100 = "//div//select//option[text() = '100']";
        #endregion

        #region Properties
        // Labels properties
        public IWebElement SearchLabel
        { get { return driver.FindElement(By.CssSelector(SEARCH_LABEL)); } }
        public IWebElement SearchCriteriaLabel
        { get { return driver.FindElement(By.CssSelector(SEARCH_CRITERIA_LABEL)); }}
        public IWebElement ProductsMeetingLabel
        { get { return driver.FindElement(By.CssSelector(PRODUCTS_MEETING_LABEL)); } }
        public IWebElement NoProductsLabel
        { get { return driver.FindElement(By.CssSelector(NO_PRODUCTS_LABEL)); } }

        // Input field, checkbox, buttons, dropdown menu properties
        public IWebElement SearchCriteriaInput
        { get { return driver.FindElement(By.CssSelector(SEARCH_CRITERIA_INPUT)); } }
        public IWebElement CategoriesDropDownMenu
        { get { return driver.FindElement(By.Name(CATEGORIES_DD_MENU)); } }
        public IWebElement SearchInSubcategoriesCheckBox
        { get { return driver.FindElement(By.Name(SEARCH_IN_SUBCAT_CHECKBOX)); } }
        public IWebElement SearchInDescriptionCheckBox
        { get { return driver.FindElement(By.CssSelector(SEARCH_IN_DESCRIP_CHECKBOX)); } }
        public IWebElement SearchButton
        { get { return driver.FindElement(By.CssSelector(SEARCH_BUTTON)); } }
        public ReadOnlyCollection<IWebElement> ProductBlocks
        { get { return driver.FindElements(By.CssSelector(PRODUCTS_BLOCK)); } }
        public IList<IWebElement> ProductNameList
        { get { return driver.FindElements(By.XPath(PRODUCTS_NAME_LIST)); } }
        public IList<IWebElement> ProductCostList
        { get { return driver.FindElements(By.CssSelector(PRODUCTS_COST_LIST)); } }
        public IWebElement ProductsShowing
        { get { return driver.FindElement(By.XPath(PRODUCTS_SHOWING)); } }
        public IWebElement SortDDMenu
        { get { return driver.FindElement(By.XPath(PRODUCTS_NAME_LIST)); } }
        public IWebElement ShowDDMenu
        { get { return driver.FindElement(By.Id(SHOW_DD_MENU)); } }
        public IWebElement ProductCompareBTN
        { get { return driver.FindElement(By.Id(PRODUCT_COMPARE_BTN)); } }
        public IWebElement GridBtn
        { get { return driver.FindElement(By.XPath(GRID_BTN)); } }
        public IWebElement ListBtn
        { get { return driver.FindElement(By.XPath(LIST_BTN)); } }

        // Categories dropdown menu options (only main) properties
        public IWebElement CategoryAllCategories
        { get { return driver.FindElement(By.XPath(CATEGORY_ALL_CATEGORIES)); } }
        public IWebElement CategoryDesktops
        { get { return driver.FindElement(By.XPath(CATEGORY_DESKTOPS)); } }
        public IWebElement CategoryLaptopsAndNotebooks
        { get { return driver.FindElement(By.XPath(CATEGORY_LAPTOP_NOTEBOOKS)); } }
        public IWebElement CategoryComponents
        { get { return driver.FindElement(By.XPath(CATEGORY_COMPONENTS)); } }
        public IWebElement CategoryTablets
        { get { return driver.FindElement(By.XPath(CATEGORY_TABLETS)); } }
        public IWebElement CategorySoftware
        { get { return driver.FindElement(By.XPath(CATEGORY_SOFTWARE)); } }
        public IWebElement CategoryPhonesAndPDAs
        { get { return driver.FindElement(By.XPath(CATEGORY_PHONES_PDAs)); } }
        public IWebElement CategoryCameras
        { get { return driver.FindElement(By.XPath(CATEGORY_CAMERAS)); } }
        public IWebElement CategoryMp3players
        { get { return driver.FindElement(By.XPath(CATEGORY_MP3)); } }

        // Sort dropdown menu options properies
        public IWebElement SortDefault
        { get { return driver.FindElement(By.XPath(SORT_DEFAULT)); } }
        public IWebElement SortNameAZ
        { get { return driver.FindElement(By.XPath(SORT_NAME_AZ)); } }
        public IWebElement SortNameZA
        { get { return driver.FindElement(By.XPath(SORT_NAME_ZA)); } }
        public IWebElement SortPriceLowHigh
        { get { return driver.FindElement(By.XPath(SORT_PRICE_LOWHIGH)); } }
        public IWebElement SortPriceHighLow
        { get { return driver.FindElement(By.XPath(SORT_PRICE_HIGHLOW)); } }
        public IWebElement SortRatingHighest
        { get { return driver.FindElement(By.XPath(SORT_RATING_HIGHEST)); } }
        public IWebElement SortRatingLowest
        { get { return driver.FindElement(By.XPath(SORT_RATING_LOWEST)); } }
        public IWebElement SortModelAZ
        { get { return driver.FindElement(By.XPath(SORT_MODEL_AZ)); } }
        public IWebElement SortModelZA
        { get { return driver.FindElement(By.XPath(SORT_MODEL_ZA)); } }

        // Show dropdown menu options properties
        public IWebElement Show_15
        { get { return driver.FindElement(By.XPath(SHOW_15)); } }
        public IWebElement Show_25
        { get { return driver.FindElement(By.XPath(SHOW_25)); } }
        public IWebElement Show_50
        { get { return driver.FindElement(By.XPath(SHOW_50)); } }
        public IWebElement Show_75
        { get { return driver.FindElement(By.XPath(SHOW_75)); } }
        public IWebElement Show_100
        { get { return driver.FindElement(By.XPath(SHOW_100)); } }
        #endregion

        #region Constructor and Verify
        // Constructor
        public SearchPage(IWebDriver driver) : base(driver) 
        {
            VerifyWebElements_Labels();
            VerifyWebElements_Func();
            VerifyWebElements_DropDownItems();
        }
        
        // Verify labels
        private void VerifyWebElements_Labels()
        {
            IWebElement element = SearchLabel;
            element = SearchCriteriaLabel;
            element = ProductsMeetingLabel;
        }

        // Verify functionality components
        private void VerifyWebElements_Func()
        {
            IWebElement element =  SearchCriteriaInput;
            element = CategoriesDropDownMenu;
            element = SearchInSubcategoriesCheckBox;
            element =  SearchInDescriptionCheckBox;
            element = SearchButton;
        }

        // Verify dropdown menu items
        private void VerifyWebElements_DropDownItems()
        {
            IWebElement element = CategoryAllCategories;
            element = CategoryDesktops;
            element = CategoryLaptopsAndNotebooks;
            element = CategoryComponents;
            element = CategoryTablets;
            element = CategorySoftware;
            element = CategoryPhonesAndPDAs;
            element = CategoryCameras;
            element = CategoryMp3players;
        }
        #endregion

        #region Methods
        // Page methods
        public string GetSearchLabelText()
        {
            return SearchLabel.Text;
        }

        public string GetSearchCriteriaLabelText()
        {
            return SearchCriteriaLabel.Text;
        }

        public string GetProductsMeetingLabelText()
        {
            return ProductsMeetingLabel.Text;
        }

        public string GetNoProductsLabelText()
        {
            return NoProductsLabel.Text;
        }

        public void SetSearchCriteriaInput(string searchText)
        {
            SearchCriteriaInput.SendKeys(searchText);
        }
        
        public void ClearSearchCriteriaInput()
        {
            SearchCriteriaInput.Clear();
        }

        public string GetCategoriesDropDownMenuText()
        {
            return CategoriesDropDownMenu.Text;
        }

        public void ClickCategoriesDropDownMenu()
        {
            CategoriesDropDownMenu.Click();
        }

        public void ClickSearchInSubcategoriesCheckBox()
        {
            SearchInSubcategoriesCheckBox.Click();
        }

        public void ClickSearchInDescriptionCheckBox()
        {
            SearchInDescriptionCheckBox.Click();
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public int CountProductBlocks()
        {
            return ProductBlocks.Count();
        }
        
        public IList<IWebElement> GetProductNameList()
        {
            IList<IWebElement> listofproducts = ProductNameList;
            return listofproducts;
        }
        // todo or nottodo? Assert expected product names and actual match

        public IList<IWebElement> GetProductCostList()
        {
            IList<IWebElement> listofproducts = ProductNameList;
            return listofproducts;
        }
        // same

        public string GetProductsShowingText()
        {
            return ProductsShowing.Text;
        }

        public string GetSortDDMenuText()
        {
           return SortDDMenu.Text;
        }

        public void ClickSortDDMenu()
        {
            SortDDMenu.Click();
        }

        public string GetShowDDMenuText()
        {
            return ShowDDMenu.Text;
        }

        public void ClickShowDDMenu()
        {
            ShowDDMenu.Click();
        }

        public string GetProductCompareBTNText()
        {
            return ProductCompareBTN.Text;
        }

        public void ClickProductCompareBTN()
        {
            ProductCompareBTN.Click();
        }

        public void ClickGridBtn()
        {
            GridBtn.Click();
        }

        public void ClickListBtn()
        {
            ListBtn.Click();
        }

        public string GetCategoryAllCategoriesText()
        {
            return CategoryAllCategories.Text;
        }

        public void ClickCategoryAllCategories()
        {
            CategoryAllCategories.Click();
        }

        public string GetCategoryDesktopsText()
        {
            return CategoryDesktops.Text;
        }

        public void ClickCategoryDesktops()
        {
            CategoryDesktops.Click();
        }

        public string GetCategoryLaptopsAndNotebooksText()
        {
            return CategoryLaptopsAndNotebooks.Text;
        }

        public void ClickCategoryLaptopsAndNotebooks()
        {
            CategoryLaptopsAndNotebooks.Click();
        }

        public string GetCategoryComponentsText()
        {
            return CategoryComponents.Text;
        }

        public void ClickCategoryComponents()
        {
            CategoryComponents.Click();
        }

        public string GetCategoryTabletsText()
        {
            return CategoryTablets.Text;
        }

        public void ClickCategoryTablets()
        {
            CategoryTablets.Click();
        }

        public string GetCategorySoftwareText()
        {
            return CategorySoftware.Text;
        }

        public void ClickCategorySoftware()
        {
            CategorySoftware.Click();
        }

        public string GetCategoryPhonesAndPDAsText()
        {
            return CategoryPhonesAndPDAs.Text;
        }

        public void ClickCategoryPhonesAndPDAs()
        {
            CategoryPhonesAndPDAs.Click();
        }

        public string GetCategoryCamerasText()
        {
            return CategoryCameras.Text;
        }

        public void ClickCategoryCameras()
        {
            CategoryCameras.Click();
        }

        public string GetCategoryMp3playersText()
        {
            return CategoryMp3players.Text;
        }

        public void ClickCategoryMp3players()
        {
            CategoryMp3players.Click();
        }

        public string GetSortDefaultText()
        {
            return SortDefault.Text;
        }

        public void ClickSortDefault()
        {
            SortDefault.Click();
        }

        public string GetSortNameAZText()
        {
            return SortNameAZ.Text;
        }

        public void ClickSortNameAZ()
        {
            SortNameAZ.Click();
        }

        public string GetSortNameZAText()
        {
            return SortNameZA.Text;
        }

        public void ClickSortNameZA()
        {
            SortNameZA.Click();
        }

        public string GetSortPriceLowHighText()
        {
            return SortPriceLowHigh.Text;
        }

        public void ClickSortPriceLowHigh()
        {
            SortPriceLowHigh.Click();
        }

        public string GetSortPriceHighLowText()
        {
            return SortPriceHighLow.Text;
        }

        public void ClickSortPriceHighLow()
        {
            SortPriceHighLow.Click();
        }

        public string GetSortRatingHighestText()
        {
            return SortRatingHighest.Text;
        }

        public void ClickSortRatingHighest()
        {
            SortRatingHighest.Click();
        }

        public string GetSortRatingLowestText()
        {
            return SortRatingLowest.Text;
        }

        public void ClickSortRatingLowest()
        {
            SortRatingLowest.Click();
        }

        public string GetSortModelAZText()
        {
            return SortModelAZ.Text;
        }

        public void ClickSortModelAZ()
        {
            SortModelAZ.Click();
        }

        public string GetSortModelZAText()
        {
            return SortModelZA.Text;
        }

        public void ClickSortModelZA()
        {
            SortModelZA.Click();
        }

        public string GetShow_15Text()
        {
            return Show_15.Text;
        }

        public void ClickShow_15()
        {
            Show_15.Click();
        }

        public string GetShow_25Text()
        {
            return Show_25.Text;
        }

        public void ClickShow_25()
        {
            Show_25.Click();
        }

        public string GetShow_50Text()
        {
            return Show_50.Text;
        }

        public void ClickShow_50()
        {
            Show_50.Click();
        }

        public string GetShow_75Text()
        {
            return Show_75.Text;
        }

        public void ClickShow_75()
        {
            Show_75.Click();
        }

        public string GetShow_100Text()
        {
            return Show_100.Text;
        }

        public void ClickShow_100()
        {
            Show_100.Click();
        }
        #endregion
    }
}