using System.Linq;
using NUnit.Framework;
using OpenCartTests.Data;

namespace OpenCartTests.Tests.Ostap
{
    [TestFixture]
    class SuccessChangePasswordTests : BaseTest
    {
        private User user;

        [SetUp]
        public void BeforeAll()
        {
            user = ReaderUserData.GetUsers().Users.FirstOrDefault(u => u.email == "ostap@gmail.com");

            Pages.HomePage
                .GoToLoginPage()
                .SuccessRegistratorLogin(user.email, user.password);
        }

        [TearDown]
        public void AfterAll()
        {
            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(user.password, user.password);

            Pages.AccountPage
                .GoToLogoutPage()
                .SuccessLogout();
        }

        [Test]
        public void PasswordAreCorrectAndMatch()
        {
            //Arrange
            string password = Passwords.Correct1;
            string expectedMessage = "Success: Your password has been successfully updated.";

            //Act           
            Pages.AccountPage
                .GoToChangePassword()
                .SuccessChangePassword(password, password);

            string actualMessage = Pages.AccountPage.GetSuccessChangePasswordMessageText();

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage, "Messages aren't equal");
        }
    }
}
