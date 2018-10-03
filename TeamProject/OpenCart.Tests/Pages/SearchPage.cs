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
        private const string PRODUCTS_BLOCK = ".product-thumb"; // cssSelector
        private const string PRODUCTS_NAME_LIST = "//div[contains(@class, 'caption')]//a"; // XPath
        private const string PRODUCTS_COST_LIST = ".price-tax"; // cssSelector
        private const string PRODUCTS_SHOWING = "//div[contains(@class, 'col') and contains(text(), 'Showing')]"; // XPath
        private const string SORT_DD_MENU = "//div//select[contains(@id, 'sort')]"; // XPath
        private const string SHOW_DD_MENU = "input-limit"; // ID
        private const string PRODUCT_COMPARE_BTN = "compare-total"; // ID
        private const string LIST_BTN = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'list')]"; // XPath
        private const string GRID_BTN = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'grid')]"; // XPath
        private const string GRID_BTN_OrNOT = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'grid') and contains(@class, 'active')]"; // XPath
        private const string LIST_BTN_OrNot = "//div[contains(@class, 'btn-group-sm')]//button[contains(@id, 'list') and contains(@class, 'active')]"; // XPath

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
        private const string SORT_DEFAULT = "//div//option[text() = 'Default']"; // XPath
        private const string SORT_NAME_AZ = "//div//option[text() = 'Name (A - Z)']"; // XPath
        private const string SORT_NAME_ZA = "//div//option[text() = 'Name (Z - A)']"; // XPath
        private const string SORT_PRICE_LOWHIGH = "//div//option[text() = 'Price (Low > High)']"; // XPath
        private const string SORT_PRICE_HIGHLOW = "//div//option[text() = 'Price (High > Low)']"; // XPath
        private const string SORT_RATING_HIGHEST = "//div//option[text() = 'Rating (Highest)']"; // XPath
        private const string SORT_RATING_LOWEST = "//div//option[text() = 'Rating (Lowest)']"; // XPath
        private const string SORT_MODEL_AZ = "//div//option[text() = 'Model (A - Z)']"; // XPath
        private const string SORT_MODEL_ZA = "//div//option[text() = 'Model (Z - A)']"; // XPath

        // Constans Show dropdown menu options
        private const string SHOW_15 = "//div//select//option[text() = '15']"; // XPath
        private const string SHOW_25 = "//div//select//option[text() = '25']"; // XPath
        private const string SHOW_50 = "//div//select//option[text() = '50']"; // XPath
        private const string SHOW_75 = "//div//select//option[text() = '75']"; // XPath
        private const string SHOW_100 = "//div//select//option[text() = '100']"; // XPath
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
        { get { return driver.FindElement(By.XPath(SORT_DD_MENU)); } }
        public IWebElement ShowDDMenu
        { get { return driver.FindElement(By.Id(SHOW_DD_MENU)); } }
        public IWebElement ProductCompareBTN
        { get { return driver.FindElement(By.Id(PRODUCT_COMPARE_BTN)); } }
        public IWebElement GridBtn
        { get { return driver.FindElement(By.XPath(GRID_BTN)); } }
        public IWebElement ListBtn
        { get { return driver.FindElement(By.XPath(LIST_BTN)); } }
        public IWebElement GridBtnOrNot
        { get { return driver.FindElement(By.XPath(GRID_BTN_OrNOT)); } }
        public IWebElement ListBtnOrNot
        { get { return driver.FindElement(By.XPath(LIST_BTN_OrNot)); } }
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
            //VerifyWebElements_Labels();
            //VerifyWebElements_Func();
            //VerifyWebElements_DropDownItems();
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
        // Method gets main label with 'Search' text
        public string GetSearchLabelText()
        {
            return SearchLabel.Text;
        }

        // Method gets label with 'Search criteria' text
        public string GetSearchCriteriaLabelText()
        {
            return SearchCriteriaLabel.Text;
        }

        // Method gets label with 'Products meeting the search criteria'
        public string GetProductsMeetingLabelText()
        {
            return ProductsMeetingLabel.Text;
        }

        // Method gets label with 'There is no product that matches the search criteria' text that appears when no products are found
        public string GetNoProductsLabelText()
        {
            return NoProductsLabel.Text;
        }

        // Method sets search input field with: (text to search)
        public void SetSearchCriteriaInput(string searchText)
        {
            SearchCriteriaInput.SendKeys(searchText);
        }
        
        // Method Clears search input field
        public void ClearSearchCriteriaInput()
        {
            SearchCriteriaInput.Clear();
        }

        // Method gets categories dropdown menu text ( Default = 'All Categories')
        public string GetCategoriesDropDownMenuText()
        {
            return CategoriesDropDownMenu.Text;
        }
        
        // Method click on categories dropdown menu. User use this to pick in wich category search products 
        public void ClickCategoriesDropDownMenu()
        {
            CategoriesDropDownMenu.Click();
        }

        // Method click on 'Search in subcategories' checkbox to search products in subcategories
        public void ClickSearchInSubcategoriesCheckBox()
        {
            SearchInSubcategoriesCheckBox.Click();
        }

        // Method click on 'Search in description' checkbox to search products in description
        public void ClickSearchInDescriptionCheckBox()
        {
            SearchInDescriptionCheckBox.Click();
        }

        // Method click on 'Search' button to start searching products
        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        // Method counts how many product blocks appear after searching
        public int CountProductBlocks()
        {
            return ProductBlocks.Count();
        }
        
        // Method gets a list of each name of the product that appeard after search
        public IList<IWebElement> GetProductNameList()
        {
            IList<IWebElement> listofproducts = ProductNameList;
            return listofproducts;
        }

        // Method gets a list of each cost of the product that appeard after search
        public IList<IWebElement> GetProductCostList()
        {
            IList<IWebElement> listofproducts = ProductCostList;
            return listofproducts;
        }

        // Method gets label text with information about how many products on how many pages was found
        public string GetProductsShowingText()
        {
            return ProductsShowing.Text;
        }

        // Method gets Sort dropdown menu text ( Default = 'Default')
        public string GetSortDDMenuText()
        {
           return SortDDMenu.Text;
        }

        // Method click on sort dropdown menu.User use this to pick how to sort searched products
        public void ClickSortDDMenu()
        {
            SortDDMenu.Click();
        }

        // Method gets Show dropdown menu text ( Default = '15')
        public string GetShowDDMenuText()
        {
            return ShowDDMenu.Text;
        }

        // Method click on show dropdown menu.User use this to pick how many products will be shown on page
        public void ClickShowDDMenu()
        {
            ShowDDMenu.Click();
        }

        // Method gets text of 'Product Compare' button. Used to see how many products are compared.
        public string GetProductCompareBTNText()
        {
            return ProductCompareBTN.Text;
        }

        // Method click on 'Product Compare' button to go to 'Product Compare' page.
        public void ClickProductCompareBTN()
        {
            ProductCompareBTN.Click();
        }

        // Method click on 'Grid' to change type of view to Grid.
        public void ClickGridBtn()
        {
            GridBtn.Click();
        }

        // Method click on 'List' to change type of view to List.
        public void ClickListBtn()
        {
            ListBtn.Click();
        }

        // Method gets text of 'All category' type of searching
        public string GetCategoryAllCategoriesText()
        {
            return CategoryAllCategories.Text;
        }

        // Method click on 'All Categories' category to search in
        public void ClickCategoryAllCategories()
        {
            CategoryAllCategories.Click();
        }

        // Method gets text of 'Desktop' type of searching
        public string GetCategoryDesktopsText()
        {
            return CategoryDesktops.Text;
        }

        // Method click on 'Desktop' category to search in
        public void ClickCategoryDesktops()
        {
            CategoryDesktops.Click();
        }

        // Method gets text of 'Laptops And Notebooks' type of searching
        public string GetCategoryLaptopsAndNotebooksText()
        {
            return CategoryLaptopsAndNotebooks.Text;
        }

        // Method click on 'Laptops and Notebooks' category to search in
        public void ClickCategoryLaptopsAndNotebooks()
        {
            CategoryLaptopsAndNotebooks.Click();
        }

        // Method gets text of 'Components' type of searching
        public string GetCategoryComponentsText()
        {
            return CategoryComponents.Text;
        }

        // Method click on 'Components' category to search in
        public void ClickCategoryComponents()
        {
            CategoryComponents.Click();
        }

        // Method gets text of 'Tablets' type of searching
        public string GetCategoryTabletsText()
        {
            return CategoryTablets.Text;
        }

        // Method click on 'Tablets' category to search in
        public void ClickCategoryTablets()
        {
            CategoryTablets.Click();
        }

        // Method gets text of 'Software' type of searching
        public string GetCategorySoftwareText()
        {
            return CategorySoftware.Text;
        }

        // Method click on 'Software' category to search in
        public void ClickCategorySoftware()
        {
            CategorySoftware.Click();
        }

        // Method gets text of 'Phones and PDAs' type of searching
        public string GetCategoryPhonesAndPDAsText()
        {
            return CategoryPhonesAndPDAs.Text;
        }

        // Method click on 'Phones and PDAs' category to search in
        public void ClickCategoryPhonesAndPDAs()
        {
            CategoryPhonesAndPDAs.Click();
        }

        // Method gets text of 'Cameras' type of searching
        public string GetCategoryCamerasText()
        {
            return CategoryCameras.Text;
        }

        // Method click on 'Cameras' category to search in
        public void ClickCategoryCameras()
        {
            CategoryCameras.Click();
        }

        // Method gets text of 'Mp3 players' type of searching
        public string GetCategoryMp3playersText()
        {
            return CategoryMp3players.Text;
        }

        // Method click on 'Mp3 players' category to search in
        public void ClickCategoryMp3players()
        {
            CategoryMp3players.Click();
        }

        // Method gets text of 'Default' type of sorting for searching
        public string GetSortDefaultText()
        {
            return SortDefault.Text;
        }

        // Method click on 'Default' type of sorting for searching
        public void ClickSortDefault()
        {
            SortDefault.Click();
        }

        // Method gets text of 'Name (A - Z)' type of sorting for searching
        public string GetSortNameAZText()
        {
            return SortNameAZ.Text;
        }

        // Method click on 'Name (A - Z)' type of sorting for searching
        public void ClickSortNameAZ()
        {
            SortNameAZ.Click();
        }

        // Method gets text of 'Name (Z - A)' type of sorting for searching
        public string GetSortNameZAText()
        {
            return SortNameZA.Text;
        }

        // Method click on 'Name (Z - A)' type of sorting for searching
        public void ClickSortNameZA()
        {
            SortNameZA.Click();
        }

        // Method gets text of 'Price (Low - High)' type of sorting for searching
        public string GetSortPriceLowHighText()
        {
            return SortPriceLowHigh.Text;
        }

        // Method click on 'Price (Low - High)' type of sorting for searching
        public void ClickSortPriceLowHigh()
        {
            SortPriceLowHigh.Click();
        }

        // Method gets text of 'Price (High - Low)' type of sorting for searching
        public string GetSortPriceHighLowText()
        {
            return SortPriceHighLow.Text;
        }

        // Method click on 'Price (High - Low)' type of sorting for searching
        public void ClickSortPriceHighLow()
        {
            SortPriceHighLow.Click();
        }

        // Method gets text of 'Rating (Highest)' type of sorting for searching
        public string GetSortRatingHighestText()
        {
            return SortRatingHighest.Text;
        }

        // Method click on 'Rating (Highest)' type of sorting for searching
        public void ClickSortRatingHighest()
        {
            SortRatingHighest.Click();
        }

        // Method gets text of 'Rating (Lowest)' type of sorting for searching
        public string GetSortRatingLowestText()
        {
            return SortRatingLowest.Text;
        }

        // Method click on 'Rating (Lowest)' type of sorting for searching
        public void ClickSortRatingLowest()
        {
            SortRatingLowest.Click();
        }

        // Method gets text of 'Model (A - Z)' type of sorting for searching
        public string GetSortModelAZText()
        {
            return SortModelAZ.Text;
        }

        // Method click on 'Model (A - Z)' type of sorting for searching
        public void ClickSortModelAZ()
        {
            SortModelAZ.Click();
        }

        // Method gets text of 'Model (Z - A)' type of sorting for searching
        public string GetSortModelZAText()
        {
            return SortModelZA.Text;
        }

        // Method click on 'Model (Z - A)' type of sorting for searching
        public void ClickSortModelZA()
        {
            SortModelZA.Click();
        }

        // Method gets text of 'Show 15' type of showing for searching
        public string GetShow_15Text()
        {
            return Show_15.Text;
        }

        // Method click on 'Show 15' type of showing for searching
        public void ClickShow_15()
        {
            Show_15.Click();
        }

        // Method gets text of 'Show 25' type of showing for searching
        public string GetShow_25Text()
        {
            return Show_25.Text;
        }

        // Method click on 'Show 25' type of showing for searching
        public void ClickShow_25()
        {
            Show_25.Click();
        }

        // Method gets text of 'Show 50' type of showing for searching
        public string GetShow_50Text()
        {
            return Show_50.Text;
        }

        // Method click on 'Show 50' type of showing for searching
        public void ClickShow_50()
        {
            Show_50.Click();
        }

        // Method gets text of 'Show 75' type of showing for searching
        public string GetShow_75Text()
        {
            return Show_75.Text;
        }

        // Method click on 'Show 75' type of showing for searching
        public void ClickShow_75()
        {
            Show_75.Click();
        }

        // Method gets text of 'Show 100' type of showing for searching
        public string GetShow_100Text()
        {
            return Show_100.Text;
        }

        // Method click on 'Show 100' type of showing for searching
        public void ClickShow_100()
        {
            Show_100.Click();
        }
        
        // Method gets information if products view type is List or not
        public bool GetListOrNot()
        {
            bool isList;
            IWebElement listOrNot = ListBtnOrNot;
            if (listOrNot == null)
            {
                return isList = false;
            }
            else
            {
                return isList = true;
            }
        }

        // Method gets information if products view type is Grid or not
        public bool GetGridOrNot()
        {
            bool isGrid;
            IWebElement GridOrNot = GridBtnOrNot;
            if (GridOrNot == null)
            {
                return isGrid = false;
            }
            else
            {
                return isGrid = true;
            }
        }
        #endregion
    }
}