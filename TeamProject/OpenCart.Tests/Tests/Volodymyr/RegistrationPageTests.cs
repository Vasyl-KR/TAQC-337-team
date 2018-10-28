using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using WebServiceTest;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class RegistrationPageTests : BaseTest
    {
        [SetUp]
        public void GoToRegister()
        {
            Pages.RegisterPage.ClickRegiser();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Positive_Registration_New_User(bool yesNo)
        {
            // Arrange
            User user = yesNo ? UnregisterUserList[1] : UnregisterUserList[2];
            string expectedMessage = ConfirmationRegisterPage.ExpectedSuccessMessage;

            // Act                   
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue(yesNo);
            string actualMessage = Pages.ConfirmationRegisterPage.SuccessMessageH1Element.Text;          
            Pages.ConfirmationRegisterPage.ClickConfirmationButtonContinue();
            Pages.AccountPage.GoToLogoutPage().SuccessLogout();
            
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void Negative_Registration_User_AlreadyExist()
        {
            // Arrange
            // get test data
            User user = UnregisterUserList[0];
            string expectedMessage = RegisterPage.EmailAlreadyExist;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.MainWarningMessage.Text;
           
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_First_Name_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.firstName = String.Empty;
            string expectedMessage = RegisterPage.FirstNameWarningText;

            // Act           
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.FirstNameWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Last_Name_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.lastName = String.Empty;
            string expectedMessage = RegisterPage.LastNameWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.LastNameWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Email_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.email = String.Empty;
            string expectedMessage = RegisterPage.EmailWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.EmailWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Telephone_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.telephone = String.Empty;
            string expectedMessage = RegisterPage.TelephoneWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.TelephoneWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Address1_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.address_1 = String.Empty;
            string expectedMessage = RegisterPage.Address1WarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.Address1WarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_City_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.city = String.Empty;
            string expectedMessage = RegisterPage.CityWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.CityWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Country_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.country = RegisterPage.PleseSelect;
            user.region = RegisterPage.None;
            string expectedMessage = RegisterPage.CountryWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.CountryWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Region_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.region = RegisterPage.PleseSelect;
            string expectedMessage = RegisterPage.RegionWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.RegionWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Password_Empty()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.password = String.Empty;
            string expectedMessage = RegisterPage.PasswordWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.PasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_ConfirmPassword_NoMatch()
        {
            // Arrange
            User user = UnregisterUserList[1];
            string expectedMessage = RegisterPage.ConfirmWarningText;

            // Act
            Pages.RegisterPage.SetFirstName(user.firstName);
            Pages.RegisterPage.SetLastName(user.lastName);
            Pages.RegisterPage.SetEmail(user.email);
            Pages.RegisterPage.SetTelephone(user.telephone);
            Pages.RegisterPage.SetFax(user.fax);
            Pages.RegisterPage.SetCompany(user.company);
            Pages.RegisterPage.SetAddress1(user.address_1);
            Pages.RegisterPage.SetAddress2(user.address_2);
            Pages.RegisterPage.SetCity(user.city);
            Pages.RegisterPage.SetPostCode(user.postCode);
            Pages.RegisterPage.SetCountry(user.country);
            Pages.RegisterPage.SetRegion(user.region);
            Pages.RegisterPage.SetPassword(user.password);
            Pages.RegisterPage.SetConfirmPassword(user.password+"in");
            SetNecessaryCheckBoxAndContinue();

            string actualMessage = Pages.RegisterPage.ConfirmPasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_PasswordIsToShort()
        {
            // Arrange
            User user = UnregisterUserList[1];
            user.password = RegisterPage.ShotPassword;
            string expectedMessage = RegisterPage.PasswordWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryCheckBoxAndContinue();
            string actualMessage = Pages.RegisterPage.PasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]

        public void UnSuccess_Register_Not_Agree_Terms()
        {
            // Arrange
            User user = UnregisterUserList[1];
            string expectedMessage = RegisterPage.AgreeTermsWarningText;

            // Act
            FillFieldsUserData(user);
            Pages.RegisterPage.SelectNewsLetter(true);
            Pages.RegisterPage.ClickButtonContinue();
            string actualMessage = Pages.RegisterPage.MainWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private void FillFieldsUserData(User user)
        {
            try
            {
                Pages.RegisterPage.SetFirstName(user.firstName);
                Pages.RegisterPage.SetLastName(user.lastName);
                Pages.RegisterPage.SetEmail(user.email);
                Pages.RegisterPage.SetTelephone(user.telephone);
                Pages.RegisterPage.SetFax(user.fax);
                Pages.RegisterPage.SetCompany(user.company);
                Pages.RegisterPage.SetAddress1(user.address_1);
                Pages.RegisterPage.SetAddress2(user.address_2);
                Pages.RegisterPage.SetCity(user.city);
                Pages.RegisterPage.SetPostCode(user.postCode);
                Pages.RegisterPage.SetCountry(user.country);
                Pages.RegisterPage.SetRegion(user.region);
                Pages.RegisterPage.SetPassword(user.password);
                Pages.RegisterPage.SetConfirmPassword(user.password);
            }
            catch (Exception exception)
            {
                LoggingLog.WritingLogging(null, exception);
            }
        }

        private void SetNecessaryCheckBoxAndContinue(bool yesNo = true)
        {
            try
            {  // select subscribe
                Pages.RegisterPage.SelectNewsLetter(yesNo);
                // agree with the terms
                Pages.RegisterPage.SetCheckAgreeTerms();
                // click button continue
                Pages.RegisterPage.ClickButtonContinue();
            }
            catch (Exception exception)
            {
                LoggingLog.WritingLogging(null, exception);
            }
          
        }
    }
}
