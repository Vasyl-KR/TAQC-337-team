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
        public void Add_NewAddress()
        {

            int ListSizeBeforeAdding = Pages.AddressPage.ListAddresses.Count();

            int ListSizeAfterAdding = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[0])
                .ListAddresses.Count();

            NUnit.Framework.Assert.AreEqual(ListSizeBeforeAdding + 1, ListSizeAfterAdding, "Compare list size after adding new address" + ListSizeBeforeAdding + " == " + ListSizeAfterAdding);

        }

        [Test]
        public void Add_NewAddress_CompareMessage()
        {

            string actual = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(users.Users[1])
                .GetSuccessfulMessage();

            string expected = "Your address has been successfully inserted";

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare the text of the comunicat about adding");
        }


        [Test]
        public void Add_NewAddress_CompareInsertedInfo()
        {
            User user = users.Users[2];
            string actual = Pages.AddressPage
                .ClickNewAddressButton()
                .SuccessfullEditionAddress(user)
                .GetAddressIfno(user.firstName, user.lastName);

            string expected = user.firstName + " " + user.lastName + "\r\n" +
                              user.address_1 + "\r\n" +
                              user.city + " " + user.postCode + "\r\n" +
                              user.region + "\r\n" +
                              user.country;

            NUnit.Framework.Assert.AreEqual(actual, expected, "Compare ------");
        }


    }
}

