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
        // Constans Labels
        private const string SEARCH_LABEL = "h1"; // cssSelector
        private const string SEARCH_CRITERIA_LABEL = "h1+"; // cssSelector
        private const string PRODUCTS_MEETING_LABEL = "h2"; // cssSelector
        private const string NO_PRODUCTS_LABEL = "#button-search + h2 + p"; // cssSelector
        
        // Constans Input fields, checkbox, buttons, dropdown menu
        private const string SEARCH_CRITERIA_INPUT = "#input-search"; // cssSelector
        private const string CATEGORIES_DD_MENU = "category_id"; // Name
        private const string SEARCH_IN_SUBCAT_CHECKBOX = "sub_category"; // Name
        private const string SEARCH_IN_DESCRIP_CHECKBOX = "#description"; // cssSelector
        private const string SEARCH_BUTTON = "#button-search"; // cssSelector
        
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
