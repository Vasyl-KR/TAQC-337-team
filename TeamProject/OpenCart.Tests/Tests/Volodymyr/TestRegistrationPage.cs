using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Volodymyr
{
    [TestFixture]
    public class TestRegistrationPage: BaseTest
    {
        [Test]
        public void Test_Register_User()
        {
            // create test data
            User user = ReaderUserData.GetUserByIndex(1);

            string expectedMessage = ConfirmationRegisterPage.ExpectedSuccessMessage;            
            string actualMessage = String.Empty;

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
            Pages.RegisterPage.SelectNewsLetter(false);
            // agree with the terms
            Pages.RegisterPage.SetCheckAgreeTerms();
            // click button continue
            Pages.RegisterPage.ClickButtonContinue();

            actualMessage = Pages.ConfirmationRegisterPage.SuccessMessageH1Element.Text;
            // click button continue on confirmation page
            Pages.ConfirmationRegisterPage.ClickConfirmationButtonContinue();

            Assert.AreEqual(expectedMessage, actualMessage);
        }    
    }
}
