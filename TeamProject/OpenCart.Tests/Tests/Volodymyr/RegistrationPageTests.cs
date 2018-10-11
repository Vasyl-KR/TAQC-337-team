using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

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
            // get test data
            User user = yesNo ? UserList[1] : UserList[3];
            string expectedMessage = ConfirmationRegisterPage.ExpectedSuccessMessage;

            // Act                   
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue(yesNo);
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
            User user = UserList[0];
            string expectedMessage = RegisterPage.EmailAlreadyExist;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.MainWarningMessage.Text;
           
            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_First_Name_Empty()
        {
            // Arrange
            User user = UserList[1];
            user.firstName = String.Empty;
            string expectedMessage = RegisterPage.FirstNameWarningText;

            // Act           
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.FirstNameWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Last_Name_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.lastName = String.Empty;
            string expectedMessage = RegisterPage.LastNameWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.LastNameWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Email_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.email = String.Empty;
            string expectedMessage = RegisterPage.EmailWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.EmailWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Telephone_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.telephone = String.Empty;
            string expectedMessage = RegisterPage.TelephoneWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.TelephoneWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Address1_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.address_1 = String.Empty;
            string expectedMessage = RegisterPage.Address1WarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.Address1WarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_City_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.city = String.Empty;
            string expectedMessage = RegisterPage.CityWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.CityWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Country_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.country = RegisterPage.PleseSelect;
            user.region = RegisterPage.None;
            string expectedMessage = RegisterPage.CountryWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.CountryWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Region_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.region = RegisterPage.PleseSelect;
            string expectedMessage = RegisterPage.RegionWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.RegionWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Password_Empty()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.password = String.Empty;
            string expectedMessage = RegisterPage.PasswordWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.PasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_ConfirmPassword_NoMatch()
        {
            // Arrange
            // get test data
            User user = UserList[1];
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
            SetNecessaryTickAndContinue();

            string actualMessage = Pages.RegisterPage.ConfirmPasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_PasswordIsToShort()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            user.password = RegisterPage.ShotPassword;
            string expectedMessage = RegisterPage.PasswordWarningText;

            // Act
            FillFieldsUserData(user);
            SetNecessaryTickAndContinue();
            string actualMessage = Pages.RegisterPage.PasswordWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]

        public void UnSuccess_Register_Not_Agree_Terms()
        {
            // Arrange
            // get test data
            User user = UserList[1];
            string expectedMessage = RegisterPage.AgreeTermsWarningText;

            // Act
            FillFieldsUserData(user);
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter(true);
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();
            string actualMessage = Pages.RegisterPage.MainWarningMessage.Text;

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        private void FillFieldsUserData(User user)
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

        private void SetNecessaryTickAndContinue(bool yesNo = true)
        {
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter(yesNo);
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();
        }
    }
}
