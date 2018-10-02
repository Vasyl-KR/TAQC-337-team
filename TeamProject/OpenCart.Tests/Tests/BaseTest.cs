using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Tests
{

    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;
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

        [TearDown]
        public void TearDown() { }

        [SetUp]
        public void SetUp() { }
    }
}
