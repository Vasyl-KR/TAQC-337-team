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
        public IWebElement ProductBlock
        { get { return driver.FindElement(By.CssSelector(PRODUCTS_BLOCK)); } }
        public IWebElement ProductNameList
        { get { return driver.FindElement(By.XPath(PRODUCTS_NAME_LIST)); } }
        public IWebElement ProductCostList
        { get { return driver.FindElement(By.CssSelector(PRODUCTS_COST_LIST)); } }
        public IWebElement ProductsShowing
        { get { return driver.FindElement(By.XPath(PRODUCTS_SHOWING)); } }
        public IWebElement SortDDMenu
        { get { return driver.FindElement(By.XPath(PRODUCTS_NAME_LIST)); } }
        public IWebElement ShowDDMenu
        { get { return driver.FindElement(By.Id(SHOW_DD_MENU)); } }
        public IWebElement ProductCompareBTN
        { get { return driver.FindElement(By.Id(PRODUCT_COMPARE_BTN)); } }
        public IWebElement GridBTN
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
    }
}
