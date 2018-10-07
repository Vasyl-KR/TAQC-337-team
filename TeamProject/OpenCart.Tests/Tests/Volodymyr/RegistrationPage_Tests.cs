using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
            User user = yesNo ? ReaderUserData.GetUserByIndex(0) : ReaderUserData.GetUserByIndex(1);

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
//[Test]
        //public void Test_(bool yesNo)
        //{
        //    // create test data
        //    User user = yesNo ? ReaderUserData.GetUserByIndex(0) : ReaderUserData.GetUserByIndex(1);

        //    string expectedMessage = ConfirmationRegisterPage.ExpectedSuccessMessage;

        //    // go to RegisterPage
        //    Pages.RegisterPage.ClickRegiser();
        //    //fill fields
        //    Pages.RegisterPage.SetFirstName(user.firstName);
        //    Pages.RegisterPage.SetLastName(user.lastName);
        //    Pages.RegisterPage.SetEmail(user.email);
        //    Pages.RegisterPage.SetTelephone(user.telephone);
        //    Pages.RegisterPage.SetFax(user.fax);
        //    Pages.RegisterPage.SetCompany(user.company);
        //    Pages.RegisterPage.SetAddress1(user.address_1);
        //    Pages.RegisterPage.SetAddress2(user.address_2);
        //    Pages.RegisterPage.SetCity(user.city);
        //    Pages.RegisterPage.SetPostCode(user.postCode);
        //    Pages.RegisterPage.SetCountry(user.country);
        //    Pages.RegisterPage.SetRegion(user.region);
        //    Pages.RegisterPage.SetPassword(user.password);
        //    Pages.RegisterPage.SetConfirmPassword(user.password);
        //    // select subscribe
        //    Pages.RegisterPage.SelectNewsLetter(yesNo);
        //    // agree with the terms
        //    Pages.RegisterPage.SetCheckAgreeTerms();
        //    // click button continue
        //    Pages.RegisterPage.ClickButtonContinue();

        //    string actualMessage = Pages.ConfirmationRegisterPage.SuccessMessageH1Element.Text;
        //    // click button continue on confirmation page
        //    Pages.ConfirmationRegisterPage.ClickConfirmationButtonContinue();

        //    Assert.AreEqual(expectedMessage, actualMessage);
        //}

    }
}
