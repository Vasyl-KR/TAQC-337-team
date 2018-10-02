using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
   public class Pages
    {
        private readonly IWebDriver driver;

        public Pages (IWebDriver driver)
        {
            this.driver = driver;
        }
   
    }
}
