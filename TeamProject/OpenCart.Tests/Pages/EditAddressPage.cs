using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace OpenCartTests.Pages
{
    class EditAddressPage
    {
        public IWebDriver driver;


        private const string FirstName_INPUT_ID = "input-firstname";
        private const string FirstName_LABEL_XPATH = "//label[contains(@for,'input-firstname')]";
        private const string LastName_INPUT_ID = "input-lastname";
        private const string LastName_LABEL_XPATH = "//label[contains(@for,'input-lastname')]";
        private const string Company_INPUT_ID = "input-company";
        private const string Company_LABEL_XPATH = "//label[contains(@for,'input-company')]";
        private const string Address1_INPUT_ID = "input-address-1";
        private const string Address1_LABEL_XPATH = "//label[contains(@for,'input-address-1')]";
        private const string Address2_INPUT_ID = "input-address-2";
        private const string Address2_LABEL_XPATH = "//label[contains(@for,'input-address-2')]";
        private const string City_INPUT_ID = "input-city";
        private const string City_LABEL_XPATH = "//label[contains(@for,'input-city')]";
        private const string PostCode_INPUT_ID = "input-postcode";
        private const string PostCode_LABEL_XPATH = "//label[contains(@for,'input-postcode')]";


        public IWebElement FirstNameLabel{get { return driver.FindElement(By.XPath(EditAddressPage.FirstName_LABEL_XPATH)); }}
        public IWebElement FirstNameInput{get { return driver.FindElement(By.Id(EditAddressPage.FirstName_INPUT_ID)); }}
        public IWebElement LastNameLabel { get { return driver.FindElement(By.XPath(EditAddressPage.LastName_LABEL_XPATH)); } }
        public IWebElement LastNameInput { get { return driver.FindElement(By.Id(EditAddressPage.LastName_INPUT_ID)); } }
        public IWebElement CompanyLabel { get { return driver.FindElement(By.XPath(EditAddressPage.Company_LABEL_XPATH)); } }
        public IWebElement CompanyInput { get { return driver.FindElement(By.Id(EditAddressPage.Company_INPUT_ID)); } }  
        public IWebElement Address1Label { get { return driver.FindElement(By.XPath(EditAddressPage.Address1_LABEL_XPATH)); } }
        public IWebElement Address1Input { get { return driver.FindElement(By.Id(EditAddressPage.Address1_INPUT_ID)); } }
        public IWebElement Address2Label { get { return driver.FindElement(By.XPath(EditAddressPage.Address2_LABEL_XPATH)); } }
        public IWebElement Address2Input { get { return driver.FindElement(By.Id(EditAddressPage.Address2_INPUT_ID)); } }
        public IWebElement CityLabel { get { return driver.FindElement(By.XPath(EditAddressPage.City_LABEL_XPATH)); } }
        public IWebElement CityInput { get { return driver.FindElement(By.Id(EditAddressPage.City_INPUT_ID)); } }
        public IWebElement PostCodeLabel { get { return driver.FindElement(By.XPath(EditAddressPage.PostCode_LABEL_XPATH)); } }
        public IWebElement PostCodeInput { get { return driver.FindElement(By.Id(EditAddressPage.PostCode_INPUT_ID)); } }

        public EditAddressPage()
        {
            VerifyWebElements_INPUTS();
            VerifyWebElements_LABELS();
        }

        private void VerifyWebElements_INPUTS()
        {
            IWebElement element = FirstNameInput;
            element = LastNameInput;
            element = CompanyInput;
            element = Address1Input;
            element = Address2Input;
            element = CityInput;
            element = PostCodeInput;
        }

        private void VerifyWebElements_LABELS()
        {
            IWebElement element = FirstNameLabel;
            element = LastNameLabel;
            element = CompanyLabel;
            element = Address1Label;
            element = Address2Label;
            element = CityLabel;
            element = PostCodeLabel;
        }


    }
}
