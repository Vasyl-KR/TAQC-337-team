using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class RegistrationPage_Tests : BaseTest
    {
        /// <summary>
        /// Positive tests for registering new user
        /// </summary>
        /// <param name="yesNo"></param>
        [TestCase(true)]
        [TestCase(false)]
        public void Positive_Registration_New_User(bool yesNo)
        {
            // create test data
            User user = yesNo ? UserList[0] : UserList[1];

            string expectedMessage = ConfirmationRegisterPage.ExpectedSuccessMessage;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();
            //fill fields
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter(yesNo);
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.ConfirmationRegisterPage.SuccessMessageH1Element.Text;
            // click button continue on confirmation page
            Pages.ConfirmationRegisterPage.ClickConfirmationButtonContinue();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_First_Name_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.FirstNameWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();
            
            //fill fields
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.FirstNameWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Last_Name_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.LastNameWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
            Pages.RegisterPage.SetFirstName(user.firstName);
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.LastNameWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Email_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.EmailWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
            Pages.RegisterPage.SetFirstName(user.firstName);
            Pages.RegisterPage.SetLastName(user.lastName);
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.EmailWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Telephone_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.TelephoneWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
            Pages.RegisterPage.SetFirstName(user.firstName);
            Pages.RegisterPage.SetLastName(user.lastName);
            Pages.RegisterPage.SetEmail(user.email);
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.TelephoneWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Address1_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.Address1WarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
            Pages.RegisterPage.SetFirstName(user.firstName);
            Pages.RegisterPage.SetLastName(user.lastName);
            Pages.RegisterPage.SetEmail(user.email);
            Pages.RegisterPage.SetTelephone(user.telephone);
            Pages.RegisterPage.SetFax(user.fax);
            Pages.RegisterPage.SetCompany(user.company);
            Pages.RegisterPage.SetAddress2(user.address_2);
            Pages.RegisterPage.SetCity(user.city);
            Pages.RegisterPage.SetPostCode(user.postCode);
            Pages.RegisterPage.SetCountry(user.country);
            Pages.RegisterPage.SetRegion(user.region);
            Pages.RegisterPage.SetPassword(user.password);
            Pages.RegisterPage.SetConfirmPassword(user.password);
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.Address1WarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_City_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.CityWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
            Pages.RegisterPage.SetFirstName(user.firstName);
            Pages.RegisterPage.SetLastName(user.lastName);
            Pages.RegisterPage.SetEmail(user.email);
            Pages.RegisterPage.SetTelephone(user.telephone);
            Pages.RegisterPage.SetFax(user.fax);
            Pages.RegisterPage.SetCompany(user.company);
            Pages.RegisterPage.SetAddress1(user.address_1);
            Pages.RegisterPage.SetAddress2(user.address_2);
            Pages.RegisterPage.SetPostCode(user.postCode);
            Pages.RegisterPage.SetCountry(user.country);
            Pages.RegisterPage.SetRegion(user.region);
            Pages.RegisterPage.SetPassword(user.password);
            Pages.RegisterPage.SetConfirmPassword(user.password);
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.CityWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Country_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.CountryWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
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
            Pages.RegisterPage.SetCountry(" --- Please Select --- ");
            Pages.RegisterPage.SetPassword(user.password);
            Pages.RegisterPage.SetConfirmPassword(user.password);
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.CountryWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Region_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.RegionWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
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
            Pages.RegisterPage.SetRegion(" --- Please Select --- ");
            Pages.RegisterPage.SetPassword(user.password);
            Pages.RegisterPage.SetConfirmPassword(user.password);
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.RegionWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_Password_Empty()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.PasswordWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.PasswordWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void UnSuccess_Register_ConfirmPassword_NoMatch()
        {
            // create test data
            User user = UserList[1];

            string expectedMessage = RegisterPage.ConfirmWarningText;

            // go to RegisterPage
            Pages.RegisterPage.ClickRegiser();

            //fill fields
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
            // select subscribe
            Pages.RegisterPage.SelectNewsLetter();
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            string actualMessage = Pages.RegisterPage.ConfirmPasswordWarningMessage.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
