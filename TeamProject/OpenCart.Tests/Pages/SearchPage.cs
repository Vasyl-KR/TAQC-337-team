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
        private IWebElement searchLabel;
        private IWebElement searchCriteriaLabel;
        private IWebElement searchCriteriaInput;
       // private IWebElement;
        

        public SearchPage(IWebDriver driver) : base(driver) 
        {

        }
    }
}
