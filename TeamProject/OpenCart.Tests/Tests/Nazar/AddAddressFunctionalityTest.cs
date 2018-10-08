using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{

    [TestFixture]
    public class AddAddressFunctionalityTest : NazarBaseTest
    {

        [Test]
        public void AddAddress_CompareListSize()
        {
            //Arrange 
            int ListSizeBeforeAdding = Pages.AddressPage.ListAddressesLenght();

            //Act
            int ListSizeAfterAdding = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[0])
                .ListAddressesLenght();

            //Assert
            NUnit.Framework.Assert.AreEqual(ListSizeBeforeAdding + 1, ListSizeAfterAdding, "Compare list size after adding new address" + ListSizeBeforeAdding + " == " + ListSizeAfterAdding);

        }

        [Test]
        public void AddNewAddress_CompareMessage()
        {
            //Act
            string actualMessage = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[1])
                .GetSuccessfulMessage();

            //Arrange 
            string expectedMessage = "Your address has been successfully inserted";

            //Assert
            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage, "Compare the text of the comunicat about adding");
        }


        [Test]
        public void AddNewAddress_CompareInsertedInfo()
        {
            //Act
            User user = users.Users[2];
            string actualAddressInfo = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(user)
                .GetAddressIfno(user.firstName, user.lastName);

            //Arrange 
            string expectedAddressInfo = user.firstName + " " + user.lastName + "\r\n" +
                              user.address_1 + "\r\n" +
                              user.city + " " + user.postCode + "\r\n" +
                              user.region + "\r\n" +                    
                              user.country;
            //Assert
            NUnit.Framework.Assert.AreEqual(actualAddressInfo, expectedAddressInfo, "Compare address info");
        }


    }
}

