﻿using System;
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
    public class LaptopsAndNotebooksPage : ATopComponent
    {
        // Label locators
        private const string LAPTOPS_AND_NOTEBOOKS_LABEL = "h2"; // cssSelector
        private const string SUCCESS_ALERT_MESSAGE = "//div[@class = 'alert alert-success']"; // XPath

        // Link locators
        private const string COMPARABLE_PRODUCT_LINK = "//div[@class = 'alert alert-success']/child::a[1]"; //XPath
        private const string PRODUCT_COMPARISON_LINK = "//div[@class = 'alert alert-success']/child::a[contains (@href, 'compare')]"; //XPath
        private const string FIRST_PRODUCT_LINK = ".caption h4:first-of-type"; //cssSelector

        // Buttons locators
        private const string COMPARE_THIS_PRODUCT_BUTTON = "//button[@data-original-title = 'Compare this Product']"; //XPath

        // Properties
        public IWebElement LaptopsAndNotebooksLabel
        { get { return driver.FindElement(By.CssSelector(LAPTOPS_AND_NOTEBOOKS_LABEL)); } }
        public IWebElement SuccessAlertMessage
        { get { return driver.FindElement(By.XPath(SUCCESS_ALERT_MESSAGE)); } }
        public IWebElement ComparableProductLink
        { get { return driver.FindElement(By.XPath(COMPARABLE_PRODUCT_LINK)); } }
        public IWebElement ProductComparisonLink
        { get { return driver.FindElement(By.XPath(PRODUCT_COMPARISON_LINK)); } }
        public IWebElement FirstProductLink
        { get { return driver.FindElement(By.CssSelector(FIRST_PRODUCT_LINK)); } }
        public IWebElement CompareThisProductButton
        { get { return driver.FindElement(By.XPath(COMPARE_THIS_PRODUCT_BUTTON)); } }

        // Constructor
        public LaptopsAndNotebooksPage(IWebDriver driver) : base(driver)
        {
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement element = LaptopsAndNotebooksLabel;
            element = FirstProductLink;
            element = CompareThisProductButton;
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

        public void ClickProductComparisonLink()
        {
            ProductComparisonLink.Click();
        }

        public void ClickCompareThisProductButton()
        {
            CompareThisProductButton.Click();
        }

        public ProductComparisonPage AddToCompare()
        {
            ClickCompareThisProductButton();
            ClickProductComparisonLink();
            return new ProductComparisonPage(driver);
        }
    }
}
