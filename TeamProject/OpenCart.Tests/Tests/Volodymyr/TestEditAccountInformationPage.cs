using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestEditAccountInformationPage: BaseTest
    {     
        [Test]
        public void Positive_Edit_Account_Information_Page()
        {
            // Arrange
            // get test data
            User firstUser = UserList[0];
            User secondUser = UserList[3];
            string expectedMessage = EditAccountInformationPage.ExpectedSuccessMessage;

            // Act
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(firstUser.email)
                        .SetPasswordInputClear(firstUser.password)
                        .ClickSigninButton();
            
            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.SetFirstName(secondUser.firstName);
            Pages.EditAccountInformationPage.SetLastName(secondUser.lastName);
            Pages.EditAccountInformationPage.SetEmail(secondUser.email);
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
            // get test data
            User user = UserList[2];
           
            string expectedMessage = EditAccountInformationPage.FirstNameWarningText;

            // Act
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();

            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputFirstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.FirstNameWarningMessage.Text;
            Pages.EditAccountInformationPage.ClickLogout();

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_LastName_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[2];

            string expectedMessage = EditAccountInformationPage.LastNameWarningText;

            // Act
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();

            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputLastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.LastNameWarningMessage.Text;
            Pages.EditAccountInformationPage.ClickLogout();
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_Email_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[2];

            string expectedMessage = EditAccountInformationPage.EmailWarningText;

            // Act
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();

            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputEmail);
            Pages.EditAccountInformationPage.SetTelephone(user.telephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.EmailWarningMessage.Text;
            Pages.EditAccountInformationPage.ClickLogout();
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Edit_Account_Telephone_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[2];

            string expectedMessage = EditAccountInformationPage.TelephoneWarningText;

            // Act
            //go to My Accaunt page
            Pages.LoginPage.GoToLoginPage()
                        .SetLoginInputClear(user.email)
                        .SetPasswordInputClear(user.password)
                        .ClickSigninButton();

            //go to Edit account page
            Pages.AccountPage.ClickEditAccountInformation();

            //fill fields on Edit account page
            Pages.EditAccountInformationPage.SetFirstName(user.firstName);
            Pages.EditAccountInformationPage.SetLastName(user.lastName);
            Pages.EditAccountInformationPage.SetEmail(user.email);
            Pages.EditAccountInformationPage.ClearDataInField(Pages.EditAccountInformationPage.InputTelephone);
            Pages.EditAccountInformationPage.SetFax(EditAccountInformationPage.DefaultFax);

            //click button Continue
            Pages.EditAccountInformationPage.ClickButtonContinue();

            string actualMessage = Pages.EditAccountInformationPage.TelephoneWarningMessage.Text;
            Pages.EditAccountInformationPage.ClickLogout();
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

    }
}
