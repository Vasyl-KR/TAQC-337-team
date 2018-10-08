using NUnit.Framework;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Ostap
{
    [TestFixture]
    class UnsuccessLoginTests : BaseTest
    {

        [OneTimeSetUp]
        public new void SetUp()
        {
            Pages = new PagesList(Driver);
            Driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/");
            Pages.HomePage
               .GoToLoginPage();
        }

        [TestCase("wrongEmail@sample.com","qwerty")]
        [TestCase("", "")]
        [TestCase("ostap@gmail.com", "wrongpassword")]
        public void InvalidUserData(string email, string password)
        {
            //Arrange
            string expectedErrorMessage = "Warning: No match for E-Mail Address and/or Password.";

            //Act
            string actualErrorMessage = Pages.LoginPage
               .UnsuccessfulLogin(email, password)
               .GetInvalidLoginLabelText();

            //Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error messages are not equal");
        }

        [TestCase("vasya@gmail.com", "wrongpassword")]
        public void TooManyLoginsWithIncorrectPass(string email, string password)
        {
            //Arrange
            string expectedErrorMessage = "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";
            int countOfLogins = 6;
            //Act
            for (int i = 0; i < countOfLogins; i++)
            {
                Pages.LoginPage
               .UnsuccessfulLogin(email, password);
            }
            string actualErrorMessage = Pages.LoginPage                
              .GetInvalidLoginLabelText();

            //Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Error messages are not equal");

        }
    }
}
