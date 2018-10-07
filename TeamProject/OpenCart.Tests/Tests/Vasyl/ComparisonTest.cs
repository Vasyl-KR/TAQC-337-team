using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Vasyl
{
    [TestFixture]
    public class ComparisonTest : BaseTest
    {

        [Test, Order(1)]
        public void AddToComparisionTest()
        {
            //Arrange
            string selectedProduct;
            string actualProduct;

            //Act
            //Go to products page
            Pages.HomePage.GoToLaptopPage();
            //Add product to comparison
            selectedProduct = Pages.LaptopsAndNotebooksPage.GetFirstProductLinkText();
            Pages.LaptopsAndNotebooksPage.ClickCompareThisProductButton();
            //Go to products comparison
            Pages.LaptopsAndNotebooksPage.GoToComparison();
            actualProduct = Pages.ProductComparisonPage.GetLastProductText();

            //Assert
            Assert.AreEqual(selectedProduct, actualProduct, "Adding failed");
        }
        [Test, Order(2)]
        public void RemoveFromCompareTableTest()
        {
            //Arrange

            //Act
            //Go to products page
            Pages.HomePage.GoToLaptopPage();
            //Add product to comparison
            Pages.LaptopsAndNotebooksPage.ClickCompareThisProductButton();
            //Go to products comparison
            Pages.LaptopsAndNotebooksPage.GoToComparison();
            //Remove product from comparison
            Pages.ProductComparisonPage.ClickRemoveLastProductButton();
            
            //Assert
            Assert.AreEqual("You have not chosen any products to compare.",
               Pages.ProductComparisonPage.GetNoProductsToCompareLabelText(), "Removing failed");

        }
        [TestCase("MacBook Pro"), Order(4)]
        public void AddSelectedProductToComparisionTest(string name)
        {
            //Arrange
            string selectedProduct = name;
            string actualProduct;

            //Act
            //Go to products page
            Pages.HomePage.GoToLaptopPage();
            //Add product to comparison
            Pages.LaptopsAndNotebooksPage.CompareProductByName(name);
            //Wait for adding
            //pages.WaitForElementTextContainsEC(pages.LaptopsAndNotebooksPage.ProductComparisonLink, "1");
            //Go to products comparison
            Pages.LaptopsAndNotebooksPage.GoToComparison();
            actualProduct = Pages.ProductComparisonPage.GetLastProductText();

            //Assert
            Assert.AreEqual(selectedProduct, actualProduct, "Adding failed");
        }
        [TestCase(4), Order(3)]
        public void Add_4_ProductsToCompareTest(int x)
        {
            //Arrange

            //Act
            //Go to products page
            Pages.HomePage.GoToLaptopPage();
            //Add 4 products to comparision
            for (int i = 0; i < x; i++)
            {
                string name = Pages.LaptopsAndNotebooksPage.CompareProductLinks[i].Text;
                Pages.LaptopsAndNotebooksPage.CompareProductByName(name);
            }
            //Go to products comparison
            Pages.LaptopsAndNotebooksPage.GoToComparison();

            //Assert
            Assert.AreEqual(x, Pages.ProductComparisonPage.AllProducts.Count, "Adding failed");
        }

    }
}