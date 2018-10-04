using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenCartTests.Pages;


namespace OpenCartTests.Tests
{

    [TestFixture]
    public abstract class BaseTest
    {
        private PagesList pages;
        private IWebDriver driver;

        public PagesList Pages
        {
            get
            {
                return pages ?? new PagesList(driver);
            }
        }

        protected IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
            set
            {
                driver = (dynamic)value;
            }
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            pages = new PagesList(Driver);
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }


    }
}
