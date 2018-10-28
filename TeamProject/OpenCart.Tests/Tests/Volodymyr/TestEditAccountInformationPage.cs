using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestEditAccountInformationPage: BaseTest
    {
        private User user;

        [SetUp]
        public void GoToEditAccount()
        {
            user = UserList[2];
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();

            Pages.AccountPage.ClickEditAccountInformation();
        }

        [TearDown]
        public void LogOut()
        {
            Pages.EditAccountInformationPage.ClickLogout();
        }

        [Test]
        public void Positive_Edit_Account_Information_Page()
        {
            // Arrange
            User secondUser = UserList[0];
            string expectedMessage = EditAccountInformationPage.ExpectedSuccessMessage;

            // Act
            Pages.EditAccountInformationPage.SetFirstName(secondUser.firstName);
            Pages.EditAccountInformationPage.SetLastName(secondUser.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(secondUser.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();
      
            string actualMessage = Pages.EditAccountInformationPage.SuccessMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_FirstName_Empty()
        {
            // Arrange
           string expectedMessage = EditAccountInformationPage.FirstNameWarningText;

            // Act
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputFirstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();
            string actualMessage = Pages.EditAccountInformationPage.FirstNameWarningMessage.Text;
           
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_LastName_Empty()
        {
            // Arrange
            string expectedMessage = EditAccountInformationPage.LastNameWarningText;

            // Act
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputLastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);
            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.LastNameWarningMessage.Text;
           
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_Email_Empty()
        {
            // Arrange
            string expectedMessage = EditAccountInformationPage.EmailWarningText;

            // Act
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputEmail);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);
            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.EmailWarningMessage.Text;
            
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_Telephone_Empty()
        {
            // Arrange
            string expectedMessage = EditAccountInformationPage.TelephoneWarningText;

            // Act
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputTelephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);
            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.TelephoneWarningMessage.Text;
           
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

    }
}
