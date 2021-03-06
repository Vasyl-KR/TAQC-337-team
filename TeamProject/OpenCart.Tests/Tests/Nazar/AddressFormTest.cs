﻿using NUnit.Framework;
using OpenCartTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Nazar
{
    [TestFixture]
    class AddressFormTest : NazarBaseTest
    {
        [Test]
        public void AddressForm_ValidationMessage_LastName()
        {
            //Act
            Driver.Navigate().GoToUrl(URL_AddressPage);
            User user = users.Users[2];
            user.lastName = "";
            string actualMessage = Pages.AddressPage
                .EditRaw(2)
                .UnsuccessfullEditionAddress(user)
                .GetWarningMessage();

            //Arrange 
            string expectedMessage = "Last Name must be between 1 and 32 characters!";

            //Assert
            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage, "Compare the text of the message");
        }

        [Test]
        public void AddressForm_ValidationMessage_Address1()
        {
            //Act
            Driver.Navigate().GoToUrl(URL_AddressPage);
            User user = users.Users[2];
            user.address_1 = "";
            string actualMessage = Pages.AddressPage
                .EditRaw(2)
                .UnsuccessfullEditionAddress(user)
                .GetWarningMessage();

            //Arrange 
            string expectedMessage = "Address must be between 3 and 128 characters!";

            //Assert
            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage, "Compare the text of the message");
        }
    }
}
